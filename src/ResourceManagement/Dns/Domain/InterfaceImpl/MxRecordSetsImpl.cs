// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class MXRecordSetsImpl 
    {
        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IDnsZone Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>.Parent
        {
            get
            {
                return this.Parent as Microsoft.Azure.Management.Dns.Fluent.IDnsZone;
            }
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name within the current resource group asynchronously.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <param name="cancellationToken">the task cancellation token</param>
        /// <return>the task</return>
        Task<Microsoft.Azure.Management.Dns.Fluent.IMXRecordSet> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<Microsoft.Azure.Management.Dns.Fluent.IMXRecordSet>.GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return this.GetByNameAsync(name, cancellationToken) as Task<Microsoft.Azure.Management.Dns.Fluent.IMXRecordSet>;
        }
    }
}