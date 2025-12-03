// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using static System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas.CustomCollectionTests;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ListOfCustomCollectionTests : MrwCollectionTests<List<CustomCollection<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override bool HasReflectionBuilderSupport => false;

        protected override string CollectionTypeName => "List<CustomCollection<AvailabilitySetData>>";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override List<CustomCollection<AvailabilitySetData>> GetModelInstance()
        {
            return [[ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376], [ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378]];
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<CustomCollectionTests.LocalContext> s_availabilitySetData_CustomCollectionTests_LocalContext = new(() => new());

            private List_CustomCollection_AvailabilitySetData_Builder _list_customCollection_AvailabilitySet_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(List<CustomCollection<AvailabilitySetData>>) => _list_customCollection_AvailabilitySet_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_CustomCollectionTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class List_CustomCollection_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<CustomCollection<AvailabilitySetData>>);

                protected override Type ItemType => typeof(CustomCollection<AvailabilitySetData>);

                protected override object CreateInstance() => new List<CustomCollection<AvailabilitySetData>>();

                protected override void AddItem(object collection, object item)
                    => ((List<CustomCollection<AvailabilitySetData>>)collection).Add((CustomCollection<AvailabilitySetData>)item);
            }
        }
#nullable enable
    }
}
