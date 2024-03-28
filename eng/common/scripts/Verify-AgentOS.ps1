param (
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $AgentImage
)

function Throw-InvalidOperatingSystem {
    throw "Invalid operating system detected. Operating system was: $([System.Runtime.InteropServices.RuntimeInformation]::OSDescription), expected image was: $AgentImage"
}

if ($IsWindows -and $AgentImage -match "windows|win|MMS\d{4}") {
    $osName = "Windows"
} elseif ($IsLinux -and $AgentImage -match "ubuntu|linux") {
    $osName = "Linux"
} elseif ($IsMacOs -and $AgentImage -match "macos|macOS") {
    $osName = "macOS"
} else {
    Throw-InvalidOperatingSystem
}

Write-Host "##vso[task.setvariable variable=OSName]$osName"
