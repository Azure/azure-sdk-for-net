<#
.SYNOPSIS
Create a default assets.json for a given ServiceDirectory or deeper.

.DESCRIPTION
Requirements:
1. git will need to be in the path.
2. This script will need to be run locally in a an azure-sdk-for-<language> repository. Further, this
needs to be run at an sdk/<ServiceDirectory> or deeper. For example sdk/core if the assets.json is
being created at the service directory level or sdk/core/<somelibrary> if the assets.json is being
created at the library level. A good rule here would be to run this in the same directory where the ci.yml
file lives. For most this is the sdk/<ServiceDirectory>, but some services emplace a ci.yml alongside each package.
In that case, the assets.json should live alongside the ci.yml in the sdk/<ServiceDirectory>/<library> directory.

Generated assets.json file contents
- AssetsRepo: "Azure/azure-sdk-assets" - This is the assets repository, aka where your recordings will live after this script runs.
- AssetsRepoPrefixPath: "<language>" - this is will be computed from repository it's being run in.
- TagPrefix: "<language>/<ServiceDirectory>" or "<language>/<ServiceDirectory>/<library>" or deeper if things
              are nested in such a manner. All tags created for this assets.json will start with this name.
- Tag: "" - Initially empty, as nothing has yet been pushed.

If flag InitialPush is set, recordings will be automatically pushed to the assets repo and the Tag property updated.

.PARAMETER TestProxyExe
The executable used during the "InitialPush" action. Defaults to the dotnet tool test-proxy, but also supports custom executables as well.

If the user provides their own value that doesn't match options "test-proxy" the script will use this input as the test-proxy exe
when invoking commands. EG "$TestProxyExe push -a sdk/keyvault/azure-keyvault-keys/assets.json."

.PARAMETER InitialPush
Pass this flag to automagically move all recordings found UNDER your assets.json to an assets repo.

Detailed process:
- Create a temp directory.
- Call "restore" against that assets directory to prepare it to receive updates.
- Move all recordings found under the assets.json within the language repo to the assets directory prepared by the restore operation in the previous step.
- Push moved recordings to the assets repo.
- Update the assets.json with the new tag.

.PARAMETER UseTestRepo
Enabling this parameter will result in an assets.json that points at repo Azure/azure-sdk-assets-integration. This is the
integration repo that the azure-sdk EngSys team uses to integration test this script and other asset-sync features.

Most library devs should ignore this setting unless directed otherwise (or if they're curious!). Permissions to the integration
repo are identical to the default assets repo.

#>
param(
  [Parameter(Mandatory = $false)]
  [string] $TestProxyExe = "test-proxy",
  [switch] $InitialPush,
  [switch] $UseTestRepo
)

# Git needs to be in the path to determine the language and, if the initial push
# is being performed, for the CLI commands to work
$GitExe = "git"

# The built test proxy on a dev machine will have the version 1.0.0-dev.20221013.1
# whereas the one installed from nuget will have the version 20221013.1 (minus the 1.0.0-dev.)
$MinTestProxyVersion = "20221017.4"

$DefaultAssetsRepo = "Azure/azure-sdk-assets"
if ($UseTestRepo) {
  $DefaultAssetsRepo = "Azure/azure-sdk-assets-integration"
  Write-Host "UseTestRepo was true, setting default repo to $DefaultAssetsRepo"
}

# Unsure of the following language recording directories:
# 1. andriod
# 2. c
# 3. ios
$LangRecordingDirs = @{"cpp" = "recordings";
  "go"                       = "recordings";
  "java"                     = "src.*?session-records";
  "js"                       = "recordings";
  "net"                      = "SessionRecords";
  "python"                   = "recordings";
};

. (Join-Path $PSScriptRoot "common-asset-functions.ps1")

Test-Exe-In-Path -ExeToLookFor $GitExe

$language = Get-Repo-Language

# If the initial push is being performed, ensure that test-proxy is
# in the path and that we're able to map the language's recording
# directories
if ($InitialPush) {
  $proxyPresent = Test-Exe-In-Path -ExeToLookFor $TestProxyExe -ExitOnError $false

  # try to fall back
  if (-not $proxyPresent) {
    $StandaloneTestProxyExe = "Azure.Sdk.Tools.TestProxy"

    if ($IsWindows) {
      $StandaloneTestProxyExe += ".exe"
    }

    $standalonePresent = Test-Exe-In-Path -ExeToLookFor $StandaloneTestProxyExe -ExitOnError $false

    if ($standalonePresent) {
      Write-Host "Default proxy exe $TestProxyExe is not present, but standalone tool $StandaloneTestProxyExe is. Updating proxy exe to use the standalone version."
      $TestProxyExe = $StandaloneTestProxyExe
    }
    else {
      Write-Error "The user has selected option InitialPush to push their assets, neither $TestProxyExe nor standalone executable $StandaloneTestProxyExe are installed on this machine."
      exit 1
    }

    # if we're pushing, we also need to confirm that the necessary git configuration items are set
    $result = git config --get user.name
    if ($LASTEXITCODE -ne 0 -or !$result){
      Write-Error "The git config setting `"user.name`" is unset. Set it to your git user name via 'git config --global user.name `"<setting>`'"
    }

    $result = git config --get user.email
    if ($LASTEXITCODE -ne 0 -or !$result){
      Write-Error "The git config setting `"user.email`" is unset. Set it to your git email via 'git config --global user.email `"<setting>`'"
    }
  }

  if ($TestProxyExe -eq "test-proxy" -or $TestProxyExe.StartsWith("Azure.Sdk.Tools.TestProxy")) {
    Test-TestProxyVersion -TestProxyExe $TestProxyExe
  }

  if (!$LangRecordingDirs.ContainsKey($language)) {
    Write-Error "The language, $language, does not have an entry in the LangRecordingDirs dictionary."
    exit 1
  }
}

$repoRoot = Get-Repo-Root

# Create the assets-json file
$assetsJsonFile = New-Assets-Json-File -Language $language

# If the initial push is being done:
# 1. Do a restore on the assetsJsonFile, it'll setup the directory that will allow a push to be done
# 2. Move all of the assets over, preserving the directory structure
# 3. Push the repository which will update the assets.json with the new Tag
if ($InitialPush) {
  try {
    $assetsJsonRelPath = [System.IO.Path]::GetRelativePath($repoRoot, $assetsJsonFile)

    # Execute a restore on the current assets.json, it'll prep the root directory that
    # the recordings need to be copied into
    $CommandArgs = "restore --assets-json-path $assetsJsonRelPath"
    Invoke-ProxyCommand -TestProxyExe $TestProxyExe -CommandString $CommandArgs -TargetDirectory $repoRoot

    $assetsRoot = (Get-AssetsRoot -AssetsJsonFile $assetsJsonFile -TestProxyExe $TestProxyExe)
    Write-Host "assetsRoot=$assetsRoot"

    Move-AssetsFromLangRepo -AssetsRoot $assetsRoot

    $CommandArgs = "push --assets-json-path $assetsJsonRelPath"
    Invoke-ProxyCommand -TestProxyExe $TestProxyExe -CommandString $CommandArgs -TargetDirectory $repoRoot

    # Verify that the assets.json file was updated
    $updatedAssets = Get-Content $assetsJsonFile | Out-String | ConvertFrom-Json
    if ([String]::IsNullOrWhitespace($($updatedAssets.Tag))) {
      Write-Error "AssetsJsonFile ($assetsJsonFile) did not have it's tag updated. Check above output messages for erroneous git output."
      exit 1
    }
  }
  catch {
    $ex = $_
    Write-Host $ex
    exit 1
  }
}
