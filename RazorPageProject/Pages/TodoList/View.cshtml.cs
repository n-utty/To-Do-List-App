using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageProject.Model;

namespace RazorPageProject.Pages.TodoList
{
    public class ViewModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ViewModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public ToDo ToDo { get; set; }
        public async Task OnGet(int id)
        {
            ToDo = await _db.ToDo.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var TodoDb = await _db.ToDo.FindAsync(ToDo.Id);
                TodoDb.Task = ToDo.Task;
                TodoDb.Status = ToDo.Status;
                TodoDb.Priority = ToDo.Priority;
                TodoDb.date = ToDo.date;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}
