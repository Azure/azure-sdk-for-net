#Requires -Version 7.0

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe 'Changelog generator failure detection' {
    BeforeAll {
        $generator = Join-Path $PSScriptRoot '../Gen-Mgmt-Changelog.ps1'
        function dotnet { $global:LASTEXITCODE = 0 }
        function changelog-gen-mgmt { $global:LASTEXITCODE = 0 }
    }

    BeforeEach {
        $listing = Join-Path $TestDrive 'api.cs'
        'API' | Set-Content $listing
    }

    It 'rejects a swallowed generator exception even when the tool returns zero' {
        Mock changelog-gen-mgmt { $global:LASTEXITCODE = 0; 'Error occurs when generating changelog:'; "Can't find Tag" }
        { & $generator -ServiceName test -ReleaseVersion 1.0.0 -ReleaseDate 2026-10-29 -ApiFilePath $listing } |
            Should -Throw '*Management changelog generation failed*'
    }

    It 'rejects a failed installation' {
        Mock dotnet { $global:LASTEXITCODE = 1 }
        { & $generator -ServiceName test -ReleaseVersion 1.0.0 -ReleaseDate 2026-10-29 -ApiFilePath $listing } |
            Should -Throw '*Failed to install*'
    }

    It 'accepts successful generator output' {
        Mock changelog-gen-mgmt { $global:LASTEXITCODE = 0; 'Changelog generated.' }
        { & $generator -ServiceName test -ReleaseVersion 1.0.0 -ReleaseDate 2026-10-29 -ApiFilePath $listing } |
            Should -Not -Throw
    }

    It 'fetches release tags in the changelog CI job' {
        Get-Content (Join-Path $PSScriptRoot '../../pipelines/templates/stages/archetype-sdk-client.yml') -Raw |
            Should -Match 'fetchTags: true'
    }
}

Describe 'Legacy automation changelog integration is removed' {
    BeforeAll {
        $scriptContent = Get-Content (Join-Path $PSScriptRoot "../Invoke-GenerateAndBuildV2.ps1") -Raw
        $config = Get-Content (Join-Path $PSScriptRoot '../../swagger_to_sdk_config.json') -Raw | ConvertFrom-Json
    }

    It 'does not dispatch changelog updates from the generator' {
        $scriptContent | Should -Not -Match 'Update-MgmtPackageChangelog'
        $scriptContent | Should -Not -Match 'Update-MgmtChangelog\.ps1'
    }

    It 'does not configure the obsolete <Hook> package hook' -TestCases @(
        @{ Hook = 'updateChangelogContentScript' }
        @{ Hook = 'changelogScript' }
    ) {
        param($Hook)
        $config.packageOptions.PSObject.Properties.Name | Should -Not -Contain $Hook
    }
}

Describe 'Update-MgmtChangelog single-package wrapper' {
    BeforeAll {
        $pwshExecutable = (Get-Command pwsh -CommandType Application | Select-Object -First 1).Source
        $wrapperSource = Join-Path $PSScriptRoot '../Update-MgmtChangelog.ps1'
    }

    BeforeEach {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $repo = Join-Path $root 'repo'
        $package = Join-Path $repo 'sdk/test/Azure.ResourceManager.Test'
        $scripts = Join-Path $root 'scripts'
        New-Item -ItemType Directory -Path "$package/src", "$package/api", $scripts -Force | Out-Null
        $projectFile = Join-Path $package 'src/Azure.ResourceManager.Test.csproj'
        '<Project><PropertyGroup><PackageId>Azure.ResourceManager.Test</PackageId><Version>1.2.3-beta.4</Version></PropertyGroup></Project>' |
            Set-Content $projectFile
        $apiFile = Join-Path $package 'api/Azure.ResourceManager.Test.netstandard2.0.cs'
        'exact API listing' | Set-Content $apiFile
        $wrapper = Join-Path $scripts 'Update-MgmtChangelog.ps1'
        Copy-Item $wrapperSource $wrapper
        # Only this stub is executed: never invoke the real changelog tool or network.
        @'
param($ServiceName, $ReleaseVersion, $ReleaseDate, $ApiFilePath)
@{ ServiceName = $ServiceName; ReleaseVersion = $ReleaseVersion; ReleaseDate = $ReleaseDate; ApiFilePath = $ApiFilePath } |
    ConvertTo-Json | Set-Content (Join-Path $PSScriptRoot 'invocation.json')
'@ | Set-Content (Join-Path $scripts 'Gen-Mgmt-Changelog.ps1')
        $PSNativeCommandUseErrorActionPreference = $false
    }

    It 'passes the exact project version, service, UTC date, and API listing to the generator' {
        & $pwshExecutable -NoProfile -File $wrapper -PackagePath $package -SdkRepoPath $repo

        $LASTEXITCODE | Should -Be 0
        $invocation = Get-Content (Join-Path $scripts 'invocation.json') -Raw | ConvertFrom-Json
        $invocation.ServiceName | Should -Be 'test'
        $invocation.ReleaseVersion | Should -Be '1.2.3-beta.4'
        $invocation.ReleaseDate | Should -Be ([DateTime]::UtcNow.ToString('yyyy-MM-dd'))
        $invocation.ApiFilePath | Should -Be $apiFile
    }

    It 'uses the project filename when PackageId is absent' {
        '<Project><PropertyGroup><Version>1.2.3</Version></PropertyGroup></Project>' | Set-Content $projectFile

        & $pwshExecutable -NoProfile -File $wrapper -PackagePath $package -SdkRepoPath $repo

        $LASTEXITCODE | Should -Be 0
        (Get-Content (Join-Path $scripts 'invocation.json') -Raw | ConvertFrom-Json).ApiFilePath | Should -Be $apiFile
    }

    It 'rejects invalid single-package input: <Case>' -TestCases @(
        @{ Case = 'missing version'; Expected = 'No package version' }
        @{ Case = 'missing exact API'; Expected = 'API listing' }
        @{ Case = 'multiple projects'; Expected = 'Expected one project' }
        @{ Case = 'non-management package'; Expected = 'not an Azure Resource Manager package' }
        @{ Case = 'outside repository'; Expected = 'not under SDK repository' }
        @{ Case = 'missing package'; Expected = 'Cannot validate argument' }
        @{ Case = 'mixed parameter sets'; Expected = 'Parameter set cannot be resolved' }
    ) {
        param($Case, $Expected)
        $extraArguments = @()
        switch ($Case) {
            'missing version' { '<Project><PropertyGroup /></Project>' | Set-Content $projectFile }
            'missing exact API' {
                Remove-Item $apiFile
                'different target framework' | Set-Content (Join-Path $package 'api/Azure.ResourceManager.Test.net8.0.cs')
            }
            'multiple projects' { Copy-Item $projectFile (Join-Path $package 'src/Other.csproj') }
            'non-management package' {
                '<Project><PropertyGroup><PackageId>Azure.Core</PackageId><Version>1.0.0</Version></PropertyGroup></Project>' |
                    Set-Content $projectFile
            }
            'outside repository' { $repo = $scripts }
            'missing package' { $package = Join-Path $root 'missing' }
            'mixed parameter sets' { $extraArguments = @('-PackageInfoDirectory', $root, '-OutputDirectory', $root) }
        }

        $messages = & $pwshExecutable -NoProfile -File $wrapper -PackagePath $package -SdkRepoPath $repo @extraArguments 2>&1

        $LASTEXITCODE | Should -Not -Be 0
        ($messages | Out-String) | Should -Match $Expected
        Test-Path (Join-Path $scripts 'invocation.json') | Should -BeFalse
    }

    It 'returns nonzero when the generator fails' {
        "throw 'stub generator failed'" | Set-Content (Join-Path $scripts 'Gen-Mgmt-Changelog.ps1')

        $messages = & $pwshExecutable -NoProfile -File $wrapper -PackagePath $package -SdkRepoPath $repo 2>&1

        $LASTEXITCODE | Should -Not -Be 0
        ($messages | Out-String) | Should -Match 'stub generator failed'
    }

    It 'continues a real batch after a failed child and exports artifacts before returning nonzero' {
        $info = Join-Path $root 'info'
        $output = Join-Path $root 'output'
        New-Item -ItemType Directory -Path $info -Force | Out-Null
        foreach ($name in 'Azure.ResourceManager.One', 'Azure.ResourceManager.Two') {
            $directory = "sdk/test/$name"
            $batchPackage = Join-Path $repo $directory
            New-Item -ItemType Directory -Path "$batchPackage/src", "$batchPackage/api" -Force | Out-Null
            "<Project><PropertyGroup><PackageId>$name</PackageId><Version>1.0.0</Version></PropertyGroup></Project>" |
                Set-Content (Join-Path $batchPackage "src/$name.csproj")
            'API' | Set-Content (Join-Path $batchPackage "api/$name.netstandard2.0.cs")
            @{ Name = $name; DirectoryPath = $directory; IncludedForValidation = $false } |
                ConvertTo-Json | Set-Content (Join-Path $info "$name.json")
        }
        @'
param($ServiceName, $ReleaseVersion, $ReleaseDate, $ApiFilePath)
if ($ApiFilePath -match 'Azure.ResourceManager.One') { throw 'first child failed' }
'generated by second child' | Set-Content (Join-Path (Split-Path (Split-Path $ApiFilePath -Parent) -Parent) 'CHANGELOG.md')
'@ | Set-Content (Join-Path $scripts 'Gen-Mgmt-Changelog.ps1')
        # Keep patch generation offline and observable without requiring a git checkout.
        @'
function git { 'patch exported' | Set-Content (($args | Where-Object { $_ -like '--output=*' }) -replace '^--output=', ''); $global:LASTEXITCODE = 0 }
& $args[0] -PackageInfoDirectory $args[1] -SdkRepoPath $args[2] -OutputDirectory $args[3]
'@ | Set-Content (Join-Path $scripts 'batch-harness.ps1')

        $messages = & $pwshExecutable -NoProfile -File (Join-Path $scripts 'batch-harness.ps1') $wrapper $info $repo $output 2>&1

        $LASTEXITCODE | Should -Not -Be 0
        ($messages | Out-String) | Should -Match 'Changelog generation failed for: Azure.ResourceManager.One'
        Get-Content (Join-Path $output 'sdk/test/Azure.ResourceManager.Two/CHANGELOG.md') | Should -Be 'generated by second child'
        Get-Content (Join-Path $output 'changelog.patch') | Should -Be 'patch exported'
    }
}

Describe 'Update-MgmtChangelog PR batch' {
    BeforeAll {
        $runner = Join-Path $PSScriptRoot '../Update-MgmtChangelog.ps1'
        $gitExecutable = (Get-Command git -CommandType Application | Select-Object -First 1).Source
        function Write-PackageInfo($Name, $Indirect = $false, $DirectoryPath = "sdk/test/$Name") {
            @{
                Name = $Name
                IncludedForValidation = $Indirect
                DirectoryPath = $DirectoryPath
            } | ConvertTo-Json | Set-Content (Join-Path $info "$Name.json")
        }
    }

    BeforeEach {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $repo = Join-Path $root 'repo'
        $info = Join-Path $root 'info'
        $output = Join-Path $root 'output'
        New-Item -ItemType Directory -Path $repo, $info -Force | Out-Null
        Mock pwsh { $global:LASTEXITCODE = 0 }
        Mock git { $global:LASTEXITCODE = 0 }
    }

    It 'calls the single-package mode only for directly changed management packages' {
        Write-PackageInfo 'Azure.ResourceManager.Test'
        Write-PackageInfo 'Azure.ResourceManager.Indirect' $true
        Write-PackageInfo 'Azure.Core'

        & $runner -PackageInfoDirectory $info -SdkRepoPath $repo -OutputDirectory $output

        Should -Invoke pwsh -Times 1 -Exactly -ParameterFilter {
            ($args -join ' ') -match 'sdk[\\/]test[\\/]Azure.ResourceManager.Test' -and
            ($args -join ' ') -match 'Update-MgmtChangelog.ps1' -and
            $args -contains '-PackagePath' -and $args -notcontains '-PackageInfoDirectory'
        }
        Should -Invoke git -Times 1 -Exactly
    }

    It 'deduplicates package metadata by directory' {
        Write-PackageInfo 'Azure.ResourceManager.Test'
        Copy-Item (Join-Path $info 'Azure.ResourceManager.Test.json') (Join-Path $info 'duplicate.json')

        & $runner -PackageInfoDirectory $info -SdkRepoPath $repo -OutputDirectory $output

        Should -Invoke pwsh -Times 1 -Exactly
    }

    It 'collects generated changelogs as artifacts' {
        Write-PackageInfo 'Azure.ResourceManager.Test'
        $package = Join-Path $repo 'sdk/test/Azure.ResourceManager.Test'
        New-Item -ItemType Directory $package -Force | Out-Null
        'generated changelog' | Set-Content (Join-Path $package 'CHANGELOG.md')

        & $runner -PackageInfoDirectory $info -SdkRepoPath $repo -OutputDirectory $output

        Get-Content (Join-Path $output 'sdk/test/Azure.ResourceManager.Test/CHANGELOG.md') |
            Should -Be 'generated changelog'
    }

    It 'attempts all packages and exports a patch even when children fail' {
        Write-PackageInfo 'Azure.ResourceManager.One'
        Write-PackageInfo 'Azure.ResourceManager.Two'
        Mock pwsh { $global:LASTEXITCODE = 1 }
        $PSNativeCommandUseErrorActionPreference = $true

        { & $runner -PackageInfoDirectory $info -SdkRepoPath $repo -OutputDirectory $output } |
            Should -Throw '*Changelog generation failed for*'
        Should -Invoke pwsh -Times 2 -Exactly
        Should -Invoke git -Times 1 -Exactly
    }

    It 'continues after a subprocess invocation throws' {
        Write-PackageInfo 'Azure.ResourceManager.One'
        Write-PackageInfo 'Azure.ResourceManager.Two'
        Mock pwsh { throw 'could not start child' }

        { & $runner -PackageInfoDirectory $info -SdkRepoPath $repo -OutputDirectory $output } |
            Should -Throw '*Changelog generation failed for*'
        Should -Invoke pwsh -Times 2 -Exactly
        Should -Invoke git -Times 1 -Exactly
    }

    It 'handles absent package metadata without calling the tool' {
        & $runner -PackageInfoDirectory (Join-Path $root 'missing') -SdkRepoPath $repo -OutputDirectory $output

        Should -Invoke pwsh -Times 0 -Exactly
        Test-Path (Join-Path $output 'README.txt') | Should -BeTrue
    }

    It 'does not call the tool for unrelated packages' {
        Write-PackageInfo 'Azure.Core'
        & $runner -PackageInfoDirectory $info -SdkRepoPath $repo -OutputDirectory $output

        Should -Invoke pwsh -Times 0 -Exactly
        Should -Invoke git -Times 0 -Exactly
    }

    It 'rejects unsafe package metadata: <DirectoryPath>' -TestCases @(
        @{ DirectoryPath = '../outside' }
        @{ DirectoryPath = 'sdk/test/Azure.ResourceManager.Test/nested' }
        @{ DirectoryPath = 'sdk/test/Azure.ResourceManager.Other' }
        @{ DirectoryPath = 'sdk/../Azure.ResourceManager.Test' }
    ) {
        param($DirectoryPath)
        Write-PackageInfo 'Azure.ResourceManager.Test' $false $DirectoryPath

        { & $runner -PackageInfoDirectory $info -SdkRepoPath $repo -OutputDirectory $output } |
            Should -Throw '*Changelog generation failed for*'
        Should -Invoke pwsh -Times 0 -Exactly
        Should -Invoke git -Times 0 -Exactly
    }

    It 'still processes valid packages when another metadata path is invalid' {
        Write-PackageInfo 'Azure.ResourceManager.Invalid' $false '../outside'
        Write-PackageInfo 'Azure.ResourceManager.Test'

        { & $runner -PackageInfoDirectory $info -SdkRepoPath $repo -OutputDirectory $output } |
            Should -Throw '*Changelog generation failed for: Azure.ResourceManager.Invalid*'
        Should -Invoke pwsh -Times 1 -Exactly
        Should -Invoke git -Times 1 -Exactly
    }

    It 'fails if the generated patch cannot be exported' {
        Write-PackageInfo 'Azure.ResourceManager.Test'
        Mock git { $global:LASTEXITCODE = 1 }

        { & $runner -PackageInfoDirectory $info -SdkRepoPath $repo -OutputDirectory $output } |
            Should -Throw '*Failed to export*'
    }

    It 'exports an applicable patch using real git' {
        Write-PackageInfo 'Azure.ResourceManager.Test'
        $package = Join-Path $repo 'sdk/test/Azure.ResourceManager.Test'
        New-Item -ItemType Directory $package -Force | Out-Null
        $changelog = Join-Path $package 'CHANGELOG.md'
        'original changelog' | Set-Content $changelog
        & $gitExecutable -C $repo init --quiet
        & $gitExecutable -C $repo add .
        & $gitExecutable -C $repo -c user.name=Test -c user.email=test@example.invalid -c commit.gpgsign=false commit --quiet -m baseline
        $LASTEXITCODE | Should -Be 0
        Mock pwsh {
            'updated changelog' | Set-Content $changelog
            $global:LASTEXITCODE = 0
        }
        Mock git {
            & $gitExecutable @args
            $global:LASTEXITCODE = $LASTEXITCODE
        }

        & $runner -PackageInfoDirectory $info -SdkRepoPath $repo -OutputDirectory $output

        $patch = Join-Path $output 'changelog.patch'
        Get-Content $patch -Raw | Should -Match 'updated changelog'
        & $gitExecutable -C $repo apply --reverse --check $patch
        $LASTEXITCODE | Should -Be 0
    }
}

Describe 'PR pipeline entrypoint' {
    BeforeAll {
        $pipeline = Get-Content (Join-Path $PSScriptRoot '../../pipelines/pullrequest.yml') -Raw
        $stageTemplate = Get-Content (Join-Path $PSScriptRoot '../../pipelines/templates/stages/archetype-sdk-client.yml') -Raw
    }

    It 'retains runs for each pushed revision' {
        $pipeline | Should -Match 'autoCancel: false'
    }

    It 'opts in through the original stage inheritance' {
        $pipeline | Should -Match 'template: /eng/pipelines/templates/stages/archetype-sdk-client.yml'
        $pipeline | Should -Match 'EnableAutoPrManagementChangelog: true'
        $pipeline | Should -Not -Match 'job: AutoPrManagementChangelog|stage: Build|stage: NoOp'
        $pipeline | Should -Match 'SkipPrValidation: \$\{\{ parameters.SkipPrValidation \}\}'
        $pipeline | Should -Match "if and\(eq\(parameters.oneESTemplateTag, 'canary'\), eq\(parameters.Service, 'auto'\)\)"
        $pipeline | Should -Match 'ServiceDirectory: template'
        $pipeline | Should -Match 'ServiceDirectory: \$\{\{ parameters.Service \}\}'
        $pipeline | Should -Match 'ExcludePaths:\s+- eng/packages/http-client-csharp/'
    }

    It 'defaults to disabled and conditionally inserts the job under Build' {
        $stageTemplate | Should -Match 'name: EnableAutoPrManagementChangelog\s+type: boolean\s+default: false'
        $stageTemplate | Should -Match '(?s)stage: Build\s+.*?jobs:\s+- \$\{\{ if eq\(parameters.EnableAutoPrManagementChangelog, true\) \}\}:\s+- job: AutoPrManagementChangelog'
    }

    It 'gates the independent changelog job on the PR source branch' {
        $stageTemplate | Should -Match 'job: AutoPrManagementChangelog'
        $stageTemplate | Should -Match "eq\(variables\['Build.Reason'\], 'PullRequest'\)"
        $stageTemplate | Should -Match "startsWith\(variables\['System.PullRequest.SourceBranch'\], 'sdkauto/'\)"
        $stageTemplate | Should -Match "startsWith\(variables\['System.PullRequest.SourceBranch'\], 'refs/heads/sdkauto/'\)"
        $stageTemplate | Should -Match 'dependsOn: \[\]'
        $stageTemplate | Should -Match 'Update-MgmtChangelog.ps1'
    }

    It 'retains existing CI jobs and publishes changelog results' {
        $stageTemplate | Should -Match 'template: /eng/pipelines/templates/jobs/ci.yml'
        $stageTemplate | Should -Match 'ArtifactName: ManagementChangelogs'
        $stageTemplate | Should -Match 'ArtifactPath: \$\(Build.ArtifactStagingDirectory\)/ManagementChangelogs'
        $stageTemplate | Should -Match 'CustomCondition: succeededOrFailed\(\)'
        $stageTemplate | Should -Not -Match 'persistCredentials: true'
    }
}
