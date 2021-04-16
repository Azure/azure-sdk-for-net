﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.AnomalyDetector.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.AnomalyDetector.Tests.Samples
{
    public partial class AnomalyDetectorSamples : SamplesBase<AnomalyDetectorTestEnvironment>
    {
        [Test]
        public async Task DetectLastPointAnomaly()
        {
            //read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var endpointUri = new Uri(endpoint);
            var credential = new AzureKeyCredential(apiKey);

            //create client
            AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);

            //read data
            string datapath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "samples", "data", "request-data.csv");

            List<TimeSeriesPoint> list = File.ReadAllLines(datapath, Encoding.UTF8)
                .Where(e => e.Trim().Length != 0)
                .Select(e => e.Split(','))
                .Where(e => e.Length == 2)
                .Select(e => new TimeSeriesPoint(float.Parse(e[1])){ Timestamp = DateTime.Parse(e[0])}).ToList();

            //create request
            DetectRequest request = new DetectRequest(list)
            {
                Granularity = TimeGranularity.Daily
            };

            #region Snippet:DetectLastPointAnomaly

            //detect
            Console.WriteLine("Detecting the anomaly status of the latest point in the series.");

            LastDetectResponse result = await client.DetectLastPointAsync(request).ConfigureAwait(false);

            if (result.IsAnomaly)
            {
                Console.WriteLine("The latest point was detected as an anomaly.");
            }
            else
            {
                Console.WriteLine("The latest point was not detected as an anomaly.");
            }

            #endregion
        }
    }
}
