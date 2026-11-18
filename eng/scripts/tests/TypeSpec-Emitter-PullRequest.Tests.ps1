#Requires -Version 7.0
<#
Run with PowerShell 7 and Node.js:
Invoke-Pester eng/scripts/tests/TypeSpec-Emitter-PullRequest.Tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module
# Match the other eng/scripts suites to avoid conflicting YAML module versions in one session.
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

Set-StrictMode -Version 3

BeforeDiscovery {
    $titleCases = foreach ($emitter in @(
        "azure-typespec/http-client-csharp",
        "azure-typespec/http-client-csharp-mgmt",
        "azure-typespec/http-client-csharp-provisioning"
    )) {
        foreach ($prerelease in @($true, $false)) {
            foreach ($result in @("Succeeded", "SucceededWithIssues", "Failed", "Canceled", "Skipped")) {
                foreach ($reason in @("Manual", "IndividualCI", "Schedule")) {
                    $version = if ($prerelease) { "1.0.0-alpha.20260911.1" } else { "1.0.0" }
                    $versionDescription = if ($prerelease) { "prerelease $version" } else { $version }
                    $title = "Update $emitter version to $versionDescription"
                    if ($result -ne "Succeeded") { $title = "Failed: $title" }
                    if ($reason -eq "Schedule") { $title = "Scheduled code regeneration test" }
                    if ($reason -eq "Manual") { $title = "[Preview] $title" }
                    @{
                        Emitter = $emitter
                        Prerelease = $prerelease
                        Version = $version
                        Result = $result
                        Reason = $reason
                        ExpectedTitle = $title
                        ExpectedDraft = $reason -ne "IndividualCI" -or $result -ne "Succeeded"
                    }
                }
            }
        }
    }

    $otherReasonCases = foreach ($reason in @(
        "BatchedCI", "PullRequest", "BuildCompletion", "ResourceTrigger", "ValidateShelveset", "CheckInShelveset"
    )) {
        foreach ($result in @("Succeeded", "Failed")) {
            @{
                Reason = $reason
                Result = $result
                ExpectedPrefix = if ($result -eq "Succeeded") { "" } else { "Failed: " }
            }
        }
    }

    $sourceCases = foreach ($source in @(
        @{ Ref = "refs/heads/main"; Trigger = "branch: [main](https://github.com/Azure/azure-sdk-for-net/tree/refs/heads/main)" },
        @{ Ref = "refs/heads/feature/test"; Trigger = "branch: [feature/test](https://github.com/Azure/azure-sdk-for-net/tree/refs/heads/feature/test)" },
        @{ Ref = "refs/tags/v1.0.0"; Trigger = "tag: [v1.0.0](https://github.com/Azure/azure-sdk-for-net/tree/refs/tags/v1.0.0)" },
        @{ Ref = "refs/pull/123/head"; Trigger = "pull request: https://github.com/Azure/azure-sdk-for-net/pull/123" },
        @{ Ref = "refs/pull/123/merge"; Trigger = "pull request: https://github.com/Azure/azure-sdk-for-net/pull/123" },
        @{ Ref = "custom-ref"; Trigger = "[custom-ref](https://github.com/Azure/azure-sdk-for-net/tree/custom-ref)" }
    )) {
        foreach ($reason in @("Manual", "IndividualCI")) {
            foreach ($result in @("Succeeded", "Failed")) {
                @{
                    SourceBranch = $source.Ref
                    ExpectedTrigger = $source.Trigger
                    Reason = $reason
                    Result = $result
                    ExpectedDraft = $reason -ne "IndividualCI" -or $result -ne "Succeeded" -or $source.Ref -ne "refs/heads/main"
                    ExpectedPrefix = "$(if ($reason -eq 'Manual') { '[Preview] ' })$(if ($result -ne 'Succeeded') { 'Failed: ' })"
                }
            }
        }
    }
}

BeforeAll {
    $repoRoot = Join-Path $PSScriptRoot ".." ".." ".."

    function Find-PipelineNode($Node, [string]$PropertyName, [string]$PropertyValue) {
        if ($Node -is [System.Collections.IDictionary]) {
            if ($Node[$PropertyName] -eq $PropertyValue) {
                $Node
            }
            foreach ($child in $Node.Values) {
                Find-PipelineNode $child $PropertyName $PropertyValue
            }
        } elseif ($Node -is [System.Collections.IEnumerable] -and $Node -isnot [string]) {
            foreach ($child in $Node) {
                Find-PipelineNode $child $PropertyName $PropertyValue
            }
        }
    }

    $pipeline = Get-Content (Join-Path $repoRoot "eng" "pipelines" "templates" "archetype-typespec-emitter.yml") -Raw | ConvertFrom-Yaml
    $titleSteps = @(Find-PipelineNode $pipeline "displayName" "Get PR title and body")
    $titleSteps.Count | Should -Be 1
    $titleScript = $titleSteps[0].pwsh

    function Invoke-TitleStep(
        [string]$Reason = "Manual",
        [string]$Result = "Succeeded",
        [string]$SourceBranch = "refs/heads/main",
        [string]$EmitterIdentifier = "-azure-typespec/http-client-csharp-mgmt",
        [bool]$Prerelease = $true,
        [string]$Version = "1.0.0-alpha.20260911.1"
    ) {
        $macros = @{
            '$(generateJobResult)' = $Result
            '$(emitterVersion)' = $Version
            '$(emitterIdentifier)' = $EmitterIdentifier
            '$(System.CollectionUri)' = "https://dev.azure.com/azure-sdk"
            '$(System.TeamProject)' = "internal"
            '$(Build.DefinitionName)' = "branded emitter"
            '$(Build.Repository.Uri)' = "https://github.com/Azure/azure-sdk-for-net"
            '$(Build.Repository.Name)' = "Azure/azure-sdk-for-net"
            '$(Build.SourceBranch)' = $SourceBranch
            '$(Build.Reason)' = $Reason
            '$(Build.BuildId)' = "12345"
            '$(Build.BuildNumber)' = "20260911.1"
            '${{ parameters.BuildPrereleaseVersion }}' = $Prerelease.ToString()
        }
        $script = $titleScript
        foreach ($macro in $macros.GetEnumerator()) {
            $script = $script.Replace($macro.Key, $macro.Value)
        }

        $variables = @{}
        & ([scriptblock]::Create($script)) 6>&1 | ForEach-Object {
            if ("$_" -match '^##vso\[task\.setvariable variable=([^\]]+)\](.*)$') {
                $variables.Add($Matches[1], $Matches[2])
            }
        }
        $variables.Count | Should -Be 6
        $variables.RepoOwner | Should -BeExactly "Azure"
        $variables.RepoName | Should -BeExactly "azure-sdk-for-net"
        return $variables
    }
}

Describe "TypeSpec emitter regeneration commits" -Tag "UnitTest" {
    It "uses the expected commit message for <Job>" -ForEach @(
        @{ Job = "Initialize"; ExpectedMessage = 'Regenerate repository SDK with TypeSpec build $(Build.BuildNumber) [skip ci]' },
        @{ Job = "Generate"; ExpectedMessage = 'Update SDK code $(JobKey)' }
    ) {
        $jobs = @(Find-PipelineNode $pipeline "job" $Job)
        $jobs.Count | Should -Be 1
        $pushSteps = @(Find-PipelineNode $jobs[0] "template" "/eng/common/pipelines/templates/steps/git-push-changes.yml")
        $pushSteps.Count | Should -Be 1

        $pushSteps[0].parameters.CommitMsg | Should -BeExactly $ExpectedMessage
        $pushSteps[0].parameters.BaseRepoBranch | Should -BeExactly '$(branchName)'
    }

    It "runs <Job> after <Dependency>" -ForEach @(
        @{ Job = "Generate"; Dependency = "Initialize" },
        @{ Job = "Create_PR"; Dependency = "Generate" }
    ) {
        $jobs = @(Find-PipelineNode $pipeline "job" $Job)
        $jobs.Count | Should -Be 1

        @($jobs[0].dependsOn) | Should -Contain $Dependency
    }
}

Describe "TypeSpec emitter regeneration PR metadata" -Tag "UnitTest" {
    It "preserves metadata for <Reason>, <Emitter>, <Version>, <Result>" -ForEach $titleCases {
        $actual = Invoke-TitleStep -Reason $Reason -Result $Result -EmitterIdentifier "-$Emitter" -Prerelease $Prerelease -Version $Version

        $actual.PullRequestTitle | Should -BeExactly $ExpectedTitle
        $actual.OpenAsDraft | Should -BeExactly $ExpectedDraft.ToString()
        $actual.PRLabels | Should -BeExactly $(if ($ExpectedDraft) { "Do Not Merge" } else { "" })
    }

    It "does not mark other automatic reasons as previews: <Reason>, <Result>" -ForEach $otherReasonCases {
        $actual = Invoke-TitleStep -Reason $Reason -Result $Result

        $actual.PullRequestTitle | Should -BeExactly "${ExpectedPrefix}Update azure-typespec/http-client-csharp-mgmt version to prerelease 1.0.0-alpha.20260911.1"
        $actual.OpenAsDraft | Should -BeExactly "True"
        $actual.PRLabels | Should -BeExactly "Do Not Merge"
    }

    It "preserves title, body and draft policy for <Reason>, <SourceBranch>, <Result>" -ForEach $sourceCases {
        $actual = Invoke-TitleStep -Reason $Reason -Result $Result -SourceBranch $SourceBranch

        $actual.PullRequestTitle | Should -BeExactly "${ExpectedPrefix}Update azure-typespec/http-client-csharp-mgmt version to prerelease 1.0.0-alpha.20260911.1"
        $actual.PullRequestBody | Should -BeExactly "Generated by branded emitter build [20260911.1](https://dev.azure.com/azure-sdk/internal/_build/results?buildId=12345)<br/>Triggered from $ExpectedTrigger"
        $actual.OpenAsDraft | Should -BeExactly $ExpectedDraft.ToString()
        $actual.PRLabels | Should -BeExactly $(if ($ExpectedDraft) { "Do Not Merge" } else { "" })
    }

    It "preserves emitter-name normalization for '<Identifier>'" -ForEach @(
        @{ Identifier = ""; ExpectedName = "TypeSpec emitter" },
        @{ Identifier = " "; ExpectedName = "TypeSpec emitter" },
        @{ Identifier = "azure-typespec/http-client-csharp"; ExpectedName = "azure-typespec/http-client-csharp" },
        @{ Identifier = "--azure-typespec/http-client-csharp"; ExpectedName = "azure-typespec/http-client-csharp" }
    ) {
        $actual = Invoke-TitleStep -EmitterIdentifier $Identifier

        $actual.PullRequestTitle | Should -BeExactly "[Preview] Update $ExpectedName version to prerelease 1.0.0-alpha.20260911.1"
    }
}

Describe "Stale generator upgrade workflow compatibility" -Tag "UnitTest" {
    It "cleans up automatic titles while excluding previews and legacy skip-ci titles" {
        $workflow = Get-Content (Join-Path $repoRoot ".github" "workflows" "close-stale-generator-upgrade-prs.yml") -Raw | ConvertFrom-Yaml
        $steps = @($workflow.jobs.'close-stale-prs'.steps | Where-Object name -eq "Find and close stale generator upgrade PRs")
        $steps.Count | Should -Be 1
        $pulls = @()
        $expectedStaleNumbers = @()
        foreach ($emitter in @("http-client-csharp", "http-client-csharp-mgmt", "http-client-csharp-provisioning")) {
            foreach ($result in @("Succeeded", "SucceededWithIssues", "Failed", "Canceled", "Skipped")) {
                foreach ($reason in @("Manual", "IndividualCI", "Schedule")) {
                    $metadata = Invoke-TitleStep -Reason $reason -Result $result -EmitterIdentifier "-azure-typespec/$emitter"
                    $number = $pulls.Count + 1
                    $pulls += @{ number = $number; title = $metadata.PullRequestTitle; user = @{ login = "azure-sdk-automation[bot]" } }
                    if ($reason -eq "IndividualCI") {
                        $expectedStaleNumbers += $number
                        # Older [skip ci] titles remain outside the workflow's existing matching rules.
                        $number = $pulls.Count + 1
                        $legacyTitle = "[skip ci] $($metadata.PullRequestTitle)"
                        $pulls += @{ number = $number; title = $legacyTitle; user = @{ login = "azure-sdk-automation[bot]" } }
                    }
                }
            }
        }

        # Execute the complete checked-in github-script, with only local API fixtures and dry-run enabled.
        $harness = @'
const { readFileSync } = require("node:fs");
const { runInNewContext } = require("node:vm");
const input = JSON.parse(readFileSync(0, "utf8"));
const staleNumbers = [];
const listPulls = () => {};
const github = {
  rest: {
    pulls: { list: listPulls },
    repos: {
      getContent: async ({ path }) => {
        const content = path.endsWith(".props")
          ? `<Project><UnbrandedGeneratorVersion>${input.currentVersion}</UnbrandedGeneratorVersion></Project>`
          : JSON.stringify({
              dependencies: Object.fromEntries(
                ["http-client-csharp", "http-client-csharp-mgmt", "http-client-csharp-provisioning"]
                  .map((name) => [`@azure-typespec/${name}`, input.currentVersion]),
              ),
            });
        return { data: { type: "file", content: Buffer.from(content).toString("base64") } };
      },
    },
  },
  paginate: async (method) => {
    if (method !== listPulls) throw new Error("Unexpected API request");
    return input.pulls;
  },
};
const core = {
  info: (message) => {
    const match = message.match(/^\[dry run\] Would close #(\d+):/);
    if (match) staleNumbers.push(Number(match[1]));
  },
  summary: { addHeading: () => {}, addRaw: () => {}, write: async () => {} },
};
runInNewContext(`(async () => {${input.script}})()`, {
  github, core, Buffer,
  context: { repo: { owner: "Azure", repo: "azure-sdk-for-net" }, payload: { repository: { default_branch: "main" } } },
  process: { env: { DRY_RUN: "true" } },
}).then(() => console.log(JSON.stringify(staleNumbers)))
  .catch((error) => { console.error(error); process.exitCode = 1; });
'@
        $inputJson = @{
            script = $steps[0].with.script
            pulls = $pulls
            currentVersion = "1.0.0-alpha.20260912.1"
        } | ConvertTo-Json -Depth 10 -Compress

        $output = $inputJson | & node -e $harness
        $LASTEXITCODE | Should -Be 0
        $staleNumbers = @($output | ConvertFrom-Json)
        $staleNumbers.Count | Should -Be 15
        $staleNumbers | Should -Be $expectedStaleNumbers
    }
}
