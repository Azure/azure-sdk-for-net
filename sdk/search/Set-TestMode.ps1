[CmdletBinding(DefaultParameterSetName="None")]
param(
    [parameter(ParameterSetName="None", Mandatory=$true)][switch]$None,
    [parameter(ParameterSetName="Playback", Mandatory=$true)][switch]$Playback,
    [parameter(ParameterSetName="Live", Mandatory=$true)][switch]$Live,
    [parameter(ParameterSetName="Record", Mandatory=$true)][switch]$Record
)

if ($Record)
{
    $mode = "Record"
}
elseif ($Playback)
{
    $mode = "Playback"
}
elseif ($Live)
{
    $mode = "Live"
}
else
{
    $mode = "None"
}

$Env:AZURE_TEST_MODE = $mode

Write-Output "New test mode is: $Env:AZURE_TEST_MODE"