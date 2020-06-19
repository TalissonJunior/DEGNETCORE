using DEGNETCORE.core.utilities;

namespace DEGNETCORE.core.models
{
    public class JSONAttributeProperty
    {
        public string Identifier { get; private set; }
        public string Name { get; private set; }

        public JSONAttributeProperty(
            string identifier,
            string name
        ) {
            this.Identifier = identifier;
            this.Name = name.ToPascalCase();
        }
    }
}