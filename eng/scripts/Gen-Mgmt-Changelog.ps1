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
    [string] $ReleaseDate,
    [Parameter(HelpMessage="Exact path to the package API listing. When omitted, the path is resolved from the service name.")]
    [string] $ApiFilePath
)

if ($ApiFilePath) {
    $apiFilePathArray = @(Resolve-Path $ApiFilePath)
}
else {
    $apiFilePathArray = @(Resolve-Path "$PSScriptRoot/../../sdk/$ServiceName/Azure.ResourceManager.*/api/Azure.ResourceManager.*.netstandard2.0.cs")
}

if($apiFilePathArray.Count -ne 1)
{
    Write-Error "Expected one API file, but resolved $($apiFilePathArray.Count)."
    $apiFilePathArray | Write-Error
}
else {
    dotnet tool update Azure.SDK.Management.ChangelogGen -g --add-source https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json  --prerelease --interactive
    if ($LASTEXITCODE -ne 0) {
        throw 'Failed to install Azure.SDK.Management.ChangelogGen.'
    }

    # The tool can log a caught exception yet return zero; do not report false success.
    $output = @(changelog-gen-mgmt $apiFilePathArray[0] $ReleaseVersion $ReleaseDate 2>&1)
    $exitCode = $LASTEXITCODE
    $output | ForEach-Object { Write-Host $_ }
    if ($exitCode -ne 0 -or ($output -join "`n") -match '(?im)^\s*(Error occurs when generating changelog:|Detail exception:)') {
        throw 'Management changelog generation failed. See the tool output above.'
    }
}
