// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI
{
    public partial class AzureMachineLearningIndexChatExtensionConfiguration : AzureChatExtensionConfiguration
    {
        /// <summary> The resource id of the Azure Machine Learning project. </summary>
        public string ProjectResourceId { get; set; }
        /// <summary> The Azure Machine Learning index name. </summary>
        public string Name { get; set; }
        /// <summary> The version of the Azure Machine Learning index. </summary>
        public string Version { get; set; }

        public AzureMachineLearningIndexChatExtensionConfiguration()
        {
            Type = AzureChatExtensionType.AzureMachineLearningIndex;
        }
    }
}
