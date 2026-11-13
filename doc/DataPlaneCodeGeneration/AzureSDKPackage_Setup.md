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

You have several options to create the initial project skeleton for SDKs generated from TypeSpec:

### Option 1: Using tsp-client init (Recommended)

You can use the `tsp-client init` command to initialize the TypeSpec configuration. This tool automatically sets up the correct emitter path for new services. You must pass the `--tsp-config` parameter pointing to the tspconfig.yaml in the spec repo:

```bash
tsp-client init --tsp-config https://github.com/Azure/azure-rest-api-specs/blob/<commit>/specification/<service>/<typespec-project-folder>/tspconfig.yaml
```

**Example:**

```bash
tsp-client init --tsp-config https://github.com/Azure/azure-rest-api-specs/blob/c226a37cdb9a3f756aff9edb33435ba7c90a5b91/specification/ai/ContentUnderstanding/tspconfig.yaml
```

This will initialize the `tsp-location.yaml` file with the correct configuration. After running this command, you'll still need to create the project structure and files manually.

### Option 2: Copy the Azure.Template project

You can copy the [Azure.Template](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template/Azure.Template) project as a starting point. This template includes the complete project structure with:

- Project files (`.csproj`, `.sln`)
- TypeSpec configuration (`tsp-location.yaml`)
- Test infrastructure
- Sample structure
- CI/CD configuration

**Steps:**
1. Copy the `sdk/template/Azure.Template` directory to your new location `sdk/<service name>/<package name>/`
2. Rename the project files and namespaces to match your service
3. Update the `tsp-location.yaml` file to point to your TypeSpec specification
4. Update the package name, version, and other metadata in the `.csproj` file

These files are created following the guidance for the [Azure SDK Repository Structure](https://github.com/Azure/azure-sdk/blob/master/docs/policies/repostructure.md).

For more information on code generation, see the [Azure SDK Code Generation Quickstart Tutorial](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKCodeGeneration_DataPlane_Quickstart.md).