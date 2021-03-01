using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCars.Data;

namespace WebApplicationCars.Models
{
    public class CarsController : Controller
    {
        private readonly MvcCarContext _context;

        public CarsController(MvcCarContext context)
        {
            _context = context;
        }

        // GET: Cars

        public async Task<IActionResult> Index(string currentFilter,string SearchString,int? pageNumber)
        {


            
                ViewData["CurrentFilter"] = SearchString;
               


            if (SearchString != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    SearchString = currentFilter;
                }



                var cars = from m in _context.Cars select m;


                if (!string.IsNullOrEmpty(SearchString))
                {
                    cars = cars.Where(s => s.Marca.Contains(SearchString)
                    || s.Placa.Contains(SearchString)
                    );
                }

                

               /* var carsPlacaVM = new CarMarcaViewModel
                {
                    Marca = new SelectList(await genreQuery.Distinct().ToListAsync()),
                    Cars = await cars.ToListAsync()
                };
               */





                int pageSize = 10;
                return View( await PaginatedList<Car>.Create(cars.AsNoTracking(), pageNumber ?? 1, pageSize));
            }

            // GET: Cars/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var car = await _context.Cars
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (car == null)
                {
                    return NotFound();
                }

                return View(car);
            }

            // GET: Cars/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Cars/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("ID,Placa,Marca,NumeroSerie,Modelo")] Car car)
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
                return View(car);
            }

            // POST: Cars/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("ID,Placa,Marca,NumeroSerie,Modelo")] Car car)
            {
                if (id != car.ID)
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
                        if (!CarExists(car.ID))
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





            private bool CarExists(int id)
            {
                return _context.Cars.Any(e => e.ID == id);
            }
        }
    }
