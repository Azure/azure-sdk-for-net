# Detect Multivariate anomaly
This sample shows how to detect the anomalies in multivariate time series.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create an AnomalyDetectorClient

To create a new `AnomalyDetectorClient` you need the endpoint, apiVersion and credentials from your resource. In the sample below you'll use an Anomaly Detector API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateAnomalyDetectorClient
//read endpoint and apiKey
string endpoint = TestEnvironment.Endpoint;
string apiKey = TestEnvironment.ApiKey;
string datasource = TestEnvironment.DataSource;
Console.WriteLine(endpoint);
var endpointUri = new Uri(endpoint);
var credential = new AzureKeyCredential(apiKey);

//create client
AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);
```

## Train the model

Create a new private async task as below to handle training your model. You will use `CreateAndTrainMultivariateModel` to train the model and `GetMultivariateModelValue` to check when training is complete.

You could add the data source, along with start time and end time to a `ModelInfo` object to create a data feed. The data source is a shared access signature(SAS) link in the format https://\[placeholder\]/. To generate the datasource link, you could first download our [sample data][datasource], then upload it to a azure container according to the [Upload a block blob][upload_blob] documentation and get the SAS link of the data according to the [Create SAS tokens for blobs in the Azure portal][generate_sas] documentation.

Call `CreateAndTrainMultivariateModel` with the created data feed and extract the model ID from the response. Afterwards, you can get the model info, including the model status, by calling `GetMultivariateModelValue` with the model ID. Wait until the model status is ready.

```C# Snippet:TrainMultivariateModel
private String TrainModel(AnomalyDetectorClient client, string datasource, DateTimeOffset start_time, DateTimeOffset end_time, int max_tryout = 500)
{
    try
    {
        Console.WriteLine("Training new model...");

        Console.WriteLine(String.Format("{0} available models before training.", GetModelNumber(client)));

        ModelInfo request = new ModelInfo(datasource, start_time, end_time);
        request.SlidingWindow = 200;

        TestContext.Progress.WriteLine("Training new model...(it may take a few minutes)");
        AnomalyDetectionModel response = client.TrainMultivariateModel(request);
        String trained_model_id = response.ModelId;
        Console.WriteLine(String.Format("Training model id is {0}", trained_model_id));

        // Wait until the model is ready. It usually takes several minutes
        ModelStatus? model_status = null;
        int tryout_count = 1;
        response = client.GetMultivariateModelValue(trained_model_id);
        while (tryout_count < max_tryout & model_status != ModelStatus.Ready & model_status != ModelStatus.Failed)
        {
            System.Threading.Thread.Sleep(1000);
            response = client.GetMultivariateModelValue(trained_model_id);
            model_status = response.ModelInfo.Status;
            TestContext.Progress.WriteLine(String.Format("try {0}, model_id: {1}, status: {2}.", tryout_count, trained_model_id, model_status));
            tryout_count += 1;
        };

        if (model_status == ModelStatus.Ready)
        {
            Console.WriteLine("Creating model succeeds.");
            Console.WriteLine(String.Format("{0} available models after training.", GetModelNumber(client)));
            return trained_model_id;
        }

        if (model_status == ModelStatus.Failed)
        {
            Console.WriteLine("Creating model failed.");
            Console.WriteLine("Errors:");
            try
            {
                Console.WriteLine(String.Format("Error code: {0}, Message: {1}", response.ModelInfo.Errors[0].Code.ToString(), response.ModelInfo.Errors[0].Message.ToString()));
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

To detect anomalies using your newly trained model, create a private async Task named `BatchDetect`. You will create a new `DetectionRequest`, pass that as a parameter to `DetectMultivariateBatchAnomaly` and get a `DetectionResult` and extract result ID from it. With the result ID, you could get the detection content and detection status by `GetMultivariateBatchDetectionResultValue`. Return the detection content when the detection status is ready.

```C# Snippet:DetectMultivariateAnomaly
private MultivariateDetectionResult BatchDetect(AnomalyDetectorClient client, string datasource, String model_id, DateTimeOffset start_time, DateTimeOffset end_time, int max_tryout = 500)
{
    try
    {
        Console.WriteLine("Start batch detect...");
        MultivariateBatchDetectionOptions request = new MultivariateBatchDetectionOptions(datasource, 10, start_time, end_time);

        TestContext.Progress.WriteLine("Start batch detection, this might take a few minutes...");
        MultivariateDetectionResult response = client.DetectMultivariateBatchAnomaly(model_id, request);
        String result_id = response.ResultId;
        TestContext.Progress.WriteLine(String.Format("result id is: {0}", result_id));

        // get detection result
        MultivariateDetectionResult resultResponse = client.GetMultivariateBatchDetectionResultValue(result_id);
        MultivariateBatchDetectionStatus result_status = resultResponse.Summary.Status;
        int tryout_count = 0;
        while (tryout_count < max_tryout & result_status != MultivariateBatchDetectionStatus.Ready & result_status != MultivariateBatchDetectionStatus.Failed)
        {
            System.Threading.Thread.Sleep(1000);
            resultResponse = client.GetMultivariateBatchDetectionResultValue(result_id);
            result_status = resultResponse.Summary.Status;
            TestContext.Progress.WriteLine(String.Format("try: {0}, result id: {1} Detection status is {2}", tryout_count, result_id, result_status.ToString()));
            Console.Out.Flush();
        }

        if (result_status == MultivariateBatchDetectionStatus.Failed)
        {
            Console.WriteLine("Detection failed.");
            Console.WriteLine("Errors:");
            try
            {
                Console.WriteLine(String.Format("Error code: {}. Message: {}", resultResponse.Results[0].Errors[0].Code.ToString(), resultResponse.Results[0].Errors[0].Message.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Get error message fail: {0}", e.Message));
            }
            return null;
        }
        return resultResponse;
    }
    catch (Exception e)
    {
        Console.WriteLine(String.Format("Detection error. {0}", e.Message));
        throw;
    }
}
```

## Detect last anomalies

To detect anomalies using your newly trained model, create a private async Task named `DetectLast`. You will create a new `LastDetectionRequest`, you could assign how many last points you want to detect in the request. Pass `LastDetectionRequest` as a parameter to `LastDetectionRequest` and get the response. Return the detection content when the detection status is ready.

```C# Snippet:DetectLastMultivariateAnomaly
private MultivariateLastDetectionResult DetectLast(AnomalyDetectorClient client, String model_id)
{
    Console.WriteLine("Start last detect...");
    try
    {
        List<VariableValues> variables = new List<VariableValues>();
        using (StreamReader r = new StreamReader("./samples/data/multivariate_sample_data.json"))
        {
            string json = r.ReadToEnd();
            JsonElement lastDetectVariables = JsonDocument.Parse(json).RootElement.GetProperty("variables");
            foreach (var index in Enumerable.Range(0, lastDetectVariables.GetArrayLength()))
            {
                variables.Add(new VariableValues(lastDetectVariables[index].GetProperty("variable").ToString(), JsonConvert.DeserializeObject<IEnumerable<String>>(lastDetectVariables[index].GetProperty("timestamps").ToString()), JsonConvert.DeserializeObject<IEnumerable<float>>(lastDetectVariables[index].GetProperty("values").ToString())));
            }
        }
        MultivariateLastDetectionOptions request = new MultivariateLastDetectionOptions(variables, 1);
        MultivariateLastDetectionResult response = client.DetectMultivariateLastAnomaly(model_id, request);
        return response;
    }
    catch (Exception ex)
    {
        Console.WriteLine(String.Format("Last detection error. {0}", ex.Message));
        throw;
    }
}
```

## Delete model

To delete a model that you have created previously use `DeleteMultivariateModel` and pass the model ID of the model you wish to delete. You can check the number of models after deletion with `GetModelNumber`.

```C# Snippet:DeleteMultivariateModel
private void DeleteModel(AnomalyDetectorClient client, String model_id)
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
