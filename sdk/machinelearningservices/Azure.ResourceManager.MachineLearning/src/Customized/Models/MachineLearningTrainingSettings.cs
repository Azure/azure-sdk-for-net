// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningTrainingSettings
    {
        /// <summary> Enable recommendation of DNN models. </summary>
        [WirePath("enableDnnTraining")]
        public bool? IsDnnTrainingEnabled
        {
            get => EnableDnnTraining;
            set => EnableDnnTraining = value;
        }

        /// <summary> Flag to turn on explainability on best model. </summary>
        [WirePath("enableModelExplainability")]
        public bool? IsModelExplainabilityEnabled
        {
            get => EnableModelExplainability;
            set => EnableModelExplainability = value;
        }

        /// <summary> Flag for enabling onnx compatible models. </summary>
        [WirePath("enableOnnxCompatibleModels")]
        public bool? IsOnnxCompatibleModelsEnabled
        {
            get => EnableOnnxCompatibleModels;
            set => EnableOnnxCompatibleModels = value;
        }

        /// <summary> Enable stack ensemble run. </summary>
        [WirePath("enableStackEnsemble")]
        public bool? IsStackEnsembleEnabled
        {
            get => EnableStackEnsemble;
            set => EnableStackEnsemble = value;
        }

        /// <summary> Enable voting ensemble run. </summary>
        [WirePath("enableVoteEnsemble")]
        public bool? IsVoteEnsembleEnabled
        {
            get => EnableVoteEnsemble;
            set => EnableVoteEnsemble = value;
        }
    }
}
