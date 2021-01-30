# Polling Long Running Operations
This sample demonstrates the different ways to consume or poll the status of a Text Analytics client Long Running Operation.  It uses the (Analyze Operation)[https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics#run-analyze-operation-asynchronously] as an example

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to run analyze operation for a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Polling using `WaitForCompletionAsync()`

In the below snippet the polling is happening by default when we call `WaitForCompletionAsync()` method.

```C#
		string document = @"We went to Contoso Steakhouse located at midtown NYC last week for a dinner party, 
				and we adore the spot! They provide marvelous food and they have a great menu. The
				chief cook happens to be the owner (I think his name is John Doe) and he is super 
				nice, coming out of the kitchen and greeted us all. We enjoyed very much dining in 
				the place! The Sirloin steak I ordered was tender and juicy, and the place was impeccably
				clean. You can even pre-order from their online menu at www.contososteakhouse.com, 
				call 312-555-0176 or send email to order@contososteakhouse.com! The only complaint 
				I have is the food didn't come fast enough. Overall I highly recommend it!";

		var batchDocuments = new List<string> { document };

		AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
		{
				KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
				EntitiesTaskParameters = new EntitiesTaskParameters(),
				PiiTaskParameters = new PiiTaskParameters(),
				DisplayName = "AnalyzeOperationSample"
		};

		AnalyzeOperation operation = client.StartAnalyzeOperationBatch(batchDocuments, operationOptions);

		await operation.WaitForCompletionAsync();

		AnalyzeOperationResult resultCollection = operation.Value;

		RecognizeEntitiesResultCollection entitiesResult = resultCollection.Tasks.EntityRecognitionTasks[0].Results;

		ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

		RecognizePiiEntitiesResultCollection piiResult = resultCollection.Tasks.EntityRecognitionPiiTasks[0].Results;
```

By default the polling happens every 1 second when there is no `pollingInterval` sent.


## Polling using `WaitForCompletionAsync(TimeSpan pollingInterval)`

For a custom `pollingInterval`, we will call `WaitForCompletionAsync()` method with `TimeSpan` object as an argument.

```C#
		string document = @"We went to Contoso Steakhouse located at midtown NYC last week for a dinner party, 
				and we adore the spot! They provide marvelous food and they have a great menu. The
				chief cook happens to be the owner (I think his name is John Doe) and he is super 
				nice, coming out of the kitchen and greeted us all. We enjoyed very much dining in 
				the place! The Sirloin steak I ordered was tender and juicy, and the place was impeccably
				clean. You can even pre-order from their online menu at www.contososteakhouse.com, 
				call 312-555-0176 or send email to order@contososteakhouse.com! The only complaint 
				I have is the food didn't come fast enough. Overall I highly recommend it!";

		var batchDocuments = new List<string> { document };

		AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
		{
				KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
				EntitiesTaskParameters = new EntitiesTaskParameters(),
				PiiTaskParameters = new PiiTaskParameters(),
				DisplayName = "AnalyzeOperationSample"
		};

		AnalyzeOperation operation = client.StartAnalyzeOperationBatch(batchDocuments, operationOptions);

		TimeSpan pollingInterval = new TimeSpan(1000);

		await operation.WaitForCompletionAsync(pollingInterval);

		AnalyzeOperationResult resultCollection = operation.Value;

		RecognizeEntitiesResultCollection entitiesResult = resultCollection.Tasks.EntityRecognitionTasks[0].Results;

		ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

		RecognizePiiEntitiesResultCollection piiResult = resultCollection.Tasks.EntityRecognitionPiiTasks[0].Results;
```

## Polling using `UpdateStatusAsync()`

This method is for users who want to have intermittent code paths during the polling process. 

```C#
		string document = @"We went to Contoso Steakhouse located at midtown NYC last week for a dinner party, 
				and we adore the spot! They provide marvelous food and they have a great menu. The
				chief cook happens to be the owner (I think his name is John Doe) and he is super 
				nice, coming out of the kitchen and greeted us all. We enjoyed very much dining in 
				the place! The Sirloin steak I ordered was tender and juicy, and the place was impeccably
				clean. You can even pre-order from their online menu at www.contososteakhouse.com, 
				call 312-555-0176 or send email to order@contososteakhouse.com! The only complaint 
				I have is the food didn't come fast enough. Overall I highly recommend it!";

		var batchDocuments = new List<string> { document };

		AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
		{
				KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
				EntitiesTaskParameters = new EntitiesTaskParameters(),
				PiiTaskParameters = new PiiTaskParameters(),
				DisplayName = "AnalyzeOperationSample"
		};

		AnalyzeOperation operation = client.StartAnalyzeOperationBatch(batchDocuments, operationOptions);

		TimeSpan pollingInterval = new TimeSpan(1000);

		while (true)
		{
			await healthOperation.UpdateStatusAsync();
			if (healthOperation.HasCompleted)
			{
				// TIP - Add logging, max wait time, or any other intermittent code path. 
				break;
			}

			await Task.Delay(pollingInterval);
		}

		AnalyzeOperationResult resultCollection = operation.Value;

		RecognizeEntitiesResultCollection entitiesResult = resultCollection.Tasks.EntityRecognitionTasks[0].Results;

		ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

		RecognizePiiEntitiesResultCollection piiResult = resultCollection.Tasks.EntityRecognitionPiiTasks[0].Results;
```

To see the full example source files, see:

* [Automatic Polling AnalyzeOperation ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationAsync_AutomaticPolling.cs)
* [Manual Polling AnalyzeOperation ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationAsync_ManualPolling.cs)
* [Automatic Polling HealthcareOperation ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareAsync_AutomaticPolling.cs)
* [Manual Polling HealthcareOperation ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareAsync_ManualPolling.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
