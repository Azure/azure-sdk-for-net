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
The executable used during the "InitialPush" action. Defaults to the dotnet tool test-proxy, but also supports "docker" or "podman".

If the user provides their own value that doesn't match options "test-proxy", "docker", or "podman", the script will use this input as the test-proxy exe
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

class Assets {
  [string]$AssetsRepo = $DefaultAssetsRepo
  [string]$AssetsRepoPrefixPath = ""
  [string]$TagPrefix = ""
  [string]$Tag = ""
  Assets(
    [string]$AssetsRepoPrefixPath,
    [string]$TagPrefix
  ) {
    $this.TagPrefix = $TagPrefix
    $this.AssetsRepoPrefixPath = $AssetsRepoPrefixPath
  }
}

class Version {
  [int]$Year
  [int]$Month
  [int]$Day
  [int]$Revision
  Version(
    [string]$VersionString
  ) {
    if ($VersionString -match "(?<year>20\d{2})(?<month>\d{2})(?<day>\d{2}).(?<revision>\d+)") {
      $this.Year = [int]$Matches["year"]
      $this.Month = [int]$Matches["month"]
      $this.Day = [int]$Matches["day"]
      $this.Revision = [int]$Matches["revision"]
    }
    else {
      # This should be a Write-Error however powershell apparently cannot utilize that
      # in the constructor in certain cases
      Write-Warning "Version String '$($VersionString)' is invalid and cannot be parsed"
      exit 1
    }
  }
  [bool] IsGreaterEqual([string]$OtherVersionString) {
    [Version]$OtherVersion = [Version]::new($OtherVersionString)
    if ($this.Year -lt $OtherVersion.Year) {
      return $false
    }
    elseif ($this.Year -eq $OtherVersion.Year) {
      if ($this.Month -lt $OtherVersion.Month) {
        return $false
      }
      elseif ($this.Month -eq $OtherVersion.Month) {
        if ($this.Day -lt $OtherVersion.Day) {
          return $false
        }
        elseif ($this.Day -eq $OtherVersion.Day) {
          if ($this.Revision -lt $OtherVersion.Revision) {
            return $false
          }
        }
      }
    }
    return $true
  }
}

Function Test-Exe-In-Path {
  Param([string] $ExeToLookFor, [bool]$ExitOnError = $true)
  if ($null -eq (Get-Command $ExeToLookFor -ErrorAction SilentlyContinue)) {
    if ($ExitOnError) {
      Write-Error "Unable to find $ExeToLookFor in your PATH"
      exit 1
    }
    else {
      return $false
    }
  }

  return $true
}

Function Test-TestProxyVersion {
  param(
    [string] $TestProxyExe
  )

  Write-Host "$TestProxyExe --version"
  [string] $output = & "$TestProxyExe" --version

  [Version]$CurrentProxyVersion = [Version]::new($output)
  if (!$CurrentProxyVersion.IsGreaterEqual($MinTestProxyVersion)) {
    Write-Error "$TestProxyExe version, $output, is less than the minimum version $MinTestProxyVersion"
    Write-Error "Please refer to https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md#installation to upgrade your $TestProxyExe"
    exit 1
  }
}

Function Get-Repo-Language {

  $GitRepoOnDiskErr = "This script can only be called from within an azure-sdk-for-<lang> repository on disk."
  # Git remote -v is going to give us output similar to the following
  # origin  git@github.com:Azure/azure-sdk-for-java.git (fetch)
  # origin  git@github.com:Azure/azure-sdk-for-java.git (push)
  # upstream        git@github.com:Azure/azure-sdk-for-java (fetch)
  # upstream        git@github.com:Azure/azure-sdk-for-java (push)
  # We're really only trying to get the language from the git remote
  Write-Host "git remote -v"
  [array] $remotes = & git remote -v
  foreach ($line in $remotes) {
    Write-Host "$line"
  }

  # Git remote -v returned "fatal: not a git repository (or any of the parent directories): .git"
  # and the list of remotes will be null
  if (-not $remotes) {
    Write-Error $GitRepoOnDiskErr
    exit 1
  }

  # The regular expression needed to be updated to handle the following types of input:
  # origin git@github.com:Azure/azure-sdk-for-python.git (fetch)
  # origin git@github.com:Azure/azure-sdk-for-python-pr.git (fetch)
  # fork git@github.com:UserName/azure-sdk-for-python (fetch)
  # azure-sdk https://github.com/azure-sdk/azure-sdk-for-net.git (fetch)
  # origin  https://github.com/Azure/azure-sdk-for-python/ (fetch)
  # ForEach-Object splits the string on whitespace so each of the above strings is actually
  # 3 different strings. The first and last pieces won't match anything, the middle string
  # will match what is below. If the regular expression needs to be updated the following
  # link below will go to a regex playground
  # https://regex101.com/r/auOnAr/1
  $lang = $remotes[0] | ForEach-Object { if ($_ -match "azure-sdk-for-(?<lang>[^\-\.\/ ]+)") {
      #Return the named language match
      return $Matches["lang"]
    }
  }

  if ([String]::IsNullOrWhitespace($lang)) {
    Write-Error $GitRepoOnDiskErr
    exit 1
  }

  Write-Host "Current language=$lang"
  return $lang
}

Function Get-Repo-Root {
  [string] $currentDir = Get-Location
  # -1 to strip off the trialing directory separator
  return $currentDir.Substring(0, $currentDir.LastIndexOf("sdk") - 1)
}

Function New-Assets-Json-File {
  param(
    [Parameter(Mandatory = $true)]
    [string] $Language
  )
  $AssetsRepoPrefixPath = $Language

  [string] $currentDir = Get-Location

  $sdkDir = "$([IO.Path]::DirectorySeparatorChar)sdk$([IO.Path]::DirectorySeparatorChar)"

  # if we're not in a <reporoot>/sdk/<ServiceDirectory> or deeper then this script isn't
  # being run in the right place
  if (-not $currentDir.contains($sdkDir)) {
    Write-Error "This script needs to be run at an sdk/<ServiceDirectory> or deeper."
    exit 1
  }

  $TagPrefix = $currentDir.Substring($currentDir.LastIndexOf("sdk") + 4)
  $TagPrefix = $TagPrefix.Replace("\", "/")
  $TagPrefix = "$($AssetsRepoPrefixPath)/$($TagPrefix)"
  [Assets]$Assets = [Assets]::new($AssetsRepoPrefixPath, $TagPrefix)

  $AssetsJson = $Assets | ConvertTo-Json

  $AssetsFileName = Join-Path -Path $currentDir -ChildPath "assets.json"
  Write-Host "Writing file $AssetsFileName with the following contents"
  Write-Host $AssetsJson
  $Assets | ConvertTo-Json | Out-File $AssetsFileName

  return $AssetsFileName
}

# Invoke the proxy command and echo the output.
Function Invoke-ProxyCommand {
  param(
    [string] $TestProxyExe,
    [string] $CommandArgs,
    [string] $TargetDirectory
  )
  $updatedDirectory = $TargetDirectory.Replace("`\", "/")

  if ($TestProxyExe -eq "docker" -or $TestProxyExe -eq "podman"){
    $token = $env:GIT_TOKEN
    $committer = $env:GIT_COMMIT_OWNER
    $email = $env:GIT_COMMIT_EMAIL

    if (-not $committer) {
      $committer = & git config --global user.name
    }

    if (-not $email) {
      $email = & git config --global user.email
    }

    if(-not $token -or -not $committer -or -not $email){
      Write-Error ("When running this transition script in `"docker`" or `"podman`" mode, " `
        + "the environment variables GIT_TOKEN, GIT_COMMIT_OWNER, and GIT_COMMIT_EMAIL must be set to reflect the appropriate user. ")
        exit 1
    }

    $targetImage = if ($env:TRANSITION_SCRIPT_DOCKER_TAG) { $env:TRANSITION_SCRIPT_DOCKER_TAG } else { "azsdkengsys.azurecr.io/engsys/test-proxy:latest" }

    $CommandArgs = @(
      "run --rm --name transition.test.proxy",
      "-v `"${updatedDirectory}:/srv/testproxy`"",
      "-e `"GIT_TOKEN=${token}`"",
      "-e `"GIT_COMMIT_OWNER=${committer}`"",
      "-e `"GIT_COMMIT_EMAIL=${email}`"",
      $targetImage,
      "test-proxy",
      $CommandArgs
    ) -join " "
  }

  Write-Host "$TestProxyExe $CommandArgs"
  [array] $output = & "$TestProxyExe" $CommandArgs.Split(" ") --storage-location="$updatedDirectory"
  # echo the command output
  foreach ($line in $output) {
    Write-Host "$line"
  }
}

# Get the shorthash directory under PROXY_ASSETS_FOLDER
Function Get-AssetsRoot {
  param(
    [string] $AssetsJsonFile
  )
  $repoRoot = Get-Repo-Root
  $relPath = [IO.Path]::GetRelativePath($repoRoot, $AssetsJsonFile).Replace("`\", "/")
  $assetsJsonDirectory = Split-Path $relPath
  $breadcrumbFile = Join-Path $repoRoot ".assets" ".breadcrumb"

  $breadcrumbString = Get-Content $breadcrumbFile | Where-Object { $_.StartsWith($relPath) }
  $assetRepo = $breadcrumbString.Split(";")[1]
  $assetsPrefix = (Get-Content $AssetsJsonFile | Out-String | ConvertFrom-Json).AssetsRepoPrefixPath

  return Join-Path $repoRoot ".assets" $assetRepo $assetsPrefix $assetsJsonDirectory
}

Function Move-AssetsFromLangRepo {
  param(
    [string] $AssetsRoot
  )
  $filter = $LangRecordingDirs[$language]
  Write-Host "Language recording directory name=$filter"
  Write-Host "Get-ChildItem -Recurse -Filter ""*.json"" | Where-Object { if ($filter.Contains(""*"")) { $_.DirectoryName -match $filter } else { $_.DirectoryName.Split([IO.Path]::DirectorySeparatorChar) -contains ""$filter"" }"
  $filesToMove = Get-ChildItem -Recurse -Filter "*.json" | Where-Object { if ($filter.Contains("*")) { $_.DirectoryName -match $filter } else { $_.DirectoryName.Split([IO.Path]::DirectorySeparatorChar) -contains "$filter" } }
  [string] $currentDir = Get-Location

  foreach ($fromFile in $filesToMove) {
    $relPath = [IO.Path]::GetRelativePath($currentDir, $fromFile)

    $toFile = Join-Path -Path $AssetsRoot -ChildPath $relPath
    # Write-Host "Moving from=$fromFile"
    # Write-Host "          to=$toFile"
    $toPath = Split-Path -Path $toFile

    Write-Host $toFile
    if (!(Test-Path $toPath)) {
      New-Item -Path $toPath -ItemType Directory -Force | Out-Null
    }
    Move-Item -LiteralPath $fromFile -Destination $toFile -Force
  }
}

Test-Exe-In-Path -ExeToLookFor $GitExe
$language = Get-Repo-Language

# If the initial push is being performed, ensure that test-proxy is
# in the path and that we're able to map the language's recording
# directories
if ($InitialPush) {
  $proxyPresent = Test-Exe-In-Path -ExeToLookFor $TestProxyExe -ExitOnError $false

  # try to fall back 
  if (-not $proxyPresent) {
    $StandaloneProxyExe = "Azure.Sdk.Tools.TestProxy"

    if ($IsWindows) {
      $StandaloneProxyExe += ".exe"
    }

    $standalonePresent = Test-Exe-In-Path -ExeToLookFor $StandaloneProxyExe -ExitOnError $false

    if ($standalonePresent) {
      Write-Host "Default proxy exe $TestProxyExe is not present, but standalone tool $StandaloneProxyExe is. Updating proxy exe to use the standalone version."
      $TestProxyExe = $StandaloneProxyExe
    }
    else {
      Write-Error "The user has selected option InitialPush to push their assets, neither $TestProxyExe nor $StandaloneProxyExe are installed on this machine."
      exit 1
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
    Invoke-ProxyCommand -TestProxyExe $TestProxyExe -CommandArgs $CommandArgs -TargetDirectory $repoRoot

    $assetsRoot = (Get-AssetsRoot -AssetsJsonFile $assetsJsonFile)
    Write-Host "assetsRoot=$assetsRoot"

    Move-AssetsFromLangRepo -AssetsRoot $assetsRoot

    $CommandArgs = "push --assets-json-path $assetsJsonRelPath"
    Invoke-ProxyCommand -TestProxyExe $TestProxyExe -CommandArgs $CommandArgs -TargetDirectory $repoRoot

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
