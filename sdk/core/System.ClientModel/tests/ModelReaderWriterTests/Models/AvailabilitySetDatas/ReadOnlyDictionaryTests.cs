﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ReadOnlyDictionaryTests : MrwCollectionTests<ReadOnlyDictionary<string, AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "Dictionary";

        protected override string CollectionTypeName => "ReadOnlyDictionary<String, AvailabilitySetData>";

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

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ReadOnlyDictionary_AvailabilitySetData_Builder _readOnlyDictionary_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(ReadOnlyDictionary<string, AvailabilitySetData>) => _readOnlyDictionary_AvailabilitySetData_Builder ??= new(),
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

            private class ReadOnlyDictionary_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(Dictionary<string, AvailabilitySetData>);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => new Dictionary<string, AvailabilitySetData>();

                protected override void AddItemWithKey(object collection, string key, object item)
                    => ((Dictionary<string, AvailabilitySetData>)collection).Add(key, (AvailabilitySetData)item);

                protected override object ConvertCollectionBuilder(object builder)
                    => new ReadOnlyDictionary<string, AvailabilitySetData>((Dictionary<string, AvailabilitySetData>)builder);
            }
        }
#nullable enable
    }
}
