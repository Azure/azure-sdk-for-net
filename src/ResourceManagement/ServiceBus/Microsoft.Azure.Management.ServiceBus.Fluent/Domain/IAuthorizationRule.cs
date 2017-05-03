// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Type representing authorization rule.
    /// </summary>
    /// <typeparam name="RuleT">The specific rule type.</typeparam>
    public interface IAuthorizationRule<RuleT>  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IIndependentChildResource<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager,Microsoft.Azure.Management.ServiceBus.Fluent.Models.SharedAccessAuthorizationRuleInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<RuleT>
    {
        /// <return>Stream that emits primary, secondary keys and connection strings.</return>
        Task<Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The primary, secondary keys and connection strings.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys GetKeys();

        /// <summary>
        /// Gets rights associated with the rule.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.ServiceBus.Fluent.Models.AccessRights> Rights { get; }

        /// <summary>
        /// Regenerates primary or secondary keys.
        /// </summary>
        /// <param name="policykey">The key to regenerate.</param>
        /// <return>Stream that emits primary, secondary keys and connection strings.</return>
        Task<Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys> RegenerateKeyAsync(Policykey policykey, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Regenerates primary or secondary keys.
        /// </summary>
        /// <param name="policykey">The key to regenerate.</param>
        /// <return>Primary, secondary keys and connection strings.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys RegenerateKey(Policykey policykey);
    }
}