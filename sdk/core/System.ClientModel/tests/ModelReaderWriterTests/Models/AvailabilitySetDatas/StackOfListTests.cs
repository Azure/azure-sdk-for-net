// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class StackOfListTests : MrwCollectionTests<Stack<List<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override string CollectionTypeName => "Stack<List<AvailabilitySetData>>";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override bool IsRoundTripOrderDeterministic => false;

        protected override Stack<List<AvailabilitySetData>> GetModelInstance()
        {
            return new Stack<List<AvailabilitySetData>>(
            [
                new([ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378]),
                new([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376])
            ]);
        }

        protected override void CompareCollections(Stack<List<AvailabilitySetData>> expected, Stack<List<AvailabilitySetData>> actual, string format)
        {
            var newStack = new Stack<List<AvailabilitySetData>>();
            foreach (var item in actual)
            {
                newStack.Push(item);
            }
            base.CompareCollections(expected, newStack, format);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ListTests.LocalContext> s_availabilitySetData_ListTests_LocalContext = new(() => new());

            private Stack_List_AvailabilitySetData_Builder _stack_List_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(Stack<List<AvailabilitySetData>>) => _stack_List_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_ListTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class Stack_List_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(Stack<List<AvailabilitySetData>>);

                protected override Type ItemType => typeof(List<AvailabilitySetData>);

                protected override object CreateInstance() => new Stack<List<AvailabilitySetData>>();

                protected override void AddItem(object collection, object item)
                    => ((Stack<List<AvailabilitySetData>>)collection).Push((List<AvailabilitySetData>)item);
            }
        }
#nullable enable
    }
}
