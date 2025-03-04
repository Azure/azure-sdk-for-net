// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    public class StackOfAvailabilitySetDataTests : CollectionTests<Stack<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonFolderName() => "ListOfAvailabilitySetData";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void Reverse(ref Stack<AvailabilitySetData> collection, ref IEnumerable enumerable)
        {
            Stack<AvailabilitySetData> newStack = new Stack<AvailabilitySetData>();
            var reverseEnumerator = enumerable.GetEnumerator();
            while (reverseEnumerator.MoveNext())
            {
                newStack.Push((AvailabilitySetData)reverseEnumerator.Current);
            }
            collection = newStack;
            enumerable = GetEnumerable(collection);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override Stack<AvailabilitySetData> GetModelInstance()
            => new Stack<AvailabilitySetData>([ListOfAvailabilitySetDataTests.s_testAs_3376, ListOfAvailabilitySetDataTests.s_testAs_3375]);

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_LibraryContext = new(() => new());
            private Stack_AvailabilitySetData_Info? _stack_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Stack<AvailabilitySetData>) => _stack_AvailabilitySetData_Info ??= new(),
                    _ => s_LibraryContext.Value.GetModelInfo(type)
                };
            }

            private class Stack_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Stack_AvailabilitySetData_Builder();

                private class Stack_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Stack<AvailabilitySetData>> _instance = new(() => new());

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Push(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
