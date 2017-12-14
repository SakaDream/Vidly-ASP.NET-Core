using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if(customer == null)
                return NotFound();
            return View(customer);
        }

        public IActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm" ,viewModel);
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(CustomerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.MembershipTypes = _context.MembershipTypes.ToList();
                return View("CustomerForm", viewModel);
            }
            if (viewModel.Customer.Id == 0)
                _context.Customers.Add(viewModel.Customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);
                customerInDb.Name = viewModel.Customer.Name;
                customerInDb.Birthday = viewModel.Customer.Birthday;
                customerInDb.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}