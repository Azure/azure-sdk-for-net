# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

. (Join-Path $PSScriptRoot '../SampleTestPlanHelpers.ps1')

Describe 'Dynamic sample queue assignment' {
    It 'creates one billable worker for a single selected sample and wires discovery before provisioning' {
        $plan = New-SampleQueuePlan -Tests @(@{
            fullName = 'Azure.AI.Projects.Tests.Samples.Sample_AIAgents(False).AgentsBasics'
            name = 'AgentsBasics'
            package = 'Azure.AI.Projects'
        }) -QueueCount 4 -Pool pool -Image image
        @($plan.matrix.Keys).Count | Should Be 1
        $plan.matrix.Contains('q1') | Should Be $true
        $template = Get-Content -LiteralPath (Join-Path $PSScriptRoot '../sample-tests-stages.yml') -Raw
        $template | Should Match "dependsOn: Plan"
        $template | Should Match "Matrix: stageDependencies.Plan.Plan.outputs\['Discover.WorkerMatrix'\]"
        $template.IndexOf('Invalid or empty worker assignment.') |
            Should BeLessThan $template.IndexOf('- ${{ parameters.PreSteps }}')
    }

    It 'distributes <Count> samples across up to <Queues> queues without repeats or empty workers' -TestCases @(
        @{ Count = 6; Queues = 4; Sizes = '2,2,1,1' }
        @{ Count = 5; Queues = 4; Sizes = '2,1,1,1' }
        @{ Count = 2; Queues = 4; Sizes = '1,1' }
        @{ Count = 1; Queues = 4; Sizes = '1' }
        @{ Count = 6; Queues = 1; Sizes = '6' }
        @{ Count = 6; Queues = 2; Sizes = '3,3' }
        @{ Count = 6; Queues = 3; Sizes = '2,2,2' }
    ) {
        param($Count, $Queues, $Sizes)
        $tests = @(1..$Count | ForEach-Object { @{ fullName = "Sample(False).Test$_"; name = "Test$_"; package = 'unit' } })
        [Array]::Reverse($tests)
        $plan = New-SampleQueuePlan -Tests $tests -QueueCount $Queues -Pool unit-pool -Image unit-image
        $counts = @($plan.queues.Values | ForEach-Object { @($_.selectedTests).Count })
        ($counts -join ',') | Should BeExactly $Sizes
        $assigned = @($plan.queues.Values | ForEach-Object { $_.selectedTests } | ForEach-Object { $_.fullName })
        @($assigned | Sort-Object -Unique).Count | Should Be $Count
        $assigned.Count | Should Be $Count
        @($plan.queues.Keys).Count | Should Be ([Math]::Min($Count, $Queues))
        foreach ($queue in $plan.queues.Keys) {
            $plan.matrix[$queue].SampleQueueName | Should BeExactly $queue
            $plan.matrix[$queue].ContainsKey('AdditionalTestFilters') | Should Be $false
            $plan.matrix[$queue].TestTargetFramework | Should BeExactly 'net10.0'
        }
    }

    It 'sorts ordinal test IDs then assigns indices round-robin across package boundaries' {
        $tests = @('F', 'B', 'D', 'A', 'E', 'C') | ForEach-Object { @{ fullName = $_; name = $_ } }
        $plan = New-SampleQueuePlan -Tests $tests -QueueCount 4 -Pool pool -Image image
        ($plan.queues.q1.selectedTests.fullName -join ',') | Should BeExactly 'A,E'
        ($plan.queues.q2.selectedTests.fullName -join ',') | Should BeExactly 'B,F'
        ($plan.queues.q3.selectedTests.fullName -join ',') | Should BeExactly 'C'
        ($plan.queues.q4.selectedTests.fullName -join ',') | Should BeExactly 'D'
    }

    It 'escapes exact test IDs for VSTest rather than using overlapping substring filters' {
        $plan = New-SampleQueuePlan -Tests @(@{ fullName = 'Sample(False).Test'; name = 'Test' }) -Pool pool -Image image
        $plan.queues.q1.filter | Should BeExactly '(FullyQualifiedName=Sample\(False\).Test)'
    }

    It 'rejects duplicate IDs, empty IDs and invalid worker counts' {
        { New-SampleQueuePlan -Tests @(@{ fullName = 'A' }, @{ fullName = 'A' }) -Pool pool -Image image } |
            Should Throw 'unique test IDs'
        { New-SampleQueuePlan -Tests @(@{ fullName = '' }) -Pool pool -Image image } | Should Throw 'unique test IDs'
        { New-SampleQueuePlan -Tests @(@{ fullName = 'A' }) -QueueCount 5 -Pool pool -Image image } | Should Throw
        { New-SampleQueuePlan -Tests @() -Pool pool -Image image } | Should Throw
    }
}

Describe 'Sample selection filter evaluation' {
    It 'honors grouping, AND precedence, exclusions and case-insensitive comparison' {
        $test = @{ fullName = 'Namespace.Sample(False).Test'; name = 'Test' }
        foreach ($filter in @('Name=Test', 'Name=test', 'Name~es', 'Name!=Other', 'Name!~Other',
            '(Name=Other|Name=Test)&FullyQualifiedName~Sample', 'Name=Test|Name=Other&Name=Missing')) {
            Test-SampleSelection -Tree (ConvertTo-SampleSelectionTree $filter) -Test $test | Should Be $true
        }

        foreach ($filter in @('Name=Other', 'Name!=Test', 'Name!~es', '(Name=Test|Name=Other)&Name=Missing')) {
            Test-SampleSelection -Tree (ConvertTo-SampleSelectionTree $filter) -Test $test | Should Be $false
        }
    }
}

        Describe 'Worker assignment result verification' {
            BeforeEach {
                $script:results = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
                $null = New-Item -ItemType Directory -Path $script:results
                $script:manifest = Join-Path $TestDrive 'assignment.json'
                @{ selectedTests = @(@{ fullName = 'Namespace.Sample(False).Test' }) } |
                    ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $script:manifest
            }

            It 'accepts exactly one passing result for the assignment' {
                '<TestRun><TestDefinitions><UnitTest id="unit" name="Test"><TestMethod className="Namespace.Sample(False)" /></UnitTest></TestDefinitions><Results><UnitTestResult testId="unit" outcome="Passed" /></Results></TestRun>' |
                    Set-Content -LiteralPath (Join-Path $script:results 'unit.trx')
                & (Join-Path $PSScriptRoot '../Test-SampleAssignments.ps1') -ManifestPath $script:manifest -ResultsRoot $script:results
            }

            It 'rejects incomplete or repeated assignments: <Scenario>' -TestCases @(
                @{ Scenario = 'skipped'; Outcome = 'NotExecuted'; MethodName = 'Test'; Duplicate = $false }
                @{ Scenario = 'failed'; Outcome = 'Failed'; MethodName = 'Test'; Duplicate = $false }
                @{ Scenario = 'unassigned'; Outcome = 'Passed'; MethodName = 'Other'; Duplicate = $false }
                @{ Scenario = 'duplicate'; Outcome = 'Passed'; MethodName = 'Test'; Duplicate = $true }
            ) {
                param($Scenario, $Outcome, $MethodName, $Duplicate)
                $resultXml = "<UnitTestResult testId='unit' outcome='$Outcome' />"
                if ($Duplicate) { $resultXml += $resultXml }
                "<TestRun><TestDefinitions><UnitTest id='unit' name='$MethodName'><TestMethod className='Namespace.Sample(False)' /></UnitTest></TestDefinitions><Results>$resultXml</Results></TestRun>" |
                    Set-Content -LiteralPath (Join-Path $script:results 'unit.trx')
                { & (Join-Path $PSScriptRoot '../Test-SampleAssignments.ps1') -ManifestPath $script:manifest -ResultsRoot $script:results } |
                    Should Throw
            }

            It 'fails when no results or no assigned executions were produced' {
                { & (Join-Path $PSScriptRoot '../Test-SampleAssignments.ps1') -ManifestPath $script:manifest -ResultsRoot $script:results } |
                    Should Throw 'No TRX'
                '<TestRun><TestDefinitions /><Results /></TestRun>' | Set-Content -LiteralPath (Join-Path $script:results 'empty.trx')
                { & (Join-Path $PSScriptRoot '../Test-SampleAssignments.ps1') -ManifestPath $script:manifest -ResultsRoot $script:results } |
                    Should Throw 'did not execute'
            }
        }

Describe 'Sample selection filter validation' {
    It 'supports escaped parentheses in exact IDs' {
        $tree = ConvertTo-SampleSelectionTree 'FullyQualifiedName=Namespace.Sample\(False\).Test'
        Test-SampleSelection -Tree $tree -Test @{ fullName = 'Namespace.Sample(False).Test' } | Should Be $true
    }

    It 'fails explicitly on malformed or unsupported filters' {
        foreach ($filter in @('Name=', 'Name=Test&', '(Name=Test', 'Name=Test)', 'Priority=1', '|Name=Test')) {
            { ConvertTo-SampleSelectionTree $filter } | Should Throw
        }
    }
}
