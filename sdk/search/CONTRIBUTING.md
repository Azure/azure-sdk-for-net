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
[Azure.Core README](../core/Azure.Core/README.md).

## Code Generation
Please do not edit any of the code in the `/Generated` folders directly.  If
you need to update a swagger file or change the generator, you can regenerate
by running the `\sdk\search\generate.ps1` script.

## Testing
Please ensure all tests pass with any changes and additional tests are added to
exercise any new features that you've added.

### Frameworks
We use [nUnit 3](https://github.com/nunit/docs/wiki) as our testing framework.

[Azure.Core's testing framework](../core/Azure.Core/tests/TestFramework) is
copied into our projects' `/TestFramework` folders by the build.  _(Please be
sure to run all of the unit tests in `../../core/Azure.Core/Azure.Core.All.sln`
if you make any changes here.)_

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
output.  You can run the tests for just one platform with `dotnet test -f netcoreapp2.1`
or `dotnet test -f net461`.

The recorded tests are run automatically on every pull request.  Live tests are
run nightly.  Contributors with write access can ask Azure DevOps to run the
live tests against a pull request by commenting `/azp run net - search - tests`
in the PR.

### Live Test Resources
To set up your Azure account to run live tests, you'll need to log into Azure,
create a service principal, and set up your resources defined in
[test-resources.json](./test-resources.json) as shown in the following example.
Note that `-Subscription` is an optional parameter but recommended if your account
is a member of multiple subscriptions.

```powershell
PS C:\src> Connect-AzAccount -Subscription 'YOUR SUBSCRIPTION ID'
PS C:\src> $sp = New-AzADServicePrincipal -Role Owner
PS C:\src> eng\common\TestResources\New-TestResources.ps1 `
  -BaseName 'myusername' `
  -ServiceDirectory search `
  -TestApplicationId $sp.ApplicationId `
  -TestApplicationSecret (ConvertFrom-SecureString $sp.Secret -AsPlainText)
```

Along with some log messages, this will output environment variables based on your
current shell like in the following example:

```
$env:AZURE_TENANT_ID = '04acef35-c7bd-4d14-bfd9-59f11b7b9eac'
$env:AZURE_CLIENT_ID = 'ce1a3a01-424f-4e34-b9a6-823e2b1ae783'
$env:AZURE_CLIENT_SECRET = 'c27ccc92-e1ca-4d29-8f4e-c6a1ee61ff57'
$env:AZURE_SUBSCRIPTION_ID = 'd686c17c-aade-4238-bce0-290453cfcf97'
$env:AZURE_RESOURCE_GROUP = 'rg-myusername'
$env:AZURE_LOCATION = 'westus2'
$env:AZURE_SEARCH_STORAGE_NAME = 'myusernamestg'
$env:AZURE_SEARCH_STORAGE_KEY = 'Of2O5Snep5tl13bfjh02/fSNYfrBPXV7CYK7EVnMm/z9fN7zCcq6WKuWfZDM9QsTORvC7zYLifyIEtymI5VCmA=='
```

For security reasons we do not set these environment variables automatically for either
the current process or persistently for future sessions. You must do that yourself.

If your current shell was detected propertly, you should be able to copy and paste the
output directly in your terminal and add to your profile script. For example,
in PowerShell on Windows you could copy and paste the output and run the following command:

```powershell
$env:AZURE_TENANT_ID = '04acef35-c7bd-4d14-bfd9-59f11b7b9eac'
$env:AZURE_CLIENT_ID = 'ce1a3a01-424f-4e34-b9a6-823e2b1ae783'
$env:AZURE_CLIENT_SECRET = 'c27ccc92-e1ca-4d29-8f4e-c6a1ee61ff57'
$env:AZURE_SUBSCRIPTION_ID = 'd686c17c-aade-4238-bce0-290453cfcf97'
$env:AZURE_RESOURCE_GROUP = 'rg-myusername'
$env:AZURE_LOCATION = 'westus2'
$env:AZURE_SEARCH_STORAGE_NAME = 'myusernamestg'
$env:AZURE_SEARCH_STORAGE_KEY = 'Of2O5Snep5tl13bfjh02/fSNYfrBPXV7CYK7EVnMm/z9fN7zCcq6WKuWfZDM9QsTORvC7zYLifyIEtymI5VCmA=='

dir env:AZURE* | % { setx $_.Name $_.Value }
```

### Samples
Our samples are structured as unit tests so we can easily verify they're up to
date and working correctly.  These tests make minimal use of test infrastructure
to keep them easy to read.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fsearch%2FCONTRIBUTING.png)
