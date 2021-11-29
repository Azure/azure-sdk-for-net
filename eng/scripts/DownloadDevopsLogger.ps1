ls D:\a\ -recurse
New-Item -ItemType directory artifacts -Force
Invoke-WebRequest -Uri https://vstsagenttools.blob.core.windows.net/tools/msbuildlogger/5/msbuildlogger.zip -OutFile artifacts/msbuildlogger.zip
Expand-Archive artifacts/msbuildlogger.zip -DestinationPath artifacts -Force
$loggerAssembly = Resolve-Path artifacts/Microsoft.TeamFoundation.DistributedTask.MSBuild.Logger.dll
$arguments = "/dl:CentralLogger,`"$loggerAssembly`";`"enableOrphanedProjectsLogs=true`"*ForwardingLogger,`"$loggerAssembly`""
$arguments | Out-File Directory.Build.rsp
