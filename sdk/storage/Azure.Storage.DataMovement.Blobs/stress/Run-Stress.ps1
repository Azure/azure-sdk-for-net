[CmdletBinding()]
param (
    # The name of the stress test to run
    [Parameter(Mandatory)]
    [String]
    $TestToRun
)

# Resources must be created already and the necessary values set in the environment

Set-Location -Path "$PSScriptRoot\src"
$null = dotnet build
Set-Location -Path "$PSScriptRoot"
dotnet "..\..\..\..\artifacts\bin\Azure.DataMovement.Blobs.Stress\Debug\net8.0\Azure.DataMovement.Blobs.Stress.dll" --test $TestToRun