// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class TestModelReaderWriterContext : ModelReaderWriterContext
    {
        private AvailabilitySetData_Info? _availabilitySetDataInfo;
        private List_AvailabilitySetData_Info? _list_AvailabilitySet_Info;

        public override ModelInfo? GetModelInfo(Type type)
        {
            return type switch
            {
                Type t when t == typeof(AvailabilitySetData) => _availabilitySetDataInfo ??= new(),
                Type t when t == typeof(List<AvailabilitySetData>) => _list_AvailabilitySet_Info ??= new(),
                _ => null
            };
        }

        private class List_AvailabilitySetData_Info : ModelInfo
        {
            public override object CreateObject() => new List_AvailabilitySetData_Builder();

            private class List_AvailabilitySetData_Builder : CollectionBuilder
            {
                private readonly Lazy<List<AvailabilitySetData>> _instance = new(() => []);

                protected override void AddItem(object item, string? key = null)
                {
                    _instance.Value.Add(AssertItem<AvailabilitySetData>(item));
                }

                protected override object GetBuilder() => _instance.Value;

                protected override object GetElement() => new AvailabilitySetData();
            }
        }

        private class AvailabilitySetData_Info : ModelInfo
        {
            public override object CreateObject() => new AvailabilitySetData();
        }
    }
}
