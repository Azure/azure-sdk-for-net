#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"
netstd13="netstandard1.3"
netstd16="netstandard1.6"
netcore11='netcoreapp1.1'
ubuntu1404="ubuntu.14.04-x64"
nugetOrgSource="https://api.nuget.org/v3/index.json"

dotnet --info

echo Restoring... $ubuntu1404
dotnet restore Fluent.Tests.sln -r $ubuntu1404
echo Building... $netcore11

dotnet build src/ResourceManagement/ResourceManager/Microsoft.Azure.Management.ResourceManager.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/Storage/Microsoft.Azure.Management.Storage.Fluent.csproj -f $netstd13 
dotnet build src/ResourceManagement/Graph.RBAC/Microsoft.Azure.Management.Graph.RBAC.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/Network/Microsoft.Azure.Management.Network.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/AppService/Microsoft.Azure.Management.AppService.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/Batch/Microsoft.Azure.Management.Batch.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/Cdn/Microsoft.Azure.Management.Cdn.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/Compute/Microsoft.Azure.Management.Compute.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/ContainerRegistry/Microsoft.Azure.Management.ContainerRegistry.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/Dns/Microsoft.Azure.Management.Dns.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/CosmosDB/Microsoft.Azure.Management.CosmosDB.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/KeyVault/Microsoft.Azure.Management.KeyVault.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/RedisCache/Microsoft.Azure.Management.Redis.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/Search/Microsoft.Azure.Management.Search.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/ServiceBus/Microsoft.Azure.Management.ServiceBus.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/Sql/Microsoft.Azure.Management.Sql.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/TrafficManager/Microsoft.Azure.Management.TrafficManager.Fluent.csproj -f $netstd13
dotnet build src/ResourceManagement/Azure.Fluent/Microsoft.Azure.Management.Fluent.csproj -f $netstd13
dotnet build Samples/Samples.csproj  -f $netstd16
dotnet build Tests/Fluent.Tests/Fluent.Tests.csproj -f $netcore11
dotnet build Tests/Samples.Tests/Samples.Tests.csproj -f $netcore11

echo Running Samples Tests
cd $rootdir/Tests/Samples.Tests
dotnet test Samples.Tests.csproj -f $netcore11

echo Running Fluent Tests
cd $rootdir/Tests/Fluent.Tests
dotnet test Fluent.Tests.csproj -f $netcore11
