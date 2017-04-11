// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using Management.Fluent.ServiceBus.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Authorization key and connection string of authorization rule associated with Service Bus entities.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IAuthorizationKeys  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<ResourceListKeysInner>
    {
        /// <summary>
        /// Gets primary key associated with the rule.
        /// </summary>
        string PrimaryKey { get; }

        /// <summary>
        /// Gets secondary key associated with the rule.
        /// </summary>
        string SecondaryKey { get; }

        /// <summary>
        /// Gets primary connection string.
        /// </summary>
        string PrimaryConnectionString { get; }

        /// <summary>
        /// Gets secondary connection string.
        /// </summary>
        string SecondaryConnectionString { get; }
    }
}