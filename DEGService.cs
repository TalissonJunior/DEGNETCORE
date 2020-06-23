using System;
using System.Collections.Generic;
using DEGNETCORE.core;
using DEGNETCORE.core.models;
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

        [HttpPost]
        public bool GetData([FromBody] List<JSONAttribute> models) {
            Console.WriteLine("oi" + models);  
            return true;
        }
    }
}