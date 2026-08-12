<#
.SYNOPSIS
Marks a published package as released in API Review Hub and APIView.

.DESCRIPTION
Invokes the centralized Azure SDK CLI release-completion command and surfaces each backend result.
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

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $ApiHash,

    [string] $RepoOwner = ""
)

Set-StrictMode -Version 4
$ErrorActionPreference = "Stop"

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

function Write-BackendResult([string] $Name, [object] $Result) {
    Write-Host $Name
    Write-Host "  Result: $($Result | ConvertTo-Json -Compress -Depth 20)"
}

$arguments = @(
    "pkg",
    "mark-released",
    "--language", $Language,
    "--package-name", $PackageName,
    "--package-version", $PackageVersion,
    "--api-hash", $ApiHash,
    "--output", "json",
    "--dry-run"
)

if (-not [string]::IsNullOrWhiteSpace($RepoOwner)) {
    $arguments += @("--repo-owner", $RepoOwner)
}

Write-Host "Marking package released: language=$Language, package=$PackageName, version=$PackageVersion, apiHash=$ApiHash"
$formattedArguments = @($arguments | ForEach-Object { Format-CommandArgument $_ })
Write-Host "Command: azsdk $($formattedArguments -join ' ')"

$commandResult = Invoke-AzSdkCommand $arguments
$exitCode = $commandResult.ExitCode

try {
    $response = $commandResult.Output | ConvertFrom-Json -ErrorAction Stop
}
catch {
    $capturedOutput = "stdout:`n$($commandResult.Stdout)`nstderr:`n$($commandResult.Stderr)"
    throw "Mark released returned malformed JSON for $PackageName $PackageVersion (azsdk exit code $exitCode). Captured output:`n$capturedOutput"
}

$hasReviewHubResult = $response.PSObject.Properties["api_review_hub"] -and $null -ne $response.api_review_hub
$hasApiViewResult = $response.PSObject.Properties["api_view"] -and $null -ne $response.api_view
if ($hasReviewHubResult) {
    Write-BackendResult "API Review Hub" $response.api_review_hub
}
if ($hasApiViewResult) {
    Write-BackendResult "APIView" $response.api_view
}

if ($exitCode -ne 0) {
    [array] $errors = if ($response.PSObject.Properties["response_errors"]) { @($response.response_errors) } else { @() }
    $failureMessage = if ($errors.Count -gt 0) { $errors -join "; " } else { "azsdk exited with code $exitCode." }
    throw "Mark released failed: $failureMessage"
}
