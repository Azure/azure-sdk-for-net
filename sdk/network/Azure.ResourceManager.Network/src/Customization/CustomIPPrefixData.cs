// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class CustomIPPrefixData
    {
        // 1.15.0 exposed IReadOnlyList<WritableSubResource> references and an obsolete model-valued child alias.
        // Project IDs from the native NetworkSubResource lists; Properties still owns deserialization and serialization.

        /// <summary> The list of all Children for IPv6 /48 CustomIpPrefix. </summary>
        [WirePath("properties.childCustomIpPrefixes")]
        public IReadOnlyList<WritableSubResource> ChildCustomIPPrefixList
        {
            get
            {
                var properties = Properties ??= new CustomIPPrefixPropertiesFormat();
                return WritableSubResourceCollectionCompatibility.AsReadOnlyList(properties.ChildCustomIPPrefixes);
            }
        }

        /// <summary> The list of all Children for IPv6 /48 CustomIpPrefix. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<CustomIPPrefixData> ChildCustomIPPrefixes
        {
            get
            {
                var properties = Properties ??= new CustomIPPrefixPropertiesFormat();
                var children = properties.ChildCustomIPPrefixes;
                var result = new CustomIPPrefixData[children.Count];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = new CustomIPPrefixData { Id = children[i].Id };
                }
                return result;
            }
        }

        /// <summary> The list of all referenced PublicIpPrefixes. </summary>
        [WirePath("properties.publicIpPrefixes")]
        public IReadOnlyList<WritableSubResource> PublicIPPrefixes
        {
            get
            {
                var properties = Properties ??= new CustomIPPrefixPropertiesFormat();
                return WritableSubResourceCollectionCompatibility.AsReadOnlyList(properties.PublicIPPrefixes);
            }
        }

        // Preserve the released model-valued alias while forwarding its resource identifier.
        /// <inheritdoc cref="ParentCustomIPPrefixId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [WirePath("properties.customIpPrefixParent")]
        public CustomIPPrefixData CustomIPPrefixParent
        {
            get => ParentCustomIPPrefixId is null ? null : new CustomIPPrefixData { Id = ParentCustomIPPrefixId };
            set => ParentCustomIPPrefixId = value?.Id;
        }
    }
}
