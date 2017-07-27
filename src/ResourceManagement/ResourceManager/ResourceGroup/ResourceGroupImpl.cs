// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Management.ResourceManager.Fluent.ResourceGroup.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
using Microsoft.Azure.Management.ResourceManager.Fluent.ResourceGroup.Update;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class ResourceGroupImpl : 
            CreatableUpdatable<IResourceGroup, ResourceGroupInner, ResourceGroupImpl, IHasId, ResourceGroup.Update.IUpdate>,
            IResourceGroup,
            ResourceGroup.Definition.IDefinition,
            ResourceGroup.Update.IUpdate
    {
        IResourceGroupsOperations client;

        internal ResourceGroupImpl(ResourceGroupInner innerModel, IResourceGroupsOperations client) : base(innerModel.Name, innerModel)
        {
            this.client = client;
        }

        #region Getters

        public override string Name
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
                return Region.Create(RegionName);
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

        IReadOnlyDictionary<string, string> IResource.Tags
        {
            get
            {
                return Inner.Tags as IReadOnlyDictionary<string, string>;
            }
        }

        #endregion

        public IResourceGroupExportResult ExportTemplate(ResourceGroupExportTemplateOptions options)
        {
            return Extensions.Synchronize(() => ExportTemplateAsync(options));
        }

        public async Task<IResourceGroupExportResult> ExportTemplateAsync(ResourceGroupExportTemplateOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            ExportTemplateRequestInner inner = new ExportTemplateRequestInner();
            inner.Resources = new List<string>() { "*" };
            inner.Options = EnumNameAttribute.GetName(options);
            var result = await client.ExportTemplateWithHttpMessagesAsync(Name, inner, cancellationToken: cancellationToken);
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
            return WithRegion(region.Name);
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

        protected override async Task<ResourceGroupInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await client.GetAsync(Name, cancellationToken: cancellationToken);
        }

        #endregion

        public async override Task<IResourceGroup> CreateResourceAsync(CancellationToken cancellationToken)
        {
            ResourceGroupInner param = new ResourceGroupInner();
            param.Location = Inner.Location;
            param.Tags = Inner.Tags;
            var response = await client.CreateOrUpdateWithHttpMessagesAsync(Name, param, cancellationToken: cancellationToken);
            SetInner(response.Body);
            return this;
        }

        public override IResourceGroup CreateResource()
        {
            return Extensions.Synchronize(() => CreateResourceAsync(CancellationToken.None));
        }
    }
}
