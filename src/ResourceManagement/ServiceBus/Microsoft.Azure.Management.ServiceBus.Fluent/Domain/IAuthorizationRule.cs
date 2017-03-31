// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ResourceActions;
    using Management.Fluent.ServiceBus.Models;

    /// <summary>
    /// Type representing authorization rule.
    /// </summary>
    /// <typeparam name="Rule">The specific rule type.</typeparam>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IAuthorizationRule<RuleT>  :
        IIndependentChildResource<ServiceBus.Fluent.IServiceBusManager, Management.Fluent.ServiceBus.Models.SharedAccessAuthorizationRuleInner>,
        IRefreshable<RuleT>
        where RuleT : IAuthorizationRule<RuleT>
    {
        /// <summary>
        /// Regenerates primary or secondary keys.
        /// </summary>
        /// <param name="policykey">The key to regenerate.</param>
        /// <return>Stream that emits primary, secondary keys and connection strings.</return>
        Task<Microsoft.Azure.Management.Servicebus.Fluent.IAuthorizationKeys> RegenerateKeyAsync(Policykey policykey, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>Stream that emits primary, secondary keys and connection strings.</return>
        Task<Microsoft.Azure.Management.Servicebus.Fluent.IAuthorizationKeys> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets rights associated with the rule.
        /// </summary>
        System.Collections.Generic.IList<AccessRights> Rights { get; }

        /// <return>The primary, secondary keys and connection strings.</return>
        Microsoft.Azure.Management.Servicebus.Fluent.IAuthorizationKeys GetKeys();

        /// <summary>
        /// Regenerates primary or secondary keys.
        /// </summary>
        /// <param name="policykey">The key to regenerate.</param>
        /// <return>Primary, secondary keys and connection strings.</return>
        Microsoft.Azure.Management.Servicebus.Fluent.IAuthorizationKeys RegenerateKey(Policykey policykey);
    }
}