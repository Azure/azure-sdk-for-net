// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
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
            if (value == null) throw new ArgumentNullException(nameof(value));

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
