#Requires -Version 7.0

BeforeAll {
    Set-StrictMode -Version 3
    Import-Module powershell-yaml -MinimumVersion 0.4.7 -ErrorAction Stop
    $repo = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' '..')).Path
    $templatePath = Join-Path $repo 'eng' 'pipelines' 'templates' 'steps' 'sdk-api-changes.yml'
    $buildPath = Join-Path $repo 'eng' 'pipelines' 'templates' 'steps' 'build.yml'
    $template = Get-Content -LiteralPath $templatePath -Raw | ConvertFrom-Yaml
    $build = Get-Content -LiteralPath $buildPath -Raw | ConvertFrom-Yaml
    $publisher = Get-Content -LiteralPath (Join-Path $repo 'eng' 'common' 'pipelines' 'templates' 'steps' 'publish-1es-artifact.yml') -Raw | ConvertFrom-Yaml

    function Get-YamlObjects {
        param($Node)
        if ($Node -is [System.Collections.IDictionary]) {
            $Node
            foreach ($value in $Node.Values) { Get-YamlObjects $value }
        }
        elseif ($Node -is [System.Collections.IEnumerable] -and $Node -isnot [string]) {
            foreach ($value in $Node) { Get-YamlObjects $value }
        }
    }
    $nodes = @(Get-YamlObjects $template)
    $collect = @($nodes | Where-Object { $_['displayName'] -eq 'Collect standalone SDK API change reports' })[0]
    $enforce = @($nodes | Where-Object { $_['displayName'] -eq 'Enforce standalone SDK API compatibility' })[0]
    $publish = @($nodes | Where-Object { $_['template'] -eq '/eng/common/pipelines/templates/steps/publish-1es-artifact.yml' })[0]
}

Describe 'Automatic SDK PR YAML integration' -Tag 'UnitTest' {
    It 'limits the new workflow to actual SDK pull requests' {
        @($template.steps[0].Keys) | Should -Contain '${{ if eq(variables[''Build.Reason''], ''PullRequest'') }}'
        @($template.parameters | Where-Object { $_.name -eq 'Mode' })[0].values | Should -Be @('collect', 'enforce')
    }

    It 'collects after both existing Release pack branches and before later artifact-mutating checks' {
        $collectIndex = -1
        $enforceIndex = -1
        $aotIndex = -1
        $packIndexes = @()
        for ($i = 0; $i -lt $build.steps.Count; $i++) {
            $step = $build.steps[$i]
            if ($step['template'] -eq '/eng/pipelines/templates/steps/sdk-api-changes.yml') {
                if ($step.parameters.Mode -eq 'collect') { $collectIndex = $i } else { $enforceIndex = $i }
            }
            if ($step['template'] -eq '/eng/pipelines/templates/steps/aot-compatibility.yml') { $aotIndex = $i }
            if (@(Get-YamlObjects $step | Where-Object { $_['pwsh'] -is [string] -and $_.pwsh -match 'dotnet pack eng/service.proj' }).Count -gt 0) {
                $packIndexes += $i
            }
        }
        $packIndexes.Count | Should -Be 2
        foreach ($index in $packIndexes) { $collectIndex | Should -BeGreaterThan $index }
        $collectIndex | Should -BeLessThan $aotIndex
        $enforceIndex | Should -Be ($build.steps.Count - 1)
    }

    It 'preserves the existing build-coupled ApiCompat gates and Release configuration' {
        $packSteps = @(Get-YamlObjects $build | Where-Object { $_['pwsh'] -is [string] -and $_.pwsh -match 'dotnet pack eng/service.proj' })
        $packSteps.Count | Should -Be 2
        foreach ($step in $packSteps) {
            $step.pwsh | Should -Match '/p:ValidateRunApiCompat=true'
            $step.pwsh | Should -Match '/p:Configuration=Release'
            $step.pwsh | Should -Not -Match '/p:RunApiCompat=false'
        }
    }

    It 'runs collection and final assertion even if a previous build or analyzer gate failed' {
        $collect.condition | Should -Be 'succeededOrFailed()'
        $enforce.condition | Should -Be 'succeededOrFailed()'
        $collect.continueOnError | Should -BeTrue
        $collect.inputs.arguments | Should -Match '-ReportOnly'
        $enforce.Contains('continueOnError') | Should -BeFalse
    }

    It 'uses the existing package selection and actual Release configuration, not public BuildConfiguration=Debug' {
        $collect.inputs.arguments | Should -Match ([regex]::Escape('-ProjectNames "$(ProjectNames)"'))
        $collect.inputs.arguments | Should -Match ([regex]::Escape('$(Build.ArtifactStagingDirectory)/PackageInfo'))
        $collect.env.Configuration | Should -Be 'Release'
        $collect.env.TargetFramework | Should -BeNullOrEmpty
        $collect.env.TargetFrameworks | Should -BeNullOrEmpty
        $collect.inputs.arguments | Should -Not -Match 'BuildConfiguration'
    }

    It 'does not add report files to the existing package artifact directory' {
        $collect.inputs.arguments | Should -Match ([regex]::Escape('-ReportRoot "$(Agent.TempDirectory)/sdk-api-changes"'))
        $publish.parameters.ArtifactPath | Should -Be '$(SdkChangesReportDirectory)'
        $publish.parameters.ArtifactName | Should -Be 'sdk-api-changes_$(System.JobName)'
    }

    It 'establishes the API verdict before publication so failed attempts use retry-safe artifact names' {
        $enforceBlock = @($nodes | Where-Object { $_.Keys -contains '${{ if eq(parameters.Mode, ''enforce'') }}' })[0]
        $steps = $enforceBlock['${{ if eq(parameters.Mode, ''enforce'') }}']
        $steps[0].displayName | Should -Be 'Enforce standalone SDK API compatibility'
        $steps[1].template | Should -Be '/eng/common/pipelines/templates/steps/publish-1es-artifact.yml'
        $publisher.steps[0].pwsh | Should -Match 'FailedAttempt'
        $publisher.steps[1].condition | Should -Match 'succeededOrFailed'
        foreach ($name in $publish.parameters.Keys) { $publisher.parameters.Contains($name) | Should -BeTrue }
    }

    It 'references existing runner scripts without requiring an unpublished CLI or additional permissions' {
        foreach ($step in @($collect, $enforce)) {
            $step.task | Should -Be 'PowerShell@2'
            $step.inputs.pwsh | Should -BeTrue
            $relative = $step.inputs.filePath.Replace('$(Build.SourcesDirectory)/', '').Replace('/', '\')
            Test-Path -LiteralPath (Join-Path $repo $relative) -PathType Leaf | Should -BeTrue
        }
        $text = Get-Content -LiteralPath $templatePath -Raw
        $text | Should -Not -Match 'azsdk.exe|detect-breaking-change|azureSubscription|SYSTEM_ACCESSTOKEN|RunApiCompat=false'
    }

    It 'is reached by both batched PR builds and ordinary service build jobs' {
        foreach ($file in @('batched-build.yml', 'ci.yml')) {
            $job = Get-Content -LiteralPath (Join-Path $repo 'eng' 'pipelines' 'templates' 'jobs' $file) -Raw | ConvertFrom-Yaml
            @(Get-YamlObjects $job | Where-Object { $_['template'] -eq '/eng/pipelines/templates/steps/build.yml' }).Count |
                Should -BeGreaterThan 0
        }
    }

    It 'runs both native and CI regression suites in the existing Compliance job with nonzero failures' {
        $jobs = Get-Content -LiteralPath (Join-Path $repo 'eng' 'pipelines' 'templates' 'jobs' 'ci.yml') -Raw | ConvertFrom-Yaml
        $compliance = @(Get-YamlObjects $jobs | Where-Object { $_['job'] -eq 'Compliance' })[0]
        $testTemplate = @(Get-YamlObjects $compliance | Where-Object { $_['template'] -eq '/eng/common/pipelines/templates/steps/run-pester-tests.yml' })[0]
        $testTemplate.parameters.TargetDirectory | Should -Be 'eng/scripts/compatibility'
        $step = $testTemplate.parameters.CustomTestSteps[0]
        $step.pwsh | Should -Match ([regex]::Escape('$config.Run.Path = @(''tests'', ''ci-tests'')'))
        $step.pwsh | Should -Match ([regex]::Escape('$config.Run.Exit = $true'))
        $step.pwsh | Should -Match ([regex]::Escape('$config.TestResult.Enabled = $true'))
        $step.pwsh | Should -Match 'Invoke-Pester -Configuration'
    }

    It 'prepares the existing YAML module and net8 targeting packs for native regression fixtures' {
        $jobs = Get-Content -LiteralPath (Join-Path $repo 'eng' 'pipelines' 'templates' 'jobs' 'ci.yml') -Raw | ConvertFrom-Yaml
        $compliance = @(Get-YamlObjects $jobs | Where-Object { $_['job'] -eq 'Compliance' })[0]
        @(Get-YamlObjects $compliance | Where-Object { $_['task'] -eq 'NuGetAuthenticate@1' }).Count | Should -Be 1
        @(Get-YamlObjects $compliance | Where-Object { $_['task'] -eq 'UseDotNet@2' -and $_.inputs['version'] -eq '8.0.x' }).Count | Should -Be 1
        @(Get-YamlObjects $compliance | Where-Object {
            $_['pwsh'] -is [string] -and $_.pwsh -match 'Install-ModuleIfNotInstalled "powershell-yaml" "0.4.7"'
        }).Count | Should -Be 1
    }
}
