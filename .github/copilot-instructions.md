# Project Overview

This repo contains Azure SDKs for various Azure services and tools that generate them.

## Prerequisites
- Always run the [`azsdk_verify_setup`](../eng/common/instructions/azsdk-tools/verify-setup.instructions.md) tool to check the user's development environment setup for using SDK MCP tools. DO NOT PROCEED with running other tools before completing this step. Only skip for queries that don't need tools.
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