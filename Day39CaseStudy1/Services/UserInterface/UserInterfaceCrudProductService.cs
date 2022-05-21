using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Day39CaseStudy.Services.Factory;


namespace Day39CaseStudy.Services.UserInterface;

public class UserInterfaceCrudProductService
{
    readonly ICrudService<Product> _productService;


    public UserInterfaceCrudProductService()
    {

        _productService = CrudFactory.Create<Product>();
    }

    public void Add()
    {
        var product = new Product();

        Console.WriteLine("Adding New Product");
        Console.WriteLine("----------------");

        Console.Write("Enter Product Name: ");
        var productNameText = Console.ReadLine();
        product.ProductName = productNameText;

        Console.Write("Enter Brand Id: ");
        var brandIdText = Console.ReadLine();
        product.BrandId = int.Parse(brandIdText);

        Console.Write("Enter CategoryId: ");
        var categoryIdText = Console.ReadLine();
        product.CategoryId = int.Parse(categoryIdText);

        Console.Write("Enter Model Year: ");
        var modelYearText = Console.ReadLine();
        product.ModelYear = short.Parse(modelYearText);

        Console.Write("Enter List Price: ");
        var listPriceText = Console.ReadLine();
        product.ListPrice = int.Parse(listPriceText);

        try
        {
            _productService.Add(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Adding product: {ex.Message}");
        }
    }

    public IEnumerable<Product> GetAll()
    {
        return _productService.GetAll();

    }

    public void Update()
    {
        Console.WriteLine("Updating existing Product");
        Console.WriteLine("-----------------------");

        Console.Write("Enter Product Name to Update: ");
        var productNameText = Console.ReadLine();

        var product = _productService.GetByName(productNameText);

        if (product == null)
        {
            Console.WriteLine($"Product Name {productNameText} not found!!");
            return;
        }

        Console.WriteLine($"Found Product: {product}");
        Console.WriteLine("-------------------------------------------------------");

        Console.Write("Enter Product Name to change: ");
        product.ProductName = Console.ReadLine();

        Console.Write("Enter Brand Id to change: ");
        var brandIdText = Console.ReadLine();
        product.BrandId = int.Parse(brandIdText);

        Console.Write("Enter CategoryId to change: ");
        var categoryIdText = Console.ReadLine();
        product.CategoryId = int.Parse(categoryIdText);

        Console.Write("Enter Model Year to change: ");
        var modelYearText = Console.ReadLine();
        product.ModelYear = short.Parse(modelYearText);

        Console.Write("Enter List Price to change: ");
        var listPriceText = Console.ReadLine();
        product.ListPrice = int.Parse(listPriceText);

        _productService.Update(product);
    }

    public void Delete()
    {
        Console.WriteLine("Deleting existing Product");
        Console.WriteLine("-----------------------");

        Console.Write("Enter the Product Id to delete: ");
        var productIdText = Console.ReadLine();
        var productId = int.Parse(productIdText);

        _productService.Delete(productId);
    }





    //----------------------------------------------------------------------------------------------------------------------------------

    public void Show()
    {
        var products = _productService.GetAll();

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine("=================================================================Formatted Report Of Products=========================" +
            "==============================================================================");
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine("Product List");
        Console.WriteLine("----------");

        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.WriteLine(Product.Header);

        Console.ResetColor();
        Console.WriteLine("**********************************************************************************************" +
                "*******************************************************************************************************");

        foreach (var product in products)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(product);
            Console.ResetColor();
            Console.WriteLine("=====================================================================================================" +
                "==============================================================================================");

        }
        Console.WriteLine("----------------------------------------------------------------------------------" +
            "-----------------------------------------------------------------------");
        Console.WriteLine();

        var check = 0;
        foreach (var brand in products)
        {

            if (check != brand.Brand.BrandId)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("=================================================================BrandWise Report Of Products=========================" +
            "==============================================================================");

                Console.ResetColor();

                Console.BackgroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Black;

                check = (int)brand.Brand.BrandId;
                Console.WriteLine($"{brand.Brand}");

                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Console.ResetColor();

                Console.WriteLine("**********************************************************************************************" +
              "*******************************************************************************************************");

                Console.WriteLine(Product.Header);

                Console.WriteLine("----------------------------------------------------------------------------------" +
                            "----------------------------------------------------------------------------------------------------------------");
            }
            else
            {

                continue;
            }

            foreach (var product in products)
            {
                if (product.BrandId == brand.BrandId)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------" +
                            "----------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{product}");


                }


            }


            Console.WriteLine("----------------------------------------------------------------------------------" +
                           "----------------------------------------------------------------------------------------------------------------");

        }


    }
}







