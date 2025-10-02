Set-StrictMode -Version 4

function Get-SystemArchitecture {
    $unameOutput = uname -m
    switch ($unameOutput) {
        "x86_64" { return "X86_64" }
        "aarch64" { return "ARM64" }
        "arm64" { return "ARM64" }
        default { throw "Unable to determine system architecture. uname -m returned $unameOutput." }
    }
}

function Get-Package-Meta(
    [Parameter(mandatory = $true)]
    $FileName,
    [Parameter(mandatory = $true)]
    $Package
) {
    $ErrorActionPreferenceDefault = $ErrorActionPreference
    $ErrorActionPreference = "Stop"

    $AVAILABLE_BINARIES = @{
        "Windows" = @{
            "AMD64" = @{
                "system"     = "Windows"
                "machine"    = "AMD64"
                "file_name"  = "$FileName-standalone-win-x64.zip"
                "executable" = "$Package.exe"
            }
        }
        "Linux"   = @{
            "X86_64" = @{
                "system"     = "Linux"
                "machine"    = "X86_64"
                "file_name"  = "$FileName-standalone-linux-x64.tar.gz"
                "executable" = "$Package"
            }
            "ARM64"  = @{
                "system"     = "Linux"
                "machine"    = "ARM64"
                "file_name"  = "$FileName-standalone-linux-arm64.tar.gz"
                "executable" = "$Package"
            }
        }
        "Darwin"  = @{
            "X86_64" = @{
                "system"     = "Darwin"
                "machine"    = "X86_64"
                "file_name"  = "$FileName-standalone-osx-x64.zip"
                "executable" = "$Package"
            }
            "ARM64"  = @{
                "system"     = "Darwin"
                "machine"    = "ARM64"
                "file_name"  = "$FileName-standalone-osx-arm64.zip"
                "executable" = "$Package"
            }
        }
    }

    if ($IsWindows) {
        $os = "Windows"
        # we only support x64 on windows, if that doesn't work the platform is unsupported
        $machine = "AMD64"
    }
    elseif ($IsLinux) {
        $os = "Linux"
        $machine = Get-SystemArchitecture
    }
    elseif ($IsMacOS) {
        $os = "Darwin"
        $machine = Get-SystemArchitecture
    }
    else {
        $os = "unknown"
    }

    $ErrorActionPreference = $ErrorActionPreferenceDefault

    return $AVAILABLE_BINARIES[$os][$machine]
}

function Clear-Directory ($path) {
    if (Test-Path -Path $path) {
        Remove-Item -Path $path -Recurse -Force
    }
    New-Item -ItemType Directory -Path $path -Force
}

function isNewVersion(
    [Parameter(mandatory = $true)]
    $Version,
    [Parameter(mandatory = $true)]
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

function Get-GitHubApiHeaders {
    # Use GitHub cli to get an auth token if available
    $token = ""
    if (Get-Command gh -ErrorAction SilentlyContinue) {
        try
        {
            $token = gh auth token 2>$null
        }
        catch
        {
            Write-Host "Failed to get GitHub CLI auth token."
        }
    }

    # Get token from env if not available from gh cli
    if (!$token)
    {
        Write-Host "Checking for GITHUB_TOKEN environment variable."
        $token = $env:GITHUB_TOKEN
    }

    if ($token)
    {
        Write-Host "Using authenticated GitHub API requests."
        $headers = @{
            Authorization = "Bearer $token"
        }
        return $headers
    }
    Write-Host "Using unauthenticated GitHub API requests."
    return @{}
}

<#
.SYNOPSIS
Installs a standalone version of an engsys tool.
.PARAMETER Version
The version of the tool to install. Requires a full version to be provided. EG "1.0.0-dev.20240617.1"
.PARAMETER Directory
The directory within which the exe will exist after this function invokes. Defaults to "."
#>
function Install-Standalone-Tool (
    [Parameter()]
    [string]$Version,
    [Parameter(mandatory = $true)]
    [string]$FileName,
    [Parameter(mandatory = $true)]
    [string]$Package,
    [Parameter()]
    [string]$Repository = "Azure/azure-sdk-tools",
    [Parameter()]
    $Directory = "."
) {
    $ErrorActionPreference = "Stop"
    $PSNativeCommandUseErrorActionPreference = $true

    $systemDetails = Get-Package-Meta -FileName $FileName -Package $Package

    if (!(Test-Path $Directory) -and $Directory -ne ".") {
        New-Item -ItemType Directory -Path $Directory -Force | Out-Null
    }

    $tag = "${Package}_${Version}"
    $headers = Get-GitHubApiHeaders

    if (!$Version -or $Version -eq "*") {
        Write-Host "Attempting to find latest version for package '$Package'"
        $releasesUrl = "https://api.github.com/repos/$Repository/releases"
        $releases = Invoke-RestMethod -Uri $releasesUrl -Headers $headers
        $found = $false
        foreach ($release in $releases) {
            if ($release.tag_name -like "$Package*") {
                $tag = $release.tag_name
                $Version = $release.tag_name -replace "${Package}_", ""
                $found = $true
                break
            }
        }
        if ($found -eq $false) {
            throw "No release found for package '$Package'"
        }
    }

    $downloadFolder = Resolve-Path $Directory
    $downloadUrl = "https://github.com/$Repository/releases/download/$tag/$($systemDetails.file_name)"
    $downloadFile = $downloadUrl.Split('/')[-1]
    $downloadLocation = Join-Path $downloadFolder $downloadFile
    $savedVersionTxt = Join-Path $downloadFolder "downloaded_version.txt"
    $executable_path = Join-Path $downloadFolder $systemDetails.executable

    if (isNewVersion $version $downloadFolder) {
        Write-Host "Installing '$Package' '$Version' to '$downloadFolder' from $downloadUrl"
        Invoke-WebRequest -Uri $downloadUrl -OutFile $downloadLocation -Headers $headers

        if ($downloadFile -like "*.zip") {
            Expand-Archive -Path $downloadLocation -DestinationPath $downloadFolder -Force
        }
        elseif ($downloadFile -like "*.tar.gz") {
            tar -xzf $downloadLocation -C $downloadFolder
        }
        else {
            throw "Unsupported file format"
        }

        # Remove the downloaded file after extraction
        Remove-Item -Path $downloadLocation -Force

        # Record downloaded version
        Set-Content -Path $savedVersionTxt -Value $Version

        # Set executable permissions if on macOS (Darwin)
        if ($IsMacOS) {
            chmod 755 $executable_path
        }
    }
    else {
        Write-Host "Target version '$Version' already present in target directory '$downloadFolder'"
    }

    return $executable_path
}

function Get-CommonInstallDirectory {
    $installDirectory = Join-Path $HOME "bin"
    if (-not (Test-Path $installDirectory)) {
        New-Item -ItemType Directory -Path $installDirectory -Force | Out-Null
    }

    # Update PATH in current session
    if (-not ($env:PATH -like "*$InstallDirectory*")) {
        $env:PATH += ";$InstallDirectory"
    }

    return $installDirectory
}

function Add-InstallDirectoryToPathInProfile(
    [Parameter()]
    [string]$InstallDirectory = (Get-CommonInstallDirectory)
) {
    $powershellProfilePath = $PROFILE
    $bashrcPath = Join-Path $HOME ".bashrc"
    $zshrcPath = Join-Path $HOME ".zshrc"
    $markerComment = "  # azsdk install path"
    $pathCommand = ""
    $configFile = ""

    if ($IsWindows) {  # expect powershell for windows, cmd.exe path update is not currently supported
        $configFile = $powershellProfilePath
        $pathCommand = "if (-not (`$env:PATH -like `'*$InstallDirectory*`')) { `$env:PATH += ';$InstallDirectory`' }" + $markerComment
    }
    elseif ($IsLinux) {  # handle bash or zsh shells for linux
        if (Test-Path $zshrcPath) {
            $configFile = $zshrcPath
        }
        else {
            $configFile = $bashrcPath
        }
        $pathCommand = "export PATH=`"`$PATH:$InstallDirectory`"" + $markerComment
    }
    elseif ($IsMacOS) {  # mac os should use zsh by default
        $configFile = $zshrcPath
        $pathCommand = "export PATH=`"`$PATH:$InstallDirectory`"" + $markerComment
    }
    else {
        throw "Unsupported platform"
    }

    if (-not (Test-Path $configFile)) {
        New-Item -ItemType File -Path $configFile -Force | Out-Null
    }

    $configContent = Get-Content $configFile -Raw

    if (!$configContent -or !$configContent.Contains($markerComment)) {
        Write-Host "Adding installation to PATH in shell profile at '$configFile'"
        Add-Content -Path $configFile -Value ([Environment]::NewLine + $pathCommand)
    }
}
