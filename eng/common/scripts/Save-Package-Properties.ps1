[CmdletBinding()]
Param (
  [Parameter(Mandatory=$True)]
  [string] $serviceDirectory,
  [Parameter(Mandatory=$True)]
  [string] $outDirectory
)

. (Join-Path $PSScriptRoot common.ps1)
$allPackageProperties = Get-AllPkgProperties $serviceDirectory
if ($allPackageProperties)
{
    New-Item -ItemType Directory -Force -Path $outDirectory
    foreach($pkg in $allPackageProperties)
    {
        if ($pkg.IsNewSdk)
        {
            Write-Host "Package Name: $($pkg.Name)"
            Write-Host "Package Version: $($pkg.Version)"
            Write-Host "Package SDK Type: $($pkg.SdkType)"
            $outputPath = Join-Path -Path $outDirectory ($pkg.Name + ".json")
            $outputObject = $pkg | ConvertTo-Json
            Set-Content -Path $outputPath -Value $outputObject
        }        
    }

    Get-ChildItem -Path $outDirectory
}
else
{
    Write-Error "Package properties are not available for service directory $($serviceDirectory)"
    exit 1
}

