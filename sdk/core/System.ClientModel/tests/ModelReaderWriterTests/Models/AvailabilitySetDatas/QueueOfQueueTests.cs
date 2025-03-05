// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class QueueOfQueueTests : MrwCollectionTests<Queue<Queue<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override Queue<Queue<AvailabilitySetData>> GetModelInstance()
        {
            return new Queue<Queue<AvailabilitySetData>>(
            [
                new Queue<AvailabilitySetData>([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]),
                new Queue<AvailabilitySetData>([ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378])
            ]);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<QueueTests.LocalContext> s_availabilitySetData_QueueTests_LocalContext = new(() => new());

            private Queue_Queue_AvailabilitySetData_Info? _queue_Queue_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Queue<Queue<AvailabilitySetData>>) => _queue_Queue_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type) ??
                         s_availabilitySetData_QueueTests_LocalContext.Value.GetModelInfo(type)
                };
            }

            private class Queue_Queue_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Queue_Queue_AvailabilitySetData_Builder();

                private class Queue_Queue_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Queue<Queue<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Enqueue(AssertItem<Queue<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
