[CmdletBinding()]
Param (
  [Parameter(Mandatory=$True)]
  [string] $serviceName,
  [Parameter(Mandatory=$True)]
  [string] $OutDirectory
)

. (Join-Path $PSScriptRoot common.ps1)
$allPackageProperties = @{}
if (Test-Path "Function:Get-AllPkgProperties")
{
    $allPackageProperties = Get-AllPkgProperties $serviceName
}
else
{
    Write-Host "The function Get-AllPkgProperties was not found."
}

if ($allPackageProperties)
{
    New-Item -ItemType Directory -Force -Path $OutDirectory
    foreach($pkg in $allPackageProperties)
    {
        Write-Host "Package Name: $($pkg.Name)"
        Write-Host "Package Version: $($pkg.Version)"
        Write-Host "Package SDK Type: $($pkg.SdkType)"
        $outputPath = Join-Path -Path $OutDirectory ($pkg.Name + ".json")
        $outputObject = @{name = $pkg.Name; version = $pkg.Version; SdkType = $pkg.SdkType } | ConvertTo-Json
        Set-Content -Path $outputPath -Value $outputObject
    }

    Get-ChildItem -Path $OutDirectory
}
else
{
    Write-Host "Package properties are not available for service directory $($serviceName)"
    exit(1)
}

