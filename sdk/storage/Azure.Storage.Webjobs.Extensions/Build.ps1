param (
  [string]$packageSuffix = "0",
  [bool]$isLocal = $false,
  [string]$outputDirectory = "..\..\buildoutput"
)

if ($isLocal){
  $packageSuffix = "dev" + [datetime]::UtcNow.Ticks.ToString()
  Write-Host "Local build - setting package suffixes to $packageSuffix" -ForegroundColor Yellow
}
dotnet --version

dotnet build Webjobs.sln -v q

if (-not $?) { exit 1 }

$projects = 
  "src\Microsoft.Azure.WebJobs\WebJobs.csproj",
  "src\Microsoft.Azure.WebJobs.Host\WebJobs.Host.csproj",
  "src\Microsoft.Azure.WebJobs.Host\WebJobs.Host.Sources.csproj",
  "src\Microsoft.Azure.WebJobs.Logging\WebJobs.Logging.csproj",
  "src\Microsoft.Azure.WebJobs.Logging.ApplicationInsights\WebJobs.Logging.ApplicationInsights.csproj",
  "src\Microsoft.Azure.WebJobs.Extensions.Storage\WebJobs.Extensions.Storage.csproj",
  "src\Microsoft.Azure.WebJobs.Host.Storage\WebJobs.Host.Storage.csproj",
  "test\Microsoft.Azure.WebJobs.Host.TestCommon\WebJobs.Host.TestCommon.csproj"

foreach ($project in $projects)
{
  $cmd = "pack", "$project", "-o", $outputDirectory, "--no-build"
  
  if ($packageSuffix -ne "0")
  {
    $cmd += "--version-suffix", "-$packageSuffix"
  }

  & dotnet $cmd  
}

### Sign package if build is not a PR
$isPr = Test-Path env:APPVEYOR_PULL_REQUEST_NUMBER
if (-not $isPr -and -not $isLocal) {
  & ".\tools\RunSigningJob.ps1" 
  if (-not $?) { exit 1 }
}
