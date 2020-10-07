$ModulesUrl = "https://pakrym0test0storage.blob.core.windows.net/myblobcontainer/AllModules.zip"
$TempPath = Join-Path $([System.IO.Path]::GetTempPath()) $(New-Guid)
$ZipFile = Join-Path $TempPath "Modules.zip"

New-Item $TempPath -ItemType Directory -Force

Invoke-WebRequest -Uri $ModulesUrl -OutFile $ZipFile 
Expand-Archive $ZipFile -DestinationPath $TempPath -Force

$p = [Environment]::GetEnvironmentVariable("PSMODULEPATH")
$p = "$p" + $([System.IO.Path]::PathSeparator) + "$TempPath";
[Environment]::SetEnvironmentVariable("PSMODULEPATH", $p, "User")
Write-Host "Updating PSModulePath to $p"
Write-Host "##vso[task.setvariable variable=PSMODULEPATH]$p"
