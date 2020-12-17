[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory,
    [string] $ExcludeProjects
)

$servicesProj = Resolve-Path "$PSScriptRoot/../service.proj"

dotnet build /p:GenerateApiListingOnBuild=true /p:RunApiCompat=false /p:GeneratePackageOnBuild=false /p:Configuration=Release /p:IncludeSamples=false /p:IncludePerf=false /p:IncludeStress=false /p:IncludeTests=false /p:Scope="$ServiceDirectory" /p:ExcludeProjects="$ExcludeProjects" /restore $servicesProj
