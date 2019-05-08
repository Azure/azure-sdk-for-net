using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

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
