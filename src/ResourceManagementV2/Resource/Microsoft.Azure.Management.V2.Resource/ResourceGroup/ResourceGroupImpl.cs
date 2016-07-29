using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Management.V2.Resource.ResourceGroup.Definition;
using Microsoft.Azure.Management.V2.Resource.Core.Resource.Update;
using Microsoft.Azure.Management.V2.Resource.ResourceGroup.Update;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class ResourceGroupImpl : 
            CreatableUpdatable<IResourceGroup, ResourceManager.Models.ResourceGroupInner, ResourceGroupImpl>,
            IResourceGroup,
            ResourceGroup.Definition.IDefinition,
            ResourceGroup.Update.IUpdate
    {
        ResourceManager.IResourceGroupsOperations client;

        public string ProvisioningState
        {
            get
            {
                return Inner.Properties.ProvisioningState;
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

        public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string RegionName
        {
            get
            {
                return Inner.Location;
            }
        }

        public IReadOnlyDictionary<string, string> Tags
        {
            get
            {
                return (IReadOnlyDictionary<string, string>)Inner.Tags;
            }
        }

        IDictionary<string, string> IResourceGroup.Tags
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Region Region
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IDictionary<string, string> IResource.Tags
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        internal ResourceGroupImpl(ResourceManager.Models.ResourceGroupInner inner, ResourceManager.IResourceGroupsOperations client) : base(inner.Name, inner)
        {
            this.client = client;
        }

        public ResourceGroup.Update.IUpdate Update() {
            return this;
        }

        public override async Task<IResourceGroup> Refresh()
        {
            var result = await client.GetWithHttpMessagesAsync(Name);
            SetInner(result.Body);
            return this;
        }

        public override async Task<IResource> CreateResourceAsync(CancellationToken cancellationToken)
        {
            ResourceManager.Models.ResourceGroupInner param = new ResourceManager.Models.ResourceGroupInner();
            param.Location = Inner.Location;
            param.Tags = Inner.Tags;
            var response = await client.CreateOrUpdateWithHttpMessagesAsync(Name, param, null, cancellationToken);
            SetInner(response.Body);
            return this;
        }

        #region Fluent setters

        #region Definition setters 

        public ResourceGroup.Definition.IWithCreate WithRegion(string regionName)
        {
            Inner.Location = regionName;
            return this;
        }


        public IResourceGroupExportResult ExportTemplate(ResourceGroupExportTemplateOptions options)
        {
            throw new NotImplementedException();
        }

        public IWithCreate WithRegion(Region region)
        {
            throw new NotImplementedException();
        }

        public IResourceGroup Create()
        {
            throw new NotImplementedException();
        }

        public Task<IResourceGroup> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
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

        public IWithCreate WithoutTag(string key)
        {
            if (Inner.Tags != null && Inner.Tags.ContainsKey(key))
            {
                Inner.Tags.Remove(key);
            }
            return this;
        }

        public IResourceGroup Apply()
        {
            throw new NotImplementedException();
        }

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
    }
}
