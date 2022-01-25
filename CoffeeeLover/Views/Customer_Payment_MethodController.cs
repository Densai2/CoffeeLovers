#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeeLover.Data;
using CoffeeeLover.Models;

namespace CoffeeeLover.Views
{
    public class Customer_Payment_MethodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Customer_Payment_MethodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customer_Payment_Method
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer_Payment_Method.ToListAsync());
        }

        // GET: Customer_Payment_Method/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer_Payment_Method = await _context.Customer_Payment_Method
                .FirstOrDefaultAsync(m => m.PaymentMethodCode == id);
            if (customer_Payment_Method == null)
            {
                return NotFound();
            }

            return View(customer_Payment_Method);
        }

        // GET: Customer_Payment_Method/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer_Payment_Method/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentMethodCode,CardNumber,DateOfPurcahse,Total,BillNumber")] Customer_Payment_Method customer_Payment_Method)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer_Payment_Method);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer_Payment_Method);
        }

        // GET: Customer_Payment_Method/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer_Payment_Method = await _context.Customer_Payment_Method.FindAsync(id);
            if (customer_Payment_Method == null)
            {
                return NotFound();
            }
            return View(customer_Payment_Method);
        }

        // POST: Customer_Payment_Method/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentMethodCode,CardNumber,DateOfPurcahse,Total,BillNumber")] Customer_Payment_Method customer_Payment_Method)
        {
            if (id != customer_Payment_Method.PaymentMethodCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer_Payment_Method);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Customer_Payment_MethodExists(customer_Payment_Method.PaymentMethodCode))
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
            return View(customer_Payment_Method);
        }

        // GET: Customer_Payment_Method/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer_Payment_Method = await _context.Customer_Payment_Method
                .FirstOrDefaultAsync(m => m.PaymentMethodCode == id);
            if (customer_Payment_Method == null)
            {
                return NotFound();
            }

            return View(customer_Payment_Method);
        }

        // POST: Customer_Payment_Method/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer_Payment_Method = await _context.Customer_Payment_Method.FindAsync(id);
            _context.Customer_Payment_Method.Remove(customer_Payment_Method);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Customer_Payment_MethodExists(int id)
        {
            return _context.Customer_Payment_Method.Any(e => e.PaymentMethodCode == id);
        }
    }
}
