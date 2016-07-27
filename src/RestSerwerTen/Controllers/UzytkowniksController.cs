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
        private readonly RestSerwerTenContext _context;

        public UzytkowniksController(RestSerwerTenContext context)
        {
            _context = context;    
        }

        // GET: Uzytkowniks
        public  IEnumerable<Uzytkownik> Index()
        {
          /*  List<Uzytkownik> usuwanie = _context.Uzytkownik.ToList();
            foreach(Uzytkownik item in usuwanie)
            {
                _context.Remove(item);
            }
            _context.SaveChanges();
        */
            return  _context.Uzytkownik.ToList();
        }

        // GET: Uzytkowniks/Details/5
        public  Uzytkownik Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            Uzytkownik uzytkownik =  _context.Uzytkownik.SingleOrDefault(m => m.Id == id);
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
        public async Task<IActionResult> Create([FromBody] Uzytkownik uzytkownik)
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
        [HttpPut]
        public async Task<IActionResult> Update(int? id, [FromBody] Uzytkownik uzytkownik)
        {
            System.Diagnostics.Debug.WriteLine("update");
            System.Diagnostics.Debug.WriteLine("ID:" + id);
            System.Diagnostics.Debug.WriteLine("Uzytkownik imie: " + uzytkownik.imie);
            System.Diagnostics.Debug.WriteLine("Uzytkownik nazwisko:" + uzytkownik.nazwisko);
            System.Diagnostics.Debug.WriteLine("Login:" + uzytkownik.login);
            System.Diagnostics.Debug.WriteLine("Haslo :" + uzytkownik.haslo);

            if (id == null)
            {
                return NotFound();
            }

            var uzytko = _context.Uzytkownik.SingleOrDefault(k => k.Id == id);
            uzytko.imie = uzytkownik.imie;
            uzytko.nazwisko = uzytkownik.nazwisko;
            uzytko.login = uzytkownik.login;
            uzytko.haslo = uzytkownik.haslo;
            System.Diagnostics.Debug.WriteLine("Znaleziony uzytkownik");
            System.Diagnostics.Debug.WriteLine("Uzytkownik imie: " + uzytko.imie);
            System.Diagnostics.Debug.WriteLine("Uzytkownik nazwisko:" + uzytko.nazwisko);
            System.Diagnostics.Debug.WriteLine("login :" + uzytko.login);
            System.Diagnostics.Debug.WriteLine("haslo :" + uzytko.haslo);
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

            var uzytkownik = await _context.Uzytkownik.SingleOrDefaultAsync(m => m.Id == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }
            _context.Remove(uzytkownik);
            _context.SaveChanges();
            return Ok();
        }

        public Uzytkownik logo(string login, string haslo)
        {
           Uzytkownik uzy= _context.Uzytkownik.SingleOrDefault(k => k.login == login && k.haslo == haslo);
            return uzy;
        }

        

        private bool UzytkownikExists(int id)
        {
            return _context.Uzytkownik.Any(e => e.Id == id);
        }
    }
}
