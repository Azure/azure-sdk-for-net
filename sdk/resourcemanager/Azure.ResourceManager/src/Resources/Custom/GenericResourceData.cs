// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    // this piece of customization code is used for fixing the base class here
    public partial class GenericResourceData : TrackedResourceExtendedData
    {
    }
}
