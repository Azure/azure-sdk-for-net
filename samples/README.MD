# Samples, Snippets, and How-To Guides

Developers like to learn by looking at code, and so the Azure SDK comes with a myriad of code samples in the form of short code snippets, sample applications, and how-to guides. This document describes where to find all these resources.

## Structure of the Repository

The Azure SDK repository is organized in the following folder structure, with the main sample locations highlighted using **bold** font.

`/samples` (this folder)\
&nbsp;&nbsp;&nbsp;&nbsp;`README.md` (this file)\
`/sdk` (folder containing sources for all SDK packages)\
&nbsp;&nbsp;&nbsp;&nbsp;`/<service>` (e.g. storage)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`/<package>` (e.g. Azure.Storage.Blobs)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`README.md`** (package READMEs contain hello world samples)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`/samples`** (package-specific samples)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`README.md`** (contains front matter for [Samples Browser](https://learn.microsoft.com/samples))\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`Sample01_HelloWorld.md`** (basic sample; the first sample should always be named "HelloWorld")\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`Sample02_SomethingElse.md`** (additional samples with monotonically increasing number and basic description)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`/src`\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`/tests`\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`/samples`**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`README.md`** (redirect back to `/<packages>/samples` using absolute URL)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`Sample01_HelloWorld.cs`** (test with sample snippets for `Sample01_HelloWorld.md`)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**`Sample02_SomethingElse.cs`** (test with sample snippets for `Sample02_SomethingElse.md`)\

## Getting Started (a.k.a. `Hello World`) Samples

Each package folder contains a package-specific `README.md` file. Most of these `README` files contain `Hello World` code samples illustrating basic usage of the the APIs contained in the package. For example, you can find `Hello World` samples for the `Azure.Storage.Blobs` package [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs/README.md#examples).

## Package Samples and How-To Guides

Each package folder contains a subfolder called `samples` with additional code samples. These samples should be complete how-to guides (code samples and some commentary) contained in `*.md` files. You can find shortcuts to main how-to guides in the [**How-To Guides List**](#how-to-guide-list) section below.

Sources for these files are contained in the `tests/Samples` directory as part of the test project. You must use `#region Snippet:{Description}` to enclose snippets to include in the markdown under `samples`, where `{Description}` must be unique throughout the entire repo - not just your package or service directory.

The include snippets in the sample markdown under your package `samples`, include markdown like:

````markdown
```C# Snippet:{Description}
```
````

Run `eng/scripts/Update-Snippets.ps1 {ServiceDirectory e.g., "keyvault"}` to update snippets in markdowns.

### Recommend base classes

There are a couple base classes you should use for samples. In either case, consider deriving your own abstract base class so that you can override `CreateClient<T>` or add other methods once and use throughout your live tests.

- [`RecordedTestBase<TEnvironment>`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/RecordedTestBaseOfTEnvironment.cs) for HTTP-based client libraries, use this for live tests and samples. See the list of examples below for usage.
- [`SamplesBase<TEnvironment>`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/SamplesBase.cs) for client libraries using other protocols or otherwise difficult to record.

In either case, you can use different code for testing and for showing in snippets by using conditional preprocessor expressions using the `SNIPPET` symbol:

```C#
#if SNIPPET
string connectionString = "<connection string>";
#else
string connectionString = TestEnvironment.ConnectionString;
#endif
```

For an example of recorded sample tests, see:

- [Sample source](https://github.com/Azure/azure-sdk-for-net/blob/7ac3f2ef9b75f4aa9edf3a1d35be29fa1306c742/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/tests/Samples/Sample1_QueryKnowledgeBase.cs)
- [Samples base class](https://github.com/Azure/azure-sdk-for-net/blob/7ac3f2ef9b75f4aa9edf3a1d35be29fa1306c742/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/tests/Infrastructure/QuestionAnsweringClientSamples.cs)
- [Recorded tests base class](https://github.com/Azure/azure-sdk-for-net/blob/7ac3f2ef9b75f4aa9edf3a1d35be29fa1306c742/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/tests/Infrastructure/QuestionAnsweringTestBase.cs#)

### Redirect to package samples

Extracted snippets we put in package sample markdown files under `samples` should be as simple as necessary and the markdown should describe exactly how to get started and use those samples. Looking at the sources of those snippets might be confusing because of how we wrap those in test fixtures. Thus,

1. Do not link back to sources from the sample markdown files.
2. Include a `README.md` file in the smaple source directory that redirects users back to the sample markdown files' directory with the content:

````markdown
```markdown
Source files in this directory are written as tests from which samples are extracted.
They are not intended to be viewed directly and help ensure our samples compile and work correctly.
See our [list of samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/appconfiguration/Azure.Data.AppConfiguration/samples) for more explanation about how to use this client library.
```
````

## Sample Applications

Sometimes we want to illustrate how several APIs or even packages work together in a context of a more complete program. For these cases, we created sample applications that you can look at, download, compile, and execute. These application samples are located on
[https://docs.microsoft.com/samples/](https://docs.microsoft.com/samples/).

## How-To Guide List

This section lists **main** how-to guides for the most commonly used APIs and most common scenarios, i.e. this section does not attempt to be a complete directory of guides contained in this repository.

### General How-To Guides

- [How to access **HTTP response details**](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Response.md)
- [How to **mock**](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Mocking.md)
- [How to configure **retries**](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md)
- [How to configure **proxies**](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md)
- How to configure, access, and analyze **logging** information (TODO)

### Azure.Security.KeyVault

- [How to **create and delete keys**](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/samples/Sample1_HelloWorld.md)
- [How to **encrypt and decrypt keys**](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/samples/Sample4_EncryptDecrypt.md)
- [How to **backup and restore keys**](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/samples/Sample2_BackupAndRestore.md)
- [How to **backup and restore secrets**](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/samples/Sample2_BackupAndRestore.md)

#### Azure.Storage.Blobs

- [How to **upload and download** a blob](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs/samples/Sample01a_HelloWorld.cs)
