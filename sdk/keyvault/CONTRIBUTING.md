# Contributing

Thank you for your interest in contributing to the Azure Key Vault client libraries. As an open source effort, we're excited to welcome feedback and contributions from the community. A great first step in sharing your thoughts and understanding where help is needed would be to take a look at the [open issues][open_issues].

Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

## Code of conduct

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Getting started

Before working on a contribution, it would be beneficial to familiarize yourself with the process and guidelines used for the Azure SDKs so that your submission is consistent with the project standards and is ready to be accepted with fewer changes requested. In particular, it is recommended to review:

- [Azure SDK README][sdk_readme], to learn more about the overall project and processes used.
- [Azure SDK Design Guidelines][sdk_design_guidelines], to understand the general guidelines for the Azure SDK across all languages and platforms.

## Azure SDK Design Guidelines for .NET

These libraries follow the [Azure SDK Design Guidelines for .NET][sdk_design_guidelines_dotnet] and share a number of core features such as HTTP retries, logging, transport protocols, authentication protocols, etc., so that once you learn how to use these features in one client library, you will know how to use them in other client libraries. You can learn about these shared features in the [Azure.Core README][sdk_dotnet_code_readme].

## Public API changes

To update public API documentation after making changes to the public API, execute `./eng/Export-API.ps1`.

## Testing

### Frameworks

We use [NUnit 3][nunit] as our testing framework.

[Azure.Core.TestFramework's testing framework][core_tests] provides a set of reusable primitives that simplify writing tests for new Azure SDK libraries.

### Sync/Async testing

We expose all of our APIs with both sync and async variants. To avoid writing each of our tests twice, we automatically rewrite our async API calls into their sync equivalents. Simply write your tests using only async APIs and call `InstrumentClient` on any of our client objects. The test framework will wrap the client with a proxy that forwards everything to the sync overloads. Please note that a number of our helpers will automatically instrument clients they provide you. Visual Studio's test runner will show `*TestClass(True)` for the async variants and `*TestClass(False)` for the sync variants.

### Recorded tests

Our testing framework supports recording service requests made during a unit test so they can be replayed later. You can set the `AZURE_TEST_MODE` environment variable to `Playback` to run previously recorded tests, `Record` to record or re-record tests, and `Live` to run tests against the live service.

Properly supporting recorded tests does require a few extra considerations. All random values should be obtained via `this.Recording.Random` since we use the same seed on test playback to ensure our client code generates the same "random" values each time. You can't share any state between tests or rely on ordering because you don't know the order they'll be recorded or replayed.

#### Re-recording tests

When re-recording tests, you should first record the latest target framework, followed by the latest target .NET Framework version. There are some tests that are specific to .NET Framework that will not run during the first phase.

Using Visual Studio, in Test Explorer:

1. Select all projects targeting the latest target framework e.g., 'net7.0'.
2. Click the `Run` button (default binding: `Ctrl+R, T`).
3. After changing the api-version, expect a lot of failures. In that case, click the `Run failed tests` button (default binding: `Ctrl+R, F`).
4. Select the latest .NET Framework target e.g., `net47`, for `Azure.Security.KeyVault.Keys.Tests`.
5. Repeat steps 2 and 3.

After re-recording tests, you need to [sync them to the assets repo](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/documentation/asset-sync/README.md).

### Running tests

The easiest way to run and debug the tests is via Visual Studio's unit test runner.

You can also run tests via the command line using `dotnet test`, but that will run tests for all supported platforms simultaneously and intermingle their output. You can run the tests for just one platform with `dotnet test -f net8.0` or `dotnet test -f net462`.

The recorded tests are run automatically on every pull request. Live tests are run nightly. Contributors with write access can ask Azure DevOps to run the live tests against a pull request by commenting `/azp run net - keyvault - tests` in the PR.

### Live Test Resources

Before running or recording live tests you need to create [live test resources][live_tests]. In addition to the standard parameters to `New-TestResources.ps1`, you can pass additional parameters for Azure Key Vault:

```powershell
eng\common\TestResources\New-TestResources.ps1 `
  -ServiceDirectory 'keyvault' `
  -AdditionalParameters @{
    # Enable Managed HSM provisioning and testing.
    # Disabled by default due to limitations: https://github.com/Azure/azure-sdk-for-net/issues/16531
    enableHsm = $true
  }
```

If recording tests, secrets will be sanitized from saved recordings. If you will be working on contributions over time, you should consider persisting these variables.

### Samples

Our samples are structured as unit tests so we can easily verify they're up to date and working correctly. These tests aren't recorded and make minimal use of test infrastructure to keep them easy to read.

[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[core_tests]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework
[live_tests]: https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md
[nunit]: https://github.com/nunit/docs/wiki
[open_issues]: https://github.com/Azure/azure-sdk-for-net/issues?utf8=%E2%9C%93&q=is%3Aopen+is%3Aissue+label%3AClient+label%3AKeyVault
[sdk_design_guidelines_dotnet]: https://azure.github.io/azure-sdk/dotnet_introduction.html
[sdk_design_guidelines]: https://azure.github.io/azure-sdk/general_introduction.html
[sdk_readme]: https://github.com/Azure/azure-sdk
[sdk_dotnet_code_readme]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md
