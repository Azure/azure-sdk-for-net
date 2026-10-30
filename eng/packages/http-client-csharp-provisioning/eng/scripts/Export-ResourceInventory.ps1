#Requires -Version 7.0

<#
.SYNOPSIS
    Writes a management-shaped JSON hierarchy of provisioning ARM resources.
.DESCRIPTION
    Accepts an existing DLL, a .csproj, or a directory containing one .csproj
    directly or under src. Projects are built before loading their assembly.
    DLL inputs are not rebuilt and must have their dependencies alongside them.

    Inspects concrete types derived from ProvisionableResource, including types
    with non-public constructors. Parent and Scope describe public instance
    properties, not assigned parent instances or ARM deployment scope kinds.
    Uses a subset of Get-ResourceHierarchy.ps1 field names, with null for metadata
    unavailable from provisioning reflection. Adds HasScope and ResourceVersion.

    Only inspect trusted libraries: loading assemblies and invoking resource
    constructors executes code. Use a PowerShell runtime compatible with the DLL.
.PARAMETER Path
    Library DLL, project file, project directory, or SDK package directory.
.PARAMETER OutputPath
    Destination JSON file. An existing file is overwritten after inspection.
.PARAMETER Framework
    Target framework used when building a project. Defaults to netstandard2.0.
.PARAMETER Configuration
    Build configuration used for project inputs. Defaults to Debug.
.EXAMPLE
    .\Export-ResourceInventory.ps1 -Path .\sdk\batch\Azure.Provisioning.Batch -OutputPath .\batch-resources.json
.EXAMPLE
    .\Export-ResourceInventory.ps1 -Path .\artifacts\bin\Azure.Provisioning.Batch\Debug\netstandard2.0\Azure.Provisioning.Batch.dll -OutputPath .\batch-resources.json
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

$inputItem = Get-Item -LiteralPath $Path
$outputFile = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($OutputPath)
if ([System.IO.Path]::GetExtension($outputFile) -ne '.json') {
    throw 'OutputPath must name a .json file.'
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Text.Json;

namespace ProvisioningResourceInventory
{
    public sealed class LoadContext : AssemblyLoadContext
    {
        private static readonly HashSet<string> FrameworkAssemblies = GetFrameworkAssemblies();
        private readonly AssemblyDependencyResolver _resolver;
        private readonly string _directory;

        public LoadContext(string assemblyPath) : base(isCollectible: true)
        {
            _resolver = new AssemblyDependencyResolver(assemblyPath);
            _directory = Path.GetDirectoryName(assemblyPath);
        }

        private static HashSet<string> GetFrameworkAssemblies()
        {
            var assemblies = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            // PowerShell can use a shared framework or bundle a self-contained runtime pack.
            string manifests = (string)AppContext.GetData("APP_CONTEXT_DEPS_FILES") ?? "";
            foreach (string manifest in manifests.Split(';', StringSplitOptions.RemoveEmptyEntries))
            {
                using (var document = JsonDocument.Parse(File.ReadAllText(manifest)))
                {
                    foreach (var target in document.RootElement.GetProperty("targets").EnumerateObject())
                    {
                        foreach (var library in target.Value.EnumerateObject())
                        {
                            if (!library.Name.StartsWith("Microsoft.NETCore.App.Runtime.", StringComparison.Ordinal)
                                && !library.Name.StartsWith("runtimepack.Microsoft.NETCore.App.Runtime.", StringComparison.Ordinal))
                            {
                                continue;
                            }
                            foreach (var asset in library.Value.GetProperty("runtime").EnumerateObject())
                            {
                                assemblies.Add(Path.GetFileNameWithoutExtension(asset.Name));
                            }
                        }
                    }
                }
            }
            if (assemblies.Count == 0)
            {
                throw new InvalidOperationException("Cannot identify .NET framework assemblies from the host dependency manifests.");
            }
            return assemblies;
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
            if (path != null)
            {
                return LoadLibrary(path);
            }
            if (FrameworkAssemblies.Contains(name.Name))
            {
                return null;
            }
            throw new FileNotFoundException(
                $"Cannot resolve private dependency '{name.FullName}' for the inspected library in '{_directory}'.",
                name.Name + ".dll");
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
        foreach ($type in ($types | Sort-Object Name, FullName)) {
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
            elseif ($constructor.GetParameters()[1].HasDefaultValue) {
                $arguments[1] = $constructor.GetParameters()[1].DefaultValue
            }
            if ($null -eq $constructor) {
                throw "Resource '$($type.FullName)' has no supported (string, string) or (string) constructor."
            }
            try {
                $instance = $constructor.Invoke($arguments)
                $resourceType = [string] $base.GetProperty('ResourceType').GetValue($instance)
                $version = $base.GetProperty('ResourceVersion').GetValue($instance)
            }
            catch {
                throw "Cannot inspect resource '$($type.FullName)': $($_.Exception.GetBaseException().Message)"
            }
            if ([string]::IsNullOrWhiteSpace($resourceType)) {
                throw "Resource '$($type.FullName)' has an empty ARM resource type."
            }

            $publicInstance = [System.Reflection.BindingFlags] 'Instance,Public'
            $parent = $type.GetProperty('Parent', $publicInstance)
            [PSCustomObject] [ordered] @{
                Name = $type.Name
                FullName = $type.FullName
                ResourceType = $resourceType
                CollectionType = $null
                ChildCollections = $null
                ChildResources = $null
                ParentResources = [string[]] @(if ($null -ne $parent) { $parent.PropertyType.Name })
                Scopes = $null
                HasScope = $null -ne $type.GetProperty('Scope', $publicInstance)
                ResourceVersion = $version
            }
        }
    )
    if ($resources.Count -eq 0) {
        throw "No concrete ProvisionableResource types were found in '$assemblyPath'."
    }

    $json = ConvertTo-Json -InputObject $resources -Depth 10
    [System.IO.Directory]::CreateDirectory([System.IO.Path]::GetDirectoryName($outputFile)) | Out-Null
    [System.IO.File]::WriteAllText($outputFile, $json.Replace("`r`n", "`n") + "`n", [System.Text.UTF8Encoding]::new($false))
    Write-Output $outputFile
}
finally {
    $context.Unload()
}
