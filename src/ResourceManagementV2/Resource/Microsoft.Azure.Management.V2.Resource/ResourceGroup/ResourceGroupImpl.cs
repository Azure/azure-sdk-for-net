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
        ResourceManager.ResourceManagementClient client;

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

        internal ResourceGroupImpl(ResourceManager.Models.ResourceGroup inner, ResourceManager.ResourceManagementClient client) : base(inner.Name, inner)
        {
            this.client = client;
        }

        async Task<IResourceGroup> ICreatable<IResourceGroup>.CreateAsync()
        {
            return await CreateAsync();
        }

        public ResourceGroup.Update.IUpdate Update() {
            return this;
        }

        public async Task<IResourceGroup> ApplyAsync()
        {
            return await CreateAsync();
        }

        public override async Task<IResourceGroup> Refresh()
        {
            var result = await client.ResourceGroups.GetWithHttpMessagesAsync(Name);
            SetInner(result.Body);
            return this;
        }

        protected override async Task CreateResource()
        {
            ResourceManager.Models.ResourceGroup param = new ResourceManager.Models.ResourceGroup();
            param.Location = Inner.Location;
            param.Tags = Inner.Tags;
            var response = await client.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync(Name, param);
            SetInner(response.Body);
        }

        #region Fluent setters

        #region Definition setters 

        public ResourceGroup.Definition.IWithCreate withRegion(string regionName)
        {
            Inner.Location = regionName;
            return this;
        }

        ResourceGroup.Definition.IWithCreate Resource.Definition.IWithTags<ResourceGroup.Definition.IWithCreate>.withTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this;
        }

        ResourceGroup.Definition.IWithCreate Resource.Definition.IWithTags<ResourceGroup.Definition.IWithCreate>.withTag(string key, string value)
        {
            if (Inner.Tags == null)
            {
                Inner.Tags = new Dictionary<string, string>();
            }

            Inner.Tags.Add(key, value);
            return this;
        }

        #endregion

        #region Update setters

        ResourceGroup.Update.IUpdate Resource.Update.IWithTags<ResourceGroup.Update.IUpdate>.withTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this;
        }

        ResourceGroup.Update.IUpdate Resource.Update.IWithTags<ResourceGroup.Update.IUpdate>.withTag(string key, string value)
        {
            return this;
        }

        public ResourceGroup.Update.IUpdate withoutTag(string key)
        {
            return this;
        }

        #endregion

        #endregion
    }
}
