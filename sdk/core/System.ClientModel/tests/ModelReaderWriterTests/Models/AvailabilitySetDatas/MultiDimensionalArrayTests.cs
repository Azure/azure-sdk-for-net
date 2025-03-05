// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

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

            private ArrayOfArray_AvailabilitySetData_Info? _arrayOfArray_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(AvailabilitySetData[,]) => _arrayOfArray_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type) ??
                         s_availabilitySetData_ListTests_LocalContext.Value.GetModelInfo(type)
                };
            }

            private class ArrayOfArray_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ArrayOfArray_AvailabilitySetData_Builder();

                private class ArrayOfArray_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object ToObject()
                    {
                        int rowCount = _instance.Value.Count;
                        int colCount = _instance.Value[0].Count;
                        AvailabilitySetData[,] multiArray = new AvailabilitySetData[rowCount, colCount];

                        for (int i = 0; i < rowCount; i++)
                        {
                            for (int j = 0; j < colCount; j++)
                            {
                                multiArray[i, j] = _instance.Value[i][j];
                            }
                        }
                        return multiArray;
                    }

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
