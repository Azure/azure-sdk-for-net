# Copied from https://github.com/microsoft/azure-pipelines-tasks/blob/a1502bbe67561f5bec8402f32c997406f798a019/Tasks/AzurePowerShellV4/Utility.ps1

function Get-SavedModulePath {
    [CmdletBinding()]
    param([string] $azurePowerShellVersion)
    $savedModulePath = $($env:SystemDrive + "\Modules\az_" + $azurePowerShellVersion)
    Write-Verbose "The value of the module path is: $savedModulePath"
    return $savedModulePath 
}

function Get-SavedModulePathLinux {
    [CmdletBinding()]
    param([string] $azurePowerShellVersion)
    $savedModulePath =  $("/usr/share/az_" + $azurePowerShellVersion)
    Write-Verbose "The value of the module path is: $savedModulePath"
    return $savedModulePath
}

function Update-PSModulePathForHostedAgent {
    [CmdletBinding()]
    param([string] $targetAzurePs)
    try {
        if ($targetAzurePs) {
            $hostedAgentAzModulePath = Get-SavedModulePath -azurePowerShellVersion $targetAzurePs
        }
        else {
            $hostedAgentAzModulePath = Get-LatestModule -patternToMatch "^az_[0-9]+\.[0-9]+\.[0-9]+$" -patternToExtract "[0-9]+\.[0-9]+\.[0-9]+$"
        }
        $env:PSModulePath = $hostedAgentAzModulePath + ";" + $env:PSModulePath
        $env:PSModulePath = $env:PSModulePath.TrimStart(';') 
    } finally {
        Write-Verbose "The updated value of the PSModulePath is: $($env:PSModulePath)"
    }
}

function Update-PSModulePathForHostedAgentLinux {
    [CmdletBinding()]
    param([string] $targetAzurePs)
    try {
        if ($targetAzurePs) {
            $hostedAgentAzModulePath = Get-SavedModulePathLinux -azurePowerShellVersion $targetAzurePs
            if(!(Test-Path $hostedAgentAzModulePath)) {
                Write-Verbose "No module path found with this name"
                throw ("Could not find the module path with given version.")
            }
        }
        else {
            $hostedAgentAzModulePath = Get-LatestModuleLinux -patternToMatch "^az_[0-9]+\.[0-9]+\.[0-9]+$" -patternToExtract "[0-9]+\.[0-9]+\.[0-9]+$"
        }
        $env:PSModulePath = $hostedAgentAzModulePath + ":" + $env:PSModulePath
        $env:PSModulePath = $env:PSModulePath.TrimStart(':') 
    } finally {
        Write-Verbose "The updated value of the PSModulePath is: $($env:PSModulePath)"
    }
}

function Get-LatestModule {
    [CmdletBinding()]
    param([string] $patternToMatch,
          [string] $patternToExtract)
    
    $resultFolder = ""
    $regexToMatch = New-Object -TypeName System.Text.RegularExpressions.Regex -ArgumentList $patternToMatch
    $regexToExtract = New-Object -TypeName System.Text.RegularExpressions.Regex -ArgumentList $patternToExtract
    $maxVersion = [version] "0.0.0"
    $modulePath = $env:SystemDrive + "\Modules";

    try {
        if (-not (Test-Path -Path $modulePath)) {
            return $resultFolder
        }

        $moduleFolders = Get-ChildItem -Directory -Path $modulePath | Where-Object { $regexToMatch.IsMatch($_.Name) }
        foreach ($moduleFolder in $moduleFolders) {
            $moduleVersion = [version] $($regexToExtract.Match($moduleFolder.Name).Groups[0].Value)
            if($moduleVersion -gt $maxVersion) {
                $modulePath = [System.IO.Path]::Combine($moduleFolder.FullName,"Az\$moduleVersion\Az.psm1")

                if(Test-Path -LiteralPath $modulePath -PathType Leaf) {
                    $maxVersion = $moduleVersion
                    $resultFolder = $moduleFolder.FullName
                } else {
                    Write-Verbose "A folder matching the module folder pattern was found at $($moduleFolder.FullName) but didn't contain a valid module file"
                }
            }
        }
    }
    catch {
        Write-Verbose "Attempting to find the Latest Module Folder failed with the error: $($_.Exception.Message)"
        $resultFolder = ""
    }
    Write-Verbose "Latest module folder detected: $resultFolder"
    return $resultFolder
}

function Get-LatestModuleLinux {
    [CmdletBinding()]
    param([string] $patternToMatch,
          [string] $patternToExtract)
    
    $resultFolder = ""
    $regexToMatch = New-Object -TypeName System.Text.RegularExpressions.Regex -ArgumentList $patternToMatch
    $regexToExtract = New-Object -TypeName System.Text.RegularExpressions.Regex -ArgumentList $patternToExtract
    $maxVersion = [version] "0.0.0"

    try {
        $moduleFolders = Get-ChildItem -Directory -Path $("/usr/share") | Where-Object { $regexToMatch.IsMatch($_.Name) }
        foreach ($moduleFolder in $moduleFolders) {
            $moduleVersion = [version] $($regexToExtract.Match($moduleFolder.Name).Groups[0].Value)
            if($moduleVersion -gt $maxVersion) {
                $modulePath = [System.IO.Path]::Combine($moduleFolder.FullName,"Az/$moduleVersion/Az.psm1")

                if(Test-Path -LiteralPath $modulePath -PathType Leaf) {
                    $maxVersion = $moduleVersion
                    $resultFolder = $moduleFolder.FullName
                } else {
                    Write-Verbose "A folder matching the module folder pattern was found at $($moduleFolder.FullName) but didn't contain a valid module file"
                }
            }
        }
    }
    catch {
        Write-Verbose "Attempting to find the Latest Module Folder failed with the error: $($_.Exception.Message)"
        $resultFolder = ""
    }
    Write-Verbose "Latest module folder detected: $resultFolder"
    return $resultFolder
}

function CleanUp-PSModulePathForHostedAgent {
    # Clean up PSModulePath for hosted agent
    $azureRMModulePath = "C:\Modules\azurerm_2.1.0"
    $azureModulePath = "C:\Modules\azure_2.1.0"
    $azPSModulePath = $env:PSModulePath

    if ($azPSModulePath.split(";") -contains $azureRMModulePath) {
        $azPSModulePath = (($azPSModulePath).Split(";") | ? { $_ -ne $azureRMModulePath }) -join ";"
        write-verbose "$azureRMModulePath removed. Restart the prompt for the changes to take effect."
    }
    else {
        write-verbose "$azureRMModulePath is not present in $azPSModulePath"
    }

    if ($azPSModulePath.split(";") -contains $azureModulePath) {
        $azPSModulePath = (($azPSModulePath).Split(";") | ? { $_ -ne $azureModulePath }) -join ";"
        write-verbose "$azureModulePath removed. Restart the prompt for the changes to take effect."
    }
    else {
        write-verbose "$azureModulePath is not present in $azPSModulePath"
    }

    $env:PSModulePath = $azPSModulePath
}
