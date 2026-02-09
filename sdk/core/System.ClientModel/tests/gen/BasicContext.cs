// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas;
using System.Collections.Generic;

namespace System.ClientModel.SourceGeneration.Tests
{
    [ModelReaderWriterBuildable(typeof(ReadOnlyMemory<JsonModel>))]
    [ModelReaderWriterBuildable(typeof(List<BaseModel>))]
    [ModelReaderWriterBuildable(typeof(List<SubNamespace.JsonModel>))]
    [ModelReaderWriterBuildable(typeof(Dictionary<string, SubNamespace.JsonModel>))]
    [ModelReaderWriterBuildable(typeof(SubNamespace.JsonModel[]))]
    [ModelReaderWriterBuildable(typeof(SubNamespace.JsonModel[,]))]
    [ModelReaderWriterBuildable(typeof(SubNamespace.JsonModel[][]))]
    [ModelReaderWriterBuildable(typeof(ReadOnlyMemory<SubNamespace.JsonModel>))]
    [ModelReaderWriterBuildable(typeof(List<SubNamespace.AvailabilitySetData>))]
    [ModelReaderWriterBuildable(typeof(PersistableModel))]
    [ModelReaderWriterBuildable(typeof(AvailabilitySetData))]
    [ModelReaderWriterBuildable(typeof(AvailabilitySetData[]))]
    [ModelReaderWriterBuildable(typeof(Dictionary<string, AvailabilitySetData>))]
    [ModelReaderWriterBuildable(typeof(AvailabilitySetData[][]))]
    [ModelReaderWriterBuildable(typeof(List<List<AvailabilitySetData>>))]
    [ModelReaderWriterBuildable(typeof(AvailabilitySetData[,]))]
    [ModelReaderWriterBuildable(typeof(ReadOnlyMemory<AvailabilitySetData>))]
#pragma warning disable TEST001
    [ModelReaderWriterBuildable(typeof(ExperimentalModel))]
#pragma warning restore TEST001
    public partial class BasicContext : ModelReaderWriterContext
    {
        partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
        {
            factories.Add(typeof(CustomCollectionTests.CustomCollection<AvailabilitySetData>), () => new CustomCollection_AvailabilitySetData_Builder());
        }

        private class CustomCollection_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(CustomCollectionTests.CustomCollection<AvailabilitySetData>);

            protected override Type ItemType => typeof(AvailabilitySetData);

            protected override object CreateInstance() => new CustomCollectionTests.CustomCollection<AvailabilitySetData>();

            protected override void AddItem(object collection, object? item)
                => ((CustomCollectionTests.CustomCollection<AvailabilitySetData>)collection).Add((AvailabilitySetData)item!);
        }
    }
}
