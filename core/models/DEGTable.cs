using System;
using System.Collections.Generic;

namespace DEGNETCORE.core.models
{
    public class DEGTable
    {
        public string Name { get; private set; }
        private List<string> properties;
        public IReadOnlyCollection<string> Properties
        {
            get
            {
                return properties;
            }
        }

        public DEGTable(
            string name
        ) {
            this.Name = name;

            this.properties = new List<string>();
        }

        public void ChangeName(string name) {
            
            if(String.IsNullOrEmpty(name)) {
                return;
            }

            this.Name = name;
        }

        public void AddProperty(string property) {

            if(String.IsNullOrEmpty(property)) {
                return;
            }

            if(properties == null) {
                this.properties = new List<string>();
            }

            var exists = this.properties.Exists(p => p == property);

            if(!exists) {
                this.properties.Add(property);
            }
        }
    }
}