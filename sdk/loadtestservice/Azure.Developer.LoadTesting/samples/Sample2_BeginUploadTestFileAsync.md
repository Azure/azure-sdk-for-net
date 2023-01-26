# Upload and Validate JMX File

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to upload JMX script and check for validation status using `LoadTestAdministrationClient` client.

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
// The data-plane endpoint is obtained from Control Plane APIs with "https://"
// To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
TokenCredential credential = new DefaultAzureCredential();

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);
```

## Calling BeginUploadTestFile
```C# Snippet:Azure_Developer_LoadTesting_BeginUploadTestFileAsync
string testId = "my-loadtest";

try
{
    // poller object
    FileUploadOperation operation = await loadTestAdministrationClient.UploadTestFileAsync(WaitUntil.Started, testId, "sample.jmx", RequestContent.Create(
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sample.jmx")
        ));

    // get the intial reponse for uploading file
    Response initialResponse = operation.GetRawResponse();
    Console.WriteLine(initialResponse);

    // run lro to check the validation of file uploaded
    await operation.WaitForCompletionAsync();

    // printing final response
    Response validatedFileResponse = operation.GetRawResponse();
    Console.WriteLine(validatedFileResponse);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
