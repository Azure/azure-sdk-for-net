// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Search.Models
{
    // Backward-compat shim: the 'type' field on CheckNameAvailabilityInput is now
    // always hardcoded to "searchServices". This type existed in the old AutoRest
    // generated code but is no longer needed.
    /// <summary> The type of the resource whose name is to be validated. This value must always be 'searchServices'. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SearchServiceResourceType
    {
    }
}
