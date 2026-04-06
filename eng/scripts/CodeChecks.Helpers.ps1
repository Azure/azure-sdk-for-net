# Helper functions for CodeChecks.ps1
# Separated so they can be unit-tested without executing the main script.

# Checks whether only CI pipeline config files (ci*.yml) were changed in the given
# service directory relative to the merge base. Returns $true if all changed files
# in sdk/<ServiceDirectory>/ match ci*.yml, meaning codegen/snippets/API export can be skipped.
function Test-OnlyCiConfigChanged {
    param(
        [string]$ServiceDirectory,
        [string]$RepoRoot
    )

    try {
        # Determine the merge base to compare against
        $targetBranch = $env:SYSTEM_PULLREQUEST_TARGETBRANCH
        $targetBranchName = $null
        if ($targetBranch) {
            $targetBranchName = $targetBranch -replace '^refs/heads/', ''
        }

        # Try to find the merge base, falling back through common branch names
        $mergeBase = $null
        $candidates = @()
        if ($targetBranchName) {
            $candidates += "origin/$targetBranchName"
            $candidates += $targetBranchName
        }
        $candidates += "origin/main", "main", "origin/master", "master"

        foreach ($candidate in $candidates) {
            $mergeBase = git -C $RepoRoot merge-base HEAD $candidate 2>$null
            if ($mergeBase) { break }
        }
        if (-not $mergeBase) { return $false }

        $svcPath = "sdk/$ServiceDirectory/"
        $changedFiles = git -C $RepoRoot diff --name-only $mergeBase -- $svcPath 2>$null
        if (-not $changedFiles) { return $false }

        foreach ($file in $changedFiles) {
            $fileName = Split-Path -Leaf $file
            if ($fileName -notmatch '^ci.*\.yml$') {
                return $false
            }
        }

        return $true
    }
    catch {
        # On any error, fall back to running codegen (safe default)
        Write-Host "Warning: Could not determine changed files for $ServiceDirectory — running full checks. Error: $_"
        return $false
    }
}

# Parses a single git status --porcelain line and returns the path(s) it contains.
# For renames ("old -> new"), returns both paths. Returns an empty array for blank/malformed lines.
function Get-PorcelainPaths([string]$line) {
    if ([string]::IsNullOrWhiteSpace($line)) { return @() }
    if ($line.Length -le 3) { return @() }
    # The porcelain format is "XY path" where XY are the two status characters.
    # Skip exactly 3 characters (XY + space) to get the path portion.
    $pathPart = $line.Substring(3)
    # Handle renames of the form "oldpath -> newpath".
    if ($pathPart -match '(.+?)\s->\s(.+)$') {
        return @($matches[1], $matches[2])
    }
    return @($pathPart)
}

# Given the current git status --porcelain lines and a list of pre-existing changed paths,
# returns an object describing which status lines are new (produced by code checks) versus
# which were already present before code checks ran.
function Get-CodeCheckSummary {
    param(
        [string[]]$CurrentStatusLines,
        [string[]]$PreExistingChanges
    )

    $newStatusLines = @()
    foreach ($line in $CurrentStatusLines) {
        # Wrap in @() to prevent PowerShell from unwrapping single-element arrays
        # to strings, which would cause $paths[-1] to return a character instead of a path.
        $paths = @(Get-PorcelainPaths $line)
        if (-not $paths) { continue }
        # For renames, check the destination (last) path against pre-existing changes.
        $checkPath = $paths[-1]
        if ($checkPath -notin $PreExistingChanges) {
            $newStatusLines += $line
        }
    }

    return @{
        NewStatusLines   = $newStatusLines
        PreExistingCount = ($PreExistingChanges | Measure-Object).Count
    }
}

# Validates that packages in the given service directory which are depended on by
# other services have TestDependsOnDependency set in their CI file.
# Returns an array of objects describing any missing entries, each with:
#   Package      - the package name that needs to be covered
#   CiFile       - the CI file path where TestDependsOnDependency should be added
#   Dependents   - list of service directories that depend on this package
function Get-MissingTestDependsOnDependency {
    param(
        [string]$ServiceDirectory,
        [string]$RepoRoot
    )

    $sdkDir = Join-Path $RepoRoot "sdk"
    $svcDir = Join-Path $sdkDir $ServiceDirectory

    if (-not (Test-Path $svcDir)) { return @() }

    $coreInfra = @(
        'Azure.Core', 'Azure.Core.TestFramework', 'Azure.Core.Experimental',
        'Azure.Identity', 'Azure.ResourceManager',
        'System.ClientModel', 'System.ClientModel.SourceGeneration',
        'Microsoft.ClientModel.TestFramework'
    )

    # Find all packages in THIS service directory
    $localPackages = @{}
    Get-ChildItem $svcDir -Directory | ForEach-Object {
        $srcDir = Join-Path $_.FullName "src"
        if (Test-Path $srcDir) {
            Get-ChildItem $srcDir -Filter "*.csproj" -File | ForEach-Object {
                $localPackages[$_.BaseName] = $true
            }
        }
    }

    # Find which local packages are depended on by OTHER services' test projects
    $dependedOn = @{} # packageName -> Set of dependent service dirs
    $refPattern = '<(?:Package|Project)Reference[^>]*Include\s*=\s*"([^"]+)"'

    foreach ($svcItem in (Get-ChildItem $sdkDir -Directory)) {
        $otherSvc = $svcItem.Name
        if ($otherSvc -eq $ServiceDirectory) { continue }

        Get-ChildItem $svcItem.FullName -Recurse -Filter "*.csproj" | Where-Object {
            $_.FullName -match '[/\\]tests[/\\]'
        } | ForEach-Object {
            $content = Get-Content $_.FullName -Raw
            $matches2 = [regex]::Matches($content, $refPattern)
            foreach ($match in $matches2) {
                $refName = $match.Groups[1].Value
                if ($refName -match '[/\\]') {
                    $refName = [System.IO.Path]::GetFileNameWithoutExtension(($refName -replace '\\', '/'))
                }
                if ($localPackages.ContainsKey($refName) -and $refName -notin $coreInfra) {
                    if (-not $dependedOn.ContainsKey($refName)) {
                        $dependedOn[$refName] = [System.Collections.Generic.HashSet[string]]::new()
                    }
                    [void]$dependedOn[$refName].Add($otherSvc)
                }
            }
        }
    }

    if ($dependedOn.Count -eq 0) { return @() }

    # Find which CI file each depended-on package is an artifact in
    $ciFiles = Get-ChildItem $svcDir -Filter "ci*.yml" -File
    $pkgToCiFile = @{}
    foreach ($ciFile in $ciFiles) {
        $content = Get-Content $ciFile.FullName -Raw
        foreach ($pkg in $dependedOn.Keys) {
            $escaped = [regex]::Escape($pkg)
            if ($content -match "(?m)^\s*-\s*name:\s*$escaped\s*$") {
                $pkgToCiFile[$pkg] = $ciFile.FullName
            }
        }
    }

    # Check which are already covered by TestDependsOnDependency
    $missing = @()
    $ciFileCoverage = @{} # ciFilePath -> Set of covered package names
    foreach ($ciFile in $ciFiles) {
        $content = Get-Content $ciFile.FullName -Raw
        if ($content -match 'TestDependsOnDependency:\s*(.+)') {
            $coveredPkgs = $Matches[1].Trim() -split '\s+'
            $ciFileCoverage[$ciFile.FullName] = $coveredPkgs
        } else {
            $ciFileCoverage[$ciFile.FullName] = @()
        }
    }

    foreach ($pkg in $dependedOn.Keys | Sort-Object) {
        $ciFile = $pkgToCiFile[$pkg]
        if (-not $ciFile) { continue }

        $coveredInFile = $ciFileCoverage[$ciFile]
        if ($pkg -notin $coveredInFile) {
            $missing += [PSCustomObject]@{
                Package    = $pkg
                CiFile     = $ciFile
                Dependents = @($dependedOn[$pkg] | Sort-Object)
            }
        }
    }

    return $missing
}

# Adds missing TestDependsOnDependency entries to a CI YAML file.
# If the file already has a TestDependsOnDependency line, merges the new packages.
# If not, appends it at the end of the extends.parameters block.
function Add-TestDependsOnDependency {
    param(
        [string]$CiFilePath,
        [string[]]$PackageNames
    )

    $content = Get-Content $CiFilePath -Raw
    $lines = $content -split "`n"

    if ($content -match 'TestDependsOnDependency:\s*(.+)') {
        $existing = $Matches[1].Trim() -split '\s+'
        $all = @($existing + $PackageNames) | Sort-Object -Unique
        $newValue = "TestDependsOnDependency: $($all -join ' ')"
        $content = $content -replace 'TestDependsOnDependency:\s*.+', $newValue
    } else {
        # Find indentation from extends.parameters block
        $indent = "    "
        for ($i = 0; $i -lt $lines.Length; $i++) {
            if ($lines[$i].Trim() -eq 'parameters:' -and $i -gt 0 -and $lines[$i - 1].Trim() -match 'template:') {
                $paramIndent = $lines[$i].Length - $lines[$i].TrimStart().Length
                $indent = ' ' * ($paramIndent + 2)
                break
            }
        }

        $newLine = "${indent}TestDependsOnDependency: $(($PackageNames | Sort-Object) -join ' ')"

        # Append before the last line of the file (or at end)
        $trimmed = $content.TrimEnd()
        $content = "$trimmed`n$newLine`n"
    }

    $utf8NoBom = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllText($CiFilePath, $content, $utf8NoBom)
}

# Determines the action to take when a git diff is detected after code checks.
# Returns an object with:
#   Action       - "none" (no diffs), "error" (fail with message), or "report" (informational summary)
#   ErrorMessage - the error string (only when Action = "error")
#   Summary      - the Get-CodeCheckSummary result (only when Action = "report")
function Get-DiffCheckResult {
    param(
        [bool]$HasDiff,
        [bool]$SkipDiffValidation,
        [string[]]$CurrentStatusLines = @(),
        [string[]]$PreExistingChanges = @(),
        [string]$ServiceDirectory = ""
    )

    if (-not $HasDiff) {
        return @{ Action = "none" }
    }

    if (-not $SkipDiffValidation) {
        return @{
            Action       = "error"
            ErrorMessage = "Generated code is not up to date.`
    You may need to rebase on the latest main, `
    run 'eng\scripts\Update-Snippets.ps1 $ServiceDirectory' if you modified sample snippets or other *.md files (https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets), `
    run 'eng\scripts\Export-API.ps1 $ServiceDirectory' if you changed public APIs (https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#public-api-additions). `
    run 'dotnet build /t:GenerateCode' to update the generated code and samples.`
    `
To fix this locally, run 'eng\scripts\CodeChecks.ps1 -ServiceDirectory $ServiceDirectory -SkipDiffValidation' and commit the resulting changes."
        }
    }

    $summary = Get-CodeCheckSummary -CurrentStatusLines $CurrentStatusLines -PreExistingChanges $PreExistingChanges
    return @{
        Action  = "report"
        Summary = $summary
    }
}
