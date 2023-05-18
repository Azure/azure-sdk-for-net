function Update-AutorestMd([string]$file) {
    $fileContent = Get-Content $file
    $store = @()
    foreach ($item in $fileContent) {
        if ($item.Contains("generate-model-factory:")) {
            $store += "generate-model-factory: true"
            continue
        }
        $store += $item
    }
    $store | Out-File -FilePath $file
}

function Update-ChangeLog([string]$file, [string]$releasedate) {
    $flag = $false
    $fileContent = Get-Content $file
    $store = @()
    foreach ($item in $fileContent) {
        if ($item.Contains("(Unreleased)")) {
            $store += $item.Replace("Unreleased", $releasedate)
            $flag = $true
            continue
        }
        if ($item.Contains("### Features Added") -and $flag) {
            $store += $item
            $store += "`n- Add model factory`n"
            continue
        }
        if ($item.Contains("### Breaking Changes") -and $flag) {
            continue
        }
        if ($item.Equals("")-and $flag) {
            continue
        }
        if ($item.Contains("### Bugs Fixed") -and $flag) {
            continue
        }
        if ($item.Contains("### Other Changes") -and $flag) {
            $store += $item
            $store += "`n- Upgraded dependent `Azure.Core` to `1.32.0`."
            $store += "- Upgraded dependent `Azure.ResourceManager` to `1.6.0`."
            $flag = $false
            continue
        }
        $store += $item
    }
    $store | Out-File -FilePath $file
}

function  Enable-ModelFactory {
    param(
        [Parameter()]
        [string]$releasedate = "2023-06-01"
    )
    process {
        try {
            $sdkRootPath = Resolve-Path "$PSScriptRoot/../../sdk/$ServiceDirectory"
        }
        catch {
            Write-Error -Message "Invalid '$ServiceDirectory' service."
        }
    
        # Add model factory config & re-generate
        $files = Get-ChildItem -Path $sdkRootPath -Recurse -Filter autorest.md | % { $_.FullName }
        foreach ($file in $files) {
            if ($file.Contains("Azure.ResourceManager")) {
                Update-AutorestMd($file)
                $workPath = Split-Path -Path $file -Parent
                Set-Location -Path $workPath
            
                & dotnet build /t:GenerateCode

                # If generate succeeds then update the changelog file
                if ($?) {
                    $changelogFile = $file.Replace("src\autorest.md", "CHANGELOG.md")
                    Update-ChangeLog -file $changelogFile -releasedate $releasedate
                }
            }
        }

        # update all api files
        $ExportAPIPath = Resolve-Path "$PSScriptRoot/Export-API.ps1"
        & $ExportAPIPath
    }
}

Enable-ModelFactory -releasedate "2023-05-19"
