// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ImmutableListTests : MrwCollectionTests<ImmutableList<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override string CollectionTypeName => "ImmutableList<AvailabilitySetData>";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ImmutableList<AvailabilitySetData> GetModelInstance()
            => new List<AvailabilitySetData>([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]).ToImmutableList();

#nullable disable
        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ImmutableList_AvailabilitySetData_Builder _immutableList_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(ImmutableList<AvailabilitySetData>) => _immutableList_AvailabilitySetData_Builder ??= new(),
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

            private class ImmutableList_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(ImmutableList<AvailabilitySetData>.Builder);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => ImmutableList<AvailabilitySetData>.Empty.ToBuilder();

                protected override void AddItem(object collection, object item)
                    => ((ImmutableList<AvailabilitySetData>.Builder)collection).Add((AvailabilitySetData)item);

                protected override object ConvertCollectionBuilder(object builder)
                    => ((ImmutableList<AvailabilitySetData>.Builder)builder).ToImmutable();
            }
        }
#nullable enable
    }
}
