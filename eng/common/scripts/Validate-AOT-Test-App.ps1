param([string]$serviceDirectory)
param([string]$artifact)
param([int]$numExpectedWarnings)

$startingDirectory = $PWD
$packageProperties = Get-PkgProperties -PackageName $PackageName -ServiceDirectory $ServiceDirectory
$sampleAppPath = Join-Path $packageProperties.pkgDirectoryPath 'aotcompatibility'

Write-Host "Validating the number of expected IL trimming warnings."
Write-Host "Attempting to publish the console app located at: azure-sdk-for-net/sdk/", $serviceDirectory, "/" $artifact, "/aotcompatibility"

Set-Location -Path $sampleAppLocation

$publishOutput = dotnet publish -nodeReuse:false /p:UseSharedCompilation=false /p:ExposeExperimentalFeatures=true

if ($LASTEXITCODE -ne 0)
{
    Write-Host "Publish failed."
    Write-Host $publishOutput
    Exit 2
}

$actualWarningCount = 0

foreach ($line in $($publishOutput -split "`r`n"))
{
    if ($line -like "*analysis warning IL*")
    {
        Write-Host $line

        $actualWarningCount += 1
    }
}

$testPassed = 0
if ($actualWarningCount -ne $numExpectedWarnings)
{
    $testPassed = 1
    Write-Host "Actual warning count:", actualWarningCount, "is not as expected. Expected warning count is:", $expectedWarningCount
}

Set-Location -Path $startingDirectory

Exit $testPassed