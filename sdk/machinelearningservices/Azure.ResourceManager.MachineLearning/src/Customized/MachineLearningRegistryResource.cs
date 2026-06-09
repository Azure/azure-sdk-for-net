// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve legacy operation names/signatures moved by the TypeSpec migration.
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
