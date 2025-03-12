// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class DictionaryOfListTests : MrwCollectionTests<Dictionary<string, List<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override Dictionary<string, List<AvailabilitySetData>> GetModelInstance()
            => new()
            {
                { "list1", new([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]) },
                { "list2", new([ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378]) },
            };

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ListTests.LocalContext> s_availabilitySetData_ListTests_LocalContext = new(() => new());

            private Dictionary_String_List_AvailabilitySetData_Builder? _dictionary_String_List_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? modeBuilder)
            {
                modeBuilder = type switch
                {
                    Type t when t == typeof(Dictionary<string, List<AvailabilitySetData>>) => _dictionary_String_List_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return modeBuilder is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? modeBuilder))
                    return modeBuilder;
                if (s_availabilitySetData_ListTests_LocalContext.Value.TryGetModelBuilder(type, out modeBuilder))
                    return modeBuilder;
                return null;
            }

            private class Dictionary_String_List_AvailabilitySetData_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new Dictionary<string, List<AvailabilitySetData>>();

                private Action<object, object, string?>? _addItem;
                protected override Action<object, object, string?>? AddItem
                    => _addItem ??= (collection, item, key) => AssertCollection<Dictionary<string, List<AvailabilitySetData>>>(collection).Add(AssertKey(key), AssertItem<List<AvailabilitySetData>>(item));

                private Func<object>? _createElementInstance;
                protected override Func<object>? CreateElementInstance
                    => _createElementInstance ??= () => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();
            }
        }
    }
}
