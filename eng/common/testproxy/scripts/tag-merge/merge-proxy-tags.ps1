<#
.SYNOPSIS
Merge multiple asset tagss worth of content into a single asset tag.

.DESCRIPTION
USAGE: merge-proxy-tags.ps1 path/to/target_assets_json. TAG1 TAG2 TAG3

Attempts to merge the contents of multiple assets tags into a single new local changeset, which can be `test-proxy push`-ed.

In the case one of the targeted tags exists in the targeted assets.json, that tag will always be the start point.

1. test-proxy restore -a <assets-file> -> populate .assets
2. test-proxy config locate -a <assets-file> -> get location of cloned git repo
3. walk the incoming tags, cherry-picking their changes directly into the changeset _in context_
4. In the case of a discovered git conflict, the process ends. A list of which tags merged and which didn't will be presented to the user.
  4a. Users should resolve the git conflicts themselves.
  4b. If the conflict was on the final tag, resolve the conflict (leaving it uncommitted tyvm), and test-proxy push, you're done.
  4c. If the conflict was _not_ on the final tag, resolve the conflict, commit it, and then re-run this script with the SAME arguments as before.

This script requires that test-proxy or azure.sdk.tools.testproxy should be on the PATH.

.PARAMETER AssetsJson
The script uses a target assets.json to resolve where specifically on disk the tag merging should take place.

.PARAMETER TargetTags
The set of tags whos contents should be merged into the targeted 

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

    if ($WorkingDirectory){
        Pop-Location
    }

    return [PSCustomObject]@{
        ExitCode = $lastexitcode,
        Output = $result
    }
}

function Git-Command($CommandString, $WorkingDirectory, $HardExit=$true) {
    $result = Git-Command-With-Result $CommandString $WorkingDirectory

    if ($lastexitcode -ne 0 -and $HardExit) {
        Write-Error $result
        exit 1
    }

    return $result.Output
}

function Resolve-Proxy {
    # this script requires the presence of git
    Test-Exe-In-Path -ExeToLookFor "git" | Out-Null

    $testProxyExe = "test-proxy"
    # this script requires the presence of the test-proxy on the PATH
    $proxyToolPresent = Test-Exe-In-Path -ExeToLookFor "test-proxy" -ExitOnError $false
    $proxyStandalonePresent = Test-Exe-In-Path -ExeToLookFor "Azure.Sdk.Tools.TestProxy" -ExitOnError $false

    if (-not $proxyToolPresent -and -not $proxyStandalonePresent){
        Write-Error "This script requires the presence of a test-proxy executable to complete its operations. Exiting."
        exit 1
    }

    if (-not $proxyToolPresent) {
        $testProxyExe = "Azure.Sdk.Tools.TestProxy"
    }

    return $testProxyExe
}

function Call-Proxy {
    param(
    [string] $TestProxyExe,
    [string] $CommandArgs,
    [string] $MountDirectory,
    [boolean] $Output = $true
    )

    $CommandArgs += " --storage-location=$MountDirectory"

    if ($Output -eq $true){
        Write-Host "$TestProxyExe $CommandArgs"
    }

    [array] $output = & "$TestProxyExe" $CommandArgs.Split(" ")

    if ($lastexitcode -ne 0){
        foreach($line in $output) {
            Write-Host $line
        }
        Write-Error "Proxy exe exited with unexpected non-zero exit code."
        exit 1
    }

    if ($Output -eq $true){
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

    if ($alreadyCombinedTags) {
        Write-Host "This script has detected the presence of a .mergeprogress file with folder $MountDirectory."
        Write-Host "Attempting to continue from a previous run, and excluding: "
        foreach($Tag in $alreadyCombinedTags){
            Write-Host " - " -nonewline
            Write-Host "$Tag" -ForegroundColor Green
        }
    }

    $TargetTags = $TargetTags | Where-Object { $_ -notin $alreadyCombinedTags }

    Write-Host "`nThis script will attempt to merge the following tag" -nonewline
    if ($TargetTags.Length -gt 1){
        Write-Host "s" -nonewline
    }
    Write-Host ":"
    foreach($Tag in $TargetTags){
        Write-Host " - " -nonewline
        Write-Host "$Tag" -ForegroundColor Green
    }
    Write-Host "`nTargeting the assets slice targeted by " -nonewline
    Write-Host "$AssetsJson." -ForegroundColor Green
    Write-Host "`nThe work will be completed in " -nonewline
    Write-Host $AssetsRepoLocation -ForegroundColor Green -nonewline
    Write-Host "."

    Read-Host -Prompt "If the above looks correct, press enter, otherwise, ctrl-c"
}

function Finish-Message($AssetsJson, $TargetTags, $AssetsRepoLocation, $MountDirectory) {
    $len = $TargetTags.Length

    Write-Host "`nSuccessfully combined $len tags. Invoke `"test-proxy push " -nonewline
    Write-Host $AssetsJson -ForegroundColor Green -nonewline
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
        $existingTags = (Get-Content -Path $progressFile) -split "`n" | ForEach-Object { $_.Trim() }
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

function Combine-Tags($RemainingTags, $AssetsRepoLocation, $MountDirectory){
    foreach($Tag in $RemainingTags){
        $tagSha = Get-Tag-SHA $Tag $AssetsRepoLocation
        Save-Incomplete-Progress $Tag $MountDirectory
        $cherryPickResult = Git-Command-With-Result "cherry-pick $tagSha" - $AssetsRepoLocation -HardExit $false

        if ($cherryPickResult.ExitCode -ne 0) {
            Write-Error $cherryPickResult.Output
            # not last tag
            if ($Tag -ne $RemainingTags[-1]) {
                Write-Error "Conflicts while cherry-picking $Tag. Resolve the the conflict over in `"$AssetsRepoLocation`", commit the result, and re-run this script with the same arguments as before."
                exit 1
            }
            # last tag
            elseif ($Tag -eq $RemainingTags[-1]) {
                Write-Error "Conflicts while cherry-picking $Tag. Resolve the conflict over in `"$AssetsRepoLocation`", leave the result uncommitted, ``test-proxy push`` the assets.json you ran this script against!"
                exit 1
            }
        }
    }

    $testFile = Get-ChildItem -Recurse -Path $AssetsRepoLocation | Where-Object { !$_.PSIsContainer } | Select-Object -First 1
    Add-Content -Path $testFile -Value "`n"

    # if we have successfully gotten to the end without any non-zero exit codes...delete the mergeprogress file, we're g2g
    Cleanup-Incomplete-Progress $MountDirectory
}

$ErrorActionPreference = "Stop"

# resolve the proxy location so that we can invoke it easily
$proxyExe = Resolve-Proxy

$AssetsJson = Resolve-Path $AssetsJson

# figure out where the root of the repo for the passed assets.json is. We need it to properly set the mounting
# directory so that the test-proxy restore operations work IN PLACE with existing tooling
$mountDirectory = Get-Repo-Root -StartDir $AssetsJson

# ensure we actually have the .assets folder that we can cherry-pick on top of
Prepare-Assets $proxyExe $mountDirectory $AssetsJson

# using the mountingDirectory and the assets.json location, we can figure out where the assets slice actually lives within the .assets folder.
# we will use this to invoke individual cherry-picks before pushing up the result
$assetsRepoLocation = Locate-Assets-Slice $proxyExe $AssetsJson $mountDirectory

# resolve the tags that we will go after. If the target assets.json contains one of these tags, that tag is _already present_
# because the entire point of this script is to run in context of a set of recordings in the repo
$tags = Resolve-Target-Tags $AssetsJson $TargetTags $mountDirectory

Start-Message $AssetsJson $Tags $AssetsRepoLocation $mountDirectory

$CombinedTags = Combine-Tags $Tags $AssetsRepoLocation $mountDirectory

Finish-Message $AssetsJson $CombinedTags $AssetsRepoLocation $mountDirectory
