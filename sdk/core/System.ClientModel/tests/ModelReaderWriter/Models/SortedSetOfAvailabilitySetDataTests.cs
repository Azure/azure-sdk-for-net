// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    public class SortedSetOfAvailabilitySetDataTests : CollectionTests<SortedSet<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonFolderName() => "ListOfAvailabilitySetData";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override SortedSet<AvailabilitySetData> GetModelInstance()
            => new SortedSet<AvailabilitySetData>([ListOfAvailabilitySetDataTests.s_testAs_3375, ListOfAvailabilitySetDataTests.s_testAs_3376], new AvailabilitySetDataComparer());

        private class AvailabilitySetDataComparer : IComparer<AvailabilitySetData>
        {
            public int Compare(AvailabilitySetData? x, AvailabilitySetData? y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                else if (x == null)
                {
                    return -1;
                }
                else if (y == null)
                {
                    return 1;
                }
                else
                {
                    var idCompare = string.Compare(x.Id, y.Id);
                    if (idCompare != 0)
                        return idCompare;

                    if (x.PlatformUpdateDomainCount > y.PlatformUpdateDomainCount)
                        return 1;

                    if (x.PlatformUpdateDomainCount < y.PlatformUpdateDomainCount)
                        return -1;

                    return 0;
                }
            }
        }

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_LibraryContext = new(() => new());
            private SortedSet_AvailabilitySetData_Info? _sortedSet_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(SortedSet<AvailabilitySetData>) => _sortedSet_AvailabilitySetData_Info ??= new(),
                    _ => s_LibraryContext.Value.GetModelInfo(type)
                };
            }

            private class SortedSet_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new SortedSet_AvailabilitySetData_Builder();

                private class SortedSet_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<SortedSet<AvailabilitySetData>> _instance = new(() => new(new AvailabilitySetDataComparer()));

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }
    }
}
