[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string] $PackagePath,

    [string] $OutputPath,

    [ValidateSet('Json', 'Markdown')]
    [string] $Format = 'Json'
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

function Get-RelativePath
{
    param(
        [Parameter(Mandatory)]
        [string] $BasePath,

        [Parameter(Mandatory)]
        [string] $Path
    )

    $baseUri = [System.Uri]::new((Join-Path $BasePath '.'))
    $pathUri = [System.Uri]::new($Path)
    return [System.Uri]::UnescapeDataString($baseUri.MakeRelativeUri($pathUri).ToString()).Replace('/', [System.IO.Path]::DirectorySeparatorChar)
}

function Get-PropertyInfo
{
    param([Parameter(Mandatory)][string] $Source)

    $properties = @{}
    $propertyPattern = '(?m)^\s*public\s+(?<type>[A-Za-z_][A-Za-z0-9_<>,\.\?\s]*)\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\s*\{'
    foreach ($match in [regex]::Matches($Source, $propertyPattern))
    {
        $openBrace = $Source.IndexOf('{', $match.Index)
        if ($openBrace -lt 0)
        {
            continue
        }

        $depth = 0
        $closeBrace = -1
        for ($i = $openBrace; $i -lt $Source.Length; $i++)
        {
            if ($Source[$i] -eq '{')
            {
                $depth++
            }
            elseif ($Source[$i] -eq '}')
            {
                $depth--
                if ($depth -eq 0)
                {
                    $closeBrace = $i
                    break
                }
            }
        }

        if ($closeBrace -le $openBrace)
        {
            continue
        }

        $body = $Source.Substring($openBrace + 1, $closeBrace - $openBrace - 1)
        $properties[$match.Groups['name'].Value] = [ordered]@{
            Type = ($match.Groups['type'].Value -replace '\s+', ' ').Trim()
            Settable = $body -match '(?m)^\s*(public\s+)?(set|init)\s*(\{|=>)'
        }
    }

    return $properties
}

function Get-SerializedPath
{
    param([Parameter(Mandatory)][string] $PathSource)

    $segments = [System.Collections.Generic.List[string]]::new()
    foreach ($match in [regex]::Matches($PathSource, '"(?<segment>[^"]+)"'))
    {
        $segments.Add($match.Groups['segment'].Value)
    }

    return $segments.ToArray()
}

function Get-PropertyKind
{
    param([Parameter(Mandatory)][string] $DefineMethod)

    switch ($DefineMethod)
    {
        'DefineProperty' { 'Property' }
        'DefineModelProperty' { 'ModelProperty' }
        'DefineListProperty' { 'ListProperty' }
        'DefineDictionaryProperty' { 'DictionaryProperty' }
        'DefineResource' { 'Resource' }
        default { $DefineMethod }
    }
}

function Get-DefaultValue
{
    param([AllowEmptyString()][string] $Arguments)

    $defaultValueMatch = [regex]::Match($Arguments, '\bdefaultValue\s*:\s*(?<value>"(?:[^"\\]|\\.)*"|[^,\)]+)')
    if (!$defaultValueMatch.Success)
    {
        return ''
    }

    return ($defaultValueMatch.Groups['value'].Value -replace '\s+', ' ').Trim()
}

function Get-ResourceProperties
{
    param(
        [Parameter(Mandatory)]
        [string] $Source,

        [Parameter(Mandatory)]
        [hashtable] $PropertyInfo
    )

    $properties = [System.Collections.Generic.List[object]]::new()
    $definePattern = '(?ms)^\s*_[A-Za-z0-9_]+\s*=\s*(?<method>Define(?:Model|List|Dictionary)?Property|DefineResource)<(?<generic>[^>]+)>\(\s*(?:"(?<literalName>[^"]+)"|nameof\(\s*(?<nameofName>[A-Za-z_][A-Za-z0-9_]*)\s*\))\s*,\s*(?:\[(?<bracketPath>[^\]]*)\]|new\s+string\[\]\s*\{(?<arrayPath>[^}]*)\})(?<args>.*?)\);'
    foreach ($match in [regex]::Matches($Source, $definePattern))
    {
        $name = if ($match.Groups['literalName'].Success) { $match.Groups['literalName'].Value } else { $match.Groups['nameofName'].Value }
        $method = $match.Groups['method'].Value
        $genericType = ($match.Groups['generic'].Value -replace '\s+', ' ').Trim()
        $type = if ($PropertyInfo.ContainsKey($name)) { $PropertyInfo[$name].Type } else { $genericType }
        $isSettable = $PropertyInfo.ContainsKey($name) -and $PropertyInfo[$name].Settable
        $args = $match.Groups['args'].Value
        $isMetadata = $method -eq 'DefineResource'
        $pathSource = if ($match.Groups['bracketPath'].Success) { $match.Groups['bracketPath'].Value } else { $match.Groups['arrayPath'].Value }

        $properties.Add([ordered]@{
            Name = $name
            SerializedPath = @(Get-SerializedPath -PathSource $pathSource)
            Kind = if ($isMetadata) { 'Resource' } else { Get-PropertyKind -DefineMethod $method }
            Type = $type
            IsRequired = $args -match '\bisRequired\s*:\s*true\b'
            IsSettable = $isSettable
            DefaultValue = Get-DefaultValue -Arguments $args
            IsMetadata = $isMetadata
        })
    }

    return $properties.ToArray()
}

function Get-ResourceInfo
{
    param(
        [Parameter(Mandatory)]
        [System.IO.FileInfo] $File,

        [Parameter(Mandatory)]
        [string] $PackagePath,

        [AllowEmptyCollection()]
        [System.IO.FileInfo[]] $CustomSourceFiles
    )

    $source = Get-Content -LiteralPath $File.FullName -Raw
    $classMatch = [regex]::Match($source, '(?m)^\s*public\s+partial\s+class\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\s*:\s*ProvisionableResource\b')
    if (!$classMatch.Success)
    {
        return $null
    }

    $className = $classMatch.Groups['name'].Value
    $classSources = [System.Collections.Generic.List[string]]::new()
    $classSources.Add($source)
    $sourcePaths = [System.Collections.Generic.List[string]]::new()
    $sourcePaths.Add((Get-RelativePath -BasePath $PackagePath -Path $File.FullName))
    foreach ($sourceFile in $CustomSourceFiles)
    {
        $candidateSource = Get-Content -LiteralPath $sourceFile.FullName -Raw
        if ($candidateSource -match "(?m)^\s*(?:public|internal|private)?\s*partial\s+class\s+$([regex]::Escape($className))\b")
        {
            $classSources.Add($candidateSource)
            $sourcePaths.Add((Get-RelativePath -BasePath $PackagePath -Path $sourceFile.FullName))
        }
    }

    $combinedSource = $classSources -join [Environment]::NewLine
    $constructorPattern = '(?ms)(?:public|internal)\s+' + [regex]::Escape($className) + '\s*\(\s*string\s+bicepIdentifier\s*,\s*string\??\s+resourceVersion\s*=\s*(?:default|null)\s*\)\s*:\s*base\(\s*bicepIdentifier\s*,\s*"(?<resourceType>[^"]+)"\s*,\s*resourceVersion\s*\?\?\s*"(?<defaultApiVersion>[^"]+)"\s*\)'
    $constructorMatch = [regex]::Match($source, $constructorPattern)

    $apiVersions = [System.Collections.Generic.List[string]]::new()
    foreach ($match in [regex]::Matches($source, '(?m)^\s*public\s+static\s+readonly\s+string\s+V[A-Za-z0-9_]+\s*=\s*"(?<version>[^"]+)";'))
    {
        $apiVersions.Add($match.Groups['version'].Value)
    }

    $propertyInfo = Get-PropertyInfo -Source $combinedSource

    return [ordered]@{
        ClassName = $className
        ResourceType = if ($constructorMatch.Success) { $constructorMatch.Groups['resourceType'].Value } else { '' }
        DefaultApiVersion = if ($constructorMatch.Success) { $constructorMatch.Groups['defaultApiVersion'].Value } else { '' }
        ApiVersions = $apiVersions.ToArray()
        SourcePath = Get-RelativePath -BasePath $PackagePath -Path $File.FullName
        AdditionalSourcePaths = @($sourcePaths.ToArray() | Where-Object { $_ -ne (Get-RelativePath -BasePath $PackagePath -Path $File.FullName) })
        InitializationError = ''
        Properties = @(Get-ResourceProperties -Source $combinedSource -PropertyInfo $propertyInfo)
    }
}

$resolvedPackagePath = (Resolve-Path -LiteralPath $PackagePath).Path
$generatedPath = Join-Path $resolvedPackagePath 'src/Generated'
if (!(Test-Path -LiteralPath $generatedPath))
{
    throw "Could not find generated source under $resolvedPackagePath"
}

$resources = [System.Collections.Generic.List[object]]::new()
$sourcePath = Join-Path $resolvedPackagePath 'src'
$generatedRoot = (Resolve-Path -LiteralPath $generatedPath).Path.TrimEnd([System.IO.Path]::DirectorySeparatorChar, [System.IO.Path]::AltDirectorySeparatorChar)
$generatedPrefix = $generatedRoot + [System.IO.Path]::DirectorySeparatorChar
$customSourceFiles = @(Get-ChildItem -LiteralPath $sourcePath -Filter '*.cs' -File -Recurse |
    Where-Object { !$_.FullName.StartsWith($generatedPrefix, [System.StringComparison]::OrdinalIgnoreCase) } |
    Sort-Object FullName)
foreach ($file in Get-ChildItem -LiteralPath $generatedPath -Filter '*.cs' -File -Recurse | Sort-Object FullName)
{
    $resource = Get-ResourceInfo -File $file -PackagePath $resolvedPackagePath -CustomSourceFiles $customSourceFiles
    if ($null -ne $resource)
    {
        $resources.Add($resource)
    }
}

$schema = [ordered]@{
    PackagePath = $resolvedPackagePath
    SourcePath = $generatedPath
    ResourceCount = $resources.Count
    Resources = $resources.ToArray()
}

if ($Format -eq 'Json')
{
    $output = $schema | ConvertTo-Json -Depth 20
}
else
{
    $lines = [System.Collections.Generic.List[string]]::new()
    $lines.Add("# Provisioning Resource Schema")
    $lines.Add("")
    $lines.Add("Package: ``$($schema.PackagePath)``")
    $lines.Add("Source: ``$($schema.SourcePath)``")
    $lines.Add("")

    foreach ($resource in $schema.Resources)
    {
        $lines.Add("## $($resource.ClassName)")
        $lines.Add("")
        $lines.Add("- Resource type: ``$($resource.ResourceType)``")
        $lines.Add("- Default API version: ``$($resource.DefaultApiVersion)``")
        $lines.Add("- Source file: ``$($resource.SourcePath)``")
        if ($resource.AdditionalSourcePaths.Count -gt 0)
        {
            $lines.Add("- Additional source files: ``$($resource.AdditionalSourcePaths -join '`, ``')``")
        }
        $lines.Add("")
        $lines.Add("| Property | Path | Kind | Type | Required | Settable | Default | Metadata |")
        $lines.Add("| --- | --- | --- | --- | --- | --- | --- | --- |")
        foreach ($property in $resource.Properties)
        {
            $path = if ($property.SerializedPath.Count -gt 0) { $property.SerializedPath -join '.' } else { '' }
            $lines.Add("| ``$($property.Name)`` | ``$path`` | $($property.Kind) | ``$($property.Type)`` | $($property.IsRequired) | $($property.IsSettable) | ``$($property.DefaultValue)`` | $($property.IsMetadata) |")
        }
        $lines.Add("")
    }

    $output = $lines -join [Environment]::NewLine
}

if (![string]::IsNullOrWhiteSpace($OutputPath))
{
    $outputDirectory = Split-Path -Parent $OutputPath
    if (![string]::IsNullOrWhiteSpace($outputDirectory))
    {
        New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null
    }
    Set-Content -LiteralPath $OutputPath -Value $output -Encoding utf8
}

$output
