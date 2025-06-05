// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Projects
{
    /// <summary> The possible values denoting the intended usage of a file. </summary>
    [CodeGenModel("OpenAIFilePurpose")]
    public readonly partial struct AgentFilePurpose : IEquatable<AgentFilePurpose>
    {
    }
}
