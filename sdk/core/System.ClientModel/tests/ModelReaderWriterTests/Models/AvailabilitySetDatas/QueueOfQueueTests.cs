// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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

            private Queue_Queue_AvailabilitySetData_Builder? _queue_Queue_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? modeBuilder)
            {
                modeBuilder = type switch
                {
                    Type t when t == typeof(Queue<Queue<AvailabilitySetData>>) => _queue_Queue_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return modeBuilder is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? modeBuilder))
                    return modeBuilder;
                if (s_availabilitySetData_QueueTests_LocalContext.Value.TryGetModelBuilder(type, out modeBuilder))
                    return modeBuilder;
                return null;
            }

            private class Queue_Queue_AvailabilitySetData_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new Queue<Queue<AvailabilitySetData>>();

                private Action<object, object, string?>? _addItem;
                protected override Action<object, object, string?>? AddItem
                    => _addItem ??= (collection, item, key) => AssertCollection<Queue<Queue<AvailabilitySetData>>>(collection).Enqueue(AssertItem<Queue<AvailabilitySetData>>(item));

                private Func<object>? _createElementInstance;
                protected override Func<object>? CreateElementInstance
                    => _createElementInstance ??= () => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();
            }
        }
    }
}
