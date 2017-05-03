// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition;
    using Microsoft.Azure.Management.ServiceBus.Fluent;

    /// <summary>
    /// Entry point to service bus queue management API in Azure.
    /// </summary>
    public interface IQueues  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Queue.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ServiceBus.Fluent.IQueue>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<Microsoft.Azure.Management.ServiceBus.Fluent.IQueue>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IQueuesOperations>
    {
    }
}