using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TirelireProject.Data;
using TirelireProject.Models;

namespace TirelireProject.Controllers
{
    public class PaymentOrdersController : Controller
    {
        private readonly TirelireProjectContext _context;

        public PaymentOrdersController(TirelireProjectContext context)
        {
            _context = context;
        }

        // GET: PaymentOrders
        public async Task<IActionResult> Index()
        {
            var tirelireProjectContext = _context.PaymentOrders.Include(p => p.ShoppingCart);
            return View(await tirelireProjectContext.ToListAsync());
        }

        // GET: PaymentOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PaymentOrders == null)
            {
                return NotFound();
            }

            var paymentOrder = await _context.PaymentOrders
                .Include(p => p.ShoppingCart)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentOrder == null)
            {
                return NotFound();
            }

            return View(paymentOrder);
        }

        // GET: PaymentOrders/Create
        public IActionResult Create()
        {
            ViewData["ShoppingCartId"] = new SelectList(_context.ShoppingCart, "Id", "Id");
            return View();
        }

        // POST: PaymentOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderDate,TotalAmountTTC,ShoppingCartId")] PaymentOrder paymentOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShoppingCartId"] = new SelectList(_context.ShoppingCart, "Id", "Id", paymentOrder.ShoppingCartId);
            return View(paymentOrder);
        }

        // GET: PaymentOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PaymentOrders == null)
            {
                return NotFound();
            }

            var paymentOrder = await _context.PaymentOrders.FindAsync(id);
            if (paymentOrder == null)
            {
                return NotFound();
            }
            ViewData["ShoppingCartId"] = new SelectList(_context.ShoppingCart, "Id", "Id", paymentOrder.ShoppingCartId);
            return View(paymentOrder);
        }

        // POST: PaymentOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderDate,TotalAmountTTC,ShoppingCartId")] PaymentOrder paymentOrder)
        {
            if (id != paymentOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentOrderExists(paymentOrder.Id))
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
            ViewData["ShoppingCartId"] = new SelectList(_context.ShoppingCart, "Id", "Id", paymentOrder.ShoppingCartId);
            return View(paymentOrder);
        }

        // GET: PaymentOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaymentOrders == null)
            {
                return NotFound();
            }

            var paymentOrder = await _context.PaymentOrders
                .Include(p => p.ShoppingCart)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentOrder == null)
            {
                return NotFound();
            }

            return View(paymentOrder);
        }

        // POST: PaymentOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaymentOrders == null)
            {
                return Problem("Entity set 'TirelireProjectContext.PaymentOrders'  is null.");
            }
            var paymentOrder = await _context.PaymentOrders.FindAsync(id);
            if (paymentOrder != null)
            {
                _context.PaymentOrders.Remove(paymentOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentOrderExists(int id)
        {
          return (_context.PaymentOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
