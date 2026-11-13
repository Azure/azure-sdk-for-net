// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only data transfer API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// An Azure Blob Storage data source/sink.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class AzureBlobDataTransferDataSourceSink : DataTransferDataSourceSink
{
    private BicepValue<string>? _containerName;
    private BicepValue<Uri>? _endpointUri;

    /// <summary>
    /// Gets or sets the container name.
    /// </summary>
    public BicepValue<string> ContainerName
    {
        get { Initialize(); return _containerName!; }
        set { Initialize(); _containerName!.Assign(value); }
    }

    /// <summary>
    /// Gets or sets the endpoint uri.
    /// </summary>
    public BicepValue<Uri> EndpointUri
    {
        get { Initialize(); return _endpointUri!; }
        set { Initialize(); _endpointUri!.Assign(value); }
    }

    /// <summary>
    /// Creates a new AzureBlobDataTransferDataSourceSink.
    /// </summary>
    public AzureBlobDataTransferDataSourceSink() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// AzureBlobDataTransferDataSourceSink.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("component", ["component"], defaultValue: "AzureBlobStorage");
        _containerName = DefineProperty<string>("ContainerName", ["containerName"]);
        _endpointUri = DefineProperty<Uri>("EndpointUri", ["endpointUrl"]);
    }
}
