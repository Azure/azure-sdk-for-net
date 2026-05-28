// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.AnomalyDetector.Tests.Samples
{
    public partial class AnomalyDetectorSamples : SamplesBase<AnomalyDetectorTestEnvironment>
    {
        [Test]
        public void DetectEntireSeriesAnomaly()
        {
            #region Snippet:CreateAnomalyDetectorClientEntire

            //read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            Uri endpointUri = new Uri(endpoint);
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);

            //create client
            AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);

            #endregion

            #region Snippet:ReadSeriesData

            //read data
            string datapath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "samples", "data", "request-data.csv");

            List<TimeSeriesPoint> list = File.ReadAllLines(datapath, Encoding.UTF8)
                .Where(e => e.Trim().Length != 0)
                .Select(e => e.Split(','))
                .Where(e => e.Length == 2)
                .Select(e => new TimeSeriesPoint(float.Parse(e[1])){ Timestamp = DateTime.Parse(e[0])}).ToList();

            //create request
            UnivariateDetectionOptions request = new UnivariateDetectionOptions(list)
            {
                Granularity = TimeGranularity.Daily
            };

            #endregion

            #region Snippet:DetectEntireSeriesAnomaly

            //detect
            Console.WriteLine("Detecting anomalies in the entire time series.");

            try
            {
                Response response = client.GetUnivariateClient().DetectUnivariateEntireSeries(request.ToRequestContent());
                JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

                bool hasAnomaly = false;
                for (int i = 0; i < request.Series.Count; ++i)
                {
                    if (result.GetProperty("isAnomaly")[i].GetBoolean())
                    {
                        Console.WriteLine($"An anomaly was detected at index: {i}.");
                        hasAnomaly = true;
                    }
                }
                if (!hasAnomaly)
                {
                    Console.WriteLine("No anomalies detected in the series.");
                }
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Entire detection failed: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Detection error. {ex.Message}");
                throw;
            }
            #endregion
        }
    }
}
