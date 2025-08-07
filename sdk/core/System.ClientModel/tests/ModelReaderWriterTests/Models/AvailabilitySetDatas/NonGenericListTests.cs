// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using static System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas.NonGenericListTests;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class NonGenericListTests : MrwCollectionTests<CustomCollection, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override string CollectionTypeName => "CustomCollection";

        public class CustomCollection : List<AvailabilitySetData> { }

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override CustomCollection GetModelInstance()
        {
            return [ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376];
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private CustomCollection_AvailabilitySetData_Builder _customCollection_AvailabilitySet_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(CustomCollection) => _customCollection_AvailabilitySet_Builder ??= new(),
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

            private class CustomCollection_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(CustomCollection);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => new CustomCollection();

                protected override void AddItem(object collection, object item)
                    => ((CustomCollection)collection).Add((AvailabilitySetData)item);
            }
        }
#nullable enable
    }
}
