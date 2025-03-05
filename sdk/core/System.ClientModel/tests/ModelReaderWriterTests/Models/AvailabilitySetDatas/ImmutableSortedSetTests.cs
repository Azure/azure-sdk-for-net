// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Immutable;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ImmutableSortedSetTests : MrwCollectionTests<ImmutableSortedSet<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ImmutableSortedSet<AvailabilitySetData> GetModelInstance()
            => ImmutableSortedSet<AvailabilitySetData>.Empty.WithComparer(new AvailabilitySetDataComparer())
                .Add(ModelInstances.s_testAs_3375)
                .Add(ModelInstances.s_testAs_3376);

        protected override void CompareCollections(ImmutableSortedSet<AvailabilitySetData> expected, ImmutableSortedSet<AvailabilitySetData> actual, string format)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Count, actual.Count);
            foreach (var actualItem in actual)
            {
                Assert.IsTrue(expected.TryGetValue(actualItem, out AvailabilitySetData? expectedItem));
                CompareModels(expectedItem, actualItem, format);
            }
        }

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ImmutableSortedSet_AvailabilitySetData_Info? _immutableSortedSet_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(ImmutableSortedSet<AvailabilitySetData>) => _immutableSortedSet_AvailabilitySetData_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type)
                };
            }

            private class ImmutableSortedSet_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ImmutableSortedSet_AvailabilitySetData_Builder();

                private class ImmutableSortedSet_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<ImmutableSortedSet<AvailabilitySetData>.Builder> _instance = new(()
                        => ImmutableSortedSet<AvailabilitySetData>.Empty.WithComparer(new AvailabilitySetDataComparer()).ToBuilder());

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();

                    protected internal override object ToObject() => _instance.Value.ToImmutable();
                }
            }
        }
    }
}
