// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition;
    using ServiceBus.Fluent;
    using Management.Fluent.ServiceBus;

    /// <summary>
    /// Entry point to service bus queue management API in Azure.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface ISubscriptions  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Subscription.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ServiceBus.Fluent.ISubscription>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<Microsoft.Azure.Management.ServiceBus.Fluent.ISubscription>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<IServiceBusManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<ISubscriptionsOperations>
    {
    }
}