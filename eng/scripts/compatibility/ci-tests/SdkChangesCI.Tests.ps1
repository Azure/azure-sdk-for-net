#Requires -Version 7.0

BeforeAll {
    Set-StrictMode -Version 3
    . (Join-Path $PSScriptRoot '..' 'SdkChangesCI.Helpers.ps1')
    $fixtureDetector = Join-Path $PSScriptRoot 'fixtures' 'Detector.ps1'

    function New-CIRepository {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
        $info = Join-Path $root 'PackageInfo'
        $detector = Join-Path $root 'eng' 'scripts' 'compatibility' 'Get-SdkChanges.ps1'
        [void][System.IO.Directory]::CreateDirectory($info)
        [void][System.IO.Directory]::CreateDirectory((Split-Path $detector -Parent))
        Copy-Item -LiteralPath $fixtureDetector -Destination $detector
        [System.IO.File]::WriteAllText((Join-Path $root 'global.json'), '{"sdk":{"version":"10.0.400"}}')
        return @{ Root = $root; Info = $info; ReportRoot = Join-Path $root 'reports'; Detector = $detector }
    }

    function New-CIPackage {
        param([hashtable]$Repository, [string]$Name, [string]$ArtifactName = $Name, [bool]$Indirect = $false)
        $relativePath = Join-Path 'sdk' 'fixture' $Name
        [void][System.IO.Directory]::CreateDirectory((Join-Path $Repository.Root $relativePath))
        $info = @{ Name = $Name; ArtifactName = $ArtifactName; DirectoryPath = $relativePath; IncludedForValidation = $Indirect }
        Write-SdkChangesCIJson -Path (Join-Path $Repository.Info "$Name.json") -Value $info
        return $info
    }

    function New-CIRawReport {
        param([switch]$Breaking, [switch]$NoGa)
        return [ordered]@{
            changes = "### Breaking Changes`nFixture`n### Features Added`nNone."
            hasBreakingChange = [bool]$Breaking
            details = [ordered]@{
                baselineVersion = $(if ($NoGa) { $null } else { '1.0.0' })
                apiChanges = @($(if ($Breaking) {
                    @{ kind = 'removed'; symbol = 'Example.Removed()'; description = 'Native removal'; isBreaking = $true; diagnosticId = 'CP0002'; targetFramework = 'net8.0' }
                }))
                diagnostics = @('Native diagnostic')
                limitations = @($(if ($NoGa) { 'No GA baseline exists; no comparison was performed.' }))
            }
        }
    }

    function Invoke-CICollection {
        param([hashtable]$Repository, [AllowEmptyString()][string]$Names, [string]$Previous = 'Succeeded')
        Invoke-SdkChangesCICollection -SdkRepoPath $Repository.Root -PackageInfoDirectory $Repository.Info `
            -ProjectNames $Names -ReportRoot $Repository.ReportRoot -PreviousJobStatus $Previous
    }
}

Describe 'SDK CI package selection' -Tag 'UnitTest' {
    BeforeEach { $repo = New-CIRepository }

    It 'normalizes the existing comma-separated ProjectNames without selecting every PackageInfo file' {
        New-CIPackage $repo 'Azure.One' | Out-Null
        New-CIPackage $repo 'Azure.Two' | Out-Null
        $names = @(Get-SdkChangesCIProjectNames ' Azure.One,Azure.One,azure.one, ')
        $names | Should -Be @('Azure.One')
        $selection = Get-SdkChangesCISelection $repo.Root $repo.Info $names
        $selection.Packages.Count | Should -Be 1
        $selection.Packages[0].packageName | Should -Be 'Azure.One'
        $selection.Packages[0].error | Should -BeNullOrEmpty
    }

    It 'matches ArtifactName when it differs from Name' {
        New-CIPackage $repo 'internal-name' 'Azure.Special' | Out-Null
        $selection = Get-SdkChangesCISelection $repo.Root $repo.Info @('Azure.Special')
        $selection.Packages[0].packageName | Should -Be 'internal-name'
        $selection.Packages[0].error | Should -BeNullOrEmpty
    }

    It 'keeps indirect validation packages when the build selected them' {
        New-CIPackage $repo 'Azure.Indirect' -Indirect $true | Out-Null
        (Get-SdkChangesCISelection $repo.Root $repo.Info @('Azure.Indirect')).Packages.Count | Should -Be 1
    }

    It 'reports missing selected metadata rather than silently skipping the package' {
        $entry = (Get-SdkChangesCISelection $repo.Root $repo.Info @('Azure.Missing')).Packages[0]
        $entry.error | Should -Match 'found 0'
    }

    It 'reports ambiguous metadata rather than picking the first match' {
        New-CIPackage $repo 'Azure.One' | Out-Null
        $nested = Join-Path $repo.Info 'nested'
        [void][System.IO.Directory]::CreateDirectory($nested)
        Copy-Item -LiteralPath (Join-Path $repo.Info 'Azure.One.json') -Destination $nested
        (Get-SdkChangesCISelection $repo.Root $repo.Info @('Azure.One')).Packages[0].error | Should -Match 'found 2'
    }

    It 'reports malformed selected metadata and continues selecting other packages' {
        New-CIPackage $repo 'Azure.One' | Out-Null
        [System.IO.File]::WriteAllText((Join-Path $repo.Info 'Azure.Bad.json'), '{invalid')
        $selection = Get-SdkChangesCISelection $repo.Root $repo.Info @('Azure.One', 'Azure.Bad')
        @($selection.Packages | Where-Object { $_.error }).Count | Should -Be 1
        @($selection.Packages | Where-Object { !$_.error }).Count | Should -Be 1
    }

    It 'records unreadable unselected metadata without attributing its failure to a selected package' {
        New-CIPackage $repo 'Azure.One' | Out-Null
        [System.IO.File]::WriteAllText((Join-Path $repo.Info 'Other.json'), 'not-json')
        $selection = Get-SdkChangesCISelection $repo.Root $repo.Info @('Azure.One')
        $selection.Packages[0].error | Should -BeNullOrEmpty
        $selection.Warnings.Count | Should -Be 1
    }

    It 'rejects missing package paths' {
        $info = New-CIPackage $repo 'Azure.One'
        $info.DirectoryPath = 'sdk\missing\Azure.One'
        Write-SdkChangesCIJson (Join-Path $repo.Info 'Azure.One.json') $info
        (Get-SdkChangesCISelection $repo.Root $repo.Info @('Azure.One')).Packages[0].error | Should -Match 'directory is missing'
    }

    It 'rejects metadata paths that escape the SDK checkout' {
        $info = New-CIPackage $repo 'Azure.One'
        $info.DirectoryPath = '..\outside'
        Write-SdkChangesCIJson (Join-Path $repo.Info 'Azure.One.json') $info
        (Get-SdkChangesCISelection $repo.Root $repo.Info @('Azure.One')).Packages[0].error | Should -Match 'outside'
    }

    It 'rejects missing DirectoryPath data' {
        New-CIPackage $repo 'Azure.One' | Out-Null
        Write-SdkChangesCIJson (Join-Path $repo.Info 'Azure.One.json') @{ Name = 'Azure.One' }
        (Get-SdkChangesCISelection $repo.Root $repo.Info @('Azure.One')).Packages[0].error | Should -Match 'Name and DirectoryPath'
    }

    It 'fails explicitly if PackageInfo is unavailable' {
        { Get-SdkChangesCISelection $repo.Root (Join-Path $repo.Root 'missing-info') @('Azure.One') } | Should -Throw '*PackageInfo directory is missing*'
    }

    It 'rejects unresolved or unsafe selection <Name>' -TestCases @(
        @{ Name = '$(ProjectNames)' }, @{ Name = '..\outside' }, @{ Name = 'a/b' },
        @{ Name = 'a;Write-Host bad' }, @{ Name = 'CON' }, @{ Name = 'NUL.json' }
    ) {
        param($Name)
        { Get-SdkChangesCIProjectNames $Name } | Should -Throw '*Invalid or unresolved*'
    }

    It 'represents an empty selected package list explicitly' {
        @(Get-SdkChangesCIProjectNames '').Count | Should -Be 0
        (Get-SdkChangesCISelection $repo.Root $repo.Info @()).Packages.Count | Should -Be 0
    }
}

Describe 'SDK CI runtime prerequisites' -Tag 'UnitTest' {
    BeforeEach { $repo = New-CIRepository }

    It 'records the actual PowerShell executable and runtime, not just the installed SDK' {
        $runtime = Get-SdkChangesCIRuntime $repo.Root
        $runtime.powerShellVersion | Should -Be $PSVersionTable.PSVersion.ToString()
        $runtime.runtimeVersion | Should -Be ([System.Environment]::Version.ToString())
        Test-Path -LiteralPath $runtime.executable -PathType Leaf | Should -BeTrue
        $runtime.sdkVersion | Should -Be '10.0.400'
        $runtime.supported | Should -Be ([System.Environment]::Version.Major -ge 10)
    }

    It 'explains an SDK/runtime mismatch instead of assuming UseDotNet upgraded pwsh' {
        $major = [System.Environment]::Version.Major + 1
        Write-SdkChangesCIJson (Join-Path $repo.Root 'global.json') @{ sdk = @{ version = "$major.0.100" } }
        $runtime = Get-SdkChangesCIRuntime $repo.Root
        $runtime.supported | Should -BeFalse
        $runtime.error | Should -Match 'Installing the .NET SDK does not upgrade pwsh'
    }

    It 'reports missing or invalid SDK metadata' -TestCases @(
        @{ Content = '{}' }, @{ Content = '{invalid' }, @{ Content = '{"sdk":{"version":"invalid"}}' }
    ) {
        param($Content)
        [System.IO.File]::WriteAllText((Join-Path $repo.Root 'global.json'), $Content)
        $runtime = Get-SdkChangesCIRuntime $repo.Root
        $runtime.supported | Should -BeFalse
        $runtime.error | Should -Not -BeNullOrEmpty
    }
}

Describe 'SDK CI native report semantics' -Tag 'UnitTest' {
    It 'distinguishes compatible, breaking, and no-GA outcomes' {
        Get-SdkChangesCIRawStatus (New-CIRawReport) | Should -Be 'compatible'
        Get-SdkChangesCIRawStatus (New-CIRawReport -Breaking) | Should -Be 'breaking_changes'
        Get-SdkChangesCIRawStatus (New-CIRawReport -NoGa) | Should -Be 'not_applicable'
    }

    It 'rejects malformed common contract field <Field>' -TestCases @(
        @{ Field = 'hasBreakingChange'; Value = 'false' },
        @{ Field = 'changes'; Value = 1 },
        @{ Field = 'details'; Value = @() }
    ) {
        param($Field, $Value)
        $raw = New-CIRawReport
        $raw[$Field] = $Value
        { Get-SdkChangesCIRawStatus $raw } | Should -Throw '*common changes/hasBreakingChange/details contract*'
    }

    It 'rejects non-array details.<Field>' -TestCases @(
        @{ Field = 'apiChanges' }, @{ Field = 'diagnostics' }, @{ Field = 'limitations' }
    ) {
        param($Field)
        $raw = New-CIRawReport
        $raw.details[$Field] = $null
        { Get-SdkChangesCIRawStatus $raw } | Should -Throw '*must be an array*'
    }

    It 'rejects invalid baseline metadata' {
        $raw = New-CIRawReport
        $raw.details.baselineVersion = ' '
        { Get-SdkChangesCIRawStatus $raw } | Should -Throw '*baselineVersion*'
    }

    It 'rejects a no-GA success-shaped report with a breaking verdict' {
        $raw = New-CIRawReport -NoGa -Breaking
        { Get-SdkChangesCIRawStatus $raw } | Should -Throw '*no-GA report*'
    }

    It 'requires no-GA limitations to explain that comparison was not performed' {
        $raw = New-CIRawReport -NoGa
        $raw.details.limitations = @()
        { Get-SdkChangesCIRawStatus $raw } | Should -Throw '*no-GA report*'
        $raw.details.limitations = @(' ')
        { Get-SdkChangesCIRawStatus $raw } | Should -Throw '*no-GA report*'
    }

    It 'rejects a false top-level verdict contradicted by native breaking API evidence' {
        $raw = New-CIRawReport -Breaking
        $raw.hasBreakingChange = $false
        { Get-SdkChangesCIRawStatus $raw } | Should -Throw '*contradicts*'
    }

    It 'rejects invalid structured changes' {
        $raw = New-CIRawReport -Breaking
        $raw.details.apiChanges[0].isBreaking = 'true'
        { Get-SdkChangesCIRawStatus $raw } | Should -Throw '*invalid structured API change*'
    }
}

Describe 'SDK CI multi-package collection and enforcement' -Tag 'UnitTest' {
    BeforeEach {
        $repo = New-CIRepository
        Mock Set-PipelineVariable {}
        Mock LogInfo {}
        Mock LogWarning {}
        Mock Get-SdkChangesCIRuntime {
            @{ supported = $true; executable = (Get-Process -Id $PID).Path; error = $null; powerShellVersion = '7.6.5'; runtimeVersion = '10.0.11'; sdkVersion = '10.0.400' }
        }
        Mock Invoke-SdkChangesCIProcess {
            param($PackagePath, $OutputJsonFile)
            $name = Split-Path $PackagePath -Leaf
            if ($name -eq 'Stale') { return @{ ExitCode = 12; TimedOut = $false; StdOut = ''; StdErr = 'Current assembly is stale.' } }
            if ($name -eq 'MissingAssembly') { return @{ ExitCode = 14; TimedOut = $false; StdOut = ''; StdErr = 'Current assembly is missing.' } }
            if ($name -eq 'Missing') { return @{ ExitCode = 0; TimedOut = $false; StdOut = ''; StdErr = '' } }
            if ($name -eq 'Timeout') { return @{ ExitCode = 137; TimedOut = $true; StdOut = ''; StdErr = 'Timeout' } }
            if ($name -eq 'Malformed') {
                [System.IO.File]::WriteAllText($OutputJsonFile, '{invalid')
            }
            else {
                Write-SdkChangesCIJson $OutputJsonFile (New-CIRawReport -Breaking:($name -in @('Breaking', 'Partial')) -NoGa:($name -eq 'NoGa'))
            }
            return @{ ExitCode = $(if ($name -eq 'Partial') { 13 } else { 0 }); TimedOut = $false; StdOut = 'Native output'; StdErr = '' }
        }
    }

    It 'collects every selected package despite native failures and distinguishes all verdicts' {
        $names = @('Compatible', 'Breaking', 'NoGa', 'Stale', 'Missing', 'Partial', 'Malformed', 'Timeout')
        foreach ($name in $names) { New-CIPackage $repo $name | Out-Null }
        $result = Invoke-CICollection $repo ($names -join ',') 'Failed'
        $result.Summary.counts.selected | Should -Be 8
        $result.Summary.counts.compatible | Should -Be 1
        $result.Summary.counts.breakingChanges | Should -Be 1
        $result.Summary.counts.notApplicable | Should -Be 1
        $result.Summary.counts.detectorErrors | Should -Be 5
        $result.Summary.previousJobStatus | Should -Be 'Failed'
        Should -Invoke Invoke-SdkChangesCIProcess -Times 8 -Exactly
        $verdict = Test-SdkChangesCIReports $result.Directory ($names -join ',')
        $verdict.Passed | Should -BeFalse
        $verdict.Errors.Count | Should -Be 6
    }

    It 'treats exit0 with hasBreakingChange=true as a failing compatibility verdict' {
        New-CIPackage $repo 'Breaking' | Out-Null
        $result = Invoke-CICollection $repo 'Breaking'
        $result.Summary.packages[0].detectorExitCode | Should -Be 0
        $result.Summary.packages[0].status | Should -Be 'breaking_changes'
        (Test-SdkChangesCIReports $result.Directory 'Breaking').Passed | Should -BeFalse
    }

    It 'does not call no-GA compatible, but permits a first-release PR' {
        New-CIPackage $repo 'NoGa' | Out-Null
        $result = Invoke-CICollection $repo 'NoGa'
        $result.Summary.packages[0].status | Should -Be 'not_applicable'
        $verdict = Test-SdkChangesCIReports $result.Directory 'NoGa'
        $verdict.Passed | Should -BeTrue
        $verdict.Counts.compatible | Should -Be 0
        $verdict.Counts.notApplicable | Should -Be 1
        Should -Invoke LogWarning -Times 1 -ParameterFilter { "$args" -match 'compatibility was not evaluated' }
    }

    It 'preserves other failed validation gates independently from API compatibility' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $result = Invoke-CICollection $repo 'Compatible' 'Failed'
        $result.Summary.packages[0].hasBreakingChange | Should -BeFalse
        $result.Summary.previousJobStatus | Should -Be 'Failed'
        $verdict = Test-SdkChangesCIReports $result.Directory 'Compatible'
        $verdict.Passed | Should -BeTrue
        $verdict.PreviousJobStatus | Should -Be 'Failed'
    }

    It 'preserves valid native JSON byte-for-byte, including additive details' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $raw = New-CIRawReport
        $raw.details.additionalEvidence = @{ retained = $true }
        $text = "`r`n" + ($raw | ConvertTo-Json -Depth 10) + "`r`n"
        Mock Invoke-SdkChangesCIProcess {
            param($OutputJsonFile)
            [System.IO.File]::WriteAllText($OutputJsonFile, $text)
            @{ ExitCode = 0; TimedOut = $false; StdOut = ''; StdErr = '' }
        }
        $result = Invoke-CICollection $repo 'Compatible'
        $path = Join-Path $result.Directory $result.Summary.packages[0].reportFile
        [System.IO.File]::ReadAllText($path) | Should -Be $text
        (Read-SdkChangesCIJson $path).details.additionalEvidence.retained | Should -BeTrue
    }

    It 'records portable artifact paths for downstream replay while invoking the detector with absolute paths' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $result = Invoke-CICollection $repo 'Compatible'
        $package = $result.Summary.packages[0]
        $package.packagePath | Should -Be 'sdk/fixture/Compatible'
        $package.reportFile | Should -Be 'Compatible/sdk-changes.json'
        Should -Invoke Invoke-SdkChangesCIProcess -Times 1 -Exactly -ParameterFilter {
            [System.IO.Path]::IsPathFullyQualified($PackagePath) -and
            [System.IO.Path]::IsPathFullyQualified($SdkRepoPath) -and
            [System.IO.Path]::IsPathFullyQualified($OutputJsonFile)
        }
    }

    It 'quarantines partial reports from failed processes rather than publishing them as replayable native results' {
        New-CIPackage $repo 'Partial' | Out-Null
        $result = Invoke-CICollection $repo 'Partial'
        $package = $result.Summary.packages[0]
        $package.status | Should -Be 'detector_error'
        $package.hasBreakingChange | Should -BeNullOrEmpty
        $package.reportFile | Should -BeNullOrEmpty
        Test-Path -LiteralPath (Join-Path $result.Directory 'Partial' 'sdk-changes.json') | Should -BeFalse
        Test-Path -LiteralPath (Join-Path $result.Directory $package.failedReportFile) | Should -BeTrue
        (Read-SdkChangesCIJson (Join-Path $result.Directory $package.errorFile)).detectorExitCode | Should -Be 13
    }

    It 'preserves <Package> diagnostics in per-package logs and error JSON' -TestCases @(
        @{ Package = 'Stale'; Message = 'Current assembly is stale' },
        @{ Package = 'MissingAssembly'; Message = 'Current assembly is missing' }
    ) {
        param($Package, $Message)
        New-CIPackage $repo $Package | Out-Null
        $result = Invoke-CICollection $repo $Package
        Get-Content -LiteralPath (Join-Path $result.Directory $Package 'detector.stderr.log') -Raw | Should -Match $Message
        $errorReport = Read-SdkChangesCIJson (Join-Path $result.Directory $Package 'error.json')
        $errorReport.status | Should -Be 'detector_error'
        $errorReport.message | Should -Match $Message
    }

    It 'records process start failures without skipping subsequent packages' {
        New-CIPackage $repo 'Compatible' | Out-Null
        New-CIPackage $repo 'Failure' | Out-Null
        Mock Invoke-SdkChangesCIProcess { throw [System.ComponentModel.Win32Exception]::new('Cannot start pwsh') } `
            -ParameterFilter { (Split-Path $PackagePath -Leaf) -eq 'Failure' }
        $result = Invoke-CICollection $repo 'Failure,Compatible'
        $result.Summary.counts.compatible | Should -Be 1
        $result.Summary.counts.detectorErrors | Should -Be 1
    }

    It 'publishes explicit prerequisite errors and never invokes an incompatible PowerShell runtime' {
        New-CIPackage $repo 'Compatible' | Out-Null
        Mock Get-SdkChangesCIRuntime { @{ supported = $false; error = 'PowerShell uses .NET8; SDK requires .NET10'; executable = 'unused' } }
        $result = Invoke-CICollection $repo 'Compatible'
        $result.Summary.runtime.supported | Should -BeFalse
        $result.Summary.packages[0].error | Should -Match 'SDK requires'
        Test-Path -LiteralPath (Join-Path $result.Directory 'Compatible' 'error.json') | Should -BeTrue
        Should -Invoke Invoke-SdkChangesCIProcess -Times 0 -Exactly
        (Test-SdkChangesCIReports $result.Directory 'Compatible').Passed | Should -BeFalse
    }

    It 'reports a missing native script as a detector prerequisite failure' {
        New-CIPackage $repo 'Compatible' | Out-Null
        Remove-Item -LiteralPath $repo.Detector
        $result = Invoke-CICollection $repo 'Compatible'
        $result.Summary.errors -join ' ' | Should -Match 'detector script is missing'
        Should -Invoke Invoke-SdkChangesCIProcess -Times 0 -Exactly
    }

    It 'writes a summary for a missing PackageInfo directory rather than returning compatible' {
        $repo.Info = Join-Path $repo.Root 'missing'
        $result = Invoke-CICollection $repo 'Compatible'
        $result.Summary.errors.Count | Should -Be 1
        (Test-SdkChangesCIReports $result.Directory 'Compatible').Passed | Should -BeFalse
    }

    It 'reports selected-package metadata errors and still processes other valid packages' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $result = Invoke-CICollection $repo 'Compatible,NoMetadata'
        $result.Summary.counts.compatible | Should -Be 1
        $result.Summary.counts.detectorErrors | Should -Be 1
        Test-Path -LiteralPath (Join-Path $result.Directory 'NoMetadata' 'error.json') | Should -BeTrue
        Should -Invoke Invoke-SdkChangesCIProcess -Times 1 -Exactly
        (Test-SdkChangesCIReports $result.Directory 'Compatible,NoMetadata').Passed | Should -BeFalse
    }

    It 'publishes an explicit empty selection without inventing a compatibility result' {
        $result = Invoke-CICollection $repo ''
        $result.Summary.counts.selected | Should -Be 0
        $result.Summary.counts.compatible | Should -Be 0
        (Test-SdkChangesCIReports $result.Directory '').Passed | Should -BeTrue
        Should -Invoke Invoke-SdkChangesCIProcess -Times 0 -Exactly
    }

    It 'uses a fresh report directory for every attempt and never reuses stale raw output' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $first = Invoke-CICollection $repo 'Compatible'
        Mock Invoke-SdkChangesCIProcess { @{ ExitCode = 1; TimedOut = $false; StdOut = ''; StdErr = 'Failed' } }
        $second = Invoke-CICollection $repo 'Compatible'
        $second.Directory | Should -Not -Be $first.Directory
        Test-Path -LiteralPath (Join-Path $second.Directory 'Compatible' 'sdk-changes.json') | Should -BeFalse
        Should -Invoke Set-PipelineVariable -Times 1 -Exactly -ParameterFilter { $Value -eq $second.Directory }
    }

    It 'fails enforcement if the raw report was changed after collection' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $result = Invoke-CICollection $repo 'Compatible'
        Write-SdkChangesCIJson (Join-Path $result.Directory 'Compatible' 'sdk-changes.json') (New-CIRawReport -Breaking)
        $verdict = Test-SdkChangesCIReports $result.Directory 'Compatible'
        $verdict.Passed | Should -BeFalse
        $verdict.Errors -join ' ' | Should -Match 'modified after collection'
    }

    It 'fails enforcement if the summary contradicts the unchanged raw verdict' {
        New-CIPackage $repo 'Breaking' | Out-Null
        $result = Invoke-CICollection $repo 'Breaking'
        $result.Summary.packages[0].status = 'compatible'
        $result.Summary.packages[0].hasBreakingChange = $false
        Write-SdkChangesCIJson (Join-Path $result.Directory 'summary.json') $result.Summary
        $verdict = Test-SdkChangesCIReports $result.Directory 'Breaking'
        $verdict.Passed | Should -BeFalse
        $verdict.Errors -join ' ' | Should -Match 'contradicts'
    }

    It 'fails enforcement when collected raw evidence is missing' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $result = Invoke-CICollection $repo 'Compatible'
        Remove-Item -LiteralPath (Join-Path $result.Directory 'Compatible' 'sdk-changes.json')
        $verdict = Test-SdkChangesCIReports $result.Directory 'Compatible'
        $verdict.Passed | Should -BeFalse
        $verdict.Errors -join ' ' | Should -Match 'report is missing'
    }

    It 'does not read raw evidence outside the report directory' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $result = Invoke-CICollection $repo 'Compatible'
        $result.Summary.packages[0].reportFile = '..\outside.json'
        Write-SdkChangesCIJson (Join-Path $result.Directory 'summary.json') $result.Summary
        $verdict = Test-SdkChangesCIReports $result.Directory 'Compatible'
        $verdict.Passed | Should -BeFalse
        $verdict.Errors -join ' ' | Should -Match 'outside'
    }

    It 'fails enforcement on unknown or unsuccessful recorded outcomes' -TestCases @(
        @{ Status = 'unknown'; ExitCode = 0; TimedOut = $false },
        @{ Status = 'compatible'; ExitCode = 1; TimedOut = $false },
        @{ Status = 'compatible'; ExitCode = 0; TimedOut = $true }
    ) {
        param($Status, $ExitCode, $TimedOut)
        New-CIPackage $repo 'Compatible' | Out-Null
        $result = Invoke-CICollection $repo 'Compatible'
        $result.Summary.packages[0].status = $Status
        $result.Summary.packages[0].detectorExitCode = $ExitCode
        $result.Summary.packages[0].timedOut = $TimedOut
        Write-SdkChangesCIJson (Join-Path $result.Directory 'summary.json') $result.Summary
        (Test-SdkChangesCIReports $result.Directory 'Compatible').Passed | Should -BeFalse
    }

    It 'fails closed on missing or invalid summary files' {
        { Test-SdkChangesCIReports $repo.ReportRoot 'Compatible' } | Should -Throw
        [void][System.IO.Directory]::CreateDirectory($repo.ReportRoot)
        Write-SdkChangesCIJson (Join-Path $repo.ReportRoot 'summary.json') @{ schemaVersion = 999 }
        { Test-SdkChangesCIReports $repo.ReportRoot 'Compatible' } | Should -Throw '*Invalid SDK API CI report summary*'
    }

    It 'rejects a summary from a different package selection' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $result = Invoke-CICollection $repo 'Compatible'
        { Test-SdkChangesCIReports $result.Directory 'Another' } | Should -Throw '*ProjectNames selection*'
    }

    It 'fails enforcement when a selected package report is missing from the summary' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $result = Invoke-CICollection $repo 'Compatible'
        $result.Summary.packages = @()
        Write-SdkChangesCIJson (Join-Path $result.Directory 'summary.json') $result.Summary
        (Test-SdkChangesCIReports $result.Directory 'Compatible').Passed | Should -BeFalse
    }
}

Describe 'SDK CI actual child process boundary' -Tag 'IntegrationTest' {
    BeforeEach { $repo = New-CIRepository }

    It 'preserves SDK NuGet configuration and inherited feed authentication/cache context' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $configPath = Join-Path $repo.Root 'NuGet.Config'
        [System.IO.File]::WriteAllText($configPath, '<configuration><packageSources><clear /><add key="SDK feed" value="https://pkgs.dev.azure.com/example/sdk/_packaging/sdk/nuget/v3/index.json" /></packageSources></configuration>')
        $configHash = (Get-FileHash -LiteralPath $configPath).Hash
        $oldPackages = $env:NUGET_PACKAGES
        $oldAuthentication = $env:VSS_NUGET_ACCESSTOKEN
        try {
            $env:NUGET_PACKAGES = Join-Path $repo.Root 'existing-package-cache'
            $env:VSS_NUGET_ACCESSTOKEN = 'synthetic-ci-fixture-not-a-real-token'
            $result = Invoke-CICollection $repo 'Compatible'
            $raw = Read-SdkChangesCIJson (Join-Path $result.Directory 'Compatible' 'sdk-changes.json')
            $raw.details.diagnostics | Should -Contain "WorkingDirectory=$($repo.Root)"
            $raw.details.diagnostics | Should -Contain "NuGetPackages=$env:NUGET_PACKAGES"
            $raw.details.diagnostics | Should -Contain 'NuGetAuthenticationPresent=True'
            $raw.details.diagnostics -join "`n" | Should -Not -Match 'synthetic-ci-fixture'
            (Get-FileHash -LiteralPath $configPath).Hash | Should -Be $configHash
        }
        finally {
            $env:NUGET_PACKAGES = $oldPackages
            $env:VSS_NUGET_ACCESSTOKEN = $oldAuthentication
        }
    }

    It 'uses named absolute paths, Release, and no inherited single-TFM override' {
        New-CIPackage $repo 'Compatible' | Out-Null
        $oldConfiguration = $env:Configuration
        $oldFramework = $env:TargetFramework
        $oldFrameworks = $env:TargetFrameworks
        try {
            $env:Configuration = 'Debug'
            $env:TargetFramework = 'net8.0'
            $env:TargetFrameworks = 'net8.0;net10.0'
            $result = Invoke-CICollection $repo 'Compatible'
            $raw = Read-SdkChangesCIJson (Join-Path $result.Directory 'Compatible' 'sdk-changes.json')
            $raw.details.diagnostics | Should -Contain 'Configuration=Release'
            $raw.details.diagnostics | Should -Contain 'TargetFramework='
            $raw.details.diagnostics | Should -Contain 'TargetFrameworks='
            $raw.details.diagnostics | Should -Contain "SdkRepoPath=$($repo.Root)"
            $env:Configuration | Should -Be 'Debug'
            $env:TargetFramework | Should -Be 'net8.0'
        }
        finally {
            $env:Configuration = $oldConfiguration
            $env:TargetFramework = $oldFramework
            $env:TargetFrameworks = $oldFrameworks
        }
    }

    It 'enforces a real child-process timeout and records an explicit error' {
        New-CIPackage $repo 'Timeout' | Out-Null
        $result = Invoke-SdkChangesCICollection -SdkRepoPath $repo.Root -PackageInfoDirectory $repo.Info `
            -ProjectNames 'Timeout' -ReportRoot $repo.ReportRoot -TimeoutSeconds 1
        $result.Summary.packages[0].timedOut | Should -BeTrue
        $result.Summary.packages[0].status | Should -Be 'detector_error'
    }

    It 'defers the collector exit code in ReportOnly mode but the final CI assertion rejects breaks' {
        New-CIPackage $repo 'Breaking' | Out-Null
        $collector = Join-Path $PSScriptRoot '..' 'Invoke-SdkChangesCI.ps1'
        $assertion = Join-Path $PSScriptRoot '..' 'Assert-SdkChangesCI.ps1'
        & pwsh -NoProfile -File $collector -SdkRepoPath $repo.Root -PackageInfoDirectory $repo.Info `
            -ProjectNames Breaking -ReportRoot $repo.ReportRoot -ReportOnly | Out-Null
        $LASTEXITCODE | Should -Be 0
        $directory = @(Get-ChildItem -LiteralPath $repo.ReportRoot -Directory)[0].FullName
        (Read-SdkChangesCIJson (Join-Path $directory 'summary.json')).packages[0].status | Should -Be 'breaking_changes'
        & pwsh -NoProfile -File $assertion -ReportDirectory $directory -ProjectNames Breaking | Out-Null
        $LASTEXITCODE | Should -Be 1
    }

    It 'returns a failing exit code for direct runner use with detector errors' {
        New-CIPackage $repo 'Stale' | Out-Null
        & pwsh -NoProfile -File (Join-Path $PSScriptRoot '..' 'Invoke-SdkChangesCI.ps1') `
            -SdkRepoPath $repo.Root -PackageInfoDirectory $repo.Info -ProjectNames Stale -ReportRoot $repo.ReportRoot | Out-Null
        $LASTEXITCODE | Should -Be 1
    }
}
