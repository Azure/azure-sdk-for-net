#Requires -Version 7.0

<#
.SYNOPSIS
Maps changes to a package's project-scoped engineering files back to the owning package.

.DESCRIPTION
Some per-package configuration lives outside the package's sdk/<service>/<package>
directory, under shared eng/ folders keyed by project (== package) name:

    eng/apicompatbaselines/<Package>.txt                            ApiCompat baselines
    eng/analyzerallowlist/<Package>.txt                             NoWarn / analyzer allow-list
    eng/centralpackagemanagement/overrides/<Package>.Packages.props CPM version overrides

The eng/common PR diff-to-package detection (Get-PkgPropsFromDiff) only attributes a
changed file to a package when the file lives under that package's sdk/ directory (or a
ci.yml TriggeringPath). A change to one of the files above therefore builds nothing, so a
PR that (for example) deletes an ApiCompat baseline can silently ship an ApiCompat
regression because the package is never rebuilt in CI (see #60837 / Azure.Identity).

These helpers map such changes back to their package so PR validation rebuilds it and
re-runs ApiCompat / analyzer validation.
#>

# Project-scoped eng folders where the file base name equals the project (== package) name.
# Prefixes are forward-slash and folder-anchored; Suffix is the file extension to strip.
$script:ProjectScopedEngFilePatterns = @(
    @{ Prefix = "eng/apicompatbaselines/";                 Suffix = ".txt" },
    @{ Prefix = "eng/analyzerallowlist/";                  Suffix = ".txt" },
    @{ Prefix = "eng/centralpackagemanagement/overrides/"; Suffix = ".Packages.props" }
)

function Get-ProjectNamesFromEngFileChanges {
    param(
        [Parameter(Mandatory = $true)]
        [AllowNull()]
        [AllowEmptyCollection()]
        [string[]]$ChangedFiles
    )

    $names = @()
    foreach ($file in $ChangedFiles) {
        if ([string]::IsNullOrWhiteSpace($file)) {
            continue
        }

        $normalized = $file.Replace("\", "/")
        foreach ($pattern in $script:ProjectScopedEngFilePatterns) {
            if (-not $normalized.StartsWith($pattern.Prefix, [System.StringComparison]::OrdinalIgnoreCase)) {
                continue
            }
            if (-not $normalized.EndsWith($pattern.Suffix, [System.StringComparison]::OrdinalIgnoreCase)) {
                continue
            }

            $remainder = $normalized.Substring($pattern.Prefix.Length)
            # Only direct files in the folder map to a package; skip nested paths.
            if ($remainder.Contains("/")) {
                continue
            }

            $baseName = $remainder.Substring(0, $remainder.Length - $pattern.Suffix.Length)
            if ($baseName) {
                $names += $baseName
            }
        }
    }

    return @($names | Select-Object -Unique)
}

function Get-PackagesFromEngFileChanges {
    param(
        [Parameter(Mandatory = $true)]
        $DiffObj,
        [Parameter(Mandatory = $true)]
        [AllowNull()]
        $AllPkgProps
    )

    $files = @()
    if ($DiffObj.ChangedFiles) { $files += $DiffObj.ChangedFiles }
    if ($DiffObj.DeletedFiles) { $files += $DiffObj.DeletedFiles }

    $projectNames = Get-ProjectNamesFromEngFileChanges -ChangedFiles $files

    $matched = @()
    foreach ($name in $projectNames) {
        $pkg = $AllPkgProps | Where-Object { $_.Name -eq $name -or $_.ArtifactName -eq $name } | Select-Object -First 1
        if ($pkg) {
            $matched += $pkg
        }
    }

    return $matched
}
