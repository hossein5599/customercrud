using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Customers;
using MohammadHosseinSadeghiCrudTest.Data;
using MohammadHosseinSadeghiCrudTest.Infrustracture;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MohammadHosseinSadeghiCrudTest.Models;
using ParsianTadrisExamSadeghi.Models.DTOs;

namespace MohammadHosseinSadeghiCrudTest.Controllers
{
    public class CustomersController : Controller
    {
        // private readonly ApplicationDbContext _context;

        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(/*ApplicationDbContext context*/IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomersController> logger)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;

        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            IEnumerable<CustomerModel> customers = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerModel>>(await _unitOfWork.Customer.GetAllAsync());
            return View(customers);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerModel customer = _mapper.Map<Customer, CustomerModel>(await _unitOfWork.Customer.GetById(id));

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateDTO customer)
        {
            if (ModelState.IsValid)
            {
                var cust = _mapper.Map<CustomerCreateDTO, Customer>(customer);

                await _unitOfWork.Customer.Create(cust);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _mapper.Map<Customer, CustomerEditDTO>(await _unitOfWork.Customer.GetById(id));
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  CustomerEditDTO customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Customer.Update(_mapper.Map<CustomerEditDTO, Customer>(customer) );
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _unitOfWork.Customer.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _unitOfWork.Customer.GetById(id);
            await _unitOfWork.Customer.Delete(id);
            await _unitOfWork.CompleteAsync();

          
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _unitOfWork.Customer.Exists(id);
        }
    }
}
