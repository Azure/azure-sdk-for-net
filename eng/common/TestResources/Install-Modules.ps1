$ModulesUrl = "https://pakrym0test0storage.blob.core.windows.net/myblobcontainer/AllModules.zip"
$TempPath = Join-Path $([System.IO.Path]::GetTempPath()) $(New-Guid)
$ZipFile = Join-Path $TempPath "Modules.zip"

New-Item $TempPath -ItemType Directory -Force

Invoke-WebRequest -Uri $ModulesUrl -OutFile $ZipFile 
Expand-Archive $ZipFile -DestinationPath $TempPath -Force

$p = [Environment]::GetEnvironmentVariable("PSModulePath")
$p = "$p" + $([System.IO.Path]::PathSeparator) + "$TempPath";
[Environment]::SetEnvironmentVariable("PSModulePath", $p, "Machine")
[Environment]::SetEnvironmentVariable("PSMODULEPATH", $p, "Machine")
Write-Host "Updating PSModulePath to $p"
Write-Host "##vso[task.setvariable variable=PSModulePath]$p"
Write-Host "##vso[task.setvariable variable=PSMODULEPATH]$p"
