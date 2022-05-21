using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Day39CaseStudy.Services.Factory;


namespace Day39CaseStudy.Services.UserInterface;

public class UserInterfaceCrudCategoryService
{
    readonly ICrudService<Category> _categoryService;

    public UserInterfaceCrudCategoryService()
    {
        _categoryService = CrudFactory.Create<Category>();
    }

    public void Add()
    {
        Console.WriteLine("Adding New Category");
        Console.WriteLine("-------------------");

        Console.Write("Enter Category Name:");
        var categoryText = Console.ReadLine();

        var cat = new Category { CategoryName = categoryText };
        _categoryService.Add(cat);
    }

    public IEnumerable<Category> GetAll()
    {
        return _categoryService.GetAll();
    }

    public void Update()
    {
        Console.WriteLine("Updating Existing Category");
        Console.WriteLine("--------------------------");

        Console.WriteLine("Enter Category Name To Update");
        var categoryText = Console.ReadLine();

        var cat = _categoryService.GetByName(categoryText);

        if (cat == null)
        {
            Console.WriteLine($"Category Name {categoryText} Not Found !!");
            return;
        }
        Console.WriteLine($"Found Category: {cat}");

        Console.WriteLine("Enter Category Name to change: ");
        var changeCategoryNameText = Console.ReadLine();

        cat.CategoryName = changeCategoryNameText;

        _categoryService.Update(cat);
    }


    public void Delete()
    {
        Console.WriteLine("Deleting existing Category");
        Console.WriteLine("--------------------------");

        Console.WriteLine("Enter the Category Id to Delete: ");
        var categoryIdText = Console.ReadLine();

        var categoryId = int.Parse(categoryIdText);

        try
        {
            _categoryService.Delete(categoryId);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Delete Category Failed!! {ex.Message}");
            Console.ResetColor();
        }
    }

    public void Show()
    {
        var cat = _categoryService.GetAll();

        Console.WriteLine("Category list");
        Console.WriteLine("==================================");

        Console.WriteLine(Category.Header);

        Console.WriteLine("==================================");

        foreach (var item in cat)
        {
            Console.WriteLine(item);
            Console.WriteLine("----------------------------------");

        }
        Console.WriteLine("------------------");

    }

}

