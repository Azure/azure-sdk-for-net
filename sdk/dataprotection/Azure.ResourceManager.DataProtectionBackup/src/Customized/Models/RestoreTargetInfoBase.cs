// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public abstract partial class RestoreTargetInfoBase
    {
        /// <summary> Initializes a new instance of <see cref="RestoreTargetInfoBase"/>. </summary>
        /// <param name="recoverySetting"> Recovery Option. </param>
        protected RestoreTargetInfoBase(RecoverySetting recoverySetting)    // This constructor is intentionally retained for backward compatibility.
        {
            RecoverySetting = recoverySetting;
        }
    }
}
