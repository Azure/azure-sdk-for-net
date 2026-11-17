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
    It 'opts in only the branded emitter and only for public publishing' {
        $branded = Get-Content $brandedPath -Raw
        $template = Get-Content $templatePath -Raw
        $branded | Should -Match 'UpdateMgmtGeneratorDependency: true'
        $engCi = Get-Content (Join-Path $repo 'eng' 'scripts' 'ci.yml') -Raw | ConvertFrom-Yaml
        $engCi.trigger.paths.include | Should -Contain 'eng/pipelines/templates/stages/update-mgmt-generator-dependency.yml'
        $engCi.pr.paths.include | Should -Contain 'eng/pipelines/templates/stages/update-mgmt-generator-dependency.yml'
        $template | Should -Match 'and\(parameters\.UpdateMgmtGeneratorDependency, parameters\.ShouldPublish, parameters\.PublishPublic\)'
        $template | Should -Match 'variable=publicNpmPublished;isOutput=true'
        $template.IndexOf('name: markPublicNpm') | Should -BeGreaterThan $template.IndexOf('task: EsrpRelease@11')
        $template.IndexOf('if parameters.UploadPlaygroundBundle') | Should -BeGreaterThan $template.IndexOf('name: markPublicNpm')
    }

    It 'waits for build and publish and restricts updates to main' {
        $pipeline = Get-Content $pipelinePath -Raw | ConvertFrom-Yaml
        $stage = $pipeline.stages[0]
        $stage.dependsOn | Should -Contain 'Build'
        $stage.dependsOn | Should -Contain 'Publish'
        $stage.condition | Should -Match "refs/heads/main"
        $stage.condition | Should -Match "Publish.Publish.markPublicNpm.publicNpmPublished"
        $stage.condition | Should -Match 'not\(canceled\(\)\)'
    }

    It 'marks npm-only releases as drafts and refreshes the GitHub token after regeneration' {
        $pipeline = Get-Content $pipelinePath -Raw
        $pipeline | Should -Match 'not\(parameters\.HasNugetPackages\)'
        $pipeline | Should -Match 'Matching NuGet package was not published'
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

    It 'runs updater tests in branded CI and makes failed tests fail eng scripts CI' {
        $template = Get-Content $templatePath -Raw
        $template | Should -Match 'Update-MgmtGeneratorDependency.Tests.ps1'
        $template | Should -Match 'Mgmt-Dependency-Pipeline.Tests.ps1'
        $engCi = Get-Content (Join-Path $repo 'eng' 'scripts' 'ci.yml') -Raw
        $engCi | Should -Match 'CustomTestSteps'
        $engCi | Should -Match 'FailedContainersCount'
    }

    It 'regenerates all management test projects and opens a draft on failure' {
        $pipeline = Get-Content $pipelinePath -Raw
        $pipeline | Should -Match 'http-client-csharp-mgmt/eng/scripts/Generate\.ps1'
        $pipeline | Should -Not -Match '(?i)-filter\b'
        $pipeline | Should -Match 'MgmtDependencyFailed'
        $pipeline | Should -Match '-(?:OpenAsDraft|Draft) \$failed'
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[0].steps)
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
            $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[0].steps)
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
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[0].steps)
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
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[0].steps)
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
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[0].steps)
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

    It 'records a nonterminating regeneration error and prevents a normal PR' {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $scripts = Join-Path $fixture 'eng' 'packages' 'http-client-csharp-mgmt' 'eng' 'scripts'
        New-Item -ItemType Directory -Force $scripts | Out-Null
        Set-Content -Path (Join-Path $scripts 'Generate.ps1') -Value "Write-Error 'injected generation failure'; `$global:LASTEXITCODE = 0"
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[0].steps)
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
        $script = Join-Path $fixture 'eng' 'scripts' 'typespec' 'Update-MgmtGeneratorDependency.ps1'
        New-Item -ItemType Directory -Force (Split-Path $script) | Out-Null
        Set-Content -Path $script -Value "Write-Host '##vso[task.setvariable variable=MgmtDependencyUpdateNeeded]true'; exit 1"
        $steps = @((Get-Content $pipelinePath -Raw | ConvertFrom-Yaml).stages[0].jobs[0].steps)
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
