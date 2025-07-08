# Contributing (for `Azure.Search.Documents`)

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com](https://cla.microsoft.com).

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)
or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any
additional questions or comments.

## Azure SDK Design Guidelines for .NET
These libraries follow the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html)
and share a number of core features such as HTTP retries, logging, transport
protocols, authentication protocols, etc., so that once you learn how to use
these features in one client library, you will know how to use them in other
client libraries.  You can learn about these shared features in the
[Azure.Core README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md).

## Code Generation
Please do not edit any of the code in the `/Generated` folders directly.  If
you need to update code in response to a swagger file change or a code generator update,
you can regenerate the code by running `dotnet build /t:GenerateCode` in the `src` directory.

## Testing
Please ensure all tests pass with any changes and additional tests are added to
exercise any new features that you've added.

### Frameworks
We use [NUnit 3](https://github.com/nunit/docs/wiki) as our testing framework.

[Azure.Core.TestFramework's testing framework][core_tests] provides a set of reusable primitives that simplify writing tests for new Azure SDK libraries.

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
sensitive values are redacted via the recording sanitizers.

### Running tests
The easiest way to run the tests is via Visual Studio's unit test runner.

You can also run tests via the command line using `dotnet test`, but that will
run tests for all supported platforms simultaneously and intermingle their
output.  You can run the tests for just one platform with `dotnet test -f net8.0`
or `dotnet test -f net462`.

The recorded tests are run automatically on every pull request.  Live tests are
run nightly.  Contributors with write access can ask Azure DevOps to run the
live tests against a pull request by commenting `/azp run net - search - tests`
in the PR.

### Live Test Resources
Before running or recording live tests you need to create
[live test resources](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md).
If recording tests, secrets will be sanitized from saved recordings.
If you will be working on contributions over time, you should consider
persisting these variables.

### Samples
Our samples are structured as unit tests so we can easily verify they're up to
date and working correctly.  These tests make minimal use of test infrastructure
to keep them easy to read.

<!-- LINKS -->
[core_tests]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework
