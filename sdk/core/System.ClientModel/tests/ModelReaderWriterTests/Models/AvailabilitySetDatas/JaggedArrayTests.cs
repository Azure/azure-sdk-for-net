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

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ArrayTests.LocalContext> s_availabilitySetData_ArrayTests_LocalContext = new(() => new());

            private Array_Array_AvailabilitySetData_Builder? _array_Array_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(AvailabilitySetData[][]) => _array_Array_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? builder))
                    return builder;
                if (s_availabilitySetData_ArrayTests_LocalContext.Value.TryGetModelBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class Array_Array_AvailabilitySetData_Builder : ModelBuilder
            {
                protected override bool IsCollection => true;

                protected override object CreateInstance() => new List<AvailabilitySetData[]>();

                protected override void AddItem(object collection, object item)
                    => AssertCollection<List<AvailabilitySetData[]>>(collection).Add(AssertItem<AvailabilitySetData[]>(item));

                protected override object CreateElementInstance()
                    => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();

                protected override object ToCollection(object builder)
                    => AssertCollection<List<AvailabilitySetData[]>>(builder).ToArray();
            }
        }
    }
}
