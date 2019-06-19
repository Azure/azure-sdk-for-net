using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    public class Secret : SecretBase
    {
        internal Secret()
        {
        }

        public Secret(string name, string value)
            : base(name)
        {
            Value = value;
        }

        public string Value { get; private set; }

        internal override void ReadProperties(JsonElement json)
        {
            if (json.TryGetProperty("value", out JsonElement value))
            {
                Value = value.GetString();
            }

            base.ReadProperties(json);
        }

        internal override void WriteProperties(ref Utf8JsonWriter json)
        {
            if (Value != null)
            {
                json.WriteString("value", Value);
            }

            base.WriteProperties(ref json);
        }
    }

}
