# Remove Old
Remove-Item "$PSScriptRoot\Generated" -Force -Recurse -ErrorAction SilentlyContinue

# Generate new
powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File "$(split-path $SCRIPT:MyInvocation.MyCommand.Path -parent)\..\..\..\..\tools\generateTool.ps1" -ResourceProvider "azsadmin/resource-manager/compute" -PowershellInvoker  -AutoRestVersion "latest" -SdkRootDirectory $PSScriptRoot

# Move
$From = "$PSScriptRoot\Compute\Compute.Admin\Generated"
$To = "$PSScriptRoot\Generated"
Move-Item -Path $From -Destination $To -Force

# Cleanup
Remove-Item "$PSScriptRoot\Compute" -Force -Recurse
