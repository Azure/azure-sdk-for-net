$global:RepoRoot = Resolve-Path "${PSScriptRoot}..\..\..\.."
$global:EngDir = Join-Path $global:RepoRoot "eng"
$global:EngCommonDir = Join-Path $global:EngDir "common"
$global:EngCommonScriptsDir = Join-Path $global:EngCommonDir "scripts"
$global:EngScriptsDir = Join-Path $global:EngDir "scripts"

# Import required scripts
. (Join-Path $global:EngCommonScriptsDir SemVer.ps1)
. (Join-Path $global:EngCommonScriptsDir Changelog-Operations.ps1)
. (Join-Path $global:EngCommonScriptsDir Package-Properties.ps1)

# Setting expected from common languages settings
$global:Language = "Unknown"
$global:PackageRepository = "Unknown"
$global:packagePattern = "Unknown"
$global:MetadataUri = "Unknown"

# Import common language settings
$EngScriptsLanguageSettings = Join-path $global:EngScriptsDir "Language-Settings.ps1"
if (Test-Path $EngScriptsLanguageSettings) {
  . $EngScriptsLanguageSettings
}

# Transformed Functions
$GetPackageInfoFromRepoFn = "Get-${Language}-PackageInfoFromRepo"
$GetPackageInfoFromPackageFileFn = "Get-${Language}-PackageInfoFromPackageFile"
$PublishGithubIODocsFn = "Publish-${Language}-GithubIODocs"