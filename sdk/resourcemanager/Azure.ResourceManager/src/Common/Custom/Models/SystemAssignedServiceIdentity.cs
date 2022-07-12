// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Models
{
    // this class here is to keep the class public and add the EditorBrowsableNever attribute
    // this class is consolidated into the ManagedServiceIdentity class.
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SystemAssignedServiceIdentity
    {
    }
}
