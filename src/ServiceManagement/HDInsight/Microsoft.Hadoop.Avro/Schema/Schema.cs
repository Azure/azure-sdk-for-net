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
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    ///     Base class for schema objects.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces",
        Justification = "It is a different namespace.")]
    public abstract class Schema
    {
        private readonly Dictionary<string, string> attributes;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Schema" /> class.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        protected Schema(IDictionary<string, string> attributes)
        {
            if (attributes == null)
            {
                throw new ArgumentNullException("attributes");
            }

            this.attributes = new Dictionary<string, string>(attributes);
        }

        /// <summary>
        ///     Gets the attributes.
        /// </summary>
        public IDictionary<string, string> Attributes
        {
            get { return this.attributes; }
        }

        /// <summary>
        ///     Adds the attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="value">The value.</param>
        public void AddAttribute(string attribute, string value)
        {
            if (attribute == null)
            {
                throw new ArgumentNullException("attribute");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            this.attributes.Add(attribute, value);
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance in JSON format.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            using (var result = new StringWriter(CultureInfo.InvariantCulture))
            {
                var writer = new JsonTextWriter(result);
                this.ToJson(writer, new HashSet<NamedSchema>());
                return result.ToString();
            }
        }

        /// <summary>
        ///     Converts current node to JSON according to the avro specification.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="seenSchemas">The seen schemas.</param>
        internal void ToJson(JsonTextWriter writer, HashSet<NamedSchema> seenSchemas)
        {
            this.ToJsonSafe(writer, seenSchemas);
        }

        /// <summary>
        ///     Converts current node to JSON according to the avro specification.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="seenSchemas">The seen schemas.</param>
        internal abstract void ToJsonSafe(JsonTextWriter writer, HashSet<NamedSchema> seenSchemas);

        #region Schema creation methods.

        /// <summary>
        /// Creates a <see cref="NullSchema" /> instance.
        /// </summary>
        /// <returns>An instance of the <see cref="NullSchema" />.</returns>
        public static NullSchema CreateNull()
        {
            return new NullSchema();
        }

        /// <summary>
        /// Creates a <see cref="BooleanSchema" /> instance.
        /// </summary>
        /// <returns>An instance of the <see cref="BooleanSchema" />.</returns>
        public static BooleanSchema CreateBoolean()
        {
            return new BooleanSchema();
        }

        /// <summary>
        /// Creates a <see cref="IntSchema" /> instance.
        /// </summary>
        /// <returns>An instance of the <see cref="IntSchema" />.</returns>
        public static IntSchema CreateInt()
        {
            return new IntSchema();
        }

        /// <summary>
        /// Creates a <see cref="LongSchema" /> instance.
        /// </summary>
        /// <returns>An instance of the <see cref="LongSchema" />.</returns>
        public static LongSchema CreateLong()
        {
            return new LongSchema();
        }

        /// <summary>
        /// Creates a <see cref="DoubleSchema" /> instance.
        /// </summary>
        /// <returns>An instance of the <see cref="DoubleSchema" />.</returns>
        public static DoubleSchema CreateDouble()
        {
            return new DoubleSchema();
        }

        /// <summary>
        /// Creates a <see cref="FloatSchema" /> instance.
        /// </summary>
        /// <returns>An instance of the <see cref="FloatSchema" />.</returns>
        public static FloatSchema CreateFloat()
        {
            return new FloatSchema();
        }

        /// <summary>
        /// Creates a <see cref="StringSchema" /> instance.
        /// </summary>
        /// <returns>An instance of the <see cref="StringSchema" />.</returns>
        public static StringSchema CreateString()
        {
            return new StringSchema();
        }

        /// <summary>
        /// Creates a <see cref="BytesSchema" /> instance.
        /// </summary>
        /// <returns>An instance of the <see cref="BytesSchema" />.</returns>
        public static BytesSchema CreateBytes()
        {
            return new BytesSchema();
        }

        /// <summary>
        /// Creates a <see cref="RecordSchema" /> instance.
        /// </summary>
        /// <param name="name">Record name.</param>
        /// <param name="ns">Record namespace.</param>
        /// <returns>An instance of the <see cref="RecordSchema" />.</returns>
        public static RecordSchema CreateRecord(string name, string ns)
        {
            return new RecordSchema(new NamedEntityAttributes(new SchemaName(name, ns), new List<string>(), string.Empty), typeof(AvroRecord));
        }

        /// <summary>
        /// Sets the fields.
        /// </summary>
        /// <param name="record">
        /// The record.
        /// </param>
        /// <param name="fields">
        /// The fields.
        /// </param>
        public static void SetFields(RecordSchema record, IEnumerable<RecordField> fields)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            if (fields == null)
            {
                throw new ArgumentNullException("fields");
            }

            if (record.Fields.Count != 0)
            {
                throw new InvalidOperationException("Fields can be set only on empty record.");
            }

            int fieldPosition = 0;
            foreach (var field in fields)
            {
                record.AddField(new RecordField(field.NamedEntityAttributes, field.TypeSchema, field.Order, field.HasDefaultValue, field.DefaultValue, field.MemberInfo, fieldPosition++));
            }
        }

        /// <summary>
        /// Creates a <see cref="RecordField" /> instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="fieldType">The field type.</param>
        /// <returns>An instance of the <see cref="RecordField" />.</returns>
        public static RecordField CreateField(string fieldName, TypeSchema fieldType)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentException("Field name is not allowed to be null or empty.");
            }

            if (fieldType == null)
            {
                throw new ArgumentNullException("fieldType");
            }

            return new RecordField(
                new NamedEntityAttributes(new SchemaName(fieldName), new List<string>(), string.Empty),
                fieldType,
                SortOrder.Ascending,
                false,
                null,
                null,
                -1);
        }

        /// <summary>
        /// Creates a <see cref="RecordField" /> instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="fieldType">The field type.</param>
        /// <param name="ns">The namespace.</param>
        /// <param name="aliases">The name aliases.</param>
        /// <param name="doc">The field documentation.</param>
        /// <param name="defaultValue">The field default value.</param>
        /// <param name="order">The field sorting order.</param>
        /// <returns>An instance of the <see cref="RecordField" />.</returns>
        public static RecordField CreateField(string fieldName, TypeSchema fieldType, string ns, IEnumerable<string> aliases, string doc, object defaultValue, SortOrder order)
        {
            return new RecordField(
                new NamedEntityAttributes(new SchemaName(fieldName, ns), aliases, doc),
                fieldType,
                order,
                defaultValue == null,
                defaultValue,
                null,
                -1);
        }

        /// <summary>
        /// Creates a <see cref="FixedSchema" /> instance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="ns">The namespace.</param>
        /// <param name="size">The size.</param>
        /// <returns>An instance of the <see cref="FixedSchema" />.</returns>
        public static FixedSchema CreateFixed(string name, string ns, int size)
        {
            return new FixedSchema(new NamedEntityAttributes(new SchemaName(name, ns), new List<string>(), string.Empty), size, typeof(byte[]));
        }

        /// <summary>
        /// Creates a <see cref="EnumSchema" /> instance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="ns">The namespace.</param>
        /// <param name="values">The values of the enum.</param>
        /// <returns>An instance of the <see cref="EnumSchema" />.</returns>
        public static EnumSchema CreateEnumeration(string name, string ns, IEnumerable<string> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            var result = new EnumSchema(new NamedEntityAttributes(new SchemaName(name, ns), new List<string>(), string.Empty), typeof(Enum));
            values.ToList().ForEach(result.AddSymbol);
            return result;
        }

        /// <summary>
        /// Creates a <see cref="ArraySchema" /> instance.
        /// </summary>
        /// <param name="itemSchema">The schema of the items.</param>
        /// <returns>An instance of the <see cref="ArraySchema" />.</returns>
        public static ArraySchema CreateArray(TypeSchema itemSchema)
        {
            return new ArraySchema(itemSchema, typeof(Array));
        }

        /// <summary>
        /// Creates a <see cref="MapSchema" /> instance.
        /// </summary>
        /// <param name="valueSchema">The schema of the values.</param>
        /// <returns>An instance of the <see cref="MapSchema" />.</returns>
        public static MapSchema CreateMap(TypeSchema valueSchema)
        {
            return new MapSchema(new StringSchema(), valueSchema, typeof(Dictionary<,>));
        }

        /// <summary>
        /// Creates a <see cref="UnionSchema" /> instance.
        /// </summary>
        /// <param name="schemas">The schemas.</param>
        /// <returns>An instance of the <see cref="UnionSchema" />.</returns>
        public static UnionSchema CreateUnion(params TypeSchema[] schemas)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException("schemas");
            }

            return new UnionSchema(new List<TypeSchema>(schemas), typeof(List<>));
        }

        #endregion //Schema creation methods.
    }
}
