// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
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

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? modeBuilder)
            {
                modeBuilder = type switch
                {
                    Type t when t == typeof(ImmutableDictionary<string, AvailabilitySetData>) => _immutable_dictionary_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return modeBuilder is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? modeBuilder))
                    return modeBuilder;
                return null;
            }

            private class ImmutableDictionary_AvailabilitySetData_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= ImmutableDictionary<string, AvailabilitySetData>.Empty.ToBuilder;

                private Action<object, object, string?>? _addItem;
                protected override Action<object, object, string?>? AddItem
                    => _addItem ??= (collection, item, key) => AssertCollection<ImmutableDictionary<string, AvailabilitySetData>.Builder>(collection)
                    .Add(AssertKey(key), AssertItem<AvailabilitySetData>(item));

                private Func<object>? _createElementInstance;
                protected override Func<object>? CreateElementInstance
                    => _createElementInstance ??= () => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();

                private Func<object, object>? _toCollection;
                protected override Func<object, object> ToCollection
                    => _toCollection ??= collection => AssertCollection<ImmutableDictionary<string, AvailabilitySetData>.Builder>(collection).ToImmutable();
            }
        }
    }
}
