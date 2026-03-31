// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerInstance
{
    // Backward-compat stub: ContainerGroupProfileRevisionCollection was removed in TypeSpec migration.
    // Revisions are now accessed through CGProfileResource.GetAllRevisions().
    /// <summary> A class representing the ContainerGroupProfileRevision collection. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupProfileRevisionCollection : ArmCollection,
        IEnumerable<ContainerGroupProfileRevisionResource>,
        IAsyncEnumerable<ContainerGroupProfileRevisionResource>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileRevisionCollection"/>. </summary>
        protected ContainerGroupProfileRevisionCollection()
        {
        }

        IEnumerator<ContainerGroupProfileRevisionResource> IEnumerable<ContainerGroupProfileRevisionResource>.GetEnumerator()
            => throw new System.NotSupportedException("Backward compat type - use CGProfileResource.GetAllRevisions() instead.");

        IEnumerator IEnumerable.GetEnumerator()
            => throw new System.NotSupportedException("Backward compat type - use CGProfileResource.GetAllRevisions() instead.");

        IAsyncEnumerator<ContainerGroupProfileRevisionResource> IAsyncEnumerable<ContainerGroupProfileRevisionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => throw new System.NotSupportedException("Backward compat type - use CGProfileResource.GetAllRevisions() instead.");
    }
}
