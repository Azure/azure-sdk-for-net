// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Management.ServiceBus.Fluent.Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Base type for various entity specific authorization rules.
    /// </summary>
    /// <typeparam name="FluentModel">The rule fluent interface.</typeparam>
    /// <typeparam name="FluentParentModel">The rule parent fluent interface.</typeparam>
    /// <typeparam name="InnerModel">The rule inner model.</typeparam>
    /// <typeparam name="FluentModelImpl">The parent fluent implementation.</typeparam>
    /// <typeparam name="Manager">The manager.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uQXV0aG9yaXphdGlvblJ1bGVCYXNlSW1wbA==
    internal abstract partial class AuthorizationRuleBaseImpl<
        IFluentResourceT,
        FluentParentModelT,
        InnerModelT,
        FluentResourceT,
        IDefinitionT,
        IUpdatableT,
        ManagerT>  :
        IndependentChildResourceImpl<IFluentResourceT,
            FluentParentModelT,
            InnerModelT,
            FluentResourceT,
            IDefinitionT,
            IUpdatableT,
            ManagerT>
        where InnerModelT : SharedAccessAuthorizationRuleInner
        where FluentResourceT : AuthorizationRuleBaseImpl<IFluentResourceT, 
            FluentParentModelT, 
            InnerModelT, 
            FluentResourceT, 
            IDefinitionT, 
            IUpdatableT, 
            ManagerT>, IFluentResourceT
        where FluentParentModelT : class, IResource, IHasResourceGroup
        where IDefinitionT : class
        where IUpdatableT : class
        where IFluentResourceT : class, IDefinitionT
    {
        ///GENMHASH:12060F5A32B0EDDCD1D39FED89E71CAF:B6C6A00BFC93336EDE90DB15B3BEA7B7
        protected AuthorizationRuleBaseImpl(string name, InnerModelT innerObject, ManagerT manager) 
            : base(name, innerObject, manager)
        {
        }

        ///GENMHASH:AB1BA95F78B711F10D574A0046DE17B7:5297C65D2669C5460BC3173EBA6C2F1E
        protected IReadOnlyList<Management.ServiceBus.Fluent.Models.AccessRights> Rights()
        {
            if (this.Inner.Rights == null)
            {
                return new List<AccessRights>();
            }
            List<AccessRights> result = new List<AccessRights>();
            foreach (AccessRights? right in this.Inner.Rights)
            {
                if (right != null && right.HasValue)
                {
                    result.Add(right.Value);
                }
            }
            return result;
        }

        ///GENMHASH:B5F20FEE4712239FEC489FA348B7432B:198551C7BC924C965FEFC5BB96B26EA0
        protected FluentResourceT WithListeningEnabled()
        {
            if (this.Inner.Rights == null) {
                this.Inner.Rights = new List<AccessRights?>();
            }
            if (!this.Inner.Rights.Contains(AccessRights.Listen)) {
                this.Inner.Rights.Add(AccessRights.Listen);
            }
            return this as FluentResourceT;
        }

        ///GENMHASH:D56754248D4EE259AEA7A819BD939780:D853053C09DA6698BD3E22070683EF9E
        protected FluentResourceT WithManagementEnabled()
        {
            WithListeningEnabled();
            WithSendingEnabled();
            if (this.Inner.Rights == null)
            {
                this.Inner.Rights = new List<AccessRights?>();
            }
            if (!this.Inner.Rights.Contains(AccessRights.Manage))
            {
                this.Inner.Rights.Add(AccessRights.Manage);
            }
            return this as FluentResourceT;
        }

        ///GENMHASH:C5DDA67F1816E477A8EAA6ECEFBBB25C:B880654E6DAF3342650562968EF88078
        protected FluentResourceT WithSendingEnabled()
        {
            if (this.Inner.Rights == null)
            {
                this.Inner.Rights = new List<AccessRights?>();
            }
            if (!this.Inner.Rights.Contains(AccessRights.Send))
            {
                this.Inner.Rights.Add(AccessRights.Send);
            }
            return this as FluentResourceT;
        }

        /// <return>Primary, secondary keys and connection strings.</return>
        ///GENMHASH:E4DFA7EA15F8324FB60C810D0C96D2FF:F6AE67E7333EEB65ADB6D0D8BBE8B1A9
        protected IAuthorizationKeys GetKeys()
        {
            return Extensions.Synchronize(() => GetKeysAsync());
        }

        /// <summary>
        /// Regenerates primary or secondary keys.
        /// </summary>
        /// <param name="policykey">The key to regenerate.</param>
        /// <return>Primary, secondary keys and connection strings.</return>
        ///GENMHASH:DF4D523C032086042E747B7880875BA8:FD18BE4C1993EC7B8551146DDA176FAC
        protected IAuthorizationKeys RegenerateKey(Policykey policykey)
        {
            return Extensions.Synchronize(() => RegenerateKeyAsync(policykey));
        }

        /// <summary>
        /// Regenerates primary or secondary keys.
        /// </summary>
        /// <param name="policykey">The key to regenerate.</param>
        /// <return>Stream that emits primary, secondary keys and connection strings.</return>
        ///GENMHASH:4A88585D14A1F4B57527C071D5C0C394:8DF2BBCDED7039A4F19381688F737A50
        protected async Task<Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys> RegenerateKeyAsync(Policykey policykey, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.RegenerateKeysInnerAsync(policykey, cancellationToken);
            return new AuthorizationKeysImpl(inner);
        }

        /// <return>Stream that emits primary, secondary keys and connection strings.</return>
        ///GENMHASH:2751D8683222AD34691166D915065302:AD0DF6429EFF7A0256E5287F769C0BD5
        protected async Task<Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.GetKeysInnerAsync(cancellationToken);
            return new AuthorizationKeysImpl(inner);
        }

        ///GENMHASH:323E13EA523CC5C9992A3C5081E83085:27E486AB74A10242FF421C0798DDC450
        protected abstract Task<ResourceListKeysInner> GetKeysInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:1475FAC06F3CDD8B38B0B8B1586C3D7E:27E486AB74A10242FF421C0798DDC450
        protected abstract Task<Management.ServiceBus.Fluent.Models.ResourceListKeysInner> RegenerateKeysInnerAsync(Policykey policykey, CancellationToken cancellationToken = default(CancellationToken));
    }
}