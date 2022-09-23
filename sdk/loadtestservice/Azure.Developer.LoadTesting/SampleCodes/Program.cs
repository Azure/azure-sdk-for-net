using System;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using Azure;
using Azure.Core;
using Azure.Developer.LoadTesting;
using Azure.Identity;
using System.IO.Pipes;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace SampleCodes
{
    internal class Program
    {
        static string endpoint = "eccdc9b7-7603-402b-879d-bde2b637db56.eus.cnt-prod.loadtesting.azure.com";
        static string clientId = "747dd2f6-45bb-43db-9286-1a701def44a1";
        static string tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        static string clientSecret = "3Nw7Q~8Q_qSx_3o-c~4uw2J78rsiZ3dWjinzY";


        static void PrintResults(Response response)
        {
            Console.WriteLine("Response Status : " + response.Status);
            Console.WriteLine("Is Error : " + response.IsError);
            Console.WriteLine("Reason Phrase : " + response.ReasonPhrase);
            Console.WriteLine("Response Content : " + response.Content);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Code Starting . . . . . . . ");

            TokenCredential credential = new ClientSecretCredential(tenantId: tenantId, clientId: clientId, clientSecret: clientSecret);

            LoadTestingClient client = new LoadTestingClient(endpoint, credential);

            string testid = "d7c68e2a-bcd8-423f-b9ce-fe9cccd00f1c";
            string fileid = "1c2ccb7b-8f62-4f70-812e-70df2c3df314";
            string testrunid = "df697300-dd3d-4654-bddf-e83d70f71af8";
            string appcomponentid = "ff0be495-eb8b-43f7-b18b-7877d33d98e7";
            string JMXPath = "/mnt/c/Users/niveditjain/Desktop/csharp/sdk/loadtestservice/Azure.Developer.LoadTesting/SampleCodes/sample.jmx";
            string appComponentConnectionString = "/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourceGroups/App-Service-Sample-Demo-rg/providers/Microsoft.Web/sites/App-Service-Sample-Demo";

            LoadTestAdministrationClient loadTestAdministration = client.getLoadTestAdministration();
            TestRunClient loadTestRun = client.getLoadTestRun();

            PrintResults(loadTestAdministration.CreateOrUpdateTest(testid, RequestContent.Create(
                   new
                   {
                       description = "This is created using SDK",
                       displayName = "SDK's LoadTest",
                       loadTestConfig = new
                       {
                           engineInstances = 1,
                           splitAllCSVs = false,
                       },
                       secrets = new { },
                       enviornmentVariables = new { },
                       passFailCriteria = new
                       {
                           passFailMetrics = new { },
                       }
                   }
                )));

            PrintResults(loadTestAdministration.UploadTestFile(testid, fileid, File.OpenRead(JMXPath)));
            // temp variable diclaration
            //Response response;


            // creating a loadtest
            //var requestCreateLoadTest = new
            //{
            //   description = "This is created from new C# SDK",
            //   displayName = "Nivedit's Test",
            //   loadTestConfig = new
            //   {
            //       engineInstances = 1,
            //       splitAllCSVs = false,
            //   },
            //   secrets = new { },
            //   environmentVariables = new { },
            //   passFailCriteria = new
            //   {
            //       passFailMetrics = new { },
            //   },
            //};

            //response = client.LoadTestAdministration.CreateOrUpdateTest(testid, RequestContent.Create(requestCreateLoadTest));
            //PrintResults(response);

            //response = client.LoadTestAdministration.UploadTestFile(testid, fileid, RequestContent.Create(filestream));
            //PrintResults(response);

            //HttpClient httpClient = new HttpClient();
            //MultipartFormDataContent form = new MultipartFormDataContent();

            //form.Add(new ByteArrayContent(file_bytes))


            // attaching JMX file to loadtest

            //var requestUploadFile = File.OpenRead(JMXPath);
            //var fileContent = new StreamContent(requestUploadFile);
            //fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
            //fileContent.Headers.ContentDisposition.FileName = "\"SampleApp.jmx\"";
            //fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            //fileContent.Headers.ContentDisposition.Name = "\"file\"";


            //MultipartFormDataContent content = new MultipartFormDataContent("----WebKitFormBoundaryOphjV8IJ3BFxFX4F");
            //content.Headers.Remove("Content-Type");
            //content.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=----WebKitFormBoundaryOphjV8IJ3BFxFX4F");
            //content.Add(fileContent);
            //RequestContent reqcontent = RequestContent.Create(content.ReadAsByteArrayAsync().GetAwaiter().GetResult());

            //response = client.LoadTestAdministration.UploadTestFile(testid, fileid, reqcontent);

            //PrintResults(response);

            ////FileStream file = new FileStream(JMXPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            ////response = client.Administration.Test.UploadFile(testid, fileid, RequestContent.Create(file));

            //// connecting to a app component

            //var data = new
            //{
            //   testId = testid,
            //   name = "Nivedit's app component",
            //   value = new
            //   {
            //       appComponentConnectionString = new
            //       {
            //           resourceId = appComponentConnectionString,
            //           resourceName = "App-Service-Sample-Demo",
            //           resourceType = "Microsoft.Web/sites",
            //           subscriptionId = "7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a"
            //       }
            //   }
            //};

            //response = client.LoadTestAdministration.CreateOrUpdateAppComponents(appcomponentid, RequestContent.Create(data));
            //PrintResults(response);

            //var dataRunLoadTest = new
            //{
            //   testId = testid,
            //   displayName = "Running load test from C# SDK",
            //};

            //response = client.LoadTestRun.CreateAndUpdateTest(testrunid, RequestContent.Create(dataRunLoadTest));
            //PrintResults(response);

            //var dataResponse = client.LoadTestRun.GetTestRunClientMetricsFilters(testrunid).Content.ToString();
            //Console.WriteLine(dataResponse);
            //dynamic clientMetricFilters = JsonConvert.DeserializeObject(dataResponse);

            //// {"testRunId":"df697300-dd3d-4654-bddf-e83d70f71af8","filters":{"requestSamplerValues":["GET"],"errorFiltersValues":[]},"timeRange":{"startTime":"2022-09-16T10:20:36Z","endTime":"2022-09-16T10:27:23Z"}}
            //Console.WriteLine(clientMetricFilters.timeRange.startTime);
            //Console.WriteLine(clientMetricFilters.timeRange.endTime);

            //var resquestData = new
            //{
            //    requestSamplers = new[]
            //    {
            //        "GET"
            //    },
            //    startTime = DateTime.ParseExact(clientMetricFilters.timeRange.startTime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
            //    endTime = DateTime.ParseExact(clientMetricFilters.timeRange.endTime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
            //};

            //response = client.LoadTestRun.GetTestRunClientMetrics(testrunid, RequestContent.Create(resquestData));
            //PrintResults(response);

            //FileStream fileStream = File.OpenRead(JMXPath);
            //var fileContent = new StreamContent(fileStream);
        }
    }
}
