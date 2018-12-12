﻿using System;
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
    public class ReservationsController : Controller
    {
        private readonly ReleaseCandContext _context;

        public ReservationsController(ReleaseCandContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservation.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .FirstOrDefaultAsync(m => m.ReservationID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationID,LastName,FirstName,Email,PhoneNumber,NumOfGuests,Reasons,Other,SpecialRequests,CustomerDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationID,LastName,FirstName,Email,PhoneNumber,NumOfGuests,Reasons,Other,SpecialRequests,CustomerDate")] Reservation reservation)
        {
            if (id != reservation.ReservationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationID))
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
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .FirstOrDefaultAsync(m => m.ReservationID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            _context.Reservation.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.ReservationID == id);
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
            return View();
        }
    }
}
