# Remove Old
Remove-Item "$PSScriptRoot\Generated" -Force -Recurse -ErrorAction SilentlyContinue

# Generate new
powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File "$(split-path $SCRIPT:MyInvocation.MyCommand.Path -parent)\..\..\..\..\tools\generateTool.ps1" -ResourceProvider "azsadmin/resource-manager/user-subscriptions" -PowershellInvoker  -AutoRestVersion "latest" -SdkDirectory $PSScriptRoot

# Move
$From = "$PSScriptRoot\Generated"
$To = "$PSScriptRoot\Generated"
Move-Item -Path $From -Destination $To -Force

# Cleanup
Remove-Item "$PSScriptRoot\Subscriptions" -Force -Recurse