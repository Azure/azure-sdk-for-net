// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class DictionaryOfListTests : MrwCollectionTests<Dictionary<string, List<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override Dictionary<string, List<AvailabilitySetData>> GetModelInstance()
            => new()
            {
                { "list1", new([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]) },
                { "list2", new([ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378]) },
            };

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ListTests.LocalContext> s_availabilitySetData_ListTests_LocalContext = new(() => new());

            private Dictionary_String_List_AvailabilitySetData_Info? _dictionary_String_List_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Dictionary<string, List<AvailabilitySetData>>) => _dictionary_String_List_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type) ??
                            s_availabilitySetData_ListTests_LocalContext.Value.GetModelInfo(type)
                };
            }

            private class Dictionary_String_List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Dictionary_String_List_AvailabilitySetData_Builder();

                private class Dictionary_String_List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Dictionary<string, List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertKey(key), AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
