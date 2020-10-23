. "$PSScriptRoot/AzurePowerShellV4/Utility.ps1"

if ($IsWindows) {
    CleanUp-PSModulePathForHostedAgent
    Update-PSModulePathForHostedAgent
}
else {
    Update-PSModulePathForHostedAgentLinux
}
