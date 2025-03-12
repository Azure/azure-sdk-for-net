// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class StackTests : MrwCollectionTests<Stack<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

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

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private Stack_AvailabilitySetData_Builder? _stack_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(Stack<AvailabilitySetData>) => _stack_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? builder))
                    return builder;
                return null;
            }

            private class Stack_AvailabilitySetData_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new Stack<AvailabilitySetData>();

                private Action<object, object, string?>? _addItem;
                protected override Action<object, object, string?>? AddItem
                    => _addItem ??= (collection, item, key) => AssertCollection<Stack<AvailabilitySetData>>(collection).Push(AssertItem<AvailabilitySetData>(item));

                private Func<object>? _createElementInstance;
                protected override Func<object>? CreateElementInstance
                    => _createElementInstance ??= () => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();
            }
        }
    }
}
