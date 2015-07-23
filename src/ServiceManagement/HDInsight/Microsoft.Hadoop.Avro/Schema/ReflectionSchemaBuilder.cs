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
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;

    /// <summary>
    ///     This class creates an avro schema given a c# type.
    /// </summary>
    internal sealed class ReflectionSchemaBuilder
    {
        private static readonly Dictionary<Type, Func<Type, PrimitiveTypeSchema>> RuntimeTypeToAvroSchema =
            new Dictionary<Type, Func<Type, PrimitiveTypeSchema>>
            {
                { typeof(AvroNull), type => new NullSchema(type) },
                { typeof(char), type => new IntSchema(type) },
                { typeof(byte), type => new IntSchema(type) },
                { typeof(sbyte), type => new IntSchema(type) },
                { typeof(short), type => new IntSchema(type) },
                { typeof(ushort), type => new IntSchema(type) },
                { typeof(uint), type => new IntSchema(type) },
                { typeof(int), type => new IntSchema(type) },
                { typeof(bool), type => new BooleanSchema() },
                { typeof(long), type => new LongSchema(type) },
                { typeof(ulong), type => new LongSchema(type) },
                { typeof(float), type => new FloatSchema() },
                { typeof(double), type => new DoubleSchema() },
                { typeof(decimal), type => new StringSchema(type) },
                { typeof(string), type => new StringSchema(type) },
                { typeof(Uri), type => new StringSchema(type) },
                { typeof(byte[]), type => new BytesSchema() },
                { typeof(DateTime), type => new LongSchema(type) }
            };

        private readonly AvroSerializerSettings settings;
        private readonly HashSet<Type> knownTypes;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReflectionSchemaBuilder" /> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public ReflectionSchemaBuilder(AvroSerializerSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            this.settings = settings;
            this.knownTypes = new HashSet<Type>(this.settings.KnownTypes);
        }

        /// <summary>
        ///     Creates a schema definition.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///     New instance of schema definition.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="type"/> parameter is null.</exception>
        public TypeSchema BuildSchema(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            AvroContractResolver resolver = this.settings.Resolver;
            this.knownTypes.UnionWith(resolver.GetKnownTypes(type) ?? new List<Type>());
            return this.CreateSchema(false, type, new Dictionary<string, NamedSchema>(), 0);
        }

        private TypeSchema CreateSchema(bool forceNullable, Type type, Dictionary<string, NamedSchema> schemas, uint currentDepth)
        {
            if (currentDepth == this.settings.MaxItemsInSchemaTree)
            {
                throw new SerializationException(string.Format(CultureInfo.InvariantCulture, "Maximum depth of object graph reached."));
            }

            var surrogate = this.settings.Surrogate;
            if (surrogate != null)
            {
                var surrogateType = surrogate.GetSurrogateType(type);
                if (surrogateType == null || surrogateType.IsUnsupported())
                {
                    throw new SerializationException(
                        string.Format(CultureInfo.InvariantCulture, "Type '{0}' is not supported.", surrogateType ?? type));
                }

                if (type != surrogateType)
                {
                    return new SurrogateSchema(
                        type,
                        surrogateType,
                        new Dictionary<string, string>(),
                        this.CreateSchema(forceNullable, surrogateType, schemas, currentDepth + 1));
                }
            }

            var typeInfo = this.settings.Resolver.ResolveType(type);
            if (typeInfo == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Unexpected type info returned for type '{0}'.", type));
            }

            return typeInfo.Nullable || forceNullable
                ? this.CreateNullableSchema(type, schemas, currentDepth)
                : this.CreateNotNullableSchema(type, schemas, currentDepth);
        }

        private TypeSchema CreateNullableSchema(Type type, Dictionary<string, NamedSchema> schemas, uint currentDepth)
        {
            var typeSchemas = new List<TypeSchema> { new NullSchema(type) };
            var notNullableSchema = this.CreateNotNullableSchema(type, schemas, currentDepth);

            var unionSchema = notNullableSchema as UnionSchema;
            if (unionSchema != null)
            {
                typeSchemas.AddRange(unionSchema.Schemas);
            }
            else
            {
                typeSchemas.Add(notNullableSchema);
            }
            return new UnionSchema(typeSchemas, type);
        }

        /// <summary>
        /// Creates the avro schema for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="schemas">The schemas seen so far.</param>
        /// <param name="currentDepth">The current depth.</param>
        /// <returns>
        /// New instance of schema.
        /// </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when maximum depth of object graph is reached.</exception>
        private TypeSchema CreateNotNullableSchema(Type type, Dictionary<string, NamedSchema> schemas, uint currentDepth)
        {
            TypeSchema schema = TryBuildPrimitiveTypeSchema(type);
            if (schema != null)
            {
                return schema;
            }

            if ((type.IsInterface || type.IsAbstract)
                || this.HasApplicableKnownType(type))
            {
                return this.BuildKnownTypeSchema(type, schemas, currentDepth);
            }

            return this.BuildComplexTypeSchema(type, schemas, currentDepth);
        }

        /// <summary>
        ///     Generates the primitive schema if the type is primitive.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///     New instance of schema.
        /// </returns>
        private static TypeSchema TryBuildPrimitiveTypeSchema(Type type)
        {
            if (!RuntimeTypeToAvroSchema.ContainsKey(type))
            {
                return null;
            }
            return RuntimeTypeToAvroSchema[type](type);
        }

        /// <summary>
        ///     Generates the schema for a complex type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="schemas">The schemas.</param>
        /// <param name="currentDepth">The current depth.</param>
        /// <returns>
        ///     New instance of schema.
        /// </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when <paramref name="type"/> is not supported.</exception>
        private TypeSchema BuildComplexTypeSchema(Type type, Dictionary<string, NamedSchema> schemas, uint currentDepth)
        {
            if (type.IsEnum)
            {
                return this.BuildEnumTypeSchema(type, schemas);
            }

            if (type.IsArray)
            {
                return this.BuildArrayTypeSchema(type, schemas, currentDepth);
            }

            // Dictionary
            Type dictionaryType = type
                .GetAllInterfaces()
                .SingleOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>));

            if (dictionaryType != null
                && (dictionaryType.GetGenericArguments()[0] == typeof(string)
                 || dictionaryType.GetGenericArguments()[0] == typeof(Uri)))
            {
                return new MapSchema(
                    this.CreateNotNullableSchema(dictionaryType.GetGenericArguments()[0], schemas, currentDepth + 1),
                    this.CreateSchema(false, dictionaryType.GetGenericArguments()[1], schemas, currentDepth + 1),
                    type);
            }

            // Enumerable
            Type enumerableType = type
                .GetAllInterfaces()
                .SingleOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            if (enumerableType != null)
            {
                var itemType = enumerableType.GetGenericArguments()[0];
                return new ArraySchema(this.CreateSchema(false, itemType, schemas, currentDepth + 1), type);
            }

            //Nullable
            var nullable = Nullable.GetUnderlyingType(type);
            if (nullable != null)
            {
                return new NullableSchema(
                    type,
                    new Dictionary<string, string>(),
                    this.CreateSchema(false, nullable, schemas, currentDepth + 1));
            }

            // Others
            if (type.IsClass || type.IsValueType)
            {
                return this.BuildRecordTypeSchema(type, schemas, currentDepth);
            }

            throw new SerializationException(
                string.Format(CultureInfo.InvariantCulture, "Type '{0}' is not supported.", type));
        }

        /// <summary>
        ///     Builds the enumeration type schema.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="schemas">The schemas.</param>
        /// <returns>Enumeration schema.</returns>
        private TypeSchema BuildEnumTypeSchema(Type type, Dictionary<string, NamedSchema> schemas)
        {
            if (type.IsFlagEnum())
            {
                return new LongSchema(type);
            }

            NamedSchema schema;
            if (schemas.TryGetValue(type.ToString(), out schema))
            {
                return schema;
            }

            var attributes = this.GetNamedEntityAttributesFrom(type);
            var result = new EnumSchema(attributes, type);
            schemas.Add(type.ToString(), result);
            return result;
        }

        private NamedEntityAttributes GetNamedEntityAttributesFrom(Type type)
        {
            AvroContractResolver resolver = this.settings.Resolver;
            TypeSerializationInfo typeInfo = resolver.ResolveType(type);
            var name = new SchemaName(typeInfo.Name, typeInfo.Namespace);
            var aliases = typeInfo
                .Aliases
                .Select(alias => string.IsNullOrEmpty(name.Namespace) || alias.Contains(".") ? alias : name.Namespace + "." + alias)
                .ToList();
            return new NamedEntityAttributes(name, aliases, typeInfo.Doc);
        }

        /// <summary>
        ///     Generates the array type schema.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="schemas">The schemas.</param>
        /// <param name="currentDepth">The current depth.</param>
        /// <returns>
        ///     A new instance of schema.
        /// </returns>
        private TypeSchema BuildArrayTypeSchema(Type type, Dictionary<string, NamedSchema> schemas, uint currentDepth)
        {
            Type element = type.GetElementType();
            TypeSchema elementSchema = this.CreateSchema(false, element, schemas, currentDepth + 1);
            return new ArraySchema(elementSchema, type);
        }

        /// <summary>
        /// Generates the record type schema.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="schemas">The schemas.</param>
        /// <param name="currentDepth">The current depth.</param>
        /// <returns>
        /// Instance of schema.
        /// </returns>
        private TypeSchema BuildRecordTypeSchema(Type type, Dictionary<string, NamedSchema> schemas, uint currentDepth)
        {
            if (type == typeof(DateTimeOffset))
            {
                return this.settings.UsePosixTime
                    ? (TypeSchema)new LongSchema(type)
                    : new StringSchema(type);
            }

            NamedSchema schema;
            if (schemas.TryGetValue(type.ToString(), out schema))
            {
                return schema;
            }

            if (type == typeof(Guid))
            {
                var recordName = new SchemaName(type.GetStrippedFullName());
                var attributes = new NamedEntityAttributes(recordName, new List<string>(), string.Empty);
                var result = new FixedSchema(attributes, 16, type);
                schemas.Add(type.ToString(), result);
                return result;
            }

            var attr = this.GetNamedEntityAttributesFrom(type);
            AvroContractResolver resolver = this.settings.Resolver;
            var record = new RecordSchema(
                attr,
                type);
            schemas.Add(type.ToString(), record);

            var members = resolver.ResolveMembers(type);
            this.AddRecordFields(members, schemas, currentDepth, record);
            return record;
        }

        private TypeSchema BuildKnownTypeSchema(Type type, Dictionary<string, NamedSchema> schemas, uint currentDepth)
        {
            var applicable = this.GetApplicableKnownTypes(type).ToList();
            if (applicable.Count == 0)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Could not find any matching known type for '{0}'.", type));
            }

            var knownTypeSchemas = new List<TypeSchema>(applicable.Count);
            applicable.ForEach(t => knownTypeSchemas.Add(TryBuildPrimitiveTypeSchema(t) ?? this.BuildComplexTypeSchema(t, schemas, currentDepth)));
            return new UnionSchema(knownTypeSchemas, type);
        }

        private bool HasApplicableKnownType(Type type)
        {
            return this.GetApplicableKnownTypes(type).Count(t => t != type) != 0;
        }

        private IEnumerable<Type> GetApplicableKnownTypes(Type type)
        {
            var allKnownTypes = new HashSet<Type>(this.knownTypes)
            {
                type
            };
            return allKnownTypes.Where(t => t.CanBeKnownTypeOf(type));
        }

        private TypeSchema TryBuildUnionSchema(Type memberType, MemberInfo memberInfo, Dictionary<string, NamedSchema> schemas, uint currentDepth)
        {
            var attribute = memberInfo.GetCustomAttributes(false).OfType<AvroUnionAttribute>().FirstOrDefault();
            if (attribute == null)
            {
                return null;
            }
            
            var result = attribute.TypeAlternatives.ToList();
            if (memberType != typeof(object) && !memberType.IsAbstract && !memberType.IsInterface)
            {
                result.Add(memberType);
            }

            return new UnionSchema(result.Select(type => this.CreateNotNullableSchema(type, schemas, currentDepth + 1)).ToList(), memberType);
        }

        private FixedSchema TryBuildFixedSchema(Type memberType, MemberInfo memberInfo, NamedSchema parentSchema)
        {
            var result = memberInfo.GetCustomAttributes(false).OfType<AvroFixedAttribute>().FirstOrDefault();
            if (result == null)
            {
                return null;
            }

            if (memberType != typeof(byte[]))
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "'{0}' can be set only to members of type byte[].", typeof(AvroFixedAttribute)));
            }

            var schemaNamespace = string.IsNullOrEmpty(result.Namespace) && !result.Name.Contains(".") && parentSchema != null
                                      ? parentSchema.Namespace
                                      : result.Namespace;

            return new FixedSchema(
                new NamedEntityAttributes(new SchemaName(result.Name, schemaNamespace), new List<string>(), string.Empty),
                result.Size,
                memberType);
        }

        private void AddRecordFields(
            IEnumerable<MemberSerializationInfo> members,
            Dictionary<string, NamedSchema> schemas,
            uint currentDepth,
            RecordSchema record)
        {
            int index = 0;
            foreach (MemberSerializationInfo info in members)
            {
                var property = info.MemberInfo as PropertyInfo;
                var field = info.MemberInfo as FieldInfo;

                Type memberType;
                if (property != null)
                {
                    memberType = property.PropertyType;
                }
                else if (field != null)
                {
                    memberType = field.FieldType;
                }
                else
                {
                    throw new SerializationException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "Type member '{0}' is not supported.",
                            info.MemberInfo.MemberType));
                }

                TypeSchema fieldSchema = this.TryBuildUnionSchema(memberType, info.MemberInfo, schemas, currentDepth)
                                         ?? this.TryBuildFixedSchema(memberType, info.MemberInfo, record)
                                         ?? this.CreateSchema(info.Nullable, memberType, schemas, currentDepth + 1);

                var aliases = info
                    .Aliases
                    .Select(alias => alias.Contains(".") ? alias : record.Namespace + "." + alias)
                    .ToList();
                var recordField = new RecordField(
                    new NamedEntityAttributes(new SchemaName(info.Name), aliases, info.Doc),
                    fieldSchema,
                    SortOrder.Ascending,
                    false,
                    null,
                    info.MemberInfo,
                    index++);
                record.AddField(recordField);
            }
        }
    }
}
