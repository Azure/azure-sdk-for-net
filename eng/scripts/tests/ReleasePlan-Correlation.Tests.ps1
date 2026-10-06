# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.
# Validate template-only completion correlation without running a release pipeline.
#Requires -Version 7.0

. (Join-Path $PSScriptRoot '../../common/scripts/Helpers/PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'Pester' '5.3.3' | Import-Module
Install-ModuleIfNotInstalled 'powershell-yaml' '0.4.1' | Import-Module

Set-StrictMode -Version 4

BeforeAll {
    $script:repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
    # Pin the pre-pilot baseline so protections cannot drift with the current branch.
    $script:baseline = 'd6261e739a077be104ff951c489e2b104c9d3c5f'
    $script:paths = @(
        'sdk/template/ci.yml',
        'eng/pipelines/templates/stages/archetype-sdk-client.yml',
        'eng/pipelines/templates/stages/archetype-net-release.yml'
    )
    $script:documents = @($script:paths | ForEach-Object {
        Get-Content -LiteralPath (Join-Path $script:repoRoot $_) -Raw | ConvertFrom-Yaml
    })
    $script:entry = $script:documents[0]
    $script:client = $script:documents[1]
    $script:release = $script:documents[2]
    $script:pilotCondition = '${{ if eq(parameters.ServiceDirectory, ''template'') }}'
    $script:autoCondition = '${{ if and(eq(variables[''Build.Reason''], ''IndividualCI''), eq(variables[''Build.SourceBranch''], ''refs/heads/main'')) }}'
    $script:autoPilotCondition = '${{ if and(eq(parameters.ServiceDirectory, ''template''), eq(variables[''Build.Reason''], ''IndividualCI''), eq(variables[''Build.SourceBranch''], ''refs/heads/main'')) }}'
    $script:existingAutoCondition = '${{ if eq(variables[''Build.Reason''], ''IndividualCI'') }}'

    function Find-PipelineNode {
        param($Node, [string]$PropertyName, [string]$PropertyValue)
        if ($Node -is [System.Collections.IDictionary]) {
            if ($Node[$PropertyName] -eq $PropertyValue) { $Node }
            foreach ($child in $Node.Values) { Find-PipelineNode $child $PropertyName $PropertyValue }
        }
        elseif ($Node -is [System.Collections.IEnumerable] -and $Node -isnot [string]) {
            foreach ($child in $Node) { Find-PipelineNode $child $PropertyName $PropertyValue }
        }
    }

    function ConvertTo-NormalizedNode {
        param($Node)
        if ($Node -is [System.Collections.IDictionary]) {
            $result = [ordered]@{}
            foreach ($key in @($Node.Keys | Sort-Object)) {
                $result[$key] = ConvertTo-NormalizedNode $Node[$key]
            }
            return $result
        }
        if ($Node -is [System.Collections.IEnumerable] -and $Node -isnot [string]) {
            $result = @($Node | ForEach-Object { ConvertTo-NormalizedNode $_ })
            return ,$result
        }
        return $Node
    }

    $script:releaseCalls = @(Find-PipelineNode $script:client 'template' 'archetype-net-release.yml')
    $script:releaseStages = @(Find-PipelineNode $script:release 'stage' 'Release_${{artifact.safeName}}')
    $script:completionCalls = @(Find-PipelineNode $script:release 'template' '/eng/common/pipelines/templates/steps/mark-release-completion.yml')
}

Describe 'Template-only completion correlation' -Tag 'UnitTest' {
    It 'exposes optional string IDs with zero defaults at every entry point' {
        foreach ($document in @($script:entry, $script:client)) {
            $parameter = @($document.parameters | Where-Object name -eq 'ReleasePlanId')
            $parameter.Count | Should -Be 1
            $parameter[0].type | Should -BeExactly 'string'
            ($parameter[0].default -is [string]) | Should -BeTrue
            $parameter[0].default | Should -BeExactly '0'
        }
        ($script:release.parameters.ReleasePlanId -is [string]) | Should -BeTrue
        $script:release.parameters.ReleasePlanId | Should -BeExactly '0'
        $script:entry.extends.parameters.ServiceDirectory | Should -BeExactly 'template'
        @($script:entry.extends.parameters.Artifacts).Count | Should -Be 1
        $script:entry.extends.parameters.Artifacts[0].name | Should -BeExactly 'Azure.Template'
    }

    It 'relays the manual ID unchanged through the client into template completion' {
        $script:releaseCalls.Count | Should -Be 1
        $script:completionCalls.Count | Should -Be 1
        $script:entry.extends.parameters.ReleasePlanId | Should -BeExactly '${{ parameters.ReleasePlanId }}'
        $script:releaseCalls[0].parameters.ReleasePlanId | Should -BeExactly '${{ parameters.ReleasePlanId }}'
        $script:completionCalls[0].parameters[$script:pilotCondition].ReleasePlanId | Should -BeExactly '${{ parameters.ReleasePlanId }}'
    }

    It 'never passes new shared-completion arguments outside the template guard' {
        $parameters = $script:completionCalls[0].parameters
        $parameters.Contains('ReleasePlanId') | Should -BeFalse
        $parameters.Contains('SdkPullRequest') | Should -BeFalse
        (@($parameters.Keys | Sort-Object) -join '|') | Should -BeExactly ((@('ConfigFileDir', 'PackageArtifactName', 'SourceRootPath', $script:pilotCondition) | Sort-Object) -join '|')
        $pilot = $parameters[$script:pilotCondition]
        $pilot.Contains('SdkPullRequest') | Should -BeFalse
        (@($pilot.Keys | Sort-Object) -join '|') | Should -BeExactly ((@('ReleasePlanId', $script:autoCondition) | Sort-Object) -join '|')
        $pilot[$script:autoCondition].SdkPullRequest | Should -BeExactly '$(AutoReleaseSdkPullRequestUrl)'
    }

    It 'binds the exact stage output only for template IndividualCI on main' {
        $script:releaseStages.Count | Should -Be 1
        $stage = $script:releaseStages[0]
        $bindings = @($stage.variables | Where-Object { $_.Contains($script:autoPilotCondition) })
        $bindings.Count | Should -Be 1
        $variables = @($bindings[0][$script:autoPilotCondition])
        $variables.Count | Should -Be 1
        $variables[0].name | Should -BeExactly 'AutoReleaseSdkPullRequestUrl'
        $variables[0].value | Should -BeExactly '$[ stageDependencies.AutoReleasePrepare.ResolveAutoReleasePackages.outputs[''resolve.AutoReleaseSdkPullRequestUrl''] ]'
        @(Find-PipelineNode $script:release 'name' 'AutoReleaseSdkPullRequestUrl').Count | Should -Be 1
        @($stage[$script:existingAutoCondition].dependsOn) -join '|' | Should -BeExactly 'Signing|AutoReleasePrepare'
        $stage['${{ else }}'].dependsOn | Should -BeExactly 'Signing'
    }

    It 'keeps completion after publication inside the existing symbols job' {
        $uploads = @(Find-PipelineNode $script:release 'job' 'UploadSymbols')
        $uploads.Count | Should -Be 1
        $uploads[0].dependsOn | Should -BeExactly 'PublishPackage'
        @(Find-PipelineNode $uploads[0] 'template' '/eng/common/pipelines/templates/steps/mark-release-completion.yml').Count | Should -Be 1
    }

    It 'preserves raw string <Id> through all handoffs without rounding' -ForEach @(
        @{ Id = '0' }, @{ Id = '35307' }, @{ Id = '2147483647' }, @{ Id = '100.6' }
    ) {
        foreach ($expression in @(
            $script:entry.extends.parameters.ReleasePlanId,
            $script:releaseCalls[0].parameters.ReleasePlanId,
            $script:completionCalls[0].parameters[$script:pilotCondition].ReleasePlanId
        )) {
            $expression.Replace('${{ parameters.ReleasePlanId }}', $Id) | Should -BeExactly $Id
        }
        # Parsing a quoted queue value must retain its original text too.
        $queued = "ReleasePlanId: '$Id'" | ConvertFrom-Yaml
        ($queued.ReleasePlanId -is [string]) | Should -BeTrue
        $queued.ReleasePlanId | Should -BeExactly $Id
    }

    It 'equals the parsed baseline after removing only the new feature in <Path>' -ForEach @(
        @{ Index = 0; Path = 'sdk/template/ci.yml' },
        @{ Index = 1; Path = 'eng/pipelines/templates/stages/archetype-sdk-client.yml' },
        @{ Index = 2; Path = 'eng/pipelines/templates/stages/archetype-net-release.yml' }
    ) {
        $previousLazyFetch = $env:GIT_NO_LAZY_FETCH
        try {
            $env:GIT_NO_LAZY_FETCH = '1'
            $baselineText = @(git -C $script:repoRoot show "$($script:baseline):$Path")
            if ($LASTEXITCODE -ne 0) { throw "Pinned baseline unavailable: $Path" }
        }
        finally { $env:GIT_NO_LAZY_FETCH = $previousLazyFetch }
        $before = ($baselineText -join "`n") | ConvertFrom-Yaml
        $after = Get-Content -LiteralPath (Join-Path $script:repoRoot $Path) -Raw | ConvertFrom-Yaml
        if ($Index -lt 2) {
            $after.parameters = @($after.parameters | Where-Object name -ne 'ReleasePlanId')
            if ($Index -eq 0) { $after.extends.parameters.Remove('ReleasePlanId') }
            else {
                $call = @(Find-PipelineNode $after 'template' 'archetype-net-release.yml')[0]
                $call.parameters.Remove('ReleasePlanId')
            }
        }
        else {
            $after.parameters.Remove('ReleasePlanId')
            $stage = @(Find-PipelineNode $after 'stage' 'Release_${{artifact.safeName}}')[0]
            $stage.variables = @($stage.variables | Where-Object { -not $_.Contains($script:autoPilotCondition) })
            $call = @(Find-PipelineNode $after 'template' '/eng/common/pipelines/templates/steps/mark-release-completion.yml')[0]
            $call.parameters.Remove($script:pilotCondition)
        }
        # Whole-document equality protects signing, environments, eligibility, gates,
        # job/stage dependencies, artifacts, and all non-template behavior.
        $expected = ConvertTo-NormalizedNode $before | ConvertTo-Json -Depth 100 -Compress
        $actual = ConvertTo-NormalizedNode $after | ConvertTo-Json -Depth 100 -Compress
        $actual | Should -BeExactly $expected
    }
}
