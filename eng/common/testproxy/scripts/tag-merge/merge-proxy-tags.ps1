#Requires -Version 6.0
#Requires -PSEdition Core

<#
.SYNOPSIS
Merge multiple asset tagss worth of content into a single asset tag.

.DESCRIPTION
USAGE: merge-proxy-tags.ps1 path/to/target_assets_json. TAG1 TAG2 TAG3

Attempts to merge the contents of multiple assets tags into a single new local changeset, which can be `test-proxy push`-ed.

In the case one of the targeted tags exists in the targeted assets.json, that tag will always be the start point.

1. test-proxy restore -a <assets-file> -> populate .assets
2. test-proxy config locate -a <assets-file> -> get location of cloned git repo
3. walk the incoming tags, merging their changes directly into the changeset _in context_
4. In the case of a discovered git conflict, the process ends. A list of which tags merged and which didn't will be presented to the user.
  4a. Users should resolve the git conflicts themselves.
  4b. If the conflict was on the final tag, resolve the conflict (leaving it uncommitted tyvm), and test-proxy push, you're done.
  4c. If the conflict was _not_ on the final tag, resolve the conflict, commit it, and then re-run this script with the SAME arguments as before.

This script requires that test-proxy or azure.sdk.tools.testproxy should be on the PATH.

.PARAMETER AssetsJson
The script uses a target assets.json to resolve where specifically on disk the tag merging should take place.

.PARAMETER TargetTags
The set of tags whose contents should be combined. Any number of tags > 1 is allowed.

#>
param(
  [Parameter(Position=0)]
  [string] $AssetsJson,
  [Parameter(Position=1, ValueFromRemainingArguments=$true)]
  [string[]] $TargetTags
)

. (Join-Path $PSScriptRoot ".." ".." "onboarding" "common-asset-functions.ps1")

function Git-Command-With-Result($CommandString, $WorkingDirectory) {
    Write-Host "git $CommandString"

    if ($WorkingDirectory){
        Push-Location $WorkingDirectory
    }

    $result = Invoke-Expression "git $CommandString"

    if ($WorkingDirectory) {
        Pop-Location
    }

    return [PSCustomObject]@{
        ExitCode = $lastexitcode
        Output = $result
    }
}

function Git-Command($CommandString, $WorkingDirectory, $HardExit=$true) {
    $result = Git-Command-With-Result $CommandString $WorkingDirectory

    if ($result.ExitCode -ne 0 -and $HardExit) {
        Write-Error $result.Output
        exit 1
    }

    return $result.Output
}

function Call-Proxy {
    param(
    [string] $TestProxyExe,
    [string] $CommandArgs,
    [string] $MountDirectory,
    [boolean] $Output = $true
    )

    $CommandArgs += " --storage-location=$MountDirectory"

    if ($Output -eq $true) {
        Write-Host "$TestProxyExe $CommandArgs"
    }

    [array] $output = & "$TestProxyExe" $CommandArgs.Split(" ")

    if ($lastexitcode -ne 0) {
        foreach($line in $output) {
            Write-Host $line
        }
        Write-Error "Proxy exe exited with unexpected non-zero exit code."
        exit 1
    }

    if ($Output -eq $true) {
        foreach($line in $output) {
            Write-Host $line
        }
    }

    return $output
}

function Locate-Assets-Slice($ProxyExe, $AssetsJson, $MountDirectory) {
    $CommandString = "config locate -a $AssetsJson"

    $output = Call-Proxy -TestProxyExe $ProxyExe -CommandArgs $CommandString -MountDirectory $MountDirectory -Output $false

    return $output[-1].Trim()
}

function Get-Tag-SHA($TagName, $WorkingDirectory) {
    $results = Git-Command "ls-remote origin $TagName" $WorkingDirectory
    
    if ($results -and $lastexitcode -eq 0) {
        $arr = $results -split '\s+'
        
        return $arr[0]
    }

    Write-Error "Unable to fetch tag SHA for $TagName. The tag does not exist on the repository."
    exit 1
}

function Start-Message($AssetsJson, $TargetTags, $AssetsRepoLocation, $MountDirectory) {
    $alreadyCombinedTags = Load-Incomplete-Progress $MountDirectory
    
    $TargetTags = $TargetTags | Where-Object { $_ -notin $alreadyCombinedTags }

    if ($alreadyCombinedTags) {
        Write-Host "This script has detected the presence of a .mergeprogress file within folder $MountDirectory."
        Write-Host "If the presence of a previous execution of this script is surprising, delete the .assets folder and .mergeprogress file before invoking the script again."
        Write-Host "Attempting to continue from a previous run, and excluding:"

        foreach($Tag in $alreadyCombinedTags) {
            Write-Host " - " -NoNewLine
            Write-Host "$Tag" -ForegroundColor Green
        }
        Write-Host "But continuing with:"

        foreach($Tag in $TargetTags){
            Write-Host " - " -NoNewLine
            Write-Host "$Tag" -ForegroundColor Green
        }
    }
    else {
        Write-Host "`nThis script will attempt to merge the following tag" -NoNewLine
        if ($TargetTags.Length -gt 1) {
            Write-Host "s" -NoNewLine
        }
        Write-Host ":"
        foreach($Tag in $TargetTags) {
            Write-Host " - " -NoNewLine
            Write-Host "$Tag" -ForegroundColor Green
        }
        Write-Host "`nTargeting the assets slice targeted by " -NoNewLine
        Write-Host "$AssetsJson." -ForegroundColor Green
        Write-Host "`nThe work will be completed in " -NoNewLine
        Write-Host $AssetsRepoLocation -ForegroundColor Green -NoNewLine
        Write-Host "."
    }

    Read-Host -Prompt "If the above looks correct, press enter, otherwise, ctrl-c"
}

function Finish-Message($AssetsJson, $TargetTags, $AssetsRepoLocation, $MountDirectory) {
    $len = $TargetTags.Length

    if ($TargetTags.GetType().Name -eq "String") {
        $len = 1
    }

    $suffix = if ($len -gt 1) { "s" } else { "" }

    Write-Host "`nSuccessfully combined $len tag$suffix. Invoke `"test-proxy push " -NoNewLine
    Write-Host $AssetsJson -ForegroundColor Green -NoNewLine
    Write-Host "`" to push the results as a new tag."
}

function Resolve-Target-Tags($AssetsJson, $TargetTags, $MountDirectory) {
    $inprogress = Load-Incomplete-Progress $MountDirectory

    $jsonContent = Get-Content -Raw -Path $AssetsJson
    $jsonObj = $JsonContent | ConvertFrom-Json

    $existingTarget = $jsonObj.Tag

    return $TargetTags | Where-Object {
        if ($_ -eq $existingTarget) {
            Write-Host "Excluding tag $($_) from tag input list, it is present in assets.json."
        }
        $_ -ne $existingTarget
    } | Where-Object {
        if ($_ -in $inprogress) {
            Write-Host "Excluding tag $($_) because we have already done work against it in a previous script invocation."
        }
        $_ -notin $inprogress
    }
}

function Save-Incomplete-Progress($Tag, $MountDirectory) {
    $progressFile = (Join-Path $MountDirectory ".mergeprogress")
    [array] $existingTags = @()
    if (Test-Path $progressFile) {
        $existingTags = (Get-Content -Path $progressFile) -split "`n" | ForEach-Object { $_.Trim() }
    }

    $existingTags = $existingTags + $Tag | Select-Object -Unique

    Set-Content -Path $progressFile -Value ($existingTags -join "`n") | Out-Null

    return $existingTags
}

function Load-Incomplete-Progress($MountDirectory) {
    $progressFile = (Join-Path $MountDirectory ".mergeprogress")
    [array] $existingTags = @()
    if (Test-Path $progressFile) {
        $existingTags = ((Get-Content -Path $progressFile) -split "`n" | ForEach-Object { $_.Trim() })
    }

    return $existingTags
}

function Cleanup-Incomplete-Progress($MountDirectory) {
    $progressFile = (Join-Path $MountDirectory ".mergeprogress")

    if (Test-Path $progressFile) {
        Remove-Item $progressFile | Out-Null
    }
}

function Prepare-Assets($ProxyExe, $MountDirectory, $AssetsJson) {
    $inprogress = Load-Incomplete-Progress $MountDirectory

    if ($inprogress.Length -eq 0) {
        Call-Proxy -TestProxyExe $ProxyExe -CommandArgs "reset -y -a $AssetsJson" -MountDirectory $MountDirectory -Output $false
    }
}

function Combine-Tags($RemainingTags, $AssetsRepoLocation, $MountDirectory, $RelativeAssetsJson){
    $remainingTagString = $RemainingTags -join " "
    foreach($Tag in $RemainingTags) {
        $tagSha = Get-Tag-SHA $Tag $AssetsRepoLocation
        $existingTags = Save-Incomplete-Progress $Tag $MountDirectory
        $cherryPickResult = Git-Command-With-Result "merge $tagSha" - $AssetsRepoLocation -HardExit $false

        if ($cherryPickResult.ExitCode -ne 0) {
            $error = "Conflicts while merging $Tag. Resolve the the conflict over in `"$AssetsRepoLocation`", and re-invoke " +
            "by `"./eng/common/testproxy/scripts/tag-merge/merge-proxy-tags.ps1 $RelativeAssetsJson $remainingTagString`""
            Write-Host $error -ForegroundColor Red
            exit 1
        }
    }

    $pushedTags = Load-Incomplete-Progress $MountDirectory

    $testFile = Get-ChildItem -Recurse -Path $AssetsRepoLocation | Where-Object { !$_.PSIsContainer } | Select-Object -First 1
    Add-Content -Path $testFile -Value "`n"

    # if we have successfully gotten to the end without any non-zero exit codes...delete the mergeprogress file, we're g2g
    Cleanup-Incomplete-Progress $MountDirectory

    return @($pushedTags)
}

$ErrorActionPreference = "Stop"

# this script requires the presence of git
Test-Exe-In-Path -ExeToLookFor "git" | Out-Null

# this script expects at least powershell 6 (core)

if ($PSVersionTable["PSVersion"].Major -lt 6) {
    Write-Error "This script requires a version of powershell newer than 6. See http://aka.ms/powershell for resolution."
    exit 1
}

# resolve the proxy location so that we can invoke it easily, if not present we exit here.
$proxyExe = Resolve-Proxy

$relativeAssetsJson = $AssetsJson
$AssetsJson = Resolve-Path $AssetsJson

# figure out where the root of the repo for the passed assets.json is. We need it to properly set the mounting
# directory so that the test-proxy restore operations work IN PLACE with existing tooling
$mountDirectory = Get-Repo-Root -StartDir $AssetsJson

# ensure we actually have the .assets folder that we can merge commits onto
Prepare-Assets $proxyExe $mountDirectory $AssetsJson

# using the mountingDirectory and the assets.json location, we can figure out where the assets slice actually lives within the .assets folder.
# we will use this to invoke individual SHA merges before pushing up the result
$assetsRepoLocation = Locate-Assets-Slice $proxyExe $AssetsJson $mountDirectory

# resolve the tags that we will go after. If the target assets.json contains one of these tags, that tag is _already present_
# because the entire point of this script is to run in context of a set of recordings in the repo
$tags = Resolve-Target-Tags $AssetsJson $TargetTags $mountDirectory

Start-Message $AssetsJson $Tags $AssetsRepoLocation $mountDirectory

$CombinedTags = Combine-Tags $Tags $AssetsRepoLocation $mountDirectory $relativeAssetsJson

Finish-Message $AssetsJson $CombinedTags $AssetsRepoLocation $mountDirectory
