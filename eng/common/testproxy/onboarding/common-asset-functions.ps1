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

Function Resolve-Proxy {
    $testProxyExe = "test-proxy"
    # this script requires the presence of the test-proxy on the PATH
    $proxyToolPresent = Test-Exe-In-Path -ExeToLookFor "test-proxy" -ExitOnError $false
    $proxyStandalonePresent = Test-Exe-In-Path -ExeToLookFor "Azure.Sdk.Tools.TestProxy" -ExitOnError $false

    if (-not $proxyToolPresent -and -not $proxyStandalonePresent) {
        Write-Error "This script requires the presence of a test-proxy executable to complete its operations. Exiting."
        exit 1
    }

    if (-not $proxyToolPresent) {
        $testProxyExe = "Azure.Sdk.Tools.TestProxy"
    }

    return $testProxyExe
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

Function Get-Repo-Root($StartDir=$null) {
  [string] $currentDir = Get-Location

  if ($StartDir){
    $currentDir = $StartDir
  }

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
    [string] $CommandString,
    [string] $TargetDirectory
  )
  $updatedDirectory = $TargetDirectory.Replace("`\", "/")

  # CommandString just a string indicating the proxy arguments. In the default case of running against the proxy tool, can just be used directly.
  # However, in the case of docker, we need to append a bunch more arguments to the string.
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

    $CommandString = @(
      "run --rm --name transition.test.proxy",
      "-v `"${updatedDirectory}:/srv/testproxy`"",
      "-e `"GIT_TOKEN=${token}`"",
      "-e `"GIT_COMMIT_OWNER=${committer}`"",
      "-e `"GIT_COMMIT_EMAIL=${email}`"",
      $targetImage,
      "test-proxy",
      $CommandString
    ) -join " "
  }

  Write-Host "$TestProxyExe $CommandString"
  [array] $output = & "$TestProxyExe" $CommandString.Split(" ") --storage-location="$updatedDirectory"
  # echo the command output
  foreach ($line in $output) {
    Write-Host "$line"
  }
}

# Get the shorthash directory under PROXY_ASSETS_FOLDER
Function Get-AssetsRoot {
  param(
    [string] $AssetsJsonFile,
    [string] $TestProxyExe
  )
  $repoRoot = Get-Repo-Root
  $relPath = [IO.Path]::GetRelativePath($repoRoot, $AssetsJsonFile).Replace("`\", "/")
  $assetsJsonDirectory = Split-Path $relPath

  [array] $output = & "$TestProxyExe" config locate -a "$relPath" --storage-location="$repoRoot"
  $assetsDirectory = $output[-1]

  return Join-Path $assetsDirectory $assetsJsonDirectory
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