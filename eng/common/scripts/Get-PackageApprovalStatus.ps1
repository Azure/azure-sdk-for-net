<#
.SYNOPSIS
Checks whether a package is approved for release.

.DESCRIPTION
Invokes the centralized Azure SDK CLI API review release gate and fails unless its structured result approves the package.

.PARAMETER Language
The SDK language used to locate the package's API review.

.PARAMETER PackageName
The package name to check.

.PARAMETER PackageVersion
The package version to check.

.PARAMETER ApiHash
The optional API Review Hub hash for the release candidate artifact.

.PARAMETER RepoOwner
The optional GitHub repository owner to query in API Review Hub.
#>
[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $Language,

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $PackageName,

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $PackageVersion,

    [string] $ApiHash = "",

    [string] $RepoOwner = ""
)

Set-StrictMode -Version 4
$ErrorActionPreference = "Stop"

function Write-BackendStatus([string] $Name, [object] $Status) {
    if ($null -eq $Status) {
        return
    }

    $approval = if ($Status.isApproved) { "APPROVED" } else { "NOT APPROVED" }
    Write-Host $Name
    Write-Host "  Status: $approval"
    if ($Status.PSObject.Properties["reason"]) {
        Write-Host "  Reason: $($Status.reason)"
    }
    if ($Status.PSObject.Properties["statusCode"]) {
        Write-Host "  HTTP status: $($Status.statusCode)"
    }

    if ($Status.PSObject.Properties["details"]) {
        foreach ($detail in @($Status.details)) {
            Write-Host "  Detail: $detail"
        }
    }
}

function Write-ApprovalSummary([object] $Response) {
    $result = $Response.result
    $source = if ($result.PSObject.Properties["finalSource"]) { $result.finalSource } else { "unknown" }
    $reason = if ($result.PSObject.Properties["reason"]) { $result.reason } else { "none" }

    Write-Host ""
    Write-Host "Approval results"
    Write-Host "----------------"
    if ($result.PSObject.Properties["reviewHub"]) {
        Write-BackendStatus "API Review Hub" $result.reviewHub
    }
    if ($result.PSObject.Properties["apiView"]) {
        Write-Host ""
        Write-BackendStatus "APIView" $result.apiView
    }

    $approval = if ($result.isApproved) { "APPROVED" } else { "NOT APPROVED" }
    Write-Host ""
    Write-Host "Overall"
    Write-Host "  Status: $approval"
    Write-Host "  Source: $source"
    Write-Host "  Reason: $reason"
}

function Format-CommandArgument([string] $Argument) {
    if ($Argument -match '[\s"'']') {
        return '"' + $Argument.Replace('"', '\"') + '"'
    }
    return $Argument
}

function Invoke-AzSdkCommand([string[]] $Arguments) {
    $command = Get-Command azsdk -ErrorAction Stop
    if ($command.CommandType -ne [System.Management.Automation.CommandTypes]::Application) {
        $output = @(& azsdk @Arguments 2>&1)
        return [PSCustomObject]@{
            ExitCode = $LASTEXITCODE
            Output = ($output | ForEach-Object { "$_" }) -join [Environment]::NewLine
            Stdout = ($output | ForEach-Object { "$_" }) -join [Environment]::NewLine
            Stderr = ""
        }
    }

    $startInfo = [System.Diagnostics.ProcessStartInfo]::new()
    $startInfo.FileName = $command.Source
    $startInfo.UseShellExecute = $false
    $startInfo.RedirectStandardOutput = $true
    $startInfo.RedirectStandardError = $true
    $startInfo.CreateNoWindow = $true

    if ($startInfo.PSObject.Properties["ArgumentList"]) {
        foreach ($argument in $Arguments) {
            $startInfo.ArgumentList.Add($argument)
        }
    }
    else {
        $formattedArguments = @($Arguments | ForEach-Object { Format-CommandArgument $_ })
        $startInfo.Arguments = $formattedArguments -join " "
    }

    $process = [System.Diagnostics.Process]::Start($startInfo)
    $stdoutTask = $process.StandardOutput.ReadToEndAsync()
    $stderrTask = $process.StandardError.ReadToEndAsync()
    $process.WaitForExit()
    $stdout = $stdoutTask.GetAwaiter().GetResult()
    $stderr = $stderrTask.GetAwaiter().GetResult()

    return [PSCustomObject]@{
        ExitCode = $process.ExitCode
        Output = if (-not [string]::IsNullOrWhiteSpace($stdout)) { $stdout } else { $stderr }
        Stdout = $stdout
        Stderr = $stderr
    }
}

$arguments = @(
    "package",
    "get-approval-status",
    "--language", $Language,
    "--package-name", $PackageName,
    "--package-version", $PackageVersion,
    "--output", "json"
)

if (-not [string]::IsNullOrWhiteSpace($ApiHash)) {
    $arguments += @("--api-hash", $ApiHash)
}

if (-not [string]::IsNullOrWhiteSpace($RepoOwner)) {
    $arguments += @("--repo-owner", $RepoOwner)
}

$hashDescription = if ([string]::IsNullOrWhiteSpace($ApiHash)) { "not provided" } else { $ApiHash }
Write-Host "Checking package approval: language=$Language, package=$PackageName, version=$PackageVersion, apiHash=$hashDescription"
$formattedArguments = @($arguments | ForEach-Object { Format-CommandArgument $_ })
Write-Host "Command: azsdk $($formattedArguments -join ' ')"

$commandResult = Invoke-AzSdkCommand $arguments
$exitCode = $commandResult.ExitCode
$outputText = $commandResult.Output

try {
    $response = $outputText | ConvertFrom-Json -ErrorAction Stop
}
catch {
    $capturedOutput = "stdout:`n$($commandResult.Stdout)`nstderr:`n$($commandResult.Stderr)"
    throw "Package approval check returned malformed JSON for $PackageName $PackageVersion (azsdk exit code $exitCode). Captured output:`n$capturedOutput"
}

if ($response.PSObject.Properties["result"] -and
    $null -ne $response.result -and
    $response.result.PSObject.Properties["isApproved"] -and
    $response.result.isApproved -is [bool]) {
    Write-ApprovalSummary $response
}

if ($exitCode -ne 0) {
    $failureMessage = if ($response.PSObject.Properties["response_error"] -and
        -not [string]::IsNullOrWhiteSpace($response.response_error)) {
        $response.response_error
    } else {
        "azsdk exited with code $exitCode."
    }
    throw "Package approval check failed: $failureMessage"
}

if (-not $response.PSObject.Properties["result"] -or
    $null -eq $response.result -or
    -not $response.result.PSObject.Properties["isApproved"] -or
    $response.result.isApproved -isnot [bool]) {
    throw "Package approval check returned an invalid response for $PackageName $PackageVersion."
}

if (-not $response.result.isApproved) {
    throw "Package $PackageName $PackageVersion is not approved for release."
}