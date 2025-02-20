// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing the CustomIPPrefix data model.
    /// Custom IP prefix resource.
    /// </summary>
    public partial class CustomIPPrefixData : NetworkTrackedResourceData
    {
        /// <summary> The Parent CustomIpPrefix for IPv6 /64 CustomIpPrefix. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CustomIPPrefixData CustomIPPrefixParent
        {
            get => ParentCustomIPPrefix is null ? null : new CustomIPPrefixData() { Id = ParentCustomIPPrefix.Id };
            set
            {
                if (ParentCustomIPPrefix is null)
                    ParentCustomIPPrefix = new WritableSubResource();
                ParentCustomIPPrefix.Id = value.Id;
            }
        }
        /// <summary> The list of all Children for IPv6 /48 CustomIpPrefix. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<CustomIPPrefixData> ChildCustomIPPrefixes
        {
            get
            {
                 var list = new ChangeTrackingList<CustomIPPrefixData>();
                if (ChildCustomIPPrefixList.Count > 0)
                {
                    foreach (var item in ChildCustomIPPrefixList)
                    {
                        list.Add(new CustomIPPrefixData() { Id = item.Id });
                    }
                }
                return list;
            }
        }
    }
}
