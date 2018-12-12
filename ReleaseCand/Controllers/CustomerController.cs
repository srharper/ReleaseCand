using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReleaseCand.Models;
using ReleaseCand.ViewModels;
using System.Linq.Dynamic.Core;

namespace ReleaseCand.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ReleaseCandContext _context;

        public CustomerController(ReleaseCandContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,CustomerDate,NumOfGuests")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(CustomerReportViewModel viewModel)
        {
            var customer = new Customer
            {
                CustomerDate = viewModel.CustomerDate,
                NumOfGuests = viewModel.NumOfGuests
            };
            var custInfo = new CustInfo
            {
                LastName = viewModel.LastName,
                FirstName = viewModel.FirstName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber
            };

            var special = new Special
            {
                NumOfGuests = viewModel.NumOfGuests,
                Reasons = viewModel.Reasons,
                Other = viewModel.Other
            };

            if (ModelState.IsValid)
            {
                _context.Add(customer);
                _context.Add(custInfo);
                _context.Add(special);
                await _context.SaveChangesAsync();
                return RedirectToAction("Report", "Home");
            }
            return View(viewModel);

        }
        [HttpGet, HttpPost]
        public IActionResult Report()
        {

            //var customer = new Customer
            //{
            //    CustomerDate = viewModel.CustomerDate,
            //    NumOfGuests = viewModel.NumOfGuests
            //};
            //var custInfo = new CustInfo
            //{
            //    LastName = viewModel.LastName,
            //    FirstName = viewModel.FirstName,
            //    Email = viewModel.Email,
            //    PhoneNumber = viewModel.PhoneNumber
            //};

            //var special = new Special
            //{
            //    NumOfGuests = viewModel.NumOfGuests,
            //    Reasons = viewModel.Reasons,
            //    Other = viewModel.Other
            //};

            //if (ModelState.IsValid)
            //{
            //    _context.Add(customer);
            //    _context.Add(custInfo);
            //    _context.Add(special);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction("Report", "Home");
            //}
            ////var customers = await _context.Customer
            ////    .Include(x => x.Reservation)

            ////    .ToListAsync();
            ////var viewModel = new List<CustomerReportViewModel>();


            ////foreach (var total in customers)
            ////{
            ////    viewModel.Add(new CustomerReportViewModel
            ////    {
            ////        LastName = total.Reservation.LastName,
            ////        FirstName = total.Reservation.FirstName,
            ////        CustomerDate = total.CustomerDate,
            ////        NumOfGuests = total.Reservation.NumOfGuests
            ////    }


            ////        );
            ////}
            return View();
        }

            // GET: Customer/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,CustomerDate,NumOfGuests")] Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerID == id);
        }
    }
}
