// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class AzureBlobDataTransferDataSourceSink : DataTransferDataSourceSink
{
    private BicepValue<string>? _containerName;
    private BicepValue<Uri>? _endpointUri;

    public BicepValue<string> ContainerName
    {
        get { Initialize(); return _containerName!; }
        set { Initialize(); _containerName!.Assign(value); }
    }

    public BicepValue<Uri> EndpointUri
    {
        get { Initialize(); return _endpointUri!; }
        set { Initialize(); _endpointUri!.Assign(value); }
    }

    public AzureBlobDataTransferDataSourceSink() : base()
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("component", ["component"], defaultValue: "AzureBlobStorage");
        _containerName = DefineProperty<string>("ContainerName", ["containerName"]);
        _endpointUri = DefineProperty<Uri>("EndpointUri", ["endpointUrl"]);
    }
}
