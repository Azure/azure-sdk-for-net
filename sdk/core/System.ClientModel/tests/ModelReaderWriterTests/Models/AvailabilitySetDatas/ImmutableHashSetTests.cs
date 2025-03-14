// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ImmutableHashSetTests : MrwCollectionTests<ImmutableHashSet<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override bool IsWriteOrderDeterministic => false;

        protected override bool IsRoundTripOrderDeterministic => false;

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ImmutableHashSet<AvailabilitySetData> GetModelInstance()
            => ImmutableHashSet<AvailabilitySetData>.Empty.WithComparer(new AvailabilitySetDataComparer())
                .Add(ModelInstances.s_testAs_3375)
                .Add(ModelInstances.s_testAs_3376);

        protected override void CompareCollections(ImmutableHashSet<AvailabilitySetData> expected, ImmutableHashSet<AvailabilitySetData> actual, string format)
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
            private ImmutableHashSet_AvailabilitySetData_Builder? _immutableHashSet_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(ImmutableHashSet<AvailabilitySetData>) => _immutableHashSet_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? builder))
                    return builder;
                return null;
            }

            private class ImmutableHashSet_AvailabilitySetData_Builder : ModelBuilder
            {
                protected override bool IsCollection => true;

                protected override object CreateInstance() => ImmutableHashSet<AvailabilitySetData>.Empty.ToBuilder();

                protected override void AddItem(object collection, object item)
                    => AssertCollection<ImmutableHashSet<AvailabilitySetData>.Builder>(collection).Add(AssertItem<AvailabilitySetData>(item));

                protected override object CreateElementInstance()
                    => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();

                protected override object ToCollection(object builder)
                    => AssertCollection<ImmutableHashSet<AvailabilitySetData>.Builder>(builder).ToImmutable();
            }
        }
    }
}
