// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    public abstract class BaseSiteConfigResource : ArmResource
    {
        private readonly SiteConfigData _data;

        protected BaseSiteConfigResource()
        {
        }

        internal BaseSiteConfigResource(ArmClient client, SiteConfigData data) : base(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        internal BaseSiteConfigResource(ArmClient client, ResourceIdentifier id) : base(client, id) { }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SiteConfigData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        // these two method does not have any implementation because the actual implementation of these might be using different RestOperations class and it is too much to let our generator figure out the "common" RestOperations and initialize them in this base class?
        // therefore for simplicity, I prefer that we let our derived class to handle everything so that this method is an equivalently a "abstract" method
        // we cannot make this method abstract because this will be a breaking change? (Need confirm)
        // if not breaking, I prefer to make this method abstract because we really cannot properly implement these methods here since we do not have anything
        protected virtual Task<Response<T>> GetCoreAsync<T>(CancellationToken cancellationToken = default) where T : BaseSiteConfigResource
        {
            return Task.Run(() => Response.FromValue(default(T), default(Response)));
        }

        protected virtual Response<T> GetCore<T>(CancellationToken cancellationToken = default) where T : BaseSiteConfigResource
        {
            return Response.FromValue(default(T), default(Response));
        }

        public Task<Response<BaseSiteConfigResource>> GetAsync(CancellationToken cancellationToken = default) => GetCoreAsync<BaseSiteConfigResource>(cancellationToken);

        public Response<BaseSiteConfigResource> Get(CancellationToken cancellationToken = default) => GetCore<BaseSiteConfigResource>(cancellationToken);

        /// <summary>
        /// The factory method
        /// </summary>
        /// <param name="client"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        internal static BaseSiteConfigResource GetSiteConfigResource(ArmClient client, SiteConfigData data)
        {
            if (data.Id.ResourceType == SiteConfigSnapshotResource.ResourceType)
                return new SiteConfigSnapshotResource(client, data);

            if (data.Id.ResourceType == WebSiteConfigResource.ResourceType)
                return new WebSiteConfigResource(client, data);

            if (data.Id.ResourceType == WebSiteSlotConfigResource.ResourceType)
                return new WebSiteSlotConfigResource(client, data);

            throw new InvalidOperationException($"{data.Id.ResourceType} is not a valid resource type for {nameof(SiteConfigData)}.  Possible values are ({SiteConfigSnapshotResource.ResourceType}, {WebSiteConfigResource.ResourceType})");
        }
    }
}
