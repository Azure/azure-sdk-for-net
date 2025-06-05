. (Join-Path $PSScriptRoot automation GenerateAndBuildLib.ps1)

$packagesPath = "$PSScriptRoot/../../sdk"

$track2MgmtDirs = Get-ChildItem -Path "$packagesPath" -Directory -Recurse -Depth 1 | Where-Object { $_.Name -match "(Azure.ResourceManager.)" -and $(Test-Path("$($_.FullName)/src")) }
$newLine = [Environment]::NewLine
function Update-CIFile() {
    param(
        [string]$mgmtCiFile = ""
    )

    $shouldRemove = $false

    $content = Get-Content $mgmtCiFile -Raw

    if ($content -match "(?s)ServiceDirectory:\s*(?<sd>[^$newLine]+).*-\s*name:\s*(?<p>[^$newLine]+)")
    {
        $serviceDirectory = $matches["sd"]
        $packageName = $matches["p"]
    }
    else {
        Write-Error "Could not parse out the service directory and package from $mgmtCiFile, so skipping."
        return
    }

    $relServiceDir = "sdk/$serviceDirectory"
    $relPackageDir = "$relServiceDir/$packageName/"
    $prtriggers = @"
pr:
  branches:
    include:
    - main
    - feature/*
    - hotfix/*
    - release/*
  paths:
    include:
    - $relServiceDir/ci.mgmt.yml
    - $relPackageDir
"@

    $content = $content -replace "(?s)pr:[^$newLine]*($newLine([ ]+[^$newLine]*|))*", "$prtriggers$newLine$newLine"
    $content = $content -replace "(?s)trigger:[^$newLine]*($newLine([ ]+[^$newLine]*|))*", "trigger: none$newLine"

    if ($content -notmatch "LimitForPullRequest: true")
    {
        $content = $content -replace "(.*)Artifacts:", "`$1LimitForPullRequest: true$newLine`$1Artifacts:"
    }

    Set-Content -Path $mgmtCiFile $content -NoNewline


    $ciFile = $mgmtCiFile.Replace("ci.mgmt", "ci")

    if (Test-Path $ciFile)
    {
        $ciContent = Get-Content $ciFile -Raw

        $ciContent = $ciContent -replace "(?s)(paths:$newLine(\s+)include:$newLine(?:\s+-[^$newLine]*$newLine)*(?:\s+-\s+$relServiceDir/?$newLine)(?:\s+-[^$newLine]*$newLine)*)(?!\s+exclude:)", "`$1`$2exclude:$newLine`$2- $relPackageDir$newLine"

        Set-Content -Path $ciFile $ciContent -NoNewline
    }
}

#update all Azure.ResourceManager libraries to use the new pattern for ci
Write-Host "Update mgmt sub clients ci.mgmt.yml"
foreach($mgmtDir in $track2MgmtDirs) {
    $curDirectory = $mgmtDir.FullName
    $mgmtCiFile = "$curDirectory/../ci.mgmt.yml"
    $ciFile = "$curDirectory/../ci.yml"
    $serviceDirectory = "$mgmtDir/.."

    if(Test-Path $mgmtCiFile) {
        Update-CIFile -mgmtCiFile $mgmtCiFile
    }
    else {
        #may have added ci.yml instead
        if(Test-Path $ciFile) {
            Copy-Item $ciFile $mgmtCiFile
            Update-CIFile -mgmtCiFile $mgmtCiFile
        }
    }

    if(Test-Path $ciFile) {
        #check for orphaned ci.yml files
        #if this service directory only has mgmt plane ci.yml should not be there
        $mgmtDirCount = (Get-ChildItem -Path "$serviceDirectory" -Directory | Where-Object { $_.Name -match "(Azure.ResourceManager.)" }).Length
        $totalDirCount = (Get-ChildItem -Path "$serviceDirectory" -Directory).Length

        if($mgmtDirCount -eq $totalDirCount) {
            Write-Host "Removing $ciFile"
            Remove-Item $ciFile
        }
    }
}

Write-Host "Updating mgmt core client ci.mgmt.yml"
#add path for each mgmt library into Azure.ResourceManager
RegisterMgmtSDKToMgmtCoreClient -packagesPath $packagesPath

