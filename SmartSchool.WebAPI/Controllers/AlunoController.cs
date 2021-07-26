using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> alunos = new List<Aluno>(){
            new Aluno() {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "almeida",
                Telefone = "12346567"
            },
             new Aluno() {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "15435127"
            },
             new Aluno() {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Maria",
                Telefone = "65872234"
            }
        };
        public AlunoController()
        {

        }

        public List<Aluno> Alunos { get => alunos; set => alunos = value; }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno nao foi encontrado");
            return Ok(aluno);
        }
        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome));
            if (aluno == null) return BadRequest("O Aluno nao foi encontrado");
            return Ok(aluno);
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok();
        }
    }
}
