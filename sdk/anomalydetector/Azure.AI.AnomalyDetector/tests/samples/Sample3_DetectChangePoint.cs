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
// using Azure.AI.AnomalyDetector.Models;
using Azure.Core.TestFramework;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.AI.AnomalyDetector.Tests.Samples
{
    public partial class AnomalyDetectorSamples : SamplesBase<AnomalyDetectorTestEnvironment>
    {
        [Test]
        public void DetectChangePoint()
        {
            #region Snippet:CreateAnomalyDetectorClientChangePoint
            //read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var endpointUri = new Uri(endpoint);
            var credential = new AzureKeyCredential(apiKey);
            String apiVersion = "v1.1";

            //create client
            AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, apiVersion, credential);
            #endregion

            #region Snippet:ReadSeriesDataForChangePoint
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
            #endregion

            #region Snippet:DetectChangePoint
            //detect
            Console.WriteLine("Detecting the change point in the series.");
            var data = new
            {
                series = data_points,
                granularity = "daily"
            };
            Response response = client.DetectChangePoint(RequestContent.Create(data));
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

            List<int> change_point_indexs = new List<int>();
            for (int i = 0; i < result.GetProperty("isChangePoint").GetArrayLength(); ++i)
            {
                if (bool.Parse(result.GetProperty("isChangePoint")[i].ToString().ToLower()))
                {
                    change_point_indexs.Add(i);
                }
            }
            if (change_point_indexs.Count > 0)
            {
                Console.WriteLine("A change point was detected at index:");
                foreach (var index in change_point_indexs) {
                    Console.Write(index);
                    Console.Write(", ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No change point detected in the series.");
            }
            #endregion
        }
    }
}
