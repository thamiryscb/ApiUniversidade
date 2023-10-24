using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiUniversidade.Context;
using apiUniversidade.Model;
using Microsoft.AspNetCore.Mvc;

namespace apiUniversidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ILogger<CursoController> _logger;
        private readonly ApiUniversidadeContext _context;
        public CursoController(ILogger<CursoController> logger, ApiUniversidadeContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Curso>> Get()
        {
            var cursos = _context.Cursos.ToList();
            if(cursos.Count == 0)
                return NotFound();

            return cursos;
        }

        [HttpGet("{id:int}", Name="GetCurso")]
        public ActionResult<Curso> Get(int id)
        {
            var curso = _context.Cursos.FirstOrDefault(p => p.Id == id);
            if(curso is null)
                return NotFound("Curso não encontrado.");
            
            return curso;
        }

        [HttpPost]
        public ActionResult Post(Curso curso){
            _context.Cursos.Add(curso);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCurso",
                new{ id = curso.Id},
                curso); 
        }
    }
}