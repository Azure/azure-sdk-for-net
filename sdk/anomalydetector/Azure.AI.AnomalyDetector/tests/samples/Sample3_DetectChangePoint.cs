// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.AnomalyDetector.Tests.Samples
{
    public partial class AnomalyDetectorSamples : SamplesBase<AnomalyDetectorTestEnvironment>
    {
        [Test]
        public void DetectChangePoint()
        {
            //read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            Uri endpointUri = new Uri(endpoint);
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);

            //create client
            AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);

            #region Snippet:ReadSeriesDataForChangePoint

            //read data
            string datapath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "samples", "data", "request-data.csv");

            List<TimeSeriesPoint> list = File.ReadAllLines(datapath, Encoding.UTF8)
                .Where(e => e.Trim().Length != 0)
                .Select(e => e.Split(','))
                .Where(e => e.Length == 2)
                .Select(e => new TimeSeriesPoint(float.Parse(e[1])){ Timestamp = DateTime.Parse(e[0])}).ToList();

            //create request
            UnivariateChangePointDetectionOptions request = new UnivariateChangePointDetectionOptions(list, TimeGranularity.Daily);

            #endregion

            #region Snippet:DetectChangePoint

            //detect
            Console.WriteLine("Detecting the change point in the series.");

            UnivariateChangePointDetectionResult result = client.GetUnivariateClient().DetectUnivariateChangePoint(request);

            if (result.IsChangePoint.Contains(true))
            {
                Console.WriteLine("A change point was detected at index:");
                for (int i = 0; i < request.Series.Count; ++i)
                {
                    if (result.IsChangePoint[i])
                    {
                        Console.Write(i);
                        Console.Write(" ");
                    }
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
