// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class OriginAuthenticationProperties
    {
        // Backward compatibility: old API used AuthenticationType, new uses Type
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OriginAuthenticationType? AuthenticationType
        {
            get => Type;
            set => Type = value;
        }
    }
}
