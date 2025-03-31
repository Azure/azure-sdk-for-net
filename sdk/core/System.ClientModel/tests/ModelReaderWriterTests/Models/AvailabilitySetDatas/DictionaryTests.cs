// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class DictionaryTests : MrwCollectionTests<Dictionary<string, AvailabilitySetData>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override Dictionary<string, AvailabilitySetData> GetModelInstance()
            => new Dictionary<string, AvailabilitySetData>()
            {
                { ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375 },
                { ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376 }
            };

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private Dictionary_AvailabilitySetData_Builder _dictionary_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(Dictionary<string, AvailabilitySetData>) => _dictionary_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                return null;
            }

            private class Dictionary_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(Dictionary<string, AvailabilitySetData>);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override bool IsCollection => true;

                protected override object CreateInstance() => new Dictionary<string, AvailabilitySetData>();

                protected override void AddKeyValuePair(object collection, string key, object item)
                    => ((Dictionary<string, AvailabilitySetData>)collection).Add(key, (AvailabilitySetData)item);
            }
        }
#nullable enable
    }
}
