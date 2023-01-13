# Upload and Validate JMX File

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

The sample below demonstrates how to upload JMX script and check for validation status using `LoadTestAdministrationClient` client.

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreateAdminClient
string endpoint = TestEnvironment.Endpoint;
Uri enpointUrl = new Uri("https://"+endpoint);
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting Administration Client
LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(enpointUrl, credential);
```

## Calling BeginUploadTestFile
```C# Snippet:Azure_Developer_LoadTesting_BeginUploadTestFile
string testId = "my-loadtest";

try
{
    // poller object
    FileUploadOperation operation = loadTestAdministrationClient.BeginUploadTestFile(WaitUntil.Started, testId, "sample.jmx", RequestContent.Create(
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sample.jmx")
        ));

    // get the intial reponse for uploading file
    Response initialResponse = operation.GetRawResponse();
    Console.WriteLine(initialResponse.Content.ToString());

    // run lro to check the validation of file uploaded
    operation.WaitForCompletion();

    // printing final response
    Response validatedFileResponse = operation.GetRawResponse();
    Console.WriteLine(validatedFileResponse.Content.ToString());
}
catch (Exception ex) {
    Console.WriteLine(ex.Message);
}
```
