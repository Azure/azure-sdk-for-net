// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ReadOnlyDictionaryTests : MrwCollectionTests<ReadOnlyDictionary<string, AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "Dictionary";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ReadOnlyDictionary<string, AvailabilitySetData> GetModelInstance()
            => new ReadOnlyDictionary<string, AvailabilitySetData>(
                new Dictionary<string, AvailabilitySetData>()
                {
                    { ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375 },
                    { ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376 }
                });

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ReadOnlyDictionary_AvailabilitySetData_Builder? _readOnlyDictionary_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(ReadOnlyDictionary<string, AvailabilitySetData>) => _readOnlyDictionary_AvailabilitySetData_Builder ??= new(),
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

            private class ReadOnlyDictionary_AvailabilitySetData_Builder : ModelBuilder
            {
                protected override bool IsCollection => true;

                protected override object CreateInstance() => new Dictionary<string, AvailabilitySetData>();

                protected override void AddKeyValuePair(object collection, string key, object item)
                    => AssertCollection<Dictionary<string, AvailabilitySetData>>(collection).Add(key, AssertItem<AvailabilitySetData>(item));

                protected override object CreateElementInstance()
                    => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();

                protected override object ToCollection(object builder)
                    => new ReadOnlyDictionary<string, AvailabilitySetData>(AssertCollection<Dictionary<string, AvailabilitySetData>>(builder));
            }
        }
    }
}
