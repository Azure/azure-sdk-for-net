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
    using Newtonsoft.Json;

    /// <summary>
    ///     Class represents a record schema.
    ///     For more details please see <a href="http://avro.apache.org/docs/current/spec.html#schema_record">the specification</a>.
    /// </summary>
    public sealed class RecordSchema : NamedSchema
    {
        private readonly List<RecordField> fields;
        private readonly Dictionary<string, RecordField> fiedsByName;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RecordSchema" /> class.
        /// </summary>
        /// <param name="namedAttributes">The named attributes.</param>
        /// <param name="runtimeType">Type of the runtime.</param>
        /// <param name="attributes">The attributes.</param>
        internal RecordSchema(
            NamedEntityAttributes namedAttributes,
            Type runtimeType,
            Dictionary<string, string> attributes)
            : base(namedAttributes, runtimeType, attributes)
        {
            this.fields = new List<RecordField>();
            this.fiedsByName = new Dictionary<string, RecordField>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RecordSchema" /> class.
        /// </summary>
        /// <param name="namedAttributes">The named attributes.</param>
        /// <param name="runtimeType">Type of the runtime.</param>
        internal RecordSchema(NamedEntityAttributes namedAttributes, Type runtimeType)
            : this(namedAttributes, runtimeType, new Dictionary<string, string>())
        {
        }

        /// <summary>
        ///     Adds the field.
        /// </summary>
        /// <param name="field">The field.</param>
        internal void AddField(RecordField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException("field");
            }

            this.fields.Add(field);
            this.fiedsByName.Add(field.Name, field);
        }

        /// <summary>
        /// Tries to get a field given its name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="result">The result.</param>
        /// <returns>A record field.</returns>
        public bool TryGetField(string fieldName, out RecordField result)
        {
            return this.fiedsByName.TryGetValue(fieldName, out result);
        }

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>A corresponding field name.</returns>
        public RecordField GetField(string fieldName)
        {
            return this.fiedsByName[fieldName];
        }

        /// <summary>
        ///     Gets the fields.
        /// </summary>
        public ReadOnlyCollection<RecordField> Fields
        {
            get { return this.fields.AsReadOnly(); }
        }

        /// <summary>
        ///     Converts current not to json according to the avro specification.
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
            writer.WriteProperty("type", "record");
            writer.WriteProperty("name", this.FullName);
            writer.WriteOptionalProperty("doc", this.Doc);
            writer.WriteOptionalProperty("aliases", this.Aliases);
            writer.WritePropertyName("fields");
            writer.WriteStartArray();
            this.fields.ForEach(_ => _.ToJson(writer, seenSchemas));
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
