// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

using Microsoft.TypeSpec.Generator.Customizations;
namespace Azure.AI.Agents.Persistent
{
    /// <summary> The possible values denoting the intended usage of a file. </summary>
    [CodeGenType("FilePurpose")]
    public readonly partial struct PersistentAgentFilePurpose : IEquatable<PersistentAgentFilePurpose>
    {
    }
}
