param([string]$targetNetFramework)

dotnet clean
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
$expectedWarningCount = 16
# Known warnings:
# - IL2026: Azure.Core.Serialization.DynamicData: Using member 'Azure.Core.Serialization.DynamicData.DynamicDataJsonConverter.DynamicDataJsonConverter()' which has 'RequiresUnreferencedCodeAttribute'
# - IL3050: Azure.Core.Serialization.DynamicData: Using member 'Azure.Core.Serialization.DynamicData.DynamicDataJsonConverter.DynamicDataJsonConverter()' which has 'RequiresDynamicCodeAttribute'
# - AzureCoreEventSource.cs(61): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.Request(String,String,String,String,String): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(83): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.RequestContent(String,Byte[]): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(104): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.Response(String,Int32,String,String,Double): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(126): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.ResponseContent(String,Byte[]): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(154): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.ResponseContentBlock(String,Int32,Byte[]): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(160): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.ResponseContentTextBlock(String,Int32,String): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(175): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.ErrorResponse(String,Int32,String,String,Double): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(197): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.ErrorResponseContent(String,Byte[]): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(225): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.ErrorResponseContentBlock(String,Int32,Byte[]): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(231): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.ErrorResponseContentTextBlock(String,Int32,String): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(244): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.ResponseDelay(String,Double): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - AzureCoreEventSource.cs(265): Trim analysis warning IL2026: Azure.Core.Diagnostics.AzureCoreEventSource.RequestRedirect(String,String,String,Int32): Using member 'System.Diagnostics.Tracing.EventSource.WriteEvent(Int32,Object[])' which has 'RequiresUnreferencedCodeAttribute'
# - IL2026: Azure.Core.Json.MutableJsonDocument: Using member 'Azure.Core.Json.MutableJsonDocument.MutableJsonDocumentConverter.MutableJsonDocumentConverter()' which has 'RequiresUnreferencedCodeAttribute'
# - IL3050: Azure.Core.Json.MutableJsonDocument: Using member 'Azure.Core.Json.MutableJsonDocument.MutableJsonDocumentConverter.MutableJsonDocumentConverter()' which has 'RequiresDynamicCodeAttribute'

$testPassed = 0
if ($actualWarningCount -ne $expectedWarningCount)
{
    $testPassed = 1
    Write-Host "Actual warning count:", $actualWarningCount, "is not as expected. Expected warning count is:", $expectedWarningCount
}

Exit $testPassed
