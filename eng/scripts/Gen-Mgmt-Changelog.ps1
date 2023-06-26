[CmdletBinding()]
param (
    [Parameter(Position=0, Mandatory=$true, HelpMessage="The service name under folder .../sdk/")]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceName,
    [Parameter(Position=1, Mandatory=$true, HelpMessage="Release version, i.e. 1.0.1")]
    [ValidateNotNullOrEmpty()]
    [string] $ReleaseVersion,
    [Parameter(Position=2, Mandatory=$true, HelpMessage="Release date in format xxxx-xx-xx. i.e. 2023-01-10")]
    [ValidateNotNullOrEmpty()]
    [string] $ReleaseDate
)

$apiFilePathArray = Resolve-Path "$PSScriptRoot/../../sdk/$ServiceName/Azure.ResourceManager.*/api/Azure.ResourceManager.*.netstandard2.0.cs"

if($apiFilePathArray.Length -ne 1)
{
    Write-Error "Multiple api files resolved."
    $apiFilePathArray | Write-Error
}
else {
    dotnet tool update Azure.SDK.Management.ChangelogGen -g --add-source https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json  --prerelease --interactive

    changelog-gen-mgmt $apiFilePathArray[0] $ReleaseVersion $ReleaseDate    
}
