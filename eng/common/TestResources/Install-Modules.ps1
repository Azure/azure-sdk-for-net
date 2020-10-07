$ModulesUrl = "https://pakrym0test0storage.blob.core.windows.net/myblobcontainer/AllModules.zip"
$TempPath = Join-Path $([System.IO.Path]::GetTempPath()) $(New-Guid)
$ZipFile = Join-Path $TempPath "Modules.zip"

New-Item $TempPath -ItemType Directory -Force

Invoke-WebRequest -Uri $ModulesUrl -OutFile $ZipFile 
Expand-Archive $ZipFile -DestinationPath $TempPath -Force

$p = [Environment]::GetEnvironmentVariable("PSModulePath")
[Environment]::SetEnvironmentVariable("PSModulePath", "$p;$TempPath", "User")
