$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

# These are specs that are not yet building correctly with the management generator
# Add specs here as needed when they fail to build
$failingSpecs = @(
    # method-subscription-id: Skipped due to "Some file paths are too long" error in CI
    "http/azure/resource-manager/method-subscription-id"
)

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

function IsValidSpecDir {
    param (
        [string]$fullPath
    )
    if (-not(Test-Path "$fullPath/main.tsp")){
        return $false;
    }

    $subPath = Get-SubPath $fullPath

    if ($failingSpecs.Contains($subPath)) {
        Write-Host "Skipping $subPath" -ForegroundColor Yellow
        return $false
    }

    return $true
}

function Get-Azure-Specs-Directory {
    $packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
    return Join-Path $packageRoot 'node_modules' '@azure-tools' 'azure-http-specs'
}

function Get-Sorted-Specs {
    $azureSpecsDirectory = Get-Azure-Specs-Directory

    # Only get azure resource-manager specs
    $resourceManagerPath = Join-Path $azureSpecsDirectory "specs" "azure" "resource-manager"
    $directories = @(Get-ChildItem -Path $resourceManagerPath -Directory -Recurse)

    $sep = [System.IO.Path]::DirectorySeparatorChar
    $pattern = "${sep}specs${sep}"

    return $directories | Where-Object { IsValidSpecDir $_.FullName } | ForEach-Object {

        # Pick client.tsp if it exists, otherwise main.tsp
        $specFile = Join-Path $_.FullName "client.tsp"
        if (-not (Test-Path $specFile)) {
            $specFile = Join-Path $_.FullName "main.tsp"
        }

        # Extract the relative path after "specs/" and normalize slashes
        $relativePath = ($specFile -replace '[\\\/]', '/').Substring($_.FullName.IndexOf($pattern) + $pattern.Length)

        # Remove the filename to get just the directory path
        $dirPath = $relativePath -replace '/[^/]+\.tsp$', ''

        # Produce an object with the path for sorting
        [PSCustomObject]@{
            SpecFile = $specFile
            DirPath = $dirPath
        }
    } | Sort-Object -Property @{Expression = { $_.DirPath -replace '/', '!' }; Ascending = $true} | ForEach-Object { $_.SpecFile }
}

function Get-SubPath {
    param (
        [string]$fullPath
    )
    $azureSpecsDirectory = Get-Azure-Specs-Directory

    $subPath = $fullPath.Substring($azureSpecsDirectory.Length + 1)

    # Keep consistent with the previous folder name because 'http' makes more sense then current 'specs'
    $subPath = $subPath -replace '^specs', 'http'

    # also strip off the spec file name if present
    $leaf = Split-Path -Leaf $subPath
    if ($leaf -like '*.tsp') {
        return (Split-Path $subPath)
    }

    return $subPath
}

Export-ModuleMember -Function "Get-Namespace"
Export-ModuleMember -Function "Get-Sorted-Specs"
Export-ModuleMember -Function "Get-SubPath"
