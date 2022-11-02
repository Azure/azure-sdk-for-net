# FOR TESTING ONLY, DELETE BEFORE MERGE

$packageSuffix = "dev" + [datetime]::UtcNow.Ticks.ToString()
$outputDirectory = "../../buildoutput"
$project = "sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/src/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.csproj"

dotnet --version

dotnet build $project

dotnet "pack" "$project" "-o" $outputDirectory "--no-build" "--version-suffix" "-$packageSuffix"
