// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Evaluation;

/// <summary> The EvaluatorDefinition. </summary>
[Experimental("AAIP001")]
[CodeGenType("EvaluatorDefinition")]
public partial class EvaluatorDefinition
{
    // Customization: retain BinaryData despite Record<unknown> basis
    [CodeGenMember("init_parameters")]
    public BinaryData InitParameters { get; set; }

    [CodeGenMember("data_schema")]
    public BinaryData DataSchema { get; set; }
}
