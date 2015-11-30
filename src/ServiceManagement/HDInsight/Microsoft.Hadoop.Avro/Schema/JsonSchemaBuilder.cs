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
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Class responsible for building the internal representation of the schema given a JSON string.
    /// </summary>
    internal sealed class JsonSchemaBuilder
    {
        private static readonly Dictionary<string, Func<PrimitiveTypeSchema>> PrimitiveRuntimeType
            = new Dictionary<string, Func<PrimitiveTypeSchema>>
        {
            { "null", () => new NullSchema() },
            { "boolean", () => new BooleanSchema() },
            { "int", () => new IntSchema() },
            { "long", () => new LongSchema() },
            { "float", () => new FloatSchema() },
            { "double", () => new DoubleSchema() },
            { "bytes", () => new BytesSchema() },
            { "string", () => new StringSchema() }
        };

        private static readonly Dictionary<string, SortOrder> SortValue = new Dictionary<string, SortOrder>
        {
            { SortOrder.Ascending.ToString().ToUpperInvariant(), SortOrder.Ascending },
            { SortOrder.Descending.ToString().ToUpperInvariant(), SortOrder.Descending },
            { SortOrder.Ignore.ToString().ToUpperInvariant(), SortOrder.Ignore }
        };

        /// <summary>
        ///     Parses the JSON schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <returns>Schema internal representation as a tree of nodes.</returns>
        /// <exception cref="System.ArgumentException">Thrown when <paramref name="schema"/> is null or empty.</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when <paramref name="schema"/> is invalid schema.</exception>
        public TypeSchema BuildSchema(string schema)
        {
            if (string.IsNullOrEmpty(schema))
            {
                throw new ArgumentNullException("schema");
            }

            JToken token = JToken.Parse(schema);
            if (token == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "'{0}' is invalid JSON.", schema));
            }

            return this.Parse(token, null, new Dictionary<string, NamedSchema>());
        }

        /// <summary>
        /// Parses the specified token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="parent">The parent schema.</param>
        /// <param name="namedSchemas">The schemas.</param>
        /// <returns>
        /// Schema internal representation.
        /// </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when JSON schema type is not supported.</exception>
        private TypeSchema Parse(JToken token, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas)
        {
            if (token.Type == JTokenType.Object)
            {
                return this.ParseJsonObject(token as JObject, parent, namedSchemas);
            }

            if (token.Type == JTokenType.String)
            {
                var t = (string)token;
                if (namedSchemas.ContainsKey(t))
                {
                    return namedSchemas[t];
                }

                if (parent != null && namedSchemas.ContainsKey(parent.Namespace + "." + t))
                {
                    return namedSchemas[parent.Namespace + "." + t];
                }

                // Primitive.
                return this.ParsePrimitiveTypeFromString(t);
            }

            if (token.Type == JTokenType.Array)
            {
                return this.ParseUnionType(token as JArray, parent, namedSchemas);
            }

            throw new SerializationException(
                string.Format(CultureInfo.InvariantCulture, "Unexpected Json schema type '{0}'.", token));
        }

        /// <summary>
        /// Parses the JSON object.
        /// </summary>
        /// <param name="token">The object.</param>
        /// <param name="parent">The parent schema.</param>
        /// <param name="namedSchemas">The schemas.</param>
        /// <returns>
        /// Schema internal representation.
        /// </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when JSON schema type is invalid.</exception>
        private TypeSchema ParseJsonObject(JObject token, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas)
        {
            JToken tokenType = token[Token.Type];
            if (tokenType.Type == JTokenType.String)
            {
                var type = token.RequiredProperty<string>(Token.Type);
                if (PrimitiveRuntimeType.ContainsKey(type))
                {
                    return this.ParsePrimitiveTypeFromObject(token);
                }
                switch (type)
                {
                    case Token.Record:
                        return this.ParseRecordType(token, parent, namedSchemas);
                    case Token.Enum:
                        return this.ParseEnumType(token, parent, namedSchemas);
                    case Token.Array:
                        return this.ParseArrayType(token, parent, namedSchemas);
                    case Token.Map:
                        return this.ParseMapType(token, parent, namedSchemas);
                    case Token.Fixed:
                        return this.ParseFixedType(token, parent, namedSchemas);
                    default:
                        throw new SerializationException(
                            string.Format(CultureInfo.InvariantCulture, "Invalid type specified: '{0}'.", type));
                }
            }

            if (tokenType.Type == JTokenType.Array)
            {
                return this.ParseUnionType(tokenType as JArray, parent, namedSchemas);
            }

            throw new SerializationException(
                string.Format(CultureInfo.InvariantCulture, "Invalid type specified: '{0}'.", tokenType));
        }

        /// <summary>
        /// Parses a union token.
        /// </summary>
        /// <param name="unionToken">The union token.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="namedSchemas">The named schemas.</param>
        /// <returns>
        /// Schema internal representation.
        /// </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when union schema type is invalid.</exception>
        private TypeSchema ParseUnionType(JArray unionToken, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas)
        {
            var schemas = new List<TypeSchema>();
            foreach (var typeAlternative in unionToken.Children())
            {
                var schema = this.Parse(typeAlternative, parent, namedSchemas);
                if (schema.Type == Token.Union)
                {
                    throw new SerializationException(
                        string.Format(CultureInfo.InvariantCulture, "Union schemas cannot be nested:'{0}'.", unionToken));
                }

                if (schemas.Any(s => UnionSchema.IsSameTypeAs(s, schema)))
                {
                    throw new SerializationException(
                        string.Format(CultureInfo.InvariantCulture, "Unions cannot contains schemas of the same type: '{0}'.", schema.Type));
                }

                schemas.Add(schema);
            }

            return new UnionSchema(schemas, typeof(object));
        }

        /// <summary>
        /// Parses a JSON object representing an Avro enumeration to a <see cref="Microsoft.Hadoop.Avro.Schema.EnumSchema"/>.
        /// </summary>
        /// <param name="enumeration">The JSON token that represents the enumeration.</param>
        /// <param name="parent">The parent schema.</param>
        /// <param name="namedSchemas">The named schemas.</param>
        /// <returns>
        /// Instance of <see cref="TypeSchema" /> containing IR of the enumeration.
        /// </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when <paramref name="enumeration"/> contains invalid symbols.</exception>
        private TypeSchema ParseEnumType(JObject enumeration, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas)
        {
            var name = enumeration.RequiredProperty<string>(Token.Name);
            var nspace = this.GetNamespace(enumeration, parent, name);
            var enumName = new SchemaName(name, nspace);

            var doc = enumeration.OptionalProperty<string>(Token.Doc);
            var aliases = this.GetAliases(enumeration, enumName.Namespace);
            var attributes = new NamedEntityAttributes(enumName, aliases, doc);

            List<string> symbols = enumeration.OptionalArrayProperty(
                Token.Symbols,
                (symbol, index) =>
                {
                    if (symbol.Type != JTokenType.String)
                    {
                        throw new SerializationException(
                            string.Format(CultureInfo.InvariantCulture, "Expected an enum symbol of type string however the type of the symbol is '{0}'.", symbol.Type));
                    }
                    return (string)symbol;
                });

            Dictionary<string, string> customAttributes = enumeration.GetAttributesNotIn(StandardProperties.Enumeration);
            var result = new EnumSchema(attributes, typeof(AvroEnum), customAttributes);
            namedSchemas.Add(result.FullName, result);
            symbols.ForEach(result.AddSymbol);
            return result;
        }

        /// <summary>
        /// Parses a JSON object representing an Avro array.
        /// </summary>
        /// <param name="array">JSON representing the array.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="namedSchemas">The named schemas.</param>
        /// <returns>
        /// A corresponding schema.
        /// </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when no 'items' property is found in <paramref name="array" />.</exception>
        private TypeSchema ParseArrayType(JObject array, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas)
        {
            var itemType = array[Token.Items];
            if (itemType == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Property 'items' cannot be found inside the array '{0}'.", array));
            }

            var elementSchema = this.Parse(itemType, parent, namedSchemas);
            return new ArraySchema(elementSchema, typeof(Array));
        }

        /// <summary>
        /// Parses a JSON object representing an Avro map.
        /// </summary>
        /// <param name="map">JSON representing the map.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="namedSchemas">The named schemas.</param>
        /// <returns>
        /// A corresponding schema.
        /// </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when 'values' property is not found in <paramref name="map" />.</exception>
        private TypeSchema ParseMapType(JObject map, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas)
        {
            var valueType = map[Token.Values];
            if (valueType == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Property 'values' cannot be found inside the map '{0}'.", map));
            }

            var valueSchema = this.Parse(valueType, parent, namedSchemas);
            return new MapSchema(new StringSchema(), valueSchema, typeof(Dictionary<string, object>));
        }

        /// <summary>
        /// Parses the record type.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <param name="parent">The parent schema.</param>
        /// <param name="namedSchemas">The named schemas.</param>
        /// <returns>
        /// Schema internal representation.
        /// </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when <paramref name="record"/> can not be parsed properly.</exception>
        private TypeSchema ParseRecordType(JObject record, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas)
        {
            var name = record.RequiredProperty<string>(Token.Name);
            var nspace = this.GetNamespace(record, parent, name);
            var recordName = new SchemaName(name, nspace);

            var doc = record.OptionalProperty<string>(Token.Doc);
            var aliases = this.GetAliases(record, recordName.Namespace);
            var attributes = new NamedEntityAttributes(recordName, aliases, doc);

            Dictionary<string, string> customAttributes = record.GetAttributesNotIn(StandardProperties.Record);
            var result = new RecordSchema(attributes, typeof(AvroRecord), customAttributes);
            namedSchemas.Add(result.FullName, result);

            List<RecordField> fields = record.OptionalArrayProperty(
                Token.Fields,
                (field, index) =>
                {
                    if (field.Type != JTokenType.Object)
                    {
                        throw new SerializationException(
                            string.Format(CultureInfo.InvariantCulture, "Property 'fields' has invalid value '{0}'.", field));
                    }
                    return this.ParseRecordField(field as JObject, result, namedSchemas, index);
                });

            fields.ForEach(result.AddField);
            return result;
        }

        /// <summary>
        /// Parses the record field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="parent">The parent schema.</param>
        /// <param name="namedSchemas">The named schemas.</param>
        /// <param name="position">The position.</param>
        /// <returns>
        /// Schema internal representation.
        /// </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when <paramref name="field"/> is not valid or when sort order is not valid.</exception>
        private RecordField ParseRecordField(JObject field, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas, int position)
        {
            var name = field.RequiredProperty<string>(Token.Name);
            var doc = field.OptionalProperty<string>(Token.Doc);
            var order = field.OptionalProperty<string>(Token.Order);
            var aliases = this.GetAliases(field, parent.FullName);
            var fieldType = field[Token.Type];
            if (fieldType == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Record field schema '{0}' has no type.", field));
            }

            TypeSchema type = this.Parse(fieldType, parent, namedSchemas);
            object defaultValue = null;
            bool hasDefaultValue = field[Token.Default] != null;
            if (hasDefaultValue)
            {
                var objectParser = new JsonObjectParser();
                defaultValue = objectParser.Parse(type, field[Token.Default].ToString());
            }

            var orderValue = SortOrder.Ascending;
            if (!string.IsNullOrEmpty(order))
            {
                if (!SortValue.ContainsKey(order.ToUpperInvariant()))
                {
                    throw new SerializationException(
                        string.Format(CultureInfo.InvariantCulture, "Invalid sort order of the field '{0}'.", order));
                }
                orderValue = SortValue[order.ToUpperInvariant()];
            }

            var fieldName = new SchemaName(name);
            var attributes = new NamedEntityAttributes(fieldName, aliases, doc);

            return new RecordField(attributes, type, orderValue, hasDefaultValue, defaultValue, null, position);
        }

        /// <summary>
        ///     Parses the primitive type schema.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Schema internal representation.</returns>
        private TypeSchema ParsePrimitiveTypeFromString(string token)
        {
            return this.CreatePrimitiveTypeSchema(token, new Dictionary<string, string>());
        }

        /// <summary>
        ///     Parses the primitive type schema.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="usingTypeName">Will use this type name for creating the primitive type.</param>
        /// <returns>Schema internal representation.</returns>
        private TypeSchema ParsePrimitiveTypeFromObject(JObject token, string usingTypeName = null)
        {
            if (usingTypeName == null)
            {
                usingTypeName = token.RequiredProperty<string>(Token.Type);
            }

            var customAttributes = token.GetAttributesNotIn(StandardProperties.Primitive);
            return this.CreatePrimitiveTypeSchema(usingTypeName, customAttributes);
        }

        /// <summary>
        ///     Creates the primitive type schema.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns>Schema internal representation.</returns>
        private TypeSchema CreatePrimitiveTypeSchema(string type, Dictionary<string, string> attributes)
        {
            var result = PrimitiveRuntimeType[type]();
            foreach (var attribute in attributes)
            {
                result.AddAttribute(attribute.Key, attribute.Value);
            }
            return result;
        }

        private FixedSchema ParseFixedType(JObject type, NamedSchema parent, Dictionary<string, NamedSchema> namedSchemas)
        {
            var name = type.RequiredProperty<string>(Token.Name);
            var nspace = this.GetNamespace(type, parent, name);
            var fixedName = new SchemaName(name, nspace);

            var size = type.RequiredProperty<int>(Token.Size);
            if (size <= 0)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Only positive size of fixed values allowed: '{0}'.", size));
            }

            var aliases = this.GetAliases(type, fixedName.Namespace);
            var attributes = new NamedEntityAttributes(fixedName, aliases, string.Empty);

            var customAttributes = type.GetAttributesNotIn(StandardProperties.Record);
            var result = new FixedSchema(attributes, size, typeof(byte[]), customAttributes);

            namedSchemas.Add(result.FullName, result);

            return result;
        }

        private string GetNamespace(JObject type, NamedSchema parentSchema, string name)
        {
            var nspace = type.OptionalProperty<string>(Token.Namespace);
            if (string.IsNullOrEmpty(nspace) && !name.Contains(".") && parentSchema != null)
            {
                nspace = parentSchema.Namespace;
            }
            return nspace;
        }

        private List<string> GetAliases(JObject type, string @namespace)
        {
            List<string> aliases = type.OptionalArrayProperty(
                Token.Aliases,
                (alias, index) =>
                {
                    if (alias.Type != JTokenType.String)
                    {
                        throw new SerializationException(
                            string.Format(CultureInfo.InvariantCulture, "Property 'aliases' has invalid value '{0}'.", alias));
                    }

                    var result = (string)alias;
                    if (string.IsNullOrEmpty(result))
                    {
                        throw new SerializationException(
                            string.Format(CultureInfo.InvariantCulture, "Alias is not allowed to be null or empty."));
                    }

                    return result;
                });

            return aliases
                .Select(alias => string.IsNullOrEmpty(@namespace) || alias.Contains(".") ? alias : @namespace + "." + alias)
                .ToList();
        }
    }
}
