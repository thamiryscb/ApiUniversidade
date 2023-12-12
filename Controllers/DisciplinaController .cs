using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using apiUniversidade.Context;
using apiUniversidade.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace apiUniversidade.Controllers
{
    [Authorize(AuthenticationSchemes ="Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class DisciplinaController  : ControllerBase
    {
        private readonly ILogger<DisciplinaController> _logger;
        private readonly ApiUniversidadeContext _context;
        public DisciplinaController(ILogger<DisciplinaController> logger, ApiUniversidadeContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Disciplina>> Get()
        {
            var disciplinas = _context.Disciplinas.ToList();
            if(disciplinas.Count == 0)
                return NotFound();

            return disciplinas;
        }

        [HttpPost]
        public ActionResult Post(Disciplina disciplina){
            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetDisciplina",
                new{id = disciplina.Id},
                disciplina);
        }

        [HttpGet("{id:int}", Name="GetDisciplina")]
        public ActionResult<Disciplina> Get(int id)
        {
            var disciplina = _context.Disciplinas.FirstOrDefault(p => p.Id == id);
            if(disciplina is null)
                return NotFound("Disciplina não encontrado.");

            return disciplina;
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Disciplina disciplina){
            if(id != disciplina.Id)
                return BadRequest();
            
            _context.Entry(disciplina).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(disciplina);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var disciplina = _context.Disciplinas.FirstOrDefault(p => p.Id == id);

            if(disciplina is null)
                return NotFound();
            
            _context.Disciplinas.Remove(disciplina);
            _context.SaveChanges();

            return Ok(disciplina);
        }
    }
}
