// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore the preview-only enum exposed by the previous GA package.
/// <summary> Describe the level of detail with which queries are to be logged. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum EnableFullTextQuery
{
    /// <summary> None. </summary>
    None,

    /// <summary> True. </summary>
    True,

    /// <summary> False. </summary>
    False,
}
