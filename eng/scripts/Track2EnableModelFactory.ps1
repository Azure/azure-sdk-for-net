function Update-AutorestMd([string]$file) {
    $fileContent = Get-Content $file
    $store = @()
    foreach ($item in $fileContent) {
        if ($item.Contains("skip-csproj: true")) {
            $store += "generate-modelfactory: true"
        }
        $store += $item
    }
    $store | Out-File -FilePath $file
}

function Update-ChangeLog([string]$file) {
    $flag = $true
    $fileContent = Get-Content $file
    $store = @()
    foreach ($item in $fileContent) {
        if ($item.Contains("### Breaking Changes") -and $flag) {
            $store += "- Add model factory"
            $flag = $false
        }
        $store += $item
    }
    $store | Out-File -FilePath $file
}

function  Enable-ModelFactory {
    param(
        [Parameter()]
        [bool]$output = $false
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
        # foreach ($file in $files) {
        #     if ($file.Contains("Azure.ResourceManager")) {
        #         Update-AutorestMd($file)
        #         $workPath = Split-Path -Path $file -Parent
        #         Set-Location -Path $workPath
            
        #         # if ([string]::IsNullOrWhitespace($AutorestPath)) { 
        #         #     dotnet build /t:GenerateCode
        #         # }
        #         # else {
        #         #     autorest .\autorest.md --use:$AutorestPath
        #         # }
        #     }
        # }

        # Update CHANGLOG file
        $files = Get-ChildItem -Path $sdkRootPath -Recurse -Filter CHANGELOG.md | % { $_.FullName }
        foreach ($file in $files) {
            if ($file.Contains("Azure.ResourceManager")) {
                Update-ChangeLog($file)
            }
        }
    }
}

Enable-ModelFactory
