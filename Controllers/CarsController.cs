using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarOwnerDealershipDB.Models;

namespace CarOwnerDealershipDB.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarOwnerDealershipContext _context;

        public CarsController(CarOwnerDealershipContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.carID == id);
            
            if (car == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealerships
                .FirstOrDefaultAsync(m => m.dealershipID == car.dealershipID);
            var owner = await _context.Owners
                .FirstOrDefaultAsync(m => m.ownerID == car.ownerID);
            car.dealership = dealership;
            car.owner = owner;

            return View(car);
        }

        // GET: Cars/Create
        /*public IActionResult Create()
        {
            return View();
        }*/

        // GET: Cars/Create
        public async Task<IActionResult> Create()
        {
            var dealerships = await _context.Dealerships.ToListAsync();

            var owners = await _context.Owners.ToListAsync();

            if (dealerships.Count > 0 && owners.Count > 0)
            {
                ViewBag.dealerships = dealerships;
                ViewBag.owners = owners;
                return View();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("carID,make,model,year,kilometers,dealershipID,ownerID")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            
            var dealerships = await _context.Dealerships.ToListAsync();
            var owners = await _context.Owners.ToListAsync();
            ViewBag.dealerships = dealerships;
            ViewBag.owners = owners;

            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("carID,make,model,year,kilometers,dealershipID,ownerID")] Car car)
        {
            if (id != car.carID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.carID))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.carID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.carID == id);
        }
    }
}
