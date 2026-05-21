// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ComponentModel;
using Azure.AI.Projects;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Evaluation
{
    /// <summary> The direction of the metric indicating whether a higher value is better, a lower value is better, or neutral. </summary>
    [Experimental("AAIP001")]
    public readonly partial struct EvaluatorMetricDirection : IEquatable<EvaluatorMetricDirection>
    {
    }
}
