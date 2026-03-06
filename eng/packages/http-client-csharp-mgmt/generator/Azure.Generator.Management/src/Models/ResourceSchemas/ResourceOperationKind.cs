// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Generator.Management.Models;

/// <summary> Represents the kind of operation on an ARM resource. </summary>
public enum ResourceOperationKind
{
    /// <summary> A custom action operation. </summary>
    Action,
    /// <summary> A create or update operation. </summary>
    Create,
    /// <summary> A delete operation. </summary>
    Delete,
    /// <summary> A read (get) operation. </summary>
    Read,
    /// <summary> A list operation. </summary>
    List,
    /// <summary> An update (patch) operation. </summary>
    Update,
}
