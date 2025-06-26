# Repository information
Note that files in this repository are generally organized in the following way:
- `azure-sdk-for-net/sdk/{service-directory}/{package-name}` holds everything for a specific Azure SDK package.
- `azure-sdk-for-net/sdk/{service-directory}/{package-name}/src` holds the source code for the package.
- `azure-sdk-for-net/sdk/{service-directory}/{package-name}/tests` holds the tests for the package.
- `azure-sdk-for-net/sdk/{service-directory}/{package-name}/samples` holds the samples for the package.

There are a few exceptions where package-name is replaced with a shorter directory name. For example in the cognitiveservices directory. The package `Microsoft.Azure.CognitiveServices.Language.SpellCheck` can be found in `azure-sdk-for-net/sdk/cognitiveservices/Language.SpellCheck`. When in doubt, you can look at the name of the .csproj file within the src folder to determine the package name.

## Definitions:
- "service directory" refers to the folder under `sdk`. For example, `azure-sdk-for-net/sdk/eventhub`, `eventhub` is the service directory
- "data plane" refers to packages that don't include `ResourceManager` in the package name. They are used to interact with azure resources at application run time.
- "management plane" refers to packages that include `ResourceManager` in the package name. They are used to manage (create/modify/delete) azure resources.
- "track 2" refers to packages that start with `Azure`. Unless otherwise specified, assume that references to "data plane" mean "track 2 data plane", i.e. packages that start with `Azure` and don't include `ResourceManager` in the package name. Unless otherwise specified, assume that references to "management plane" mean "track 2 management plane", i.e. packages that start with `Azure.ResourceManager`.
- "functions extensions packages" or sometimes just "extensions packages" refers to packages that start with `Microsoft.Azure.WebJobs.Extensions`. They are built on data plane packages and are used with Azure Functions.

# Requirements
- If you are writing C# code within the `azure-sdk-for-net/sdk` directory:
    1. Follow the coding guidelines in the "Coding guidelines" section below.
    2. You should never manually make changes to `*/Generated/*` files, e.g. `azure-sdk-for-net/sdk/containerregistry/Azure.Containers.ContainerRegistry/src/Generated/`
        - Only re-generate these files if instructed to do so. If you are instructed to regenerate an SDK, use `dotnet build /t:GenerateCode`
        - If you feel like you need to make changes to these files beyond re-generating them in order to complete your task, do not do this, instead see if you can work around the problem in the code that is not in the `Generated` folder. If you can't, report this to the user.
    3. Code should build successfully using the following steps:
        - navigate to the root of the repository and run `dotnet build eng\service.proj /p:ServiceDirectory={service-directory}` for each service directory you modified. For example, if you modified code in `sdk/eventhub` and `sdk/keyvault`, you would run:
          `dotnet build eng\service.proj /p:ServiceDirectory=eventhub` and `dotnet build eng\service.proj /p:ServiceDirectory=keyvault`
        - If you see build errors, try to fix them, if you can't fix them within 5 iterations, give up, do not do steps 4 or 5, and report this to the user. Do not report success if the build fails!
    4. Once the code builds, run the unit tests using `dotnet test eng/service.proj /p:ServiceDirectory={service-directory} --filter TestCategory!=Live` for each service directory you modified. Try to fix failures if you can within 5 iterations. If you can't, give up and report this to the user. Do not report success if the tests fail!
    5. When you're done working, navigate to the root of the repository and run `.\eng\scripts\Export-API.ps1 {service-directory}` for each service directory you modified.
---

## Coding guidelines
- Follow implementation guidelines at https://azure.github.io/azure-sdk/dotnet_implementation.html
- When writing tests, do not emit "Act", "Arrange" or "Assert" comments.
- Do not add extra whitespace to the end of lines.