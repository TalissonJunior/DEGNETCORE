using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DEGNETCORE.core;
using DEGNETCORE.core.models;
using Newtonsoft.Json;

namespace DEGNETCORE.core
{
    public class DEG
    {
        private Database Database { get; set; }

        public DEG(string connectionString) {
            this.Database = new Database(connectionString);

            this.CheckSettings();
        }
        
        private string BaseFolderPath() {
            return Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot", 
                "libraries"
            ); 
        }

        private string BaseFilePath() {
            return Path.Combine(
                this.BaseFolderPath(), 
                "deg.json"
            ); 
        }
        
        private void CheckSettings() {
            // Declarations
            var folderPath = this.BaseFolderPath();
            var filePath = this.BaseFilePath();

            // If isn´t created
            if(!Directory.Exists(folderPath)) {
                Directory.CreateDirectory(folderPath);
            }

            if(!File.Exists(filePath)) {
               var stream = File.Create(filePath);
               stream.Close();

               Console.WriteLine($"CREATED: {filePath}");
               this.Rebuild();
            }
            // Check if it is empty
            else {
               var content = File.ReadAllText(filePath);

               if(
                String.IsNullOrEmpty(content) || 
                (content != null && String.IsNullOrEmpty(content.Trim()))
                ) {
                  this.Rebuild();
               }
            }
        }

        public string GetJSONData() {
            return File.ReadAllText(this.BaseFilePath());
        }

        public void Rebuild() {
            var structure = this.Database.GetStructure();

            var data = new List<JSONAttribute>();

            // Format
            data = structure.Select(s => {
                var model = new JSONAttribute(s.Name, s.Name);

                foreach (string property in s.Properties)
                {   
                    var prop = new JSONAttributeProperty(property, property);

                    model.AddProperties(prop);
                }
              
              return model;
            }).ToList();
            
            // Transform to Javascript JSON
            var json = JsonConvert.SerializeObject(new { data = data });

            File.AppendAllText(this.BaseFilePath(), json);

            Console.WriteLine($"DEG LOG: UPDATED => {this.BaseFilePath()}");
        }       
    }
}
