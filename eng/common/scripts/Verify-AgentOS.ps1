param (
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $AgentImage
)

function Throw-InvalidOperatingSystem {
    throw "Invalid operating system detected. Operating system was: $([System.Runtime.InteropServices.RuntimeInformation]::OSDescription), expected image was: $AgentImage"
}

if ($AgentImage -match "windows|win|MMS2019" -and !$IsWindows) { Throw-InvalidOperatingSystem }
if ($AgentImage -match "ubuntu" -and !$IsLinux) { Throw-InvalidOperatingSystem }
if ($AgentImage -match "macos" -and !$IsMacOs) { Throw-InvalidOperatingSystem }