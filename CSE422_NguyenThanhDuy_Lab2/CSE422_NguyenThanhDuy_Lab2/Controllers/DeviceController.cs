using CSE422_NguyenThanhDuy_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CSE422_NguyenThanhDuy_Lab2.Controllers
{
    public class DeviceController : Controller
    {
        private static List<Device> devices = new List<Device>
{
    new Device { Id = 1, Name = "Computer", Code = "CMP-001", CategoryId = 1, Status = "In use", DateOfEntry = new DateTime(2023, 5, 10) },
    new Device { Id = 2, Name = "Printer", Code = "PRT-002", CategoryId = 2, Status = "Under maintenance", DateOfEntry = new DateTime(2022, 11, 20) },
    new Device { Id = 3, Name = "Phone", Code = "PHN-003", CategoryId = 3, Status = "In use", DateOfEntry = new DateTime(2023, 1, 15) },
    new Device { Id = 4, Name = "Laptop", Code = "LAP-004", CategoryId = 1, Status = "In use", DateOfEntry = new DateTime(2023, 6, 5) },
    new Device { Id = 5, Name = "Tablet", Code = "TAB-005", CategoryId = 2, Status = "Broken", DateOfEntry = new DateTime(2022, 8, 30) },
    new Device { Id = 6, Name = "Smartwatch", Code = "SW-006", CategoryId = 3, Status = "In use", DateOfEntry = new DateTime(2022, 12, 2) },
    new Device { Id = 7, Name = "Projector", Code = "PRJ-007", CategoryId = 2, Status = "Under maintenance", DateOfEntry = new DateTime(2023, 3, 18) },
    new Device { Id = 8, Name = "Router", Code = "RT-008", CategoryId = 1, Status = "In use", DateOfEntry = new DateTime(2023, 7, 10) },
    new Device { Id = 9, Name = "Camera", Code = "CAM-009", CategoryId = 3, Status = "In use", DateOfEntry = new DateTime(2022, 10, 15) },
    new Device { Id = 10, Name = "Speaker", Code = "SPK-010", CategoryId = 2, Status = "In use", DateOfEntry = new DateTime(2023, 2, 12) }
};



		// Display all device 
		public IActionResult Index(int? categoryId, string searchTerm, string statusFilter)
		{
			// Start with all devices
			var filteredDevices = devices.AsQueryable();

			// Filter by category if provided
			if (categoryId.HasValue && categoryId.Value != 0)
			{
				filteredDevices = filteredDevices.Where(d => d.CategoryId == categoryId.Value);
			}
			if (!string.IsNullOrEmpty(statusFilter))
			{
				filteredDevices = filteredDevices.Where(d => d.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase));
			}


			// Search by device name or code if searchTerm is provided
			if (!string.IsNullOrEmpty(searchTerm))
			{
				filteredDevices = filteredDevices.Where(d =>
					d.Name.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase) ||
					d.Code.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase));
			}

			// Prepare category list for the dropdown in the view
			ViewBag.Categories = new SelectList(CategoriesController.GetCategories(), "Id","Name");

			ViewBag.Statuses = devices.Select(d => d.Status).Distinct().ToList();
			// Return the filtered list of devices to the view
			return View(filteredDevices.ToList());
		}


		// Add 
		public IActionResult AddDevices()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDevices(Device laptop)
        {
            laptop.Id = devices.Count > 0 ? devices.Max(c => c.Id) + 1 : 1;
            devices.Add(laptop);
            return RedirectToAction("Index");
        }
        //UPdate
        // GET: Edit Device
        public IActionResult EditDevices(int id)
        {
            var deviceToEdit = devices.FirstOrDefault(c => c.Id == id);
            if (deviceToEdit == null)
            {
                return NotFound();
            }
            return View(deviceToEdit);
        }

        // POST: Update Device
        [HttpPost]
        public IActionResult EditDevices(Device updatedDevice)
        {
            var deviceToUpdate = devices.FirstOrDefault(c => c.Id == updatedDevice.Id);
            if (deviceToUpdate != null)
            {
                deviceToUpdate.Name = updatedDevice.Name;
                deviceToUpdate.Code = updatedDevice.Code;
                deviceToUpdate.Status = updatedDevice.Status;
                deviceToUpdate.CategoryId = updatedDevice.CategoryId;
                deviceToUpdate.DateOfEntry = updatedDevice.DateOfEntry;
            }
            return RedirectToAction("Index");
        }

        //Delete
        public IActionResult DeleteDevices(int id)
        {
            var deviceToDelete = devices.FirstOrDefault(c => c.Id == id);
            if (deviceToDelete != null)
            {
                devices.Remove(deviceToDelete);
            }
            return RedirectToAction("Index");
        }

    }

}
