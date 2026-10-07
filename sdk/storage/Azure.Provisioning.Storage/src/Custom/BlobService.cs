// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
#if EXPERIMENTAL_PROVISIONING
using Azure.Storage.Blobs;
#endif

namespace Azure.Provisioning.Storage;

// TypeSpec does not emit the experimental IClientCreator integration; retain the shipped deployment-output client factory.
public partial class BlobService
#if EXPERIMENTAL_PROVISIONING
    : IClientCreator<BlobServiceClient, BlobClientOptions>
#endif
{
    public static partial class ResourceVersions
    {
        /// <summary>2024-01-01.</summary>
        public static readonly string V2024_01_01 = "2024-01-01";
        /// <summary>2023-05-01.</summary>
        public static readonly string V2023_05_01 = "2023-05-01";
        /// <summary>2023-04-01.</summary>
        public static readonly string V2023_04_01 = "2023-04-01";
        /// <summary>2023-01-01.</summary>
        public static readonly string V2023_01_01 = "2023-01-01";
        /// <summary>2022-09-01.</summary>
        public static readonly string V2022_09_01 = "2022-09-01";
        /// <summary>2022-05-01.</summary>
        public static readonly string V2022_05_01 = "2022-05-01";
        /// <summary>2021-09-01.</summary>
        public static readonly string V2021_09_01 = "2021-09-01";
        /// <summary>2021-08-01.</summary>
        public static readonly string V2021_08_01 = "2021-08-01";
        /// <summary>2021-06-01.</summary>
        public static readonly string V2021_06_01 = "2021-06-01";
        /// <summary>2021-05-01.</summary>
        public static readonly string V2021_05_01 = "2021-05-01";
        /// <summary>2021-04-01.</summary>
        public static readonly string V2021_04_01 = "2021-04-01";
        /// <summary>2021-02-01.</summary>
        public static readonly string V2021_02_01 = "2021-02-01";
        /// <summary>2021-01-01.</summary>
        public static readonly string V2021_01_01 = "2021-01-01";
        /// <summary>2019-06-01.</summary>
        public static readonly string V2019_06_01 = "2019-06-01";
        /// <summary>2019-04-01.</summary>
        public static readonly string V2019_04_01 = "2019-04-01";
        /// <summary>2018-11-01.</summary>
        public static readonly string V2018_11_01 = "2018-11-01";
        /// <summary>2018-07-01.</summary>
        public static readonly string V2018_07_01 = "2018-07-01";
        /// <summary>2018-02-01.</summary>
        public static readonly string V2018_02_01 = "2018-02-01";
        /// <summary>2017-10-01.</summary>
        public static readonly string V2017_10_01 = "2017-10-01";
        /// <summary>2017-06-01.</summary>
        public static readonly string V2017_06_01 = "2017-06-01";
        /// <summary>2016-12-01.</summary>
        public static readonly string V2016_12_01 = "2016-12-01";
        /// <summary>2016-05-01.</summary>
        public static readonly string V2016_05_01 = "2016-05-01";
    }

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
