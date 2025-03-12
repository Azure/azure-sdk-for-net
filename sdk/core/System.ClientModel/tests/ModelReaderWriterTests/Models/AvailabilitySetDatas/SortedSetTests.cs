// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class SortedSetTests : MrwCollectionTests<SortedSet<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override SortedSet<AvailabilitySetData> GetModelInstance()
            => new SortedSet<AvailabilitySetData>([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376], new AvailabilitySetDataComparer());

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
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private SortedSet_AvailabilitySetData_Builder? _sortedSet_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? modelInfo)
            {
                modelInfo = type switch
                {
                    Type t when t == typeof(SortedSet<AvailabilitySetData>) => _sortedSet_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return modelInfo is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? modelInfo))
                    return modelInfo;
                return null;
            }

            private class SortedSet_AvailabilitySetData_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new SortedSet<AvailabilitySetData>(new AvailabilitySetDataComparer());

                private Action<object, object, string?>? _addItem;
                protected override Action<object, object, string?>? AddItem
                    => _addItem ??= (collection, item, _) => AssertCollection<SortedSet<AvailabilitySetData>>(collection).Add(AssertItem<AvailabilitySetData>(item));

                private Func<object>? _createElementInstance;
                protected override Func<object>? CreateElementInstance
                    => _createElementInstance ??= () => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();
            }
        }
    }
}
