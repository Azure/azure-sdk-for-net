// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class LinkedListTests : MrwCollectionTests<LinkedList<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override string CollectionTypeName => "LinkedList<AvailabilitySetData>";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override LinkedList<AvailabilitySetData> GetModelInstance()
            => new LinkedList<AvailabilitySetData>([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]);

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private LinkedList_AvailabilitySetData_Builder _linkedList_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(LinkedList<AvailabilitySetData>) => _linkedList_AvailabilitySetData_Builder ??= new(),
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

            private class LinkedList_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(LinkedList<AvailabilitySetData>);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => new LinkedList<AvailabilitySetData>();

                protected override void AddItem(object collection, object item)
                    => ((LinkedList<AvailabilitySetData>)collection).AddLast((AvailabilitySetData)item);
            }
        }
#nullable enable
    }
}
