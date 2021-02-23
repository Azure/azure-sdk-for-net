// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the ResourceGroup data model.
    /// </summary>
    public class ResourceGroupData : TrackedResource<ResourceManager.Resources.Models.ResourceGroup>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupData"/> class.
        /// </summary>
        /// <param name="rg"> The existing resource group model to copy from. </param>
        public ResourceGroupData(ResourceManager.Resources.Models.ResourceGroup rg)
            : base(rg.Id, rg.Location, rg)
        {
            if (rg.Tags == null)
            {
                rg.Tags = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            }
        }

        /// <inheritdoc/>
        public override IDictionary<string, string> Tags => Model.Tags;

        /// <inheritdoc/>
        public override string Name => Model.Name;

        /// <summary>
        /// Gets or sets the resource group properties
        /// </summary>
        public ResourceGroupProperties Properties
        {
            get => Model.Properties;
            set => Model.Properties = value;
        }

        /// <summary>
        /// Gets or sets who this resource group is managed by
        /// </summary>
        public string ManagedBy
        {
            get => Model.ManagedBy;
            set => Model.ManagedBy = value;
        }

        /// <summary>
        /// Converts from a <see cref="ResourceGroupData"/> into the ResourceManager.Resources.Models.ResourceGroup.
        /// </summary>
        /// <param name="other"> The tracked resource convert from. </param>
        public static implicit operator ResourceManager.Resources.Models.ResourceGroup(ResourceGroupData other)
        {
            other.Model.Tags.Clear();
            foreach (var tag in other.Tags)
            {
                other.Model.Tags.Add(tag);
            }

            return other.Model;
        }
    }
}
