// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("AzureMachineLearningIndexChatExtensionParameters", typeof(string), typeof(string), typeof(string))]
internal partial class AzureMachineLearningIndexChatExtensionParameters
{
    internal AzureMachineLearningIndexChatExtensionParameters()
    { }

    /// <summary> The resource ID of the Azure Machine Learning project. </summary>
    public string ProjectResourceId { get; set; }
    /// <summary> The Azure Machine Learning index name. </summary>
    public string Name { get; set; }
    /// <summary> The version of the Azure Machine Learning index. </summary>
    public string Version { get; set; }
}
