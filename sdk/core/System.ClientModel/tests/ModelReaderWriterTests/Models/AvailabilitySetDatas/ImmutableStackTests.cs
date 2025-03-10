// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Immutable;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ImmutableStackTests : MrwCollectionTests<ImmutableStack<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override bool IsRoundTripOrderDeterministic => false;

        protected override void CompareCollections(ImmutableStack<AvailabilitySetData> expected, ImmutableStack<AvailabilitySetData> actual, string format)
        {
            var newImmutableStack = ImmutableStack<AvailabilitySetData>.Empty;
            foreach (var item in actual)
            {
                newImmutableStack = newImmutableStack.Push(item);
            }
            base.CompareCollections(expected, newImmutableStack, format);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ImmutableStack<AvailabilitySetData> GetModelInstance()
            => ImmutableStack<AvailabilitySetData>.Empty
                .Push(ModelInstances.s_testAs_3376)
                .Push(ModelInstances.s_testAs_3375);

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ImmutableStack_AvailabilitySetData_Info? _immutableStack_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(ImmutableStack<AvailabilitySetData>) => _immutableStack_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type)
                };
            }

            private class ImmutableStack_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ImmutableStack_AvailabilitySetData_Builder();

                private class ImmutableStack_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private ImmutableStack<AvailabilitySetData> _instance = ImmutableStack<AvailabilitySetData>.Empty;

                    protected internal override void AddItem(object item, string? key = null)
                    {
                        _instance = _instance.Push(AssertItem<AvailabilitySetData>(item));
                    }

                    protected internal override object GetBuilder() => _instance;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
