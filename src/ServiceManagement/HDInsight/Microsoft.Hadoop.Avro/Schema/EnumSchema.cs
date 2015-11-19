// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    ///     Schema representing an enumeration.
    ///     For more details please see <a href="http://avro.apache.org/docs/current/spec.html#Enums"> the specification</a>.
    /// </summary>
    public sealed class EnumSchema : NamedSchema
    {
        private readonly List<string> symbols;
        private readonly List<long> avroToCSharpValueMapping;
        private readonly Dictionary<string, int> symbolToValue;
        private readonly Dictionary<int, string> valueToSymbol;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSchema"/> class.
        /// </summary>
        /// <param name="namedEntityAttributes">The named entity attributes.</param>
        /// <param name="runtimeType">Type of the runtime.</param>
        internal EnumSchema(NamedEntityAttributes namedEntityAttributes, Type runtimeType)
            : this(namedEntityAttributes, runtimeType, new Dictionary<string, string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSchema" /> class.
        /// </summary>
        /// <param name="namedEntityAttributes">The named schema attributes.</param>
        /// <param name="runtimeType">Type of the runtime.</param>
        /// <param name="attributes">The attributes.</param>
        internal EnumSchema(
            NamedEntityAttributes namedEntityAttributes,
            Type runtimeType,
            Dictionary<string, string> attributes)
            : base(namedEntityAttributes, runtimeType, attributes)
        {
            if (runtimeType == null)
            {
                throw new ArgumentNullException("runtimeType");
            }

            this.symbols = new List<string>();
            this.symbolToValue = new Dictionary<string, int>();
            this.valueToSymbol = new Dictionary<int, string>();
            this.avroToCSharpValueMapping = new List<long>();

            if (runtimeType.IsEnum)
            {
                this.symbols = Enum.GetNames(runtimeType).ToList();
                Array values = Enum.GetValues(runtimeType);
                for (int i = 0; i < this.symbols.Count; i++)
                {
                    int v = Convert.ToInt32(values.GetValue(i), CultureInfo.InvariantCulture);
                    this.avroToCSharpValueMapping.Add(Convert.ToInt64(values.GetValue(i), CultureInfo.InvariantCulture));
                    this.symbolToValue.Add(this.symbols[i], v);
                    this.valueToSymbol.Add(v, this.symbols[i]);
                }
            }
        }

        /// <summary>
        ///     Gets the symbols.
        /// </summary>
        public ReadOnlyCollection<string> Symbols
        {
            get { return new ReadOnlyCollection<string>(this.symbols); }
        }

        /// <summary>
        /// Gets the value by symbol.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>Value corresponding to the symbol.</returns>
        public int GetValueBySymbol(string symbol)
        {
            return this.symbolToValue[symbol];
        }

        /// <summary>
        /// Gets the symbol by integer value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Symbol that corresponds to the specified integer value.</returns>
        public string GetSymbolByValue(int value)
        {
            return this.valueToSymbol[value];
        }

        /// <summary>
        ///     Gets the avro to C sharp value mapping.
        /// </summary>
        /// <value>
        ///     The avro to C sharp value mapping.
        /// </value>
        internal long[] AvroToCSharpValueMapping
        {
            get { return this.avroToCSharpValueMapping.ToArray(); }
        }

        /// <summary>
        ///     Converts current not to JSON according to the avro specification.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="seenSchemas">The seen schemas.</param>
        internal override void ToJsonSafe(JsonTextWriter writer, HashSet<NamedSchema> seenSchemas)
        {
            if (seenSchemas.Contains(this))
            {
                writer.WriteValue(this.FullName);
                return;
            }

            seenSchemas.Add(this);
            writer.WriteStartObject();
            writer.WriteProperty("type", "enum");
            writer.WriteProperty("name", this.FullName);
            writer.WriteOptionalProperty("doc", this.Doc);
            writer.WritePropertyName("symbols");
            writer.WriteStartArray();
            this.symbols.ForEach(writer.WriteValue);
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal void AddSymbol(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Symbol should not be null."));
            }

            this.symbols.Add(symbol);
            this.symbolToValue.Add(symbol, this.symbolToValue.Count);
            this.valueToSymbol.Add(this.valueToSymbol.Count, symbol);

            if (this.avroToCSharpValueMapping.Any())
            {
                this.avroToCSharpValueMapping.Add(this.avroToCSharpValueMapping.Last() + 1);
            }
            else
            {
                this.avroToCSharpValueMapping.Add(0);
            }
        }
    }
}
