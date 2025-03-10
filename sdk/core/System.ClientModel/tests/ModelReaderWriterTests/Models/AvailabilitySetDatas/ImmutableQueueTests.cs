// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Immutable;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ImmutableQueueTests : MrwCollectionTests<ImmutableQueue<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ImmutableQueue<AvailabilitySetData> GetModelInstance()
            => ImmutableQueue<AvailabilitySetData>.Empty
                .Enqueue(ModelInstances.s_testAs_3375)
                .Enqueue(ModelInstances.s_testAs_3376);

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ImmutableQueue_AvailabilitySetData_Info? _immutableQueue_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(ImmutableQueue<AvailabilitySetData>) => _immutableQueue_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type)
                };
            }

            private class ImmutableQueue_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ImmutableQueue_AvailabilitySetData_Builder();

                private class ImmutableQueue_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private ImmutableQueue<AvailabilitySetData> _instance = ImmutableQueue<AvailabilitySetData>.Empty;

                    protected internal override void AddItem(object item, string? key = null)
                    {
                        _instance = _instance.Enqueue(AssertItem<AvailabilitySetData>(item));
                    }

                    protected internal override object GetBuilder() => _instance;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
