#Requires -Version 7.0
<# Run with: Invoke-Pester eng/scripts/tests/Prepare-RegenerationHistory.Tests.ps1 #>

. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'Helpers' 'PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'powershell-yaml' '0.4.1' | Import-Module

BeforeAll {
    $prepareScript = Join-Path $PSScriptRoot '..' 'Prepare-RegenerationHistory.ps1'

    function Get-TestFileUri {
        param([string] $Path)
        return ([System.Uri]::new([System.IO.Path]::GetFullPath($Path))).AbsoluteUri
    }

    function Find-PipelineNode {
        param($Node, [string] $Property, [string] $Value)
        if ($Node -is [System.Collections.IDictionary]) {
            if ($Node[$Property] -eq $Value) { $Node }
            foreach ($child in $Node.Values) { Find-PipelineNode $child $Property $Value }
        } elseif ($Node -is [System.Collections.IEnumerable] -and $Node -isnot [string]) {
            foreach ($child in $Node) { Find-PipelineNode $child $Property $Value }
        }
    }

    function Invoke-TestGit {
        param([string] $Directory, [string[]] $GitArgs)
        $output = & git -C $Directory @GitArgs 2>&1
        if ($LASTEXITCODE -ne 0) {
            throw "git $($GitArgs -join ' ') failed: $($output -join "`n")"
        }
        return ($output -join "`n").Trim()
    }

    function New-RegenerationFixture {
        param([string] $Directory)
        $seed = Join-Path $Directory 'seed'
        $remote = Join-Path $Directory 'remote.git'
        $client = Join-Path $Directory 'client'
        New-Item -ItemType Directory -Path $seed, $client -Force | Out-Null
        Invoke-TestGit $seed @('init', '-q', '-b', 'main') | Out-Null
        Invoke-TestGit $seed @('config', 'user.name', 'Test') | Out-Null
        Invoke-TestGit $seed @('config', 'user.email', 'test@example.invalid') | Out-Null
        $bytes = [byte[]]::new(1MB)
        [System.Security.Cryptography.RandomNumberGenerator]::Fill($bytes)
        [System.IO.File]::WriteAllBytes((Join-Path $seed 'large.bin'), $bytes)
        Set-Content -Path (Join-Path $seed 'change.txt') -Value 'base'
        Invoke-TestGit $seed @('add', '.') | Out-Null
        Invoke-TestGit $seed @('commit', '-q', '-m', 'base') | Out-Null
        $base = Invoke-TestGit $seed @('rev-parse', 'HEAD')
        Invoke-TestGit $seed @('clone', '--bare', '--quiet', $seed, $remote) | Out-Null
        Invoke-TestGit $client @('init', '-q') | Out-Null
        Invoke-TestGit $client @('config', 'user.name', 'Test') | Out-Null
        Invoke-TestGit $client @('config', 'user.email', 'test@example.invalid') | Out-Null
        Invoke-TestGit $client @('remote', 'add', 'origin', (Get-TestFileUri $remote)) | Out-Null
        Invoke-TestGit $client @('fetch', '--quiet', '--depth=1', 'origin', "+${base}:refs/remotes/origin/base") | Out-Null
        Invoke-TestGit $client @('checkout', '--quiet', '--detach', $base) | Out-Null
        Set-Content -Path (Join-Path $client 'change.txt') -Value 'simulated regeneration'
        Invoke-TestGit $client @('add', 'change.txt') | Out-Null
        Invoke-TestGit $client @('commit', '-q', '-m', 'generated changes') | Out-Null
        Set-Content -Path (Join-Path $seed 'advance.txt') -Value 'advanced main'
        Invoke-TestGit $seed @('add', 'advance.txt') | Out-Null
        Invoke-TestGit $seed @('commit', '-q', '-m', 'advance main') | Out-Null
        Invoke-TestGit $seed @('push', '--quiet', (Get-TestFileUri $remote), 'HEAD:refs/heads/main') | Out-Null
        $tip = Invoke-TestGit $seed @('rev-parse', 'HEAD')
        return @{ Client = $client; Remote = $remote; Base = $base; Tip = $tip }
    }

    function New-TestReceiver {
        param([string] $Remote, [string] $Directory)
        Invoke-TestGit (Split-Path $Directory -Parent) @('clone', '--bare', '--shared', '--quiet', $Remote, $Directory) | Out-Null
        Invoke-TestGit $Directory @('config', 'receive.unpackLimit', '1') | Out-Null
    }
}

Describe 'Prepare regeneration history' -Tag 'UnitTest' {
    It 'is opt-in and runs before both management regeneration pushes' {
        $template = Get-Content (Join-Path $PSScriptRoot '..' '..' 'pipelines' 'templates' 'archetype-typespec-emitter.yml') -Raw | ConvertFrom-Yaml
        $management = Get-Content (Join-Path $PSScriptRoot '..' '..' 'packages' 'http-client-csharp-mgmt' 'ci.yml') -Raw | ConvertFrom-Yaml
        $scriptsCi = Get-Content (Join-Path $PSScriptRoot '..' 'ci.yml') -Raw | ConvertFrom-Yaml
        foreach ($trigger in @($scriptsCi.trigger, $scriptsCi.pr)) {
            $trigger.paths.include | Should -Contain 'eng/scripts/*'
            $trigger.paths.include | Should -Contain 'eng/packages/http-client-csharp-mgmt/ci.yml'
            $trigger.paths.include | Should -Contain 'eng/pipelines/templates/archetype-typespec-emitter.yml'
        }
        $parameter = @($template.parameters | Where-Object name -eq 'RegenerationHistoryDepth')
        $parameter.Count | Should -Be 1
        $parameter[0].default | Should -Be 0
        $management.extends.parameters.RegenerationHistoryDepth | Should -Be 50
        $management.trigger.paths.include | Should -Contain 'eng/scripts/Prepare-RegenerationHistory.ps1'
        $management.pr.paths.include | Should -Contain 'eng/scripts/Prepare-RegenerationHistory.ps1'
        foreach ($name in @('Initialize', 'Generate')) {
            $job = @(Find-PipelineNode $template 'job' $name)
            $job.Count | Should -Be 1
            $steps = @($job[0].steps)
            $prepareIndex = -1
            $pushIndex = -1
            for ($i = 0; $i -lt $steps.Count; $i++) {
                if (@(Find-PipelineNode $steps[$i] 'displayName' 'Prepare regeneration push history').Count -eq 1) { $prepareIndex = $i }
                if ($steps[$i].template -eq '/eng/common/pipelines/templates/steps/git-push-changes.yml') { $pushIndex = $i }
            }
            $prepareIndex | Should -BeGreaterOrEqual 0
            $pushIndex | Should -BeGreaterThan $prepareIndex
            @($steps[$prepareIndex].Keys) | Should -Contain '${{ if gt(parameters.RegenerationHistoryDepth, 0) }}'
            $conditionalSteps = @($steps[$prepareIndex].Values)[0]
            $conditionalSteps.Count | Should -Be 2
            $conditionalSteps[0].displayName | Should -Be 'Check for regeneration push changes'
            $conditionalSteps[0].inputs.filePath | Should -Be './eng/common/scripts/check-for-git-changes.ps1'
            $conditionalSteps[1].displayName | Should -Be 'Prepare regeneration push history'
            $prepare = $conditionalSteps[1]
            $prepare.condition | Should -Be "and(succeeded(), eq(variables['HasChanges'], 'true'))"
            $prepare.inputs.filePath | Should -Be './eng/scripts/Prepare-RegenerationHistory.ps1'
            $prepare.inputs.arguments | Should -Be '-Depth ${{ parameters.RegenerationHistoryDepth }} -SourceVersion "$(Build.SourceVersion)"'
        }
    }

    It 'reduces the push pack when main advanced without changing HEAD or local changes' {
        $fixture = New-RegenerationFixture (Join-Path $TestDrive 'regression')
        $baseline = Join-Path $TestDrive 'baseline.git'
        $candidate = Join-Path $TestDrive 'candidate.git'
        New-TestReceiver $fixture.Remote $baseline
        New-TestReceiver $fixture.Remote $candidate
        Invoke-TestGit $fixture.Client @('push', '--quiet', (Get-TestFileUri $baseline), 'HEAD:refs/heads/probe') | Out-Null
        $baselinePack = (Get-ChildItem (Join-Path $baseline 'objects/pack/*.pack') | Measure-Object Length -Sum).Sum
        $baselinePack | Should -BeGreaterThan 500000

        Set-Content -Path (Join-Path $fixture.Client 'staged.txt') -Value 'staged'
        Invoke-TestGit $fixture.Client @('add', 'staged.txt') | Out-Null
        Set-Content -Path (Join-Path $fixture.Client 'unstaged.txt') -Value 'untracked'
        $beforeHead = Invoke-TestGit $fixture.Client @('rev-parse', 'HEAD')
        $beforeStatus = Invoke-TestGit $fixture.Client @('status', '--porcelain')
        Push-Location $fixture.Client
        try {
            & pwsh -NoLogo -NoProfile -File $prepareScript -Depth 50 -SourceVersion $fixture.Base
            $LASTEXITCODE | Should -Be 0
        } finally { Pop-Location }
        (Invoke-TestGit $fixture.Client @('rev-parse', 'HEAD')) | Should -Be $beforeHead
        (Invoke-TestGit $fixture.Client @('status', '--porcelain')) | Should -Be $beforeStatus
        (Invoke-TestGit $fixture.Client @('rev-parse', 'refs/remotes/origin/regeneration-main')) | Should -Be $fixture.Tip
        & git -C $fixture.Client show-ref --verify --quiet refs/remotes/origin/regeneration-source
        $LASTEXITCODE | Should -Be 1
        Invoke-TestGit $fixture.Client @('merge-base', '--is-ancestor', $fixture.Base, $fixture.Tip) | Out-Null
        Invoke-TestGit $fixture.Client @('push', '--quiet', (Get-TestFileUri $candidate), 'HEAD:refs/heads/probe') | Out-Null
        $candidatePack = (Get-ChildItem (Join-Path $candidate 'objects/pack/*.pack') | Measure-Object Length -Sum).Sum
        $candidatePack | Should -BeLessThan 50000
    }

    It 'deepens a shallow PR merge commit before pushing' {
        $fixture = New-RegenerationFixture (Join-Path $TestDrive 'pr-merge')
        $seed = Join-Path $TestDrive 'pr-merge/seed'
        Invoke-TestGit $seed @('checkout', '--quiet', '-b', 'pr', $fixture.Base) | Out-Null
        Set-Content -Path (Join-Path $seed 'pr.txt') -Value 'PR change'
        Invoke-TestGit $seed @('add', 'pr.txt') | Out-Null
        Invoke-TestGit $seed @('commit', '-q', '-m', 'PR change') | Out-Null
        Invoke-TestGit $seed @('push', '--quiet', (Get-TestFileUri $fixture.Remote), 'HEAD:refs/heads/pr') | Out-Null
        Invoke-TestGit $seed @('checkout', '--quiet', 'main') | Out-Null
        Invoke-TestGit $seed @('merge', '--quiet', '--no-ff', 'pr', '-m', 'synthetic merge') | Out-Null
        $merge = Invoke-TestGit $seed @('rev-parse', 'HEAD')
        # GitHub already has the synthetic merge object, but does not advertise it as a branch.
        Invoke-TestGit $seed @('push', '--quiet', (Get-TestFileUri $fixture.Remote), 'HEAD:refs/heads/temporary-merge') | Out-Null
        Invoke-TestGit $fixture.Remote @('update-ref', '-d', 'refs/heads/temporary-merge') | Out-Null
        Invoke-TestGit $fixture.Remote @('config', 'uploadpack.allowAnySHA1InWant', 'true') | Out-Null
        $client = Join-Path $TestDrive 'pr-client'
        New-Item -ItemType Directory -Path $client | Out-Null
        Invoke-TestGit $client @('init', '-q') | Out-Null
        Invoke-TestGit $client @('config', 'user.name', 'Test') | Out-Null
        Invoke-TestGit $client @('config', 'user.email', 'test@example.invalid') | Out-Null
        Invoke-TestGit $client @('remote', 'add', 'origin', (Get-TestFileUri $fixture.Remote)) | Out-Null
        Invoke-TestGit $client @('fetch', '--quiet', '--depth=1', 'origin', "+${merge}:refs/remotes/origin/base") | Out-Null
        Invoke-TestGit $client @('checkout', '--quiet', '--detach', $merge) | Out-Null
        Set-Content -Path (Join-Path $client 'generated.txt') -Value 'generated'
        Invoke-TestGit $client @('add', 'generated.txt') | Out-Null
        Invoke-TestGit $client @('commit', '-q', '-m', 'generated') | Out-Null
        Invoke-TestGit $client @('fetch', '--quiet', '--no-tags', '--depth=50', 'origin', '+refs/heads/main:refs/remotes/origin/regeneration-main') | Out-Null
        $baselineOutput = & git -C $client push --quiet origin HEAD:refs/heads/baseline 2>&1
        $LASTEXITCODE | Should -Not -Be 0
        ($baselineOutput -join "`n") | Should -Match 'shallow update not allowed'
        Push-Location $client
        try {
            & pwsh -NoLogo -NoProfile -File $prepareScript -Depth 50 -SourceVersion $merge
            $LASTEXITCODE | Should -Be 0
        } finally { Pop-Location }
        $shallowFile = Join-Path $client '.git/shallow'
        if (Test-Path $shallowFile) {
            @(Get-Content $shallowFile) | Should -Not -Contain $merge
        }
        Invoke-TestGit $client @('push', '--quiet', 'origin', 'HEAD:refs/heads/generated') | Out-Null
    }

    It 'fails if the shallow source commit cannot be fetched' {
        $fixture = New-RegenerationFixture (Join-Path $TestDrive 'missing-source')
        $source = Invoke-TestGit $fixture.Client @('rev-parse', 'HEAD')
        Add-Content -Path (Join-Path $fixture.Client '.git/shallow') -Value $source
        Push-Location $fixture.Client
        try {
            & pwsh -NoLogo -NoProfile -File $prepareScript -Depth 50 -SourceVersion $source 2>&1 | Out-Null
            $LASTEXITCODE | Should -Not -Be 0
        } finally { Pop-Location }
    }

    It 'fails if the remote main ref cannot be fetched' {
        Test-Path $prepareScript | Should -BeTrue
        $fixture = New-RegenerationFixture (Join-Path $TestDrive 'fetch-failure')
        Invoke-TestGit $fixture.Client @('remote', 'set-url', 'origin', (Get-TestFileUri (Join-Path $TestDrive 'missing.git'))) | Out-Null
        Push-Location $fixture.Client
        try {
            & pwsh -NoLogo -NoProfile -File $prepareScript -Depth 50 -SourceVersion $fixture.Base 2>&1 | Out-Null
            $LASTEXITCODE | Should -Not -Be 0
        } finally { Pop-Location }
    }
}
