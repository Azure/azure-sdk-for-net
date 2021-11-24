Invoke-WebRequest -Uri https://vstsagenttools.blob.core.windows.net/tools/msbuildlogger/3/msbuildlogger.zip -OutFile artifacts/msbuildlogger.zip
Expand-Archive artifacts/msbuildlogger.zip -DestinationPath artifacts
$loggerAssembly = Resolve-Path artifacts/Microsoft.TeamFoundation.DistributedTask.MSBuild.Logger.dll
Write-Host "##vso[task.setvariable variable=DevopsLoggerArguments;]-dl:CentralLogger,`"$loggerAssembly`"*ForwardingLogger,`"$loggerAssembly`""