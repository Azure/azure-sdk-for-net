// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat constructor for TypeSpec migration (ApiCompat MembersMustExist).
// The generated type's constructor is internal; this public parameterless ctor preserves the old API.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupIdentityAccessControlLevels
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupIdentityAccessControlLevels"/> for mocking. </summary>
        public ContainerGroupIdentityAccessControlLevels()
        {
        }
    }
}
