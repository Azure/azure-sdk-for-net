# Remove old
Remove-Item -Path "$PSScriptRoot\Generated" -Force -Recurse

# Generate
powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File "$(split-path $SCRIPT:MyInvocation.MyCommand.Path -parent)\..\..\..\..\tools\generateTool.ps1" -ResourceProvider "azsadmin/resource-manager/keyvault" -PowershellInvoker  -AutoRestVersion "latest" -SdkRootDirectory $PSScriptRoot

# Cleanup
$From = Join-Path -Path $PSScriptRoot -ChildPath "KeyVault\KeyVault.Admin\Generated"
$To = $PSScriptRoot
Move-Item -Path $From  -Destination $To -Force
Remove-Item -Path "$PSScriptRoot\Commerce" -Recurse -Force
