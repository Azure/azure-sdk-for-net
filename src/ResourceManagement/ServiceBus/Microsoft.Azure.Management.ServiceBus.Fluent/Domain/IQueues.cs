// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using Queue.Definition;
    using ResourceManager.Fluent.Core;
    using Management.Fluent.ServiceBus;
    using ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to service bus queue management API in Azure.
    /// </summary>
    public interface IQueues  :
        ISupportsCreating<Queue.Definition.IBlank>,
        ISupportsGettingByName<Microsoft.Azure.Management.Servicebus.Fluent.IQueue>,
        ISupportsDeletingByName,
        IHasManager<ServiceBus.Fluent.IServiceBusManager>,
        IHasInner<IQueuesOperations>
    {
    }
}