// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.Dns.Models
{
    [CodeGenSuppressAttribute("DnsResourceReferences")]
    public partial class DnsResourceReferenceResult
    {
        /// <summary> The result of dns resource reference request. A list of dns resource references for each of the azure resource in the request. </summary>
        public IReadOnlyList<DnsResourceReference> DnsResourceReferences
        {
            get
            {
                return Properties is null ? default : new System.Collections.ObjectModel.ReadOnlyCollection<DnsResourceReference>(Properties.DnsResourceReferences);
            }
        }
    }
}
