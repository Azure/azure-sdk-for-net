To workaround an issue with https://github.com/Azure/azure-sdk-for-net/issues/7490 we are simply going to
include the contents of the package in the repo itself, given that it is just a props and targets file.

If this needs to be updated go and download the latest package from
https://www.nuget.org/packages/Microsoft.Build.CentralPackageVersions and extract the sdk.props/targets
file from the package and put them under a folder matching the version of the package. Then update
the places we are importing those files to include the updated version number. Currently only
the CentralPackageVersionPackagePath property in Directory.Build.Data.targets. Be sure to cleam up
the old version as well.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Feng%2FMicrosoft.Build.CentralPackageVersions%2FReadme.png)
