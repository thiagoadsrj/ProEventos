using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        public readonly DataContext _context;
        public EventosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
        }

        [HttpPost]
        public ActionResult<Evento> Post(Evento evento)
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();
            return evento;

        }

        [HttpPut]
        public ActionResult<Evento> Put(int id, Evento evento)
        {
            var eventoBanco = _context.Eventos.FirstOrDefault(evento => evento.Id == id);
            if (eventoBanco == null) return NotFound();
            eventoBanco.Local = evento.Local;
            eventoBanco.Tema = evento.Tema;
            eventoBanco.QtdPessoas = evento.QtdPessoas;
            eventoBanco.ImagemURL = evento.ImagemURL;
            eventoBanco.Telefone = evento.Telefone;
            eventoBanco.Email = evento.Email;
            _context.Eventos.Update(eventoBanco);
            _context.SaveChanges();
            return eventoBanco;
        }

        [HttpDelete]
        public ActionResult<Evento> Delete(int id)
        {
            var eventoBanco = _context.Eventos.FirstOrDefault(evento => evento.Id == id);
            if (eventoBanco == null) return NotFound();
            _context.Eventos.Remove(eventoBanco);
            _context.SaveChanges();
            return eventoBanco;


        }
    }
}
