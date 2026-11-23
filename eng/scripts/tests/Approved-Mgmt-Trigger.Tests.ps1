#Requires -Version 7.0
. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'Helpers' 'PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'Pester' '5.3.3' | Import-Module
Install-ModuleIfNotInstalled 'powershell-yaml' '0.4.1' | Import-Module

BeforeAll {
    $repo = Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..')
    $comparisonScript = Join-Path $repo 'eng' 'scripts' 'mgmt-dependency' 'Get-ApprovedEmitterChange.ps1'
}

Describe 'Approved management dependency trigger' -Tag 'UnitTest' {
    It 'runs independently on main descriptor changes, not branded release publishing' {
        $pipelinePath = Join-Path $repo 'eng' 'pipelines' 'update-mgmt-generator-dependency.yml'
        Test-Path $pipelinePath | Should -BeTrue
        $pipeline = Get-Content $pipelinePath -Raw | ConvertFrom-Yaml
        $pipeline.trigger.branches.include | Should -Be @('main')
        $pipeline.trigger.paths.include | Should -Be @('eng/azure-typespec-http-client-csharp-emitter-package.json')
        $pipeline.pr | Should -Be 'none'
        $branded = Get-Content (Join-Path $repo 'eng' 'packages' 'http-client-csharp' 'ci.yml') -Raw | ConvertFrom-Yaml
        $branded.trigger.paths.include | Should -Not -Contain 'eng/pipelines/templates/stages/update-mgmt-generator-dependency.yml'
        $template = Get-Content (Join-Path $repo 'eng' 'pipelines' 'templates' 'archetype-typespec-emitter.yml') -Raw
        $template | Should -Not -Match 'markPublicNpm'
        $template | Should -Not -Match 'stages/update-mgmt-generator-dependency.yml'
    }

    It 'forces the public registry even when a user config overrides the scope' {
        $stage = Get-Content (Join-Path $repo 'eng' 'pipelines' 'templates' 'stages' 'update-mgmt-generator-dependency.yml') -Raw | ConvertFrom-Yaml
        $step = @($stage.stages[0].jobs[1].steps | Where-Object displayName -eq 'Retrieve exact approved npm package metadata')[0]
        $step.pwsh | Should -Match '--@azure-typespec:registry=https://registry\.npmjs\.org'
        $config = Join-Path $TestDrive 'conflicting-npmrc'
        '@azure-typespec:registry=http://127.0.0.1:9/' | Set-Content $config
        $npmExe = (Get-Command npm -CommandType Application | Select-Object -First 1).Source
        $output = & $npmExe config get '@azure-typespec:registry' "--userconfig=$config" '--registry=https://registry.npmjs.org' '--@azure-typespec:registry=https://registry.npmjs.org'
        $LASTEXITCODE | Should -Be 0
        $output.TrimEnd('/') | Should -BeExactly 'https://registry.npmjs.org'
    }

    It 'only removes the skip marker from branded regeneration' {
        $template = Get-Content (Join-Path $repo 'eng' 'pipelines' 'templates' 'archetype-typespec-emitter.yml') -Raw
        $template | Should -Match '(?m)^\s*\$\{\{ if eq\(parameters\.EmitterPackagePath, ''eng/packages/http-client-csharp''\) \}\}:\r?\n\s*CommitMsg: Regenerate repository SDK with TypeSpec build \$\(Build.BuildNumber\)\r?\n\s*\$\{\{ else \}\}:\r?\n\s*CommitMsg: .*\[skip ci\]'
    }
}

Describe 'Approved emitter pin comparison' -Tag 'UnitTest' {
    BeforeEach {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        New-Item -ItemType Directory -Force (Join-Path $fixture 'eng') | Out-Null
        git init -b main $fixture 2>&1 | Out-Null
        git -C $fixture config user.name test
        git -C $fixture config user.email test@example.com
        $descriptor = Join-Path $fixture 'eng' 'azure-typespec-http-client-csharp-emitter-package.json'
        '{"dependencies":{"@azure-typespec/http-client-csharp":"1.0.0-alpha.1"},"other":1}' | Set-Content $descriptor
        git -C $fixture add .
        git -C $fixture commit -m initial 2>&1 | Out-Null
        $base = git -C $fixture rev-parse HEAD
    }

    It 'does nothing when only an unrelated field changes' {
        '{"dependencies":{"@azure-typespec/http-client-csharp":"1.0.0-alpha.1"},"other":2}' | Set-Content $descriptor
        git -C $fixture commit -am unrelated 2>&1 | Out-Null
        $source = git -C $fixture rev-parse HEAD
        $output = & $comparisonScript -RepoRoot $fixture -SourceVersion $source -PreviousVersion $base 6>&1 | Out-String
        $output | Should -Match 'variable=pinChanged;isOutput=true\]False'
    }

    It 'detects a changed pin even when a later commit changes an unrelated field' {
        '{"dependencies":{"@azure-typespec/http-client-csharp":"1.0.0-alpha.2"},"other":1}' | Set-Content $descriptor
        git -C $fixture commit -am pin 2>&1 | Out-Null
        '{"dependencies":{"@azure-typespec/http-client-csharp":"1.0.0-alpha.2"},"other":2}' | Set-Content $descriptor
        git -C $fixture commit -am unrelated 2>&1 | Out-Null
        $source = git -C $fixture rev-parse HEAD
        $output = & $comparisonScript -RepoRoot $fixture -SourceVersion $source -PreviousVersion $base 6>&1 | Out-String
        $output | Should -Match 'variable=pinChanged;isOutput=true\]True'
        $output | Should -Match 'variable=emitterVersion;isOutput=true\]1\.0\.0-alpha\.2'
    }

    It 'rejects a non-exact approved version' {
        '{"dependencies":{"@azure-typespec/http-client-csharp":"^1.0.0"}}' | Set-Content $descriptor
        git -C $fixture commit -am invalid 2>&1 | Out-Null
        $source = git -C $fixture rev-parse HEAD
        { & $comparisonScript -RepoRoot $fixture -SourceVersion $source -PreviousVersion $base } | Should -Throw '*exact version*'
    }
}

Describe 'Pipeline approval baseline' -Tag 'UnitTest' {
    BeforeAll {
        $stage = Get-Content (Join-Path $repo 'eng' 'pipelines' 'templates' 'stages' 'update-mgmt-generator-dependency.yml') -Raw | ConvertFrom-Yaml
        $approvalStep = @($stage.stages[0].jobs[0].steps | Where-Object name -eq 'approval')[0]
        $approvalScript = [scriptblock]::Create($approvalStep.pwsh)
    }
    BeforeEach {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        New-Item -ItemType Directory -Force (Join-Path $fixture 'eng' 'scripts' 'mgmt-dependency') | Out-Null
        git init -b main $fixture 2>&1 | Out-Null
        git -C $fixture config user.name test
        git -C $fixture config user.email test@example.com
        $descriptor = Join-Path $fixture 'eng' 'azure-typespec-http-client-csharp-emitter-package.json'
        '{"dependencies":{"@azure-typespec/http-client-csharp":"1.0.0-alpha.1"}}' | Set-Content $descriptor
        git -C $fixture add .
        git -C $fixture commit -m initial 2>&1 | Out-Null
        Copy-Item $comparisonScript (Join-Path $fixture 'eng' 'scripts' 'mgmt-dependency' 'Get-ApprovedEmitterChange.ps1')
        $source = git -C $fixture rev-parse HEAD
        $env:BUILD_SOURCEVERSION = $source
        $env:BUILD_SOURCESDIRECTORY = $fixture
        $env:BUILD_BUILDID = '10'
        $env:BUILD_REASON = 'Manual'
        $env:SYSTEM_TEAMPROJECT = 'test'
        $env:SYSTEM_COLLECTIONURI = 'https://example.test/'
        $env:SYSTEM_DEFINITIONID = '1'
        $env:SYSTEM_ACCESSTOKEN = 'test-token'
        $env:SEED_BASELINE = 'True'
        $env:RETRY_APPROVED_VERSION = 'False'
        Push-Location $fixture
        Mock Invoke-RestMethod { return @{ value = @() } }
    }
    AfterEach {
        Pop-Location
        foreach ($name in @('BUILD_SOURCEVERSION','BUILD_SOURCESDIRECTORY','BUILD_BUILDID','BUILD_REASON','SYSTEM_TEAMPROJECT','SYSTEM_COLLECTIONURI','SYSTEM_DEFINITIONID','SYSTEM_ACCESSTOKEN','SEED_BASELINE','RETRY_APPROVED_VERSION')) {
            [Environment]::SetEnvironmentVariable($name, $null)
        }
    }
    It 'seeds the initial main version without starting the updater' {
        $output = & $approvalScript 6>&1 | Out-String
        $output | Should -Match 'variable=pinChanged;isOutput=true\]False'
        $output | Should -Match 'variable=emitterVersion;isOutput=true\]1\.0\.0-alpha\.1'
    }
    It 'fails closed when no baseline has been seeded' {
        $env:SEED_BASELINE = 'False'
        $env:BUILD_REASON = 'IndividualCI'
        { & $approvalScript } | Should -Throw '*SeedBaseline=true*'
    }
    It 'refuses a combined seed and retry request' {
        $env:RETRY_APPROVED_VERSION = 'True'
        { & $approvalScript } | Should -Throw '*cannot seed and retry*'
    }
    It 'does not allow CI to seed a baseline' {
        $env:BUILD_REASON = 'IndividualCI'
        { & $approvalScript } | Should -Throw '*only be seeded by a manual run*'
    }
    It 'does not silently replace an existing baseline' {
        Mock Invoke-RestMethod { return @{ value = @(@{ id = 1; sourceVersion = 'seed' }) } }
        { & $approvalScript } | Should -Throw '*already been seeded*'
    }
    It 'allows a manual retry even if the previous CI run used the same pin' {
        $env:SEED_BASELINE = 'False'
        $env:RETRY_APPROVED_VERSION = 'True'
        $gitBinary = (Get-Command git -CommandType Application | Select-Object -First 1).Source
        Mock git { if ($args[0] -eq 'fetch') { $global:LASTEXITCODE = 0 } else { & $gitBinary @args } }
        Mock Invoke-RestMethod { return @{ value = @(@{ id = 1; sourceVersion = $source; reason = 'individualCI' }) } }
        $output = & $approvalScript 6>&1 | Out-String
        $output | Should -Match 'variable=pinChanged;isOutput=true\]True'
    }
    It 'refuses a forced retry on automatic CI' {
        $env:SEED_BASELINE = 'False'
        $env:RETRY_APPROVED_VERSION = 'True'
        $env:BUILD_REASON = 'IndividualCI'
        $gitBinary = (Get-Command git -CommandType Application | Select-Object -First 1).Source
        Mock git { if ($args[0] -eq 'fetch') { $global:LASTEXITCODE = 0 } else { & $gitBinary @args } }
        Mock Invoke-RestMethod { return @{ value = @(@{ id = 1; sourceVersion = $source; reason = 'individualCI' }) } }
        { & $approvalScript } | Should -Throw '*only be retried by a manual run*'
    }
    It 'compares with the previous CI run across multiple commits' {
        $baseline = $source
        '{"dependencies":{"@azure-typespec/http-client-csharp":"1.0.0-alpha.2"},"other":1}' | Set-Content $descriptor
        git -C $fixture commit -am pin 2>&1 | Out-Null
        '{"dependencies":{"@azure-typespec/http-client-csharp":"1.0.0-alpha.2"},"other":2}' | Set-Content $descriptor
        git -C $fixture commit -am unrelated 2>&1 | Out-Null
        $env:BUILD_SOURCEVERSION = git -C $fixture rev-parse HEAD
        $env:BUILD_REASON = 'IndividualCI'
        $env:SEED_BASELINE = 'False'
        $gitBinary = (Get-Command git -CommandType Application | Select-Object -First 1).Source
        Mock git {
            if ($args[0] -eq 'fetch') { $global:LASTEXITCODE = 0 }
            else { & $gitBinary @args }
        }
        Mock Invoke-RestMethod {
            if ($Uri -match 'resultFilter=succeeded') { return @{ value = @(@{ id = 1; sourceVersion = $baseline }) } }
            return @{ value = @(@{ id = 9; reason = 'individualCI'; sourceVersion = $baseline }) }
        }
        $output = & $approvalScript 6>&1 | Out-String
        $output | Should -Match 'variable=pinChanged;isOutput=true\]True'
        $output | Should -Match 'variable=emitterVersion;isOutput=true\]1\.0\.0-alpha\.2'
    }
}
