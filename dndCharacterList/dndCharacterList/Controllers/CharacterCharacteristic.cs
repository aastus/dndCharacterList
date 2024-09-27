﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dndCharacterList.Data;
using dndCharacterList.Models;


namespace dndCharacterList.Controllers
{
    public class CharacterCharacteristic : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacterCharacteristic(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Skills
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, string filterModifier)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ModifierSortParm"] = sortOrder == "Modifier" ? "modifier_desc" : "Modifier";

            if (searchString != null)
            {
                // Якщо користувач вводить новий пошуковий запит, скидаємо сторінку
                ViewData["CurrentFilter"] = searchString;
            }
            else
            {
                searchString = currentFilter;
            }

            var skills = from s in _context.Skill
                         select s;

            // Фільтрація за пошуковим запитом
            if (!String.IsNullOrEmpty(searchString))
            {
                skills = skills.Where(s => s.Name.Contains(searchString));
            }

            // Фільтрація за модифікатором
            if (!String.IsNullOrEmpty(filterModifier))
            {
                if (int.TryParse(filterModifier, out int modifierValue))
                {
                    skills = skills.Where(s => s.Modifier == modifierValue);
                }
            }

            // Сортування
            switch (sortOrder)
            {
                case "name_desc":
                    skills = skills.OrderByDescending(s => s.Name);
                    break;
                case "Modifier":
                    skills = skills.OrderBy(s => s.Modifier);
                    break;
                case "modifier_desc":
                    skills = skills.OrderByDescending(s => s.Modifier);
                    break;
                default:
                    skills = skills.OrderBy(s => s.Name);
                    break;
            }

            return View(await skills.AsNoTracking().ToListAsync());
        }


        // GET: Skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Skill == null)
            {
                return NotFound();
            }

            var skill = await _context.Skill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Modifier")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Skill == null)
            {
                return NotFound();
            }

            var skill = await _context.Skill.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Modifier")] Skill skill)
        {
            if (id != skill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.Id))
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
            return View(skill);
        }

        // GET: Skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Skill == null)
            {
                return NotFound();
            }

            var skill = await _context.Skill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Skill == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Skill'  is null.");
            }
            var skill = await _context.Skill.FindAsync(id);
            if (skill != null)
            {
                _context.Skill.Remove(skill);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
          return (_context.Skill?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
