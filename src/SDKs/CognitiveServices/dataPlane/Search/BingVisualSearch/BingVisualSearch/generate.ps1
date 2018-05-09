<#
    This is a template to describe how to call the generateTool.ps1 script to generate the code using AutoRest
#>
powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File "$(split-path $SCRIPT:MyInvocation.MyCommand.Path -parent)\..\..\..\..\..\..\..\tools\generateTool.ps1" -ResourceProvider "cognitiveservices/data-plane/VisualSearch" -PowershellInvoker