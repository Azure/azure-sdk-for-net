// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ReadOnlyMemoryTests : MrwCollectionTests<ReadOnlyMemory<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override ReadOnlyMemory<AvailabilitySetData> GetModelInstance()
            => new ReadOnlyMemory<AvailabilitySetData>([ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376]);

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ReadOnlyMemory_AvailabilitySetData_Builder? _readOnlyMemory_AvailabilitySetData_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? modelInfo)
            {
                modelInfo = type switch
                {
                    Type t when t == typeof(ReadOnlyMemory<AvailabilitySetData>) => _readOnlyMemory_AvailabilitySetData_Builder ??= new(),
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

            private class ReadOnlyMemory_AvailabilitySetData_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new List<AvailabilitySetData>();

                private Action<object, object, string?>? _addItem;
                protected override Action<object, object, string?>? AddItem
                    => _addItem ??= (collection, item, key) => AssertCollection<List<AvailabilitySetData>>(collection).Add(AssertItem<AvailabilitySetData>(item));

                private Func<object>? _createElementInstance;
                protected override Func<object>? CreateElementInstance
                    => _createElementInstance ??= () => s_libraryContext.Value.GetModelBuilder(typeof(AvailabilitySetData)).CreateObject();

                private Func<object, object>? _toCollection;
                protected override Func<object, object> ToCollection
                    => _toCollection ??= collection => new ReadOnlyMemory<AvailabilitySetData>([.. AssertCollection<List<AvailabilitySetData>>(collection)]);

                protected internal override IEnumerable? GetEnumerable(object obj)
                {
                    if (obj is ReadOnlyMemory<AvailabilitySetData> rom)
                    {
                        for (int i = 0; i < rom.Length; i++)
                        {
                            yield return rom.Span[i];
                        }
                    }
                    yield break;
                }
            }
        }
    }
}
