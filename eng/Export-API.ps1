$servicesProj = Resolve-Path "$PSScriptRoot/service.proj"

dotnet msbuild /p:Configuration=Release /p:IncludeSamples=false /p:IncludeTests=false /restore /t:GenerateAPIListing $servicesProj