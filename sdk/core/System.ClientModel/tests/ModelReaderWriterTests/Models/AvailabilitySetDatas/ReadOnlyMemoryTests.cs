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

#nullable disable
        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private ReadOnlyMemory_AvailabilitySetData_Builder _readOnlyMemory_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(ReadOnlyMemory<AvailabilitySetData>) => _readOnlyMemory_AvailabilitySetData_Builder ??= new(),
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

            private class ReadOnlyMemory_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<AvailabilitySetData>);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override bool IsCollection => true;

                protected override object CreateInstance() => new List<AvailabilitySetData>();

                protected override void AddItem(object collection, object item)
                    => ((List<AvailabilitySetData>)collection).Add((AvailabilitySetData)item);

                protected override object ToCollection(object builder)
                    => new ReadOnlyMemory<AvailabilitySetData>([.. (List<AvailabilitySetData>)builder]);

                protected internal override IEnumerable GetItems(object obj)
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
#nullable enable
    }
}
