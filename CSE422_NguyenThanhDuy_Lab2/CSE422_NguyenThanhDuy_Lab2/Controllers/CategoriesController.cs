using CSE422_NguyenThanhDuy_Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSE422_NguyenThanhDuy_Lab2.Controllers
{
    public class CategoriesController : Controller
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Computer" },
            new Category { Id = 2, Name = "Printer" },
            new Category { Id = 3, Name = "Phone" }
        };

        // Display a list of categories
        public IActionResult Index()
        {
            return View(categories);
        }
        public static List<Category> GetCategories() => categories;

        // Add a new category
        public IActionResult AddCategories()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddCategories(Category category)
		{
			category.Id = categories.Count > 0 ? categories.Max(c => c.Id) + 1 : 1;
			categories.Add(category);
			return RedirectToAction("Index");
		}

		// GET: Edit Device
		public IActionResult EditCategories(int id)
		{
			var deviceToEdit = categories.FirstOrDefault(c => c.Id == id);
			if (deviceToEdit == null)
			{
				return NotFound();
			}
			return View(deviceToEdit);
		}

		// POST: Update Device
		[HttpPost]
		public IActionResult EditCategories(Category updated)
		{
			var deviceToUpdate = categories.FirstOrDefault(c => c.Id == updated.Id);
			if (deviceToUpdate != null)
			{
				deviceToUpdate.Name = updated.Name;
		
			}
			return RedirectToAction("Index");
		}



		// Delete a category
		public IActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                categories.Remove(category);
            }
            return RedirectToAction("Index");
        }
      
       
        
    }
}
