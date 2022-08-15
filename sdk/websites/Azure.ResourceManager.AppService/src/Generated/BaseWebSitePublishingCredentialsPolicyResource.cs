// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    public abstract class BaseWebSitePublishingCredentialsPolicyResource : ArmResource
    {
        private readonly CsmPublishingCredentialsPoliciesEntityData _data;

        protected BaseWebSitePublishingCredentialsPolicyResource()
        { }

        internal BaseWebSitePublishingCredentialsPolicyResource(ArmClient client, CsmPublishingCredentialsPoliciesEntityData data) : base(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        internal BaseWebSitePublishingCredentialsPolicyResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        { }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual CsmPublishingCredentialsPoliciesEntityData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        protected virtual Task<Response<T>> GetCoreAsync<T>(CancellationToken cancellationToken = default) where T : BaseWebSitePublishingCredentialsPolicyResource
        {
            return Task.Run(() => Response.FromValue(default(T), default));
        }

        protected virtual Response<T> GetCore<T>(CancellationToken cancellationToken = default) where T : BaseWebSitePublishingCredentialsPolicyResource
        {
            return Response.FromValue(default(T), default);
        }

        public virtual async Task<Response<BaseWebSitePublishingCredentialsPolicyResource>> GetAsync(CancellationToken cancellationToken = default)
            => await GetCoreAsync<BaseWebSitePublishingCredentialsPolicyResource>(cancellationToken).ConfigureAwait(false);

        public virtual Response<BaseWebSitePublishingCredentialsPolicyResource> Get(CancellationToken cancellationToken = default)
            => GetCore<BaseWebSitePublishingCredentialsPolicyResource>(cancellationToken);

        // do we really have to implement these?
        protected virtual Task<ArmOperation<T>> CreateOrUpdateCoreAsync<T>(WaitUntil waitUntil, CsmPublishingCredentialsPoliciesEntityData data, CancellationToken cancellationToken = default) where T : BaseWebSitePublishingCredentialsPolicyResource
        {
            return Task.Run(() => new FakeArmOperation<T>() as ArmOperation<T>);
        }

        // do we really have to implement these?
        protected virtual ArmOperation<T> CreateOrUpdateCore<T>(WaitUntil waitUntil, CsmPublishingCredentialsPoliciesEntityData data, CancellationToken cancellationToken = default) where T : BaseWebSitePublishingCredentialsPolicyResource
        {
            return new FakeArmOperation<T>();
        }

        public virtual async Task<ArmOperation<BaseWebSitePublishingCredentialsPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, CsmPublishingCredentialsPoliciesEntityData data, CancellationToken cancellationToken = default)
            => await CreateOrUpdateCoreAsync<BaseWebSitePublishingCredentialsPolicyResource>(waitUntil, data, cancellationToken).ConfigureAwait(false);

        public virtual ArmOperation<BaseWebSitePublishingCredentialsPolicyResource> CreateOrUpdate(WaitUntil waitUntil, CsmPublishingCredentialsPoliciesEntityData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateCore<BaseWebSitePublishingCredentialsPolicyResource>(waitUntil, data, cancellationToken);

        internal static BaseWebSitePublishingCredentialsPolicyResource CreateWebSitePublishCredentialsPolicyResource(ArmClient client, CsmPublishingCredentialsPoliciesEntityData data)
        {
            if (IsWebSiteFtpPublishingCredentialsPolicyResource(data))
                return new WebSiteFtpPublishingCredentialsPolicyResource(client, data);

            if (IsWebSiteScmPublishingCredentialsPolicyResource(data))
                return new WebSiteScmPublishingCredentialsPolicyResource(client, data);

            throw new InvalidOperationException($"{data.Id} is not a valid resource type for {nameof(BaseWebSitePublishingCredentialsPolicyResource)}.  Possible values are ({nameof(WebSiteFtpPublishingCredentialsPolicyResource)}, {nameof(WebSiteScmPublishingCredentialsPolicyResource)})");
        }

        private static bool IsWebSiteFtpPublishingCredentialsPolicyResource(CsmPublishingCredentialsPoliciesEntityData data)
        {
            return data.Id.ResourceType == WebSiteFtpPublishingCredentialsPolicyResource.ResourceType && data.Id.Name == "ftp";
        }

        // move this method to its corresponding derived class?
        private static bool IsWebSiteScmPublishingCredentialsPolicyResource(CsmPublishingCredentialsPoliciesEntityData data)
        {
            return data.Id.ResourceType == WebSiteFtpPublishingCredentialsPolicyResource.ResourceType && data.Id.Name == "scm";
        }

        private class FakeArmOperation<T> : AppServiceArmOperation<T>
        { }
    }
}
