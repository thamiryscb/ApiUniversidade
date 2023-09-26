using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiUniversidade.Model;
using Microsoft.AspNetCore.Mvc;

[HttpGet]
public ActionResult<Enumerable<Curso> Get()
{
    var cursos = context.Cursos.ToList();
    if(cursos is null)
        return NotFound();

    return cursos;
}