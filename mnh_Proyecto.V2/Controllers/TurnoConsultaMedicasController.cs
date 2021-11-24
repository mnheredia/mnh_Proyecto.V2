using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mnh_Proyecto.V2.Context;
using mnh_Proyecto.V2.Models;

namespace mnh_Proyecto.V2.Controllers
{
    public class TurnoConsultaMedicasController : Controller
    {
        private readonly ClinicaDatabaseV2Context _context;

        public TurnoConsultaMedicasController(ClinicaDatabaseV2Context context)
        {
            _context = context;
        }

        // GET: TurnoConsultaMedicas
        public async Task<IActionResult> Index(string searching)
        {
            return View(await _context.TurnoConsultaMedica.Where(x => x.DocumentoPaciente.ToString().Contains(searching) || searching == null).ToListAsync());
            //return View(await _context.TurnoConsultaMedica.ToListAsync());
        }

        // GET: TurnoConsultaMedicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoConsultaMedica = await _context.TurnoConsultaMedica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turnoConsultaMedica == null)
            {
                return NotFound();
            }

            return View(turnoConsultaMedica);
        }

        // GET: TurnoConsultaMedicas/Create
        public IActionResult Create()
        {
            List<SelectListItem> MedicosItems = new List<SelectListItem>();
            foreach (Medico m in _context.Medicos)
            {
                MedicosItems.Add(new SelectListItem()
                {
                    Text = m.Nombre.ToString() +" "+m.Apellido.ToString()+ " -    Especialidad: " + m.Especialidad.ToString(),

                    Value = m.Id.ToString(),
                    Selected = false
                });
            }
            ViewBag.MedicosItems = MedicosItems;

            return View();
        }

        // POST: TurnoConsultaMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedico,FechaConsultaMedica,DocumentoPaciente,Id,IdPaciente,DiasDisponibles,HorasDisponibles")] TurnoConsultaMedica turnoConsultaMedica)
        {

            if (ModelState.IsValid)
            {
                
                DateTime date = DateTime.Today;

                switch (turnoConsultaMedica.DiasDisponibles)
                {
                    case DiasDisponibles.Lunes:
                        turnoConsultaMedica.FechaConsultaMedica = date.AddDays(7).ToString("dd/MM/yyyy") + " " + (int)turnoConsultaMedica.HorasDisponibles + ":00";
                        break;
                    case DiasDisponibles.Martes:
                        turnoConsultaMedica.FechaConsultaMedica = date.AddDays(8).ToString("dd/MM/yyyy") + " " + (int)turnoConsultaMedica.HorasDisponibles + ":00";
                        break;
                    case DiasDisponibles.Miercoles:
                        turnoConsultaMedica.FechaConsultaMedica = date.AddDays(9).ToString("dd/MM/yyyy") + " " + (int)turnoConsultaMedica.HorasDisponibles + ":00";
                        break;
                    case DiasDisponibles.Jueves:
                        turnoConsultaMedica.FechaConsultaMedica = date.AddDays(10).ToString("dd/MM/yyyy") + " " + (int)turnoConsultaMedica.HorasDisponibles + ":00";
                        break;
                    case DiasDisponibles.Viernes:
                        turnoConsultaMedica.FechaConsultaMedica = date.AddDays(11).ToString("dd/MM/yyyy") + " " + (int)turnoConsultaMedica.HorasDisponibles + ":00";
                        break;
                }
                foreach (TurnoConsultaMedica tcm in _context.TurnoConsultaMedica.Where(s => s.FechaConsultaMedica.Equals(turnoConsultaMedica.FechaConsultaMedica)))
                {

                    if (tcm.IdMedico == turnoConsultaMedica.IdMedico)
                    {
                        return Content("EL MEDICO  YA TIENE UN TURNO ASIGNADO EN ESA FECHA Y HORA");
                    }
                    else if (tcm.DocumentoPaciente == turnoConsultaMedica.DocumentoPaciente)
                    {
                        return Content("EL PACIENTE YA TIENE UN TURNO ASIGNADO EN ESA FECHA Y HORA");
                    }
                }
                foreach(Paciente p in _context.Pacientes.Where(s=> s.Documento == turnoConsultaMedica.DocumentoPaciente)){
                    turnoConsultaMedica.IdPaciente = p.Id;
                }


               

                _context.Add(turnoConsultaMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<SelectListItem> MedicosItems = new List<SelectListItem>();
            foreach (Medico m in _context.Medicos)
            {
                MedicosItems.Add(new SelectListItem()
                {
                    Text = m.Nombre.ToString() + " " + m.Apellido.ToString() + " -    Especialidad: " + m.Especialidad.ToString(),

                    Value = m.Id.ToString(),
                    Selected = false
                });
            }
            ViewBag.MedicosItems = MedicosItems;
            return View(turnoConsultaMedica);
        }

        // GET: TurnoConsultaMedicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoConsultaMedica = await _context.TurnoConsultaMedica.FindAsync(id);
            if (turnoConsultaMedica == null)
            {
                return NotFound();
            }
            return View(turnoConsultaMedica);
        }

        // POST: TurnoConsultaMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,FechaConsultaMedica,DocumentoPaciente,Id,IdPaciente,DiasDisponibles,HorasDisponibles")] TurnoConsultaMedica turnoConsultaMedica)
        {
            if (id != turnoConsultaMedica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turnoConsultaMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoConsultaMedicaExists(turnoConsultaMedica.Id))
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
            return View(turnoConsultaMedica);
        }

        // GET: TurnoConsultaMedicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoConsultaMedica = await _context.TurnoConsultaMedica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turnoConsultaMedica == null)
            {
                return NotFound();
            }

            return View(turnoConsultaMedica);
        }

        // POST: TurnoConsultaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turnoConsultaMedica = await _context.TurnoConsultaMedica.FindAsync(id);
            _context.TurnoConsultaMedica.Remove(turnoConsultaMedica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoConsultaMedicaExists(int id)
        {
            return _context.TurnoConsultaMedica.Any(e => e.Id == id);
        }
    }
}
