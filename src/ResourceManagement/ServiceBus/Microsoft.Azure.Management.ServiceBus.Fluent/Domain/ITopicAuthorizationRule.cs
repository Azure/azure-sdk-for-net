// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.TopicAuthorizationRule.Update;

    /// <summary>
    /// Type representing authorization rule defined for topic.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface ITopicAuthorizationRule  :
        Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRule<Microsoft.Azure.Management.ServiceBus.Fluent.ITopicAuthorizationRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<TopicAuthorizationRule.Update.IUpdate>
    {
        /// <summary>
        /// Gets the name of the namespace that the parent topic belongs to.
        /// </summary>
        string NamespaceName { get; }

        /// <summary>
        /// Gets the name of the parent topic name.
        /// </summary>
        string TopicName { get; }
    }
}