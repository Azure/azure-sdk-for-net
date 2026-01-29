// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Immutable;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ImmutableDictionaryTests : MrwCollectionTests<ImmutableDictionary<string, AvailabilitySetData>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override bool HasReflectionBuilderSupport => false;

        protected override string CollectionTypeName => "ImmutableDictionary<String, AvailabilitySetData>";

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override bool IsWriteOrderDeterministic => false;

        protected override ImmutableDictionary<string, AvailabilitySetData> GetModelInstance()
            => ImmutableDictionary<string, AvailabilitySetData>.Empty
                .Add(ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375)
                .Add(ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376);

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ImmutableDictionary_AvailabilitySetData_Builder _immutable_dictionary_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(ImmutableDictionary<string, AvailabilitySetData>) => _immutable_dictionary_AvailabilitySetData_Builder ??= new(),
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

            private class ImmutableDictionary_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(ImmutableDictionary<string, AvailabilitySetData>.Builder);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => ImmutableDictionary<string, AvailabilitySetData>.Empty.ToBuilder();

                protected override void AddItemWithKey(object collection, string key, object item)
                    => ((ImmutableDictionary<string, AvailabilitySetData>.Builder)collection).Add(key, (AvailabilitySetData)item);

                protected override object ConvertCollectionBuilder(object builder)
                    => ((ImmutableDictionary<string, AvailabilitySetData>.Builder)builder).ToImmutable();
            }
        }
#nullable enable
    }
}
