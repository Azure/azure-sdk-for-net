// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Models
{
    // this class here is to keep the class public and add the EditorBrowsableNever attribute
    // this class is exposed in resourcemanager by accident, now we hide it in resourcemanager
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KeyVaultProperties
    {
    }
}
