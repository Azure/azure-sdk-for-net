using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    internal class VaultBackup : Model
    {
        public byte[] Value { get; set; }

        internal override void ReadProperties(JsonElement json)
        {
            if (json.TryGetProperty("value", out JsonElement value))
            {
                Value = Base64Url.Decode(value.GetString());
            }
        }

        internal override void WriteProperties(ref Utf8JsonWriter json)
        {
            json.WriteString("value", Base64Url.Encode(Value));
        }

        protected override byte[] CreateSerializationBuffer()
        {
            return Value != null ? new byte[Value.Length * 2] : base.CreateSerializationBuffer();
        }
    }
}
