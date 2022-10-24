# Upload JMX File

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

You can create a LoadTestclient and call the `UploadTestFile` method from SubClient `LoadTestAdministrationClient`

## Create LoadTestAdministrationClient
```C# Snippet:Azure_Developer_LoadTesting_CreatingClient
string endpoint = TestEnvironment.Endpoint;
TokenCredential credential = TestEnvironment.Credential;

// creating LoadTesting Client
LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

// getting appropriate Subclient
LoadTestAdministrationClient loadTestAdministrationClient = loadTestingClient.getLoadTestAdministration();
```

## Calling UploadTestFile
```C# Snippet:Azure_Developer_LoadTesting_UploadTestFile
// provide unique identifier for your test
string testId = "my-test-id";

// provide unique identifier for your file
string fileId = "my-file-id";

try
{
    // uploading file
    Response response = loadTestAdministrationClient.UploadTestFile(testId, fileId, File.OpenRead(
        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sample.jmx")
        ));

    // if the file is uploaded successfully, printing response
    Console.WriteLine(response.Content);
}
catch (Exception e)
{
    Console.WriteLine(String.Format("Error : ", e.Message));
}
```
To see the full example source files, see:
* [Sample2_UploadTestFile.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/tests/Samples/Sample2_UploadTestFile.cs)
