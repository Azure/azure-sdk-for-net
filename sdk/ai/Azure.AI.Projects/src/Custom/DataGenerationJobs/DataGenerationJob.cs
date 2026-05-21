// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects;

[Experimental("AAIP001")]
public partial class DataGenerationJob
{
    internal FoundryOpenAIError Error { get; }
}
