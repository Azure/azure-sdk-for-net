/*
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License.


This sample demonstrates the Anomaly Detection service's two detection methods:
    * Anomaly detection on an entire time-series dataset.
    * Anomaly detection on the latest data point in a dataset.

 * Prerequisites:
     * The Anomaly Detector client library for .NET
     * A .csv file containing a time-series data set with 
        UTC-timestamp and numerical values pairings. 
        Example data is included in this repo.
*/

namespace AnomalyDetectorSample
{
    // <usingStatements>
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.CognitiveServices.AnomalyDetector;
    using Microsoft.Azure.CognitiveServices.AnomalyDetector.Models;
    // </usingStatements>

    class Program{

        // <mainMethod>
        static void Main(string[] args){
            //This sample assumes you have created an environment variable for your key and endpoint
            string endpoint = Environment.GetEnvironmentVariable("ANOMALY_DETECTOR_ENDPOINT");
            string key = Environment.GetEnvironmentVariable("ANOMALY_DETECTOR_KEY");
            string datapath = "request-data.csv";

            IAnomalyDetectorClient client = createClient(endpoint, key); //Anomaly Detector client

            Request request = GetSeriesFromFile(datapath); // The request payload with points from the data file

            EntireDetectSampleAsync(client, request).Wait(); // Async method for batch anomaly detection
            LastDetectSampleAsync(client, request).Wait(); // Async method for analyzing the latest data point in the set

            Console.WriteLine("\nPress ENTER to exit.");
            Console.ReadLine();
        }
        // </mainMethod>

        // <createClient>
        static IAnomalyDetectorClient createClient(string endpoint, string key)
        {
            IAnomalyDetectorClient client = new AnomalyDetectorClient(new ApiKeyServiceClientCredentials(key))
            {
                Endpoint = endpoint
            };
            return client;
        }
        // </createClient>

        // <runSamplesHelper>
        //Run the anomaly detection examples with extra error handling
        static void runSamples(IAnomalyDetectorClient client, string dataPath)
        {

            try
            {
                List<Point> series = GetSeriesFromFile(dataPath);
                Request request = new Request(series, Granularity.Daily);

                EntireDetectSampleAsync(client, request).Wait();
                LastDetectSampleAsync(client, request).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null && e.InnerException is APIErrorException)
                {
                    APIError error = ((APIErrorException)e.InnerException).Body;
                    Console.WriteLine("Error code: " + error.Code);
                    Console.WriteLine("Error message: " + error.Message);
                }
                else if (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
        }
        // </runSamplesHelper>

        // <GetSeriesFromFile>
        static Request GetSeriesFromFile(string path)
        {
            List<Point> list = File.ReadAllLines(path, Encoding.UTF8)
                .Where(e => e.Trim().Length != 0)
                .Select(e => e.Split(','))
                .Where(e => e.Length == 2)
                .Select(e => new Point(DateTime.Parse(e[0]), Double.Parse(e[1]))).ToList();
            
            return new Request(list, Granularity.Daily); 
        }
        // </GetSeriesFromFile>

        // <entireDatasetExample>
        static async Task EntireDetectSampleAsync(IAnomalyDetectorClient client, Request request)
        {
            Console.WriteLine("Detecting anomalies in the entire time series.");

            EntireDetectResponse result = await client.EntireDetectAsync(request).ConfigureAwait(false);

            if (result.IsAnomaly.Contains(true))
            {
                Console.WriteLine("An anomaly was detected at index:");
                for (int i = 0; i < request.Series.Count; ++i)
                {
                    if (result.IsAnomaly[i])
                    {
                        Console.Write(i);
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(" No anomalies detected in the series.");
            }
        }
        // </entireDatasetExample>

        // <latestPointExample>
        static async Task LastDetectSampleAsync(IAnomalyDetectorClient client, Request request)
        {

            Console.WriteLine("Detecting the anomaly status of the latest point in the series.");
            LastDetectResponse result = await client.LastDetectAsync(request).ConfigureAwait(false);

            if (result.IsAnomaly)
            {
                Console.WriteLine("The latest point was detected as an anomaly.");
            }
            else
            {
                Console.WriteLine("The latest point was not detected as an anomaly.");
            }
        }
        // </latestPointExample>
    }
}
