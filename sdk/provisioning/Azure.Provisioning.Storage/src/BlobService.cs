// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Storage.Blobs;

namespace Azure.Provisioning.Storage;

// Customize the generated BlobService resource.
public partial class BlobService
    : IClientCreator<BlobServiceClient, BlobClientOptions>
{
    /// <summary>
    /// Get the default value for the Name property.
    /// </summary>
    private partial BicepValue<string> GetNameDefaultValue() =>
        new StringLiteral("default");

    /// <summary>
    /// Create a <see cref="BlobServiceClient"/> after deploying a
    /// <see cref="BlobService"/> resource.
    /// </summary>
    /// <param name="deployment">The deployment for this resource.</param>
    /// <param name="credential">A credential to use for creating the client.</param>
    /// <param name="options">
    /// Optional <see cref="BlobClientOptions"/> to use for configuring the
    /// <see cref="BlobServiceClient"/>.
    /// </param>
    /// <returns>
    /// A <see cref="BlobServiceClient"/> client for the provisioned
    /// <see cref="BlobService"/> resource.
    /// </returns>
    BlobServiceClient IClientCreator<BlobServiceClient, BlobClientOptions>.CreateClient(
        ProvisioningDeployment deployment,
        TokenCredential credential,
        BlobClientOptions? options)
    {
        string endpoint = deployment.GetClientCreationOutput<string>(this, "endpoint");
        return new BlobServiceClient(new Uri(endpoint), credential, options);
    }
}
