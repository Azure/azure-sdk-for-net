# How to generate Code

To generate code, simply run the `generate.ps1` powershell script. If a powershell script does not exist under the RP directory, create one using an example [here](https://github.com/Azure/azure-sdk-for-net/blob/psSdkJson6/src/SDKs/Compute/Management.Compute/generate.ps1).

If code generation fails for any reason, here are a few common steps to resolve the issues.

- Clean the repo
```
git clean -xdf
```
- Download and install the latest build tools (use a VS 2017 developer prompt to run msbuild)
``` 
msbuild build.proj
```
- Run the `generate.ps1` command again


# When opening a PR

## General instructions
- Please link the REST spec API PR which helps the review process
- Please check whether a new API version is introduced in the REST spec repo; this is important while addressing the instructions below
- Please read the SLA information and other instructions on the PR template before opening the PR

## REST API version artifacts
If there is a new version of the REST API from which code is being generated for the PR, the following files should be modified/created in the PR
- A `.props` file which holds information about the REST API versions eg: [here](https://github.com/Azure/azure-sdk-for-net/blob/psSdkJson6/src/SDKs/Compute/AzSdk.RP.props)
- A `SdkInfo_*.cs` file which holds information about the REST API versions eg: [here](https://github.com/Azure/azure-sdk-for-net/blob/psSdkJson6/src/SDKs/Compute/AzSdk.RP.props)

To generate the `.props` artifact, please run (use the VS 2017 developer prompt for msbuild):
```
msbuild build.proj /t:build /p:Scope=SDKs\<RP>
```
RP is the resource provider's directory under SDKs, eg.: Compute

To generate the `SdkInfo*.cs` file, please run the `generate.ps1` script

## Code generation artifacts
If code is generated using `generate.ps1`, information related to the generation gets logged in a `.txt` file under `src\SDKs\_metadata` eg.: [here](https://github.com/Azure/azure-sdk-for-net/blob/psSdkJson6/src/SDKs/_metadata/compute_resource-manager.txt)

Please check the branch and fork of the REST spec for which the code was generated, this must always be `Azure` and `master` respectively for a PR to be valid. Code generated using specifications not checked in the Azure master branch will not be merged.

# How to sign/publish bits
For detailed information about publishing and the overall workflow towards developing a powershell cli, click [here](https://github.com/Azure/adx-documentation-pr/blob/master/engineering/autorest-to-powershell.md)

# How to generate code from a different fork and branch
For testing purposes, code can be generated from any fork and branch.
To do so, modify the `generate.ps1` as below
```
powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File "<relativepath>\..\tools\generateTool.ps1" -ResourceProvider "<resourceprovider>" -PowershellInvoker -AutoRestVersion "latest" -SpecsRepoFork "<forkname>" -SpecsRepoBranch "<branchname>"
```
If the spec is a completely different repo, add the following argument to the command above
```
-SpecsRepoName "<specsrepo>"
```