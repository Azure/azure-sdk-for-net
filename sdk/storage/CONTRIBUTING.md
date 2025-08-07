# Contributing

This project welcomes contributions and suggestions.  Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring that
you have the right to, and actually do, grant us the rights to use your
contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].  For
more information see the [Code of Conduct FAQ][coc_faq] or contact
[opencode@microsoft.com][coc_contact] with any additional questions or
comments.

## Azure SDK Design Guidelines for .NET

These libraries follow the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html)
and share a number of core features such as HTTP retries, logging, transport
protocols, authentication protocols, etc., so that once you learn how to use
these features in one client library, you will know how to use them in other
client libraries.  You can learn about these shared features in the
[Azure.Core README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md).

## Code Generation

Please do not edit any of the code in the `/Generated` folders directly.  If
you need to update a swagger file or change the generator, you can regenerate
by running the `\sdk\storage\generate.ps1` script:

```powershell
PS C:\src\azure-sdk-for-net\sdk\storage> .\generate.ps1

>>> VERBOSE: Emitting file BlobRestClient.cs
>>> VERBOSE: Emitting file FileRestClient.cs
>>> VERBOSE: Emitting file QueueRestClient.cs
```

The generator uses [AutoRest](https://github.com/Azure/autorest) which requires
node.js. It is recommended to use the beta version as it increases the max usable memory:
```
npm install -g autorest@beta
```
There's known flakiness that results in an `ERROR: Did not find any
input files to generate!` message that can be safely ignored -- just run the
generator one more time.

## Testing
Please ensure all tests pass with any changes and additional tests are added to
exercise any new features that you've added.

### Frameworks

We use [NUnit 3](https://github.com/nunit/docs/wiki) as our testing framework.

[Azure.Core.TestFramework's testing framework][core_tests] provides a set of reusable primitives that simplify writing tests for new Azure SDK libraries.

We also have [common test code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Common/tests/Shared) in our
projects' `/Shared` folders that provides helpful Storage specific
infrastructure.

### Configuration

Our live tests require access to a variety of Storage accounts making use of
different service features.  We specify all of them via a
`TestConfigurations.xml` file.  It includes:

* `TargetTestTenant` - the default Storage account for our tests
* `TargetSecondaryTestTenant` - A Storage account with Read Access Geo-Redundant Storage enabled
* `TargetPremiumBlobTenant` - A Storage account using Premium SSDs
* `TargetPreviewBlobTenant` - A Storage account with access to preview features
* `TargetOAuthTenant` - A Storage account configured to authenticate with Azure Active Directory
* `TargetHierarchicalNamespaceTenant` - A Storage account with hierarchical namespace enabled
   and configured to authenticate with Azure Active Directory (OAuth access)

If you want to run live tests against your own account, you can edit the
[`TestConfigurationsTemplate.xml`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Common/tests/Shared/TestConfigurationsTemplate.xml)
file and rename it to `TestConfigurations.xml` in the same folder.  The build
will automatically copy it to each test project.  If you're working with
multiple enlistments or want to change between multiple configuration files,
you can set the `AZ_STORAGE_CONFIG_PATH` environment variable to a
configuration file path that will take precedence over your local
`TestConfigurations.xml` file.

### Sync/Async testing

We expose all of our APIs with both sync and async variants.  To avoid writing
each of our tests twice, we automatically rewrite our async API calls into
their sync equivalents.  Simply write your tests using only async APIs and
call `InstrumentClient` on any of our client objects.  The test framework will
wrap the client with a proxy that forwards everything to the sync overloads.
Please note that a number of our helpers will automatically instrument clients
they provide you.  Visual Studio's test runner will show `*TestClass(True)` for
the async variants and `*TestClass(False)` for the sync variants.

### Recorded tests

Our testing framework supports recording service requests made during a unit
test so they can be replayed later.  You can set the `AZURE_TEST_MODE`
environment variable to `Playback` to run previously recorded tests, `Record`
to record or re-record tests, and `Live` to run tests against the live service.

Properly supporting recorded tests does require a few extra considerations.
All random values should be obtained via `this.Recording.Random` since we use
the same seed on test playback to ensure our client code generates the same
"random" values each time.  You can't share any state between tests or rely on
ordering because you don't know the order they'll be recorded or replayed.  Any
sensitive values are redacted via the the configuration in the constructor of [`StorageTestBase`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Common/tests/Shared/StorageTestBase.cs).

### Running tests

The easiest way to run the tests is via Visual Studio's unit test runner.

You can also run tests via the command line using `dotnet test`, but that will
run tests for all supported platforms simultaneously and intermingle their
output.  You can run the tests for just one platform with `dotnet test -f net6.0`
or `dotnet test -f net462`.

The recorded tests are run automatically on every pull request.  Live tests are
run nightly.  Contributors with write access can ask Azure DevOps to run the
live tests against a pull request by commenting `/azp run net - storage - tests`
in the PR.

### Samples

Our samples are structured as unit tests so we can easily verify they're up to
date and working correctly.  These tests aren't recorded and make minimal use
of test infrastructure to keep them easy to read.

<!-- LINKS -->
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[core_tests]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework