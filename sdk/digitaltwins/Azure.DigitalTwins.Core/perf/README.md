# Azure Digital Twins performance tests

The assets in this area comprise a set of performance tests for the [Azure DigitalTwins client library for .NET](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core) and its associated ecosystem. The artifacts in this library are intended to be used primarily with the Azure SDK engineering system's testing infrastructure, but may also be run as stand-alone applications from the command-line.

You can learn more about the project structure [here](https://github.com/Azure/azure-sdk-for-net/wiki/Writing-performance-tests-for-Client-libraries).
## Purpose
Performance Testing using performance framework, in general, allows you to test throughput and latency offered to the customers via the SDKs.

Major Benefit:
- Performance Regressions are caught prior to release. Regressions can come in from new code changes that get merged between two releases, new dependencies that get introduced or old dependencies that are upgraded.

The Digital Twins performance tests will be plugged into performance automation pipelines automatically and will run the tests regularly to scan for any performance issues that should be fixed before releasing the SDK.

## Perf test scenarios

### QueryDigitalTwins

This scenario tests API calls to the DigitalTwins service to query for Twins and Relationships.
The `GlobalTestSetupAsync` method override will create a single model that is used for all instances of the parallel test runs. This method is only invoked once and will not be called during the parallel test run across all instances of the test.
The `SetupAsync` method override will create multiple Twins that is configurable using the input options. Each test will create Twins using a unique test Id and will only query that subset during each run.

## Running the tests

Build a performance test project
```dotnetcli
dotnet run -c Release -f <supported-framework> --no-build -p <path/to/project/file> -- [parameters needed for the test]
```

Run the executable output of a project
```dotnetcli
dotnet run -c Release -f <supported-framework> --no-build -p <path/to/project/file> -- [parameters needed for the test]
```

\<supported-framework\> can be one of net7.0, net6.0, or net461. Note the -- before any custom parameters to pass. This prevents dotnet from trying to handle any ambiguous command line switches.

You should use the scenario test class names as the first parameter that is needed for running the test.

## Contributing
This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
