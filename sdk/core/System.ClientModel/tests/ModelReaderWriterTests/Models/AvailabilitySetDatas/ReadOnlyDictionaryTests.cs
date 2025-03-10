// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ReadOnlyDictionaryTests : MrwCollectionTests<ReadOnlyDictionary<string, AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "Dictionary";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ReadOnlyDictionary<string, AvailabilitySetData> GetModelInstance()
            => new ReadOnlyDictionary<string, AvailabilitySetData>(
                new Dictionary<string, AvailabilitySetData>()
                {
                    { ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375 },
                    { ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376 }
                });

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ReadOnlyDictionary_AvailabilitySetData_Info? _readOnlyDictionary_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(ReadOnlyDictionary<string, AvailabilitySetData>) => _readOnlyDictionary_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type)
                };
            }

            private class ReadOnlyDictionary_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ReadOnlyDictionary_AvailabilitySetData_Builder();

                private class ReadOnlyDictionary_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Dictionary<string, AvailabilitySetData>> _instance = new(() => new());

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertKey(key), AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();

                    protected internal override object ToObject() => new ReadOnlyDictionary<string, AvailabilitySetData>(_instance.Value);
                }
            }
        }
    }
}
