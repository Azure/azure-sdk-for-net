#
# Microsoft Azure SDK for Net - Generate library code
# Copyright (C) Microsoft Corporation. All Rights Reserved.
#
powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File "$(split-path $SCRIPT:MyInvocation.MyCommand.Path -parent)\..\..\..\..\tools\generateTool.ps1" -ResourceProvider "signalr/resource-manager" -PowershellInvoker  -AutoRestVersion "latest"
