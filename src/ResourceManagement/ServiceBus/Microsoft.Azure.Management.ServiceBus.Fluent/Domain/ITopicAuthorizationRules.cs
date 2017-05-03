// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.TopicAuthorizationRule.Definition;
    using Microsoft.Azure.Management.ServiceBus.Fluent;

    /// <summary>
    /// Entry point to topic authorization rules management API.
    /// </summary>
    public interface ITopicAuthorizationRules  :
        IBeta,
        Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRules<Microsoft.Azure.Management.ServiceBus.Fluent.ITopicAuthorizationRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<TopicAuthorizationRule.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.ServiceBus.Fluent.ITopicsOperations>
    {
    }
}