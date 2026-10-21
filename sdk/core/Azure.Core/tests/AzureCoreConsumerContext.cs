// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Core.Tests
{
    [ModelReaderWriterBuildable(typeof(GeoPoint))]
    [ModelReaderWriterBuildable(typeof(GeoPoint[]))]
    [ModelReaderWriterBuildable(typeof(List<GeoPoint>))]
    [ModelReaderWriterBuildable(typeof(Dictionary<string, GeoPoint>))]
    internal partial class AzureCoreConsumerContext : ModelReaderWriterContext
    {
    }
}
