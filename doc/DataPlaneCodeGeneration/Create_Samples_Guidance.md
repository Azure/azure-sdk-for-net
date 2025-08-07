# Guidance to write samples for data plane

Samples are where developers start to learn a library. For general information about samples, see the [Samples guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-samples).

The samples should match the structure containing the following key features:

```
├── ...
├── samples
│   ├── README.md
│   ├── Sample1_{Scenario1}.md
│   |── Sample1_{Scenario1}Async.md
│   ├── Sample2_{Scenario2}.md
│   |── Sample2_{Scenario2}Async.md
│   └── ...
├── tests
|   ├── Azure.{group}.{service}.Tests.csproj
│   ├── Samples
|   |   ├── Sample1_{Scenario1}.cs
|   |   ├── Sample1_{Scenario1}Async.cs
|   |   ├── Sample2_{Scenario2}.cs
|   |   ├── Sample2_{Scenario2}Async.cs
|   |   └── ...
│   └── ...
└── ...
```

All the `Sample{number}_{Scenario}Async.*` files contain the corresponding async scenarios. You could merge it into its corresponding sync scenario files `Sample{number}_{Scenario}.*`. If you keep the structure same as above, you should declare the async class and its corresponding sync class as partial class. E.g.,

```C#
// Sample1_HelloWorld.cs
public partial class Sample1_HelloWorld : SampleBase<SampleTestEnvironent>
{
  [Test]
  [SyncOnly]
  public void DoWork()
  {
    #region Azure_Sample_Sample1_DoWork
    // ...
    #endregion
}

// Sample1_HelloWorldAsync.cs
public partial class Sample1_HelloWorld
{
  [Test]
  [AsyncOnly]
  public async Task DoWorkAsync()
  {
    #region Azure_Sample_Sample1_DoWorkAsync
    // ...
    #endregion
  }
}
```

## Snippets

All samples in the Azure SDK for .NET repository are required to use snippets when demonstrating code.  Snippets allow us to verify that the code in our samples and READMEs is always up to date and passes unit tests. We have added the snippet [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Samples/Sample1_HelloWorld.cs#L21) in a sample and used it in the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/README.md#get-secret). Please refer to [Updating Sample Snippets](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets) to add snippets in your samples.

## Folder `samples`
This folder is developer's starting point. With samples of different scenarios, developer could quickly learn without digging into the in-depth technology. It should be located at subdirectory of main library directory. 

In this folder, you could have several senarios for your library. In each scenario, you should have snippets from tests\Samples\ to make sure it will be compiled, tested and up-to-date. All the scenarios should be listed at `README.md`. See the [specification](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-samples) and [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template/Azure.Template/samples).

## Folder `tests`
This folder contains all the scenarios in a test form to ensure that they are kept up to date. See examples [here](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template/Azure.Template/tests/Samples). In these examples, you should mark some code as a snippet so that you could reuse it in the markdown files in the folder `samples`. All the code in the scenario readme filed of folder `samples` should refer to these snipppets to ensure that sample code always compiles, runs, and passes CI tests. See [Updating Sample Snippets](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets) to learn how to use snippets.