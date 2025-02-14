using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Authorize(Roles = "Admin")]
public class CarController : Controller
{
    private readonly ApplicationDbContext _context;

    public CarController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string searchString, string sortOrder, int page = 1)
    {
        int pageSize = 5;
        var cars = _context.Cars.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            cars = cars.Where(c => c.Brand.Contains(searchString) || c.Model.Contains(searchString));
        }

        cars = sortOrder switch
        {
            "brand_desc" => cars.OrderByDescending(c => c.Brand),
            "price_asc" => cars.OrderBy(c => c.RentalPrice),
            "price_desc" => cars.OrderByDescending(c => c.RentalPrice),
            _ => cars.OrderBy(c => c.Brand),
        };

        return View(await PaginatedList<Car>.CreateAsync(cars.AsNoTracking(), page, pageSize));
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound();
        return View(car);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Car car)
    {
        if (id != car.CarId) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound();
        return View(car);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null) _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private class PaginatedList<T>
    {
        internal static async Task<string?> CreateAsync(IQueryable<Car> cars, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
