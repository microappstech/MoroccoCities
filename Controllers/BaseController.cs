using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MoroccoCities.Models;

namespace MoroccoCities.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected AppDbContext Context { get; set; }
        public BaseController(AppDbContext appDb)
        {
            this.Context = appDb;
        }
    }
}
