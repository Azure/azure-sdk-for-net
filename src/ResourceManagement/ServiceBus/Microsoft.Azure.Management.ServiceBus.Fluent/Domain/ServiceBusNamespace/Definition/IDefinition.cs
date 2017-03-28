// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition
{
    using Microsoft.Azure.Management.Servicebus.Fluent;
    using Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Update;
    using ResourceManager.Fluent.Core.ResourceActions;
    using ResourceManager.Fluent.Core.Resource.Definition;
    using ResourceManager.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The stage of the Service Bus namespace definition allowing to add a new topic in the namespace.
    /// </summary>
    public interface IWithTopic 
    {
        /// <summary>
        /// Creates a topic entity in the Service Bus namespace.
        /// </summary>
        /// <param name="name">Topic name.</param>
        /// <param name="maxSizeInMB">Maximum size of memory allocated for the topic entity.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition.IWithCreate WithNewTopic(string name, int maxSizeInMB);
    }

    /// <summary>
    /// The entirety of the Service Bus namespace definition.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition.IWithGroup,
        IWithCreate
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        IDefinitionWithTags<Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition.IWithCreate>,
        IWithSku,
        IWithQueue,
        IWithTopic,
        IWithAuthorizationRule
    {
    }

    /// <summary>
    /// The stage of the Service Bus namespace definition allowing to add a new queue in the namespace.
    /// </summary>
    public interface IWithQueue 
    {
        /// <summary>
        /// Creates a queue entity in the Service Bus namespace.
        /// </summary>
        /// <param name="name">Queue name.</param>
        /// <param name="maxSizeInMB">Maximum size of memory allocated for the queue entity.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition.IWithCreate WithNewQueue(string name, int maxSizeInMB);
    }

    /// <summary>
    /// The stage of the Service Bus namespace definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        IWithGroup<Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the Service Bus namespace definition allowing to add an authorization rule for accessing
    /// the namespace.
    /// </summary>
    public interface IWithAuthorizationRule 
    {
        /// <summary>
        /// Creates a send authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition.IWithCreate WithNewSendRule(string name);

        /// <summary>
        /// Creates a listen authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition.IWithCreate WithNewListenRule(string name);

        /// <summary>
        /// Creates a manage authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition.IWithCreate WithNewManageRule(string name);
    }

    /// <summary>
    /// The first stage of a Service Bus namespace definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the Service Bus namespace definition allowing to specify the sku.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the namespace sku.
        /// </summary>
        /// <param name="namespaceSku">The sku.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespace.Definition.IWithCreate WithSku(NamespaceSku namespaceSku);
    }
}