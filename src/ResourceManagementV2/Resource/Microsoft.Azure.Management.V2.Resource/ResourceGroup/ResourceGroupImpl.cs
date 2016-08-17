using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Management.V2.Resource.ResourceGroup.Definition;
using Microsoft.Azure.Management.V2.Resource.Core.Resource.Update;
using Microsoft.Azure.Management.V2.Resource.ResourceGroup.Update;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class ResourceGroupImpl : 
            CreatableUpdatable<IResourceGroup, ResourceGroupInner, ResourceGroupImpl, IResource, ResourceGroup.Update.IUpdate>,
            IResourceGroup,
            ResourceGroup.Definition.IDefinition,
            ResourceGroup.Update.IUpdate
    {
        ResourceManager.IResourceGroupsOperations client;

        internal ResourceGroupImpl(ResourceGroupInner innerModel, ResourceManager.IResourceGroupsOperations client) : base(innerModel.Name, innerModel)
        {
            this.client = client;
        }

        #region Getters

        public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string ProvisioningState
        {
            get
            {
                return Inner.Properties.ProvisioningState;
            }
        }

        public string RegionName
        {
            get
            {
                return Inner.Location;
            }
        }

        public Region Region
        {
            get
            {
                return EnumNameAttribute.FromName<Region>(RegionName);
            }
        }

        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        public string Type
        {
            get
            {
                return null;
            }
        }

        IDictionary<string, string> IResource.Tags
        {
            get
            {
                return Inner.Tags;
            }
        }

        #endregion

        public IResourceGroupExportResult ExportTemplate(ResourceGroupExportTemplateOptions options)
        {
            ExportTemplateRequestInner inner = new ExportTemplateRequestInner();
            inner.Resources = new List<string>() { "*" };
            inner.Options = EnumNameAttribute.GetName(options);
            var result = client.ExportTemplateWithHttpMessagesAsync(Name, inner).Result;
            return new ResourceGroupExportResultImpl(result.Body);
        }

        #region Fluent setters

        #region Definition setters 

        public ResourceGroup.Definition.IWithCreate WithRegion(string regionName)
        {
            Inner.Location = regionName;
            return this;
        }

        public IWithCreate WithRegion(Region region)
        {
            return WithRegion(EnumNameAttribute.GetName(region));
        }

        public IWithCreate WithTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this;
        }

        public IWithCreate WithTag(string key, string value)
        {
            if (Inner.Tags == null)
            {
                Inner.Tags = new Dictionary<string, string>();
            }

            if (!Inner.Tags.ContainsKey(key))
            {
                Inner.Tags.Add(key, value);
            }
            return this;
        }

        #endregion

        #region Update setters

        IUpdate IUpdateWithTags<IUpdate>.WithTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this;
        }

        IUpdate IUpdateWithTags<IUpdate>.WithTag(string key, string value)
        {
            if (Inner.Tags == null)
            {
                Inner.Tags = new Dictionary<string, string>();
            }

            if (!Inner.Tags.ContainsKey(key))
            {
                Inner.Tags.Add(key, value);
            }
            return this;
        }

        IUpdate IUpdateWithTags<IUpdate>.WithoutTag(string key)
        {
            if (Inner.Tags != null && Inner.Tags.ContainsKey(key))
            {
                Inner.Tags.Remove(key);
            }
            return this;
        }

        #endregion

        #endregion

        #region Implementation of IRefreshable interface

        public override async Task<IResourceGroup> Refresh()
        {
            var result = await client.GetWithHttpMessagesAsync(Name);
            SetInner(result.Body);
            return this;
        }

        #endregion

        public override async Task<IResourceGroup> CreateResourceAsync(CancellationToken cancellationToken)
        {
            ResourceGroupInner param = new ResourceGroupInner();
            param.Location = Inner.Location;
            param.Tags = Inner.Tags;
            var response = await client.CreateOrUpdateWithHttpMessagesAsync(Name, param, null, cancellationToken);
            SetInner(response.Body);
            return this;
        }

        public override IResourceGroup CreateResource()
        {
            return CreateResourceAsync(CancellationToken.None).Result;
        }
    }
}
