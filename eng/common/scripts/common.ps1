
$global:RepoRoot = Resolve-Path "$PSScriptRoot..\..\..\.."
$global:EngDir = Join-Path $global:RepoRoot "eng"
$global:EngCommonDir = Join-Path $global:EngDir "common"
$global:EngCommonScriptsDir = Join-Path $global:EngCommonDir "scripts"
$global:EngCommonScriptsSharedDir = Join-Path $global:EngCommonScriptsDir "shared"
$global:EngScriptsDir = Join-Path $global:EngDir "scripts"

# Import common scripts
. (Join-Path $global:EngCommonScriptsSharedDir SemVer.ps1)
. (Join-Path $global:EngCommonScriptsSharedDir Changelog-Operations.ps1)
. (Join-Path $global:EngCommonScriptsSharedDir Package-Properties.ps1)

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
$ExtractPkgProps = "Extract-${Language}-PkgPropertiesFn"
$ParsePkgInfoFn = "Parse-${PackageRepository}-PackageFn"
$StageAndUpload = "StageAndUpload-${Language}-DocsFn"