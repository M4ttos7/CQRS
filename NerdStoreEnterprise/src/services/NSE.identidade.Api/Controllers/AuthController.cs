using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identidade.API.Models;

namespace NSE.Identidade.API.Controllers
{
    [Route("api/identidade")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost] ("nova-conta")]
        public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                UserName = usuarioResgistro.Email,
                Email = usuarioRegistgro.Email,
                EmailConfirmed = true
            };

            var results = await _userManager.CreateAsync(User, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                await _SignInmanager. SignInAsync(user, isPeesistent:false)
                return Ok();  
            }

            return BadRequest();    
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSigInAsync(usuaruioLogin.Email, UsuarioLogin.Senha,
                false, true);  
            
        if (result.Sucessed) 
            {
                return Ok();
            }

            return BadRequest();        


        }
    }
}