param (
    [Parameter(Mandatory = $true)]
    [string] $SourceBlobPath,
    [Parameter(Mandatory = $true)]
    [string] $ApplicationId,
    [Parameter(Mandatory = $true)]
    [string] $DestinationDirectory
)

azcopy login --service-principal --application-id $ApplicationId
Write-Host "Copying from $SourceBlobPath to $DestinationDirectory ..."
azcopy cp "${SourceBlobPath}/*" $DestinationDirectory --recursive=true