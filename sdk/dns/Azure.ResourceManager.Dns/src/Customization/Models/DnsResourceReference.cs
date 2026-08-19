// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Dns.Models
{
    public partial class DnsResourceReference
    {
        /// <summary> A reference to an azure resource from where the dns resource value is taken. </summary>
        public ResourceIdentifier TargetResourceId => TargetResource is null ? default : TargetResource.Id;
    }
}
