// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ImmutableQueueTests : MrwCollectionTests<ImmutableQueue<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override string CollectionTypeName => "ImmutableQueue<AvailabilitySetData>";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ImmutableQueue<AvailabilitySetData> GetModelInstance()
            => ImmutableQueue<AvailabilitySetData>.Empty
                .Enqueue(ModelInstances.s_testAs_3375)
                .Enqueue(ModelInstances.s_testAs_3376);

#nullable disable
        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ImmutableQueue_AvailabilitySetData_Builder _immutableQueue_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(ImmutableQueue<AvailabilitySetData>) => _immutableQueue_AvailabilitySetData_Builder ??= new(),
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

            private class ImmutableQueue_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<AvailabilitySetData>);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => new List<AvailabilitySetData>();

                protected override void AddItem(object collection, object item)
                    => ((List<AvailabilitySetData>)collection).Add((AvailabilitySetData)item);

                protected override object ConvertCollectionBuilder(object builder)
                    => ImmutableQueue.CreateRange((List<AvailabilitySetData>)builder);
            }
        }
#nullable enable
    }
}
