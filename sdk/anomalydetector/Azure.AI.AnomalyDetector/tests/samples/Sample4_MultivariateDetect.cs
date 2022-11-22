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
            Guid? model_id_raw = null;
            try
            {
                model_id_raw = TrainModel(client, datasource, start_time, end_time);
                Guid model_id = model_id_raw.GetValueOrDefault();

                // detect
                end_time = new DateTimeOffset(2021, 1, 2, 1, 0, 0, offset);
                JsonElement? result = BatchDetect(client, datasource, model_id, start_time, end_time);
                if (result != null)
                {
                    JsonElement valid_result = (JsonElement)result;
                    Console.WriteLine(String.Format("Result ID: {0}", valid_result.GetProperty("resultId").ToString()));
                    Console.WriteLine(String.Format("Result summary: {0}", valid_result.GetProperty("summary").ToString()));
                    Console.WriteLine(String.Format("Result length: {0}", valid_result.GetProperty("results").GetArrayLength()));
                }

                //detect last
                JsonElement last_detection_result = DetectLast(client, model_id);
                Console.WriteLine("Variable States: {0}", last_detection_result.GetProperty("variableStates"));
                Console.WriteLine("Variable States length: {0}", last_detection_result.GetProperty("variableStates").GetArrayLength());
                Console.WriteLine("Results: {0}", last_detection_result.GetProperty("results"));
                Console.WriteLine("Results length: {0}", last_detection_result.GetProperty("results").GetArrayLength());

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
        private Guid? TrainModel(AnomalyDetectorClient client, string datasource, DateTimeOffset start_time, DateTimeOffset end_time, int max_tryout = 500)
        {
            try
            {
                Console.WriteLine("Training new model...");

                Console.WriteLine(String.Format("{0} available models before training.", GetModelNumber(client)));

                var data = new {
                    dataSource = datasource,
                    startTime = start_time,
                    endTime = end_time,
                    slidingWindow = 200
                };

                TestContext.Progress.WriteLine("Training new model...(it may take a few minutes)");
                Response response = client.CreateAndTrainMultivariateModel(RequestContent.Create(data));
                JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
                Guid trained_model_id = Guid.Parse(result.GetProperty("modelId").ToString());
                Console.WriteLine(String.Format("Training model id is {0}", trained_model_id));

                // Wait until the model is ready. It usually takes several minutes
                String model_status = null;
                int tryout_count = 0;
                while (tryout_count < max_tryout & model_status != "READY" & model_status != "FAILED")
                {
                    System.Threading.Thread.Sleep(1000);
                    response = client.GetMultivariateModel(trained_model_id);
                    result = JsonDocument.Parse(response.ContentStream).RootElement;
                    model_status = result.GetProperty("modelInfo").GetProperty("status").ToString();
                    TestContext.Progress.WriteLine(String.Format("try {0}, model_id: {1}, status: {2}.", tryout_count, trained_model_id, model_status));
                    tryout_count += 1;
                };

                if (model_status == "READY")
                {
                    Console.WriteLine("Creating model succeeds.");
                    Console.WriteLine(String.Format("{0} available models after training.", GetModelNumber(client)));
                    return trained_model_id;
                }

                if (model_status == "FAILED")
                {
                    Console.WriteLine("Creating model failed.");
                    Console.WriteLine("Errors:");
                    try
                    {
                        Console.WriteLine(String.Format("Error code: {0}, Message: {1}", result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("code").ToString(), result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("message").ToString()));
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
        private JsonElement? BatchDetect(AnomalyDetectorClient client, string datasource, Guid model_id,DateTimeOffset start_time, DateTimeOffset end_time, int max_tryout = 500)
        {
            try
            {
                Console.WriteLine("Start batch detect...");
                var data = new {
                    dataSource = datasource,
                    topContributorCount = 10,
                    startTime = start_time,
                    endTime = end_time,
                };

                TestContext.Progress.WriteLine("Start batch detection, this might take a few minutes...");
                Response response = client.DetectMultivariateBatchAnomaly(model_id, RequestContent.Create(data));
                JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
                Guid result_id = Guid.Parse(result.GetProperty("resultId").ToString());
                TestContext.Progress.WriteLine(String.Format("result id is: {0}", result_id));

                // get detection result
                response = client.GetMultivariateBatchDetectionResult(result_id);
                JsonElement detection_result = JsonDocument.Parse(response.ContentStream).RootElement;
                String result_status = result.GetProperty("summary").GetProperty("status").ToString();
                int tryout_count = 0;
                while (tryout_count < max_tryout & result_status != "READY" & result_status != "FAILED")
                {
                    System.Threading.Thread.Sleep(1000);
                    response = client.GetMultivariateBatchDetectionResult(result_id);
                    detection_result = JsonDocument.Parse(response.ContentStream).RootElement;
                    result_status = detection_result.GetProperty("summary").GetProperty("status").ToString();
                    TestContext.Progress.WriteLine(String.Format("try: {0}, result id: {1} Detection status is {2}", tryout_count, result_id, result_status));
                    Console.Out.Flush();
                }

                if (result_status == "FAILED")
                {
                    Console.WriteLine("Detection failed.");
                    Console.WriteLine("Errors:");
                    try
                    {
                        Console.WriteLine(String.Format("Error code: {}. Message: {}", detection_result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("code").ToString(), detection_result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("message").ToString()));
                    } catch (Exception e)
                    {
                        Console.WriteLine(String.Format("Get error message fail: {0}", e.Message));
                    }
                    return null;
                }
                return detection_result;
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Detection error. {0}", e.Message));
                throw;
            }
        }
        #endregion

        #region Snippet:DetectLastMultivariateAnomaly
        private JsonElement DetectLast(AnomalyDetectorClient client, Guid model_id)
        {
            Console.WriteLine("Start last detect...");
            try
            {
                JsonElement data;
                using (StreamReader r = new StreamReader("./samples/data/multivariate_sample_data.json"))
                {
                    string json = r.ReadToEnd();
                    data = JsonDocument.Parse(json).RootElement;
                }
                Response response = client.DetectMultivariateLastAnomaly(model_id, RequestContent.Create(data));
                return JsonDocument.Parse(response.ContentStream).RootElement;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Last detection error. {0}", ex.Message));
                throw;
            }
        }
        #endregion

        #region Snippet:DeleteMultivariateModel
        private void DeleteModel(AnomalyDetectorClient client, Guid model_id)
        {
            client.DeleteMultivariateModel(model_id);
            int model_number = GetModelNumber(client);
            Console.WriteLine(String.Format("{0} available models after deletion.", model_number));
        }
        #endregion
    }
}
