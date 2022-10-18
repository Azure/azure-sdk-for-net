# Detect Multivariate anomaly
This sample shows how to detect the anomalies in multivariate time series.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create an AnomalyDetectorClient

To create a new `AnomalyDetectorClient` you need the endpoint and credentials from your resource. In the sample below you'll use an Anomaly Detector API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateAnomalyDetectorClient
//read endpoint and apiKey
string endpoint = TestEnvironment.Endpoint;
string apiKey = TestEnvironment.ApiKey;
string datasource = TestEnvironment.DataSource;
Console.WriteLine(endpoint);
var endpointUri = new Uri(endpoint);
var credential = new AzureKeyCredential(apiKey);
String apiVersion = "v1.1";

//create client
AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, apiVersion, credential);
```

## Train the model

Create a new private async task as below to handle training your model. You will use `CreateMultivariateModel` to train the model and `GetMultivariateModel` to check when training is complete.

You could add the data source, along with start time and end time to the input of `CreateMultivariateModel`. The data source is a shared access signature(SAS) link in the format https://\[placeholder\]/. To generate the datasource link, you could first download our [sample data][datasource], then upload it to a azure container according to the [Upload a block blob][upload_blob] documentation and get the SAS link of the data according to the [Create SAS tokens for blobs in the Azure portal][generate_sas] documentation.

Call `CreateMultivariateModel` with the data and extract the model ID from the response. Afterwards, you can get the model info, including the model status, by calling `GetMultivariateModel` with the model ID . Wait until the model status is ready. 

```C# Snippet:TrainMultivariateModel
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
        Response response = client.CreateMultivariateModel(RequestContent.Create(data));
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
```

## Detect anomalies

To detect anomalies using your newly trained model, create a private function named `BatchDetect`. You will pass data to `BatchDetectAnomaly` and get resultId from the response. With the resultId, you could get the detection content and detection status by `GetBatchDetectionResult`. Return the detection content when the detection status is ready. 

```C# Snippet:DetectMultivariateAnomaly
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
        Response response = client.BatchDetectAnomaly(model_id, RequestContent.Create(data));
        JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        Guid result_id = Guid.Parse(result.GetProperty("resultId").ToString());
        TestContext.Progress.WriteLine(String.Format("result id is: {0}", result_id));

        // get detection result
        response = client.GetBatchDetectionResult(result_id);
        JsonElement detection_result = JsonDocument.Parse(response.ContentStream).RootElement;
        String result_status = result.GetProperty("summary").GetProperty("status").ToString();
        int tryout_count = 0;
        while (tryout_count < max_tryout & result_status != "READY" & result_status != "FAILED")
        {
            System.Threading.Thread.Sleep(1000);
            response = client.GetBatchDetectionResult(result_id);
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
```

## Detect last anomalies

To detect anomalies using your newly trained model, create a private function named `DetectLast`. You will you could read data from local file and pass the data to `LastDetectAnomaly`. Result can be found in the response. 

```C# Snippet:DetectLastMultivariateAnomaly
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
        Response response = client.LastDetectAnomaly(model_id, RequestContent.Create(data));
        return JsonDocument.Parse(response.ContentStream).RootElement;
    }
    catch (Exception ex)
    {
        Console.WriteLine(String.Format("Last detection error. {0}", ex.Message));
        throw;
    }
}
```

## Delete model

To delete a model that you have created previously use `DeleteMultivariateModelAsync` and pass the model ID of the model you wish to delete. You can check the number of models after deletion with `getModelNumberAsync`.

```C# Snippet:DeleteMultivariateModel
private void DeleteModel(AnomalyDetectorClient client, Guid model_id)
{
    client.DeleteMultivariateModel(model_id);
    int model_number = GetModelNumber(client);
    Console.WriteLine(String.Format("{0} available models after deletion.", model_number));
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/README.md
[datasource]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/data/sample_data_20_3000.zip
[upload_blob]: https://docs.microsoft.com/azure/storage/blobs/storage-quickstart-blobs-portal#upload-a-block-blob
[generate_sas]: https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/create-sas-tokens?tabs=Containers#create-sas-tokens-for-blobs-in-the-azure-portal
