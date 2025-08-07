// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class DictionaryOfDictionaryTests : MrwCollectionTests<Dictionary<string, Dictionary<string, AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override string CollectionTypeName => "Dictionary<String, Dictionary<String, AvailabilitySetData>>";

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override Dictionary<string, Dictionary<string, AvailabilitySetData>> GetModelInstance()
            => new()
            {
                { "dictionary1", new(){ { ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375 }, { ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376 } } },
                { "dictionary2", new(){ { ModelInstances.s_testAs_3377.Name!, ModelInstances.s_testAs_3377 }, { ModelInstances.s_testAs_3378.Name!, ModelInstances.s_testAs_3378 } } },
            };

#nullable disable
        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<DictionaryTests.LocalContext> s_availabilitySetData_DictionaryTests_LocalContext = new(() => new());

            private Dictionary_String_Dictionary_String_AvailabilitySetData_Builder _dictionary_String_Dictionary_String_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(Dictionary<string, Dictionary<string, AvailabilitySetData>>) => _dictionary_String_Dictionary_String_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_DictionaryTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class Dictionary_String_Dictionary_String_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(Dictionary<string, Dictionary<string, AvailabilitySetData>>);

                protected override Type ItemType => typeof(Dictionary<string, AvailabilitySetData>);

                protected override object CreateInstance() => new Dictionary<string, Dictionary<string, AvailabilitySetData>>();

                protected override void AddItemWithKey(object collection, string key, object item)
                    => ((Dictionary<string, Dictionary<string, AvailabilitySetData>>)collection).Add(key, (Dictionary<string, AvailabilitySetData>)item);
            }
        }
#nullable enable
    }
}
