using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestSerwerTen.Models;

namespace RestSerwerTen.Controllers
{
    public class UzytkowniksController : Controller
    {
        private readonly PostgreSqlContext _context;

        public UzytkowniksController(PostgreSqlContext context)
        {
            _context = context;    
        }

        // GET: Uzytkowniks
        public  IEnumerable<uzytkownik> Index()
        {
            return  _context.uzytkowniko.ToList();
        }

        // GET: Uzytkowniks/Details/5
        public  uzytkownik Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            uzytkownik uzytkownik =  _context.uzytkowniko.SingleOrDefault(m => m.Id == id);
            if (uzytkownik == null)
            {
                return null;
            }

            return uzytkownik;
        }

        // GET: Uzytkowniks/Create
       

        // POST: Uzytkowniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] uzytkownik uzytkownik)
        {
            System.Diagnostics.Debug.WriteLine("POST");
            System.Diagnostics.Debug.WriteLine("Uzytkownik imie: "+uzytkownik.imie);
            System.Diagnostics.Debug.WriteLine("Uzytkownik nazwisko:"+ uzytkownik.nazwisko);
            if (ModelState.IsValid)
            {
                _context.Add(uzytkownik);
                await _context.SaveChangesAsync();
                return Created("http://localhost:63188/Uzytkowniks",uzytkownik) ;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Nie poszlo");
            }
            return BadRequest() ;
        }

        // GET: Uzytkowniks/Edit/5
        public async Task<IActionResult> Update(int? id, [FromBody] uzytkownik uzytkownik)
        {
            System.Diagnostics.Debug.WriteLine("update");
            System.Diagnostics.Debug.WriteLine("Uzytkownik imie: " + uzytkownik.imie);
            System.Diagnostics.Debug.WriteLine("Uzytkownik nazwisko:" + uzytkownik.nazwisko);
            System.Diagnostics.Debug.WriteLine("ID:" + id);
       
            if (id == null)
            {
                return NotFound();
            }

            var uzytko = _context.uzytkowniko.SingleOrDefault(k => k.Id == id);
            uzytko.imie = uzytkownik.imie;
            uzytko.nazwisko = uzytkownik.nazwisko;
            System.Diagnostics.Debug.WriteLine("Znaleziony uzytkownik");
            System.Diagnostics.Debug.WriteLine("Uzytkownik imie: " + uzytko.imie);
            System.Diagnostics.Debug.WriteLine("Uzytkownik nazwisko:" + uzytko.nazwisko);
            
            if (uzytkownik == null || uzytko==null)
            {
                return NotFound();
            }
            //  Uzytkownik uz1 = new Uzytkownik { Id=uzytkownik.Id, imie=uzytkownik.imie, nazwisko=uzytkownik  };
            // _context.Remove(uzytko);
            //  _context.Add(uzytkownik);
            _context.Update(uzytko);
           
            _context.SaveChanges();
            return new NoContentResult() ;
        }

        // POST: Uzytkowniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
     

        // GET: Uzytkowniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.uzytkowniko.SingleOrDefaultAsync(m => m.Id == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }
            _context.Remove(uzytkownik);
            _context.SaveChanges();
            return Ok();
        }

        public uzytkownik logo(string mail,string haslo)
        {
            uzytkownik uz = _context.uzytkowniko.Single(k => k.mail == mail && k.haslo == haslo);
            if (uz == null)
            {
                return null;
            }else
            {
                return uz;
            }
        }

        private bool UzytkownikExists(int id)
        {
            return _context.uzytkowniko.Any(e => e.Id == id);
        }
    }
}
