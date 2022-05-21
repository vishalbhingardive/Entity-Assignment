using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;

namespace Day39CaseStudy.Services.DbService;

public class CrudCategoryService : ICrudService<Category>
{
    public void Add(Category cat)
    {
        using var context = new SampleStoreDbContext();

        context.Categories.Add(cat);
        context.SaveChanges();
    }

    public void Delete(int categoryId)
    {
        using var context = new SampleStoreDbContext();

        var cat = from s in context.Categories
                  where s.CategoryId == categoryId
                  select s;

        if (cat == null)
        {
            Console.WriteLine($"CategoryId {categoryId} not found");
            return;
        }
        context.Categories.Remove(cat.SingleOrDefault());
        context.SaveChanges();
    }

    public IEnumerable<Category> GetAll()
    {
        //using var context = new SampleStoreDbContext();
        //var categories = from c in context.Categories
        //                 select c;

        //foreach (var category in categories)
        //{
        //    Console.WriteLine($"{category}");

        //}
        //return categories.ToList();

        using var context = new SampleStoreDbContext();

        var list = from s in context.Categories

                   select s;


        return list.ToList();

    }

    public Category GetByName(string categoryName)
    {
        using var context = new SampleStoreDbContext();

        var list = from s in context.Categories
                   where s.CategoryName == categoryName
                   select s;

        foreach (var cat in list)
        {
            Console.WriteLine(cat);
            return cat;
        }

        return list.SingleOrDefault();

    }

    public void Update(Category cat)
    {
        using var context = new SampleStoreDbContext();

        context.Categories.Update(cat);
        context.SaveChanges();
    }

}