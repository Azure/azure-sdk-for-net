$servicesProj = Resolve-Path "$PSScriptRoot/service.proj"

dotnet build /p:GenerateApiListingOnBuild=true /p:Configuration=Release /p:IncludeSamples=false /p:IncludeTests=false /restore $servicesProj /bl