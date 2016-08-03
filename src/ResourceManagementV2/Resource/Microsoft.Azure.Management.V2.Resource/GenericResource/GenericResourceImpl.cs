using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.GenericResource.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Core;
using System.Threading;
using Microsoft.Azure.Management.V2.Resource.GenericResource.Update;
using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using Microsoft.Azure.Management.V2.Resource.Core.Resource.Update;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class GenericResourceImpl : GroupableResource<IGenericResource,
        GenericResourceInner,
        Rest.Azure.Resource,
        GenericResourceImpl,
        IResourceManager,
        IWithGroup,
        IWithResourceType>,
        IGenericResource,
        GenericResource.Definition.IDefintion,
        GenericResource.Update.IUpdate,
        GenericResource.Update.IWithApiVersion
    {
        private IResourcesOperations client;
        internal string resourceProviderNamespace;
        internal string parentResourceId;
        internal string resourceType;
        internal string apiVersion;

        #region Getters

        public string ResourceProviderNamespace
        {
            get
            {
                return resourceProviderNamespace;
            }
        }

        public string ParentResourceId
        {
            get
            {
                return parentResourceId;
            }
        }

        public string ResourceType
        {
            get
            {
                return resourceType;
            }
        }

        public string ApiVersion
        {
            get
            {
                return apiVersion;
            }
        }

        public Plan Plan
        {
            get
            {
                return Inner.Plan;
            }
        }

        public object Properties
        {
            get
            {
                return Inner.Properties;
            }
        }

        #endregion

        internal GenericResourceImpl(string key,
            GenericResourceInner innerModel,
            IResourcesOperations client,
            IResourceManager resourceManager) : base(key, innerModel, resourceManager)
        {
            this.client = client;
        }

        #region Implementation of IResourceCreator interface

        public override IResource CreateResource()
        {
            return CreateResourceAsync(CancellationToken.None).Result;
        }

        public override async Task<IResource> CreateResourceAsync(CancellationToken cancellationToken)
        {
            GenericResourceInner inner = await client.CreateOrUpdateAsync(ResourceGroupName,
                resourceProviderNamespace,
                parentResourceId,
                resourceType,
                Name,
                apiVersion,
                Inner,
                cancellationToken);
            SetInner(inner);
            return this;
        }

        #endregion

        public override Task<IGenericResource> Refresh()
        {
            return null;
        }


        public GenericResource.Update.IWithApiVersion Update()
        {
            return this;
        }

        #region Setters

        #region Definition Setters

        public IWithProviderNamespace WithResourceType(string resourceType)
        {
            this.resourceType = resourceType;
            return this;
        }

        public GenericResource.Definition.IWithPlan WithProviderNamespace(string resourceProviderNamespace)
        {
            this.resourceProviderNamespace = resourceProviderNamespace;
            return this;
        }

        public IWithCreate WithApiVersion(string apiVersion)
        {
            this.apiVersion = apiVersion;
            return this;
        }

        public IWithCreate WithProperties(object properties)
        {
            Inner.Properties = properties;
            return this;
        }

        public GenericResource.Definition.IWithCreate WithParentResource(string parentResourceId)
        {
            this.parentResourceId = parentResourceId;
            return this;
        }

        public GenericResource.Definition.IWithApiVersion WithPlan(string name, string publisher, string product, string promotionCode)
        {
            Inner.Plan = new Plan
            {
                Name = name,
                Publisher = publisher,
                Product = product,
                PromotionCode = promotionCode
            };
            return this;
        }

        public GenericResource.Definition.IWithApiVersion WithoutPlan()
        {
            Inner.Plan = null;
            return this;
        }

        IWithCreate IDefinitionWithTags<IWithCreate>.WithTags(IDictionary<string, string> tags)
        {
            base.WithTags(tags);
            return this;
        }

        IWithCreate IDefinitionWithTags<IWithCreate>.WithTag(string key, string value)
        {
            base.WithTag(key, value);
            return this;
        }

        #endregion

        #region Update setters


        IUpdate GenericResource.Update.IWithPlan.WithPlan(string name, string publisher, string product, string promotionCode)
        {
            Inner.Plan = new Plan
            {
                Name = name,
                Publisher = publisher,
                Product = product,
                PromotionCode = promotionCode
            };
            return this;
        }

        IUpdate GenericResource.Update.IWithParentResource.WithParentResource(string parentResourceId)
        {
            this.parentResourceId = parentResourceId;
            return this;
        }

        IUpdate IWithProperties.WithProperties(object properties)
        {
            Inner.Properties = properties;
            return this;
        }

        IUpdate GenericResource.Update.IWithApiVersion.WithApiVersion(string apiVersion)
        {
            this.apiVersion = apiVersion;
            return this;
        }

        IUpdate GenericResource.Update.IWithPlan.WithoutPlan()
        {
            Inner.Plan = null;
            return this;
        }

        IUpdate IUpdateWithTags<IUpdate>.WithTags(IDictionary<string, string> tags)
        {
            WithTags(tags);
            return this;
        }

        IUpdate IUpdateWithTags<IUpdate>.WithTag(string key, string value)
        {
            WithTag(key, value);
            return this;
        }

        IUpdate IUpdateWithTags<IUpdate>.WithoutTag(string key)
        {
            WithoutTag(key);
            return this;
        }

        #endregion

        #endregion

        #region Implementation of ICreatable resource

        IGenericResource ICreatable<IGenericResource>.Create()
        {
            this.CreateAsync(CancellationToken.None, true);
            return this;
        }

        async Task<IGenericResource> ICreatable<IGenericResource>.CreateAsync(CancellationToken cancellationToken, bool multiThreaded)
        {
            await CreateAsync(cancellationToken, multiThreaded);
            return this;
        }

        #endregion

        #region Implementation of IUpdatable interface

        public IGenericResource Apply()
        {
            this.Create();
            return this;
        }

        public async Task<IGenericResource> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            await CreateAsync(cancellationToken, multiThreaded);
            return this;
        }

        #endregion
    }
}
