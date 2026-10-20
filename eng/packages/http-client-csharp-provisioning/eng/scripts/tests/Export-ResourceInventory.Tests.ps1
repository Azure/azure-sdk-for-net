#Requires -Version 7.0

# Run with Invoke-Pester -Path .\Export-ResourceInventory.Tests.ps1 -Output Detailed

BeforeAll {
    $scriptPath = Join-Path $PSScriptRoot '..\Export-ResourceInventory.ps1'
    $framework = "net$([System.Environment]::Version.Major).0"
    $coreDirectory = New-Item -ItemType Directory -Path (Join-Path $TestDrive 'core')
    $sourceDirectory = New-Item -ItemType Directory -Path (Join-Path $TestDrive 'package\src')
    Set-Content (Join-Path $coreDirectory 'Inventory.Core.csproj') @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup><TargetFramework>$framework</TargetFramework></PropertyGroup>
</Project>
"@
    Set-Content (Join-Path $coreDirectory 'Resource.cs') @'
namespace Azure.Provisioning.Primitives
{
    public abstract class ProvisionableResource
    {
        protected ProvisionableResource(string name, string resourceType, string version)
        {
            ResourceType = resourceType;
            ResourceVersion = version;
        }
        public string ResourceType { get; }
        public string ResourceVersion { get; }
    }
}
'@
    $projectPath = Join-Path $sourceDirectory 'Inventory.Sample.csproj'
    Set-Content $projectPath @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup><TargetFramework>$framework</TargetFramework></PropertyGroup>
  <ItemGroup><ProjectReference Include="..\..\core\Inventory.Core.csproj" /></ItemGroup>
</Project>
"@
    Set-Content (Join-Path $sourceDirectory 'Resources.cs') @'
using Azure.Provisioning.Primitives;
namespace Inventory.Sample
{
    public class Root : ProvisionableResource
    {
        public Root(string name, string version = null) : base(name, "Test/roots", version ?? "2025-01-01") { }
    }
    [System.Obsolete("Use Root instead.")]
    internal class Child : ProvisionableResource
    {
        internal Child(string name, string version = null) : base(name, "Test/roots/children", version ?? "2025-01-01") { }
        public Root Parent { get; set; }
    }
    public abstract class ScopedBase : ProvisionableResource
    {
        protected ScopedBase(string name) : base(name, "Test/scoped", "2025|preview") { }
        public object Scope { get; set; }
    }
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public class ScopedResource : ScopedBase
    {
        public ScopedResource(string name) : base(name) { }
    }
    public class NotAResource { }
}
'@

    $reportPath = Join-Path $TestDrive 'directory.json'
    & $scriptPath -Path (Split-Path $sourceDirectory) -OutputPath $reportPath -Framework $framework
    $directoryReport = Get-Content -LiteralPath $reportPath -Raw
    $directoryResources = ConvertFrom-Json -InputObject $directoryReport -NoEnumerate
    $assemblyPath = Join-Path $sourceDirectory "bin\Debug\$framework\Inventory.Sample.dll"
}

Describe 'Export-ResourceInventory' {
    It 'builds a package directory and reports only concrete resources in stable order' {
        $directoryResources.Count | Should -Be 3
        ($directoryResources.Name -join ',') | Should -Be 'Child,Root,ScopedResource'
        $directoryResources[0].FullName | Should -Be 'Inventory.Sample.Child'
        $directoryResources[0].ResourceType | Should -Be 'Test/roots/children'
        @($directoryResources[0].ParentResources).Count | Should -Be 1
        $directoryResources[0].ParentResources[0] | Should -Be 'Root'
        $directoryResources[0].HasScope | Should -BeFalse
        $directoryResources[0].ResourceVersion | Should -Be '2025-01-01'
        @($directoryResources[1].ParentResources).Count | Should -Be 0
        $directoryResources[2].HasScope | Should -BeTrue
        $directoryResources[2].ResourceVersion | Should -Be '2025|preview'
    }

    It 'uses the provisioning hierarchy fields and leaves unavailable concepts explicitly null' {
        $expectedFields = @(
            'Name', 'FullName', 'ResourceType', 'CollectionType', 'ChildCollections',
            'ChildResources', 'ParentResources', 'Scopes', 'HasScope', 'ResourceVersion'
        )
        foreach ($resource in $directoryResources) {
            ($resource.PSObject.Properties.Name -join ',') | Should -Be ($expectedFields -join ',')
            foreach ($field in @('CollectionType', 'ChildCollections', 'ChildResources', 'Scopes')) {
                ($null -eq $resource.$field) | Should -BeTrue
            }
            ($resource.ParentResources -is [array]) | Should -BeTrue
            ($resource.HasScope -is [bool]) | Should -BeTrue
        }
    }

    It 'omits singleton, management-only and deprecation fields even on attributed types' {
        foreach ($resource in $directoryResources) {
            foreach ($field in @('ResourceId', 'DataType', 'IsTrackedResource', 'IsSingleton', 'IsSingletonResource', 'IsObsolete', 'ObsoleteMessage', 'IsEditorBrowsableNever')) {
                $resource.PSObject.Properties.Name | Should -Not -Contain $field
            }
        }
    }

    It 'loads an existing DLL with adjacent dependencies and creates output directories' {
        $output = Join-Path $TestDrive 'nested\dll.json'
        & $scriptPath -Path $assemblyPath -OutputPath $output
        Get-Content -LiteralPath $output -Raw | Should -Be $directoryReport
    }

    It 'writes UTF-8 without a BOM and uses LF line endings for committed reports' {
        $bytes = [System.IO.File]::ReadAllBytes($reportPath)
        $bytes[0] | Should -Be 91
        $directoryReport.Contains("`r") | Should -BeFalse
        $directoryReport.EndsWith("`n") | Should -BeTrue
    }

    It 'supports repeated loads and explicit project-file inputs' {
        $output = Join-Path $TestDrive 'project.json'
        & $scriptPath -Path $projectPath -OutputPath $output -Framework $framework
        & $scriptPath -Path $assemblyPath -OutputPath $output
        Get-Content -LiteralPath $output -Raw | Should -Be $directoryReport
    }

    It 'does not lock the inspected DLL or its dependency' {
        $unlocked = New-Item -ItemType Directory -Path (Join-Path $TestDrive 'unlocked')
        $dll = Join-Path $unlocked 'Inventory.Sample.dll'
        $dependency = Join-Path $unlocked 'Inventory.Core.dll'
        Copy-Item -LiteralPath $assemblyPath -Destination $dll
        Copy-Item -LiteralPath (Join-Path (Split-Path $assemblyPath) 'Inventory.Core.dll') -Destination $dependency
        & $scriptPath -Path $dll -OutputPath (Join-Path $TestDrive 'unlocked.json')
        Remove-Item -LiteralPath $dll, $dependency
        Test-Path -LiteralPath $dll | Should -BeFalse
        Test-Path -LiteralPath $dependency | Should -BeFalse
    }

    It 'rejects ambiguous project directories' {
        $ambiguous = New-Item -ItemType Directory -Path (Join-Path $TestDrive 'ambiguous')
        Set-Content (Join-Path $ambiguous 'One.csproj') '<Project />'
        Set-Content (Join-Path $ambiguous 'Two.csproj') '<Project />'
        { & $scriptPath -Path $ambiguous -OutputPath (Join-Path $TestDrive 'ambiguous.json') } |
            Should -Throw '*Expected exactly one .csproj*'
    }

    It 'rejects missing inputs and directories without projects' {
        { & $scriptPath -Path (Join-Path $TestDrive 'missing.dll') -OutputPath (Join-Path $TestDrive 'missing.json') } |
            Should -Throw
        $empty = New-Item -ItemType Directory -Path (Join-Path $TestDrive 'empty')
        { & $scriptPath -Path $empty -OutputPath (Join-Path $TestDrive 'empty.json') } |
            Should -Throw '*found 0*'
    }

    It 'rejects non-JSON output and unsupported input files' {
        { & $scriptPath -Path $assemblyPath -OutputPath $assemblyPath } |
            Should -Throw '*must name a .json file*'
        { & $scriptPath -Path $assemblyPath -OutputPath (Join-Path $TestDrive 'old-format.md') } |
            Should -Throw '*must name a .json file*'
        $textFile = Join-Path $TestDrive 'input.txt'
        Set-Content $textFile 'not an assembly'
        { & $scriptPath -Path $textFile -OutputPath (Join-Path $TestDrive 'text.json') } |
            Should -Throw '*Expected a .dll, .csproj, or project directory*'
    }

    It 'reports project build failures without overwriting the existing report' {
        $invalidProject = Join-Path $TestDrive 'Invalid.csproj'
        Set-Content $invalidProject '<Project'
        $output = Join-Path $TestDrive 'unchanged.json'
        Set-Content $output 'preserve this report'
        { & $scriptPath -Path $invalidProject -OutputPath $output -Framework $framework } |
            Should -Throw '*Build failed*'
        (Get-Content $output -Raw).Trim() | Should -Be 'preserve this report'
    }

    It 'fails explicitly for a library with no concrete resources' {
        $coreAssembly = Join-Path $sourceDirectory "bin\Debug\$framework\Inventory.Core.dll"
        { & $scriptPath -Path $coreAssembly -OutputPath (Join-Path $TestDrive 'no-resources.json') } |
            Should -Throw '*No concrete ProvisionableResource types*'
    }

    It 'reports <Failure> without producing a partial report' -ForEach @(
        @{
            Failure = 'unsupported constructors'
            Folder = 'unsupported'
            Constructor = 'public Broken(int value) : base("name", "Test/broken", null) { }'
            Message = '*has no supported*constructor*'
        }
        @{
            Failure = 'constructor exceptions'
            Folder = 'throwing'
            Constructor = 'public Broken(string name, string version = null) : base(name, "Test/broken", version) { throw new System.InvalidOperationException("Constructor deliberately failed."); }'
            Message = '*Cannot inspect resource*Constructor deliberately failed*'
        }
    ) {
        $failureDirectory = New-Item -ItemType Directory -Path (Join-Path $TestDrive $Folder)
        $failureProject = Join-Path $failureDirectory 'Inventory.Failure.csproj'
        Set-Content $failureProject @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup><TargetFramework>$framework</TargetFramework></PropertyGroup>
  <ItemGroup><ProjectReference Include="..\core\Inventory.Core.csproj" /></ItemGroup>
</Project>
"@
        Set-Content (Join-Path $failureDirectory 'Broken.cs') @"
public class Broken : Azure.Provisioning.Primitives.ProvisionableResource
{
    $Constructor
}
"@
        $output = Join-Path $failureDirectory 'report.json'
        { & $scriptPath -Path $failureProject -OutputPath $output -Framework $framework } |
            Should -Throw $Message
        Test-Path -LiteralPath $output | Should -BeFalse
    }

    It 'fails explicitly when a required assembly dependency is absent' {
        $isolated = New-Item -ItemType Directory -Path (Join-Path $TestDrive 'isolated')
        $isolatedAssembly = Join-Path $isolated 'Inventory.Sample.dll'
        Copy-Item -LiteralPath $assemblyPath -Destination $isolatedAssembly
        { & $scriptPath -Path $isolatedAssembly -OutputPath (Join-Path $TestDrive 'missing-dependency.json') } |
            Should -Throw '*Inventory.Core*'
        Test-Path -LiteralPath (Join-Path $TestDrive 'missing-dependency.json') | Should -BeFalse
    }

    It 'preserves the outer JSON array for a single resource' {
        $singleDirectory = New-Item -ItemType Directory -Path (Join-Path $TestDrive 'single')
        $singleProject = Join-Path $singleDirectory 'Inventory.Single.csproj'
        Set-Content $singleProject @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup><TargetFramework>$framework</TargetFramework></PropertyGroup>
  <ItemGroup><ProjectReference Include="..\core\Inventory.Core.csproj" /></ItemGroup>
</Project>
"@
        Set-Content (Join-Path $singleDirectory 'Single.cs') @'
public class Single : Azure.Provisioning.Primitives.ProvisionableResource
{
    public Single(string name) : base(name, "Test/single", null) { }
}
'@
        $output = Join-Path $singleDirectory 'report.json'
        & $scriptPath -Path $singleProject -OutputPath $output -Framework $framework
        $single = ConvertFrom-Json -InputObject (Get-Content $output -Raw) -NoEnumerate
        ($single -is [array]) | Should -BeTrue
        $single.Count | Should -Be 1
        $single[0].Name | Should -Be 'Single'
        $single[0].ResourceVersion | Should -BeNullOrEmpty
        ($single[0].ParentResources -is [array]) | Should -BeTrue
        $single[0].ParentResources.Count | Should -Be 0
    }
}
