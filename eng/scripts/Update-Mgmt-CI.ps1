$packagesPath = "$PSScriptRoot/../../sdk"

$track2MgmtDirs = Get-ChildItem -Path "$packagesPath" -Directory -Recurse -Depth 1 | Where-Object { $_.Name -match "(Azure.ResourceManager.)" -and $(Test-Path("$($_.FullName)/src")) }

function Update-CIFile() {
    param(
        [string]$mgmtCiFile = ""
    )

    $shouldRemove = $false

    $content = Get-Content $mgmtCiFile -Raw

    if ($content -match "(?s)ServiceDirectory: (?<sd>[^\r\n]+).*- name: (?<p>[^\r\n]+)")
    {
        $serviceDirectory = $matches["sd"]
        $packageName = $matches["p"]
    }
    else {
        Write-Error "Could not parse out the service directory and package from $mgmtCiFile, so skipping."
        return
    }

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
    - sdk/$serviceDirectory/$packageName

"@

    $content = $content -replace "(?s)pr:[^\n]*(\n([ ]+[^\n]*|))*", $prtriggers
    $content = $content -replace "trigger:[^\n]*(\n([ ]+[^\n]*|))*", "trigger: none"

    Set-Content -Path $mgmtCiFile $content -NoNewline
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
