$success = $true

$projects = 
  "test\Microsoft.Azure.WebJobs.Host.UnitTests",
  "test\Microsoft.Azure.WebJobs.Host.FunctionalTests",
  "test\Microsoft.Azure.WebJobs.Logging.FunctionalTests",
  "test\Microsoft.Azure.WebJobs.Host.EndToEndTests",
  "test\Microsoft.Azure.Webjobs.Extensions.Storage.UnitTests"
  

foreach ($project in $projects)
{
  $cmd = "test", "$project", "-v", "q", "--no-build"

  & dotnet $cmd  

  $success = $success -and $?
}


if (-not $success) { exit 1 }