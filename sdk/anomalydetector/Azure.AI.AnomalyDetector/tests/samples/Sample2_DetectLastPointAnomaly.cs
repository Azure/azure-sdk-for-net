// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.AI.AnomalyDetector.Tests.Samples
{
    public partial class AnomalyDetectorSamples : SamplesBase<AnomalyDetectorTestEnvironment>
    {
        [Test]
        public void DetectLastPointAnomaly()
        {
            //read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var endpointUri = new Uri(endpoint);
            var credential = new AzureKeyCredential(apiKey);
            String apiVersion = "v1.1";

            //create client
            AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, apiVersion, credential);

            //read data
            List<JsonElement> data_points = new List<JsonElement>();
            using (StreamReader reader = new StreamReader("./samples/data/request-data.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(',');
                    if (values.Length == 2)
                    {
                        dynamic obj = new JObject();
                        obj.timestamp = values[0];
                        obj.value = values[1];
                        data_points.Add(JsonDocument.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(obj)).RootElement);
                    }
                }
            }

            #region Snippet:DetectLastPointAnomaly

            //detect
            Console.WriteLine("Detecting the anomaly status of the latest point in the series.");
            try
            {
                var data = new
                {
                    series = data_points,
                    granularity = "daily"
                };
                Response response = client.DetectLastPoint(RequestContent.Create(data));
                JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

                if (bool.Parse(result.GetProperty("isAnomaly").ToString()))
                {
                    Console.WriteLine("The latest point was detected as an anomaly.");
                }
                else
                {
                    Console.WriteLine("The latest point was not detected as an anomaly.");
                }
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
            #endregion
        }
    }
}
