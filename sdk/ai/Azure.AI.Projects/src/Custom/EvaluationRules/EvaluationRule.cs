// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Evaluation;

[CodeGenType("EvaluationRule")]
public partial class EvaluationRule
{
    /// <summary> Definition of the evaluation rule action. </summary>
    [CodeGenMember("Action")]
    public EvaluationRuleAction Action { get; set; }
}
