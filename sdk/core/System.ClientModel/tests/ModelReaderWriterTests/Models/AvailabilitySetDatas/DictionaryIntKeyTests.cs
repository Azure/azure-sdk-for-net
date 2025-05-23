// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class DictionaryIntKeyTests : MrwCollectionTests<Dictionary<int, AvailabilitySetData>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override string CollectionTypeName => "Dictionary<Int32, AvailabilitySetData>";

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override Dictionary<int, AvailabilitySetData> GetModelInstance()
            => new Dictionary<int, AvailabilitySetData>()
            {
                { ModelInstances.s_testAs_3375.PlatformUpdateDomainCount!.Value, ModelInstances.s_testAs_3375 },
                { ModelInstances.s_testAs_3376.PlatformUpdateDomainCount!.Value, ModelInstances.s_testAs_3376 }
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
                    Type t when t == typeof(Dictionary<int, AvailabilitySetData>) => _dictionary_AvailabilitySetData_Builder ??= new(),
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
                protected override Type BuilderType => typeof(Dictionary<int, AvailabilitySetData>);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => new Dictionary<int, AvailabilitySetData>();

                protected override void AddItemWithKey(object collection, string key, object item)
                    => ((Dictionary<int, AvailabilitySetData>)collection).Add(int.Parse(key), (AvailabilitySetData)item);
            }
        }
#nullable enable
    }
}
