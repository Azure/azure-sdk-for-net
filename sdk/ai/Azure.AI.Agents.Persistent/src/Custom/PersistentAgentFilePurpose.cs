// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

using Microsoft.TypeSpec.Generator.Customizations;
using CodeGenTypeAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenTypeAttribute;
using CodeGenMemberAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenMemberAttribute;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;
using CodeGenSerializationAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSerializationAttribute;
namespace Azure.AI.Agents.Persistent
{
    /// <summary> The possible values denoting the intended usage of a file. </summary>
    [CodeGenType("FilePurpose")]
    public readonly partial struct PersistentAgentFilePurpose : IEquatable<PersistentAgentFilePurpose>
    {
    }
}
