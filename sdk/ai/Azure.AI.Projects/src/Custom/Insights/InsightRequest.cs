// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Evaluation
{
    /// <summary>
    /// The request of the insights report.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="EvaluationRunClusterInsightRequest"/>, <see cref="AgentClusterInsightRequest"/>, and <see cref="EvaluationComparisonInsightRequest"/>.
    /// </summary>
    [Experimental("AAIP001")]
    public abstract partial class InsightRequest
    {
    }
}
