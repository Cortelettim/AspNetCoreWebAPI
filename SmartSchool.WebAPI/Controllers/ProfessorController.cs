using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {


        private readonly DataContext _context;
        public ProfessorController(DataContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var Professores = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (Professores == null) return BadRequest("O Professores nao foi encontrado");
            return Ok(Professores);
        }
        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var Professores = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
            if (Professores == null) return BadRequest("O Professores nao foi encontrado");
            return Ok(Professores);
        }
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var response = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (response == null) return BadRequest("Professores Inexistente");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var response = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (response == null) return BadRequest("Professores Inexistente");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (response == null) return BadRequest("Professores Inexistente");
            _context.Remove(response);
            _context.SaveChanges();
            return Ok();
        }
    }
}