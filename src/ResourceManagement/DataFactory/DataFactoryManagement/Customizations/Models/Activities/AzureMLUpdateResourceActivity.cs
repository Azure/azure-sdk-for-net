//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// ADF Activity for updating the Trained Model module of an Azure ML Web service endpoint with a new trained model. See 
    /// https://azure.microsoft.com/documentation/articles/machine-learning-retrain-models-programmatically/
    /// for information on how to create retrainable Azure Machine Learning services. You can create an ADF Pipeline with 
    /// an <see cref="AzureMLBatchExecutionActivity" /> to perform retraining and produce a new iLearner in an output Dataset, then use that
    /// Dataset as input to this Activity to patch a batch scoring endpoint.
    /// 
    /// The Azure ML Linked Service for this activity must contain the management URL and API key.
    /// </summary>
    [AdfTypeName("AzureMLUpdateResource")]
    public class AzureMLUpdateResourceActivity : ActivityTypeProperties
    {
        /// <summary>
        /// Required. Name of ADF Blob Dataset representing the iLearner file that will be uploaded by the update operation.
        /// The Dataset must be included in this Activity's Pipeline Inputs.
        /// </summary>
        [AdfRequired]
        public string TrainedModelDatasetName { get; set; }

        /// <summary>
        /// Required. Name of the Trained Model module in the experiment graph to be updated.
        /// </summary>
        [AdfRequired]
        public string TrainedModelName { get; set; }

        public AzureMLUpdateResourceActivity()
        {
        }

        public AzureMLUpdateResourceActivity(string trainedModelDatasetName, string trainedModelName)
        {
            Ensure.IsNotNull(trainedModelDatasetName, "trainedModelDatasetName");
            Ensure.IsNotNull(trainedModelName, "trainedModelName");
            this.TrainedModelDatasetName = trainedModelDatasetName;
            this.TrainedModelName = trainedModelName;
        }
    }
}
