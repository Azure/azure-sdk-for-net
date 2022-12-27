# Training a Text Analytics project.
This sample demonstrates how to train a text analytics project, using a cognitive services for language resource.

## Create a `TextAuthoringClient`
To create a new `TextAuthoringClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAuthoringClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
TextAuthoringClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Training the project
To train a project, call `Train` on the `TextAuthoringClient`, which returns a `Response` object with the project training jobId, creation time, status, and more.

```C# Snippet:Train a Project
var training_parameters = new
{
    modelLabel = "<trainedModelName>", //Can take any name you like
    trainingConfigVersion = "latest",
    evaluationOptions = new
    {
        kind = "percentage",
        testingSplitPercentage = 20, //Tune the percentage for your training dataset
        trainingSplitPercentage = 80
    }
};

var operation = client.Train(WaitUntil.Completed, "<projectName>", RequestContent.Create(training_parameters));
BinaryData response = operation.WaitForCompletion();
```

You can then check whether the operation was successful by checking the `response.status`.
```C# Snippet:Print Training Response
JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
if (result.GetProperty("status").ToString().Equals("succeeded"))
    Console.WriteLine("Project training succeeded!");
else
    Console.WriteLine("Project training failed, check \"result\" error message for more information");
```

**Note:** The training process usually takes a relatively long time, so it is likely that you would not want to use ```operation.WaitForCompletion();``` for the training operation, but rather use the ```TrainAsync``` version.

See the [README][README] of the Text Analytics Authoring client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics.Authoring/README.md