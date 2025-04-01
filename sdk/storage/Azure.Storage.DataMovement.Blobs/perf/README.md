# Azure Storage DataMovement Blobs performance tests

The assets in this area comprise a set of performance tests for the [Azure Storage Blobs Data Movement library for .NET](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Blobs) and its associated ecosystem.  The artifacts in this library are intended to be used primarily with the Azure SDK engineering system's testing infrastructure, but may also be run as stand-alone applications from the command line.

## Running tests locally
There are two perf test projects:
- Track2 (default): sdk\storage\Azure.Storage.DataMovement.Blobs\perf\Azure.Storage.DataMovement.Blobs.Perf\Azure.Storage.DataMovement.Blobs.Perf.csproj
- Track1: sdk\storage\Azure.Storage.DataMovement.Blobs\perf\Microsoft.Azure.Storage.DataMovement.Perf\Microsoft.Azure.Storage.DataMovement.Perf.csproj

First, build the project either via Visual Studio or the command line. For best results, build the `Release` build but the `Debug` will also work and allow for debugging.
```
dotnet build -c Release -f <supported-framework> <project>
```

Setup the account you want to use for testing. Note Track2 tests use OAuth using a DefaultAzureCredential, meaning you will need permission to the Storage account as well as a way to authenticate (Visual Studio, Azure CLI, etc.)
```
set AZURE_STORAGE_ACCOUNT_NAME=<account-name>
# Only needed for Track1 tests
set AZURE_STORAGE_ACCOUNT_KEY=<account-key>
```

Then run the desired test via the command line.
```
dotnet run -c Release -f <supported-framework> --no-build --project sdk\storage\Azure.Storage.DataMovement.Blobs\perf\Azure.Storage.DataMovement.Blobs.Perf\Azure.Storage.DataMovement.Blobs.Perf.csproj -- (UploadDirectory|DownloadDirectory|CopyDirectory) <test-options>
```

Current test options (non-exahustive list):
- `-c`, `--count`: The number of files in each transfer (default: 10)
- `-s`, `--size`: The size of each file (default: 1024)
- `-d`, `--duration`: The duration of the test (default: 10)
- `--councurrency`: The concurrency limit for Data Movement
- `--initial-transfer-size`: The initial transfer size of the transfer (Track2 only)
- `--chunk-size`: The chunk size to use during the transfer
- `--disable-checkpointer`: Disable the checkpointer (Track2 only)
- `--help`: See full list of options for that particular test

### Running in Visual Studio
You can also run these tests directly through Visual Studio which can be helpful for debugging or profiling. You just need to setup the run profile for either project to include the command line arguments `(UploadDirectory|DownloadDirectory|CopyDirectory) <test-options>` and the enviorment variables.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for more information.
