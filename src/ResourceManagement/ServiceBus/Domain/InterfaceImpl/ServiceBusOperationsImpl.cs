// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;

    internal partial class ServiceBusOperationsImpl 
    {
        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusOperation> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusOperation>.List()
        {
            return this.List() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusOperation>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IServiceBusOperation>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusOperation>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IServiceBusOperation>;
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager>.Manager
        {
            get
            {
                return this.Manager() as Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager;
            }
        }
    }
}