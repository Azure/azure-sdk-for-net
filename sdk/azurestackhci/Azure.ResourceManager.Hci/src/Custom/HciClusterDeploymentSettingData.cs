// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    [CodeGenSuppress("ArcNodeResourceIds")]
    [CodeGenSuppress("DeploymentMode")]
    public partial class HciClusterDeploymentSettingData
    {
        /// <summary> Azure resource ids of Arc machines to be part of cluster. </summary>
        [Obsolete("This property is obsolete. Use Properties.ArcNodeResourceIds with type IList<string> instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.arcNodeResourceIds")]
        public IList<ResourceIdentifier> ArcNodeResourceIds
        {
            get
            {
                if (Properties is null)
                    Properties = new DeploymentSettingsProperties();
                return new ResourceIdentifierListWrapper(Properties.ArcNodeResourceIds);
            }
        }

        /// <summary> The deployment mode for cluster deployment. </summary>
        [Obsolete("This property is obsolete. Use Properties.DeploymentMode with type EceDeploymentMode instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.deploymentMode")]
        public EceDeploymentMode? DeploymentMode
        {
            get
            {
                return Properties is null ? default : Properties.DeploymentMode;
            }
            set
            {
                if (Properties is null)
                    Properties = new DeploymentSettingsProperties();
                if (value.HasValue)
                    Properties.DeploymentMode = value.Value;
            }
        }

        /// <summary> Wrapper that presents IList&lt;string&gt; as IList&lt;ResourceIdentifier&gt;. </summary>
        private class ResourceIdentifierListWrapper : IList<ResourceIdentifier>
        {
            private readonly IList<string> _inner;
            internal ResourceIdentifierListWrapper(IList<string> inner) => _inner = inner;

            public ResourceIdentifier this[int index]
            {
                get => string.IsNullOrEmpty(_inner[index]) ? null : new ResourceIdentifier(_inner[index]);
                set => _inner[index] = value?.ToString();
            }

            public int Count => _inner.Count;
            public bool IsReadOnly => _inner.IsReadOnly;
            public void Add(ResourceIdentifier item) => _inner.Add(item?.ToString());
            public void Clear() => _inner.Clear();
            public bool Contains(ResourceIdentifier item) => _inner.Contains(item?.ToString());
            public void CopyTo(ResourceIdentifier[] array, int arrayIndex)
            {
                for (int i = 0; i < _inner.Count; i++)
                    array[arrayIndex + i] = string.IsNullOrEmpty(_inner[i]) ? null : new ResourceIdentifier(_inner[i]);
            }
            public IEnumerator<ResourceIdentifier> GetEnumerator() => _inner.Select(s => string.IsNullOrEmpty(s) ? null : new ResourceIdentifier(s)).GetEnumerator();
            public int IndexOf(ResourceIdentifier item) => _inner.IndexOf(item?.ToString());
            public void Insert(int index, ResourceIdentifier item) => _inner.Insert(index, item?.ToString());
            public bool Remove(ResourceIdentifier item) => _inner.Remove(item?.ToString());
            public void RemoveAt(int index) => _inner.RemoveAt(index);
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
