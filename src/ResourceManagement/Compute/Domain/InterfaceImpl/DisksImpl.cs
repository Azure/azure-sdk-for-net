// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.Disk.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Rest;

    internal partial class DisksImpl
    {
        /// <summary>
        /// Revoke access granted to the snapshot asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IDisksBeta.RevokeAccessAsync(string resourceGroupName, string diskName, CancellationToken cancellationToken)
        {

            await this.RevokeAccessAsync(resourceGroupName, diskName, cancellationToken);
        }

        /// <summary>
        /// Grants access to the disk asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <returna>Representation of the deferred computation of this call returning a read-only SAS URI to the disk.</returna>
        async Task<string> Microsoft.Azure.Management.Compute.Fluent.IDisksBeta.GrantAccessAsync(string resourceGroupName, string diskName, AccessLevel accessLevel, int accessDuration, CancellationToken cancellationToken)
        {
            return await this.GrantAccessAsync(resourceGroupName, diskName, accessLevel, accessDuration, cancellationToken);
        }

        /// <summary>
        /// Revoke access granted to a disk.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IDisksBeta.RevokeAccess(string resourceGroupName, string diskName)
        {

            this.RevokeAccess(resourceGroupName, diskName);
        }

        /// <summary>
        /// Grants access to a disk.
        /// </summary>
        /// <param name="resourceGroupName">A resource group name.</param>
        /// <param name="diskName">A disk name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <return>The read-only SAS URI to the disk.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IDisksBeta.GrantAccess(string resourceGroupName, string diskName, AccessLevel accessLevel, int accessDuration)
        {
            return this.GrantAccess(resourceGroupName, diskName, accessLevel, accessDuration);
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
        Disk.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Disk.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as Disk.Definition.IBlank;
        }
    }
}