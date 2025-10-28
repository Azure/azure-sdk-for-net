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

### Option 1: Using tsp-client init (Recommended)

You can use the `tsp-client init` command to create the initial project structure and configuration. This tool automatically sets up the correct emitter path for new services:

```bash
npx -y @azure-tools/typespec-client-generator-cli@latest init
```

This will guide you through an interactive process to set up your TypeSpec client configuration.

### Option 2: Manual Setup

Alternatively, you can manually create the `tsp-location.yaml` file in your SDK package folder:

1. Create your SDK package folder structure under `sdk/<service name>/<package name>/`
2. Create a `tsp-location.yaml` file with the following structure:

```yaml
directory: specification/<service>/<typespec-project-folder>
commit: <commit-hash>
repo: Azure/azure-rest-api-specs
emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-emitter-package.json

# Optional: if your TypeSpec project depends on shared libraries
additionalDirectories:
- specification/<shared-library-path>/
```

**Example tsp-location.yaml:**

```yaml
directory: specification/cognitiveservices/AnomalyDetector
commit: ac8e06a2ed0fc1c54663c98f12c8a073f8026b90
repo: Azure/azure-rest-api-specs
emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-emitter-package.json
```

For new data plane services, you **must** set the `emitterPackageJsonPath` property to `eng/azure-typespec-http-client-csharp-emitter-package.json` to use the new emitter path.

**Note**:

- `directory` - The relative path of the TypeSpec project folder in the spec repo (e.g., `specification/cognitiveservices/AnomalyDetector`)
- `commit` - The git commit hash from the spec repo (e.g., `ac8e06a2ed0fc1c54663c98f12c8a073f8026b90`)
- `repo` - The `<owner>/<repo>` of the REST API specification repository (default: `Azure/azure-rest-api-specs`)
- `emitterPackageJsonPath` - Path to the emitter package.json file (required for new services: `eng/azure-typespec-http-client-csharp-emitter-package.json`)
- `additionalDirectories` - Optional list of additional directories needed by the TypeSpec project (e.g., shared library folders)

These files are created following the guidance for the [Azure SDK Repository Structure](https://github.com/Azure/azure-sdk/blob/master/docs/policies/repostructure.md).

For more information on code generation, see the [Azure SDK Code Generation Quickstart Tutorial](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKCodeGeneration_DataPlane_Quickstart.md).