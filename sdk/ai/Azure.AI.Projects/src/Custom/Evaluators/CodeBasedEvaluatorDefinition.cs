// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects;

public partial class CodeBasedEvaluatorDefinition
{
    /// <summary> Initializes a new instance of <see cref="CodeBasedEvaluatorDefinition"/>. </summary>
    /// <param name="initParameters"> The JSON schema (Draft 2020-12) for the evaluator's input parameters. This includes parameters like type, properties, required. </param>
    /// <param name="dataSchema"> The JSON schema (Draft 2020-12) for the evaluator's input data. This includes parameters like type, properties, required. </param>
    /// <param name="metrics"> List of output metrics produced by this evaluator. </param>
    /// <param name="codeText"> Inline code text for the evaluator. </param>
    public CodeBasedEvaluatorDefinition(BinaryData initParameters, BinaryData dataSchema, IDictionary<string, EvaluatorMetric> metrics, string codeText) : base(EvaluatorDefinitionType.Code, initParameters, dataSchema, metrics, null)
    {
        CodeText = codeText;
    }
}
