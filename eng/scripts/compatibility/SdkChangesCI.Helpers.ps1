#Requires -Version 7.0

. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'logging.ps1')

function Read-SdkChangesCIJson {
    param([string]$Path)

    $text = [System.IO.File]::ReadAllText($Path)
    $document = $null
    try {
        $options = [System.Text.Json.JsonDocumentOptions]::new()
        $options.MaxDepth = 100
        $document = [System.Text.Json.JsonDocument]::Parse($text, $options)
        if ($document.RootElement.ValueKind -ne 'Object') {
            throw [System.IO.InvalidDataException]::new("Expected a JSON object in $Path.")
        }
    }
    catch [System.Text.Json.JsonException] {
        throw [System.IO.InvalidDataException]::new("Invalid JSON in ${Path}: $($_.Exception.Message)", $_.Exception)
    }
    finally {
        if ($null -ne $document) { $document.Dispose() }
    }
    return ($text | ConvertFrom-Json -AsHashtable -Depth 100 -ErrorAction Stop)
}

function Write-SdkChangesCIJson {
    param([string]$Path, [object]$Value)

    $temporary = "$Path.$([guid]::NewGuid().ToString('N')).tmp"
    try {
        [System.IO.File]::WriteAllText($temporary, ($Value | ConvertTo-Json -Depth 100), [System.Text.UTF8Encoding]::new($false))
        [System.IO.File]::Move($temporary, $Path, $true)
    }
    finally {
        if (Test-Path -LiteralPath $temporary -PathType Leaf) { Remove-Item -LiteralPath $temporary -Force }
    }
}

function Get-SdkChangesCIProjectNames {
    param([AllowEmptyString()][string]$ProjectNames)

    $names = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
    foreach ($name in ($ProjectNames -split ',')) {
        $name = $name.Trim()
        if (!$name) { continue }
        if ($name -notmatch '^[A-Za-z0-9_][A-Za-z0-9_.-]*$' -or $name -match '^(CON|PRN|AUX|NUL|COM[1-9]|LPT[1-9])(\.|$)') {
            throw [System.IO.InvalidDataException]::new("Invalid or unresolved ProjectNames entry: '$name'.")
        }
        [void]$names.Add($name)
    }
    return @($names | Sort-Object)
}

function Resolve-SdkChangesCIPath {
    param([string]$Root, [string]$Path)

    if ([string]::IsNullOrWhiteSpace($Path)) { throw [System.IO.InvalidDataException]::new('A required path is empty.') }
    $absolute = [System.IO.Path]::GetFullPath($Path, $Root)
    $relative = [System.IO.Path]::GetRelativePath($Root, $absolute)
    if ($relative -eq '..' -or $relative.StartsWith("..$([System.IO.Path]::DirectorySeparatorChar)") -or
        [System.IO.Path]::IsPathFullyQualified($relative)) {
        throw [System.IO.InvalidDataException]::new("Path '$Path' is outside '$Root'.")
    }
    return $absolute
}

function Get-SdkChangesCISelection {
    param([string]$SdkRepoPath, [string]$PackageInfoDirectory, [string[]]$ProjectNames)

    if (!(Test-Path -LiteralPath $PackageInfoDirectory -PathType Container)) {
        throw [System.IO.DirectoryNotFoundException]::new("PackageInfo directory is missing: $PackageInfoDirectory")
    }
    $metadata = @()
    $warnings = @()
    foreach ($file in (Get-ChildItem -LiteralPath $PackageInfoDirectory -Filter '*.json' -File -Recurse)) {
        try {
            $info = Read-SdkChangesCIJson $file.FullName
            $metadata += @{ File = $file.FullName; Info = $info; Error = $null; FileName = $file.BaseName }
        }
        catch [System.IO.InvalidDataException], [System.IO.IOException], [System.UnauthorizedAccessException] {
            $metadata += @{ File = $file.FullName; Info = @{}; Error = $_.Exception.Message; FileName = $file.BaseName }
            if ($file.BaseName -notin $ProjectNames) {
                $warnings += "Unselected PackageInfo file could not be read: $($file.FullName): $($_.Exception.Message)"
            }
        }
    }
    $packages = @()
    foreach ($name in $ProjectNames) {
        $matches = @($metadata | Where-Object {
            $_.Info['Name'] -eq $name -or $_.Info['ArtifactName'] -eq $name -or ($_.Error -and $_.FileName -eq $name)
        })
        $entry = [ordered]@{ projectName = $name; packageName = $null; packagePath = $null; packageInfoFile = $null; error = $null }
        if ($matches.Count -ne 1) {
            $entry.error = "Expected one PackageInfo record for '$name'; found $($matches.Count)."
        }
        else {
            $match = $matches[0]
            $entry.packageInfoFile = $match.File
            if ($match.Error) {
                $entry.error = $match.Error
            }
            elseif ($match.Info['Name'] -isnot [string] -or !$match.Info['Name'] -or
                $match.Info['DirectoryPath'] -isnot [string] -or !$match.Info['DirectoryPath']) {
                $entry.error = "PackageInfo for '$name' must contain Name and DirectoryPath strings."
            }
            else {
                $entry.packageName = $match.Info.Name
                try {
                    $entry.packagePath = Resolve-SdkChangesCIPath -Root $SdkRepoPath -Path $match.Info.DirectoryPath
                    if (!(Test-Path -LiteralPath $entry.packagePath -PathType Container)) {
                        $entry.error = "Selected package directory is missing: $($entry.packagePath)"
                    }
                }
                catch [System.IO.InvalidDataException], [System.ArgumentException], [System.NotSupportedException] {
                    $entry.error = $_.Exception.Message
                }
            }
        }
        $packages += $entry
    }
    return @{ Packages = $packages; Warnings = $warnings }
}

function Get-SdkChangesCIRuntime {
    param([string]$SdkRepoPath)

    $process = [System.Diagnostics.Process]::GetCurrentProcess()
    try { $executable = $process.MainModule.FileName } finally { $process.Dispose() }
    $runtime = [ordered]@{
        powerShellVersion = $PSVersionTable.PSVersion.ToString()
        runtimeVersion = [System.Environment]::Version.ToString()
        executable = $executable
        sdkVersion = $null
        requiredRuntimeMajor = $null
        supported = $false
        error = $null
    }
    try {
        $globalJson = Read-SdkChangesCIJson (Join-Path $SdkRepoPath 'global.json')
        if ($globalJson['sdk'] -isnot [System.Collections.IDictionary] -or
            $globalJson.sdk['version'] -isnot [string] -or $globalJson.sdk.version -notmatch '^(\d+)\.\d+\.\d+') {
            throw [System.IO.InvalidDataException]::new('global.json must identify the .NET SDK version required by the detector.')
        }
        $runtime.sdkVersion = $globalJson.sdk.version
        $runtime.requiredRuntimeMajor = [int]$Matches[1]
        $runtime.supported = $PSVersionTable.PSEdition -eq 'Core' -and [System.Environment]::Version.Major -ge $runtime.requiredRuntimeMajor
        if (!$runtime.supported) {
            $runtime.error = "SDK $($runtime.sdkVersion) requires a PowerShell host on .NET $($runtime.requiredRuntimeMajor)+ for native diagnostics; this host is PowerShell $($runtime.powerShellVersion) on .NET $($runtime.runtimeVersion). Installing the .NET SDK does not upgrade pwsh."
        }
    }
    catch [System.IO.InvalidDataException], [System.IO.IOException], [System.UnauthorizedAccessException] {
        $runtime.error = $_.Exception.Message
    }
    return $runtime
}

function Invoke-SdkChangesCIProcess {
    param(
        [string]$PowerShellPath, [string]$DetectorPath, [string]$SdkRepoPath,
        [string]$PackagePath, [string]$OutputJsonFile,
        [ValidateRange(1, 3600)][int]$TimeoutSeconds = 300
    )

    $start = [System.Diagnostics.ProcessStartInfo]::new($PowerShellPath)
    $start.WorkingDirectory = $SdkRepoPath
    $start.UseShellExecute = $false
    $start.RedirectStandardOutput = $true
    $start.RedirectStandardError = $true
    foreach ($key in @($start.Environment.Keys)) {
        if ($key -in @('Configuration', 'TargetFramework', 'TargetFrameworks')) { [void]$start.Environment.Remove($key) }
    }
    $start.Environment['Configuration'] = 'Release'
    foreach ($argument in @(
        '-NoLogo', '-NoProfile', '-NonInteractive', '-File', $DetectorPath,
        '-PackagePath', $PackagePath, '-SdkRepoPath', $SdkRepoPath, '-OutputJsonFile', $OutputJsonFile
    )) {
        $start.ArgumentList.Add($argument)
    }
    $process = [System.Diagnostics.Process]::new()
    $process.StartInfo = $start
    try {
        if (!$process.Start()) { throw [System.InvalidOperationException]::new('Could not start the native SDK detector.') }
        $stdout = $process.StandardOutput.ReadToEndAsync()
        $stderr = $process.StandardError.ReadToEndAsync()
        $timedOut = !$process.WaitForExit($TimeoutSeconds * 1000)
        if ($timedOut) {
            $process.Kill($true)
            $process.WaitForExit()
        }
        return @{
            ExitCode = $process.ExitCode
            TimedOut = $timedOut
            StdOut = $stdout.GetAwaiter().GetResult()
            StdErr = $stderr.GetAwaiter().GetResult()
        }
    }
    finally {
        $process.Dispose()
    }
}

function Get-SdkChangesCIRawStatus {
    param([System.Collections.IDictionary]$Report)

    if ($Report['changes'] -isnot [string] -or $Report['hasBreakingChange'] -isnot [bool] -or
        $Report['details'] -isnot [System.Collections.IDictionary]) {
        throw [System.IO.InvalidDataException]::new('The detector did not return the common changes/hasBreakingChange/details contract.')
    }
    $details = $Report.details
    if (!$details.Contains('baselineVersion') -or
        ($null -ne $details.baselineVersion -and ($details.baselineVersion -isnot [string] -or [string]::IsNullOrWhiteSpace($details.baselineVersion)))) {
        throw [System.IO.InvalidDataException]::new('The detector baselineVersion must be a nonempty string or null.')
    }
    foreach ($name in @('apiChanges', 'diagnostics', 'limitations')) {
        if ($details[$name] -isnot [array]) { throw [System.IO.InvalidDataException]::new("The detector details.$name must be an array.") }
    }
    foreach ($value in @($details.diagnostics) + @($details.limitations)) {
        if ($value -isnot [string]) { throw [System.IO.InvalidDataException]::new('Detector diagnostics and limitations must contain strings.') }
    }
    foreach ($change in $details.apiChanges) {
        if ($change -isnot [System.Collections.IDictionary] -or $change['kind'] -isnot [string] -or
            $change['symbol'] -isnot [string] -or $change['description'] -isnot [string] -or $change['isBreaking'] -isnot [bool]) {
            throw [System.IO.InvalidDataException]::new('The detector returned an invalid structured API change.')
        }
    }
    if ($null -eq $details.baselineVersion) {
        if ($Report.hasBreakingChange -or $details.apiChanges.Count -ne 0 -or
            @($details.limitations | Where-Object { ![string]::IsNullOrWhiteSpace($_) }).Count -eq 0) {
            throw [System.IO.InvalidDataException]::new('A no-GA report must explain why comparison is not applicable and contain no API verdicts.')
        }
        return 'not_applicable'
    }
    $hasBreakingApi = @($details.apiChanges | Where-Object { $_.isBreaking }).Count -gt 0
    if ($Report.hasBreakingChange -ne $hasBreakingApi) {
        throw [System.IO.InvalidDataException]::new('The detector hasBreakingChange contradicts its structured API changes.')
    }
    if ($Report.hasBreakingChange) { return 'breaking_changes' }
    return 'compatible'
}

function Get-SdkChangesCICounts {
    param([object[]]$Packages)

    return [ordered]@{
        selected = @($Packages).Count
        compatible = @($Packages | Where-Object { $_.status -eq 'compatible' }).Count
        breakingChanges = @($Packages | Where-Object { $_.status -eq 'breaking_changes' }).Count
        notApplicable = @($Packages | Where-Object { $_.status -eq 'not_applicable' }).Count
        detectorErrors = @($Packages | Where-Object { $_.status -eq 'detector_error' }).Count
    }
}

function Invoke-SdkChangesCICollection {
    param(
        [string]$SdkRepoPath, [string]$PackageInfoDirectory, [AllowEmptyString()][string]$ProjectNames,
        [string]$ReportRoot, [string]$PreviousJobStatus,
        [ValidateRange(1, 3600)][int]$TimeoutSeconds = 300
    )

    if (![System.IO.Path]::IsPathFullyQualified($ReportRoot)) {
        throw [System.ArgumentException]::new('ReportRoot must be absolute.')
    }
    $directory = Join-Path $ReportRoot ([guid]::NewGuid().ToString('N'))
    [void][System.IO.Directory]::CreateDirectory($directory)
    Set-PipelineVariable -Name 'SdkChangesReportDirectory' -Value $directory
    $summary = [ordered]@{
        schemaVersion = 1
        generatedAt = [datetime]::UtcNow.ToString('o')
        configuration = 'Release'
        previousJobStatus = $(if ($PreviousJobStatus) { $PreviousJobStatus } else { 'Unknown' })
        projectNames = @()
        runtime = $null
        selectionWarnings = @()
        errors = @()
        packages = @()
        counts = $null
    }
    try {
        if (![System.IO.Path]::IsPathFullyQualified($SdkRepoPath) -or !(Test-Path -LiteralPath $SdkRepoPath -PathType Container)) {
            throw [System.IO.DirectoryNotFoundException]::new("SdkRepoPath must identify an existing absolute repository path: $SdkRepoPath")
        }
        $summary.projectNames = @(Get-SdkChangesCIProjectNames $ProjectNames)
        $selection = Get-SdkChangesCISelection -SdkRepoPath $SdkRepoPath -PackageInfoDirectory $PackageInfoDirectory -ProjectNames $summary.projectNames
        $summary.selectionWarnings = @($selection.Warnings)
        foreach ($warning in $summary.selectionWarnings) { LogWarning $warning }
        $summary.runtime = Get-SdkChangesCIRuntime $SdkRepoPath
        $detector = Join-Path $SdkRepoPath 'eng' 'scripts' 'compatibility' 'Get-SdkChanges.ps1'
        $prerequisiteError = if (!$summary.runtime.supported) { $summary.runtime.error } elseif (!(Test-Path -LiteralPath $detector -PathType Leaf)) {
            "Native SDK detector script is missing: $detector"
        } else { $null }
        if ($prerequisiteError) { $summary.errors += $prerequisiteError }
        foreach ($entry in $selection.Packages) {
            $packageDirectory = Join-Path $directory $entry.projectName
            [void][System.IO.Directory]::CreateDirectory($packageDirectory)
            $rawPath = Join-Path $packageDirectory 'sdk-changes.json'
            $result = [ordered]@{
                projectName = $entry.projectName
                packageName = $entry.packageName
                packagePath = $(if ($entry.packagePath) { [System.IO.Path]::GetRelativePath($SdkRepoPath, $entry.packagePath).Replace('\', '/') } else { $null })
                status = 'detector_error'
                hasBreakingChange = $null
                baselineVersion = $null
                detectorExitCode = $null
                timedOut = $false
                reportFile = $null
                reportSha256 = $null
                errorFile = $null
                failedReportFile = $null
                error = $entry.error
            }
            if (!$result.error -and $prerequisiteError) { $result.error = $prerequisiteError }
            if (!$result.error) {
                try {
                    $process = Invoke-SdkChangesCIProcess -PowerShellPath $summary.runtime.executable -DetectorPath $detector `
                        -SdkRepoPath $SdkRepoPath -PackagePath $entry.packagePath -OutputJsonFile $rawPath -TimeoutSeconds $TimeoutSeconds
                    [System.IO.File]::WriteAllText((Join-Path $packageDirectory 'detector.stdout.log'), $process.StdOut)
                    [System.IO.File]::WriteAllText((Join-Path $packageDirectory 'detector.stderr.log'), $process.StdErr)
                    $result.detectorExitCode = $process.ExitCode
                    $result.timedOut = $process.TimedOut
                    if ($process.TimedOut) {
                        $result.error = "SDK change extraction timed out after $TimeoutSeconds seconds."
                    }
                    elseif ($process.ExitCode -ne 0) {
                        $result.error = "SDK change extraction failed with exit code $($process.ExitCode). See detector.stdout.log and detector.stderr.log."
                        $nativeError = if (![string]::IsNullOrWhiteSpace($process.StdErr)) { $process.StdErr.Trim() } else { $process.StdOut.Trim() }
                        if ($nativeError) { $result.error += "`n$nativeError" }
                    }
                    elseif (!(Test-Path -LiteralPath $rawPath -PathType Leaf)) {
                        $result.error = 'The detector exited successfully but did not produce SDK change JSON.'
                    }
                    else {
                        $raw = Read-SdkChangesCIJson $rawPath
                        $result.status = Get-SdkChangesCIRawStatus $raw
                        $result.hasBreakingChange = $raw.hasBreakingChange
                        $result.baselineVersion = $raw.details.baselineVersion
                        $result.reportFile = [System.IO.Path]::GetRelativePath($directory, $rawPath).Replace('\', '/')
                        $result.reportSha256 = (Get-FileHash -LiteralPath $rawPath -Algorithm SHA256).Hash
                    }
                }
                catch [System.IO.InvalidDataException], [System.IO.IOException], [System.UnauthorizedAccessException],
                    [System.ArgumentException], [System.InvalidOperationException], [System.ComponentModel.Win32Exception],
                    [System.Management.Automation.ItemNotFoundException] {
                    $result.error = $_.Exception.Message
                }
            }
            if ($result.error) {
                $result.status = 'detector_error'
                $result.hasBreakingChange = $null
                $result.baselineVersion = $null
                $result.reportFile = $null
                $result.reportSha256 = $null
                if (Test-Path -LiteralPath $rawPath -PathType Leaf) {
                    $failedPath = Join-Path $packageDirectory 'failed-sdk-changes.json'
                    [System.IO.File]::Move($rawPath, $failedPath)
                    $result.failedReportFile = [System.IO.Path]::GetRelativePath($directory, $failedPath).Replace('\', '/')
                }
                $errorPath = Join-Path $packageDirectory 'error.json'
                Write-SdkChangesCIJson -Path $errorPath -Value @{
                    status = 'detector_error'
                    projectName = $entry.projectName
                    message = $result.error
                    detectorExitCode = $result.detectorExitCode
                    timedOut = $result.timedOut
                }
                $result.errorFile = [System.IO.Path]::GetRelativePath($directory, $errorPath).Replace('\', '/')
            }
            Write-SdkChangesCIJson -Path (Join-Path $packageDirectory 'result.json') -Value $result
            $summary.packages += $result
            LogInfo "SDK API report: $($entry.projectName): $($result.status)"
            if ($result.status -eq 'detector_error') { LogWarning "$($entry.projectName): $($result.error)" }
            if ($result.status -eq 'not_applicable') { LogWarning "$($entry.projectName): no GA baseline; compatibility was not evaluated." }
        }
    }
    catch [System.IO.InvalidDataException], [System.IO.IOException], [System.UnauthorizedAccessException],
        [System.ArgumentException], [System.InvalidOperationException] {
        $summary.errors += $_.Exception.Message
        LogWarning "SDK API report collection error: $($_.Exception.Message)"
    }
    $summary.counts = Get-SdkChangesCICounts $summary.packages
    Write-SdkChangesCIJson -Path (Join-Path $directory 'summary.json') -Value $summary
    return @{ Directory = $directory; Summary = $summary }
}

function Test-SdkChangesCIReports {
    param([string]$ReportDirectory, [AllowEmptyString()][string]$ProjectNames)

    $summary = Read-SdkChangesCIJson (Join-Path $ReportDirectory 'summary.json')
    if ($summary['schemaVersion'] -ne 1 -or $summary['configuration'] -ne 'Release' -or
        $summary['packages'] -isnot [array] -or $summary['projectNames'] -isnot [array] -or $summary['errors'] -isnot [array]) {
        throw [System.IO.InvalidDataException]::new('Invalid SDK API CI report summary.')
    }
    $expectedNames = @(Get-SdkChangesCIProjectNames $ProjectNames)
    if (($expectedNames -join ',') -ine (@($summary.projectNames | Sort-Object) -join ',')) {
        throw [System.IO.InvalidDataException]::new('The SDK API report does not match this job''s ProjectNames selection.')
    }
    $errors = @($summary.errors)
    $actualNames = @($summary.packages | ForEach-Object { $_.projectName } | Sort-Object)
    if (($actualNames -join ',') -ine ($expectedNames -join ',')) {
        $errors += 'SDK API reports are missing or duplicated for selected projects.'
    }
    foreach ($package in $summary.packages) {
        if ($package.status -eq 'detector_error') {
            $errors += "$($package.projectName): detector error: $($package.error)"
            continue
        }
        if ($package.status -notin @('compatible', 'breaking_changes', 'not_applicable') -or
            $package.detectorExitCode -ne 0 -or $package.timedOut) {
            $errors += "$($package.projectName): invalid detector result status."
            continue
        }
        try {
            $path = Resolve-SdkChangesCIPath -Root $ReportDirectory -Path $package.reportFile
            if (!(Test-Path -LiteralPath $path -PathType Leaf)) {
                throw [System.IO.FileNotFoundException]::new("Collected native SDK report is missing: $path", $path)
            }
            if ((Get-FileHash -LiteralPath $path -Algorithm SHA256 -ErrorAction Stop).Hash -ne $package.reportSha256) {
                throw [System.IO.InvalidDataException]::new('The raw SDK change report was modified after collection.')
            }
            $raw = Read-SdkChangesCIJson $path
            $status = Get-SdkChangesCIRawStatus $raw
            if ($status -ne $package.status -or $raw.hasBreakingChange -ne $package.hasBreakingChange -or
                $raw.details.baselineVersion -ne $package.baselineVersion) {
                throw [System.IO.InvalidDataException]::new('The CI summary contradicts the authoritative native SDK report.')
            }
            if ($status -eq 'breaking_changes') { $errors += "$($package.projectName): native ApiCompat detected breaking changes." }
        }
        catch [System.IO.InvalidDataException], [System.IO.IOException], [System.UnauthorizedAccessException],
            [System.ArgumentException], [System.Management.Automation.ItemNotFoundException] {
            $errors += "$($package.projectName): $($_.Exception.Message)"
        }
    }
    return @{ Passed = $errors.Count -eq 0; Errors = $errors; Counts = (Get-SdkChangesCICounts $summary.packages); PreviousJobStatus = $summary.previousJobStatus }
}
