<#
.SYNOPSIS
Given a directory containing packageInfo json files and a repository root,
add or update the namespaces. This script MUST be run in the build job after
the build task.

.DESCRIPTION
Given a directory containing the packgeInfo json files, for each file call
to get the namespaces from the DLL and populate the packageInfo file with
the namespace information.

.PARAMETER packageInfoDirectory
The directory where the packageInfo files have been created. These files will
be updated with namespaces information.

.PARAMETER repoRoot
The root of the repository. This, along with the information in the packageInfo
files, is used to compute the the build path to the .dll so namespaces can be
parsed from it. Using Azure.Template as an example, the path to the binary would
be in $repoRoot/artifacts/bin/Azure.Template/Release/netstandard2.0/Azure.Template.dll

.PARAMETER buildConfiguration
Debug or Release. This is the same $(BuildConfiguration) variable that's used to set
in the dotnet pack command of the Build and Package task. It's necessary in order to
construct the artifacts bin directory correctly.
#>
[CmdletBinding()]
Param (
    [Parameter(Mandatory = $True)]
    [string] $repoRoot,
    [Parameter(Mandatory = $True)]
    [string] $packageInfoDirectory,
    [Parameter(Mandatory = $True)]
    [string] $buildConfiguration
)

. (Join-Path $PSScriptRoot ".." common scripts common.ps1)
Write-Host "repoRoot=$repoRoot"
Write-Host "packageInfoDirectory=$packageInfoDirectory"
if (-not (Test-Path -Path $packageInfoDirectory)) {
    LogError "packageInfoDirectory '$packageInfoDirectory' does not exist."
    exit 1
}
if (-not (Test-Path -Path $repoRoot)) {
    LogError "repoRoot '$repoRoot' does not exist."
    exit 1
}
# Get all of the packageInfo files
$packageInfoFiles = Get-ChildItem -Path $packageInfoDirectory -Filter *.json `
    | Where-Object { (Get-Content -Raw $_ | ConvertFrom-Json).IncludedForValidation -eq $false }

if ($packageInfoFiles.Length -eq 0) {
    LogWarning "packageInfoDirectory '$packageInfoDirectory' does not contain any json files. Please ensure that the packageInfo files were generated prior to running this."
    exit 0
}

$foundError = $false
# At this point the packageInfo files should have been already been created
# and the only thing being done here is adding namespaces
foreach ($packageInfoFile in $packageInfoFiles) {
    Write-Host "processing $($packageInfoFile.FullName)"
    $packageInfo = ConvertFrom-Json (Get-Content $packageInfoFile -Raw)
    # Piece together the artifacts bin directory. Note that the artifactsBinDir
    # directory cannot include the netstandard2.0 because anything not building
    # with the netstandard2.0 will be in a different subdirectory
    $artifactsBinDir = Join-Path $repoRoot "artifacts" "bin" $packageInfo.Name $buildConfiguration
    Write-Host "artifactsBinDir=$artifactsBinDir"
    if (Test-Path $artifactsBinDir) {
        $dllName = "$($packageInfo.Name).dll"
        # This needs to ensure an array is always returned.
        $foundDlls = @(Get-ChildItem -Path $artifactsBinDir -Recurse -File -Filter $dllName)
        if (-not $foundDlls) {
            LogError "$dllName does not exist in any of the subdirectories of $artifactsBinDir"
            $foundError = $true
            continue
        }
        $defaultDll = $foundDlls[0]
        Write-Host "dll file path: $($defaultDll.FullName)"
        $namespaces = @(Get-NamespacesFromDll $defaultDll)
        if ($namespaces.Count -gt 0) {
            Write-Host "Get-NamespacesFromDll returned the following namespaces:"
            foreach ($namespace in $namespaces) {
                Write-Host "  $namespace"
            }
            # If by some reason, the namespaces already exist, overwrite them with
            # what was just computed
            if ($packageInfo.PSobject.Properties.Name -contains "Namespaces") {
                $packageInfo.Namespaces = $namespaces
            }
            else {
                $packageInfo = $packageInfo | Add-Member -MemberType NoteProperty -Name Namespaces -Value $namespaces -PassThru
            }
            $packageInfoJson = ConvertTo-Json -InputObject $packageInfo -Depth 100
            Write-Host "The updated packageInfo for $packageInfoFile is:"
            Write-Host "$packageInfoJson"
            Set-Content `
                -Path $packageInfoFile `
                -Value $packageInfoJson
        }
        else {
            LogWarning "Unable to get namespaces for $($defaultDll.FullName)"
        }
    }
    else {
        LogError "$artifactsBinDir path did not exist. Unable to get namespaces for for $($packageInfo.Name), version=$($packageInfo.Verison)"
        $foundError = $true
    }
}

if ($foundError) {
    exit 1
}
exit 0