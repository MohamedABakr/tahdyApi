using Microsoft.AspNetCore.Mvc;
using System;
using test_Api.Entities;
using test_Api.Models;

namespace test_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        testContext db;

        public ValuesController(testContext _db)
        {
            db = _db;
        }
        //List<items> items = new List<items>();
        //public ValuesController()
        //{
        //    items.Add(new items
        //    {
        //        Id = 1,
        //        Name = "Test1",
        //        IsComplete = true
        //    });
        //    items.Add(new items
        //    {
        //        Id = 2,
        //        Name = "Test2",
        //        IsComplete = true
        //    });
        //}
        //[HttpGet]
        //public List<items> Get()
        //{
        //    return items;
        //}
        //[HttpGet("{id}")]
        //public ActionResult<items> getById(int id)
        //{
        //    var itemId = items.FirstOrDefault(i => i.Id == id);

        //    if (itemId == null)
        //    {
        //        return NotFound();
        //    }
        //    return itemId;

        //}

        //[HttpPost]
        //public IActionResult Post(items item)
        //{
        //    //if(ModelState.IsValid)
        //    //{
        //    //    items.Add(item);
        //    //    return CreatedAtAction("getById", new { id = item.Id }, items);
        //    //}
        //    //return BadRequest();
        //    db.items.Add(item);
        //    db.SaveChanges();
        //    return Ok(item);

        //}

        //[HttpPut("{id}")]
        //public ActionResult Put(int id , items item)
        //{
        //    var itemId = items.Find(i => i.Id == id);
        //    if (itemId == null)
        //    {
        //        return NotFound();
        //    }

        //    foreach(var i  in items)
        //    {
        //        if(i.Id == id)
        //        {
        //            i.Name = itemId.Name;
        //        }
        //    }
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    var itemId = items.Find(i => i.Id == id);
        //    if(itemId == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        items.Remove(itemId);
        //    }
        //    return NoContent();
        //}

        [HttpGet]
        public IActionResult Get()
        {
            List<items> i = db.items.ToList();
            return Ok(i);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = db.items.Find(id);
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] items item)
        {
            db.items.Add(item);
            db.SaveChanges();
            return Ok(item);
        }

        [HttpGet("random")]
        public IActionResult GetRandomItem()
        {
            // تحصل على عدد إجمالي للعناصر في الجدول
            int totalItems = db.items.Count();

            // تحصل على رقم عشوائي بين 1 وعدد العناصر
            Random random = new Random();
            int randomId = random.Next(1, totalItems + 1);

            // استرجاع العنصر العشوائي
            var randomItem = db.items.OrderBy(x => x.Id).Skip(randomId - 1).FirstOrDefault();

            return Ok(randomItem);
        }

    }
}
