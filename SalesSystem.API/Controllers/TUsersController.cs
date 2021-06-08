using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesSystem.API.DataContext;
using SalesSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TUsersController : Controller
    {

        private readonly DbContextOptions<SalesSystemDataContext> options;

        public TUsersController(DbContextOptions<SalesSystemDataContext> options)
        {
            this.options = options;
        }

        [HttpGet]
        public async Task<IEnumerable<TUsers>> Get()
        {
            try
            {
                using (var context = new SalesSystemDataContext(this.options))
                {
                    var resp = await context.TUsers.ToListAsync();
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public async Task<TUsers> GetLogin(string Email, string Password)
        {
            try
            {
                using (var context = new SalesSystemDataContext(this.options))
                {
                    var resp = await context.TUsers.FirstOrDefaultAsync(x => x.Email.Equals(Email) && x.Password.Equals(Password));
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
