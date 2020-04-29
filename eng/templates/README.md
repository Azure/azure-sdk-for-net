# DotNet project templates

## Azure.Management SDK client library template

To install the template (one-time step), run following commands:
* dotnet new -i `Path to SDK repo`\eng\templates\AzureManagement.Template

To create a new management SDK project:
* Create folder `Azure.Management.Rp` under corresponding service folder, ie under network\Azure.Management.Network 
* Change to the `Azure.Management.Rp` folder 
* dotnet new azuremgmt --provider `ResourceProviderName` --swagger `PATH to Swagger JSON or README.MD`

> Note: Please use proper casing for the directory name as well as resource provider name. `Azure.Management.Rp`, `Microsoft.Compute` or `Microsoft.KeyVault`.

To list help and creation options for this template:
* dotnet new azuremgmt -h