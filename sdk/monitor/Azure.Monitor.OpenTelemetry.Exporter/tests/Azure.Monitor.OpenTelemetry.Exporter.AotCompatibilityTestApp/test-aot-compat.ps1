param([string]$targetNetFramework)

dotnet restore
$publishOutput = dotnet publish --framework net8.0 -nodeReuse:false /p:UseSharedCompilation=false /p:ExposeExperimentalFeatures=true

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

Write-Host "Actual warning count is:", $actualWarningCount
$expectedWarningCount = 0

$testPassed = 0
if ($actualWarningCount -ne $expectedWarningCount)
{
    $testPassed = 1
    Write-Host "Actual warning count:", $actualWarningCount, "is not as expected. Expected warning count is:", $expectedWarningCount
}

Exit $testPassed
