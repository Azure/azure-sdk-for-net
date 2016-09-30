// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Management.Fluent.Resource.ResourceGroup.Definition;
using Microsoft.Azure.Management.Fluent.Resource.Core.Resource.Update;
using Microsoft.Azure.Management.Fluent.Resource.ResourceGroup.Update;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Management.Fluent.Resource
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

        public override IResourceGroup Refresh()
        {
            var result = client.Get(Name);
            SetInner(result);
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
