using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autobazar.Models;

namespace Autobazar.Controllers;

public class CarsController : Controller
{
    private readonly CarsContext _context;

    public CarsController(CarsContext context)
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
            .FirstOrDefaultAsync(m => m.Id == id);
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
    public async Task<IActionResult> Create([Bind("Id,Manufacturer,Model,ManufacturingDate,Tachometer,Fuels,Bodies,Spz,Conditions,InBazarFrom,Note")] Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = car.Id });
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
    public async Task<IActionResult> Edit(int id, [Bind("Id,Manufacturer,Model,ManufacturingDate,Tachometer,Fuels,Bodies,Spz,Conditions,InBazarFrom,Note")] Car car)
    {
        if (id != car.Id)
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
                if (!CarExists(car.Id))
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
    /*public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var car = await _context.Cars
            .FirstOrDefaultAsync(m => m.Id == id);
        if (car == null)
        {
            return NotFound();
        }

        return View(car);
    }*/

    // POST: Cars/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car is not null)
        {
            _context.Cars.Remove(car);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CarExists(int id)
    {
        return _context.Cars.Any(e => e.Id == id);
    }

    //GET: Car/Statistics
    public async Task<IActionResult> Statistics()
    {
        var cars = await _context.Cars.ToListAsync();

        var pseudoModel = new CarStatistics
        {
            CarsTotal = cars.Count,
            UnderOneHundredTotal = cars.Count(x => x.Tachometer < 100000),
            AboveOneHundredTotal = cars.Count(x => x.Tachometer >= 100000),
            PetrolTotal = cars.Count(x => x.Fuels == Fuel.Petrol),
            DieselTotal = cars.Count(x => x.Fuels == Fuel.Diesel),
            ElectroTotal = cars.Count(x => x.Fuels == Fuel.Electricity),
            GasTotal = cars.Count(x => x.Fuels == Fuel.Gas),
            ConditionGoodTotal = cars.Count(x => x.Conditions == Condition.Good),
            ConditionBadTotal = cars.Count(x => x.Conditions == Condition.Bad),
        };

        //var FinalModel = _context.Cars.ToListAsync();

        return View(pseudoModel);
    }

    //Validation of existing SPZ
    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> VerifySpz(string spz, int Id)
    {
        var editedCar = await _context.Cars.FirstOrDefaultAsync(x => x.Id == Id);
        var carWithSameSpz = await _context.Cars.FirstOrDefaultAsync(x => x.Spz == spz);
        var errorMsg = Json($"Státní značka se již používá.");

        if(carWithSameSpz==null || carWithSameSpz.Id == editedCar?.Id)
        {
            return Json(true);
        }

        return errorMsg;
    }
}
