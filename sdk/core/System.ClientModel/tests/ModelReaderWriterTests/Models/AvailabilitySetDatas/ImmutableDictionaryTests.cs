// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ImmutableDictionaryTests : MrwCollectionTests<ImmutableDictionary<string, AvailabilitySetData>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override bool IsWriteOrderDeterministic => false;

        protected override ImmutableDictionary<string, AvailabilitySetData> GetModelInstance()
            => ImmutableDictionary<string, AvailabilitySetData>.Empty
                .Add(ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375)
                .Add(ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376);

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ImmutableDictionary_AvailabilitySetData_Builder? _immutable_dictionary_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(ImmutableDictionary<string, AvailabilitySetData>) => _immutable_dictionary_AvailabilitySetData_Builder ??= new(),
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

            private class ImmutableDictionary_AvailabilitySetData_Builder : ModelBuilder
            {
                protected override bool IsCollection => true;

                protected override object CreateInstance() => ImmutableDictionary<string, AvailabilitySetData>.Empty.ToBuilder();

                protected override void AddKeyValuePair(object collection, string key, object item)
                    => AssertCollection<ImmutableDictionary<string, AvailabilitySetData>.Builder>(collection).Add(key, AssertItem<AvailabilitySetData>(item));

                protected override object CreateElementInstance()
                    => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();

                protected override object ToCollection(object builder)
                    => AssertCollection<ImmutableDictionary<string, AvailabilitySetData>.Builder>(builder).ToImmutable();
            }
        }
    }
}
