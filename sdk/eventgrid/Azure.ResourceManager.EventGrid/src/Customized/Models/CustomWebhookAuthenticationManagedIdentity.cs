// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class CustomWebhookAuthenticationManagedIdentity
    {
        /// <summary> Back-compatible alias for <see cref="Type"/>. </summary>
        public CustomWebhookAuthenticationManagedIdentityType IdentityType
        {
            get => Type;
            set => Type = value;
        }
    }
}
