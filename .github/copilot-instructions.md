# Project Overview

This repo contains Azure SDKs for various Azure services and tools that generate them.

## Prerequisites
- To use MCP tool calls, PowerShell must be installed. Provide [PowerShell installation instructions](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) if not installed, and recommend restarting the IDE to use the MCP server.

## Folder Structure

- `/eng/packages/http-client-csharp`: Contains the source code of the generator for Azure Data Plane SDKs (aka Azure Generator).
- `/eng/packages/http-client-csharp-mgmt`: Contains the source code of the generator for Azure Management Plane SDKs (aka Azure Management Generator).
- `/sdk`: Contains the individual SDKs for Azure services.

### Azure Generator

- Always run `npm install` in the `/eng/packages/http-client-csharp` directory before running the generator.
- Always run `/eng/packages/http-client-csharp/eng/scripts/Generate.ps1` to regenerate the test projects to validate the result of generator code changes.

### Azure Management Generator

- Always run `npm install` in the `/eng/packages/http-client-csharp-mgmt` directory before running the generator.
- Always run `/eng/packages/http-client-csharp-mgmt/eng/scripts/Generate.ps1` to regenerate the test projects to validate the result of generator code changes.

## SDK generator renew

These are instructions when you are required to renew/change/update the generator of one specific package to the new generator.

The new generator could be `@azure-tools/http-client-csharp` or `@azure-tools/http-client-csharp-mgmt`.

Do the following steps to renew/change/update the generator:

1. Figure out which new generator you should use. Determine this by the package name.
    - For namespace in pattern of `Azure.ResourceManager.*`, the new generator should be `@azure-tools/http-client-csharp-mgmt`.
    - For namespace in pattern of `Azure.Provisioning.*`, you should reject this request because now we do not have a valid generator for it yet.
    - For namespace in any other pattern, the new generator should be `@azure-tools/http-client-csharp`.
2. Find the package directory in the `sdk` directory for that package. Search for the `*.csproj` file with the request package name, you should find a directory in this pattern `sdk/<service-directory>/<requested-package-name>`, and inside this sub-directory, there is such a `<requested-package-name>.csproj` file.
3. Find the `tsp-location.yaml` file in the above package directory.
    - If this file exists, add an extra property at the end of this file with
        - `emitterPackageJsonPath: "eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json"` if the new generator is `@azure-tools/http-client-csharp-mgmt`.
        - `emitterPackageJsonPath: "eng/azure-typespec-http-client-csharp-emitter-package.json"` if the new generator is `@azure-tools/http-client-csharp`.
    - If this file does not exist, create this file with the following content:
    ```yaml
    directory: specification/placeholderServiceDir/PlaceholderServiceName.Management
    commit: PlaceholderCommitId
    repo: Azure/azure-rest-api-specs
    emitterPackageJsonPath: <the corresponding file path for the corresponding generator>
    ```
    After creating the above `tsp-location.yaml` file, find the `autorest.md` file inside the package directory, and rename it to `autorest.md.bak`.
4. If in the above step, the `tsp-location.yaml` existed, run the `dotnet build /t:GenerateCode` command in the package directory. Report any errors if they happen.
If in the above step, the `tsp-location.yaml` did not exist and we just created it, report this in the PR description and emphasize everything inside it are placeholders.

## SDK release

There are two tools to help with SDK releases:
- Check SDK release readiness
- Release SDK

### Check SDK Release Readiness
Run `CheckPackageReleaseReadiness` to verify if the package is ready for release. This tool checks:
- API review status
- Change log status
- Package name approval(If package is new and releasing a preview version)
- Release date is set in release tracker

### Release SDK
Run `ReleasePackage` to release the package. This tool requires package name and language as inputs. It will:
- Check if the package is ready for release
- Identify the release pipeline
- Trigger the release pipeline.
User needs to approve the release stage in the pipeline after it is triggered.