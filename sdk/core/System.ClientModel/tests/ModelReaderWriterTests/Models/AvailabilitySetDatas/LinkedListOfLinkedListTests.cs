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

        protected override string CollectionTypeName => "LinkedList<LinkedList<AvailabilitySetData>>";

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

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<LinkedListTests.LocalContext> s_availabilitySetData_LinkedListTests_LocalContext = new(() => new());

            private LinkedList_LinkedList_AvailabilitySetData_Builder _linkedList_LinkedList_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(LinkedList<LinkedList<AvailabilitySetData>>) => _linkedList_LinkedList_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_LinkedListTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class LinkedList_LinkedList_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(LinkedList<LinkedList<AvailabilitySetData>>);

                protected override Type ItemType => typeof(LinkedList<AvailabilitySetData>);

                protected override object CreateInstance() => new LinkedList<LinkedList<AvailabilitySetData>>();

                protected override void AddItem(object collection, object item)
                    => ((LinkedList<LinkedList<AvailabilitySetData>>)collection).AddLast((LinkedList<AvailabilitySetData>)item);
            }
        }
#nullable enable
    }
}
