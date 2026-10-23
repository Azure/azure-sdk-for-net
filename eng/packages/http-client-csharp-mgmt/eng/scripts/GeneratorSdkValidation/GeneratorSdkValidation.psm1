#Requires -Version 7.0
Set-StrictMode -Version 3.0

function Get-GeneratorSdkValidationIdentity {
    param([string]$PackageName, [string]$Version, [int]$PullRequest, [string]$RunId)
    $identifier = ($PackageName -replace '^@', '' -replace '[^a-zA-Z0-9\-_/]', '-').Trim('-').ToLowerInvariant()
    $version = "$($Version.Split('-')[0])-alpha.$RunId"
    $branch = if ($PullRequest) { "validate-typespec-pr-$PullRequest-$identifier" } else { "validate-typespec-$RunId-$identifier" }
    [pscustomobject]@{
        Version = $version
        Branch = $branch
        Title = "[Preview] Update $identifier version to prerelease $version"
    }
}

function Get-GeneratorSdkValidationServices {
    [CmdletBinding()]
    param([string]$RepoRoot, [string[]]$Services)
    $packages = @(Get-ChildItem (Join-Path $RepoRoot sdk) -Directory | Get-ChildItem -Directory | Where-Object {
        $location = Join-Path $_.FullName 'tsp-location.yaml'
        (Test-Path $location) -and ((Get-Content $location -Raw) -match 'azure-typespec-http-client-csharp-mgmt-emitter-package')
    } | Sort-Object FullName)
    if (-not $Services -or @($Services | Where-Object { [string]::IsNullOrWhiteSpace($_) }).Count) {
        throw 'Specify exact SDK folder names in -Services.'
    }
    $unknown = @($Services | Where-Object { $_ -notin $packages.Name })
    if ($unknown.Count) { throw "No management TypeSpec SDK matched: $($unknown -join ', ')." }
    $packages = @($packages | Where-Object Name -In $Services)
    if (-not $packages.Count) { throw 'No management TypeSpec SDKs selected.' }
    return $packages
}

function Get-GeneratorSdkValidationSchedule {
    param([object[]]$Packages, [string]$HistoryPath)
    $secondsByPackage = @{}
    $seed = Join-Path $PSScriptRoot ValidateGeneratorSdkChanges.timings.json
    foreach ($path in @($seed, $HistoryPath)) {
        if (-not $path -or -not (Test-Path $path)) { continue }
        try { $measurements = @((Get-Content $path -Raw -ErrorAction Stop) | ConvertFrom-Json -ErrorAction Stop) }
        catch {
            if ($path -eq $seed) { throw }
            Write-Warning "Cannot read timing cache; using bundled measurements: $_"
            continue
        }
        foreach ($measurement in $measurements) {
            if ($measurement.Success -ne $true) { continue }
            $seconds = [double]$measurement.Seconds
            if ([double]::IsNaN($seconds) -or [double]::IsInfinity($seconds) -or $seconds -lt 0) {
                throw "Expected finite nonnegative elapsed seconds for $($measurement.Package)."
            }
            $secondsByPackage[$measurement.Package] = $seconds
        }
    }
    if (-not @($Packages | Where-Object { $secondsByPackage.ContainsKey($_.Name) }).Count) { return $Packages }
    # Reorder only; timing history must never add SDKs to the requested scope.
    $Packages | Sort-Object @{ Expression = {
        if ($secondsByPackage.ContainsKey($_.Name)) { $secondsByPackage[$_.Name] } else { -1 }
    }; Descending = $true }, Name
}

function Update-GeneratorSdkValidationHistory {
    param([string]$HistoryPath, [object[]]$Results)
    if (-not $HistoryPath) { return }
    $lock = $null
    $temporary = $null
    try {
        New-Item (Split-Path $HistoryPath -Parent) -ItemType Directory -Force | Out-Null
        $lock = [IO.File]::Open("$HistoryPath.lock", [IO.FileMode]::OpenOrCreate, [IO.FileAccess]::ReadWrite, [IO.FileShare]::None)
        $byPackage = @{}
        if (Test-Path $HistoryPath) {
            foreach ($measurement in @((Get-Content $HistoryPath -Raw) | ConvertFrom-Json)) {
                if ($measurement.Success -eq $true) { $byPackage[$measurement.Package] = $measurement }
            }
        }
        foreach ($result in $Results) {
            if (-not $result.Success) { continue }
            $seconds = [double]$result.Seconds
            if ([double]::IsNaN($seconds) -or [double]::IsInfinity($seconds) -or $seconds -lt 0) {
                throw "Expected finite nonnegative elapsed seconds for $($result.Package)."
            }
            $byPackage[$result.Package] = [pscustomobject]@{
                Package = $result.Package; Success = $true; Seconds = $seconds
                UpdatedUtc = (Get-Date -AsUTC -Format o)
            }
        }
        $temporary = "$HistoryPath.$([Guid]::NewGuid().ToString('N')).tmp"
        ConvertTo-Json -InputObject @($byPackage.Values | Sort-Object Package) -Depth 5 | Set-Content $temporary
        [IO.File]::Move($temporary, $HistoryPath, $true)
    }
    catch { Write-Warning "Timing history was not updated; SDK results are unaffected: $_" }
    finally {
        if ($temporary -and (Test-Path $temporary)) { Remove-Item $temporary -Force }
        if ($lock) { $lock.Dispose() }
    }
}

function Invoke-GeneratorSdkValidationCommand {
    param([string]$File, [string[]]$Arguments, [string]$WorkingDirectory)
    Push-Location $WorkingDirectory
    try {
        $output = & $File @Arguments 2>&1
        $exitCode = $LASTEXITCODE
        if ($exitCode -ne 0) { throw "$File exited with code $exitCode`n$($output -join "`n")" }
        $output | ForEach-Object { "$_" }
    }
    finally { Pop-Location }
}

function Assert-GeneratorSdkValidationPortableConfig {
    param([string[]]$Paths)
    foreach ($path in $Paths) {
        $content = Get-Content $path -Raw
        $null = $content | ConvertFrom-Json
        if ($content -match '(?i)file:|https?://(localhost|127\.0\.0\.1|\[::1\])') {
            throw "Refusing to publish a PR with machine-local package references in $path."
        }
    }
}

function Invoke-GeneratorSdkValidationParallel {
    param([object[]]$Packages, [int]$Parallel, [string]$LogDirectory, [string]$HistoryPath)
    New-Item $LogDirectory -ItemType Directory -Force | Out-Null
    $results = @($Packages | ForEach-Object -ThrottleLimit $Parallel -Parallel {
        $package = $_
        $log = Join-Path $using:LogDirectory "$($package.Name).log"
        $start = Get-Date -AsUTC
        $timer = [Diagnostics.Stopwatch]::StartNew()
        try {
            # Match CI's restore-before-generation ordering: some SDKs import
            # GenerateCode from NuGet targets. Shared npm tools are installed by
            # the parent, not concurrently in every worker.
            & dotnet msbuild (Join-Path $package.FullName "src/$($package.Name).csproj") `
                /restore /t:GenerateCode /p:SkipTspClientInstall=true *> $log
            $code = $LASTEXITCODE
            if ($code -ne 0) { throw "GenerateCode exited with code $code; see $log" }
            [pscustomobject]@{ Package = $package.Name; Success = $true; Seconds = $timer.Elapsed.TotalSeconds; StartedUtc = $start.ToString('o'); FinishedUtc = (Get-Date -AsUTC -Format o); Log = $log; Error = $null }
        }
        catch {
            [pscustomobject]@{ Package = $package.Name; Success = $false; Seconds = $timer.Elapsed.TotalSeconds; StartedUtc = $start.ToString('o'); FinishedUtc = (Get-Date -AsUTC -Format o); Log = $log; Error = "$_" }
        }
    })
    $results | ConvertTo-Json -Depth 5 | Set-Content (Join-Path $LogDirectory results.json)
    Update-GeneratorSdkValidationHistory -HistoryPath $HistoryPath -Results $results
    $results | Sort-Object Package | Format-Table Package, Success, Seconds, Log | Out-Host
    if (@($results | Where-Object { -not $_.Success }).Count) {
        throw "SDK regeneration failed. No commit, push, or PR was attempted. See $LogDirectory/results.json."
    }
    return $results
}

Export-ModuleMember -Function Get-GeneratorSdkValidationIdentity, Get-GeneratorSdkValidationServices, Get-GeneratorSdkValidationSchedule, Update-GeneratorSdkValidationHistory, Invoke-GeneratorSdkValidationCommand, Assert-GeneratorSdkValidationPortableConfig, Invoke-GeneratorSdkValidationParallel
