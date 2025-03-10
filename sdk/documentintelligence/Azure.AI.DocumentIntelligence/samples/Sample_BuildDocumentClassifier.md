# Build a document classifier

This sample demonstrates how to build a document classifier with your own data. A document classifier can accurately detect and identify documents you process within your application.

Please note that document classifiers can also be created using a graphical user interface such as the [Document Intelligence Studio][di_studio].

To get started you'll need an Azure AI services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

## Creating a `DocumentIntelligenceAdministrationClient`

To create a new `DocumentIntelligenceAdministrationClient` you need the endpoint and credentials from your resource. In the sample below you'll make use of identity-based authentication by creating a `DefaultAzureCredential` object.

You can set `endpoint` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceAdministrationClient
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), credential);
```

## Build a document classifier

Document classifiers are trained with your own data, so they're tailored to your documents.

After building, a `DocumentClassifierDetails` instance is returned indicating the document types the classifier will recognize.

```C# Snippet:DocumentIntelligenceSampleBuildClassifier
// For this sample, you can use the training documents found in the `classifierTrainingFiles` folder.
// Upload the documents to your storage container and then generate a container SAS URL. Note
// that a container URI without SAS is accepted only when the container is public or has a
// managed identity configured.

// For instructions to set up documents for training in an Azure Blob Storage Container, please see:
// https://aka.ms/azsdk/formrecognizer/buildclassifiermodel

string classifierId = "<classifierId>";
Uri blobContainerUri = new Uri("<blobContainerUri>");
var sourceA = new BlobContentSource(blobContainerUri) { Prefix = "IRS-1040-A/train" };
var sourceB = new BlobContentSource(blobContainerUri) { Prefix = "IRS-1040-B/train" };
var docTypeA = new ClassifierDocumentTypeDetails(sourceA);
var docTypeB = new ClassifierDocumentTypeDetails(sourceB);
var docTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
{
    { "IRS-1040-A", docTypeA },
    { "IRS-1040-B", docTypeB }
};

var options = new BuildClassifierOptions(classifierId, docTypes);

Operation<DocumentClassifierDetails> operation = await client.BuildClassifierAsync(WaitUntil.Completed, options);
DocumentClassifierDetails classifier = operation.Value;

Console.WriteLine($"Classifier ID: {classifier.ClassifierId}");
Console.WriteLine($"Created on: {classifier.CreatedOn}");

Console.WriteLine("Document types the classifier can recognize:");
foreach (KeyValuePair<string, ClassifierDocumentTypeDetails> docType in classifier.DocumentTypes)
{
    Console.WriteLine($"  {docType.Key}");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
[di_studio]: https://aka.ms/azsdk/formrecognizer/formrecognizerstudio
