// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class MultiDimensionalArrayTests : MrwCollectionTests<AvailabilitySetData[,], AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override AvailabilitySetData[,] GetModelInstance()
            => new AvailabilitySetData[,] { { ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376 }, { ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378 } };

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ListTests.LocalContext> s_availabilitySetData_ListTests_LocalContext = new(() => new());

            private ArrayOfArray_AvailabilitySetData_Builder? _arrayOfArray_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(AvailabilitySetData[,]) => _arrayOfArray_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? builder))
                    return builder;
                if (s_availabilitySetData_ListTests_LocalContext.Value.TryGetModelBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class ArrayOfArray_AvailabilitySetData_Builder : ModelBuilder
            {
                protected override bool IsCollection => true;

                protected override object CreateInstance() => new List<List<AvailabilitySetData>>();

                protected override void AddItem(object collection, object item)
                    => AssertCollection<List<List<AvailabilitySetData>>>(collection).Add(AssertItem<List<AvailabilitySetData>>(item));

                protected override object CreateElementInstance()
                    => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();

                protected override object ToCollection(object builder)
                {
                    var instance = AssertCollection<List<List<AvailabilitySetData>>>(builder);
                    int rowCount = instance.Count;
                    int colCount = instance[0].Count;
                    AvailabilitySetData[,] multiArray = new AvailabilitySetData[rowCount, colCount];

                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < colCount; j++)
                        {
                            multiArray[i, j] = instance[i][j];
                        }
                    }
                    return multiArray;
                }
            }
        }
    }
}
