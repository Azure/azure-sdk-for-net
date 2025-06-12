# Repository information
Note that files in this repository are generally organized in the following way:
- `azure-sdk-for-net/sdk/{service-directory}/{package-name}` holds everything for a specific Azure SDK package.
- `azure-sdk-for-net/sdk/{service-directory}/{package-name}/src` holds the source code for the package.
- `azure-sdk-for-net/sdk/{service-directory}/{package-name}/tests` holds the tests for the package.
- `azure-sdk-for-net/sdk/{service-directory}/{package-name}/samples` holds the samples for the package.

There are a few exceptions where package-name is replaced with a shorter directory name. For example in the cognitiveservices directory. The package `Microsoft.Azure.CognitiveServices.Language.SpellCheck` can be found in `azure-sdk-for-net/sdk/cognitiveservices/Language.SpellCheck`. When in doubt, you can look at the name of the .csproj file within the src folder to determine the package name.

# Requirements
- If you are writing C# code within the `azure-sdk-for-net/sdk` directory:
    1. Follow the coding guidelines in the "Coding guidelines" section below.
    2. You should never manually make changes to `*/Generated/*` files, e.g. `azure-sdk-for-net/sdk/containerregistry/Azure.Containers.ContainerRegistry/src/Generated/`
        - Only re-generate these files if instructed to do so. If you are instructed to regenerate an SDK, use `dotnet build /t:GenerateCode`
        - If you feel like you need to make changes to these files beyond re-generating them in order to complete your task, do not do this, instead see if you can work around the problem in the code that is not in the `Generated` folder. If you can't, report this to the user.
    3. Code should build successfully using the following steps:
        - Find the .sln file that applies to the files you are working on.
            - This will typically be within the package directory. For example, if you update a file in `azure-sdk-for-net/sdk/batch/Azure.ResourceManager.Batch/src/`, you would need `azure-sdk-for-net/sdk/batch/Azure.ResourceManager.Batch/Azure.ResourceManager.Batch.sln`. From the directory of the sln file, run `dotnet build {solution-file}`. So in this example, you would run `dotnet build Azure.ResourceManager.Batch.sln` in the `azure-sdk-for-net/sdk/batch/Azure.ResourceManager.Batch/` directory.
        - If you see build errors, try to fix them, if you can't fix them within 5 iterations, give up and report this to the user. Do not report success if the build fails!
    4. When you're done working, navigate to the root of the repository and run `./eng/scripts/Export-API.ps1 {service-directory}`, for all impacted service directories. To get the impacted service directories, look at the paths of all files that have been edited. All projects follow this pattern: `azure-sdk-for-net/sdk/{service-directory}/{package-name}`. For example, if you have edited a file in `azure-sdk-for-net/sdk/storage/Azure.Storage.Blobs`, you would run `./eng/scripts/Export-API.ps1 storage`.
---

## Coding guidelines
- Follow implementation guidelines at https://azure.github.io/azure-sdk/dotnet_implementation.html
- When writing tests, do not emit "Act", "Arrange" or "Assert" comments.
- Do not add extra whitespace to the end of lines.