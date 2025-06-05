Set-StrictMode -Version 4
$AVAILABLE_TEST_PROXY_BINARIES = @{
    "Windows" = @{
        "AMD64" = @{
            "system" = "Windows"
            "machine" = "AMD64"
            "file_name" = "test-proxy-standalone-win-x64.zip"
            "executable" = "Azure.Sdk.Tools.TestProxy.exe"
        }
    }
    "Linux" = @{
        "X86_64" = @{
            "system" = "Linux"
            "machine" = "X86_64"
            "file_name" = "test-proxy-standalone-linux-x64.tar.gz"
            "executable" = "Azure.Sdk.Tools.TestProxy"
        }
        "ARM64" = @{
            "system" = "Linux"
            "machine" = "ARM64"
            "file_name" = "test-proxy-standalone-linux-arm64.tar.gz"
            "executable" = "Azure.Sdk.Tools.TestProxy"
        }
    }
    "Darwin" = @{
        "X86_64" = @{
            "system" = "Darwin"
            "machine" = "X86_64"
            "file_name" = "test-proxy-standalone-osx-x64.zip"
            "executable" = "Azure.Sdk.Tools.TestProxy"
        }
        "ARM64" = @{
            "system" = "Darwin"
            "machine" = "ARM64"
            "file_name" = "test-proxy-standalone-osx-arm64.zip"
            "executable" = "Azure.Sdk.Tools.TestProxy"
        }
    }
}

function Get-SystemArchitecture {
    $unameOutput = uname -m
    switch ($unameOutput) {
        "x86_64" { return "X86_64" }
        "aarch64" { return "ARM64" }
        "arm64" { return "ARM64" }
        default { throw "Unable to determine system architecture. uname -m returned $unameOutput." }
    }
}

function Get-Proxy-Meta () {
    $ErrorActionPreferenceDefault = $ErrorActionPreference
    $ErrorActionPreference = "Stop"

    $os = "unknown"
    $machine = Get-SystemArchitecture

    if ($IsWindows) {
        $os = "Windows"
        # we only support x64 on windows, if that doesn't work the platform is unsupported
        $machine = "AMD64"
    } elseif ($IsLinux) {
        $os = "Linux"
    } elseif ($IsMacOS) {
        $os = "Darwin"
    }

    $ErrorActionPreference = $ErrorActionPreferenceDefault

    return $AVAILABLE_TEST_PROXY_BINARIES[$os][$machine]
}

function Get-Proxy-Url (
    [Parameter(mandatory=$true)]$Version
) {
    $systemDetails = Get-Proxy-Meta

    $file = $systemDetails.file_name
    $url = "https://github.com/Azure/azure-sdk-tools/releases/download/Azure.Sdk.Tools.TestProxy_$Version/$file"

    return $url
}

function Cleanup-Directory ($path) {
    if (Test-Path -Path $path) {
        Remove-Item -Path $path -Recurse -Force
    }
    New-Item -ItemType Directory -Path $path -Force
}

function Is-Work-Necessary (
    [Parameter(mandatory=$true)]
    $Version,
    [Parameter(mandatory=$true)]
    $Directory
) {
    $savedVersionTxt = Join-Path $Directory "downloaded_version.txt"
    if (Test-Path $savedVersionTxt) {
        $result = (Get-Content -Raw $savedVersionTxt).Trim()

        if ($result -eq $Version) {
            return $false
        }
    }

    return $true
}

<#
.SYNOPSIS
Installs a standalone version of the test-proxy.
.PARAMETER Version
The version of the proxy to install. Requires a full version to be provided. EG "1.0.0-dev.20240617.1"
.PARAMETER Directory
The directory within which the test-proxy exe will exist after this function invokes. Defaults to "."
#>
function Install-Standalone-TestProxy (
    [Parameter(mandatory=$true)]
    $Version,
    $Directory="."
) {
    $ErrorActionPreference = "Stop"
    $systemDetails = Get-Proxy-Meta

    if (!(Test-Path $Directory) -and $Directory -ne ".") {
        New-Item -ItemType Directory -Path $Directory -Force
    }

    $downloadFolder = Resolve-Path $Directory
    $downloadUrl = Get-Proxy-Url $Version
    $downloadFile = $downloadUrl.Split('/')[-1]
    $downloadLocation = Join-Path $downloadFolder $downloadFile
    $savedVersionTxt = Join-Path $downloadFolder "downloaded_version.txt"

    if (Is-Work-Necessary $version $downloadFolder) {
        Write-Host "Commencing installation of `"$Version`" to `"$downloadFolder`" from $downloadUrl."
        Invoke-WebRequest -Uri $downloadUrl -OutFile $downloadLocation

        if ($downloadFile -like "*.zip") {
            Expand-Archive -Path $downloadLocation -DestinationPath $downloadFolder -Force
        } elseif ($downloadFile -like "*.tar.gz") {
            tar -xzf $downloadLocation -C $downloadFolder
        } else {
            throw "Unsupported file format"
        }

        # Remove the downloaded file after extraction
        Remove-Item -Path $downloadLocation -Force

        # Record downloaded version
        Set-Content -Path $savedVersionTxt -Value $Version

        # Set executable permissions if on macOS (Darwin)
        $executable_path = Join-Path $downloadFolder $systemDetails.executable
        if ($IsMacOS) {
            chmod 755 $executable_path
        }
    }
    else {
        Write-Host "Target version `"$Version`" already present in target directory `"$downloadFolder.`""
    }
}
