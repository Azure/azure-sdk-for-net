#Requires -Version 7.0

<#
.SYNOPSIS
    Writes a Markdown inventory of ARM resources in a provisioning library.
.DESCRIPTION
    Accepts an existing DLL, a .csproj, or a directory containing one .csproj
    directly or under src. Projects are built before loading their assembly.
    DLL inputs are not rebuilt and must have their dependencies alongside them.

    Inspects concrete types derived from ProvisionableResource, including types
    with non-public constructors. Parent and Scope describe public instance
    properties, not assigned parent instances or ARM deployment scope kinds.

    Only inspect trusted libraries: loading assemblies and invoking resource
    constructors executes code. Use a PowerShell runtime compatible with the DLL.
.PARAMETER Path
    Library DLL, project file, project directory, or SDK package directory.
.PARAMETER OutputPath
    Destination Markdown file. An existing file is overwritten after inspection.
.PARAMETER Framework
    Target framework used when building a project. Defaults to netstandard2.0.
.PARAMETER Configuration
    Build configuration used for project inputs. Defaults to Debug.
.EXAMPLE
    .\Export-ResourceInventory.ps1 -Path .\sdk\batch\Azure.Provisioning.Batch -OutputPath .\batch-resources.md
.EXAMPLE
    .\Export-ResourceInventory.ps1 -Path .\artifacts\bin\Azure.Provisioning.Batch\Debug\netstandard2.0\Azure.Provisioning.Batch.dll -OutputPath .\batch-resources.md
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory, Position = 0)]
    [string] $Path,

    [Parameter(Mandatory)]
    [string] $OutputPath,

    [string] $Framework = 'netstandard2.0',

    [string] $Configuration = 'Debug'
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

function ConvertTo-MarkdownCell([string] $Value) {
    if ([string]::IsNullOrEmpty($Value)) {
        return '-'
    }
    return $Value.Replace('&', '&amp;').Replace('<', '&lt;').Replace('>', '&gt;').Replace('|', '&#124;').Replace('`', '&#96;').Replace("`r", '').Replace("`n", '<br>')
}

$inputItem = Get-Item -LiteralPath $Path
$outputFile = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($OutputPath)
if ([System.IO.Path]::GetExtension($outputFile) -ne '.md') {
    throw 'OutputPath must name a .md file.'
}

if ($inputItem.PSIsContainer) {
    $projects = @(Get-ChildItem -LiteralPath $inputItem.FullName -Filter '*.csproj' -File)
    if ($projects.Count -eq 0 -and (Test-Path -LiteralPath (Join-Path $inputItem.FullName 'src') -PathType Container)) {
        $projects = @(Get-ChildItem -LiteralPath (Join-Path $inputItem.FullName 'src') -Filter '*.csproj' -File)
    }
    if ($projects.Count -ne 1) {
        throw "Expected exactly one .csproj directly in '$Path' or its src directory; found $($projects.Count). Specify a project file instead."
    }
    $inputItem = $projects[0]
}

if ($inputItem.Extension -eq '.csproj') {
    $buildOutput = & dotnet build $inputItem.FullName --framework $Framework --configuration $Configuration --nologo --verbosity quiet /p:CopyLocalLockFileAssemblies=true 2>&1
    if ($LASTEXITCODE -ne 0) {
        throw "Build failed for '$($inputItem.FullName)':`n$($buildOutput -join "`n")"
    }
    Write-Verbose ($buildOutput -join "`n")

    $targetOutput = & dotnet msbuild $inputItem.FullName -nologo "-property:TargetFramework=$Framework" "-property:Configuration=$Configuration" -getProperty:TargetPath 2>&1
    if ($LASTEXITCODE -ne 0) {
        throw "Cannot determine the built assembly path:`n$($targetOutput -join "`n")"
    }
    $assemblyPath = (Resolve-Path -LiteralPath ($targetOutput -join "`n").Trim()).Path
}
elseif ($inputItem.Extension -eq '.dll') {
    $assemblyPath = $inputItem.FullName
}
else {
    throw "Expected a .dll, .csproj, or project directory; received '$Path'."
}

# Resolve dependencies in an isolated context so repeat runs can inspect different library versions.
if (-not ('ProvisioningResourceInventory.LoadContext' -as [type])) {
    Add-Type -TypeDefinition @'
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace ProvisioningResourceInventory
{
    public sealed class LoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver _resolver;
        private readonly string _directory;

        public LoadContext(string assemblyPath) : base(isCollectible: true)
        {
            _resolver = new AssemblyDependencyResolver(assemblyPath);
            _directory = Path.GetDirectoryName(assemblyPath);
        }

        public Assembly LoadLibrary(string path)
        {
            // Stream loading avoids locking build outputs while PowerShell retains reflection objects.
            using (var stream = File.OpenRead(path))
            {
                return LoadFromStream(stream);
            }
        }

        protected override Assembly Load(AssemblyName name)
        {
            string path = _resolver.ResolveAssemblyToPath(name);
            if (path == null)
            {
                string adjacent = Path.Combine(_directory, name.Name + ".dll");
                if (File.Exists(adjacent))
                {
                    path = adjacent;
                }
            }
            return path == null ? null : LoadLibrary(path);
        }
    }
}
'@
}

$context = [ProvisioningResourceInventory.LoadContext]::new($assemblyPath)
try {
    $assembly = $context.LoadLibrary($assemblyPath)
    try {
        $types = $assembly.GetTypes()
    }
    catch [System.Reflection.ReflectionTypeLoadException] {
        throw "Cannot load types from '$assemblyPath'. Ensure dependencies are beside the DLL, or pass its project directory to build them:`n$($_.Exception.LoaderExceptions.Message -join "`n")"
    }

    $resources = @(
        foreach ($type in ($types | Sort-Object FullName)) {
            if ($type.IsAbstract -or $type.ContainsGenericParameters) {
                continue
            }
            $base = $type.BaseType
            while ($null -ne $base -and $base.FullName -ne 'Azure.Provisioning.Primitives.ProvisionableResource') {
                $base = $base.BaseType
            }
            if ($null -eq $base) {
                continue
            }

            $flags = [System.Reflection.BindingFlags] 'Instance,Public,NonPublic'
            $constructor = $type.GetConstructor($flags, $null, [type[]] @([string], [string]), $null)
            $arguments = [object[]] @('resourceInventory', $null)
            if ($null -eq $constructor) {
                $constructor = $type.GetConstructor($flags, $null, [type[]] @([string]), $null)
                $arguments = [object[]] @('resourceInventory')
            }
            if ($null -eq $constructor) {
                throw "Resource '$($type.FullName)' has no supported (string, string) or (string) constructor."
            }
            try {
                $instance = $constructor.Invoke($arguments)
                $resourceType = [string] $base.GetProperty('ResourceType').GetValue($instance)
                $version = [string] $base.GetProperty('ResourceVersion').GetValue($instance)
            }
            catch {
                throw "Cannot inspect resource '$($type.FullName)': $($_.Exception.GetBaseException().Message)"
            }
            if ([string]::IsNullOrWhiteSpace($resourceType)) {
                throw "Resource '$($type.FullName)' has an empty ARM resource type."
            }

            $publicInstance = [System.Reflection.BindingFlags] 'Instance,Public'
            $parent = $type.GetProperty('Parent', $publicInstance)
            [PSCustomObject] @{
                Name = $type.Name
                ResourceType = $resourceType
                Parent = if ($null -ne $parent) { $parent.PropertyType.Name } else { '-' }
                HasScope = if ($null -ne $type.GetProperty('Scope', $publicInstance)) { 'Yes' } else { 'No' }
                Version = $version
            }
        }
    )
    if ($resources.Count -eq 0) {
        throw "No concrete ProvisionableResource types were found in '$assemblyPath'."
    }

    $markdown = @(
        "# $(ConvertTo-MarkdownCell $assembly.GetName().Name) ARM resources"
        ''
        "Resources: $($resources.Count)"
        ''
        'Parent resource and Has scope describe public properties (including inherited properties), not deployment scope kinds.'
        ''
        '| Resource | ARM resource type | Parent resource | Has scope | Default API version |'
        '| --- | --- | --- | --- | --- |'
        foreach ($resource in $resources) {
            $cells = @($resource.Name, $resource.ResourceType, $resource.Parent, $resource.HasScope, $resource.Version) |
                ForEach-Object { ConvertTo-MarkdownCell $_ }
            '| ' + ($cells -join ' | ') + ' |'
        }
    )
    [System.IO.Directory]::CreateDirectory([System.IO.Path]::GetDirectoryName($outputFile)) | Out-Null
    [System.IO.File]::WriteAllText($outputFile, ($markdown -join "`n") + "`n", [System.Text.UTF8Encoding]::new($false))
    Write-Output $outputFile
}
finally {
    $context.Unload()
}
