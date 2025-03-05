// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ReadOnlyCollectionTests : MrwCollectionTests<ReadOnlyCollection<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ReadOnlyCollection<AvailabilitySetData> GetModelInstance()
            => new([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]);

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ReadOnlyCollection_AvailabilitySetData_Info? _readOnlyCollection_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(ReadOnlyCollection<AvailabilitySetData>) => _readOnlyCollection_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type)
                };
            }

            private class ReadOnlyCollection_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ReadOnlyCollection_AvailabilitySetData_Builder();

                private class ReadOnlyCollection_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<AvailabilitySetData>> _instance = new(() => new());

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();

                    protected internal override object ToObject() => _instance.Value.AsReadOnly();
                }
            }
        }
    }
}
