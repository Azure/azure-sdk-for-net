# DotNet project templates (DO NOT USE!)

*  This document is for Track 2 .NET SDK (Azure.ResourceManager.XXX). Not for track 1 .NET SDK (Microsoft.Azure.Management.XXX)

## Azure.ResourceManager SDK client library template

### To install the template (one-time step), run following commands:

```
dotnet new install `Path to SDK repo`\eng\templates\Azure.ResourceManager.Template
```

###  List help and (ToAzure.ResourceManager.XXX) creation options for  this template:

```
dotnet new azuremgmt --help
```

Following parameter is available
| Parameter | Required | Description |
| ---- | ---- | ---- |
| -p, --provider | Yes | The Azure provider name. For example, `Microsoft.Network` or `Microsoft.Compute`. Note this parameter is also used for diagnostic attribute in AssemblyInfo.cs. The second part of the provider name `Compute` is also used in  `src\autorest.md` to point to REST Api spec `specifications\Compute\resource-manager\readme.md`. If they mismatch, manual adjustment is needed in `autorest.md`. |
| -t, --tagVersion | No | Specifies the package tag in the README.MD. If empty, CodeGen will rely on the default tag in the README.MD is used. If default tag isn't present, CodeGen may fail. |
| -in, --includeCI | No | Specifies whether `ci.mgmt.yml` will be created in the parent folder. Token replacements have been performed on `ci.mgmt.yml` based on current project name. *Note*, for now, you still need to change `sdk/template/` to `sdk/RP` and serviceDirectory: to RP folder name. This issue would be fixed in the future. |

---


### To create a new management SDK project:

* Create folder `Azure.ResourceManager.Rp` under corresponding service folder that is under network\Azure.ResourceManager.Network
* Change to the `Azure.ResourceManager.Rp` folder
* dotnet new azuremgmt --provider `ResourceProviderName`  **OR**
* dotnet new azuremgmt --provider `ResourceProviderName` --tagVersion `Optional tag in README.MD`  **OR**
* dotnet new azuremgmt --provider `ResourceProviderName` --includeCI true
* ..\..\eng\scripts Update-Mgmt-CI.ps1
*
> Note: The last step updates the ci paths in Azure.ResourceManager ci.mgmt.yml file so that it will run anytime this new package changes
> Note: Please use proper casing for the directory name as well as resource provider name. `Azure.ResourceManager.Rp`, `Microsoft.Compute` or `Microsoft.KeyVault`. The resource provider name without `Microsoft.` will be used in autorest.md file pointing to the  `https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/<resource name>/resource-manager/readme.md`

---


### Next Step
1. Inspect `tsp-location.yaml` to ensure the REST Api path is valid
2. Run `dotnet build` to ensure empty project builds successfully.
3. Run `dotnet build /t:GenerateCode` to generate C# code and ensure no fatal errors.
4. Run `dotnet build` to ensure now generated project builds successfully.
5. Viola!
