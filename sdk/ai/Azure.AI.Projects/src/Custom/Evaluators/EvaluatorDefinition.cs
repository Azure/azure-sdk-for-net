// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects;

/// <summary> The EvaluatorDefinition. </summary>
public partial class EvaluatorDefinition
{
    // Customization: retain BinaryData despite Record<unknown> basis
    [CodeGenMember("init_parameters")]
    public BinaryData InitParameters { get; set; }

    [CodeGenMember("data_schema")]
    public BinaryData DataSchema { get; set; }
}
