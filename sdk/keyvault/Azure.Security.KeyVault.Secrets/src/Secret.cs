// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// Secret is the resource consisting of name, value and its attributes inherited from <see cref="SecretBase"/>.
    /// </summary>
    public class Secret : SecretBase
    {
        internal Secret()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Secret class.
        /// </summary>
        /// <param name="name">The name of the secret.</param>
        /// <param name="value">The value of the secret.</param>
        public Secret(string name, string value)
            : base(name)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        /// <summary>
        /// The value of the secret.
        /// </summary>
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
