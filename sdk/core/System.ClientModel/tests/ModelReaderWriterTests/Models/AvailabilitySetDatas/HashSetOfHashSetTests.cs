// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class HashSetOfHashSetTests : MrwCollectionTests<HashSet<HashSet<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override string CollectionTypeName => "HashSet<HashSet<AvailabilitySetData>>";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override HashSet<HashSet<AvailabilitySetData>> GetModelInstance()
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
            private static readonly Lazy<HashSetTests.LocalContext> s_availabilitySetData_HashSetTests_LocalContext = new(() => new());

            private HashSet_HashSet_AvailabilitySetData_Builder _hashSet_HashSet_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(HashSet<HashSet<AvailabilitySetData>>) => _hashSet_HashSet_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_HashSetTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class HashSet_HashSet_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(HashSet<HashSet<AvailabilitySetData>>);

                protected override Type ItemType => typeof(HashSet<AvailabilitySetData>);

                protected override object CreateInstance() => new HashSet<HashSet<AvailabilitySetData>>();

                protected override void AddItem(object collection, object item)
                    => ((HashSet<HashSet<AvailabilitySetData>>)collection).Add((HashSet<AvailabilitySetData>)item);
            }
        }
#nullable enable
    }
}
