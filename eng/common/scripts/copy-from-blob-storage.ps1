param (
    [Parameter(Mandatory = $true)]
    [string] $SourceBlobPath,
    [Parameter(Mandatory = $true)]
    [string] $SASKey,
    [Parameter(Mandatory = $true)]
    [string] $DestinationDirectory
)

Write-Host "Copying from $SourceBlobPath to $DestinationDirectory ..."
$Source = $SourceBlobPath + $SASKey
& azcopy cp $Source $DestinationDirectory --recursive