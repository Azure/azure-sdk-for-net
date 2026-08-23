// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects.Agents;

public partial class AgentOptimizationCandidate { }
public partial class AgentOptimizationDatasetCriterion { }
public abstract partial class AgentOptimizationDatasetInput { }
public readonly partial struct AgentOptimizationDatasetInputType { }
public partial class AgentOptimizationDatasetItem { }
public partial class AgentOptimizationEvaluatorRef { }
public partial class AgentOptimizationInlineDatasetInput { }
public partial class AgentOptimizationJobInputs { }
public partial class AgentOptimizationJobProgress
{
    [CodeGenMember("ElapsedSeconds")]
    internal double ElapsedSecondsInternal { get; }

    /// <summary> Wall-clock time elapsed in seconds since the job began executing. </summary>
    public TimeSpan ElapsedSeconds => TimeSpan.FromSeconds(ElapsedSecondsInternal);
}
public partial class AgentOptimizationJobResult { }
public partial class AgentOptimizationOptions { }
public partial class AgentOptimizationReferenceDatasetInput { }
public partial class OptimizedAgentIdentifier { }
