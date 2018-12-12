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
    public class OnOrdsController : Controller
    {
        private readonly ReleaseCandContext _context;

        public OnOrdsController(ReleaseCandContext context)
        {
            _context = context;
        }

        // GET: OnOrds
        public async Task<IActionResult> Index()
        {
            return View(await _context.OnOrd.ToListAsync());
        }

        // GET: OnOrds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onOrd = await _context.OnOrd
                .FirstOrDefaultAsync(m => m.OnOrdID == id);
            if (onOrd == null)
            {
                return NotFound();
            }

            return View(onOrd);
        }

        // GET: OnOrds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OnOrds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OnOrdID,LastName,FirstName,Email,PhoneNumber,CheeseBurger,Lasagna,TiriMisu,CheeseCake,FrenchFries,Pepsi,Sprite,Water,BillAddress,BillCity,BillState,BillZip,CreditCardNum,CCV,ExpDate")] OnOrd onOrd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onOrd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(onOrd);
        }

        // GET: OnOrds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onOrd = await _context.OnOrd.FindAsync(id);
            if (onOrd == null)
            {
                return NotFound();
            }
            return View(onOrd);
        }

        // POST: OnOrds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OnOrdID,LastName,FirstName,Email,PhoneNumber,CheeseBurger,Lasagna,TiriMisu,CheeseCake,FrenchFries,Pepsi,Sprite,Water,BillAddress,BillCity,BillState,BillZip,CreditCardNum,CCV,ExpDate")] OnOrd onOrd)
        {
            if (id != onOrd.OnOrdID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onOrd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnOrdExists(onOrd.OnOrdID))
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
            return View(onOrd);
        }

        // GET: OnOrds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onOrd = await _context.OnOrd
                .FirstOrDefaultAsync(m => m.OnOrdID == id);
            if (onOrd == null)
            {
                return NotFound();
            }

            return View(onOrd);
        }

        // POST: OnOrds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var onOrd = await _context.OnOrd.FindAsync(id);
            _context.OnOrd.Remove(onOrd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnOrdExists(int id)
        {
            return _context.OnOrd.Any(e => e.OnOrdID == id);
        }

        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(OnOrdViewModel viewModel)
        {
            var meal = new Meal
            {
                CheeseBurger = viewModel.CheeseBurger,
                Lasagna = viewModel.Lasagna,
                TiriMisu = viewModel.TiriMisu,
                CheeseCake = viewModel.CheeseCake,
                FrenchFries = viewModel.FrenchFries,
                Pepsi = viewModel.Pepsi,
                Sprite = viewModel.Sprite,
                Water = viewModel.Water
            };

            var creditIn = new CreditIn
            {
                BillAddress = viewModel.BillAddress,
                BillCity = viewModel.BillCity,
                BillState = viewModel.BillState,
                BillZip = viewModel.BillZip,
                CreditCardNum = viewModel.CreditCardNum,
                CCV = viewModel.CCV,
                ExpDate = viewModel.ExpDate
            };

            var perInfo = new PerInfo
            {
                LastName = viewModel.LastName,
                FirstName = viewModel.FirstName,
                Email = viewModel.Email,
                Phone = viewModel.Phone
            };

            var req = new Req
            {
                Date = DateTime.Now,
                Meal = meal,
                CreditIn = creditIn,
                PerInfo = perInfo
            };

            if (ModelState.IsValid)
            {
                _context.Add(meal);
                _context.Add(creditIn);
                _context.Add(perInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Report", "Home");
            }

            //var reqs = await _context.Req
            //    .include(x => x.Meal)
            //    .include(x => x.CreditIn)
            //    .include(x => x.PerInfo)
            //    .ToListAsync();

            //foreach (var x in reqs)
            //{
            //    if ((req.PerInfo.LastName == perInfo.LastName) && (req.PerInfo.FirstName == perInfo.FirstName))
            //    {
            //        ModelState.AddModelError("LastName", "There is already an");
            //        ModelState.AddModelError("FirstName", "This first and last name already exists");
            //    }
            //}
            //return View(viewModel);

            return View(viewModel);
        }

        [HttpGet, HttpPost]
        public IActionResult Report()
        {
            //var reqs = await _context.Req

            return View();
        }
    }
}
