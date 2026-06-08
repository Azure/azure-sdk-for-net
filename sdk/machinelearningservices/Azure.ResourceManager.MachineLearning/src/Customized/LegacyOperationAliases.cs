// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat operation aliases are grouped to keep related shims together.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve legacy operation names/signatures moved by the TypeSpec migration.
    public partial class MachineLearningDatastoreResource
    {
        /// <summary> Lists datastore secrets. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<MachineLearningDatastoreSecrets>> GetSecretsAsync(CancellationToken cancellationToken)
            => GetSecretsAsync(default(SecretExpiry), cancellationToken);

        /// <summary> Lists datastore secrets. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<MachineLearningDatastoreSecrets> GetSecrets(CancellationToken cancellationToken)
            => GetSecrets(default(SecretExpiry), cancellationToken);
    }

    // Customized: preserve the old verbose registry data reference SAS method name.
    public partial class MachineLearningRegistryResource
    {
        /// <summary> Gets a blob reference SAS URI. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BlobReferenceSasResult>> GetBlobReferenceSasRegistryDataReferenceAsync(string name, string version, BlobReferenceSasContent content, CancellationToken cancellationToken)
            => GetBlobReferenceSASAsync(name, version, content, cancellationToken);

        /// <summary> Gets a blob reference SAS URI. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobReferenceSasResult> GetBlobReferenceSasRegistryDataReference(string name, string version, BlobReferenceSasContent content, CancellationToken cancellationToken)
            => GetBlobReferenceSAS(name, version, content, cancellationToken);
    }
}

#pragma warning restore SA1402
