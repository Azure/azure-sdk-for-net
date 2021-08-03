[CmdletBinding()]
param (
    [Parameter(Mandatory=$True)]
    [string] $PipelineWorkSpace,
    [Parameter(Mandatory=$True)]
    [string] $SourceDirectory,
    [string] $PoliCheckBaseLineSource,
)

$poliCheckBaselineFile = Join-Path $PipelineWorkSpace "policheck.gdnbaselines"
$poliCheckBaselineName = "policheck"

if ($PoliCheckBaseLineSource -ieq "empty")
{
    $poliCheckBaselineFile = Join-Path $SourceDirectory eng guardian-tools "empty.gdnbaselines"
    $poliCheckBaselineName = "empty"
}

if ($PoliCheckBaseLineSource -ieq "repo")
{
    $poliCheckBaselineFile = Join-Path $SourceDirectory eng guardian-tools "policheck.gdnbaselines"
}

echo "##vso[task.setvariable variable=PoliCheckBaselineFile]$poliCheckBaselineFile"
echo "##vso[task.setvariable variable=PoliCheckBaselineName]$poliCheckBaselineName"