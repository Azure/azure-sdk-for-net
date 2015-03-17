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
namespace Microsoft.Hadoop.Avro.Serializers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Visitor for assigning serializers to the schema tree.
    /// </summary>
    internal sealed class SerializerAssigningVisitor
    {
        private readonly AvroSerializerSettings settings;
        private readonly HashSet<Schema> visited;

        public SerializerAssigningVisitor(AvroSerializerSettings settings)
        {
            this.visited = new HashSet<Schema>();
            this.settings = settings;
        }

        public void Visit(Schema schema)
        {
            this.visited.Clear();
            this.VisitDynamic(schema);
        }

        private void VisitDynamic(Schema schema)
        {
            this.VisitCore((dynamic)schema);
        }

        private void VisitCore(RecordSchema s)
        {
            if (this.visited.Contains(s))
            {
                return;
            }
            this.visited.Add(s);

            s.Serializer = new ClassSerializer(s);

            foreach (var field in s.Fields)
            {
                this.VisitDynamic(field);
            }
        }

        private void VisitCore(IntSchema s)
        {
            s.Serializer = new IntSerializer(s);
        }

        private void VisitCore(FloatSchema s)
        {
            s.Serializer = new FloatSerializer(s);
        }

        private void VisitCore(LongSchema s)
        {
            if (s.RuntimeType == typeof(DateTime))
            {
                s.Serializer = new DateTimeSerializer(s, this.settings.UsePosixTime);
            }
            else if (s.RuntimeType == typeof(DateTimeOffset))
            {
                s.Serializer = new DateTimeOffsetSerializer(s, this.settings.UsePosixTime);
            }
            else
            {
                s.Serializer = new LongSerializer(s);
            }
        }

        private void VisitCore(DoubleSchema s)
        {
            s.Serializer = new DoubleSerializer(s);
        }

        private void VisitCore(NullSchema s)
        {
            s.Serializer = new NullSerializer(s);
        }

        private void VisitCore(BooleanSchema s)
        {
            s.Serializer = new BooleanSerializer(s);
        }

        private void VisitCore(StringSchema s)
        {
            if (s.RuntimeType == typeof(Uri))
            {
                s.Serializer = new UriSerializer(s);
            }
            else if (s.RuntimeType == typeof(decimal))
            {
                s.Serializer = new AsStringSerializer(s);
            }
            else if (s.RuntimeType == typeof(DateTimeOffset))
            {
                s.Serializer = new DateTimeOffsetSerializer(s, this.settings.UsePosixTime);
            }
            else
            {
                s.Serializer = new StringSerializer(s);
            }
        }

        private void VisitCore(BytesSchema s)
        {
            s.Serializer = new ByteArraySerializer(s);
        }

        private void VisitCore(RecordField s)
        {
            s.Builder = new RecordFieldSerializer(s);
            this.VisitDynamic(s.TypeSchema);
        }

        private void VisitCore(ArraySchema s)
        {
            if (s.RuntimeType == typeof(Array))
            {
                s.Serializer = new ArraySerializer(s);
            }
            else if (s.RuntimeType.IsArray)
            {
                s.Serializer = new ArraySerializer(s);
                if (s.RuntimeType.GetArrayRank() != 1)
                {
                    s.Serializer = new MultidimensionalArraySerializer(s);
                }
            }
            else
            {
                Type listType =
                    s.RuntimeType.GetAllInterfaces().SingleOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>));

                Type enumerableType =
                    s.RuntimeType.GetAllInterfaces().SingleOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                if (listType != null)
                {
                    s.Serializer = new ListSerializer(s);
                }
                else if (enumerableType != null)
                {
                    s.Serializer = new EnumerableSerializer(s);
                }
            }
            this.VisitDynamic(s.ItemSchema);
        }

        private void VisitCore(MapSchema s)
        {
            s.Serializer = new DictionarySerializer(s);
            this.VisitDynamic(s.KeySchema);
            this.VisitDynamic(s.ValueSchema);
        }

        private void VisitCore(EnumSchema s)
        {
            s.Serializer = new EnumSerializer(s);
        }

        private void VisitCore(SurrogateSchema s)
        {
            s.Serializer = new SurrogateSerializer(this.settings, s);
            this.VisitDynamic(s.Surrogate);
        }

        private void VisitCore(UnionSchema s)
        {
            s.Serializer = new UnionSerializer(s);
            foreach (var schema in s.Schemas)
            {
                this.VisitDynamic(schema);
            }
        }

        private void VisitCore(FixedSchema s)
        {
            if (s.RuntimeType == typeof(Guid))
            {
                s.Serializer = new GuidSerializer(s);
            }
            else
            {
                s.Serializer = new FixedSerializer(s);
            }
        }

        private void VisitCore(NullableSchema s)
        {
            s.Serializer = new NullableSerializer(s);
            this.VisitDynamic(s.ValueSchema);
        }

        private void VisitCore(object obj)
        {
            throw new SerializationException(
                string.Format(CultureInfo.InvariantCulture, "Unknown schema of type '{0}'.", obj.GetType()));
        }
    }
}
