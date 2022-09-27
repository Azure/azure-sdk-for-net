$packageSuffix = "dev" + [datetime]::UtcNow.Ticks.ToString()
$outputDirectory = "../../../../../../buildoutput"
$project = "Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.csproj"

dotnet --version

dotnet build

$cmd = "pack", "$project", "-o", $outputDirectory, "--no-build", "--version-suffix", "-$packageSuffix"

& dotnet $cmd
