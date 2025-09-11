// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
#if EXPERIMENTAL_PROVISIONING
using Azure.Storage.Blobs;
#endif

namespace Azure.Provisioning.Storage;

// Customize the generated BlobService resource.
public partial class BlobService
#if EXPERIMENTAL_PROVISIONING
    : IClientCreator<BlobServiceClient, BlobClientOptions>
#endif
{
    /// <summary>
    /// Get the default value for the Name property.
    /// </summary>
    private partial BicepValue<string> GetNameDefaultValue() =>
        new StringLiteralExpression("default");

#if EXPERIMENTAL_PROVISIONING
    /// <inheritdoc/>
    IEnumerable<ProvisioningOutput> IClientCreator.GetOutputs()
    {
        yield return new ProvisioningOutput($"{BicepIdentifier}_endpoint", typeof(string))
        {
            Value = Parent!.PrimaryEndpoints.Value!.BlobUri
        };
    }

    /// <summary>
    /// Create a <see cref="BlobServiceClient"/> after deploying a
    /// <see cref="BlobService"/> resource.
    /// </summary>
    /// <param name="deploymentOutputs">The deployment outputs.</param>
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
        IReadOnlyDictionary<string, object?> deploymentOutputs,
        TokenCredential credential,
        BlobClientOptions? options)
    {
        // TODO: Move into a shared helper off ProvCtx's namescoping
        string qualifiedName = $"{BicepIdentifier}_endpoint";
        string endpoint = (deploymentOutputs.TryGetValue(qualifiedName, out object? raw) && raw is string value) ?
            value :
            throw new InvalidOperationException($"Could not find output value {qualifiedName} to construct {GetType().Name} resource {BicepIdentifier}.");
        return new BlobServiceClient(new Uri(endpoint), credential, options);
    }
#endif
}
