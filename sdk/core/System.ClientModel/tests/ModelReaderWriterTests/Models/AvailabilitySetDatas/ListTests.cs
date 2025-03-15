// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ListTests : MrwCollectionTests<List<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override List<AvailabilitySetData> GetModelInstance()
        {
            return [ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376];
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private List_AvailabilitySetData_Builder _list_AvailabilitySet_Builder;

            protected override bool TryGetModelBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(List<AvailabilitySetData>) => _list_AvailabilitySet_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                return null;
            }

            private class List_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<AvailabilitySetData>);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override bool IsCollection => true;

                protected override object CreateInstance() => new List<AvailabilitySetData>();

                protected override void AddItem(object collection, object item)
                    => ((List<AvailabilitySetData>)collection).Add((AvailabilitySetData)item);
            }
        }
#nullable enable
    }
}
