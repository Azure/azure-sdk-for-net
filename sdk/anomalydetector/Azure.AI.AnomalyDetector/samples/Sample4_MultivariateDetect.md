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
Uri dataSource = new Uri(TestEnvironment.DataSource);

Uri endpointUri = new Uri(endpoint);
AzureKeyCredential credential = new AzureKeyCredential(apiKey);

//create client
AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);
```

## Train the model

Create a new private async task as below to handle training your model. You will use `CreateAndTrainMultivariateModel` to train the model and `GetMultivariateModelValue` to check when training is complete.

You could add the data source, along with start time and end time to a `ModelInfo` object to create a data feed. The data source is a shared access signature(SAS) link in the format https://\[placeholder\]/. To generate the datasource link, you could first download our [sample data][datasource], then upload it to a azure container according to the [Upload a block blob][upload_blob] documentation and get the SAS link of the data according to the [Create SAS tokens for blobs in the Azure portal][generate_sas] documentation.

Call `CreateAndTrainMultivariateModel` with the created data feed and extract the model ID from the response. Afterwards, you can get the model info, including the model status, by calling `GetMultivariateModelValue` with the model ID. Wait until the model status is ready.

```C# Snippet:TrainMultivariateModel
private string TrainModel(AnomalyDetectorClient client, Uri dataSource, DateTimeOffset startTime, DateTimeOffset endTime, int maxTryout = 500)
{
    try
    {
        Console.WriteLine("Training new model...");

        Console.WriteLine($"{GetModelNumber(client)} available models before training.");

        ModelInfo modelInfo = new ModelInfo(dataSource, startTime, endTime)
        {
            SlidingWindow = 200
        };

        Console.WriteLine("Training new model...(it may take a few minutes)");
        AnomalyDetectionModel response = client.GetMultivariateClient().TrainMultivariateModel(modelInfo);
        string trainedModelId = response.ModelId.ToString();
        Console.WriteLine($"Training model id is {trainedModelId}");

        // Wait until the model is ready. It usually takes several minutes
        ModelStatus? modelStatus = null;
        int tryoutCount = 1;
        response = client.GetMultivariateClient().GetMultivariateModel(trainedModelId);
        while (tryoutCount < maxTryout & modelStatus != ModelStatus.Ready & modelStatus != ModelStatus.Failed)
        {
            System.Threading.Thread.Sleep(1000);
            response = client.GetMultivariateClient().GetMultivariateModel(trainedModelId);
            modelStatus = response.ModelInfo.Status;
            TestContext.Progress.WriteLine($"try {tryoutCount}, model id: {trainedModelId}, status: {modelStatus}.");
            tryoutCount += 1;
        };

        if (modelStatus == ModelStatus.Ready)
        {
            Console.WriteLine("Creating model succeeds.");
            Console.WriteLine($"{GetModelNumber(client)} available models after training.");
            return trainedModelId;
        }

        if (modelStatus == ModelStatus.Failed)
        {
            Console.WriteLine("Creating model failed.");
            Console.WriteLine("Errors:");
            ErrorResponse error = response.ModelInfo.Errors[0];
            try
            {
                Console.WriteLine($"Error code: {error.Code}, Message: {error.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Get error message fail: {e.Message}");
            }
        }
        return null;
    }
    catch (Exception e)
    {
        Console.WriteLine($"Train error. {e.Message}");
        throw;
    }
}
```

## Detect anomalies

To detect anomalies using your newly trained model, create a private async Task named `BatchDetect`. You will create a new `DetectionRequest`, pass that as a parameter to `DetectMultivariateBatchAnomaly` and get a `DetectionResult` and extract result ID from it. With the result ID, you could get the detection content and detection status by `GetMultivariateBatchDetectionResultValue`. Return the detection content when the detection status is ready.

```C# Snippet:DetectMultivariateAnomaly
private MultivariateDetectionResult BatchDetect(AnomalyDetectorClient client, Uri datasource, string modelId, DateTimeOffset startTime, DateTimeOffset endTime, int maxTryout = 500)
{
    try
    {
        Console.WriteLine("Start batch detect...");
        MultivariateBatchDetectionOptions request = new MultivariateBatchDetectionOptions(datasource, startTime, endTime)
        {
            TopContributorCount = 10
        };

        Console.WriteLine("Start batch detection, this might take a few minutes...");
        MultivariateDetectionResult response = client.GetMultivariateClient().DetectMultivariateBatchAnomaly(modelId, request);
        Guid resultId = response.ResultId;
        Console.WriteLine($"result id is: {resultId.ToString()}");

        // get detection result
        MultivariateDetectionResult resultResponse = client.GetMultivariateClient().GetMultivariateBatchDetectionResult(resultId);
        MultivariateBatchDetectionStatus resultStatus = resultResponse.Summary.Status;
        int tryoutCount = 0;
        while (tryoutCount < maxTryout & resultStatus != MultivariateBatchDetectionStatus.Ready & resultStatus != MultivariateBatchDetectionStatus.Failed)
        {
            System.Threading.Thread.Sleep(1000);
            resultResponse = client.GetMultivariateClient().GetMultivariateBatchDetectionResult(resultId);
            resultStatus = resultResponse.Summary.Status;
            Console.WriteLine($"try: {tryoutCount}, result id: {resultId} Detection status is {resultStatus}");
        }

        if (resultStatus == MultivariateBatchDetectionStatus.Failed)
        {
            Console.WriteLine("Detection failed.");
            Console.WriteLine("Errors:");
            ErrorResponse error = resultResponse.Results[0].Errors[0];
            Console.WriteLine($"Error code: {error.Code}. Message: {error.Message}");
            return null;
        }

        return resultResponse;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Detection error. {ex.Message}");
        throw;
    }
}
```

## Detect last anomalies

To detect anomalies using your newly trained model, create a private async Task named `DetectLast`. You will create a new `LastDetectionRequest`, you could assign how many last points you want to detect in the request. Pass `LastDetectionRequest` as a parameter to `LastDetectionRequest` and get the response. Return the detection content when the detection status is ready.

```C# Snippet:DetectLastMultivariateAnomaly
private MultivariateLastDetectionResult DetectLast(AnomalyDetectorClient client, string modelId)
{
    Console.WriteLine("Start last detect...");
    try
    {
        List<VariableValues> variables = new List<VariableValues>();
        using (StreamReader r = new StreamReader("./samples/data/multivariate_sample_data.json"))
        {
            string json = r.ReadToEnd();
            JsonElement lastDetectVariables = JsonDocument.Parse(json).RootElement.GetProperty("variables");
            foreach (JsonElement item in lastDetectVariables.EnumerateArray())
            {
                variables.Add(new VariableValues(item.GetProperty("variable").ToString(), JsonConvert.DeserializeObject<IEnumerable<string>>(item.GetProperty("timestamps").ToString()), JsonConvert.DeserializeObject<IEnumerable<float>>(item.GetProperty("values").ToString())));
            }
        }
        MultivariateLastDetectionOptions request = new MultivariateLastDetectionOptions(variables);
        MultivariateLastDetectionResult response = client.GetMultivariateClient().DetectMultivariateLastAnomaly(modelId, request);
        return response;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Last detection error. {ex.Message}");
        throw;
    }
}
```

## Delete model

To delete a model that you have created previously use `DeleteMultivariateModel` and pass the model ID of the model you wish to delete. You can check the number of models after deletion with `GetModelNumber`.

```C# Snippet:DeleteMultivariateModel
private void DeleteModel(AnomalyDetectorClient client, string modelId)
{
    client.GetMultivariateClient().DeleteMultivariateModel(modelId);
    int modelNumber = GetModelNumber(client);
    Console.WriteLine($"{modelNumber} available models after deletion.");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/README.md
[datasource]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/data/sample_data_20_3000.zip
[upload_blob]: https://learn.microsoft.com/azure/storage/blobs/storage-quickstart-blobs-portal#upload-a-block-blob
[generate_sas]: https://learn.microsoft.com/azure/cognitive-services/translator/document-translation/create-sas-tokens?tabs=Containers#create-sas-tokens-for-blobs-in-the-azure-portal
