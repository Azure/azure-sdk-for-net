// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class MixedListTests : MrwCollectionTests<List<object>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override string CollectionTypeName => "List<Object>";

        protected override List<object> GetModelInstance()
        {
            return
            [
                new List<AvailabilitySetData>([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]),
                ModelInstances.s_testAs_3379,
                new List<AvailabilitySetData>([ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378]),
            ];
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ListTests.LocalContext> s_availabilitySetData_ListTests_LocalContext = new(() => new());

            private List_Object_Builder _list_object_Builder;
            private Object_Builder _object_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(List<object>) => _list_object_Builder ??= new(),
                    Type t when t == typeof(object) => _object_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_ListTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class Object_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(object);

                protected override object CreateInstance() => new ObjectDiscriminator();
            }

            private class List_Object_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<object>);

                protected override Type ItemType => typeof(object);

                protected override object CreateInstance() => new List<object>();

                protected override void AddItem(object collection, object item)
                    => ((List<object>)collection).Add(item);
            }

            private class ObjectDiscriminator : IJsonModel<object>
            {
                public object Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                {
                    if (reader.TokenType == JsonTokenType.StartObject)
                    {
                        var aset = s_availabilitySetData_ListTests_LocalContext.Value.GetTypeBuilder(typeof(AvailabilitySetData)).CreateObject();
                        return ((IJsonModel<AvailabilitySetData>)aset).Create(ref reader, options);
                    }
                    else if (reader.TokenType == JsonTokenType.StartArray)
                    {
                        return DeserializeList(ref reader, options);
                    }
                    throw new FormatException($"Unexpected token type: {reader.TokenType}");
                }

                public object Create(BinaryData data, ModelReaderWriterOptions options)
                {
                    return new object();
                }

                private object DeserializeList(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                {
                    reader.Read();
                    List<object> list = [];
                    do
                    {
                        list.Add(Create(ref reader, options));
                    } while (reader.Read() && reader.TokenType != JsonTokenType.EndArray);
                    return list;
                }

                public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

                public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
                {
                }

                public BinaryData Write(ModelReaderWriterOptions options)
                {
                    return BinaryData.Empty;
                }
            }
        }
#nullable enable
    }
}
