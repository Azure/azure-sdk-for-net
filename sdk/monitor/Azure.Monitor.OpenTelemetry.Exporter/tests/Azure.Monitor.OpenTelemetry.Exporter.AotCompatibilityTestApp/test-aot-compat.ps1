param([string]$targetNetFramework)

dotnet restore
$publishOutput = dotnet publish --framework net7.0 -nodeReuse:false /p:UseSharedCompilation=false /p:ExposeExperimentalFeatures=true

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
$expectedWarningCount = 7
# Known warnings:
# - Azure.Core.Serialization.DynamicData: Using member 'Azure.Core.Serialization.DynamicData.DynamicDataJsonConverter.DynamicDataJsonConverter()'
# - 4x Azure.RequestFailedException.TryExtractErrorContent(): Using member 'System.Text.Json.JsonSerializer.Deserialize<>()' (https://github.com/Azure/azure-sdk-for-net/pull/38996)
# - Azure.Core.Json.MutableJsonDocument: Using member 'Azure.Core.Json.MutableJsonDocument.MutableJsonDocumentConverter.MutableJsonDocumentConverter()'
# - Microsoft.Extensions.DependencyInjection.ServiceLookup.IEnumerableCallSite.ServiceType.get: Using member 'System.Type.MakeGenericType(Type[])

$testPassed = 0
if ($actualWarningCount -ne $expectedWarningCount)
{
    $testPassed = 1
    Write-Host "Actual warning count:", $actualWarningCount, "is not as expected. Expected warning count is:", $expectedWarningCount
}

Exit $testPassed
