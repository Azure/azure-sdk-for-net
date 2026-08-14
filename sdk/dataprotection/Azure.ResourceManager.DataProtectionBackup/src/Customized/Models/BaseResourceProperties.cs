// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public abstract partial class BaseResourceProperties
    {
        /// <summary> Initializes a new instance of <see cref="BaseResourceProperties"/> for deserialization. </summary>
        protected BaseResourceProperties()  // This constructor is protected for backward compatibility.
        {
        }
    }
}
