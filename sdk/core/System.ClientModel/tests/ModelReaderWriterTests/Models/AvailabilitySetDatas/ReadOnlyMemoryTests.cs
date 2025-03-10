// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ReadOnlyMemoryTests : MrwCollectionTests<ReadOnlyMemory<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ReadOnlyMemory<AvailabilitySetData> GetModelInstance()
            => new ReadOnlyMemory<AvailabilitySetData>([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]);

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ReadOnlyMemory_AvailabilitySetData_Info? _readOnlyMemory_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(ReadOnlyMemory<AvailabilitySetData>) => _readOnlyMemory_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type)
                };
            }

            private class ReadOnlyMemory_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ReadOnlyMemory_AvailabilitySetData_Builder();

                private class ReadOnlyMemory_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object ToObject() => new ReadOnlyMemory<AvailabilitySetData>([.. _instance.Value]);

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }

                public override IEnumerable? GetEnumerable(object obj)
                {
                    if (obj is ReadOnlyMemory<AvailabilitySetData> rom)
                    {
                        for (int i = 0; i < rom.Length; i++)
                        {
                            yield return rom.Span[i];
                        }
                    }
                    yield break;
                }
            }
        }
    }
}
