using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class ResourceGroupImpl : 
            CreatableUpdatable<IResourceGroup, ResourceManager.Models.ResourceGroup, ResourceGroupImpl>,
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

        internal ResourceGroupImpl(ResourceManager.Models.ResourceGroup inner, ResourceManager.IResourceGroupsOperations client) : base(inner.Name, inner)
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

        public override async Task<IResource> CreateResourceAsync()
        {
            ResourceManager.Models.ResourceGroup param = new ResourceManager.Models.ResourceGroup();
            param.Location = Inner.Location;
            param.Tags = Inner.Tags;
            var response = await client.CreateOrUpdateWithHttpMessagesAsync(Name, param);
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

        ResourceGroup.Definition.IWithCreate Resource.Definition.IWithTags<ResourceGroup.Definition.IWithCreate>.WithTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this;
        }

        ResourceGroup.Definition.IWithCreate Resource.Definition.IWithTags<ResourceGroup.Definition.IWithCreate>.WithTag(string key, string value)
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

        ResourceGroup.Update.IUpdate Resource.Update.IWithTags<ResourceGroup.Update.IUpdate>.WithTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this;
        }

        ResourceGroup.Update.IUpdate Resource.Update.IWithTags<ResourceGroup.Update.IUpdate>.WithTag(string key, string value)
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

        public ResourceGroup.Update.IUpdate withoutTag(string key)
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
