// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.AnomalyDetector.Models;
using Azure.Core.TestFramework;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.AI.AnomalyDetector.Tests.Samples
{
    public partial class AnomalyDetectorSamples : SamplesBase<AnomalyDetectorTestEnvironment>
    {
        [Test]
        public async Task MultivariateDetect()
        {
            //read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string datasource = TestEnvironment.DataSource;
            Console.WriteLine(endpoint);
            var endpointUri = new Uri(endpoint);
            var credential = new AzureKeyCredential(apiKey);

            //create client
            AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);

            // train
            TimeSpan offset = new TimeSpan(0);
            DateTimeOffset start_time = new DateTimeOffset(2021, 1, 1, 0, 0, 0, offset);
            DateTimeOffset end_time = new DateTimeOffset(2021, 1, 2, 12, 0, 0, offset);
            Guid? model_id_raw = null;
            try
            {
                model_id_raw = await TrainAsync(client, datasource, start_time, end_time).ConfigureAwait(false);
                Console.WriteLine(model_id_raw);
                Guid model_id = model_id_raw.GetValueOrDefault();

                // detect
                start_time = end_time;
                end_time = new DateTimeOffset(2021, 1, 3, 0, 0, 0, offset);
                DetectionResult result = await DetectAsync(client, datasource, model_id, start_time, end_time).ConfigureAwait(false);
                if (result != null)
                {
                    Console.WriteLine(String.Format("Result ID: {0}", result.ResultId));
                    Console.WriteLine(String.Format("Result summary: {0}", result.Summary));
                    Console.WriteLine(String.Format("Result length: {0}", result.Results.Count));
                }

                //detect last
                await DetectLastAsync(client, model_id).ConfigureAwait(false);

                // export model
                await ExportAsync(client, model_id).ConfigureAwait(false);

                // delete
                await DeleteAsync(client, model_id).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                String msg = String.Format("Multivariate error. {0}", e.Message);
                if (model_id_raw != null)
                {
                    await DeleteAsync(client, model_id_raw.GetValueOrDefault()).ConfigureAwait(false);
                }
                Console.WriteLine(msg);
                throw;
            }
        }

        #region Snippet:TrainMultivariateModel
        private async Task<Guid?> TrainAsync(AnomalyDetectorClient client, string datasource, DateTimeOffset start_time, DateTimeOffset end_time, int max_tryout = 500)
        {
            try
            {
                Console.WriteLine("Training new model...");

                int model_number = await GetModelNumberAsync(client, false).ConfigureAwait(false);
                Console.WriteLine(String.Format("{0} available models before training.", model_number));

                ModelInfo data_feed = new ModelInfo(datasource, start_time, end_time);
                Response response_header = client.TrainMultivariateModel(data_feed);
                response_header.Headers.TryGetValue("Location", out string trained_model_id_path);
                Guid trained_model_id = Guid.Parse(trained_model_id_path.Split('/').LastOrDefault());
                Console.WriteLine(trained_model_id);

                // Wait until the model is ready. It usually takes several minutes
                Response<Model> get_response = await client.GetMultivariateModelAsync(trained_model_id).ConfigureAwait(false);
                ModelStatus? model_status = null;
                int tryout_count = 0;
                while (tryout_count < max_tryout & model_status != ModelStatus.Ready)
                {
                    System.Threading.Thread.Sleep(10000);
                    get_response = await client.GetMultivariateModelAsync(trained_model_id).ConfigureAwait(false);
                    ModelInfo model_info = get_response.Value.ModelInfo;
                    Console.WriteLine(String.Format("model_id: {0}, createdTime: {1}, lastUpdateTime: {2}, status: {3}.", get_response.Value.ModelId, get_response.Value.CreatedTime, get_response.Value.LastUpdatedTime, model_info.Status));

                    if (model_info != null)
                    {
                        model_status = model_info.Status;
                    }
                    tryout_count += 1;
                };
                get_response = await client.GetMultivariateModelAsync(trained_model_id).ConfigureAwait(false);

                if (model_status != ModelStatus.Ready)
                {
                    Console.WriteLine(String.Format("Request timeout after {0} tryouts", max_tryout));
                }

                model_number = await GetModelNumberAsync(client).ConfigureAwait(false);
                Console.WriteLine(String.Format("{0} available models after training.", model_number));
                return trained_model_id;
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Train error. {0}", e.Message));
                throw;
            }
        }
        #endregion

        #region Snippet:DetectMultivariateAnomaly
        private async Task<DetectionResult> DetectAsync(AnomalyDetectorClient client, string datasource, Guid model_id,DateTimeOffset start_time, DateTimeOffset end_time, int max_tryout = 500)
        {
            try
            {
                Console.WriteLine("Start detect...");
                Response<Model> get_response = await client.GetMultivariateModelAsync(model_id).ConfigureAwait(false);

                DetectionRequest detectionRequest = new DetectionRequest(datasource, start_time, end_time);
                Response result_response = await client.DetectAnomalyAsync(model_id, detectionRequest).ConfigureAwait(false);
                var ok = result_response.Headers.TryGetValue("Location", out string result_id_path);
                Guid result_id = Guid.Parse(result_id_path.Split('/').LastOrDefault());
                // get detection result
                Response<DetectionResult> result = await client.GetDetectionResultAsync(result_id).ConfigureAwait(false);
                int tryout_count = 0;
                while (result.Value.Summary.Status != DetectionStatus.Ready & tryout_count < max_tryout)
                {
                    System.Threading.Thread.Sleep(2000);
                    result = await client.GetDetectionResultAsync(result_id).ConfigureAwait(false);
                    tryout_count += 1;
                }

                if (result.Value.Summary.Status != DetectionStatus.Ready)
                {
                    Console.WriteLine(String.Format("Request timeout after {0} tryouts", max_tryout));
                    return null;
                }

                return result.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Detection error. {0}", e.Message));
                throw;
            }
        }
        #endregion

        #region Snippet:ExportMultivariateModel
        private async Task ExportAsync(AnomalyDetectorClient client, Guid model_id, string model_path = "model.zip")
        {
            try
            {
                Stream model = await client.ExportModelAsync(model_id).ConfigureAwait(false);
                if (model != null)
                {
                    var fileStream = File.Create(model_path);
                    model.Seek(0, SeekOrigin.Begin);
                    model.CopyTo(fileStream);
                    fileStream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Export error. {0}", e.Message));
                throw;
            }
        }
        #endregion

        #region Snippet:DeleteMultivariateModel
        private async Task DeleteAsync(AnomalyDetectorClient client, Guid model_id)
        {
            await client.DeleteMultivariateModelAsync(model_id).ConfigureAwait(false);
            int model_number = await GetModelNumberAsync(client).ConfigureAwait(false);
            Console.WriteLine(String.Format("{0} available models after deletion.", model_number));
        }
        private async Task<int> GetModelNumberAsync(AnomalyDetectorClient client, bool delete = false)
        {
            int count = 0;
            AsyncPageable<ModelSnapshot> model_list = client.ListMultivariateModelAsync(0, 10000);
            await foreach (ModelSnapshot x in model_list)
            {
                count += 1;
                Console.WriteLine(String.Format("model_id: {0}, createdTime: {1}, lastUpdateTime: {2}.", x.ModelId, x.CreatedTime, x.LastUpdatedTime));
                if (delete & count < 4)
                {
                    await client.DeleteMultivariateModelAsync(x.ModelId).ConfigureAwait(false);
                }
            }
            return count;
        }
        #endregion

        #region Snippet:DetectLastMultivariateAnomaly
        private async Task<LastDetectionResult> DetectLastAsync(AnomalyDetectorClient client, Guid model_id)
        {
            Console.WriteLine("Start detect...");

            List<VariableValues> variables = new List<VariableValues>();
            variables.Add(new VariableValues("variables_name1", new[] { "2021-01-01 00:00:00", "2021-01-01 01:00:00", "2021-01-01 02:00:00" }, new[] { 0.0f, 0.0f, 0.0f }));
            variables.Add(new VariableValues("variables_name2", new[] { "2021-01-01 00:00:00", "2021-01-01 01:00:00", "2021-01-01 02:00:00" }, new[] { 0.0f, 0.0f, 0.0f }));

            LastDetectionRequest lastDetectionRequest = new LastDetectionRequest(variables, 1);

            try
            {
                Response<LastDetectionResult> response = await client.LastDetectAnomalyAsync(model_id, lastDetectionRequest).ConfigureAwait(false);
                if (response.GetRawResponse().Status == 200)
                {
                    foreach (AnomalyState state in response.Value.Results)
                    {
                        Console.WriteLine(String.Format("timestamp: {}, isAnomaly: {}, score: {}.", state.Timestamp, state.Value.IsAnomaly, state.Value.Score));
                    }
                }

                return response;
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(String.Format("Last detection failed: {0}", ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Detection error. {0}", ex.Message));
                throw;
            }
        }
        #endregion
    }
}
