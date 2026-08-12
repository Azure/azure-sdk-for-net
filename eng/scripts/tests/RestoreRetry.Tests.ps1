#Requires -Version 7.0
<#
.SYNOPSIS
    Unit tests for Invoke-WithRestoreRetry in RestoreRetry.Helpers.ps1.

.DESCRIPTION
    Covers which failures are retried, which are allowed to fail immediately, the attempt
    limit, clearing of the NuGet http cache between attempts, and how transient failures are
    reported to Azure DevOps while retries remain.

.How-To-Run
    Run these tests (Pester is installed automatically via PSModule-Helpers):
        Invoke-Pester -Output Detailed $PSScriptRoot/RestoreRetry.Tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

BeforeAll {
    . "$PSScriptRoot/../RestoreRetry.Helpers.ps1"

    # Stands in for the restore command: prints the given output and fails the first $FailTimes
    # invocations, tracking how many times it ran.
    $script:fakeRestore = Join-Path $TestDrive "fake-restore.ps1"
    Set-Content -Path $script:fakeRestore -Value @'
param([string]$CounterFile, [int]$FailTimes, [string]$Message)
$attempt = 1
if (Test-Path $CounterFile) { $attempt = [int](Get-Content $CounterFile) + 1 }
Set-Content -Path $CounterFile -Value $attempt
Write-Output "  Determining projects to restore..."
if ($attempt -le $FailTimes) {
    Write-Output $Message
    exit 1
}
Write-Output "  Restored fake.csproj (in 100 ms)."
exit 0
'@

    function New-CounterFile {
        Join-Path $TestDrive "attempts-$([guid]::NewGuid().ToString('N')).txt"
    }

    function Get-AttemptCount([string] $counterFile) {
        if (Test-Path $counterFile) { [int](Get-Content $counterFile) } else { 0 }
    }

    function Invoke-FakeRestore {
        param(
            [string] $CounterFile,
            [int] $FailTimes,
            [string] $Message,
            [switch] $MsBuildLogging
        )

        $command = "pwsh -NoProfile -File `"$script:fakeRestore`" -CounterFile `"$CounterFile`" -FailTimes $FailTimes -Message `"$Message`""
        Invoke-WithRestoreRetry -Command $command -RetryDelaySeconds 0 -MsBuildLogging:$MsBuildLogging
    }

    $script:transientError = "C:\r\p.csproj : error NU1103: Unable to find a stable package Microsoft.NET.ILLink.Tasks with version (>= 10.0.11)"
    $script:compilerError = "C:\r\P.cs(10,5): error CS0103: The name 'x' does not exist in the current context"
}

Describe "Invoke-WithRestoreRetry" -Tag "UnitTest" {

    BeforeAll {
        # Keeps the retry path from wiping the real http cache, and lets the tests observe it.
        Mock Clear-NuGetHttpCache { }
    }

    Context "recognizing a transient restore failure" {

        It "detects the pattern in the captured output collection" {
            # The retry decision tests the whole captured output, not one line at a time, so the
            # collection type has to work with -match.
            $output = [System.Collections.Generic.List[string]]::new()
            $output.Add("  Determining projects to restore...")
            $output.Add($script:transientError)

            [bool]($output -match $TransientRestoreErrorPattern) | Should -BeTrue
        }

        It "does not detect the pattern when the output holds an unrelated error" {
            $output = [System.Collections.Generic.List[string]]::new()
            $output.Add($script:compilerError)

            [bool]($output -match $TransientRestoreErrorPattern) | Should -BeFalse
        }

        It "retries <code> and succeeds on the second attempt" -TestCases @(
            @{ code = "NU1101" }
            @{ code = "NU1102" }
            @{ code = "NU1103" }
            @{ code = "NU1301" }
            @{ code = "NU1603" }
        ) {
            $counter = New-CounterFile
            $message = "C:\r\p.csproj : error ${code}: Unable to find package Microsoft.NET.ILLink.Tasks"

            Invoke-FakeRestore -CounterFile $counter -FailTimes 1 -Message $message | Out-Null

            Get-AttemptCount $counter | Should -Be 2
            $LASTEXITCODE | Should -Be 0
        }
    }

    Context "failures that should not be retried" {

        It "runs a failing compiler error only once" {
            $counter = New-CounterFile

            Invoke-FakeRestore -CounterFile $counter -FailTimes 1 -Message $script:compilerError | Out-Null

            Get-AttemptCount $counter | Should -Be 1
        }

        It "leaves the failing exit code for the caller" {
            $counter = New-CounterFile

            Invoke-FakeRestore -CounterFile $counter -FailTimes 1 -Message $script:compilerError | Out-Null

            $LASTEXITCODE | Should -Be 1
        }
    }

    Context "attempt limits" {

        It "runs once when the command succeeds" {
            $counter = New-CounterFile

            Invoke-FakeRestore -CounterFile $counter -FailTimes 0 -Message "" | Out-Null

            Get-AttemptCount $counter | Should -Be 1
            $LASTEXITCODE | Should -Be 0
        }

        It "stops after the maximum number of attempts when the failure persists" {
            $counter = New-CounterFile

            Invoke-FakeRestore -CounterFile $counter -FailTimes 99 -Message $script:transientError | Out-Null

            Get-AttemptCount $counter | Should -Be 3
            $LASTEXITCODE | Should -Be 1
        }

        It "honors an explicit MaxAttempts" {
            $counter = New-CounterFile
            $command = "pwsh -NoProfile -File `"$script:fakeRestore`" -CounterFile `"$counter`" -FailTimes 99 -Message `"$script:transientError`""

            Invoke-WithRestoreRetry -Command $command -RetryDelaySeconds 0 -MaxAttempts 2 | Out-Null

            Get-AttemptCount $counter | Should -Be 2
        }
    }

    Context "NuGet http cache" {

        It "clears the http cache before retrying so the retry does not replay the cached miss" {
            $counter = New-CounterFile

            Invoke-FakeRestore -CounterFile $counter -FailTimes 1 -Message $script:transientError | Out-Null

            Should -Invoke Clear-NuGetHttpCache -Times 1 -Exactly
        }

        It "does not clear the http cache when nothing is retried" {
            $counter = New-CounterFile

            Invoke-FakeRestore -CounterFile $counter -FailTimes 0 -Message "" | Out-Null

            Should -Invoke Clear-NuGetHttpCache -Times 0 -Exactly
        }
    }

    Context "ScriptBlock parameter set" {

        It "retries a transient failure" {
            $counter = New-CounterFile
            $fake = $script:fakeRestore
            $message = $script:transientError

            Invoke-WithRestoreRetry -RetryDelaySeconds 0 {
                pwsh -NoProfile -File $fake -CounterFile $counter -FailTimes 1 -Message $message
            } | Out-Null

            Get-AttemptCount $counter | Should -Be 2
            $LASTEXITCODE | Should -Be 0
        }

        It "leaves a failing exit code for the caller to act on" {
            $counter = New-CounterFile
            $fake = $script:fakeRestore
            $message = $script:compilerError

            Invoke-WithRestoreRetry -RetryDelaySeconds 0 {
                pwsh -NoProfile -File $fake -CounterFile $counter -FailTimes 1 -Message $message
            } | Out-Null

            $LASTEXITCODE | Should -Be 1
        }
    }

    Context "Azure DevOps issue logging" {

        BeforeAll {
            $script:originalTeamProjectId = $env:SYSTEM_TEAMPROJECTID
            $env:SYSTEM_TEAMPROJECTID = "pester"
        }

        AfterAll {
            $env:SYSTEM_TEAMPROJECTID = $script:originalTeamProjectId
        }

        It "does not report a transient failure on an attempt that will be retried" {
            $counter = New-CounterFile

            $output = Invoke-FakeRestore -CounterFile $counter -FailTimes 1 -Message $script:transientError -MsBuildLogging |
                Out-String

            $output | Should -Not -Match '##vso.*NU1103'
        }

        It "reports a transient failure once no retries remain" {
            $counter = New-CounterFile

            $output = Invoke-FakeRestore -CounterFile $counter -FailTimes 99 -Message $script:transientError -MsBuildLogging |
                Out-String

            $output | Should -Match '##vso.*NU1103'
        }

        It "reports an unrelated error on the first attempt" {
            $counter = New-CounterFile

            $output = Invoke-FakeRestore -CounterFile $counter -FailTimes 1 -Message $script:compilerError -MsBuildLogging |
                Out-String

            $output | Should -Match '##vso.*CS0103'
        }
    }
}
