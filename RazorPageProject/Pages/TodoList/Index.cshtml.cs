using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageProject.Model;

namespace RazorPageProject.Pages.TodoList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<ToDo> ToDos { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public ToDo ToDo { get; set; }
        public async Task  OnGet()
        {
            ToDos = await _db.ToDo.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var todo = await _db.ToDo.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
   
             
             _db.Remove(todo);
             await _db.SaveChangesAsync();
             return RedirectToPage();


        }

        public async Task<IActionResult> OnPostComplete(int id)
        {
            var todo = await _db.ToDo.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.Task = todo.Task;
            todo.Status = 100;
            todo.Priority = todo.Priority;
            todo.date = todo.date;
            await _db.SaveChangesAsync();
            return RedirectToPage();
            

        }
    }
}
