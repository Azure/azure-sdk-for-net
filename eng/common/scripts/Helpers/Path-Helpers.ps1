<#
.SYNOPSIS
Tests whether a repository-relative path is excluded by an ExcludePaths list.

.DESCRIPTION
ExcludePaths entries are matched case-insensitively and literally. An entry ending in '/'
matches that directory and its descendants. Any other entry matches only the exact path.
Glob syntax is not interpreted.

.PARAMETER Path
The repository-relative path to test, using '/' as the directory separator.

.PARAMETER ExcludePaths
The repository-relative file and directory exclusions.
#>
function Test-PathExcluded {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Path,

        [AllowEmptyCollection()]
        [string[]]$ExcludePaths = @()
    )

    foreach ($excludePath in $ExcludePaths) {
        if ($excludePath.EndsWith('/')) {
            if ($Path.StartsWith($excludePath, [System.StringComparison]::CurrentCultureIgnoreCase)) {
                return $true
            }
        }
        elseif ($Path.Equals($excludePath, [System.StringComparison]::CurrentCultureIgnoreCase)) {
            return $true
        }
    }

    return $false
}
