using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using ExpenseTracker.Data;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class expenseController : ControllerBase
    {
        private readonly ApiContext _context;

        public expenseController(ApiContext context)
        {
            _context = context;
        }

        // Post
        [HttpPost]
        public JsonResult CreateEdit(Models.ExpenseTracker expense)
        {
            if(expense.Id == 0)
            {
                _context.Expenses.Add(expense);
            } else
            {
                var expenseInDB = _context.Expenses.Find(expense.Id);
                
                if(expenseInDB == null)
                {
                    return new JsonResult(NotFound());
                } else
                {
                    expenseInDB = expense;
                }
            }

            _context.SaveChanges();

            return new JsonResult(Ok(expense));
        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Expenses.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            } else
            {
                return new JsonResult(Ok(result));
            }
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Expenses.Find(id);

            if(result == null)
            {
                return new JsonResult(NotFound());
            } else
            {
                _context.Expenses.Remove(result);
                _context.SaveChanges();

                return new JsonResult(NoContent());
            }
        }

        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.Expenses.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
