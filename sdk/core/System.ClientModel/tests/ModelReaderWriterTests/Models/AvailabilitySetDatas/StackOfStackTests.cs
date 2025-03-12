// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class StackOfStackTests : MrwCollectionTests<Stack<Stack<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override bool IsRoundTripOrderDeterministic => false;

        protected override Stack<Stack<AvailabilitySetData>> GetModelInstance()
        {
            return new Stack<Stack<AvailabilitySetData>>(
            [
                new Stack<AvailabilitySetData>([ModelInstances.s_testAs_3378, ModelInstances.s_testAs_3377]),
                new Stack<AvailabilitySetData>([ModelInstances.s_testAs_3376, ModelInstances.s_testAs_3375])
            ]);
        }

        protected override void CompareCollections(Stack<Stack<AvailabilitySetData>> expected, Stack<Stack<AvailabilitySetData>> actual, string format)
        {
            var newStack = new Stack<Stack<AvailabilitySetData>>();
            foreach (var item in actual)
            {
                var newInnerStack = new Stack<AvailabilitySetData>();
                foreach (var innerItem in item)
                {
                    newInnerStack.Push(innerItem);
                }
                newStack.Push(newInnerStack);
            }
            base.CompareCollections(expected, newStack, format);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<StackTests.LocalContext> s_availabilitySetData_StackTests_LocalContext = new(() => new());

            private Stack_Stack_AvailabilitySetData_Builder? _stack_Stack_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? modelInfo)
            {
                modelInfo = type switch
                {
                    Type t when t == typeof(Stack<Stack<AvailabilitySetData>>) => _stack_Stack_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return modelInfo is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? modelInfo))
                    return modelInfo;
                if (s_availabilitySetData_StackTests_LocalContext.Value.TryGetModelBuilder(type, out modelInfo))
                    return modelInfo;
                return null;
            }

            private class Stack_Stack_AvailabilitySetData_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new Stack<Stack<AvailabilitySetData>>();

                private Action<object, object, string?>? _addItem;
                protected override Action<object, object, string?>? AddItem
                    => _addItem ??= (collection, item, key) => AssertCollection<Stack<Stack<AvailabilitySetData>>>(collection).Push(AssertItem<Stack<AvailabilitySetData>>(item));

                private Func<object>? _createElementInstance;
                protected override Func<object>? CreateElementInstance
                    => _createElementInstance ??= () => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();
            }
        }
    }
}
