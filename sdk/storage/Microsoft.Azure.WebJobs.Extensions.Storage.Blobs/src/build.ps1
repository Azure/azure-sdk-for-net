$packageSuffix = "dev" + [datetime]::UtcNow.Ticks.ToString()
$outputDirectory = "C:\Users\likasem\source\extoutput"
$project = "Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.csproj"

dotnet --version

dotnet build

$cmd = "pack", "$project", "-o", $outputDirectory, "--no-build", "--version-suffix", "-$packageSuffix"

& dotnet $cmd

Copy-Item -Path "C:\Users\likasem\source\extoutput\*" -Destination "C:\Users\likasem\source\localnuget" -Recurse
