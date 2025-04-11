// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ListOfCollectionTests : MrwCollectionTests<List<Collection<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override string CollectionTypeName => "List<Collection<AvailabilitySetData>>";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override List<Collection<AvailabilitySetData>> GetModelInstance()
        {
            return
            [
                new([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]),
                new([ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378])
            ];
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<CollectionTests.LocalContext> s_availabilitySetData_CollectionTests_LocalContext = new(() => new());

            private List_Collection_AvailabilitySetData_Builder _list_Collection_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(List<Collection<AvailabilitySetData>>) => _list_Collection_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_CollectionTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class List_Collection_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<Collection<AvailabilitySetData>>);

                protected override Type ItemType => typeof(Collection<AvailabilitySetData>);

                protected override object CreateInstance() => new List<Collection<AvailabilitySetData>>();

                protected override void AddItem(object collection, object item)
                    => ((List<Collection<AvailabilitySetData>>)collection).Add((Collection<AvailabilitySetData>)item);
            }
        }
#nullable enable
    }
}
