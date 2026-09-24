<#
.SYNOPSIS
    Adds a provisioning emitter to an Azure TypeSpec project and generates a new SDK package.

.DESCRIPTION
    Creates clean SDK and spec branches from Azure/main, updates the spec emitter configuration,
    commits and pushes the spec change, scaffolds the provisioning package, and runs GenerateCode.
    Use -CreateDraftPullRequests to open the spec draft PR after generation.

.EXAMPLE
    .\Onboard-ProvisioningLibrary.ps1 `
        -ServiceDirectory appnetwork `
        -PackageName AppNetwork `
        -ResourceProvider AppLink `
        -SpecRepoPath D:\Azure\azure-rest-api-specs `
        -SpecProjectDirectory specification/applink/AppLink.Management `
        -Namespace Azure.Provisioning.AppNetwork `
        -ApiVersion 2026-08-01-preview
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$ServiceDirectory,

    [Parameter(Mandatory)]
    [string]$PackageName,

    [string]$ResourceProvider = $PackageName,

    [Parameter(Mandatory)]
    [string]$SpecRepoPath,

    [Parameter(Mandatory)]
    [string]$SpecProjectDirectory,

    [Parameter(Mandatory)]
    [string]$Namespace,

    [Parameter(Mandatory)]
    [string]$ApiVersion,

    [string]$SdkBranch = "provisioning-$($ServiceDirectory)-onboarding",

    [string]$SpecBranch = "provisioning-$($ServiceDirectory)-emitter",

    [switch]$CreateDraftPullRequests
)

$ErrorActionPreference = "Stop"
$SdkRepoPath = (Resolve-Path (Join-Path $PSScriptRoot "..\..\..")).Path
$SpecRepoPath = (Resolve-Path $SpecRepoPath).Path
$PackageDirectory = Join-Path $SdkRepoPath "sdk\$ServiceDirectory\Azure.Provisioning.$PackageName"
$SpecConfigPath = Join-Path $SpecRepoPath "$SpecProjectDirectory\tspconfig.yaml"
$SpecRepoName = "Azure/azure-rest-api-specs"
$SdkRepoName = "Azure/azure-sdk-for-net"

function Invoke-Git {
    param(
        [Parameter(Mandatory)][string]$Repository,
        [Parameter(Mandatory)][string[]]$Arguments
    )

    & git -C $Repository @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "git $($Arguments -join ' ') failed in $Repository"
    }
}

function Assert-AzureOrigin {
    param([Parameter(Mandatory)][string]$Repository, [Parameter(Mandatory)][string]$Expected)

    $origin = (& git -C $Repository remote get-url origin).Trim()
    if ($origin -notmatch "github\.com[/:]Azure/$([regex]::Escape(($Expected -split "/")[1]))(?:\.git)?$") {
        throw "The origin remote for $Repository is '$origin'. Expected an Azure/$Expected repository."
    }
}

function Assert-CleanRepository {
    param([Parameter(Mandatory)][string]$Repository)

    $status = (& git -C $Repository status --porcelain)
    if ($status) {
        throw "Repository is not clean: $Repository`n$status"
    }
}

function Set-ProvisioningEmitter {
    param([Parameter(Mandatory)][string]$Path)

    $content = Get-Content $Path -Raw
    if ($content -match [regex]::Escape("@azure-typespec/http-client-csharp-provisioning")) {
        throw "Provisioning emitter is already configured in $Path"
    }

    $outputDirectory = "{output-dir}/sdk/$ServiceDirectory/Azure.Provisioning.$PackageName"
    $block = @"
  "@azure-typespec/http-client-csharp-provisioning":
    namespace: "$Namespace"
    emitter-output-dir: "$outputDirectory"
    api-version: "$ApiVersion"
"@

    if ($content -notmatch "(?m)^linter:") {
        throw "Could not find the linter section in $Path"
    }

    $content = [regex]::Replace($content, "(?m)^linter:", "$block`r`nlinter:", 1)
    Set-Content -Path $Path -Value $content -NoNewline
}

function Write-IfMissing {
    param([Parameter(Mandatory)][string]$Path, [Parameter(Mandatory)][string]$Content)

    if (-not (Test-Path $Path)) {
        New-Item -ItemType Directory -Force -Path (Split-Path $Path) | Out-Null
        Set-Content -Path $Path -Value $Content -NoNewline
    }
}

Assert-AzureOrigin -Repository $SdkRepoPath -Expected $SdkRepoName
Assert-AzureOrigin -Repository $SpecRepoPath -Expected $SpecRepoName
Assert-CleanRepository -Repository $SdkRepoPath
Assert-CleanRepository -Repository $SpecRepoPath

Invoke-Git -Repository $SdkRepoPath -Arguments @("fetch", "origin", "main")
Invoke-Git -Repository $SpecRepoPath -Arguments @("fetch", "origin", "main")
Invoke-Git -Repository $SdkRepoPath -Arguments @("switch", "-C", $SdkBranch, "origin/main")
Invoke-Git -Repository $SpecRepoPath -Arguments @("switch", "-C", $SpecBranch, "origin/main")

Set-ProvisioningEmitter -Path $SpecConfigPath
Invoke-Git -Repository $SpecRepoPath -Arguments @("add", $SpecConfigPath)
Invoke-Git -Repository $SpecRepoPath -Arguments @(
    "commit",
    "-m",
    "Add $PackageName provisioning emitter config",
    "-m",
    "Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>"
)
Invoke-Git -Repository $SpecRepoPath -Arguments @("push", "-u", "origin", $SpecBranch)
$specCommit = (& git -C $SpecRepoPath rev-parse HEAD).Trim()

Write-IfMissing -Path (Join-Path $PackageDirectory "Azure.Provisioning.$PackageName.slnx") -Content @"
<Solution>
  <Project Path="src/Azure.Provisioning.$PackageName.csproj" />
  <Project Path="tests/Azure.Provisioning.$PackageName.Tests.csproj" />
</Solution>
"@

Write-IfMissing -Path (Join-Path $PackageDirectory "Directory.Build.props") -Content @"
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="`$([MSBuild]::GetDirectoryNameOfFileAbove(`$(MSBuildThisFileDirectory).., Directory.Build.props))\Directory.Build.props" />

  <PropertyGroup>
    <ExperimentalProvisioning Condition="'`$(ExperimentalProvisioning)' == ''">false</ExperimentalProvisioning>
    <DefineConstants Condition="'`$(ExperimentalProvisioning)' == 'true'">EXPERIMENTAL_PROVISIONING;`$(DefineConstants)</DefineConstants>
  </PropertyGroup>

  <PropertyGroup>
    <TargetFrameworks>`$(RequiredTargetFrameworks)</TargetFrameworks>
    <IsMgmtLibrary>true</IsMgmtLibrary>
    <IncludeOperationsSharedSource>true</IncludeOperationsSharedSource>
  </PropertyGroup>

  <PropertyGroup>
    <NoWarn>
      `$(NoWarn);
      AZC0034;
      AZC0035;
    </NoWarn>
  </PropertyGroup>

  <ItemGroup>
    <Compile Include="`$(AzureCoreSharedSources)ExperimentalAttribute.cs" LinkBase="Shared\Core" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="Azure.Core" Condition="`$(UseProjectReferenceToAzureClients) == 'true'" />
  </ItemGroup>
</Project>
"@

Write-IfMissing -Path (Join-Path $PackageDirectory "CHANGELOG.md") -Content @"
# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial beta release of Azure.Provisioning.$PackageName.
"@

Write-IfMissing -Path (Join-Path $PackageDirectory "metadata.json") -Content @"
{
  "apiVersions": {
    "Microsoft.$ResourceProvider": "$ApiVersion"
  }
}
"@

Set-Content -Path (Join-Path $PackageDirectory "tsp-location.yaml") -Value @"
directory: $SpecProjectDirectory
commit: $specCommit
repo: $SpecRepoName
additionalDirectories:

emitterPackageJsonPath: "eng/azure-typespec-http-client-csharp-provisioning-emitter-package.json"
"@ -NoNewline

Write-IfMissing -Path (Join-Path $PackageDirectory "src\Azure.Provisioning.$PackageName.csproj") -Content @"
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <Description>Azure.Provisioning.$PackageName simplifies declarative provisioning for $PackageName in .NET.</Description>
    <Version>1.0.0-beta.1</Version>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Azure.Provisioning" />
  </ItemGroup>

</Project>
"@

Write-IfMissing -Path (Join-Path $PackageDirectory "tests\Azure.Provisioning.$PackageName.Tests.csproj") -Content @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="..\..\..\core\Azure.Core.TestFramework\src\Azure.Core.TestFramework.csproj" />
    <ProjectReference Include="..\..\..\provisioning\Azure.Provisioning\src\Azure.Provisioning.csproj" />
    <ProjectReference Include="..\src\Azure.Provisioning.$PackageName.csproj" />
    <ProjectReference Include="..\..\..\provisioning\Azure.Provisioning.Deployment\src\Azure.Provisioning.Deployment.csproj" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="..\..\..\..\common\ProvisioningTestShared\*.cs" LinkBase="Shared\ProvisioningTestShared" />
  </ItemGroup>
</Project>
"@

$ciPath = Join-Path $SdkRepoPath "sdk\$ServiceDirectory\ci.mgmt.yml"
if (Test-Path $ciPath -and -not (Select-String -Path $ciPath -Pattern "Azure\.Provisioning\.$PackageName" -Quiet)) {
    Add-Content -Path $ciPath -Value @"
    - name: Azure.Provisioning.$PackageName
      safeName: AzureProvisioning$PackageName
"@
}

Push-Location (Join-Path $PackageDirectory "src")
try {
    & dotnet build /t:GenerateCode
    if ($LASTEXITCODE -ne 0) {
        throw "Provisioning SDK generation failed"
    }
}
finally {
    Pop-Location
}

if ($CreateDraftPullRequests) {
    gh pr create --repo $SpecRepoName --head $SpecBranch --base main --draft `
        --title "Add $PackageName provisioning emitter config" `
        --body "Enables the Azure.Provisioning.$PackageName emitter. SDK tsp-location.yaml commit: $specCommit"
    if ($LASTEXITCODE -ne 0) {
        throw "Spec draft PR creation failed"
    }
}

Write-Host "Spec commit: $specCommit"
Write-Host "SDK package: $PackageDirectory"
Write-Host "SDK generation completed."
