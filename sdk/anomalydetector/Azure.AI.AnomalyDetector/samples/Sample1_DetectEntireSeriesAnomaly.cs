using Azure;
using Azure.AI.AnomalyDetector;
using Azure.AI.AnomalyDetector.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

class Sample1_DetectEntireSeriesAnomaly
{
    // <mainMethod>
    static void Main(string[] args)
    {
        //This sample assumes you have created an environment variable for your key and endpoint
        string endpoint = Environment.GetEnvironmentVariable("ANOMALY_DETECTOR_ENDPOINT");
        string key = Environment.GetEnvironmentVariable("ANOMALY_DETECTOR_API_KEY");
        string datapath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "data","request-data.csv");

        AnomalyDetectorClient client = createClient(endpoint, key); //Anomaly Detector client

        Request request = GetSeriesFromFile(datapath); // The request payload with points from the data file

        EntireDetectSampleAsync(client, request).Wait(); // Async method for batch anomaly detection

        Console.WriteLine("\nPress ENTER to exit.");
        Console.ReadLine();
    }
    // </mainMethod>

    // <createClient>
    static AnomalyDetectorClient createClient(string endpoint, string key)
    {
        var endpointUri = new Uri(endpoint);
        var credential = new AzureKeyCredential(key);

        AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);

        return client;
    }
    // </createClient>

    // <createAnomalyDetectRequest>
    static Request GetSeriesFromFile(string path)
    {
        List<Point> list = File.ReadAllLines(path, Encoding.UTF8)
            .Where(e => e.Trim().Length != 0)
            .Select(e => e.Split(','))
            .Where(e => e.Length == 2)
            .Select(e => new Point(DateTime.Parse(e[0]), float.Parse(e[1]))).ToList();

        return new Request(list, Granularity.Daily);
    }
    // </createAnomalyDetectRequest>

    // <entireDatasetExample>
    static async Task EntireDetectSampleAsync(AnomalyDetectorClient client, Request request)
    {
        Console.WriteLine("Detecting anomalies in the entire time series.");

        try
        {
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
        catch (RequestFailedException ex)
        {
            Console.WriteLine("Error code: " + ex.ErrorCode);
            Console.WriteLine("Error message: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    // </entireDatasetExample>
}