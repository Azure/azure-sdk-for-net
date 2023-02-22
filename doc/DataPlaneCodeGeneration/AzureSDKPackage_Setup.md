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
  
We will use the Azure SDK template [Azure.Template](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template) to create the initial project skeleton.

You can run `eng\scripts\automation\Invoke-CadlDataPlaneGenerateSDKPackage.ps1` to generate the starting SDK client library package directly as following:

```powershell
eng/scripts/automation/Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -sdkFolder <sdk-folder-path> -cadlSpecDirectory <relativeCadlProjectFolderPath> [-commit <commitId>] [-repo <specRepo>] [-specRoot <specRepoRootPath>] [-additionalSubDirectories <relativeFolders>]
```

e.g. 
Use git url

```powershell
pwsh /home/azure-sdk-for-net/eng/scripts/automation/Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -sdkFolder /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector -cadlSpecDirectory specification/cognitiveservices/AnomalyDetector -commit ac8e06a2ed0fc1c54663c98f12c8a073f8026b90 -repo Azure/azure-rest-api-specs
```
or 
Use local Cadl project

```powershell
pwsh /home/azure-sdk-for-net/eng/scripts/automation/Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -sdkFolder /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector -cadlSpecDirectory specification/cognitiveservices/AnomalyDetector -specRoot /home/azure-rest-api-specs
```
**Note**:

- `-sdkFolder` take the address of the sdk folder in azure-sdk-for-net repo. e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector. [Required]
- `-cadlSpecDirectory` takes the relative path of the cadl project folder in spec repo. e.g. specification/cognitiveservices/AnomalyDetector [Required]
- `-additionalSubDirectories` takes the relative paths of the additional directories needed by the cadl project, such as share library folder, separated by semicolon if there is more than one folder. [Optional]
- `-commit` takes the git commit hash  (e.g. ac8e06a2ed0fc1c54663c98f12c8a073f8026b90)
- `-repo` takes the `<owner>/<repo>` of the REST API specification repository. (e.g. Azure/azure-rest-api-specs)
- `-specRoot` takes the file system path of the spec repo. e.g. /home/azure-rest-api-specs
- You need to provide the cadl project path, either (`-commit`, `-repo`) pair to refer to an URL path of the cadl project or `-specRoot` to refer to local file system path. If you provide both, `-specRoot` will be ignored.

When you run `eng\scripts\automation\Invoke-CadlDataPlaneGenerateSDKPackage.ps1`, it will:

- Create a project folder, install template files from `sdk/template/Azure.Template`, and create `.csproj` and `.sln` files for your new library.

    These files are created following the guidance for the [Azure SDK Repository Structure](https://github.com/Azure/azure-sdk/blob/master/docs/policies/repostructure.md).

- Generate the library source code files to the directory `<sdkPath>/sdk/<service>/<namespace>/src/Generated`
- Build the library project to create the starter package binary.
- Export the library's public API to the directory `<sdkPath>/sdk/<service>/<namespace>/api`