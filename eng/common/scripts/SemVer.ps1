<#
.DESCRIPTION
Parses a semver version string into its components and supports operations around it that we use for versioning our packages.

See https://azure.github.io/azure-sdk/policies_releases.html#package-versioning

Example: 1.2.3-preview.4
Components: Major.Minor.Patch-PrereleaseLabel.PrereleaseNumber

Note: A builtin Powershell version of SemVer exists in 'System.Management.Automation'. At this time, it does not parsing of PrereleaseNumber. It's name is also type accelerated to 'SemVer'.
#>

class AzureEngSemanticVersion {
    [int] $Major
    [int] $Minor
    [int] $Patch
    [string] $PrereleaseLabel
    [int] $PrereleaseNumber
    [bool] $IsPrerelease
    [string] $RawVersion
    # Regex inspired but simplified from https://semver.org/#is-there-a-suggested-regular-expression-regex-to-check-a-semver-string
    static [string] $SEMVER_REGEX = "(?<major>0|[1-9]\d*)\.(?<minor>0|[1-9]\d*)\.(?<patch>0|[1-9]\d*)(?:-?(?<prelabel>[a-zA-Z-]*)(?:\.?(?<prenumber>0|[1-9]\d*)))?"

    static [AzureEngSemanticVersion] ParseVersionString([string] $versionString)
    {
        try {
            return [AzureEngSemanticVersion]::new($versionString)
        }
        catch {
            return $null
        }
    }
    
    AzureEngSemanticVersion([string] $versionString){
        if ($versionString -match "^$([AzureEngSemanticVersion]::SEMVER_REGEX)$") {
            if ($null -eq $matches['prelabel']) {
                # artifically provide these values for non-prereleases to enable easy sorting of them later than prereleases.
                $prelabel = "zzz"
                $prenumber = 999;
                $isPre = $false;
            }
            else {
                $prelabel = $matches["prelabel"]
                $prenumber = [int]$matches["prenumber"]
                $isPre = $true;
            }

            $this.Major = [int]$matches.Major
            $this.Minor = [int]$matches.Minor
            $this.Patch = [int]$matches.Patch
            $this.PrereleaseLabel = $prelabel
            $this.PrereleaseNumber = $prenumber
            $this.IsPrerelease = $isPre
            $this.RawVersion = $versionString
        }      
        else
        {
            throw "Invalid version string: '$versionString'"
        }
    }

    # If a prerelease label exists, it must be 'preview', and similar semantics used in our release guidelines
    # See https://azure.github.io/azure-sdk/policies_releases.html#package-versioning
    [bool] HasValidPrereleaseLabel(){
        if ($this.IsPrerelease -eq $true) {
            if ($this.PrereleaseLabel -ne 'preview') {
                Write-Error "Unexpected pre-release identifier '$this.PrereleaseLabel', should be 'preview'"
                return $false;
            }
            if ($this.PrereleaseNumber -lt 1)
            {
                Write-Error "Unexpected pre-release version '$this.PrereleaseNumber', should be >= '1'"
                return $false;
            }
        }
        return $true;
    }

    [string] ToString(){
        if ($this.IsPrerelease -eq $false)
        {
            $versionString = "{0}.{1}.{2}" -F $this.Major, $this.Minor, $this.Patch
        }
        else
        {
            $versionString = "{0}.{1}.{2}-{3}.{4}" -F $this.Major, $this.Minor, $this.Patch, $this.PrereleaseLabel, $this.PrereleaseNumber
        }
        return $versionString;
    }    
    
    [void] IncrementAndSetToPrerelease(){
        if  ($this.IsPrerelease -eq $false)
        {
            $this.PrereleaseLabel = 'preview'
            $this.PrereleaseNumber = 1
            $this.Minor++
            $this.Patch = 0
            $this.IsPrerelease = $true
        }
        else
        {
            $this.PrereleaseNumber++
        }
    }
}
