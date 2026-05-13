// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Evaluation;

[CodeGenType("ModelSamplingParams")]
public partial class ModelSamplingParams
{
    /// <summary> Initializes a new instance of <see cref="ModelSamplingParams"/>. </summary>
    /// <param name="temperature"> The temperature parameter for sampling. </param>
    /// <param name="topP"> The top-p parameter for nucleus sampling. </param>
    /// <param name="seed"> The random seed for reproducibility. </param>
    /// <param name="maxCompletionTokens"> The maximum number of tokens allowed in the completion. </param>
    public ModelSamplingParams(float temperature, float topP, int seed, int maxCompletionTokens)
    {
        Temperature = temperature;
        TopP = topP;
        Seed = seed;
        MaxCompletionTokens = maxCompletionTokens;
    }
}
