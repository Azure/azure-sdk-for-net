#Requires -Version 7.0

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Describe 'Trusted AutoPR changelog writeback' {
    BeforeAll {
        $workflow = Get-Content (Join-Path $PSScriptRoot '../../../.github/workflows/management-changelog.yml') -Raw
        $scriptMatch = [regex]::Match($workflow, '(?m)^          script: \|\r?\n(?<script>(?:^            [^\r\n]*(?:\r?\n|\z)|^\r?\n)+)\z', [System.Text.RegularExpressions.RegexOptions]::None, [TimeSpan]::FromSeconds(5))
        $writebackScript = $scriptMatch.Groups['script'].Value -replace '(?m)^            ', ''
        $harness = @'
const assert = require('node:assert/strict');
const { script, scenario } = JSON.parse(require('node:fs').readFileSync(0, 'utf8'));
const filename = 'sdk/netapp/Azure.ResourceManager.NetApp/CHANGELOG.md';
const normalizedContent = 'generated changelog\n\nHistorical entry\n';
const lineEndingScenario = ['crlf', 'mixed-eol-noop', 'repair-crlf'].includes(scenario);
const generatedContent = lineEndingScenario ? 'generated changelog\r\n\r\nHistorical entry\n' : 'generated changelog';
const currentContent = scenario === 'mixed-eol-noop' ? normalizedContent : scenario === 'repair-crlf' ? normalizedContent.replace(/\n/g, '\r\n') : scenario === 'noop' ? 'generated changelog' : 'old changelog';
const sourceSha = 'a'.repeat(40);
const pr = { state: 'open', head: { sha: sourceSha, ref: 'sdkauto/test', repo: { full_name: 'Azure/azure-sdk-for-net' } } };
const run = { head_repository: { full_name: 'Azure/azure-sdk-for-net' }, event: 'pull_request', head_branch: 'sdkauto/test', head_sha: sourceSha };
const build = { definition: { id: 7327 }, reason: 'pullRequest', repository: { type: 'GitHub', id: 'Azure/azure-sdk-for-net' },
    id: 123, sourceBranch: 'refs/pull/42/merge', triggerInfo: { 'pr.sourceSha': sourceSha, 'pr.sourceBranch': 'sdkauto/test' } };
const timeline = { records: [ { id: 'job', type: 'Job', state: 'completed', identifier: 'Build.AutoPrManagementChangelog.__default', result: 'succeeded' },
    { parentId: 'job', name: 'Run management changelog tool', result: 'succeeded' } ] };
const artifacts = { value: [ { name: 'ManagementChangelogs', source: 'job', resource: { downloadUrl: 'https://example.artifacts.visualstudio.com/changelogs.zip' } } ] };
let entries = `ManagementChangelogs/${filename}\n`;
if (scenario === 'stale') pr.head.sha = 'b'.repeat(40);
if (scenario === 'fork') pr.head.repo.full_name = 'someone/fork';
if (scenario === 'non-autopr') pr.head.ref = 'users/test';
if (scenario === 'closed') pr.state = 'closed';
if (scenario === 'run-fork') run.head_repository.full_name = 'someone/fork';
if (scenario === 'run-non-autopr') run.head_branch = 'users/test';
if (scenario === 'run-not-pr') run.event = 'push';
if (scenario === 'definition') build.definition.id = 1;
if (scenario === 'reason') build.reason = 'manual';
if (scenario === 'repository-type') build.repository.type = 'TfsGit';
if (scenario === 'repository-id') build.repository.id = 'someone/fork';
if (scenario === 'merge-ref') build.sourceBranch = 'refs/heads/main';
if (scenario === 'dispatch-wrong-pr') build.sourceBranch = 'refs/pull/99/merge';
if (scenario === 'failed-job') timeline.records[0].result = 'failed';
if (scenario === 'failed-tool') timeline.records[1].result = 'failed';
if (scenario === 'tool-parent') timeline.records[1].parentId = 'other-job';
if (scenario === 'artifact-source') artifacts.value[0].source = 'other-job';
if (scenario === 'artifact-name') artifacts.value[0].name = 'Other';
if (scenario === 'download-host') artifacts.value[0].resource.downloadUrl = 'https://evil.example/zip';
if (scenario === 'download-suffix') artifacts.value[0].resource.downloadUrl = 'https://example.artifacts.visualstudio.com.evil.example/zip';
if (scenario === 'download-http') artifacts.value[0].resource.downloadUrl = 'http://example.artifacts.visualstudio.com/zip';
if (scenario === 'unrelated-package') entries = 'sdk/other/Azure.ResourceManager.Other/CHANGELOG.md\n';
if (scenario === 'traversal') entries = 'sdk/../Azure.ResourceManager.NetApp/CHANGELOG.md\n';
if (scenario === 'duplicate') entries += entries;
if (scenario === 'patch-only') entries = 'ManagementChangelogs/changelog.patch\n';
if (scenario === 'too-many-entries') entries = 'ignored\n'.repeat(1001);
const updates = [], trees = [], commits = [], requests = [];
let reads = 0, unzips = 0, cleanups = 0;
const dispatch = scenario.startsWith('dispatch');
const github = { paginate: async () => Array.from({ length: scenario === 'truncated-files' ? 3000 : 1 }, () =>
    ({ filename: 'sdk/netapp/Azure.ResourceManager.NetApp/api/test.cs', status: scenario === 'removed-package' ? 'removed' : 'modified' })), rest: {
    pulls: { get: async p => { assert.equal(p.pull_number, 42); reads++;
        return { data: ['race', 'race-closed', 'race-branch'].includes(scenario) && reads > 1 ?
            { ...pr, state: scenario === 'race-closed' ? 'closed' : pr.state,
                head: { ...pr.head, sha: scenario === 'race' ? 'b'.repeat(40) : pr.head.sha,
                    ref: scenario === 'race-branch' ? 'sdkauto/other' : pr.head.ref } } : pr }; }, listFiles: {} },
    repos: { getContent: async p => { assert.equal(p.path, filename); assert.equal(p.ref, sourceSha);
        return { data: { type: scenario === 'symlink' ? 'symlink' : 'file', encoding: scenario === 'encoding' ? 'none' : 'base64', content: Buffer.from(currentContent).toString('base64') } }; } },
    git: { getCommit: async p => { assert.equal(p.commit_sha, sourceSha); return { data: { tree: { sha: 'oldtree' } } }; },
        createTree: async p => { assert.equal(p.base_tree, 'oldtree'); trees.push(p); return { data: { sha: 'newtree' } }; },
        createCommit: async p => { assert.deepEqual(p.parents, [sourceSha]); assert.equal(p.tree, 'newtree');
            assert.equal(p.message, 'Update management SDK changelogs [skip ci]'); commits.push(p); return { data: { sha: 'newcommit' } }; },
        updateRef: async p => { if (scenario === 'nonfastforward') throw new Error('Reference update failed'); updates.push(p); } }
} };
async function fetch(url) {
    url = String(url); requests.push(url);
    assert.ok(url.startsWith('https://dev.azure.com/azure-sdk/public/') || url === 'https://example.artifacts.visualstudio.com/changelogs.zip');
    const listing = url.includes('definitions=7327');
    const candidate = { ...build, triggerInfo: { ...build.triggerInfo } };
    if (['lookup-sha', 'lookup-branch'].includes(scenario)) {
        // Include an unmatched build first, then the correct one: only the latter's timeline may be read.
        candidate.id = 999;
        candidate.triggerInfo[scenario === 'lookup-sha' ? 'pr.sourceSha' : 'pr.sourceBranch'] = 'wrong';
    }
    if (scenario === 'changed-sha' && !listing) build.triggerInfo['pr.sourceSha'] = 'b'.repeat(40);
    if (scenario === 'changed-branch' && !listing) build.triggerInfo['pr.sourceBranch'] = 'sdkauto/other';
    const data = listing ? { value: [candidate, build] } : url.includes('/timeline?') ? timeline : url.includes('/artifacts?') ? artifacts : build;
    assert.ok(!url.includes('/999/'), 'must not select an unmatched build');
    const ok = !(scenario === 'lookup-http-error' && listing) && !(scenario === 'download-error' && url.endsWith('.zip'));
    return { ok, status: 503, json: async () => data, body: (async function* () { yield Buffer.alloc(scenario === 'oversized' ? 10 * 1024 * 1024 + 1 : 3); })() };
}
function safeRequire(name) {
    if (name === 'node:fs/promises') return { mkdtemp: async () => '/temp/changelog', writeFile: async () => {}, rm: async () => { cleanups++; } };
    if (name === 'node:child_process') {
        const execFile = () => { throw new Error('Expected promisified execFile'); };
        execFile[require('node:util').promisify.custom] = async (cmd, args, options) => {
            assert.equal(cmd, 'unzip'); assert.equal(options.maxBuffer, 1024 * 1024); unzips++;
            assert.ok(args[0] === '-Z1' || args[0] === '-p', 'never extract or execute artifacts');
            if (args[0] === '-p') assert.equal(args[2], `ManagementChangelogs/${filename}`);
            return { stdout: args[0] === '-Z1' ? entries : generatedContent, stderr: '' };
        };
        return { execFile };
    }
    assert.ok(['node:os', 'node:path', 'node:util'].includes(name), 'unexpected module');
    return require(name);
}
(async () => {
    let error;
    const context = { repo: { owner: 'Azure', repo: 'azure-sdk-for-net' }, eventName: dispatch ? 'workflow_dispatch' : 'workflow_run',
        payload: dispatch ? { inputs: { pull_request_number: scenario === 'dispatch-invalid' ? '42;evil' : '42' } } : { workflow_run: run } };
    try { await new (Object.getPrototypeOf(async function(){}).constructor)('require', 'context', 'github', 'core', 'fetch', script)(
        safeRequire, context, github, { info: () => {} }, fetch); }
    catch (e) { error = e; }
    const rejects = ['definition', 'reason', 'repository-type', 'repository-id', 'merge-ref', 'changed-sha', 'changed-branch',
        'failed-job', 'failed-tool', 'tool-parent', 'artifact-source', 'artifact-name', 'download-host', 'download-suffix', 'download-http',
        'unrelated-package', 'traversal', 'duplicate', 'too-many-entries', 'truncated-files', 'removed-package', 'symlink', 'encoding',
        'oversized', 'lookup-http-error', 'download-error', 'nonfastforward', 'dispatch-invalid', 'dispatch-wrong-pr'];
    if (rejects.includes(scenario)) assert.ok(error, 'unsafe input must be rejected');
    else if (error) throw error;
    const shouldUpdate = ['success', 'workflow-run', 'dispatch', 'crlf', 'repair-crlf', 'lookup-sha', 'lookup-branch'].includes(scenario);
    assert.equal(updates.length, shouldUpdate ? 1 : 0);
    if (shouldUpdate) {
        assert.equal(commits.length, 1); assert.equal(updates[0].sha, 'newcommit');
        assert.equal(updates[0].force, false); assert.equal(updates[0].ref, 'heads/sdkauto/test');
        assert.deepEqual(trees[0].tree, [{ path: filename, mode: '100644', type: 'blob', content: lineEndingScenario ? normalizedContent : generatedContent }]);
    }
    if (unzips) assert.equal(cleanups, 1, 'temporary artifacts must be cleaned up on success or failure');
    if (['run-fork', 'run-non-autopr', 'run-not-pr', 'dispatch-invalid'].includes(scenario)) assert.equal(requests.length, 0);
    console.log('passed: ' + scenario);
})().catch(e => { console.error(e); process.exitCode = 1; });
'@
    }

    It 'validates writeback scenario: <Scenario>' -TestCases @(
        @{ Scenario = 'success' }, @{ Scenario = 'workflow-run' }, @{ Scenario = 'dispatch' },
        @{ Scenario = 'stale' }, @{ Scenario = 'fork' }, @{ Scenario = 'non-autopr' }, @{ Scenario = 'closed' },
        @{ Scenario = 'run-fork' }, @{ Scenario = 'run-non-autopr' }, @{ Scenario = 'run-not-pr' },
        @{ Scenario = 'definition' }, @{ Scenario = 'reason' }, @{ Scenario = 'repository-type' }, @{ Scenario = 'repository-id' },
        @{ Scenario = 'merge-ref' }, @{ Scenario = 'changed-sha' }, @{ Scenario = 'changed-branch' },
        @{ Scenario = 'lookup-sha' }, @{ Scenario = 'lookup-branch' }, @{ Scenario = 'lookup-http-error' },
        @{ Scenario = 'failed-job' }, @{ Scenario = 'failed-tool' }, @{ Scenario = 'tool-parent' },
        @{ Scenario = 'artifact-source' }, @{ Scenario = 'artifact-name' }, @{ Scenario = 'download-host' },
        @{ Scenario = 'download-suffix' }, @{ Scenario = 'download-http' }, @{ Scenario = 'download-error' },
        @{ Scenario = 'unrelated-package' }, @{ Scenario = 'traversal' }, @{ Scenario = 'duplicate' }, @{ Scenario = 'patch-only' },
        @{ Scenario = 'too-many-entries' }, @{ Scenario = 'truncated-files' }, @{ Scenario = 'removed-package' },
        @{ Scenario = 'symlink' }, @{ Scenario = 'encoding' }, @{ Scenario = 'oversized' },
        @{ Scenario = 'noop' }, @{ Scenario = 'race' }, @{ Scenario = 'race-closed' }, @{ Scenario = 'race-branch' }, @{ Scenario = 'nonfastforward' },
        @{ Scenario = 'dispatch-invalid' }, @{ Scenario = 'dispatch-wrong-pr' },
        @{ Scenario = 'crlf' }, @{ Scenario = 'mixed-eol-noop' }, @{ Scenario = 'repair-crlf' }
    ) {
        param($Scenario)
        $writebackScript | Should -Not -BeNullOrEmpty
        @{ script = $writebackScript; scenario = $Scenario } | ConvertTo-Json -Compress | node -e $harness
        $LASTEXITCODE | Should -Be 0
    }

    It 'restricts manual write access to the trusted default-branch definition' {
        $workflow | Should -Match "(?s)if: >-\s+\(github.event_name == 'workflow_dispatch' &&\s+github.ref == format\('refs/heads/\{0\}', github.event.repository.default_branch\)\) \|\|\s+\(github.event_name == 'workflow_run' &&"
    }

    It 'uses only the dedicated trusted triggers and least-privilege pinned writer' {
        $workflow | Should -Match '(?s)on:\s+workflow_run:\s+workflows: \[Verify Links\]\s+types: \[completed\]\s+workflow_dispatch:\s+inputs:\s+pull_request_number:'
        $workflow | Should -Match '(?m)^permissions: \{\}\r?$'
        $workflow | Should -Match 'permissions:\s+contents: write\s+pull-requests: read\s+steps:'
        $workflow | Should -Match 'uses: actions/github-script@3a2844b7e9c422d3c10d287c895573f7108da1b3'
        $workflow | Should -Match 'runs-on: ubuntu-latest'
        $workflow | Should -Not -Match 'actions/checkout|(?m)^\s+run:|check_run:|pull_request_target:'
        $writebackScript | Should -Not -Match '\$\{\{|payload\.check_run'
        ([regex]::Matches($workflow, '(?m)^\s+uses:')).Count | Should -Be 1
    }

    It 'leaves the shared event processor and link verification workflows untouched' {
        $root = Join-Path $PSScriptRoot '../../..'
        foreach ($name in 'event-processor.yml', 'verify-links.yml') {
            $relativePath = ".github/workflows/$name"
            $difference = & git -C $root diff HEAD -- $relativePath
            $LASTEXITCODE | Should -Be 0
            $difference | Should -BeNullOrEmpty
            Get-Content (Join-Path $root $relativePath) -Raw | Should -Not -Match 'update-management-changelogs|Management Changelog Writeback|workflow_run:'
        }
    }
}

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
