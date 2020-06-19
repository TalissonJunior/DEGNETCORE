using DEGNETCORE.core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DEGNETCORE
{   
    [Route("deg")]
    public class DEGService : Controller
    {   
        private DEG deg { get; set;}
        private IConfiguration Configuration { get; }

        public DEGService(IConfiguration configuration) {
            this.Configuration = configuration;

            var connectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            
            this.deg = new DEG(connectionString);
        }

        [HttpGet]
        public string Get() {
            return this.deg.GetJSONData();
        }
    }
}