$packagesPath = "$PSScriptRoot/../../sdk"

$track2MgmtDirs = Get-ChildItem -Path "$packagesPath" -Directory -Recurse -Depth 1 | Where-Object { $_.Name -match "(Azure.ResourceManager.)" -and $(Test-Path("$($_.FullName)/src")) }

function Update-CIFile() {
    param(
        [string]$mgmtCiFile = ""
    )

    $shouldRemove = $false

    $content = Get-Content $mgmtCiFile -Raw

    if ($content -match "(?s)ServiceDirectory:\s*(?<sd>[^\r\n]+).*-\s*name:\s*(?<p>[^\r\n]+)")
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

    $content = $content -replace "(?s)pr:[^\r\n]*(\r\n([ ]+[^\r\n]*|))*", "$prtriggers`r`n`r`n"
    $content = $content -replace "(?s)trigger:[^\r\n]*(\r\n([ ]+[^\r\n]*|))*", "trigger: none`r`n"

    if ($content -notmatch "LimitForPullRequest: true")
    {
        $content = $content -replace "(.*)Artifacts:", "`$1LimitForPullRequest: true`r`n`$1Artifacts:"
    }

    Set-Content -Path $mgmtCiFile $content -NoNewline


    $ciFile = $mgmtCiFile.Replace("ci.mgmt", "ci")

    if (Test-Path $ciFile)
    {
        $ciContent = Get-Content $ciFile -Raw

        $ciContent = $ciContent -replace "(?s)(paths:\r\n(\s+)include:\r\n(?:\s+-[^\r\n]*\r\n)*(?:\s+-\s+$relServiceDir/?\r\n)(?:\s+-[^\r\n]*\r\n)*)(?!\s+exclude:)", "`$1`$2exclude:`r`n`$2- $relPackageDir`r`n"

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
        $mgmtDirCount = (Get-ChildItem -Path "$serviceDirectory" -Directory | Where-Object { $_.Name -match "(Azure.ResourceManager.|Microsoft.Azure.Management.)" }).Length
        $totalDirCount = (Get-ChildItem -Path "$serviceDirectory" -Directory).Length

        if($mgmtDirCount -eq $totalDirCount) {
            Write-Host "Removing $ciFile"
            Remove-Item $ciFile
        }
    }
}

Write-Host "Updating mgmt core client ci.mgmt.yml"
#add path for each mgmt library into Azure.ResourceManager
$armCiFile = "$packagesPath/resourcemanager/ci.mgmt.yml"
$armLines = Get-Content $armCiFile
$newLines = [System.Collections.ArrayList]::new()
$startIndex = $track2MgmtDirs[0].FullName.IndexOf(("\sdk\")) + 1
$shouldRemove = $false
foreach($line in $armLines) {
    if($line.StartsWith("  paths:")) {
        $newLines.Add($line) | Out-Null
        $newLines.Add("    include:") | Out-Null
        $newLines.Add("    - sdk/resourcemanager") | Out-Null
        $newLines.Add("    - common/ManagementTestShared") | Out-Null
        $newLines.Add("    - common/ManagementCoreShared") | Out-Null
        foreach($dir in $track2MgmtDirs) {
            $newLine = "    - $($dir.FullName.Substring($startIndex, $dir.FullName.Length - $startIndex).Replace('\', '/'))"
            $newLines.Add($newLine) | Out-Null
        }
        $shouldRemove = $true
        Continue
    }

    if($shouldRemove) {
        if($line.StartsWith(" ")) {
            Continue
        }
        $shouldRemove = $false
    }

    $newLines.Add($line) | Out-Null
}
Set-Content -Path $armCiFile $newLines
