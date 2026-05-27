#Requires -Version 7.0
<#
.SYNOPSIS
Post-generation fixups for the ApiManagement MPG-generated SDK.

.DESCRIPTION
The MPG generator emits invalid serialization code for the
RequestReportRecordContract.method property: it conflates the model property
named "method" with Azure.Core.RequestMethod and emits:

    writer.WriteObjectValue<RequestMethod?>(Method.Value, options);
    @method = RequestMethod.DeserializeRequestMethod(prop.Value, options);

Neither call exists on Azure.Core.RequestMethod, so the build fails with
CS0117 / CS1503. This script rewrites those two call sites to the correct
RequestMethod (struct) serialization shape.

The script is wired into Azure.ResourceManager.ApiManagement.csproj via an
AfterTargets="GenerateCode" Exec target, so it runs both during local regen
and during CI's `dotnet msbuild eng/service.proj /t:GenerateCode`.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string] $PackageRoot
)

$ErrorActionPreference = 'Stop'
$generatedRoot = Join-Path $PackageRoot 'src\Generated'
if (-not (Test-Path -LiteralPath $generatedRoot)) {
    Write-Host "Post-gen fixups: '$generatedRoot' not found; nothing to do."
    exit 0
}

$target = Join-Path $generatedRoot 'Models\RequestReportRecordContract.Serialization.cs'
$updated = 0

if (Test-Path -LiteralPath $target) {
    $content = [System.IO.File]::ReadAllText($target)
    $original = $content

    # Fix Write: writer.WriteObjectValue<RequestMethod?>(Method.Value, options);
    # -> writer.WriteStringValue(Method.Value.Method);
    $content = $content -creplace `
        'writer\.WriteObjectValue<RequestMethod\?>\(Method\.Value, options\);', `
        'writer.WriteStringValue(Method.Value.Method);'

    # Fix Read: @method = RequestMethod.DeserializeRequestMethod(prop.Value, options);
    # -> @method = new RequestMethod(prop.Value.GetString());
    $content = $content -creplace `
        '@method = RequestMethod\.DeserializeRequestMethod\(prop\.Value, options\);', `
        '@method = new RequestMethod(prop.Value.GetString());'

    if ($content -cne $original) {
        [System.IO.File]::WriteAllText($target, $content)
        $updated++
    }
}

Write-Host "Post-gen fixups for ApiManagement: updated $updated file(s)."
