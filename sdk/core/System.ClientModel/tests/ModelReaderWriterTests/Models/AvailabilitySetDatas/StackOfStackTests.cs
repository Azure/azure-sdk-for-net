// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class StackOfStackTests : MrwCollectionTests<Stack<Stack<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override int ReverseLayerMask => 3;

        protected override Stack<Stack<AvailabilitySetData>> GetModelInstance()
        {
            return new Stack<Stack<AvailabilitySetData>>(
            [
                new Stack<AvailabilitySetData>([ModelInstances.s_testAs_3378, ModelInstances.s_testAs_3377]),
                new Stack<AvailabilitySetData>([ModelInstances.s_testAs_3376, ModelInstances.s_testAs_3375])
            ]);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<StackTests.LocalContext> s_availabilitySetData_StackTests_LocalContext = new(() => new());

            private Stack_Stack_AvailabilitySetData_Info? _stack_Stack_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Stack<Stack<AvailabilitySetData>>) => _stack_Stack_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type) ??
                         s_availabilitySetData_StackTests_LocalContext.Value.GetModelInfo(type)
                };
            }

            private class Stack_Stack_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Stack_Stack_AvailabilitySetData_Builder();

                private class Stack_Stack_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Stack<Stack<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Push(AssertItem<Stack<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
