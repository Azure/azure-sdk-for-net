param (
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $AgentPool,

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $AgentImage
)

$lookup = @(
    @{ AgentPool = "Azure Pipelines"; AgentImage = "windows-2019"; AgentOSMatch = $IsWindows }
    @{ AgentPool = "Azure Pipelines"; AgentImage = "vs2017-win2016"; AgentOSMatch = $IsWindows }
    @{ AgentPool = "Azure Pipelines"; AgentImage = "ubuntu-latest"; AgentOSMatch = $IsLinux }
    @{ AgentPool = "Azure Pipelines"; AgentImage = "ubuntu-20.04"; AgentOSMatch = $IsLinux }
    @{ AgentPool = "Azure Pipelines"; AgentImage = "ubuntu-18.04"; AgentOSMatch = $IsLinux }
    @{ AgentPool = "Azure Pipelines"; AgentImage = "ubuntu-16.04"; AgentOSMatch = $IsLinux }
    @{ AgentPool = "Azure Pipelines"; AgentImage = "macOS-latest"; AgentOSMatch = $IsMacOs }
    @{ AgentPool = "Azure Pipelines"; AgentImage = "macOS-10.05"; AgentOSMatch = $IsMacOs }
    @{ AgentPool = "Azure Pipelines"; AgentImage = "macOS-10.04"; AgentOSMatch = $IsMacOs }
    @{ AgentPool = "azsdk-pool-mms-ubuntu-1604-general"; AgentImage = "MMSUbuntu16.04"; AgentOSMatch = $IsLinux }
    @{ AgentPool = "azsdk-pool-mms-ubuntu-1804-general"; AgentImage = "MMSUbuntu18.04"; AgentOSMatch = $IsLinux }
    @{ AgentPool = "azsdk-pool-mms-ubuntu-2004-general"; AgentImage = "MMSUbuntu20.04"; AgentOSMatch = $IsLinux }
    @{ AgentPool = "azsdk-pool-mms-win-2019-general"; AgentImage = "MMS2019"; AgentOSMatch = $IsWindows }
)

foreach ($mapping in $lookup)
{
    if (($mapping.AgentPool -eq $AgentPool) -and ($mapping.AgentImage -eq $AgentImage) -and $mapping.AgentOSMatch) {
        return;
    }
}

throw "Agent operating system failed validation!"