param (
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $AgentPool,

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $AgentImage
)

class Rule {
    [string]
    $AgentPool
    [string]
    $AgentImage
    [string]
    $AgentOS

    Rule([string]$agentPool, [string]$agentImage, [string]$agentOS) {
        $this.AgentPool = $agentPool
        $this.AgentImage = $agentImage
        $this.AgentOS = $agentOS
    }
}

$rules = @(
    [Rule]::new("Azure Pipelines", "windows-2019", "Windows")
    [Rule]::new("Azure Pipelines", "vs2017-win2016", "Windows")
    [Rule]::new("Azure Pipelines", "ubuntu-latest", "Linux")
    [Rule]::new("Azure Pipelines", "ubuntu-20.04", "Linux")
    [Rule]::new("Azure Pipelines", "ubuntu-18.04", "Linux")
    [Rule]::new("Azure Pipelines", "ubuntu-16.04", "Linux")
    [Rule]::new("Azure Pipelines", "macOS-latest", "MacOS")
    [Rule]::new("Azure Pipelines", "macOS-10.05", "MacOS")
    [Rule]::new("Azure Pipelines", "macOS-10.04", "MacOS")
    [Rule]::new("azsdk-pool-mms-ubuntu-1604-general", "MMSUbuntu16.04", "Linux")
    [Rule]::new("azsdk-pool-mms-ubuntu-1804-general", "MMSUbuntu18.04", "Linux")
    [Rule]::new("azsdk-pool-mms-ubuntu-2004-general", "MMSUbuntu20.04", "Linux")
    [Rule]::new("azsdk-pool-mms-win-2019-general", "MMS2019", "Windows")
)

Write-Host "Valid rules are:"
$rules | Format-Table

foreach ($rule in $rules)
{
    if (($rule.AgentPool -eq $AgentPool) -and ($rule.AgentImage -eq $AgentImage)) {

        # This strange expression allows us to exploit the built-in PowerShell OS detection
        # without us having to worry about parsing OS version strings etc. 
        if (($rule.AgentOS -eq "Windows" -and $IsWindows) -or `
            ($rule.AgentOS -eq "Linux" -and $IsLinux) -or `
            ($rule.AgentOS -eq "MacOS" -and $IsMacOS)) {
            
            return;
        }
    }
}

throw "Invalid operating system detected. Operating system was: $([System.Runtime.InteropServices.RuntimeInformation]::OSDescription)"