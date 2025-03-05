// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Immutable;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ImmutableArrayTests : MrwCollectionTests<ImmutableArray<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ImmutableArray<AvailabilitySetData> GetModelInstance()
            => ImmutableArray<AvailabilitySetData>.Empty
                .Add(ModelInstances.s_testAs_3375)
                .Add(ModelInstances.s_testAs_3376);

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ImmutableArray_AvailabilitySetData_Info? _immutableArray_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(ImmutableArray<AvailabilitySetData>) => _immutableArray_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type)
                };
            }

            private class ImmutableArray_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ImmutableArray_AvailabilitySetData_Builder();

                private class ImmutableArray_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<ImmutableArray<AvailabilitySetData>.Builder> _instance = new(() => ImmutableArray<AvailabilitySetData>.Empty.ToBuilder());

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object ToObject() => _instance.Value.ToImmutable();

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
