// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class LinkedListOfLinkedListTests : MrwCollectionTests<LinkedList<LinkedList<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override LinkedList<LinkedList<AvailabilitySetData>> GetModelInstance()
        {
            return new(
            [
                new([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]),
                new([ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378])
            ]);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<LinkedListTests.LocalContext> s_availabilitySetData_LinkedListTests_LocalContext = new(() => new());

            private LinkedList_LinkedList_AvailabilitySetData_Info? _linkedList_LinkedList_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(LinkedList<LinkedList<AvailabilitySetData>>) => _linkedList_LinkedList_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type) ??
                         s_availabilitySetData_LinkedListTests_LocalContext.Value.GetModelInfo(type)
                };
            }

            private class LinkedList_LinkedList_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new LinkedList_LinkedList_AvailabilitySetData_Builder();

                private class LinkedList_LinkedList_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<LinkedList<LinkedList<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.AddLast(AssertItem<LinkedList<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
