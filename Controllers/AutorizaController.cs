using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUniversidade.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiUniversidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorizaController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AutorizaController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
            public ActionResult<string> Get(){
                return "AutorizaController :: Acessado em: " + DateTime.Now.ToLongDateString();
            }

        [HttpPost("Register")]
            public async Task<ActionResult> RegisterUser([FromBody]UsuarioDTO model){
                var user = new IdentityUser{
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if(!result.Succeeded)
                    return BadRequest(result.Errors);

                await _signInManager.SignInAsync(user, false);
                //return Ok(GerarToken(model));
                return Ok();
            }
    }
}