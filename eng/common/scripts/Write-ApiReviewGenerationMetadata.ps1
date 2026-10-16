[CmdletBinding()]
param(
    [string]$ArtifactOutputDirectory = $env:ARTIFACT_OUTPUT_DIRECTORY,
    [string]$OperationId = $env:OPERATION_ID,
    [string]$Kind = $env:KIND,
    [string]$Ref = $env:REF,
    [string]$SourceCommit = $env:SOURCE_COMMIT
)

Set-StrictMode -Version 4
$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($ArtifactOutputDirectory) -or [string]::IsNullOrWhiteSpace($OperationId)) {
    throw 'ArtifactOutputDirectory and OperationId are required.'
}
if ($Kind -notin 'base', 'target') {
    throw 'Kind must be base or target.'
}
if ($Ref -notmatch '^refs/(heads|tags)/.+$') {
    throw 'Ref must be a fully-qualified branch or tag ref.'
}
if ($SourceCommit -notmatch '^[0-9a-f]{40}$') {
    throw 'SourceCommit must be a 40-character Git commit SHA.'
}

New-Item -ItemType Directory -Force -Path $ArtifactOutputDirectory | Out-Null
@{
    operationId = $OperationId
    kind = $Kind
    ref = $Ref
    sourceCommit = $SourceCommit
} | ConvertTo-Json -Compress | Set-Content -LiteralPath (Join-Path $ArtifactOutputDirectory 'generation-metadata.json') -Encoding utf8NoBOM
