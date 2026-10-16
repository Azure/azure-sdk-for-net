#Requires -Version 7.0

. (Join-Path $PSScriptRoot "../../common/scripts/Helpers/PSModule-Helpers.ps1")
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

BeforeDiscovery {
    $dependencyCases = @(
        @{ Emitter = "http-client-csharp"; Dependency = "@typespec/http-client-csharp" }
        @{ Emitter = "http-client-csharp-mgmt"; Dependency = "@typespec/http-client-csharp" }
        @{ Emitter = "http-client-csharp-mgmt"; Dependency = "@azure-typespec/http-client-csharp" }
    )
    $olderCases = foreach ($case in $dependencyCases) {
        foreach ($version in @("1.0.0-alpha.20261012.1", "1.0.0-alpha.20261013.3")) {
            @{ Emitter = $case.Emitter; Dependency = $case.Dependency; Version = $version }
        }
    }
}

BeforeAll {
    $repoRoot = (Resolve-Path (Join-Path $PSScriptRoot "../../..")).Path
    . (Join-Path $repoRoot "eng/scripts/typespec/CodeGen-Helpers.ps1")
    $current = "1.0.0-alpha.20261014.2"
    $older = "1.0.0-alpha.20261013.2"
    $newer = "1.0.0-alpha.20261015.1"
    $base = "@typespec/http-client-csharp"
    $azure = "@azure-typespec/http-client-csharp"
    $template = Join-Path $TestDrive "template"
    $descriptorPaths = @(
        "eng/http-client-csharp-emitter-package.json"
        "eng/azure-typespec-http-client-csharp-emitter-package.json"
    )

    function Write-Json($Path, $Value) {
        $Value | ConvertTo-Json -Depth 20 | Set-Content $Path
    }

    function New-Resolution($Dependency, $Version) {
        @{
            version = $Version
            resolved = "https://registry.npmjs.org/$Dependency/-/$($Dependency.Split('/')[-1])-$Version.tgz"
            integrity = "sha512-fixture"
        }
    }

    function Set-DependencyVersion($Root, $Emitter, $Dependency, $Version) {
        $directory = Join-Path $Root "eng/packages/$Emitter"
        $manifestPath = Join-Path $directory "package.json"
        $lockPath = Join-Path $directory "package-lock.json"
        $manifest = Get-Content $manifestPath -Raw | ConvertFrom-Json -AsHashtable
        $lock = Get-Content $lockPath -Raw | ConvertFrom-Json -AsHashtable
        $manifest.dependencies[$Dependency] = $Version
        $lock.packages[''].dependencies[$Dependency] = $Version
        $lock.packages["node_modules/$Dependency"] = New-Resolution $Dependency $Version
        Write-Json $manifestPath $manifest
        Write-Json $lockPath $lock
    }

    New-Item -ItemType Directory -Force (Join-Path $template "eng") | Out-Null
    foreach ($emitter in @("http-client-csharp", "http-client-csharp-mgmt")) {
        $directory = Join-Path $template "eng/packages/$emitter"
        New-Item -ItemType Directory -Force $directory | Out-Null
        $dependencies = @{ $base = $current }
        if ($emitter.EndsWith("-mgmt")) { $dependencies[$azure] = $current }
        Write-Json (Join-Path $directory "package.json") @{
            name = "@azure-typespec/$emitter"
            dependencies = $dependencies
        }
        $packages = @{ "" = @{ dependencies = $dependencies } }
        foreach ($dependency in $dependencies.Keys) {
            $packages["node_modules/$dependency"] = New-Resolution $dependency $current
        }
        Write-Json (Join-Path $directory "package-lock.json") @{ lockfileVersion = 3; packages = $packages }
    }
    Write-Json (Join-Path $template $descriptorPaths[0]) @{ dependencies = @{ $base = $current } }
    Write-Json (Join-Path $template $descriptorPaths[1]) @{ dependencies = @{ $azure = $current } }
}

Describe "Emitter dependency version ceilings" {
    BeforeEach {
        $fixture = Join-Path $TestDrive ([Guid]::NewGuid().ToString())
        Copy-Item $template $fixture -Recurse -Force
    }

    It "accepts versions equal to the local descriptor for <Emitter> / <Dependency>" -ForEach $dependencyCases {
        { Assert-EmitterDependencies $fixture "eng/packages/$Emitter" } | Should -Not -Throw
    }

    It "accepts older version <Version> without publication history for <Emitter> / <Dependency>" -ForEach $olderCases {
        Set-DependencyVersion $fixture $Emitter $Dependency $Version
        { Assert-EmitterDependencies $fixture "eng/packages/$Emitter" } | Should -Not -Throw
    }

    It "rejects versions newer than the descriptor for <Emitter> / <Dependency>" -ForEach $dependencyCases {
        Set-DependencyVersion $fixture $Emitter $Dependency $newer
        { Assert-EmitterDependencies $fixture "eng/packages/$Emitter" } |
            Should -Throw "*$Emitter*dependency '$Dependency'*referenced version '$newer'*newer than the approved version '$current'*"
    }

    It "rejects the incident's preview when the local approved version is lower" {
        $preview = "1.0.0-alpha.20261013.3"
        Write-Json (Join-Path $fixture $descriptorPaths[1]) @{ dependencies = @{ $azure = $older } }
        Set-DependencyVersion $fixture "http-client-csharp-mgmt" $azure $preview
        { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp-mgmt" } |
            Should -Throw "*$azure*referenced version '$preview'*newer than the approved version '$older'*"
    }

    It "rejects manifest/lockfile root reference mismatch for <Emitter> / <Dependency>" -ForEach $dependencyCases {
        $path = Join-Path $fixture "eng/packages/$Emitter/package-lock.json"
        $lock = Get-Content $path -Raw | ConvertFrom-Json -AsHashtable
        $lock.packages[''].dependencies[$Dependency] = $older
        Write-Json $path $lock
        { Assert-EmitterDependencies $fixture "eng/packages/$Emitter" } |
            Should -Throw "*$Dependency*root reference '$older'*does not match*"
    }

    It "rejects direct lockfile resolution mismatch for <Emitter> / <Dependency>" -ForEach $dependencyCases {
        $path = Join-Path $fixture "eng/packages/$Emitter/package-lock.json"
        $lock = Get-Content $path -Raw | ConvertFrom-Json -AsHashtable
        $lock.packages["node_modules/$Dependency"] = New-Resolution $Dependency $older
        Write-Json $path $lock
        { Assert-EmitterDependencies $fixture "eng/packages/$Emitter" } |
            Should -Throw "*$Dependency*resolved version '$older'*does not match*"
    }

    It "rejects a nested resolution newer than the descriptor even with valid direct pins" {
        $path = Join-Path $fixture "eng/packages/http-client-csharp-mgmt/package-lock.json"
        $lock = Get-Content $path -Raw | ConvertFrom-Json -AsHashtable
        $lock.packages["node_modules/$azure/node_modules/$base"] = New-Resolution $base $newer
        Write-Json $path $lock
        { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp-mgmt" } |
            Should -Throw "*$base*referenced version '$current'*node_modules/$azure/node_modules/$base*version '$newer'*newer than the approved version '$current'*"
    }

    It "accepts a nested older resolution" {
        $path = Join-Path $fixture "eng/packages/http-client-csharp-mgmt/package-lock.json"
        $lock = Get-Content $path -Raw | ConvertFrom-Json -AsHashtable
        $lock.packages["node_modules/$azure/node_modules/$base"] = New-Resolution $base $older
        Write-Json $path $lock
        { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp-mgmt" } | Should -Not -Throw
    }

    It "rejects non-exact manifest reference <Reference>" -ForEach @(
        @{ Reference = "^1.0.0" }, @{ Reference = "next" }, @{ Reference = "file:../preview" },
        @{ Reference = "npm:preview@1.0.0" }, @{ Reference = "" }
    ) {
        Set-DependencyVersion $fixture "http-client-csharp" $base $Reference
        { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp" } |
            Should -Throw "*Unable to compare*$base*referenced version '$Reference'*approved version '$current'*"
    }

    It "fails explicitly when the approval descriptor is invalid" {
        Write-Json (Join-Path $fixture $descriptorPaths[0]) @{ dependencies = @{ $base = "next" } }
        { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp" } |
            Should -Throw "*Unable to compare*$base*approved version 'next'*"
    }

    It "does not treat peer dependencies as descriptor approvals" {
        Write-Json (Join-Path $fixture $descriptorPaths[0]) @{ peerDependencies = @{ $base = $current } }
        { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp" } |
            Should -Throw "*Unable to compare*$base*approved version ''*"
    }

    It "reads updated approvals dynamically rather than hard-coding versions" {
        $newApproval = "2.0.0-alpha.7"
        Write-Json (Join-Path $fixture $descriptorPaths[0]) @{ dependencies = @{ $base = $newApproval } }
        Set-DependencyVersion $fixture "http-client-csharp" $base $newApproval
        { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp" } | Should -Not -Throw
    }

    It "reports a missing approval descriptor explicitly" {
        Remove-Item (Join-Path $fixture $descriptorPaths[0])
        { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp" } |
            Should -Throw "*emitter-package.json*does not exist*"
    }

    It "rejects a missing lockfile root or direct resolution" -ForEach @(
        @{ MissingPath = "" }, @{ MissingPath = "node_modules/@typespec/http-client-csharp" }
    ) {
        $path = Join-Path $fixture "eng/packages/http-client-csharp/package-lock.json"
        $lock = Get-Content $path -Raw | ConvertFrom-Json -AsHashtable
        $lock.packages.Remove($MissingPath)
        Write-Json $path $lock
        { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp" } |
            Should -Throw "*$base*does not match*"
    }

    It "supports npm lockfile v2 but rejects unresolved v1" -ForEach @(
        @{ LockVersion = 2; Valid = $true }, @{ LockVersion = 1; Valid = $false }
    ) {
        $path = Join-Path $fixture "eng/packages/http-client-csharp/package-lock.json"
        $lock = Get-Content $path -Raw | ConvertFrom-Json -AsHashtable
        $lock.lockfileVersion = $LockVersion
        Write-Json $path $lock
        if ($Valid) {
            { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp" } | Should -Not -Throw
        }
        else {
            { Assert-EmitterDependencies $fixture "eng/packages/http-client-csharp" } |
                Should -Throw "*package-lock.json must contain*package resolutions*"
        }
    }

}

Describe "Shared code generation helpers" {
    BeforeAll {
        Set-StrictMode -Version 3
    }

    It "reads the package version" {
        $path = Join-Path $TestDrive "package-version.json"
        Write-Json $path @{ version = $current }
        Get-PackageJsonVersion $path | Should -BeExactly $current
    }

    It "prefers regular dependencies to peer dependencies" {
        $path = Join-Path $TestDrive "dependency-version.json"
        Write-Json $path @{
            dependencies = @{ $base = $current }
            peerDependencies = @{ $base = $older }
        }
        Get-NpmDependencyVersion $path $base | Should -BeExactly $current
    }

    It "supports the dashboard's peer-dependency fallback" {
        $path = Join-Path $TestDrive "peer-version.json"
        Write-Json $path @{ peerDependencies = @{ $base = $older } }
        Get-NpmDependencyVersion $path $base | Should -BeExactly $older
        Get-NpmDependencyVersion $path $base -DependenciesOnly | Should -BeNullOrEmpty
    }

    It "returns no version when a dependency is absent" {
        $path = Join-Path $TestDrive "missing-version.json"
        Write-Json $path @{}
        Get-NpmDependencyVersion $path $base | Should -BeNullOrEmpty
    }

    It "preserves comparison diagnostics for invalid versions" {
        { Assert-VersionNotNewerThanApproved "Test dependency" "next" $current "descriptor.json" } |
            Should -Throw "*Unable to compare Test dependency version 'next'*approved version '$current'*"
    }
}

Describe "Emitter CI integration" {
    It "validates checked-in inputs before initialization can rewrite them" {
        $pipeline = Get-Content (Join-Path $repoRoot "eng/pipelines/templates/archetype-typespec-emitter.yml") -Raw
        $pipeline | Should -Match "if in\(parameters.EmitterPackagePath, 'eng/packages/http-client-csharp', 'eng/packages/http-client-csharp-mgmt'\)"
        $pipeline.IndexOf("Assert-EmitterDependencies") | Should -BeGreaterThan -1
        $pipeline.IndexOf("Assert-EmitterDependencies") |
            Should -BeLessThan $pipeline.IndexOf("Initialize-WorkingDirectory.ps1")
        $pipeline | Should -Match 'eng/scripts/typespec/CodeGen-Helpers.ps1'
        $pipeline.Substring(0, $pipeline.IndexOf("Initialize-WorkingDirectory.ps1")) |
            Should -Not -Match 'git fetch|Get-EmitterApprovalHistory'
        $pipeline | Should -Match "Invoke-Pester -Path.*Validate-EmitterDependencies.tests.ps1"
    }

    It "triggers both CI pipelines for dependencies, validators, tests and approvals" {
        foreach ($emitter in @("http-client-csharp", "http-client-csharp-mgmt")) {
            $pipeline = Get-Content (Join-Path $repoRoot "eng/packages/$emitter/ci.yml") -Raw | ConvertFrom-Yaml
            foreach ($trigger in @("trigger", "pr")) {
                foreach ($path in @(
                    "eng/packages/$emitter",
                    "eng/scripts/typespec",
                    "eng/scripts/tests/Validate-EmitterDependencies.tests.ps1",
                    "eng/http-client-csharp-emitter-package.json",
                    "eng/azure-typespec-http-client-csharp-emitter-package.json",
                    "eng/pipelines/templates/archetype-typespec-emitter.yml"
                )) {
                    $pipeline[$trigger].paths.include | Should -Contain $path
                }
            }
        }
    }
}
