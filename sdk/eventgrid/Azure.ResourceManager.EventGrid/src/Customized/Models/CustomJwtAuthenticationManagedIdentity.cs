// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class CustomJwtAuthenticationManagedIdentity
    {
        /// <summary> Back-compatible alias for <see cref="Type"/>. </summary>
        public CustomJwtAuthenticationManagedIdentityType IdentityType
        {
            get => Type;
            set => Type = value;
        }
    }
}
