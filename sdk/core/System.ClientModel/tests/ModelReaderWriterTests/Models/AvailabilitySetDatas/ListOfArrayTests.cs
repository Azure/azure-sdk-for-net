// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ListOfArrayTests : MrwCollectionTests<List<AvailabilitySetData[]>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "ListOfList";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override List<AvailabilitySetData[]> GetModelInstance()
        {
            return new List<AvailabilitySetData[]>([[ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376], [ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378]]);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ArrayTests.LocalContext> s_availabilitySetData_ArrayTests_LocalContext = new(() => new());

            private List_Array_AvailabilitySetData_Info? _list_array_AvailabilitySet_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(List<AvailabilitySetData[]>) => _list_array_AvailabilitySet_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type) ??
                         s_availabilitySetData_ArrayTests_LocalContext.Value.GetModelInfo(type)
                };
            }

            private class List_Array_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new List_Array_AvailabilitySetData_Builder();

                private class List_Array_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<AvailabilitySetData[]>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData[]>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
