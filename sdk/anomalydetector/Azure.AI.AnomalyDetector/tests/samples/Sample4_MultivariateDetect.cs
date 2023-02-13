// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Identity.Client;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Azure.AI.AnomalyDetector;
using Newtonsoft.Json;

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
            string datasource = TestEnvironment.DataSource;
            Console.WriteLine(endpoint);
            var endpointUri = new Uri(endpoint);
            var credential = new AzureKeyCredential(apiKey);

            //create client
            AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);
            #endregion

            // train
            TimeSpan offset = new TimeSpan(0);
            DateTimeOffset start_time = new DateTimeOffset(2021, 1, 2, 0, 0, 0, offset);
            DateTimeOffset end_time = new DateTimeOffset(2021, 1, 2, 5, 0, 0, offset);
            String model_id = null;
            try
            {
                model_id = TrainModel(client, datasource, start_time, end_time);

                // detect
                end_time = new DateTimeOffset(2021, 1, 2, 1, 0, 0, offset);
                MultivariateDetectionResult result = BatchDetect(client, datasource, model_id, start_time, end_time);
                if (result != null)
                {
                    Console.WriteLine(String.Format("Result ID: {0}", result.ResultId.ToString()));
                    Console.WriteLine(String.Format("Result summary: {0}", result.Summary.ToString()));
                    Console.WriteLine(String.Format("Result length: {0}", result.Results.Count));
                }

                //detect last
                MultivariateLastDetectionResult last_detection_result = DetectLast(client, model_id);
                Console.WriteLine("Variable States: {0}", last_detection_result.VariableStates);
                Console.WriteLine("Variable States length: {0}", last_detection_result.VariableStates.Count);
                Console.WriteLine("Results: {0}", last_detection_result.Results);
                Console.WriteLine("Results length: {0}", last_detection_result.Results.Count);

                // delete
                DeleteModel(client, model_id);
            }
            catch (Exception e)
            {
                String msg = String.Format("Multivariate error. {0}", e.Message);
                Console.WriteLine(msg);
                throw;
            }
        }

        private int GetModelNumber(AnomalyDetectorClient client)
        {
            int model_number = 0;
            foreach (var multivariateModel in client.GetMultivariateModels())
            {
                model_number++;
            }
            return model_number;
        }

        #region Snippet:TrainMultivariateModel
        private String TrainModel(AnomalyDetectorClient client, string datasource, DateTimeOffset start_time, DateTimeOffset end_time, int max_tryout = 500)
        {
            try
            {
                Console.WriteLine("Training new model...");

                Console.WriteLine(String.Format("{0} available models before training.", GetModelNumber(client)));

                ModelInfo request = new ModelInfo(datasource, start_time, end_time);
                request.SlidingWindow = 200;

                TestContext.Progress.WriteLine("Training new model...(it may take a few minutes)");
                AnomalyDetectionModel response = client.TrainMultivariateModel(request);
                String trained_model_id = response.ModelId;
                Console.WriteLine(String.Format("Training model id is {0}", trained_model_id));

                // Wait until the model is ready. It usually takes several minutes
                ModelStatus? model_status = null;
                int tryout_count = 1;
                response = client.GetMultivariateModelValue(trained_model_id);
                while (tryout_count < max_tryout & model_status != ModelStatus.Ready & model_status != ModelStatus.Failed)
                {
                    System.Threading.Thread.Sleep(1000);
                    response = client.GetMultivariateModelValue(trained_model_id);
                    model_status = response.ModelInfo.Status;
                    TestContext.Progress.WriteLine(String.Format("try {0}, model_id: {1}, status: {2}.", tryout_count, trained_model_id, model_status));
                    tryout_count += 1;
                };

                if (model_status == ModelStatus.Ready)
                {
                    Console.WriteLine("Creating model succeeds.");
                    Console.WriteLine(String.Format("{0} available models after training.", GetModelNumber(client)));
                    return trained_model_id;
                }

                if (model_status == ModelStatus.Failed)
                {
                    Console.WriteLine("Creating model failed.");
                    Console.WriteLine("Errors:");
                    try
                    {
                        Console.WriteLine(String.Format("Error code: {0}, Message: {1}", response.ModelInfo.Errors[0].Code.ToString(), response.ModelInfo.Errors[0].Message.ToString()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(String.Format("Get error message fail: {0}", e.Message));
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Train error. {0}", e.Message));
                throw;
            }
        }
        #endregion

        #region Snippet:DetectMultivariateAnomaly
        private MultivariateDetectionResult BatchDetect(AnomalyDetectorClient client, string datasource, String model_id, DateTimeOffset start_time, DateTimeOffset end_time, int max_tryout = 500)
        {
            try
            {
                Console.WriteLine("Start batch detect...");
                MultivariateBatchDetectionOptions request = new MultivariateBatchDetectionOptions(datasource, 10, start_time, end_time);

                TestContext.Progress.WriteLine("Start batch detection, this might take a few minutes...");
                MultivariateDetectionResult response = client.DetectMultivariateBatchAnomaly(model_id, request);
                String result_id = response.ResultId;
                TestContext.Progress.WriteLine(String.Format("result id is: {0}", result_id));

                // get detection result
                MultivariateDetectionResult resultResponse = client.GetMultivariateBatchDetectionResultValue(result_id);
                MultivariateBatchDetectionStatus result_status = resultResponse.Summary.Status;
                int tryout_count = 0;
                while (tryout_count < max_tryout & result_status != MultivariateBatchDetectionStatus.Ready & result_status != MultivariateBatchDetectionStatus.Failed)
                {
                    System.Threading.Thread.Sleep(1000);
                    resultResponse = client.GetMultivariateBatchDetectionResultValue(result_id);
                    result_status = resultResponse.Summary.Status;
                    TestContext.Progress.WriteLine(String.Format("try: {0}, result id: {1} Detection status is {2}", tryout_count, result_id, result_status.ToString()));
                    Console.Out.Flush();
                }

                if (result_status == MultivariateBatchDetectionStatus.Failed)
                {
                    Console.WriteLine("Detection failed.");
                    Console.WriteLine("Errors:");
                    try
                    {
                        Console.WriteLine(String.Format("Error code: {}. Message: {}", resultResponse.Results[0].Errors[0].Code.ToString(), resultResponse.Results[0].Errors[0].Message.ToString()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(String.Format("Get error message fail: {0}", e.Message));
                    }
                    return null;
                }
                return resultResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Detection error. {0}", e.Message));
                throw;
            }
        }
        #endregion

        #region Snippet:DetectLastMultivariateAnomaly
        private MultivariateLastDetectionResult DetectLast(AnomalyDetectorClient client, String model_id)
        {
            Console.WriteLine("Start last detect...");
            try
            {
                List<VariableValues> variables = new List<VariableValues>();
                using (StreamReader r = new StreamReader("./samples/data/multivariate_sample_data.json"))
                {
                    string json = r.ReadToEnd();
                    JsonElement lastDetectVariables = JsonDocument.Parse(json).RootElement.GetProperty("variables");
                    foreach (var index in Enumerable.Range(0, lastDetectVariables.GetArrayLength()))
                    {
                        variables.Add(new VariableValues(lastDetectVariables[index].GetProperty("variable").ToString(), JsonConvert.DeserializeObject<IEnumerable<String>>(lastDetectVariables[index].GetProperty("timestamps").ToString()), JsonConvert.DeserializeObject<IEnumerable<float>>(lastDetectVariables[index].GetProperty("values").ToString())));
                    }
                }
                MultivariateLastDetectionOptions request = new MultivariateLastDetectionOptions(variables, 1);
                MultivariateLastDetectionResult response = client.DetectMultivariateLastAnomaly(model_id, request);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Last detection error. {0}", ex.Message));
                throw;
            }
        }
        #endregion

        #region Snippet:DeleteMultivariateModel
        private void DeleteModel(AnomalyDetectorClient client, String model_id)
        {
            client.DeleteMultivariateModel(model_id);
            int model_number = GetModelNumber(client);
            Console.WriteLine(String.Format("{0} available models after deletion.", model_number));
        }
        #endregion
    }
}
