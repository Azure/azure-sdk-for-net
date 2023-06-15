// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Grant type is expected to be refresh_token. </summary>
    internal enum TokenGrantType
    {
        /// <summary> refresh_token. </summary>
        RefreshToken,
        /// <summary> password. </summary>
        Password
    }
}
