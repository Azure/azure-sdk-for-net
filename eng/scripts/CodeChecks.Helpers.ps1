# Helper functions for CodeChecks.ps1
# Separated so they can be unit-tested without executing the main script.

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
