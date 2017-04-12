// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent;

    /// <summary>
    /// The stage of the Service Bus namespace update allowing to manage topics in the namespace.
    /// </summary>
    public interface IWithTopic 
    {
        /// <summary>
        /// Removes a topic entity from the Service Bus namespace.
        /// </summary>
        /// <param name="name">Topic name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate WithoutTopic(string name);

        /// <summary>
        /// Creates a topic entity in the Service Bus namespace.
        /// </summary>
        /// <param name="name">Topic name.</param>
        /// <param name="maxSizeInMB">Maximum size of memory allocated for the topic entity.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate WithNewTopic(string name, int maxSizeInMB);
    }

    /// <summary>
    /// The template for a Service Bus namespace update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate>,
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithSku,
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithQueue,
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithTopic,
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithAuthorizationRule
    {
    }

    /// <summary>
    /// The stage of the Service Bus namespace update allowing to manage queues in the namespace.
    /// </summary>
    public interface IWithQueue 
    {
        /// <summary>
        /// Creates a queue entity in the Service Bus namespace.
        /// </summary>
        /// <param name="name">Queue name.</param>
        /// <param name="maxSizeInMB">Maximum size of memory allocated for the queue entity.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate WithNewQueue(string name, int maxSizeInMB);

        /// <summary>
        /// Removes a queue entity from the Service Bus namespace.
        /// </summary>
        /// <param name="name">Queue name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate WithoutQueue(string name);
    }

    /// <summary>
    /// The stage of the Service Bus namespace update allowing manage authorization rules
    /// for the namespace.
    /// </summary>
    public interface IWithAuthorizationRule 
    {
        /// <summary>
        /// Creates a listen authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate WithNewListenRule(string name);

        /// <summary>
        /// Creates a manage authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate WithNewManageRule(string name);

        /// <summary>
        /// Removes an authorization rule from the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate WithoutAuthorizationRule(string name);

        /// <summary>
        /// Creates a send authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate WithNewSendRule(string name);
    }

    /// <summary>
    /// The stage of the Service Bus namespace update allowing to change the sku.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the namespace sku.
        /// </summary>
        /// <param name="namespaceSku">The sku.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate WithSku(NamespaceSku namespaceSku);
    }
}