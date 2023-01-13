# Upload and Validate JMX File

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to upload JMX script and check for validation status using `LoadTestAdministrationClient` client.

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
string endpoint = TestEnvironment.Endpoint;
Uri endpointUrl = new Uri("https://" + endpoint);
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);
```

## Calling BeginUploadTestFile
```C# Snippet:Azure_Developer_LoadTesting_BeginUploadTestFileAsync
string testId = "my-loadtest";

try
{
    // poller object
    FileUploadOperation operation = await loadTestAdministrationClient.BeginUploadTestFileAsync(WaitUntil.Started, testId, "sample.jmx", RequestContent.Create(
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
