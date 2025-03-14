// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class DictionaryOfDictionaryTests : MrwCollectionTests<Dictionary<string, Dictionary<string, AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override Dictionary<string, Dictionary<string, AvailabilitySetData>> GetModelInstance()
            => new()
            {
                { "dictionary1", new(){ { ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375 }, { ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376 } } },
                { "dictionary2", new(){ { ModelInstances.s_testAs_3377.Name!, ModelInstances.s_testAs_3377 }, { ModelInstances.s_testAs_3378.Name!, ModelInstances.s_testAs_3378 } } },
            };

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<DictionaryTests.LocalContext> s_availabilitySetData_DictionaryTests_LocalContext = new(() => new());

            private Dictionary_String_Dictionary_String_AvailabilitySetData_Builder? _dictionary_String_Dictionary_String_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(Dictionary<string, Dictionary<string, AvailabilitySetData>>) => _dictionary_String_Dictionary_String_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? builder))
                    return builder;
                if (s_availabilitySetData_DictionaryTests_LocalContext.Value.TryGetModelBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class Dictionary_String_Dictionary_String_AvailabilitySetData_Builder : ModelBuilder
            {
                protected override bool IsCollection => true;

                protected override object CreateInstance() => new Dictionary<string, Dictionary<string, AvailabilitySetData>>();

                protected override void AddKeyValuePair(object collection, string key, object item)
                    => AssertCollection<Dictionary<string, Dictionary<string, AvailabilitySetData>>>(collection).Add(AssertKey(key), AssertItem<Dictionary<string, AvailabilitySetData>>(item));

                protected override object CreateElementInstance()
                    => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();
            }
        }
    }
}
