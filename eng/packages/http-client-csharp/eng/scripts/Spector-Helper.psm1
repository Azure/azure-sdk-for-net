$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

$failingSpecs = @(
    Join-Path 'http' 'streaming' 'jsonl'
    Join-Path 'http' 'payload' 'xml'
    Join-Path 'http' 'response' 'status-code-range' # Response namespace conflicts with Azure.Response
# Azure scenarios not yet buildable
    Join-Path 'http' 'azure' 'client-generator-core' 'alternate-type'
    Join-Path 'http' 'azure' 'client-generator-core' 'client-initialization'
    Join-Path 'http' 'azure' 'client-generator-core' 'deserialize-empty-string-as-null' # long path issue and also not needed for Azure emitter
# These scenarios will be covered in Azure.Generator.Management
    Join-Path 'http' 'azure' 'resource-manager' 'common-properties'
    Join-Path 'http' 'azure' 'resource-manager' 'non-resource'
    Join-Path 'http' 'azure' 'resource-manager' 'operation-templates'
    Join-Path 'http' 'azure' 'resource-manager' 'resources'
    Join-Path 'http' 'azure' 'resource-manager' 'large-header'
    Join-Path 'http' 'azure' 'resource-manager' 'method-subscription-id'
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

function Get-Specs-Directory {
    $packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
    return Join-Path $packageRoot 'node_modules' '@typespec' 'http-specs'
}

function Get-Azure-Specs-Directory {
    $packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
    return Join-Path $packageRoot 'node_modules' '@azure-tools' 'azure-http-specs'
}

function Get-Sorted-Specs {
    $specsDirectory = Get-Specs-Directory
    $azureSpecsDirectory = Get-Azure-Specs-Directory

    $directories = @(Get-ChildItem -Path "$specsDirectory/specs" -Directory -Recurse)
    $directories += @(Get-ChildItem -Path "$azureSpecsDirectory/specs" -Directory -Recurse)

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
    $specsDirectory = Get-Specs-Directory
    $azureSpecsDirectory = Get-Azure-Specs-Directory

    $fromAzure = $fullPath.Contains("azure-http-specs")
    $subPath = if ($fromAzure) {$fullPath.Substring($azureSpecsDirectory.Length + 1)} else {$fullPath.Substring($specsDirectory.Length + 1)}

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
