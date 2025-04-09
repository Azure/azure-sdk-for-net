// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class StackTests : MrwCollectionTests<Stack<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override string CollectionTypeName => "Stack<AvailabilitySetData>";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override bool IsRoundTripOrderDeterministic => false;

        protected override void CompareCollections(Stack<AvailabilitySetData> expected, Stack<AvailabilitySetData> actual, string format)
        {
            var newStack = new Stack<AvailabilitySetData>();
            foreach (var item in actual)
            {
                newStack.Push(item);
            }
            base.CompareCollections(expected, newStack, format);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override Stack<AvailabilitySetData> GetModelInstance()
            => new Stack<AvailabilitySetData>([ModelInstances.s_testAs_3376, ModelInstances.s_testAs_3375]);

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private Stack_AvailabilitySetData_Builder _stack_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(Stack<AvailabilitySetData>) => _stack_AvailabilitySetData_Builder ??= new(),
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

            private class Stack_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(Stack<AvailabilitySetData>);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => new Stack<AvailabilitySetData>();

                protected override void AddItem(object collection, object item)
                    => ((Stack<AvailabilitySetData>)collection).Push((AvailabilitySetData)item);
            }
        }
#nullable enable
    }
}
