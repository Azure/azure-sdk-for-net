<#
.SYNOPSIS
Marks a published package as released in API Review Hub and APIView.

.DESCRIPTION
Invokes the centralized Azure SDK CLI release-completion command and surfaces each backend result.

.PARAMETER PackageInfoFiles
Package-info JSON files containing the published package name, version, and API hash.

.PARAMETER AzSdkExePath
The path to the azsdk executable.
#>
[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $Language,

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [array] $PackageInfoFiles,

    [string] $RepoOwner = "",

    [ValidateNotNullOrEmpty()]
    [string] $AzSdkExePath = "azsdk"
)

Set-StrictMode -Version 4
$ErrorActionPreference = "Stop"

function Format-CommandArgument([string] $Argument) {
    if ($Argument -match '[\s"'']') {
        return '"' + $Argument.Replace('"', '\"') + '"'
    }
    return $Argument
}

function Invoke-AzSdkCommand([string] $Executable, [string[]] $Arguments) {
    $command = Get-Command $Executable -ErrorAction SilentlyContinue
    if (-not $command) {
        throw "The azsdk CLI executable was not found at '$Executable'. Install azsdk before marking packages released."
    }

    if ($command.CommandType -ne [System.Management.Automation.CommandTypes]::Application) {
        $output = @(& $command @Arguments 2>&1)
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

function Set-PackageReleased([string] $PackageName, [string] $PackageVersion, [string] $ApiHash) {
    $arguments = @(
        "package",
        "mark-released",
        "--language", $Language,
        "--package-name", $PackageName,
        "--package-version", $PackageVersion
    )

    if (-not [string]::IsNullOrWhiteSpace($ApiHash)) {
        $arguments += @("--api-hash", $ApiHash)
    }

    $arguments += @("--output", "json")

    if (-not [string]::IsNullOrWhiteSpace($RepoOwner)) {
        $arguments += @("--repo-owner", $RepoOwner)
    }

    $hashDescription = if ([string]::IsNullOrWhiteSpace($ApiHash)) { "not provided" } else { $ApiHash }
    Write-Host "Marking package released: language=$Language, package=$PackageName, version=$PackageVersion, apiHash=$hashDescription"
    $formattedArguments = @($arguments | ForEach-Object { Format-CommandArgument $_ })
    Write-Host "Command: azsdk $($formattedArguments -join ' ')"

    $commandResult = Invoke-AzSdkCommand $AzSdkExePath $arguments
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
}

$packageInfoPaths = @($PackageInfoFiles | Where-Object { -not [string]::IsNullOrWhiteSpace($_) })
if ($packageInfoPaths.Count -eq 0) {
    throw "At least one package-info file is required."
}

$failures = @()
foreach ($packageInfoFile in $packageInfoPaths) {
    try {
        if (-not (Test-Path $packageInfoFile -PathType Leaf)) {
            throw "Package-info file does not exist."
        }

        $packageInfo = Get-Content $packageInfoFile -Raw | ConvertFrom-Json -ErrorAction Stop
        $packageName = if ($packageInfo.PSObject.Properties["Name"]) { [string] $packageInfo.Name } else { "" }
        $packageVersion = if ($packageInfo.PSObject.Properties["Version"]) { [string] $packageInfo.Version } else { "" }
        $apiHash = if ($packageInfo.PSObject.Properties["ApiHash"]) { [string] $packageInfo.ApiHash } else { "" }

        if ([string]::IsNullOrWhiteSpace($packageName)) {
            throw "Package-info file does not contain a package Name."
        }
        if ([string]::IsNullOrWhiteSpace($packageVersion)) {
            throw "Package-info file does not contain a package Version."
        }

        Set-PackageReleased $packageName $packageVersion $apiHash
    }
    catch {
        Write-Error "Mark released failed for ${packageInfoFile}: $($_.Exception.Message)" -ErrorAction Continue
        $failures += "${packageInfoFile}: $($_.Exception.Message)"
    }
}

if ($failures.Count -gt 0) {
    throw "Mark released failed for $($failures.Count) package(s):`n$($failures -join "`n")"
}
