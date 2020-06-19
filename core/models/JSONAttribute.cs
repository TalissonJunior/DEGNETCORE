using System.Collections.Generic;
using DEGNETCORE.core.utilities;

namespace DEGNETCORE.core.models
{
    public class JSONAttribute
    {
        public string Identifier { get; private set; }
        public string Name { get; private set; }

        private List<JSONAttributeProperty> properties;
        public IReadOnlyCollection<JSONAttributeProperty> Properties
        {
            get
            {
                return properties;
            }
        }

        public JSONAttribute(
            string identifier,
            string name
        ) {
            this.Identifier = identifier;
            this.Name = name.ToPascalCase();

            this.properties = new List<JSONAttributeProperty>();
        }

        public void AddProperties(JSONAttributeProperty property) {
            
            if(property == null) {
                return;
            }

            if(this.properties == null) {
                this.properties = new List<JSONAttributeProperty>();
            }

            this.properties.Add(property);
        }
    }
}