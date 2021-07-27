using System;

namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina(int alunoId, int disciplinaId, Aluno aluno, Disciplina disciplina)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;

        }
        public AlunoDisciplina(){}
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public Aluno Aluno { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; }
        public int? Nota { get; set; } = null;
        public Disciplina Disciplina { get; set; }
    }
}