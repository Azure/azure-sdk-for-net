# Remove Old
Remove-Item "$PSScriptRoot\Generated" -Force -Recurse -ErrorAction SilentlyContinue

# Generate new
powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File "$(split-path $SCRIPT:MyInvocation.MyCommand.Path -parent)\..\..\..\..\tools\generateTool.ps1" -ResourceProvider "storage/resource-manager" -PowershellInvoker  -AutoRestVersion "latest"


# Move
$From = "$PSScriptRoot\Storage\Management.Storage\Generated\Management.Storage\Generated"
$To = "$PSScriptRoot\Generated"
Move-Item -Path $From -Destination $To -Force

# Cleanup
Remove-Item "$PSScriptRoot\Storage" -Force -Recurse