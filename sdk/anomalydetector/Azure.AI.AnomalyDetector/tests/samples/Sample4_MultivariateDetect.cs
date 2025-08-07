// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.AI.AnomalyDetector.Tests.Samples
{
    public partial class AnomalyDetectorSamples : SamplesBase<AnomalyDetectorTestEnvironment>
    {
        [Test]
        public void MultivariateDetect()
        {
            #region Snippet:CreateAnomalyDetectorClient
            //read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri dataSource = new Uri(TestEnvironment.DataSource);

            Uri endpointUri = new Uri(endpoint);
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);

            //create client
            AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);
            #endregion

            // train
            TimeSpan offset = new TimeSpan(0);
            DateTimeOffset startTime = new DateTimeOffset(2021, 1, 2, 0, 0, 0, offset);
            DateTimeOffset endTime = new DateTimeOffset(2021, 1, 2, 5, 0, 0, offset);
            string modelId = null;
            try
            {
                modelId = TrainModel(client, dataSource, startTime, endTime);

                // detect
                endTime = new DateTimeOffset(2021, 1, 2, 1, 0, 0, offset);
                MultivariateDetectionResult result = BatchDetect(client, dataSource, modelId, startTime, endTime);
                if (result != null)
                {
                    Console.WriteLine($"Result ID: {result.ResultId}");
                    Console.WriteLine($"Result summary: {result.Summary}");
                    Console.WriteLine($"Result length: {result.Results.Count}");
                }

                //detect last
                MultivariateLastDetectionResult lastDetectionResult = DetectLast(client, modelId);
                Console.WriteLine($"Variable States: {lastDetectionResult.VariableStates}");
                Console.WriteLine($"Variable States length: {lastDetectionResult.VariableStates.Count}");
                Console.WriteLine($"Results: {lastDetectionResult.Results}");
                Console.WriteLine($"Results length: {lastDetectionResult.Results.Count}");

                // delete
                DeleteModel(client, modelId);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Multivariate error. {e.Message}");
                throw;
            }
        }

        private int GetModelNumber(AnomalyDetectorClient client)
        {
            int modelNumber = 0;
            foreach (AnomalyDetectionModel multivariateModel in client.GetMultivariateClient().GetMultivariateModels())
            {
                modelNumber++;
            }
            return modelNumber;
        }

        #region Snippet:TrainMultivariateModel
        private string TrainModel(AnomalyDetectorClient client, Uri dataSource, DateTimeOffset startTime, DateTimeOffset endTime, int maxTryout = 500)
        {
            try
            {
                Console.WriteLine("Training new model...");

                Console.WriteLine($"{GetModelNumber(client)} available models before training.");

                ModelInfo modelInfo = new ModelInfo(dataSource, startTime, endTime)
                {
                    SlidingWindow = 200
                };

                Console.WriteLine("Training new model...(it may take a few minutes)");
                AnomalyDetectionModel response = client.GetMultivariateClient().TrainMultivariateModel(modelInfo);
                string trainedModelId = response.ModelId.ToString();
                Console.WriteLine($"Training model id is {trainedModelId}");

                // Wait until the model is ready. It usually takes several minutes
                ModelStatus? modelStatus = null;
                int tryoutCount = 1;
                response = client.GetMultivariateClient().GetMultivariateModel(trainedModelId);
                while (tryoutCount < maxTryout & modelStatus != ModelStatus.Ready & modelStatus != ModelStatus.Failed)
                {
                    System.Threading.Thread.Sleep(1000);
                    response = client.GetMultivariateClient().GetMultivariateModel(trainedModelId);
                    modelStatus = response.ModelInfo.Status;
                    TestContext.Progress.WriteLine($"try {tryoutCount}, model id: {trainedModelId}, status: {modelStatus}.");
                    tryoutCount += 1;
                };

                if (modelStatus == ModelStatus.Ready)
                {
                    Console.WriteLine("Creating model succeeds.");
                    Console.WriteLine($"{GetModelNumber(client)} available models after training.");
                    return trainedModelId;
                }

                if (modelStatus == ModelStatus.Failed)
                {
                    Console.WriteLine("Creating model failed.");
                    Console.WriteLine("Errors:");
                    ErrorResponse error = response.ModelInfo.Errors[0];
                    try
                    {
                        Console.WriteLine($"Error code: {error.Code}, Message: {error.Message}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Get error message fail: {e.Message}");
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Train error. {e.Message}");
                throw;
            }
        }
        #endregion

        #region Snippet:DetectMultivariateAnomaly
        private MultivariateDetectionResult BatchDetect(AnomalyDetectorClient client, Uri datasource, string modelId, DateTimeOffset startTime, DateTimeOffset endTime, int maxTryout = 500)
        {
            try
            {
                Console.WriteLine("Start batch detect...");
                MultivariateBatchDetectionOptions request = new MultivariateBatchDetectionOptions(datasource, startTime, endTime)
                {
                    TopContributorCount = 10
                };

                Console.WriteLine("Start batch detection, this might take a few minutes...");
                MultivariateDetectionResult response = client.GetMultivariateClient().DetectMultivariateBatchAnomaly(modelId, request);
                Guid resultId = response.ResultId;
                Console.WriteLine($"result id is: {resultId.ToString()}");

                // get detection result
                MultivariateDetectionResult resultResponse = client.GetMultivariateClient().GetMultivariateBatchDetectionResult(resultId);
                MultivariateBatchDetectionStatus resultStatus = resultResponse.Summary.Status;
                int tryoutCount = 0;
                while (tryoutCount < maxTryout & resultStatus != MultivariateBatchDetectionStatus.Ready & resultStatus != MultivariateBatchDetectionStatus.Failed)
                {
                    System.Threading.Thread.Sleep(1000);
                    resultResponse = client.GetMultivariateClient().GetMultivariateBatchDetectionResult(resultId);
                    resultStatus = resultResponse.Summary.Status;
                    Console.WriteLine($"try: {tryoutCount}, result id: {resultId} Detection status is {resultStatus}");
                }

                if (resultStatus == MultivariateBatchDetectionStatus.Failed)
                {
                    Console.WriteLine("Detection failed.");
                    Console.WriteLine("Errors:");
                    ErrorResponse error = resultResponse.Results[0].Errors[0];
                    Console.WriteLine($"Error code: {error.Code}. Message: {error.Message}");
                    return null;
                }

                return resultResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Detection error. {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Snippet:DetectLastMultivariateAnomaly
        private MultivariateLastDetectionResult DetectLast(AnomalyDetectorClient client, string modelId)
        {
            Console.WriteLine("Start last detect...");
            try
            {
                List<VariableValues> variables = new List<VariableValues>();
                using (StreamReader r = new StreamReader("./samples/data/multivariate_sample_data.json"))
                {
                    string json = r.ReadToEnd();
                    JsonElement lastDetectVariables = JsonDocument.Parse(json).RootElement.GetProperty("variables");
                    foreach (JsonElement item in lastDetectVariables.EnumerateArray())
                    {
                        variables.Add(new VariableValues(item.GetProperty("variable").ToString(), JsonConvert.DeserializeObject<IEnumerable<string>>(item.GetProperty("timestamps").ToString()), JsonConvert.DeserializeObject<IEnumerable<float>>(item.GetProperty("values").ToString())));
                    }
                }
                MultivariateLastDetectionOptions request = new MultivariateLastDetectionOptions(variables);
                MultivariateLastDetectionResult response = client.GetMultivariateClient().DetectMultivariateLastAnomaly(modelId, request);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Last detection error. {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Snippet:DeleteMultivariateModel
        private void DeleteModel(AnomalyDetectorClient client, string modelId)
        {
            client.GetMultivariateClient().DeleteMultivariateModel(modelId);
            int modelNumber = GetModelNumber(client);
            Console.WriteLine($"{modelNumber} available models after deletion.");
        }
        #endregion
    }
}
