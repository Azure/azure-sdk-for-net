// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class CustomDomainIdentity
    {
        /// <summary> The type of managed identity used. </summary>
        [WirePath("type")]
        public CustomDomainIdentityType? IdentityType
        {
            get => Type;
            set => Type = value;
        }
    }
}
