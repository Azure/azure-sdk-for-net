# Develop Hybrid Profile SDK for .NET

## This document shows you how to develop Hybrid Profile SDK for .NET.

---

### Notice
This Document is only for Track 1 SDK with Hybrid Profile Project

## Getting Started

1. Fork the [Azure/azure-rest-api-specs](https://github.com/Azure/azure-rest-api-specs), create a work branch if you need.
2. Modify the target RPs' readme.md file based on the Hybrid Profile file.   
   Example:   
   - **[2020-09-01-hybrid.json](https://github.com/Azure/azure-rest-api-specs/blob/master/profile/2020-09-01-hybrid.json):**   
        >"microsoft.commerce": {
        >"2015-06-01-preview":[
        >  {
        >    "resourceType": "estimateResourceSpend",
        >    "path":"https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json"
        >  },
        >  {
        >    "resourceType": "operations",
        >    "path":"https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json"
        >  },
        >  {
        >    "resourceType": "subscriberUsageAggregates",
        >    "path":"https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json"
        >  },
        >  {
        >    "resourceType": "usageAggregates",
        >    "path":"https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json"
        > }
        >]
        >},   

    - **specification/commerce/resource-manager/readme.md:**    
    Add the following Tag based on the json path in profile
        >### Tag: profile-hybrid-2020-09-01
        >
        >These settings apply only when `--tag=profile-hybrid-2020-09-01` is specified on the command line.
        >
        >``` yaml $(tag) == 'profile-hybrid-2020-09-01'
        >input-file:
        >- Microsoft.Commerce/preview/2015-06-01-preview/commerce.json
        >```

   - **specification/commerce/resource-manager/readme.csharp.md:**   
    Add the following Tag to point to the specified Tag in readme.md. (If the file doesn't exsit, create one based on other *.csharp.md file)   
        >### Profile: hybrid_2020_09_01
        >
        >These settings apply only when `--csharp-profile=hybrid_2020_09_01` is specified on the command line.
        >
        >``` yaml $(csharp-profile)=='hybrid_2020_09_01'
        >namespace: Microsoft.Azure.Management.Profiles.$(csharp-profile).Commerce
        >output-folder: $(csharp-sdks-folder)/$(csharp-profile)/Commerce/Management.Commerce/Generated
        >
        >batch:
        >  - tag: profile-hybrid-2020-09-01
        >```

3. Create hybrid folder for each RP:   
   - `/src/Profiles/hybrid_YYYY_MM_DD/RP`

4. Track 1 SDK doesn't have a template to create a project, so just copy previous RP's project. Modify following file with the right content, like API version, RP name...:   
   - `Management.RP.Profiles.Hybrid-YYYY-MM-DD.sln`
   - `AzSdk.Profiles.RP.props`
   - `./Management.RP/Management.RP.Profiles.Hybrid-YYYY-MM-DD.csproj`

5. Modify `./Management.RP/generate.ps1` file with the correct RP and Tag, If you use a fork repo, make sure you added `-SpecsRepoBranch` and `-SpecsRepoFork` parameters to point to your own repo & branch.   
   `Start-AutoRestCodeGeneration -ResourceProvider "authorization/resource-manager" -AutoRestVersion "v2" -AutoRestCodeGenerationFlags "--csharp-profile=hybrid_2020_09_01" -SdkGenerationDirectory "$PSScriptRoot\Generated"`
6. Run `generate.ps1`, should create new generated code based on your setting, you can check the api version in code later.   
If the `Start-AutoRestCodeGeneration` command report cmdlet not found error, install the build tool under [SDK](https://github.com/Azure/azure-sdk-for-net) folder with command `msbuild eng/mgmt.proj /t:Util /p:UtilityName=InstallPsModules.`
7. Run `dotnet build` under `./Management.RP/` folder to check if the RP could successfully build.
8. If you used a fork rest-api Repo. When you get all the RPs done, try to create a PR to [Azure/azure-rest-api-specs](https://github.com/Azure/azure-rest-api-specs) Repo with the Profile Tag changes you made. After that, you could saftly remove `-SpecsRepoBranch` and `-SpecsRepoFork` parameters from `generate.ps1` file.