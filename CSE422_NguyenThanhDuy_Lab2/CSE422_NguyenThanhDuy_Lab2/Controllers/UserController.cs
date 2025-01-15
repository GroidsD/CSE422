using CSE422_NguyenThanhDuy_Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSE422_NguyenThanhDuy_Lab2.Controllers
{
	public class UserController : Controller
	{
		private static List<User> users = new List<User>
{
	new User { Id = 1, FullName = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
	new User { Id = 2, FullName = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber = "987-654-3210" },
	new User { Id = 3, FullName = "Alice Johnson", Email = "alice.johnson@example.com", PhoneNumber = "555-123-4567" }
};


		// Display a list of categories
		public IActionResult Index()
		{
			return View(users);
		}

		// Add a new category
		public static List<User> GetUser() => users;
		public IActionResult AddUser()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddUser(User human)
		{
			human.Id = users.Count > 0 ? users.Max(c => c.Id) + 1 : 1;
			users.Add(human);
			return RedirectToAction("Index");
		}

		// GET: Edit Device
		public IActionResult EditUser(int id)
		{
			var deviceToEdit = users.FirstOrDefault(c => c.Id == id);
			if (deviceToEdit == null)
			{
				return NotFound();
			}
			return View(deviceToEdit);
		}

		// POST: Update Device
		[HttpPost]
		public IActionResult EditUser(User updated)
		{
			var deviceToUpdate = users.FirstOrDefault(c => c.Id == updated.Id);
			if (deviceToUpdate != null)
			{
				deviceToUpdate.Id = updated.Id;
				deviceToUpdate.FullName = updated.FullName;
				deviceToUpdate.Email = updated.Email;
				deviceToUpdate.PhoneNumber = updated.PhoneNumber;

			}
			return RedirectToAction("Index");
		}


		// Delete a category
		public IActionResult DeleteUser(int id)
		{
			var category = users.FirstOrDefault(c => c.Id == id);
			if (category != null)
			{
				users.Remove(category);
			}
			return RedirectToAction("Index");
		}



	}
}
