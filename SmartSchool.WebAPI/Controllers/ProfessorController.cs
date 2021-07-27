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



        private readonly IRepository _repo;

        public ProfessorController(DataContext context, IRepository repo)
        {

            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var response = _repo.GetAllProfessores(true);
            if(Response == null) return BadRequest("Nao ha professores cadastrados");
            return Ok(Response);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var Professores = _repo.GetProfessorById(id, false);
            if (Professores == null) return BadRequest("O Professores nao foi encontrado");
            return Ok(Professores);
        }
        
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
           _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor nao cadastrado");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
             var response = _repo.GetProfessorById(id, false);
            if (response == null) return BadRequest("Professor Inexistente");
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor nao atualizado");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var response = _repo.GetProfessorById(id, false);
            if (response == null) return BadRequest("Professor Inexistente");
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor nao atualizado");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor Inexistente");
            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor Deletado");
            }
            return BadRequest("Professor nao deletado");
        }
    }
}