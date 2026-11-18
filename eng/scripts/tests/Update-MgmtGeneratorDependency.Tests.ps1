#Requires -Version 7.0
# Run with: Invoke-Pester eng/scripts/tests/Update-MgmtGeneratorDependency.Tests.ps1

. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'Helpers' 'PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'Pester' '5.3.3' | Import-Module

BeforeAll {
    $scriptPath = Join-Path $PSScriptRoot '..' 'typespec' 'Update-MgmtGeneratorDependency.ps1'
    $pushScript = Join-Path $PSScriptRoot '..' 'typespec' 'Push-MgmtDependencyBranch.ps1'
    # Windows resolves npm to npm.ps1; Pester otherwise mocks that script under
    # its suffixed name and the updater's extensionless npm call bypasses it.
    function npm { throw 'Unexpected real npm call in a mocked test.' }
}

Describe 'Management generator dependency update' -Tag 'UnitTest' {
    BeforeEach {
        $repo = Join-Path $TestDrive 'repo'
        $mgmt = Join-Path $repo 'eng' 'packages' 'http-client-csharp-mgmt'
        $props = Join-Path $repo 'eng' 'centralpackagemanagement' 'Directory.Generation.Packages.props'
        New-Item -ItemType Directory -Force $mgmt, (Split-Path $props) | Out-Null
        Set-Content -Path $props -Value '<Project><PropertyGroup><AzureGeneratorVersion>1.0.0-alpha.20261023.4</AzureGeneratorVersion></PropertyGroup></Project>' -NoNewline
        Set-Content -Path (Join-Path $mgmt 'package.json') -Value '{"dependencies":{"@azure-typespec/http-client-csharp":"1.0.0-alpha.20261023.4","@typespec/http-client-csharp":"1.0.0-alpha.20261023.3"}}' -NoNewline
        $published = Join-Path $TestDrive 'published-package.json'
        Set-Content -Path $published -Value '{"name":"@azure-typespec/http-client-csharp","version":"1.0.0-alpha.20261117.1","dependencies":{"@typespec/http-client-csharp":"1.0.0-alpha.20261116.2"}}' -NoNewline
        Mock npm { $global:LASTEXITCODE = 0 }
    }

    It 'updates both generator versions and the matching unbranded emitter' {
        & $scriptPath -RepoRoot $repo -PublishedPackageJson $published -Version '1.0.0-alpha.20261117.1'
        (Get-Content $props -Raw) | Should -Match '<AzureGeneratorVersion>1\.0\.0-alpha\.20261117\.1</AzureGeneratorVersion>'
        Should -Invoke npm -Times 1 -Exactly -ParameterFilter {
            $args -contains 'dependencies.@azure-typespec/http-client-csharp=1.0.0-alpha.20261117.1' -and
            $args -contains 'dependencies.@typespec/http-client-csharp=1.0.0-alpha.20261116.2'
        }
        Should -Invoke npm -Times 1 -Exactly -ParameterFilter { $args -contains 'install' }
    }

    It 'updates the actual package manifest using npm pkg set' {
        $npmExecutable = (Get-Command npm -CommandType Application | Select-Object -First 1).Source
        Mock npm {
            if ($args -contains 'install') { $global:LASTEXITCODE = 0 }
            else { & $npmExecutable @args; $global:LASTEXITCODE = $LASTEXITCODE }
        }
        & $scriptPath -RepoRoot $repo -PublishedPackageJson $published -Version '1.0.0-alpha.20261117.1'
        $manifest = Get-Content (Join-Path $mgmt 'package.json') -Raw | ConvertFrom-Json -AsHashtable
        $manifest.dependencies['@azure-typespec/http-client-csharp'] | Should -BeExactly '1.0.0-alpha.20261117.1'
        $manifest.dependencies['@typespec/http-client-csharp'] | Should -BeExactly '1.0.0-alpha.20261116.2'
    }

    It 'can align only the central pin when the management npm pins are already current' {
        $manifestPath = Join-Path $mgmt 'package.json'
        $manifest = (Get-Content $manifestPath -Raw).Replace('20261023.4', '20261117.1').Replace('20261023.3', '20261116.2')
        Set-Content -Path $manifestPath -Value $manifest -NoNewline
        & $scriptPath -RepoRoot $repo -PublishedPackageJson $published -Version '1.0.0-alpha.20261117.1'
        (Get-Content $manifestPath -Raw) | Should -BeExactly $manifest
        (Get-Content $props -Raw) | Should -Match '<AzureGeneratorVersion>1\.0\.0-alpha\.20261117\.1</AzureGeneratorVersion>'
    }

    It 'does not downgrade when a newer branded generator is already on main' {
        $before = Get-Content $props -Raw
        (Get-Content $published -Raw).Replace('20261117.1', '20261001.1') | Set-Content -Path $published -NoNewline
        & $scriptPath -RepoRoot $repo -PublishedPackageJson $published -Version '1.0.0-alpha.20261001.1'
        (Get-Content $props -Raw) | Should -BeExactly $before
        Should -Invoke npm -Times 0 -Exactly
    }

    It 'skips a release that is already installed' {
        $current = (Get-Content $published -Raw).Replace('20261117.1', '20261023.4').Replace('20261116.2', '20261023.3')
        Set-Content -Path $published -Value $current -NoNewline
        & $scriptPath -RepoRoot $repo -PublishedPackageJson $published -Version '1.0.0-alpha.20261023.4'
        Should -Invoke npm -Times 0 -Exactly
    }

    It 'does not downgrade a newer management package pin even if the central pin is older' {
        $manifestPath = Join-Path $mgmt 'package.json'
        (Get-Content $manifestPath -Raw).Replace('20261023.4', '20261118.1') | Set-Content -Path $manifestPath -NoNewline
        $before = Get-Content $props -Raw
        & $scriptPath -RepoRoot $repo -PublishedPackageJson $published -Version '1.0.0-alpha.20261117.1'
        (Get-Content $props -Raw) | Should -BeExactly $before
        Should -Invoke npm -Times 0 -Exactly
    }

    It 'rejects an unbranded dependency range instead of an exact version' {
        (Get-Content $published -Raw).Replace('20261116.2', '20261116.2 || ^2.0.0') | Set-Content -Path $published -NoNewline
        { & $scriptPath -RepoRoot $repo -PublishedPackageJson $published -Version '1.0.0-alpha.20261117.1' } | Should -Throw '*exact*'
        Should -Invoke npm -Times 0 -Exactly
    }

    It 'rejects a package artifact whose version does not match the published build' {
        { & $scriptPath -RepoRoot $repo -PublishedPackageJson $published -Version '1.0.0-alpha.20261117.2' } | Should -Throw '*does not match*'
        Should -Invoke npm -Times 0 -Exactly
    }

    It 'fails if npm install fails' {
        Mock npm { if ($args -contains 'install') { $global:LASTEXITCODE = 1 } else { $global:LASTEXITCODE = 0 } }
        { & $scriptPath -RepoRoot $repo -PublishedPackageJson $published -Version '1.0.0-alpha.20261117.1' } | Should -Throw '*npm install*'
    }
}

Describe 'Management dependency branch creation' -Tag 'UnitTest' {
    BeforeEach {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $remote = Join-Path $fixture 'remote.git'
        $work = Join-Path $fixture 'work'
        New-Item -ItemType Directory -Force $fixture | Out-Null
        git init --bare $remote 2>&1 | Out-Null
        git init -b main $work 2>&1 | Out-Null
        Push-Location $work
        git config user.name test
        git config user.email test@example.com
        Set-Content -Path 'file.txt' -Value 'base'
        git add file.txt
        git commit -m 'Update management generator branded dependency to 1.0.0-alpha.20261117.1' 2>&1 | Out-Null
        git remote add origin $remote
        git push origin main 2>&1 | Out-Null
    }
    AfterEach { Pop-Location }

    It 'creates a new branch with staged updates and new generated files' {
        Set-Content -Path 'file.txt' -Value 'update'
        Set-Content -Path 'generated.txt' -Value 'generated'
        git add file.txt generated.txt
        $output = & $pushScript -RepoRoot $work -Branch 'typespec/update-mgmt-branded-123' -Version '1.0.0-alpha.20261117.1' -GitUrl $remote -Failed:$false *>&1 | Out-String
        $output | Should -Match 'variable=HasChanges\]true'
        (git --git-dir $remote show refs/heads/typespec/update-mgmt-branded-123:file.txt) | Should -BeExactly 'update'
        (git --git-dir $remote show refs/heads/typespec/update-mgmt-branded-123:generated.txt) | Should -BeExactly 'generated'
    }

    It 'atomically preserves and reuses a branch created between preflight and push' {
        git push origin HEAD:refs/heads/typespec/update-mgmt-branded-123 2>&1 | Out-Null
        $before = git --git-dir $remote rev-parse refs/heads/typespec/update-mgmt-branded-123
        Set-Content -Path 'file.txt' -Value 'competing update'
        Set-Content -Path 'generated.txt' -Value 'generated'
        git add file.txt generated.txt
        $output = & $pushScript -RepoRoot $work -Branch 'typespec/update-mgmt-branded-123' -Version '1.0.0-alpha.20261117.1' -GitUrl $remote -Failed:$false *>&1 | Out-String
        $output | Should -Match 'variable=ReuseExistingDependencyPR\]true'
        (git --git-dir $remote rev-parse refs/heads/typespec/update-mgmt-branded-123) | Should -BeExactly $before
        (git status --porcelain) | Should -BeNullOrEmpty
    }

    It 'uses the competing branch failure status, not the local attempt status' {
        git commit --amend -m 'Failed: Update management generator branded dependency to 1.0.0-alpha.20261117.1' 2>&1 | Out-Null
        git push origin HEAD:refs/heads/typespec/update-mgmt-branded-123 2>&1 | Out-Null
        Set-Content -Path 'file.txt' -Value 'competing update'
        git add file.txt
        $output = & $pushScript -RepoRoot $work -Branch 'typespec/update-mgmt-branded-123' -Version '1.0.0-alpha.20261117.1' -GitUrl $remote -Failed:$false *>&1 | Out-String
        $output | Should -Match 'variable=MgmtDependencyFailed\]true'
    }

    It 'refuses a competing branch with an unexpected head' {
        git commit --amend -m 'Manual work' 2>&1 | Out-Null
        git push origin HEAD:refs/heads/typespec/update-mgmt-branded-123 2>&1 | Out-Null
        $before = git --git-dir $remote rev-parse refs/heads/typespec/update-mgmt-branded-123
        Set-Content -Path 'file.txt' -Value 'competing update'
        git add file.txt
        { & $pushScript -RepoRoot $work -Branch 'typespec/update-mgmt-branded-123' -Version '1.0.0-alpha.20261117.1' -GitUrl $remote -Failed:$false *>&1 } | Should -Throw '*unexpected head*'
        (git --git-dir $remote rev-parse refs/heads/typespec/update-mgmt-branded-123) | Should -BeExactly $before
    }
}
