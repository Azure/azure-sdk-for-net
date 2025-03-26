// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas;
using System.Collections.Generic;

namespace System.ClientModel.SourceGeneration.Tests
{
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
