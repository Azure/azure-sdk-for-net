// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Rest;

    internal partial class SnapshotsImpl
    {
        /// <summary>
        /// Revoke access granted to the snapshot asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="snapName">The snapshot name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.ISnapshotsBeta.RevokeAccessAsync(string resourceGroupName, string snapName, CancellationToken cancellationToken)
        {

            await this.RevokeAccessAsync(resourceGroupName, snapName, cancellationToken);
        }

        /// <summary>
        /// Grants access to the snapshot asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="snapshotName">The snapshot name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <returna>Representation of the deferred computation of this call returning a read-only SAS URI to the disk.</returna>
        async Task<string> Microsoft.Azure.Management.Compute.Fluent.ISnapshotsBeta.GrantAccessAsync(string resourceGroupName, string snapshotName, AccessLevel accessLevel, int accessDuration, CancellationToken cancellationToken)
        {
            return await this.GrantAccessAsync(resourceGroupName, snapshotName, accessLevel, accessDuration, cancellationToken);
        }

        /// <summary>
        /// Revoke access granted to a snapshot.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="snapName">The snapshot name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.ISnapshotsBeta.RevokeAccess(string resourceGroupName, string snapName)
        {

            this.RevokeAccess(resourceGroupName, snapName);
        }

        /// <summary>
        /// Grants access to a snapshot.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="snapshotName">The snapshot name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <return>The read-only SAS URI to the snapshot.</return>
        string Microsoft.Azure.Management.Compute.Fluent.ISnapshotsBeta.GrantAccess(string resourceGroupName, string snapshotName, AccessLevel accessLevel, int accessDuration)
        {
            return this.GrantAccess(resourceGroupName, snapshotName, accessLevel, accessDuration);
        }

        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        Snapshot.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Snapshot.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as Snapshot.Definition.IBlank;
        }
    }
}