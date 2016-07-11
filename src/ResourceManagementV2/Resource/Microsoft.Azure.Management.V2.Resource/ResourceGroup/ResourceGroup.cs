using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Resource.Update;
using Microsoft.Azure.Management.V2.Resource.ResourceGroup.Definition;
using Microsoft.Azure.Management.V2.Resource.ResourceGroup.Update;

namespace Microsoft.Azure.Management.V2.Resource.ResourceGroup
{
    internal class ResourceGroup : 
        CreatableUpdatable<IResourceGroup, ResourceManager.Models.ResourceGroup, ResourceGroup>,
            IResourceGroup,
            IDefinition,
            IUpdate
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

        internal ResourceGroup(ResourceManager.Models.ResourceGroup inner, ResourceManager.ResourceManagementClient client) : base(inner.Name, inner)
        {
            this.client = client;
        }

        async Task<IResourceGroup> ICreatable<IResourceGroup>.Create()
        {
            return await Create();
        }

        public IUpdate Update() {
            return this;
        }

        public async Task<IResourceGroup> Apply()
        {
            return await Create();
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
            var response = await this.client.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync(Name, param);
            SetInner(response.Body);
        }

        #region Fluent setters

        public IWithCreate withRegion(string regionName)
        {
            Inner.Location = regionName;
            return this;
        }

        public IWithCreate withTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this;
        }

        public IWithCreate withTag(string key, string value)
        {
            if (Inner.Tags == null)
            {
                Inner.Tags = new Dictionary<string, string>();
            }

            Inner.Tags.Add(key, value);
            return this;
        }

        IUpdate IWithTags<IUpdate>.withTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this;
        }

        IUpdate IWithTags<IUpdate>.withTag(string key, string value)
        {
            return this;
        }

        IUpdate IWithTags<IUpdate>.withoutTag(string key)
        {
            return this;
        }

        #endregion
    }
}
