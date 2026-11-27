#Requires -Version 7.0
. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'Helpers' 'PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'Pester' '5.3.3' | Import-Module
Install-ModuleIfNotInstalled 'powershell-yaml' '0.4.1' | Import-Module

BeforeAll {
    $repo = Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..')
    $pipelinePath = Join-Path $repo 'eng' 'pipelines' 'templates' 'stages' 'update-mgmt-generator-dependency.yml'
    $templatePath = Join-Path $repo 'eng' 'pipelines' 'templates' 'archetype-typespec-emitter.yml'
    $brandedPath = Join-Path $repo 'eng' 'packages' 'http-client-csharp' 'ci.yml'
}

Describe 'Branded release management dependency automation' -Tag 'UnitTest' {
    It 'keeps updater changes out of branded generator CI and validates them in eng CI' {
        $branded = Get-Content $brandedPath -Raw | ConvertFrom-Yaml
        $branded.trigger.paths.include | Should -Not -Contain 'eng/pipelines/templates/stages/update-mgmt-generator-dependency.yml'
        $engCi = Get-Content (Join-Path $repo 'eng' 'scripts' 'ci.yml') -Raw | ConvertFrom-Yaml
        $engCi.trigger.paths.include | Should -Contain 'eng/pipelines/templates/stages/update-mgmt-generator-dependency.yml'
        $engCi.pr.paths.include | Should -Contain 'eng/pipelines/update-mgmt-generator-dependency.yml'
    }

    It 'restricts updates to changed approved pins on main' {
        $pipeline = Get-Content $pipelinePath -Raw | ConvertFrom-Yaml
        $stage = $pipeline.stages[0]
        $stage.condition | Should -Match 'refs/heads/main'
        $stage.jobs[1].dependsOn | Should -Contain 'ReadApproval'
        $stage.jobs[1].condition | Should -Match 'approval.pinChanged'
    }

    It 'checks the matching NuGet publication and refreshes the GitHub token after regeneration' {
        $pipeline = Get-Content $pipelinePath -Raw
        $pipeline | Should -Match 'Verify matching NuGet publication'
        $pipeline | Should -Match 'azure.generator/index.json'
        $pipeline.IndexOf('login-to-github.yml') | Should -BeGreaterThan $pipeline.IndexOf('Regenerate management test projects')
    }

    It 'reuses a previously pushed branch rather than overwriting it on retry' {
        $pipeline = Get-Content $pipelinePath -Raw
        $pipeline | Should -Match 'ReuseExistingDependencyPR'
        $pipeline | Should -Match 'git ls-remote'
        $pipeline | Should -Match 'Failed: Update management generator branded dependency'
        $pipeline | Should -Not -Match 'git-push-changes.yml'
        $pipeline | Should -Match 'Push-MgmtDependencyBranch.ps1'
    }

    It 'makes failed updater tests fail eng scripts CI' {
        $engCi = Get-Content (Join-Path $repo 'eng' 'scripts' 'ci.yml') -Raw
        $engCi | Should -Match 'Update-MgmtGeneratorDependency.Tests.ps1'
        $engCi | Should -Match 'Mgmt-Dependency-Pipeline.Tests.ps1'
        $engCi | Should -Match 'Approved-Mgmt-Trigger.Tests.ps1'
        $engCi | Should -Match 'CustomTestSteps'
        $engCi | Should -Match 'FailedContainersCount'
    }

    It 'regenerates all management test projects and opens a draft on failure' {
        $pipeline = Get-Content $pipelinePath -Raw
        $pipeline | Should -Match 'http-client-csharp-mgmt/eng/scripts/Generate\.ps1'
        $pipeline | Should -Not -Match '(?i)-filter\b'
        $pipeline | Should -Match 'MgmtDependencyFailed'
        $pipeline | Should -Match '-(?:OpenAsDraft|Draft) \$failed'
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[1].steps)
        foreach ($name in @('Install locked management dependencies', 'Regenerate management test projects')) {
            ($steps | Where-Object displayName -eq $name).condition | Should -Match "eq\(variables\['MgmtDependencyFailed'\], 'false'\)"
        }
        ($steps | Where-Object displayName -eq 'Report failed update').condition | Should -Match "eq\(variables\['MgmtDependencyFailed'\], 'true'\)"
    }

    It 'detects an existing <Kind> branch without changing it' -ForEach @(
        @{ Kind = 'successful'; Prefix = ''; ExpectedFailure = $false },
        @{ Kind = 'failed'; Prefix = 'Failed: '; ExpectedFailure = $true }
    ) {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $remote = Join-Path $fixture 'remote.git'
        $work = Join-Path $fixture 'work'
        New-Item -ItemType Directory -Force $fixture | Out-Null
        git init --bare $remote 2>&1 | Out-Null
        git init -b main $work 2>&1 | Out-Null
        Push-Location $work
        try {
            git config user.name test
            git config user.email test@example.com
            Set-Content -Path 'file.txt' -Value 'base'
            git add file.txt
            git commit -m base 2>&1 | Out-Null
            git remote add origin $remote
            git push origin main 2>&1 | Out-Null
            git switch -c typespec/update-mgmt-branded-123 2>&1 | Out-Null
            Set-Content -Path 'file.txt' -Value 'update'
            git commit -am "${Prefix}Update management generator branded dependency to 1.0.0-alpha.20261117.1" 2>&1 | Out-Null
            git push origin typespec/update-mgmt-branded-123 2>&1 | Out-Null
            $before = git rev-parse HEAD
            git switch main 2>&1 | Out-Null
            $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[1].steps)
            $command = ($steps | Where-Object displayName -eq 'Detect previous update attempt').pwsh
            $command = $command.Replace('$(dependencyBranch)', 'typespec/update-mgmt-branded-123').Replace('$(emitterVersion)', '1.0.0-alpha.20261117.1')
            $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command))
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Be 0
            $output | Should -Match 'variable=ReuseExistingDependencyPR\]true'
            if ($ExpectedFailure) { $output | Should -Match 'variable=MgmtDependencyFailed\]true' }
            else { $output | Should -Not -Match 'variable=MgmtDependencyFailed\]true' }
            (git rev-parse refs/heads/typespec/update-mgmt-branded-123) | Should -BeExactly $before
            (git status --porcelain) | Should -BeNullOrEmpty
        } finally { Pop-Location }
    }

    It 'does not recreate a previously closed PR when retrying' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $common = Join-Path $fixture 'eng' 'common' 'scripts'
        New-Item -ItemType Directory -Force $common | Out-Null
        Set-Content -Path (Join-Path $common 'common.ps1') -Value 'function Get-GitHubPullRequests { param($RepoOwner,$RepoName,$State,$Head,$Base,$AuthToken) @(@{ state = "closed" }) }'
        Set-Content -Path (Join-Path $common 'Submit-PullRequest.ps1') -Value 'throw "A closed PR must not be recreated"'
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[1].steps)
        $command = ($steps | Where-Object displayName -eq 'Create dependency update pull request').pwsh
        $command = $command.Replace('$(MgmtDependencyFailed)', 'false').Replace('$(ReuseExistingDependencyPR)', 'true').Replace('$(emitterVersion)', '1.0.0-alpha.20261117.1').Replace('$(System.CollectionUri)', 'https://example.test/').Replace('$(System.TeamProject)', 'internal').Replace('$(Build.BuildId)', '123').Replace('$(dependencyBranch)', 'typespec/update-mgmt-branded-123').Replace('${{ parameters.HasNugetPackages }}', 'true')
        $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command))
        Push-Location $fixture
        try {
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Be 0
            $output | Should -Match 'already closed'
        } finally { Pop-Location }
    }

    It 'recovers if another attempt creates the PR between lookup and creation' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $common = Join-Path $fixture 'eng' 'common' 'scripts'
        New-Item -ItemType Directory -Force $common | Out-Null
        Set-Content -Path (Join-Path $common 'common.ps1') -Value @'
$script:lookupCount = 0
function Get-GitHubPullRequests {
    param($RepoOwner,$RepoName,$State,$Head,$Base,$AuthToken)
    $script:lookupCount++
    if ($script:lookupCount -gt 1) { return @{ state = 'open'; number = 42; html_url = 'https://example.test/pr/42' } }
}
function New-GitHubPullRequest { throw 'Another attempt created the PR' }
'@
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[1].steps)
        $command = ($steps | Where-Object displayName -eq 'Create dependency update pull request').pwsh
        $command = $command.Replace('$(MgmtDependencyFailed)', 'false').Replace('$(ReuseExistingDependencyPR)', 'false').Replace('$(emitterVersion)', '1.0.0-alpha.20261117.1').Replace('$(System.CollectionUri)', 'https://example.test/').Replace('$(System.TeamProject)', 'internal').Replace('$(Build.BuildId)', '123').Replace('$(dependencyBranch)', 'typespec/update-mgmt-branded-123').Replace('${{ parameters.HasNugetPackages }}', 'true')
        $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command))
        Push-Location $fixture
        try {
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Be 0
            $output | Should -Match 'https://example.test/pr/42'
        } finally { Pop-Location }
    }

    It 'fails PR creation when no competing open PR exists' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $common = Join-Path $fixture 'eng' 'common' 'scripts'
        New-Item -ItemType Directory -Force $common | Out-Null
        Set-Content -Path (Join-Path $common 'common.ps1') -Value @'
function Get-GitHubPullRequests { param($RepoOwner,$RepoName,$State,$Head,$Base,$AuthToken) }
function New-GitHubPullRequest { throw 'GitHub unavailable' }
'@
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[1].steps)
        $command = ($steps | Where-Object displayName -eq 'Create dependency update pull request').pwsh
        $command = $command.Replace('$(MgmtDependencyFailed)', 'false').Replace('$(ReuseExistingDependencyPR)', 'false').Replace('$(emitterVersion)', '1.0.0-alpha.20261117.1').Replace('$(System.CollectionUri)', 'https://example.test/').Replace('$(System.TeamProject)', 'internal').Replace('$(Build.BuildId)', '123').Replace('$(dependencyBranch)', 'typespec/update-mgmt-branded-123').Replace('${{ parameters.HasNugetPackages }}', 'true')
        $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command))
        Push-Location $fixture
        try {
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Not -Be 0
            $output | Should -Match 'GitHub unavailable'
        } finally { Pop-Location }
    }

    It 'checks the approved descriptor in management CI for generated PRs' {
        $template = Get-Content $templatePath -Raw
        $template | Should -Match "eq\(parameters.EmitterPackagePath, 'eng/packages/http-client-csharp-mgmt'\)"
        $template | Should -Match 'git sparse-checkout add .*/doc/GeneratorVersions/Emitter_Version_Dashboard.ps1'
        $template | Should -Match 'Emitter_Version_Dashboard.ps1.*-ValidateOnly'
        $engCi = Get-Content (Join-Path $repo 'eng' 'scripts' 'ci.yml') -Raw | ConvertFrom-Yaml
        $engCi.pr.paths.include | Should -Contain 'eng/centralpackagemanagement/Directory.Generation.Packages.props'
        $engCi.pr.paths.include | Should -Contain 'eng/azure-typespec-http-client-csharp-emitter-package.json'
        $engCi.pr.paths.include | Should -Contain 'doc/GeneratorVersions/Emitter_Version_Dashboard.ps1'
        $engCi.extends.parameters.CustomTestSteps[0].pwsh | Should -Match 'Emitter_Version_Dashboard.ps1.*-ValidateOnly'
    }

    It 'runs <Name> CI for changes to the shared generator pins without publishing on main' -ForEach @(
        @{ Name = 'management'; Package = 'http-client-csharp-mgmt' },
        @{ Name = 'provisioning'; Package = 'http-client-csharp-provisioning' }
    ) {
        $ci = Get-Content (Join-Path $repo 'eng' 'packages' $Package 'ci.yml') -Raw | ConvertFrom-Yaml
        $props = 'eng/centralpackagemanagement/Directory.Generation.Packages.props'
        $ci.pr.paths.include | Should -Contain $props
        $ci.trigger.paths.include | Should -Not -Contain $props
        $engCi = Get-Content (Join-Path $repo 'eng' 'scripts' 'ci.yml') -Raw | ConvertFrom-Yaml
        $engCi.pr.paths.include | Should -Contain "eng/packages/$Package/ci.yml"
        $ci.extends.parameters.TestMatrix.All.TestArguments | Should -Match '-UnitTests'
        $ci.extends.parameters.TestMatrix.All.TestArguments | Should -Match '-GenerationChecks'
    }

    It 'runs the management CI gate on the sparse PR checkout' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $source = Join-Path $fixture 'source'
        $checkout = Join-Path $fixture 'checkout'
        New-Item -ItemType Directory -Force $source | Out-Null
        $older = '1.0.0-alpha.20261116.3'
        $newer = '1.0.0-alpha.20261117.1'
        $files = @{
            'eng/packages/http-client-csharp/package.json' = '{"version":"1.0.0","dependencies":{"@typespec/http-client-csharp":"1.0.0-alpha.1"}}'
            'eng/packages/http-client-csharp-mgmt/package.json' = "{`"version`":`"1.0.0`",`"dependencies`":{`"@azure-typespec/http-client-csharp`":`"$newer`"}}"
            'eng/packages/http-client-csharp-provisioning/package.json' = '{"version":"1.0.0","dependencies":{"@azure-typespec/http-client-csharp-mgmt":"1.0.0-alpha.1"}}'
            'eng/azure-typespec-http-client-csharp-emitter-package.json' = "{`"dependencies`":{`"@azure-typespec/http-client-csharp`":`"$older`"}}"
            'eng/centralpackagemanagement/Directory.Generation.Packages.props' = "<Project><PropertyGroup><AzureGeneratorVersion>$newer</AzureGeneratorVersion></PropertyGroup></Project>"
        }
        foreach ($entry in $files.GetEnumerator()) {
            $path = Join-Path $source $entry.Key
            New-Item -ItemType Directory -Force (Split-Path $path) | Out-Null
            Set-Content -Path $path -Value $entry.Value -NoNewline
        }
        $dashboard = Join-Path $source 'doc' 'GeneratorVersions' 'Emitter_Version_Dashboard.ps1'
        New-Item -ItemType Directory -Force (Split-Path $dashboard) | Out-Null
        Copy-Item (Join-Path $repo 'doc' 'GeneratorVersions' 'Emitter_Version_Dashboard.ps1') $dashboard
        git init -b main $source 2>&1 | Out-Null
        git -C $source add -A
        git -C $source -c user.name=test -c user.email=test@example.com commit -m fixture 2>&1 | Out-Null
        git clone --no-checkout $source $checkout 2>&1 | Out-Null
        git -C $checkout sparse-checkout init --no-cone
        git -C $checkout sparse-checkout set --no-cone '/*' '!/*/' '/eng' '/.config'
        git -C $checkout checkout main 2>&1 | Out-Null
        Test-Path (Join-Path $checkout 'doc' 'GeneratorVersions' 'Emitter_Version_Dashboard.ps1') | Should -BeFalse

        $template = Get-Content $templatePath -Raw | ConvertFrom-Yaml
        $stageKey = '${{ if ne(length(parameters.TestMatrix), 0) }}'
        $conditionalStage = @($template.extends.parameters.stages | Where-Object { $_ -is [System.Collections.IDictionary] -and $_.Contains($stageKey) })[0][$stageKey][0]
        $includeKey = '${{ if eq(parameters.EmitterPackagePath, ''eng/packages/http-client-csharp-mgmt'') }}'
        $include = @($conditionalStage.jobs[0].steps | Where-Object { $_ -is [System.Collections.IDictionary] -and $_.Contains($includeKey) })[0][$includeKey][0]
        $stepKey = '${{ if eq(parameters.EmitterPackagePath, ''eng/packages/http-client-csharp-mgmt'') }}'
        $step = @($conditionalStage.jobs[0].steps | Where-Object { $_ -is [System.Collections.IDictionary] -and $_.Contains($stepKey) })[1][$stepKey][0]
        $step.displayName | Should -Be 'Validate approved management versions'
        $includeCommand = $include.pwsh + "`nexit `$LASTEXITCODE"
        $includeEncoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($includeCommand))
        $command = $step.pwsh.Replace('$(Build.SourcesDirectory)', $checkout) + "`nexit `$LASTEXITCODE"
        $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command))
        Push-Location $checkout
        try {
            & pwsh -NoLogo -NoProfile -EncodedCommand $includeEncoded 2>&1 | Out-Null
            $LASTEXITCODE | Should -Be 0
            Test-Path (Join-Path $checkout 'doc' 'GeneratorVersions' 'Emitter_Version_Dashboard.ps1') | Should -BeTrue
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Not -Be 0
            $output | Should -Match 'Management emitter dependency version'
            $output | Should -Match 'approved version'
            $descriptor = Join-Path $checkout 'eng' 'azure-typespec-http-client-csharp-emitter-package.json'
            (Get-Content $descriptor -Raw).Replace($older, $newer) | Set-Content -Path $descriptor -NoNewline
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Be 0
            $output | Should -Match 'do not exceed the approved'
        } finally { Pop-Location }
    }

    It 'marks approval validation as <Outcome> for branded npm <Mgmt> and NuGet <Nuget>' -ForEach @(
        @{ Outcome = 'passed'; Approved = '1.0.0-alpha.20261116.3'; Mgmt = '1.0.0-alpha.20261116.3'; Nuget = '1.0.0-alpha.20261116.3'; Blocked = $false },
        @{ Outcome = 'passed'; Approved = '1.0.0-alpha.20261116.3'; Mgmt = '1.0.0-alpha.20261024.1'; Nuget = '1.0.0-alpha.20261024.1'; Blocked = $false },
        @{ Outcome = 'blocked'; Approved = '1.0.0-alpha.20261116.3'; Mgmt = '1.0.0-alpha.20261117.1'; Nuget = '1.0.0-alpha.20261116.3'; Blocked = $true },
        @{ Outcome = 'blocked'; Approved = '1.0.0-alpha.20261116.3'; Mgmt = '1.0.0-alpha.20261116.3'; Nuget = '1.0.0-alpha.20261117.1'; Blocked = $true },
        @{ Outcome = 'blocked'; Approved = 'invalid'; Mgmt = '1.0.0-alpha.20261116.3'; Nuget = '1.0.0-alpha.20261116.3'; Blocked = $true },
        @{ Outcome = 'blocked'; Approved = ''; Mgmt = '1.0.0-alpha.20261116.3'; Nuget = '1.0.0-alpha.20261116.3'; Blocked = $true }
    ) {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $files = @{
            'eng/packages/http-client-csharp/package.json' = '{"version":"1.0.0","dependencies":{"@typespec/http-client-csharp":"1.0.0-alpha.1"}}'
            'eng/packages/http-client-csharp-mgmt/package.json' = "{`"version`":`"1.0.0`",`"dependencies`":{`"@azure-typespec/http-client-csharp`":`"$Mgmt`"}}"
            'eng/packages/http-client-csharp-provisioning/package.json' = '{"version":"1.0.0","dependencies":{"@azure-typespec/http-client-csharp-mgmt":"1.0.0-alpha.1"}}'
            'eng/azure-typespec-http-client-csharp-emitter-package.json' = "{`"dependencies`":{`"@azure-typespec/http-client-csharp`":`"$Approved`"}}"
            'eng/centralpackagemanagement/Directory.Generation.Packages.props' = "<Project><PropertyGroup><AzureGeneratorVersion>$Nuget</AzureGeneratorVersion></PropertyGroup></Project>"
        }
        foreach ($entry in $files.GetEnumerator()) {
            $path = Join-Path $fixture $entry.Key
            New-Item -ItemType Directory -Force (Split-Path $path) | Out-Null
            Set-Content -Path $path -Value $entry.Value -NoNewline
        }
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[1].steps)
        $step = $steps | Where-Object displayName -eq 'Validate approved management versions'
        $step | Should -Not -BeNullOrEmpty
        $command = $step.pwsh + "`nexit `$LASTEXITCODE"
        $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command))
        $previousScript = $env:MGMT_APPROVAL_SCRIPT
        $previousRoot = $env:MGMT_APPROVAL_REPO
        try {
            $env:MGMT_APPROVAL_SCRIPT = Join-Path $repo 'doc' 'GeneratorVersions' 'Emitter_Version_Dashboard.ps1'
            $env:MGMT_APPROVAL_REPO = $fixture
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Be 0
            if ($Blocked) { $output | Should -Match 'variable=MgmtDependencyFailed\]true' }
            else { $output | Should -Not -Match 'variable=MgmtDependencyFailed\]true' }
        } finally {
            $env:MGMT_APPROVAL_SCRIPT = $previousScript
            $env:MGMT_APPROVAL_REPO = $previousRoot
        }
    }

    It 'records a nonterminating regeneration error and prevents a normal PR' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $scripts = Join-Path $fixture 'eng' 'packages' 'http-client-csharp-mgmt' 'eng' 'scripts'
        New-Item -ItemType Directory -Force $scripts | Out-Null
        Set-Content -Path (Join-Path $scripts 'Generate.ps1') -Value "Write-Error 'injected generation failure'; `$global:LASTEXITCODE = 0"
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[1].steps)
        $command = ($steps | Where-Object displayName -eq 'Regenerate management test projects').pwsh
        $command = $command.Replace('$(Build.SourcesDirectory)', $fixture) + "`nexit `$LASTEXITCODE"
        $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command))
        $previousScript = $env:MGMT_GENERATE_SCRIPT
        try {
            $env:MGMT_GENERATE_SCRIPT = Join-Path $scripts 'Generate.ps1'
            $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
            $LASTEXITCODE | Should -Be 0
            $output | Should -Match 'variable=MgmtDependencyFailed\]true'
        } finally { $env:MGMT_GENERATE_SCRIPT = $previousScript }
    }

    It 'records an update failure while allowing the draft PR steps to run' {
        $fixture = Join-Path $TestDrive 'fake-repo'
        $script = Join-Path $fixture 'eng' 'scripts' 'mgmt-dependency' 'Update-MgmtGeneratorDependency.ps1'
        New-Item -ItemType Directory -Force (Split-Path $script) | Out-Null
        Set-Content -Path $script -Value "Write-Host '##vso[task.setvariable variable=MgmtDependencyUpdateNeeded]true'; exit 1"
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[1].steps)
        $command = ($steps | Where-Object displayName -eq 'Update management dependencies').pwsh
        $command = $command.Replace('$(Build.SourcesDirectory)', $fixture).Replace('$(Pipeline.Workspace)', $TestDrive).Replace('$(emitterVersion)', '1.0.0-alpha.20261117.1')
        # PowerShell@2 propagates LASTEXITCODE after a script unless it is reset.
        $command += "`nexit `$LASTEXITCODE"
        $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command))
        $output = & pwsh -NoLogo -NoProfile -EncodedCommand $encoded 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output | Should -Match 'variable=MgmtDependencyUpdateNeeded\]true'
        $output | Should -Match 'variable=MgmtDependencyFailed\]true'
    }
}
