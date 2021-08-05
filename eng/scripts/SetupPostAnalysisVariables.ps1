[CmdletBinding()]
param (
    [Parameter(Mandatory=$True)]
    [string] $PipelineWorkSpace,
    [Parameter(Mandatory=$True)]
    [string] $SourceDirectory,
    [string] $PoliCheckBaseLineSource
)

$poliCheckBaselineFile = Join-Path $SourceDirectory eng guardian-tools "policheck.gdnbaselines"
$poliCheckBaselineName = "policheck"

if ($PoliCheckBaseLineSource -ieq "empty")
{
    $poliCheckBaselineFile = ''
    $poliCheckBaselineName = ''
}

echo "##vso[task.setvariable variable=PoliCheckBaselineFile]$poliCheckBaselineFile"
echo "##vso[task.setvariable variable=PoliCheckBaselineName]$poliCheckBaselineName"