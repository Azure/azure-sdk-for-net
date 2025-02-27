// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class TestModelReaderWriterContext : ModelReaderWriterContext
    {
        public override ModelInfo? GetModelInfo(Type type)
        {
            return type switch
            {
                Type t when t == typeof(AvailabilitySetData) => new AvailabilitySetDataInfo(),
                Type t when t == typeof(List<AvailabilitySetData>) => new List_AvailabilitySetDataInfo(),
                _ => null
            };
        }

        private class List_AvailabilitySetDataInfo : ModelInfo
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
            }
        }

        private class AvailabilitySetDataInfo : ModelInfo
        {
            public override object CreateObject() => new AvailabilitySetData();
        }
    }
}
