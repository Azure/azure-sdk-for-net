[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory,
    [string] $SDKType = "all"
)

$servicesProj = Resolve-Path "$PSScriptRoot/../service.proj"

dotnet build /t:ExportApi /p:RunApiCompat=false /p:InheritDocEnabled=false /p:GeneratePackageOnBuild=false /p:Configuration=Release /p:IncludeSamples=false /p:IncludePerf=false /p:IncludeStress=false /p:IncludeTests=false /p:Scope="$ServiceDirectory" /p:SDKType=$SDKType /restore $servicesProj
