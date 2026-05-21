// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Evaluation
{
    /// <summary>
    /// The result of the insights.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="EvaluationComparisonInsightResult"/>, <see cref="EvaluationRunClusterInsightResult"/>, and <see cref="AgentClusterInsightResult"/>.
    /// </summary>
    [Experimental("AAIP001")]
    public abstract partial class InsightResult
    {
    }
}
