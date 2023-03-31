using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;


namespace ShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly ShelterApiContext _db;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AnimalsController(ShelterApiContext db, IWebHostEnvironment webHostEnvironment)
    {
      _db = db;
      _webHostEnvironment = webHostEnvironment;
    }


    [HttpGet("page/{page}")]
    public async Task<ActionResult<List<Animal>>> GetPages(int page)
    {
      if (_db.Animals == null)
        return NotFound();

      var pageResults = 3f;
      var pageCount = Math.Ceiling(_db.Animals.Count() / pageResults);

      var animals = await _db.Animals
        .Skip((page - 1) * (int)pageResults)
        .Take((int)pageResults)
        .ToListAsync();

      var response = new AnimalResponse
      {
        Animals = animals,
        CurrentPage = page,
        Pages = (int)pageCount
      };
      return Ok(response);
    }

    [HttpGet]
    public async Task<List<Animal>> Get(string name, string species, string breed, int age)
    {

      IQueryable<Animal> query = _db.Animals.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (species != null)
      {
        query = query.Where(entry => entry.Species == species);
      }

      if (breed != null)
      {
        query = query.Where(entry => entry.Breed == breed);
      }

      if (age >= 0)
      {
        query = query.Where(entry => entry.Age >= age);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }

      return Ok(animal);
    }

[HttpPost]
public async Task<ActionResult<Animal>> Post([FromForm] Animal animal)
{
    if (ModelState.IsValid)
    {
        if (animal.Image != null)
        {
            using (var stream = new MemoryStream())
            {
                await stream.WriteAsync(animal.Image, 0, animal.Image.Length);
                animal.Image = stream.ToArray();
            }
        }
        _db.Animals.Add(animal);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }
    return BadRequest(ModelState);
}

[HttpPut("{id}")]
public async Task<IActionResult> Put(int id, Animal animal)
{
  if (id != animal.AnimalId)
  {
    return BadRequest();
  }

  _db.Animals.Update(animal);

  try
  {
    await _db.SaveChangesAsync();
  }
  catch (DbUpdateConcurrencyException)
  {
    if (!AnimalExists(id))
    {
      return NotFound();
    }
    else
    {
      throw;
    }
  }
  return NoContent();
}

private bool AnimalExists(int id)
{
  return _db.Animals.Any(location => location.AnimalId == id);
}

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteAnimal(int id)
{
  Animal animal = await _db.Animals.FindAsync(id);
  if (animal == null)
  {
    return NotFound();
  }

  _db.Animals.Remove(animal);
  await _db.SaveChangesAsync();

  return NoContent();
}
  }
}