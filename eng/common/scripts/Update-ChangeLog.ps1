# Note: This script will add or replace version title in change log

# Parameter description
# Version : Version to add or replace in change log
# ChangeLogPath: Path to change log file. If change log path is set to directory then script will probe for change log file in that path 
# Unreleased: Default is true. If it is set to false, then today's date will be set in verion title. If it is True then title will show "Unreleased"
# ReplaceVersion: This is useful when replacing current version title with new title.( Helpful to update the title before package release)

param (
  [Parameter(Mandatory = $true)]
  [String]$Version,
  [Parameter(Mandatory = $true)]
  [String]$ServiceDirectory,
  [Parameter(Mandatory = $true)]
  [String]$PackageName,
  [boolean]$Unreleased=$True,
  [boolean]$ReplaceVersion = $False
)

DynamicParam {
    if ($Unreleased -eq $False) {
        $releaseStatusAttribute = New-Object System.Management.Automation.ParameterAttribute
        $releaseStatusAttribute.Mandatory = $False
        $attributeCollection = New-object System.Collections.ObjectModel.Collection[System.Attribute]
        $attributeCollection.Add($releaseStatusAttribute)
        $releaseStatusParam = New-Object System.Management.Automation.RuntimeDefinedParameter('ReleaseDate', [string], $attributeCollection)
        $paramDictionary = New-Object System.Management.Automation.RuntimeDefinedParameterDictionary
        $paramDictionary.Add('ReleaseDate', $releaseStatusParam)
        return $paramDictionary
    }
}

Begin {
    . "${PSScriptRoot}\common.ps1"
    $UNRELEASED_TAG = "(Unreleased)"

    $dateFormat = "yyyy-MM-dd"
    $provider = [System.Globalization.CultureInfo]::InvariantCulture
    if ($ReleaseDate)
    {
        try {
            $ReleaseStatus = ([System.DateTime]::ParseExact($ReleaseDate, $dateFormat, $provider)).ToString($dateFormat)
        }
        catch {
            LogError "Invalid Release date. Please use a valid date in the format '$dateFormat'"
        }
    }
    elseif ($Unreleased) {
        $ReleaseStatus = "$UNRELEASED_TAG"
    }
    else {
        $ReleaseStatus = "($(Get-Date -Format $dateFormat))"
    }
}

Process {
    $PkgProperties = Get-PkgProperties -PackageName $PackageName -ServiceDirectory $ServiceDirectory
    $ChangeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $PkgProperties.ChangeLogPath

    if ($ChangeLogEntries.Count -gt 0)
    {
        if ($ChangeLogEntries.Contains($Version))
        {
            if ($ChangeLogEntries[$Version].ReleaseStatus -eq $ReleaseStatus)
            {
                LogWarning "Version is already present in change log with specificed ReleaseStatus [$ReleaseStatus]"
                exit(0)
            }

            if ($Unreleased -and ($ChangeLogEntries[$Version].ReleaseStatus -ne $ReleaseStatus))
            {
                LogWarning "Version is already present in change log with a release date. Please review [$($PkgProperties.ChangeLogPath)]"
                exit(0)
            }

            if (!$Unreleased -and ($ChangeLogEntries[$Version].ReleaseStatus -ne $UNRELEASED_TAG))
            {
                if ((Get-Date ($ChangeLogEntries[$Version].ReleaseStatus).Trim("()")) -gt (Get-Date $ReleaseStatus.Trim("()")))
                {
                    LogWarning "New ReleaseDate is older than existing release date in changelog. Please review [$($PkgProperties.ChangeLogPath)]"
                    exit(0)
                }
            }
        }

        $PresentVersionsSorted = [AzureEngSemanticVersion]::SortVersionStrings($ChangeLogEntries.Keys)
        $LatestVersion = $PresentVersionsSorted[0]

        if ($ReplaceVersion) 
        {
            $NewChangeLogEntries = Edit-ChangeLogEntry -ChangeLogEntries $ChangeLogEntries -VersionToEdit $LatestVersion `
            -NewEntryReleaseVersion $Version -NewEntryReleaseStatus $ReleaseStatus
            Set-ChangeLogContent -ChangeLogLocation $PkgProperties.ChangeLogPath -ChangeLogEntries $NewChangeLogEntries
        }
        else 
        {
            $NewChangeLogEntries = Add-ChangeLogEntry -ChangeLogEntries $ChangeLogEntries -NewEntryVersion $Version `
            -NewEntryReleaseStatus $ReleaseStatus
            Set-ChangeLogContent -ChangeLogLocation $PkgProperties.ChangeLogPath -ChangeLogEntries $NewChangeLogEntries
        }
    }
    else 
    {
        $NewChangeLogEntries = Add-ChangeLogEntry -NewEntryVersion $Version -NewEntryReleaseStatus $ReleaseStatus
        Set-ChangeLogContent -ChangeLogLocation $PkgProperties.ChangeLogPath -ChangeLogEntries $NewChangeLogEntries
    }
}


