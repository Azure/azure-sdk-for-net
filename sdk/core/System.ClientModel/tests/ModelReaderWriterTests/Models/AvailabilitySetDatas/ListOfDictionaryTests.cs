// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ListOfDictionaryTests : MrwCollectionTests<List<Dictionary<string, AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override List<Dictionary<string, AvailabilitySetData>> GetModelInstance()
            =>
            [
                new(){ { ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375 }, { ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376 } },
                new(){ { ModelInstances.s_testAs_3377.Name!, ModelInstances.s_testAs_3377 }, { ModelInstances.s_testAs_3378.Name!, ModelInstances.s_testAs_3378 } },
            ];

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<DictionaryTests.LocalContext> s_availabilitySetData_DictionaryTests_LocalContext = new(() => new());

            private List_Dictionary_String_AvailabilitySetData_Info? _list_Dictionary_String_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(List<Dictionary<string, AvailabilitySetData>>) => _list_Dictionary_String_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type) ??
                            s_availabilitySetData_DictionaryTests_LocalContext.Value.GetModelInfo(type)
                };
            }

            private class List_Dictionary_String_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new List_Dictionary_String_AvailabilitySetData_Builder();

                private class List_Dictionary_String_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<Dictionary<string, AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<Dictionary<string, AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
