$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

function IsGenerated {
    param (
        [string]$dir
    )

    if (-not ($dir.EndsWith("Generated"))) {
        return $false
    }

    $csFiles = Get-ChildItem -Path $dir -Filter *.cs -File
    return $csFiles.Count -gt 0
}

function Capitalize-FirstLetter {
    param (
        [string]$inputString
    )

    if ([string]::IsNullOrEmpty($inputString)) {
        return $inputString
    }

    $firstChar = $inputString[0].ToString().ToUpper()
    $restOfString = $inputString.Substring(1)

    return $firstChar + $restOfString
}

function Get-Namespace {
    param (
        [string]$dir
    )

    $words = $dir.Split('-')
    $namespace = ""
    foreach ($word in $words) {
        $namespace += Capitalize-FirstLetter $word
    }
    return $namespace
}

Export-ModuleMember -Function "IsGenerated"
Export-ModuleMember -Function "Get-Namespace"
