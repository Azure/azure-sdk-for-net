# Azure SDK Package Setup Tutorial (Data Plane)

For this guide, we'll create a getting started project in a branch of your fork of `azure-sdk-for-net` repo. The started project will be under `sdk\<servie name>\<package name>` directory of `azure-sdk-for-net` repo. The package will contain several folders and files (see following). Please refer to [sdk-directory-layout](https://github.com/Azure/azure-sdk/blob/main/docs/policies/repostructure.md#sdk-directory-layout) for detail information.

```text
sdk\<service name>\<package name>\README.md
sdk\<service name>\<package name>\api
sdk\<service name>\<package name>\perf
sdk\<service name>\<package name>\samples
sdk\<service name>\<package name>\src
sdk\<service name>\<package name>\tests
sdk\<service name>\<package name>\CHANGELOG.md
sdk\<service name>\<package name>\<package name>.sln
```

- `<service name>` - Should be the short name for the azure service. e.g. deviceupdate. It is usually your service name in REST API specifications. For instance, if the API spec is under `specification/deviceupdate`, the service would normally be `deviceupdate`.
- `<package name>` -  Should be the name of the shipping package, or an abbreviation that distinguishes the given shipping artifact for the given service. It will be `Azure.<group>.<service>`, e.g. Azure.IoT.DeviceUpdate

## Create sdk package

We will use the Azure SDK template [Azure.Template](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template) to create the initial project skeleton for SDKs generated from TypeSpec.

You can run `eng\scripts\automation\Invoke-TypeSpecDataPlaneGenerateSDKPackage.ps1` to generate the starting SDK client library package directly as following:

```powershell
eng/scripts/automation/Invoke-TypeSpecDataPlaneGenerateSDKPackage.ps1 -sdkFolder <sdk-folder-path> -typespecSpecDirectory <relativeTypeSpecProjectFolderPath> -commit <commitId> [-repo <specRepo>] [-additionalSubDirectories <relativeFolders>]
```

e.g.
Use git url

```powershell
pwsh /home/azure-sdk-for-net/eng/scripts/automation/Invoke-TypeSpecDataPlaneGenerateSDKPackage.ps1 -sdkFolder /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector -typespecSpecDirectory specification/cognitiveservices/AnomalyDetector -commit ac8e06a2ed0fc1c54663c98f12c8a073f8026b90 -repo Azure/azure-rest-api-specs
```

**Note**:

- `-sdkFolder` take the address of the sdk folder in azure-sdk-for-net repo. e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector. [Required]
- `-typespecSpecDirectory` takes the relative path of the typespec project folder in spec repo. e.g. specification/cognitiveservices/AnomalyDetector [Required]
- `-additionalSubDirectories` takes the relative paths of the additional directories needed by the typespec project, such as share library folder, separated by semicolon if there is more than one folder. [Optional]
- `-commit` takes the git commit hash  (e.g. ac8e06a2ed0fc1c54663c98f12c8a073f8026b90) [Required]
- `-repo` takes the `<owner>/<repo>` of the REST API specification repository. (e.g. Azure/azure-rest-api-specs), [Optional], default is `Azure/azure-rest-api-specs`

When you run `eng\scripts\automation\Invoke-TypeSpecDataPlaneGenerateSDKPackage.ps1`, it will:

- Create a project folder, install template files from `sdk/template/Azure.Template`, and create `.csproj` and `.sln` files for your new library.

    These files are created following the guidance for the [Azure SDK Repository Structure](https://github.com/Azure/azure-sdk/blob/master/docs/policies/repostructure.md).