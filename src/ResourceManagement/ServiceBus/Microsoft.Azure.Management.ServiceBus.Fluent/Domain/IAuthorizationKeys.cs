// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;

    /// <summary>
    /// Authorization key and connection string of authorization rule associated with Service Bus entities.
    /// </summary>
    public interface IAuthorizationKeys  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.ServiceBus.Fluent.Models.ResourceListKeysInner>
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