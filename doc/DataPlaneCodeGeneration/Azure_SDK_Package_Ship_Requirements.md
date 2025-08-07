# Enhance a generated SDK

`Azure.<group>.<service>` is the Azure SDK package name and `<client-name>` is a client name. C# generator will generate a client which you can find in `Azure.<group>.<service>/Generated` directory.

Before the generated library can be released, you will need to add several requirements manually, including tests, samples, README, and CHANGELOG.
You can refer to following guideline to add those requirements:

## Tests

When the SDK was generated, a test project was created and saved under `Azure.<group>.<service>\tests`. You need to add tests to your SDK.

Steps:

- Add other client parameters in `<client-name>ClientTestEnvironment.cs`
- Update `<client-name>ClientTest.cs` with your tests. Refer to [Using the TestFramework](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md) to add tests.

**Note**:

- Before running live tests you will need to create live test resources, please refer to [Live Test Resource Management](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md) to learn more about how to manage resources and update test environment.

**Learn more:** see the [docs](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#to-test-1) to learn more about tests.

## Samples

When the SDK was generated, a samples folder was created and saved under `Azure.<group>.<service>/tests`. The samples run as a part of the tests. 

Steps:

1. Add sample tests per hero scenario of your service. Use `Sample<number>_<scenario>.cs`.
2. Add created samples to the documentation. Modify  `Sample<sample_number>_<scenario>.md`.

**Learn more:** More information: [Create sample guidance](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/Create_Samples_Guidance.md).

## README

Add/update the README.md file (`Azure.<group>.<service>/README.md`) of your library. You can use the [README.md template](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/README.md).

## Changelog

Add/update the CHANGELOG.md file (`Azure.<group>.<service>/CHANGELOG.md`). For general information about the changelog, see the [Changelog Guidelines](https://azure.github.io/azure-sdk/policies_releases.html#change-logs).

## Convenience APIs (optional)

Adding convenience APIs is not required for Azure SDK data plane generated libraries, but doing so can provide customers with a better experience when they develop code using your library.  You should consider adding convenience APIs to the generated client to make it easier to use for the most common customer scenarios, or based on customer feedback.  Any convenience APIs you add should be approved with the Azure SDK architecture board.

You can add convienice APIs by adding a customization layer on top of the generated code.  Please see the [autorest.csharp README#customizing-the-generated-code](https://github.com/Azure/autorest.csharp/blob/main/readme.md#customizing-the-generated-code) for the details of adding the customization layer.  This is the preferred method for adding convenience APIs to your generated client.


If you generate SDK from Open API specification (swagger), and other modifications are needed to the generated API, you can consider making them directly to the Open API specification, which will have the benefit of making the changes to the library in all languages you generate the library in.  As a last resort, you can add modifications with swagger transforms in the `autorest.md` file.  Details for various transforms can be found in [Customizing the generated code](https://github.com/Azure/autorest.csharp#customizing-the-generated-code).

Once you've made changes to the public API, you will need to run the `eng\scripts\Export-API.ps1` script to update the public API listing. This will generate a file in the library's directory similar to the example found in [sdk\template\Azure.Template\api\Azure.Template.netstandard2.0.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/api/Azure.Template.netstandard2.0.cs).

e.g. Running the script for a project in `sdk\deviceupdate` would look like this:

```powershell
eng\scripts\Export-API.ps1 deviceupdate
```

## Test pipelines

When a PR is created, our CI/CD runs the test to validate the changes done to the sdk. These pipelines follow the name convention: `net - [serviceDirectory] - ci`.
If this is not present in your PR, you need to [create the pipeline](https://dev.azure.com/azure-sdk/internal/_wiki/wikis/internal.wiki/55/Pipelines?anchor=creating-pipelines-for-new-services) by running `prepare-pipelines` or investigate the configuration of your triggers in your ci.yml file.  Once `prepare-pipelines` finishes you should be able to manually kick off the pipeline with `/azp run net - [serviceDirectory] - ci`.  All subsequent PRs should automatically have this pipeline run as long as the ci.yml triggers are set up correctly.

Example: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/ci.yml.
