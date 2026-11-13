// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class SortedSetTests : MrwCollectionTests<SortedSet<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override bool HasReflectionBuilderSupport => false;

        protected override string CollectionTypeName => "SortedSet<AvailabilitySetData>";

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

#nullable disable
        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private SortedSet_AvailabilitySetData_Builder _sortedSet_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(SortedSet<AvailabilitySetData>) => _sortedSet_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                return null;
            }

            private class SortedSet_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(SortedSet<AvailabilitySetData>);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => new SortedSet<AvailabilitySetData>(new AvailabilitySetDataComparer());

                protected override void AddItem(object collection, object item)
                    => ((SortedSet<AvailabilitySetData>)collection).Add((AvailabilitySetData)item);
            }
        }
#nullable enable
    }
}
