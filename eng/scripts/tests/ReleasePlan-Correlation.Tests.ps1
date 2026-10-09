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

    # Assert the safety contract from checked-in nodes, not historical Git objects:
    # CI uses shallow checkouts and must not fetch a pre-pilot revision to run tests.
    It 'keeps template feed and approval overrides opt-in with the same artifact and triggers' {
        foreach ($name in @('ReleaseToDevOpsOnly', 'AutoApproveRelease')) {
            $parameter = @($script:entry.parameters | Where-Object name -eq $name)
            $parameter.Count | Should -Be 1
            $parameter[0].type | Should -BeExactly 'boolean'
            $parameter[0].default | Should -BeFalse
        }
        $script:entry.extends.template | Should -BeExactly '/eng/pipelines/templates/stages/archetype-sdk-client.yml'
        $parameters = $script:entry.extends.parameters
        $parameters.Contains('PublicFeed') | Should -BeFalse
        $parameters.Contains('PublicPublishEnvironment') | Should -BeFalse
        $parameters['${{ if eq(parameters.ReleaseToDevOpsOnly, ''true'') }}'].PublicFeed | Should -BeExactly 'public/storage-staging'
        $parameters['${{ if eq(parameters.AutoApproveRelease, ''true'') }}'].PublicPublishEnvironment | Should -BeExactly 'none'
        $parameters.ArtifactName | Should -BeExactly 'packages'
        $parameters.Artifacts[0].safeName | Should -BeExactly 'AzureTemplate'
        @($script:entry.trigger.branches.include) -join '|' | Should -BeExactly 'main|hotfix/*|release/*'
        @($script:entry.trigger.paths.include) -join '|' | Should -BeExactly 'sdk/template/|eng/common/'
    }

    It 'keeps client release eligibility, build dependency and non-template publish defaults' {
        $gate = '${{if and(not(and(eq(parameters.SkipPrValidation, true), eq(variables[''Build.Reason''], ''Manual''))), ne(variables[''Build.Reason''], ''PullRequest''), eq(variables[''System.TeamProject''], ''internal''))}}'
        $guarded = @($script:client.extends.parameters.stages | Where-Object { $_.Contains($gate) })
        $guarded.Count | Should -Be 1
        @(Find-PipelineNode $guarded[0][$gate] 'template' 'archetype-net-release.yml').Count | Should -Be 1
        $parameters = $script:releaseCalls[0].parameters
        @($parameters.DependsOn) -join '|' | Should -BeExactly 'Build'
        $parameters.ServiceDirectory | Should -BeExactly '${{ parameters.ServiceDirectory }}'
        $parameters.PublicFeed | Should -BeExactly '${{ parameters.PublicFeed }}'
        $parameters.PublicPublishEnvironment | Should -BeExactly '${{ parameters.PublicPublishEnvironment }}'
        $parameters.Contains('TestPipeline') | Should -BeFalse
        $parameters[$script:pilotCondition].TestPipeline | Should -BeTrue
        $artifacts = ConvertTo-NormalizedNode $parameters.Artifacts | ConvertTo-Json -Depth 10 -Compress
        $expected = @(@{ '${{ each artifact in parameters.Artifacts }}' = @(@{ '${{ if ne(artifact.createReleaseStage, ''false'') }}' = @('${{ artifact }}') }) })
        $artifacts | Should -BeExactly (ConvertTo-NormalizedNode $expected | ConvertTo-Json -Depth 10 -Compress)
        foreach ($contract in @(
            @{ Name = 'PublicFeed'; Default = 'Nuget.org' },
            @{ Name = 'PublicPublishEnvironment'; Default = 'package-publish' }
        )) {
            $parameter = @($script:client.parameters | Where-Object name -eq $contract.Name)
            $parameter.Count | Should -Be 1
            $parameter[0].default | Should -BeExactly $contract.Default
        }
    }

    It 'keeps signed publication, release gates and manual versus auto-release environments' {
        $safeCondition = 'and(succeeded(), ne(variables[''SetDevVersion''], ''true''), ne(variables[''Skip.Release''], ''true''), ne(variables[''Build.Repository.Name''], ''Azure/azure-sdk-for-net-pr''))'
        $internalAuto = '${{ if and(eq(variables[''Build.Reason''], ''IndividualCI''), eq(variables[''Build.SourceBranch''], ''refs/heads/main''), eq(variables[''System.TeamProject''], ''internal'')) }}'
        $releaseGate = '${{ if and(eq(variables[''System.TeamProject''], ''internal''), or(in(variables[''Build.Reason''], ''Manual'', ''''), and(eq(variables[''Build.Reason''], ''IndividualCI''), eq(variables[''Build.SourceBranch''], ''refs/heads/main'')))) }}'
        $guarded = @($script:release.stages | Where-Object { $_.Contains($releaseGate) })
        $guarded.Count | Should -Be 1
        $artifactLoop = $guarded[0][$releaseGate][0]['${{ each artifact in parameters.Artifacts }}']
        @(Find-PipelineNode $artifactLoop[0]['${{if ne(artifact.skipReleaseStage, ''true'')}}'] 'stage' 'Release_${{artifact.safeName}}').Count | Should -Be 1
        $prepare = @($script:release.stages | Where-Object { $_.Contains($internalAuto) })
        $prepare.Count | Should -Be 1
        $prepare[0][$internalAuto][0].template | Should -BeExactly '/eng/common/pipelines/templates/stages/archetype-auto-release-prepare.yml'
        @($prepare[0][$internalAuto][0].parameters.DependsOn) -join '|' | Should -BeExactly 'Signing'
        $prepare[0][$internalAuto][0].parameters.Condition | Should -BeExactly $safeCondition

        $signing = @(Find-PipelineNode $script:release 'stage' 'Signing')
        $signing.Count | Should -Be 1
        $signing[0].dependsOn | Should -BeExactly '${{parameters.DependsOn}}'
        $sign = @(Find-PipelineNode $signing[0] 'job' 'SignPackage')[0]
        $sign.templateContext.outputs[0].artifactName | Should -BeExactly '${{parameters.ArtifactName}}-signed'
        @(Find-PipelineNode $sign 'template' 'pipelines/steps/net-signing.yml@azure-sdk-build-tools').Count | Should -Be 1
        $stage = $script:releaseStages[0]
        $stage['${{ else }}'].condition | Should -BeExactly $safeCondition
        ($stage[$script:existingAutoCondition].condition -replace '\s', '') | Should -BeExactly ('and(succeeded(),ne(variables[''SetDevVersion''],''true''),ne(variables[''Skip.Release''],''true''),ne(variables[''Build.Repository.Name''],''Azure/azure-sdk-for-net-pr''),eq(dependencies.AutoReleasePrepare.outputs[''ResolveAutoReleasePackages.resolve.ReleaseArtifact_${{artifact.safeName}}''],''true''))')
        $publishGuard = @($stage.jobs | Where-Object { $_.Contains('${{if ne(artifact.skipPublishPackage, ''true'')}}') })
        $publishGuard.Count | Should -Be 1
        $publish = @(Find-PipelineNode $publishGuard[0]['${{if ne(artifact.skipPublishPackage, ''true'')}}'] 'deployment' 'PublishPackage')
        $publish.Count | Should -Be 1
        $publish[0].condition | Should -BeExactly 'and(succeeded(), ne(variables[''Skip.PublishPackage''], ''true''))'
        $publish[0].dependsOn | Should -BeExactly 'TagRepository'
        $publish[0].Contains('environment') | Should -BeFalse
        $publish[0][$internalAuto].environment | Should -BeExactly 'none'
        $publish[0]['${{ else }}'].environment | Should -BeExactly '${{ parameters.PublicPublishEnvironment }}'
        $publish[0].templateContext.inputs[0].artifactName | Should -BeExactly '${{parameters.ArtifactName}}-signed'
        $publish[0].templateContext.type | Should -BeExactly 'releaseJob'
        $publish[0].templateContext.isProduction | Should -BeTrue
        $pushes = @(Find-PipelineNode $publish[0] 'task' '1ES.PublishNuget@1')
        $pushes.Count | Should -Be 2
        $pushes[0].inputs.packagesToPush | Should -BeExactly '$(Pipeline.Workspace)/${{parameters.ArtifactName}}-signed/${{artifact.name}}/*.nupkg;!$(Pipeline.Workspace)//${{parameters.ArtifactName}}-signed/${{artifact.name}}/*.symbols.nupkg'
        $pushes[0].inputs['${{ if eq(parameters.PublicFeed, ''Nuget.org'') }}'].publishFeedCredentials | Should -BeExactly 'Nuget.org'
        $pushes[0].inputs['${{ if ne(parameters.PublicFeed, ''Nuget.org'') }}'].publishVstsFeed | Should -BeExactly '${{ parameters.PublicFeed }}'
        $pushes[1].inputs.packagesToPush | Should -BeExactly '$(Pipeline.Workspace)/${{parameters.ArtifactName}}-signed/${{artifact.name}}/*.nupkg;!$(Pipeline.Workspace)/${{parameters.ArtifactName}}-signed/${{artifact.name}}/*.symbols.nupkg'
        $pushes[1].inputs.publishVstsFeed | Should -BeExactly '${{ parameters.DevFeed }}'
        $uploads = @(Find-PipelineNode $stage 'job' 'UploadSymbols')
        $uploads[0].condition | Should -BeExactly 'and(succeeded(), ne(variables[''Skip.SymbolsUpload''], ''true''))'
        $completion = $script:completionCalls[0].parameters
        $completion.ConfigFileDir | Should -BeExactly '$(Pipeline.Workspace)/${{parameters.ArtifactName}}/PackageInfo'
        $completion.PackageArtifactName | Should -BeExactly '${{artifact.name}}'
        $completion.SourceRootPath | Should -BeExactly '$(sdk-repo-path)'
    }
}
