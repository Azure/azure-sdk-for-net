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
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;

    // Schema Resolution. Citation from the Avro specification:
    // A reader of Avro data, whether from an RPC or a file, can always parse that data because its schema is provided. But that 
    // schema may not be exactly the schema that was expected. For example, if the data was written with a different version of the software than it is read,
    // then records may have had fields added or removed. This section specifies how such schema differences should be resolved.
    // We call the schema used to write the data as the writer's schema, and the schema that the application expects the reader's schema.
    // Differences between these should be resolved as follows:
    // • It is an error if the two schemas do not match.
    // To match, one of the following must hold:
    //     ◦both schemas have same primitive type
    //     ◦the writer's schema may be promoted to the reader's as follows:
    //         ◾int is promotable to long, float, or double
    //         ◾long is promotable to float or double
    //         ◾float is promotable to double
    //     ◦both schemas are arrays whose item types match
    //     ◦both schemas are maps whose value types match
    //     ◦both schemas are enums whose names match
    //     ◦both schemas are fixed whose sizes and names match
    //     ◦both schemas are records with the same name
    //     ◦either schema is a union
    // • if both are records: 
    //     ◦the ordering of fields may be different: fields are matched by name.
    //     ◦schemas for fields with the same name in both records are resolved recursively.
    //     ◦if the writer's record contains a field with a name not present in the reader's record, the writer's value for that field is ignored.
    //     ◦if the reader's record schema has a field that contains a default value, and writer's schema does not have a field with the same name,
    //        then the reader should use the default value from its field.
    //     ◦if the reader's record schema has a field with no default value, and writer's schema does not have a field with the same name, an error is signalled.
    // • if both are enums: 
    //      if the writer's symbol is not present in the reader's enum, then an error is signalled.
    // • if both are arrays: 
    //      This resolution algorithm is applied recursively to the reader's and writer's array item schemas.
    // • if both are maps: 
    //      This resolution algorithm is applied recursively to the reader's and writer's value schemas.
    // • if both are unions: 
    //      The first schema in the reader's union that matches the selected writer's union schema is recursively resolved against it. if none match,
    //          an error is signalled.
    // • if reader's is a union, but writer's is not 
    //      The first schema in the reader's union that matches the writer's schema is recursively resolved against it. If none match, an error is signalled.
    // • if writer's is a union, but reader's is not 
    //      If the reader's schema matches the selected writer's schema, it is recursively resolved against it. If they do not match, an error is signalled.
    // A schema's "doc" fields are ignored for the purposes of schema resolution. Hence, the "doc" portion of a schema may be dropped at serialization.

    /// <summary>
    /// Matches the schema of writer to the schema of writer.
    /// </summary>
    internal sealed class EvolutionSchemaBuilder
    {
        private readonly Dictionary<TypeSchema, TypeSchema> visited = new Dictionary<TypeSchema, TypeSchema>();

        public TypeSchema Build(TypeSchema w, TypeSchema r)
        {
            this.visited.Clear();
            return this.BuildDynamic(w, r);
        }

        /// <summary>
        /// Implements double dispatch.
        /// </summary>
        /// <param name="w">The writer schema.</param>
        /// <param name="r">The reader schema.</param>
        /// <returns>True if match.</returns>
        private TypeSchema BuildDynamic(TypeSchema w, TypeSchema r)
        {
            return this.BuildCore((dynamic)w, (dynamic)r);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(IntSchema w, IntSchema r)
        {
            return new IntSchema(r.RuntimeType);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(BooleanSchema w, BooleanSchema r)
        {
            return new BooleanSchema();
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(BytesSchema w, BytesSchema r)
        {
            return new BytesSchema();
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(DoubleSchema w, DoubleSchema r)
        {
            return new DoubleSchema();
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(FloatSchema w, FloatSchema r)
        {
            return new FloatSchema(r.RuntimeType);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(LongSchema w, LongSchema r)
        {
            return new LongSchema(r.RuntimeType);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(StringSchema w, StringSchema r)
        {
            return new StringSchema(r.RuntimeType);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(IntSchema w, LongSchema r)
        {
            return new IntSchema(r.RuntimeType);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(IntSchema w, FloatSchema r)
        {
            return new IntSchema(r.RuntimeType);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(IntSchema w, DoubleSchema r)
        {
            return new IntSchema(r.RuntimeType);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(LongSchema w, FloatSchema r)
        {
            return new LongSchema(r.RuntimeType);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(LongSchema w, DoubleSchema r)
        {
            return new LongSchema(r.RuntimeType);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(FloatSchema w, DoubleSchema r)
        {
            return new FloatSchema(r.RuntimeType);
        }

        private TypeSchema BuildCore(ArraySchema w, ArraySchema r)
        {
            TypeSchema itemSchema = this.BuildDynamic(w.ItemSchema, r.ItemSchema);
            return itemSchema != null
                ? new ArraySchema(itemSchema, r.RuntimeType)
                : null;
        }

        private TypeSchema BuildCore(MapSchema w, MapSchema r)
        {
            TypeSchema valueSchema = this.BuildDynamic(w.ValueSchema, r.ValueSchema);
            TypeSchema keySchema = this.BuildDynamic(w.KeySchema, r.KeySchema);
            return valueSchema != null && keySchema != null
                ? new MapSchema(keySchema, valueSchema, r.RuntimeType)
                : null;
        }

        private TypeSchema BuildCore(EnumSchema w, EnumSchema r)
        {
            bool match = this.DoNamesMatch(w, r)
                && w.Symbols.Select((s, i) => i < r.Symbols.Count && r.Symbols[i] == s).All(m => m);
            if (!match)
            {
                return null;
            }

            if (this.visited.ContainsKey(w))
            {
                return this.visited[w];
            }

            var attr = new NamedEntityAttributes(new SchemaName(w.Name, w.Namespace), w.Aliases, w.Doc);
            var schema = new EnumSchema(attr, r.RuntimeType);
            r.Symbols.Where(s => !schema.Symbols.Contains(s)).ToList().ForEach(schema.AddSymbol);
            this.visited.Add(w, schema);
            return schema;
        }

        private TypeSchema BuildCore(FixedSchema w, FixedSchema r)
        {
            bool match = this.DoNamesMatch(w, r) && w.Size == r.Size;
            if (!match)
            {
                return null;
            }

            if (this.visited.ContainsKey(w))
            {
                return this.visited[w];
            }

            var attr = new NamedEntityAttributes(new SchemaName(w.Name, w.Namespace), w.Aliases, w.Doc);
            var schema = new FixedSchema(attr, w.Size, r.RuntimeType);
            this.visited.Add(w, schema);
            return schema;
        }

        private TypeSchema BuildCore(RecordSchema w, RecordSchema r)
        {
            if (!this.DoNamesMatch(w, r))
            {
                return null;
            }

            if (this.visited.ContainsKey(w))
            {
                return this.visited[w];
            }

            var schema = new RecordSchema(
                new NamedEntityAttributes(new SchemaName(w.Name, w.Namespace), w.Aliases, w.Doc),
                r.RuntimeType);

            this.visited.Add(w, schema);

            var fields = this.BuildWriterFields(w, r);
            fields.AddRange(this.BuildReaderFields(w, r, fields.Count));
            fields.Sort((f1, f2) => f1.Position.CompareTo(f2.Position));
            fields.ForEach(schema.AddField);
            return schema;
        }

        private List<RecordField> BuildReaderFields(RecordSchema w, RecordSchema r, int startPosition)
        {
            var readerFieldsWithDefault = r.Fields.Where(field => field.HasDefaultValue);
            var fieldsToAdd = new List<RecordField>();
            foreach (var readerField in readerFieldsWithDefault)
            {
                if (!w.Fields.Any(f => this.DoNamesMatch(f, readerField)))
                {
                    var newField = new RecordField(
                        readerField.NamedEntityAttributes,
                        readerField.TypeSchema,
                        readerField.Order,
                        readerField.HasDefaultValue,
                        readerField.DefaultValue,
                        readerField.MemberInfo,
                        startPosition++)
                    {
                        UseDefaultValue = true
                    };

                    fieldsToAdd.Add(newField);
                }
            }

            if (r.RuntimeType == typeof(AvroRecord) &&
                r.Fields.Any(rf => !rf.HasDefaultValue && !w.Fields.Any(wf => this.DoNamesMatch(wf, rf))))
            {
                throw new SerializationException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    "Fields without default values found in type '{0}'. Not corresponding writer fields found.",
                    r.RuntimeType));
            }
            return fieldsToAdd;
        }

        /// <summary>
        /// Matches if the writer's record contains a field with a name not present in the reader's record, the writer's value for that field is ignored.
        /// </summary>
        /// <param name="w">The writer schema.</param>
        /// <param name="r">The reader schema.</param>
        /// <returns>True if match.</returns>
        private List<RecordField> BuildWriterFields(RecordSchema w, RecordSchema r)
        {
            var fields = new List<RecordField>();
            var writerFields = w.Fields.OrderBy(f => f.FullName);
            foreach (var writerField in writerFields)
            {
                writerField.ShouldBeSkipped = true;

                RecordField readerField = r.Fields.SingleOrDefault(f => this.DoNamesMatch(writerField, f));
                RecordField newField = null;
                if (readerField != null)
                {
                    var schema = this.BuildDynamic(writerField.TypeSchema, readerField.TypeSchema);
                    if (schema == null)
                    {
                        throw new SerializationException(
                            string.Format(
                            CultureInfo.InvariantCulture,
                            "Field '{0}' in type '{1}' does not match the reader field.",
                            writerField.Name,
                            w.RuntimeType));
                    }

                    newField = new RecordField(
                        writerField.NamedEntityAttributes,
                        schema,
                        writerField.Order,
                        writerField.HasDefaultValue,
                        writerField.DefaultValue,
                        readerField.MemberInfo,
                        writerField.Position)
                    {
                        ShouldBeSkipped = false
                    };
                }
                else
                {
                    newField = new RecordField(
                        writerField.NamedEntityAttributes,
                        writerField.TypeSchema,
                        writerField.Order,
                        writerField.HasDefaultValue,
                        writerField.DefaultValue,
                        writerField.MemberInfo,
                        writerField.Position)
                    {
                        ShouldBeSkipped = true
                    };
                }

                fields.Add(newField);
            }
            return fields;
        }

        private TypeSchema BuildCore(UnionSchema w, UnionSchema r)
        {
            var unionSchemas = new List<TypeSchema>();
            foreach (var writerSchema in w.Schemas)
            {
                TypeSchema schema = null;
                foreach (var readerSchema in r.Schemas)
                {
                    schema = this.BuildDynamic(writerSchema, readerSchema);
                    if (schema != null)
                    {
                        break;
                    }
                }

                if (schema == null)
                {
                    return null;
                }

                unionSchemas.Add(schema);
            }
            return new UnionSchema(unionSchemas, r.RuntimeType);
        }

        /// <summary>
        ///  If reader's is a union, but writer's is not the first schema in the reader's union 
        ///  that matches the writer's schema is recursively resolved against it. If none match, an error is signalled.
        /// </summary>
        /// <param name="w">The writer schema.</param>
        /// <param name="r">The reader schema.</param>
        /// <returns>True if match.</returns>
        private TypeSchema BuildCore(TypeSchema w, UnionSchema r)
        {
            return r.Schemas.Select(rs => this.BuildDynamic(w, rs)).SingleOrDefault(s => s != null);
        }

        /// <summary>
        ///  If writer's is a union, but reader's is not then
        ///  if the reader's schema matches the selected writer's schema, it is recursively resolved against it. If they do not match, an error is signalled.
        /// </summary>
        /// <param name="w">The writer schema.</param>
        /// <param name="r">The reader schema.</param>
        /// <returns>True if match.</returns>
        private TypeSchema BuildCore(UnionSchema w, TypeSchema r)
        {
            var schemas = new List<TypeSchema>();
            TypeSchema schemaToReplace = null;
            TypeSchema newSchema = null;
            foreach (var ws in w.Schemas)
            {
                newSchema = this.BuildDynamic(ws, r);
                if (newSchema != null)
                {
                    schemaToReplace = ws;
                    break;
                }
            }

            if (newSchema == null)
            {
                throw new SerializationException("Cannot match the union schema.");
            }

            foreach (var s in w.Schemas)
            {
                schemas.Add(s == schemaToReplace ? newSchema : s);
            }

            return new UnionSchema(schemas, newSchema.RuntimeType);
        }

        private TypeSchema BuildCore(TypeSchema w, NullableSchema r)
        {
            var schema = this.BuildDynamic(w, r.ValueSchema);
            return schema != null
                ? new NullableSchema(r.RuntimeType, schema)
                : null;
        }

        private TypeSchema BuildCore(TypeSchema w, SurrogateSchema r)
        {
            var schema = this.BuildDynamic(w, r.Surrogate);
            return schema != null
                ? new SurrogateSchema(r.RuntimeType, r.SurrogateType, r.Surrogate)
                : null;
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Double dispatch.")]
        private TypeSchema BuildCore(NullSchema w, NullSchema r)
        {
            return new NullSchema(r.RuntimeType);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters",
            Justification = "The method is used for double dispatch.")]
        private TypeSchema BuildCore(object w, object r)
        {
            return null;
        }

        private bool DoNamesMatch(NamedSchema w, NamedSchema r)
        {
            return r.FullName == w.FullName || r.Aliases.Contains(w.FullName);
        }

        private bool DoNamesMatch(RecordField w, RecordField r)
        {
            return r.FullName == w.FullName || r.Aliases.Contains(w.FullName);
        }
    }
}
