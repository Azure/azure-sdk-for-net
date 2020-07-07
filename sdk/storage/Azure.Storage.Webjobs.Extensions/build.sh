 #!/usr/bin/env bash
 dotnet build WebJobs.sln

 dotnet test ./test/Microsoft.Azure.WebJobs.Host.UnitTests/ -v q --no-build --filter Category!=secretsrequired

 # dotnet test ./test/Microsoft.Azure.WebJobs.Host.FunctionalTests/ -v q --no-build

 # dotnet test ./test/Microsoft.Azure.WebJobs.Logging.FunctionalTests/ -v q --no-build

 # dotnet test ./test/Microsoft.Azure.WebJobs.Host.EndToEndTests/ -v q --no-build