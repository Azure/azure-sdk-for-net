// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class JaggedArrayTests : MrwCollectionTests<AvailabilitySetData[][], AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override AvailabilitySetData[][] GetModelInstance()
            => new AvailabilitySetData[][]
            {
                new AvailabilitySetData[] { ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376 },
                new AvailabilitySetData[] { ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378 }
            };

#nullable disable
        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ArrayTests.LocalContext> s_availabilitySetData_ArrayTests_LocalContext = new(() => new());

            private Array_Array_AvailabilitySetData_Builder _array_Array_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(AvailabilitySetData[][]) => _array_Array_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_ArrayTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class Array_Array_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<AvailabilitySetData[]>);

                protected override Type ItemType => typeof(AvailabilitySetData[]);

                protected override bool IsCollection => true;

                protected override object CreateInstance() => new List<AvailabilitySetData[]>();

                protected override void AddItem(object collection, object item)
                    => ((List<AvailabilitySetData[]>)collection).Add((AvailabilitySetData[])item);

                protected override object ToCollection(object builder)
                    => ((List<AvailabilitySetData[]>)builder).ToArray();
            }
        }
#nullable enable
    }
}
