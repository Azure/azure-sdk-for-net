// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using Subscription.Definition;
    using ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;
    using Management.Fluent.ServiceBus.Models;
    using Management.Fluent.ServiceBus;

    /// <summary>
    /// Entry point to service bus queue management API in Azure.
    /// </summary>
    public interface ISubscriptions  :
        ISupportsCreating<Subscription.Definition.IBlank>,
        ISupportsGettingByName<Microsoft.Azure.Management.Servicebus.Fluent.ISubscription>,
        ISupportsListing<ISubscription>,
        ISupportsDeletingByName,
        IHasManager<ServiceBus.Fluent.IServiceBusManager>,
        IHasInner<ISubscriptionsOperations>
    {
    }
}