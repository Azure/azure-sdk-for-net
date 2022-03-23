Samples are where developers could start to learn a library. You should generate samples scaffold by running the quick start [tool](AzureSDKCodeGeneration_DataPlane_Quickstart.md#create-starter-package). The samples should match the structure containing the following key features:
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
│   ├── Samples
|   |   ├── Sample1_{Scenario1}.cs
|   |   ├── Sample1_{Scenario1}Async.cs
|   |   ├── Sample2_{Scenario2}.cs
|   |   ├── Sample2_{Scenario2}Async.cs
|   |   └── ...
│   └── ...
└── ...
```

## Folder `samples`
This folder is developer's starting point. With samples of different scenarios, developer could quickly learn without digging into the in-depth technology. It should be located at subdirectory of main library directory. 

In this folder, you could have several senarios for your library. In each scenario, you should have snippets from tests\Samples\ to make sure it will be compiled, tested and up-to-date. All the scenarios should be listed at `README.md`. See the [specification](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-samples) and [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template/Azure.Template/samples).

## Folder `tests`
This folder contains all the scenarios in a test form. See examples [here](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template/Azure.Template/tests/Samples). In these examples, you should mark some code as a snippet so that you could reuse it in the markdown files in the folder `samples`. All the code in the scenario readme filed of folder `samples` should refer to these snipppets to ensure that sample code always compiles, runs, and passes CI tests. See [Updating Sample Snippets](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets) to learn how to use snippets.