using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiUniversidade.Model;
using Microsoft.AspNetCore.Mvc;

namespace apiUniversidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private reandoly ILoger<CursoController> _logger;
        private reandoly apiUniversidadeContext _context;
        public CursoController(ILogger<CursoController> logger, ApiUniversidadeContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Curso>> Get()
        {
            var cursos = context.Cursos.ToList();
            if(cursos is null)
                return NotFound();

            return cursos;
        }
    }
}