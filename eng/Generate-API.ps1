$servicesProj = Resolve-Path "$PSScriptRoot/service.proj"

dotnet msbuild /p:Configuration=Release /restore /t:GenerateAPIListing $servicesProj