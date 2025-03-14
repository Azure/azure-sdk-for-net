// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

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
            private ReadOnlyCollection_AvailabilitySetData_Builder? _readOnlyCollection_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(ReadOnlyCollection<AvailabilitySetData>) => _readOnlyCollection_AvailabilitySetData_Builder ??= new(),
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

            private class ReadOnlyCollection_AvailabilitySetData_Builder : ModelBuilder
            {
                protected override bool IsCollection => true;

                protected override object CreateInstance() => new List<AvailabilitySetData>();

                protected override void AddItem(object collection, object item)
                    => AssertCollection<List<AvailabilitySetData>>(collection).Add(AssertItem<AvailabilitySetData>(item));

                protected override object CreateElementInstance()
                    => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();

                protected override object ToCollection(object builder)
                    => AssertCollection<List<AvailabilitySetData>>(builder).AsReadOnly();
            }
        }
    }
}
