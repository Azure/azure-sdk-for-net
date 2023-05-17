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
    $flag = $true
    $fileContent = Get-Content $file
    $store = @()
    foreach ($item in $fileContent) {
        if ($item.Contains("(Unreleased)") -and $flag) {
            $store += $item.Replace("Unreleased", $releasedate)
            continue
        }
        if ($item.Contains("### Breaking Changes") -and $flag) {
            $store += "- Add model factory`n"
        }
        if ($item.Contains("### Other Changes") -and $flag) {
            $store += "- Upgraded dependent `Azure.Core` to `1.32.0`."
            $store += "- Upgraded dependent `Azure.ResourceManager` to `1.6.0`.`n"
            $flag = $false
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
                $changelogFile = $file.Replace("src\autorest.md", "CHANGELOG.md")
                if ($?) {
                    Update-ChangeLog -file $changelogFile -releasedate $releasedate
                }
            }
        }
    }
}

Enable-ModelFactory -releasedate "2023-05-17"
