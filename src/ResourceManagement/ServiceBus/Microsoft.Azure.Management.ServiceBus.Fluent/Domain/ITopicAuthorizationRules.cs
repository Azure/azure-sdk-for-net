// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using TopicAuthorizationRule.Definition;
    using ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;
    using Management.Fluent.ServiceBus;

    /// <summary>
    /// Entry point to topic authorization rules management API.
    /// </summary>
    public interface ITopicAuthorizationRules  :
        IAuthorizationRules<Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRule>,
        ISupportsCreating<TopicAuthorizationRule.Definition.IBlank>,
        IHasInner<ITopicsOperations>
    {
    }
}