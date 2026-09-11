// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns.Models
{
    public partial class DnsResourceReferenceContent
    {
        private IList<WritableSubResource> _targetResources;

        /// <summary> A list of references to Azure resources for which referencing DNS records need to be queried. </summary>
        // The service schema uses DnsSubResourceInfo, but this property shipped in stable 1.1.1 as WritableSubResource.
        // Preserve the stable public contract while adapting the generated backing collection.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Please use TargetResourceReferences instead.")]
        public IList<WritableSubResource> TargetResources
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new DnsResourceReferenceRequestProperties();
                }
                return _targetResources ??= new DnsSubResourceInfoList(Properties.TargetResourceReferences);
            }
        }
    }
}
