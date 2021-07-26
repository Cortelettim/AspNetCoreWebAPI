using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;
        public AlunoController(DataContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno nao foi encontrado");
            return Ok(aluno);
        }
        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome));
            if (aluno == null) return BadRequest("O Aluno nao foi encontrado");
            return Ok(aluno);
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var response = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (response == null) return BadRequest("Aluno Inexistente");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var response = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (response == null) return BadRequest("Aluno Inexistente");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno Inexistente");
            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}
