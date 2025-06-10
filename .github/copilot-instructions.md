**Requirements:**
- If you are writing C# code within the azure-sdk-for-net/sdk directory:
    1. Follow the coding guidelines in the "Coding guidelines" section below.
    2. You should never manually make changes to `*/Generated/*` files, e.g. `azure-sdk-for-net/sdk/containerregistry/Azure.Containers.ContainerRegistry/src/Generated/`
        - Only re-generate these files if instructed to do so. If you are instructed to regenerate an SDK, use `dotnet build /t:GenerateCode`
        - If you feel like you need to make changes beyond re-generating to these files to complete your task, do not do this, instead see if you can work around the problem in the code that is not in the `Generated` folder. If you can't, report this to the user.
    3. Code should build successfully using the following steps:
        - Run `dotnet build` within each of the src folders of affected packages. This will build that project's .csproj file. For example, if you make a change to a file in the `azure-sdk-for-net/sdk/storage/Azure.Storage.Blobs/` directory, you would change to the `azure-sdk-for-net/sdk/storage/Azure.Storage.Blobs/src` directory, and then run `dotnet build`, which will build `Azure.Storage.Blobs.csproj`
        - If you see build errors, try to fix them, if you can't fix them within 5 iterations, give up and report this to the user. Do not report success if the build fails!
    4. When you're done working, navigate to the root of the repository and run `./eng/scripts/Export-API.ps1 {service-directory}`, for all impacted service directories. To get the impacted service directories, look at the paths of all files that have been edited. All projects follow this pattern: `azure-sdk-for-net/sdk/{service-directory}/{package-name}`. For example, if you have edited a file in `azure-sdk-for-net/sdk/storage/Azure.Storage.Blobs`, you would run `./eng/scripts/Export-API.ps1 storage`.
---

# Coding guidelines
- Follow implementation guidelines at https://azure.github.io/azure-sdk/dotnet_implementation.html
- When writing tests, do not emit "Act", "Arrange" or "Assert" comments.