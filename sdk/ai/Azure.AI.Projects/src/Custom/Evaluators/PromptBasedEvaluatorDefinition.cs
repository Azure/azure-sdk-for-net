// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects;

public partial class PromptBasedEvaluatorDefinition
{
    /// <summary> Initializes a new instance of <see cref="PromptBasedEvaluatorDefinition"/>. </summary>
    /// <param name="initParameters"> The JSON schema (Draft 2020-12) for the evaluator's input parameters. This includes parameters like type, properties, required. </param>
    /// <param name="dataSchema"> The JSON schema (Draft 2020-12) for the evaluator's input data. This includes parameters like type, properties, required. </param>
    /// <param name="metrics"> List of output metrics produced by this evaluator. </param>
    /// <param name="promptText"> Inline prompt text for the evaluator. </param>
    public PromptBasedEvaluatorDefinition(BinaryData initParameters, BinaryData dataSchema, IDictionary<string, EvaluatorMetric> metrics, string promptText) : base(EvaluatorDefinitionType.Prompt, initParameters, dataSchema, metrics, null)
    {
        PromptText = promptText;
    }
}
