<#
.DESCRIPTION
Parses a semver version string into its components and supports operations around it.
Example: 1.2.3-preview.4
Components: Major.Minor.Patch-PrereleaseLabel.PrereleaseNumber
#>

class SemVer {
    [int] $Major
    [int] $Minor
    [int] $Patch
    [string] $PrereleaseLabel
    [int] $PrereleaseNumber
    [bool] $IsPrerelease
    [string] $RawVersion

    SemVer(
        [string] $versionString
    ){
        # Regex inspired but simplifie from https://semver.org/#is-there-a-suggested-regular-expression-regex-to-check-a-semver-string
        $SEMVER_REGEX = "^(?<major>0|[1-9]\d*)\.(?<minor>0|[1-9]\d*)\.(?<patch>0|[1-9]\d*)(?:-?(?<prelabel>[a-zA-Z-]*)(?:\.?(?<prenumber>0|[1-9]\d*)))?$"
        
        if ($versionString -match $SEMVER_REGEX) {
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
            throw "Invalid version string: $versionString"
        }
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
