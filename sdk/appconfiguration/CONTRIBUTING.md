# Contributing

Thank you for your interest in contributing to the Azure App Configuration client library. As an open source effort, we're excited to welcome feedback and contributions from the community. A great first step in sharing your thoughts and understanding where help is needed would be to take a look at the [open issues][open_issues].

Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

## Code of conduct

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

## Getting started

Before working on a contribution, it would be beneficial to familiarize yourself with the process and guidelines used for the Azure SDKs so that your submission is consistent with the project standards and is ready to be accepted with fewer changes requested. In particular, it is recommended to review:

 - [Azure SDK README][sdk_readme], to learn more about the overall project and processes used.
 - [Azure SDK Design Guidelines][sdk_design_guidelines], to understand the general guidelines for the Azure SDK across all languages and platforms.
 - [Azure SDK Contributing Guide][sdk_contributing], for information about how to onboard and contribute to the overall Azure SDK ecosystem.

## Azure SDK Design Guidelines for .NET

These libraries follow the [Azure SDK Design Guidelines for .NET][sdk_design_guidelines_dotnet] and share a number of core features such as HTTP retries, logging, transport protocols, authentication protocols, etc., so that once you learn how to use these features in one client library, you will know how to use them in other client libraries. You can learn about these shared features in the [Azure.Core README][sdk_dotnet_code_readme].

## Public API changes

To update [`Azure.Data.AppConfiguration.netstandard2.0.cs`][azconfig_api] after making changes to the public API, execute [`./eng/scripts/Export-API.ps1`][azconfig_export_api].

## Testing

### Frameworks

We use [NUnit 3][nunit] as our testing framework.

[Azure.Core.TestFramework's testing framework][core_tests] provides a set of reusable primitives that simplify writing tests for new Azure SDK libraries.

### Sync/Async testing

We expose all of our APIs with both sync and async variants. To avoid writing each of our tests twice, we automatically rewrite our async API calls into their sync equivalents. Simply write your tests using only async APIs and call `InstrumentClient` on any of our client objects. The test framework will wrap the client with a proxy that forwards everything to the sync overloads. Please note that a number of our helpers will automatically instrument clients they provide you. Visual Studio's test runner will show `*TestClass(True)` for the async variants and `*TestClass(False)` for the sync variants.

### Recorded tests

Our testing framework supports recording service requests made during a unit test so they can be replayed later. You can set the `AZURE_TEST_MODE` environment variable to `Playback` to run previously recorded tests, `Record` to record or re-record tests, and `Live` to run tests against the live service.

Properly supporting recorded tests does require a few extra considerations. All random values should be obtained via `this.Recording.Random` since we use the same seed on test playback to ensure our client code generates the same "random" values each time. You can't share any state between tests or rely on ordering because you don't know the order they'll be recorded or replayed. Any sensitive values are redacted via the [`ConfigurationRecordedTestSanitizer`][tests_sanitized].

### Running tests

The easiest way to run the tests is via Visual Studio's unit test runner.

You can also run tests via the command line using `dotnet test`, but that will run tests for all supported platforms simultaneously and intermingle their output. You can run the tests for just one platform with `dotnet test -f net8.0` or `dotnet test -f net462`.

The recorded tests are run automatically on every pull request. Live tests are run nightly. Contributors with write access can ask Azure DevOps to run the live tests against a pull request by commenting `/azp run net - appconfiguration - tests` in the PR.

### Samples

Our samples are structured as unit tests so we can easily verify they're up to date and working correctly. These tests aren't recorded and make minimal use of test infrastructure to keep them easy to read.

## Development history

For additional insight and context, the development, release, and issue history for the Azure Event Hubs client library is available in read-only form, in its previous location, the [Azure App Configuration .NET repository](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/appconfiguration).

<!-- LINKS -->
[azconfig_root]: ../../sdk/appconfiguration
[azconfig_api]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/Azure.Data.AppConfiguration/api/Azure.Data.AppConfiguration.netstandard2.0.cs
[azconfig_export_api]: https://github.com/Azure/azure-sdk-for-net/blob/main/eng/scripts/Export-API.ps1
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[core_tests]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework
[nunit]: https://github.com/nunit/docs/wiki
[open_issues]: https://github.com/Azure/azure-sdk-for-net/issues?utf8=%E2%9C%93&q=is%3Aopen+is%3Aissue+label%3AClient+label%3AAzConfig
[sdk_readme]: https://github.com/Azure/azure-sdk
[sdk_contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/CONTRIBUTING.md
[sdk_design_guidelines]: https://azure.github.io/azure-sdk/general_introduction.html
[sdk_design_guidelines_dotnet]: https://azure.github.io/azure-sdk/dotnet_introduction.html
[sdk_dotnet_code_readme]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md
[email_opencode]: mailto:opencode@microsoft.com
