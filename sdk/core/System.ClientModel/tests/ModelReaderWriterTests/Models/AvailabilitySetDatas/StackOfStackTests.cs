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

        protected override string CollectionTypeName => "Stack<Stack<AvailabilitySetData>>";

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

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<StackTests.LocalContext> s_availabilitySetData_StackTests_LocalContext = new(() => new());

            private Stack_Stack_AvailabilitySetData_Builder _stack_Stack_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(Stack<Stack<AvailabilitySetData>>) => _stack_Stack_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_StackTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class Stack_Stack_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(Stack<Stack<AvailabilitySetData>>);

                protected override Type ItemType => typeof(Stack<AvailabilitySetData>);

                protected override object CreateInstance() => new Stack<Stack<AvailabilitySetData>>();

                protected override void AddItem(object collection, object item)
                    => ((Stack<Stack<AvailabilitySetData>>)collection).Push((Stack<AvailabilitySetData>)item);
            }
        }
#nullable enable
    }
}
