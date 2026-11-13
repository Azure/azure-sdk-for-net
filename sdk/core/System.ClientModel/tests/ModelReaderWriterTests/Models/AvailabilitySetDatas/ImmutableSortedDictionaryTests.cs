// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Immutable;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ImmutableSortedDictionaryTests : MrwCollectionTests<ImmutableSortedDictionary<string, AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "Dictionary";

        protected override bool HasReflectionBuilderSupport => false;

        protected override string CollectionTypeName => "ImmutableSortedDictionary<String, AvailabilitySetData>";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ImmutableSortedDictionary<string, AvailabilitySetData> GetModelInstance()
            => ImmutableSortedDictionary<string, AvailabilitySetData>.Empty
                .Add(ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375)
                .Add(ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376);

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ImmutableSortedDictionary_AvailabilitySetData_Builder _immutableSortedDictionary_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(ImmutableSortedDictionary<string, AvailabilitySetData>) => _immutableSortedDictionary_AvailabilitySetData_Builder ??= new(),
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

            private class ImmutableSortedDictionary_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(ImmutableSortedDictionary<string, AvailabilitySetData>.Builder);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => ImmutableSortedDictionary<string, AvailabilitySetData>.Empty.ToBuilder();

                protected override void AddItemWithKey(object collection, string key, object item)
                    => ((ImmutableSortedDictionary<string, AvailabilitySetData>.Builder)collection).Add(key, (AvailabilitySetData)item);

                protected override object ConvertCollectionBuilder(object builder)
                    => ((ImmutableSortedDictionary<string, AvailabilitySetData>.Builder)builder).ToImmutable();
            }
        }
#nullable enable
    }
}
