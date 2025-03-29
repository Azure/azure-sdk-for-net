# Recognizing Personally Identifiable Information in Documents

This sample demonstrates how to eradicate Personally Identifiable Information (PII) from one or more native documents.

A native document refers to the file format used to create the original document such as Microsoft Word (docx) or a portable document file (pdf). Native document support eliminates the need for text preprocessing before using Azure AI Language resource capabilities. 

Language resource needs granted access to your storage account
``` private static readonly HttpClient httpClient = new HttpClient();
    private const string CognitiveServicesUrl = "https://<endpointname>.cognitiveservices.azure.com/language/analyze-documents/jobs?api-version=2024-11-15-preview";
    private const string SourceSasUri = "<containersasuri>";
    private const string DestinationSasUri = "containersasuri";
```

Iterate through the files in the source container, filter out PDF and DOCX files, append the file name to the source SAS URI, and then invoke the cognitive service.
``` private static async Task ProcessSourceContainerAsync()
    {
        BlobContainerClient sourceContainer = new BlobContainerClient(new Uri(SourceSasUri));
        await foreach (var blobItem in sourceContainer.GetBlobsAsync())
        {
            if (blobItem.Name.EndsWith(".pdf") || 
                blobItem.Name.EndsWith(".docx"))
            {
                string blobUri = sourceContainer.Uri.ToString().Replace("?", "/" + Uri.EscapeDataString(blobItem.Name) + "?");
                await AnalyzeDocumentAsync(blobUri);
                await Task.Delay(TimeSpan.FromSeconds(2));
                Console.WriteLine(blobItem.Name);
            }
        }
    }
```

Call the service to eradicate the PII from document
```
    private static async Task AnalyzeDocumentAsync(string sourceUri)
    {
        var requestBody = new
        {
            displayName = "Document PII Redaction example",
            analysisInput = new
            {
                documents = new[]
                {
                    new
                    {
                        language = "en-US",
                        id = "Output-1",
                        source = new { location = sourceUri },
                        target = new { location = DestinationSasUri }
                    }
                }
            },
            tasks = new[]
            {
                new
                {
                    kind = "PiiEntityRecognition",
                    taskName = "Redact PII Task 1",
                    parameters = new
                    {
                        redactionPolicy = new { policyKind = "EntityMask" },
                        excludeExtractionData = false,
                        piiCategories = new [] {
                            "Person",
                            "Organization", 
                            "PersonType", 
                            "PhoneNumber",
                            "Organization", 
                            "Address",
                            "Email",
                            "URL",
                            "IPAddress",
                            "DateTime",
                            "Date",
                            "Age",
                        }
                    }
                }
            }
        };

        string jsonContent = JsonSerializer.Serialize(requestBody);
        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        content.Headers.Add("Ocp-Apim-Subscription-Key", "<key>");
        HttpResponseMessage response = await httpClient.PostAsync(CognitiveServicesUrl, content);
        foreach (var header in response.Headers)
        {
            Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
        }
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Success: " + response.Headers);
        }
        else
        {
           
            Console.WriteLine("Failed: " + response.StatusCode);
        }
    }
```

	
    static async Task Main()
    {
        await ProcessSourceContainerAsync();
    }
```

}


