// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ManagementGroups;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// the base resource of policy definition
    /// </summary>
    public abstract class BasePolicyDefinitionResource : ArmResource
    {
        private readonly PolicyDefinitionData _data;

        /// <summary>
        /// ctor for mock
        /// </summary>
        protected BasePolicyDefinitionResource()
        { }

        internal BasePolicyDefinitionResource(ArmClient client, PolicyDefinitionData data) : base(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        internal BasePolicyDefinitionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        { }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PolicyDefinitionData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        /// <summary>
        /// Core
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected virtual Task<Response<T>> GetCoreAsync<T>(CancellationToken cancellationToken = default) where T : BasePolicyDefinitionResource
        {
            return Task.Run(() => Response.FromValue(default(T), default));
        }

        /// <summary>
        /// Core
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected virtual Response<T> GetCore<T>(CancellationToken cancellationToken = default) where T : BasePolicyDefinitionResource
        {
            return Response.FromValue(default(T), default);
        }

        /// <summary>
        /// base implementation
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BasePolicyDefinitionResource>> GetAsync(CancellationToken cancellationToken = default)
            => await GetCoreAsync<BasePolicyDefinitionResource>(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// base implementation
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BasePolicyDefinitionResource> Get(CancellationToken cancellationToken = default)
            => GetCore<BasePolicyDefinitionResource>(cancellationToken);

        // factory method
        internal static BasePolicyDefinitionResource CreatePolicyDefinitionResource(ArmClient client, PolicyDefinitionData data)
        {
            if (IsTenantPolicyDefinitionResource(data))
                return new TenantPolicyDefinitionResource(client, data);

            if (IsManagementGroupPolicyDefinitionResource(data))
                return new ManagementGroupPolicyDefinitionResource(client, data);

            if (IsSubscriptionPolicyDefinitionResource(data))
                return new SubscriptionPolicyDefinitionResource(client, data);

            throw new InvalidOperationException();
        }

        internal static bool IsTenantPolicyDefinitionResource(PolicyDefinitionData data)
        {
            return data.Id.ResourceType == TenantPolicyDefinitionResource.ResourceType && data.Id.Parent.ResourceType == TenantResource.ResourceType;
        }

        internal static bool IsManagementGroupPolicyDefinitionResource(PolicyDefinitionData data)
        {
            return data.Id.ResourceType == ManagementGroupPolicyDefinitionResource.ResourceType && data.Id.Parent.ResourceType == ManagementGroupResource.ResourceType;
        }

        internal static bool IsSubscriptionPolicyDefinitionResource(PolicyDefinitionData data)
        {
            return data.Id.ResourceType == SubscriptionPolicyDefinitionResource.ResourceType && data.Id.Parent.ResourceType == SubscriptionResource.ResourceType;
        }
    }
}
