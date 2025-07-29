// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using MgmtTypeSpec.Models;

namespace MgmtTypeSpec
{
    // This is temporary. In a near future, the generator will be able to generate all these attributes.
    [ModelReaderWriterBuildable(typeof(BarSettingsProperties))]
    [ModelReaderWriterBuildable(typeof(BarData))]
    [ModelReaderWriterBuildable(typeof(BarSettingsData))]
    [ModelReaderWriterBuildable(typeof(FooData))]
    [ModelReaderWriterBuildable(typeof(FooSettingsData))]
    [ModelReaderWriterBuildable(typeof(ZooData))]
    [ModelReaderWriterBuildable(typeof(BarListResult))]
    [ModelReaderWriterBuildable(typeof(BarProperties))]
    [ModelReaderWriterBuildable(typeof(FooListResult))]
    [ModelReaderWriterBuildable(typeof(FooProperties))]
    [ModelReaderWriterBuildable(typeof(FooSettingsPatch))]
    [ModelReaderWriterBuildable(typeof(FooSettingsProperties))]
    [ModelReaderWriterBuildable(typeof(FooSettingsUpdateProperties))]
    [ModelReaderWriterBuildable(typeof(PrivateLink))]
    [ModelReaderWriterBuildable(typeof(PrivateLinkListResult))]
    [ModelReaderWriterBuildable(typeof(PrivateLinkResourceProperties))]
    [ModelReaderWriterBuildable(typeof(ZooListResult))]
    [ModelReaderWriterBuildable(typeof(ZooPatch))]
    [ModelReaderWriterBuildable(typeof(ZooProperties))]
    [ModelReaderWriterBuildable(typeof(ZooUpdateProperties))]
    public partial class MgmtTypeSpecContext
    {
    }
}
