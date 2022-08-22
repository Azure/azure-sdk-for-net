$packageSuffix = "dev" + [datetime]::UtcNow.Ticks.ToString()
$outputDirectory = "/Users/likasem/source/extoutput"
$project = "Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.csproj"
$localNuget = "/Users/likasem/source/localnuget"
# $packageName = "Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.5.1.0-alpha." + $packageSuffix

# Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.5.1.0-alpha.20220822.1.nupkg

dotnet --version

dotnet build

$cmd = "pack", "$project", "-o", $outputDirectory, "--no-build", "--version-suffix", "-$packageSuffix"

& dotnet $cmd

nuget init $outputDirectory $localNuget