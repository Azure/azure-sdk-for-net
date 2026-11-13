// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Authorization.Models
{
    // The TypeSpec-generated model lost the ResourceData inheritance shipped by the GA SDK.
    // Restore it through this partial declaration to preserve base-type compatibility.
    public partial class AuthorizationClassicAdministrator : ResourceData
    {
    }
}
