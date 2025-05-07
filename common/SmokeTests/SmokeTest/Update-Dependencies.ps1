param(
    [string]$ProjectFile = (Join-Path $PSScriptRoot './SmokeTest.csproj'),
    [switch]$PreferDevVersion,
    [switch]$CI,
    [string]$ArtifactsPath
)

. (Join-Path $PSScriptRoot ../../../eng/scripts/smoketest/Get-Package-Version.ps1)

# Define a set that contains the list of packages which should not be included
# as references to the smoke tests.  This is necessary because some compatibility
# packages do not target netstandard2.0, and the package source is unable to
# filter upstream to restrict to the appropriate packages for the running target.

$packageExcludeSet = @(
    "Microsoft.Azure.WebPubSub.AspNetCore",
    "Microsoft.WCF.Azure.StorageQueues",
    "Azure.Projects.Web",
    "OpenAI"
)

function Log-Warning($message) {
    if ($CI) {
        Write-Host "##vso[task.logissue type=warning]$message"
    } else {
        Write-Warning $message
    }
}

function Log-Info($message) {
    Write-Host $message
}

function AddPackageReference($csproj, $referenceNode, $packageInfo) {
    $package = $packageInfo.Name
    $version = $packageInfo.Version

    if ($PreferDevVersion -and $packageInfo.DevVersion) {
        $version = $packageInfo.DevVersion
    }

    if ($version -and $package) {
        Log-Info "Adding a reference for: '$($package)', version:'$($version)'."
    } else {
        Log-Warning "Missing artifact name or for '$($package)' [$($version)]."
        return 0
    }

    $packageNode = $csproj.CreateElement('PackageReference')
    $referenceNode.AppendChild($packageNode) | Out-Null

    $includeAttribute = $csproj.CreateAttribute('Include')
    $includeAttribute.Value = $package

    $versionAttribute = $csproj.CreateAttribute('Version')
    $versionAttribute.Value = $version

    $packageNode.Attributes.Append($includeAttribute) | Out-Null
    $packageNode.Attributes.Append($versionAttribute) | Out-Null

    return 1
}

# Start the update process.
$projectPath = Resolve-Path -Path $ProjectFile
Log-Info "Updating the smoke test project: '$($projectPath)'"

# Load the project file and locate the node to overwrite.
$csproj = New-Object xml
$csproj.Load($projectPath)
$referenceNode = $csproj.SelectSingleNode('//Project/ItemGroup[@Label="SmokeTestPackageReferences"]')

# Clear all existing references.
$referenceNode.InnerXml = ''

# Query the available packages and create references for each.
Log-Info "Querying package information."

$referenceUpdateCount = 0

Get-SmokeTestPkgProperties -ArtifactsPath $ArtifactsPath
| Where-Object { $packageExcludeSet -notcontains $_.Name }
| Foreach-Object { $referenceUpdateCount += AddPackageReference $csproj $referenceNode $_ }

# Save the project and report the outcome.  If no refrences were added, consider this
# an exception state and throw.  This is intended to prevent a smoke test run against an
# empty project being considered a successful check.
$csproj.Save($projectPath)

if ($referenceUpdateCount -gt 0) {
    Log-Info "Updates complete.  $($referenceUpdateCount) package references were added."
} else {
    throw "No packages have been referenced."
}
