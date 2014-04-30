[CmdletBinding()]
Param(
[Parameter(Mandatory=$True)]
[string]$Credential,

[Parameter(Mandatory=$False)]
[string]$Sha1,

[Parameter(Mandatory=$True)]
[string]$BuildOutputPath,

[Parameter()]
[switch]$WhatIf
)

[string]$Repo = "Azure/azure-sdk-for-net"

# Extract published packages from the build output
function GetPublishedPackages([string] $pathToOutputFile, [string] $targetName) 
{
    [bool] $enteredPublishTarget = $false
    [string] $output = '';
    [string] $currentPackage = ''
    foreach ($line in (Get-Content $pathToOutputFile))
    {
        if ($line -eq $targetName + ":")
        {
            $enteredPublishTarget = $true
        }
        if ($enteredPublishTarget)
        {
            [string]$lineTrimmed = $line.Trim()
            if ($lineTrimmed.StartsWith("Pushing ") -and $lineTrimmed.Contains("to the symbol server") -eq $false)
            {
                $currentPackage = $lineTrimmed.Substring("Pushing ".Length, $lineTrimmed.IndexOf(" to ") - "Pushing ".Length)
            }
            if ($lineTrimmed -eq "Your package was pushed." -and $currentPackage -ne '')
            {
                $output += "* $currentPackage`r`n"
                $currentPackage = ''
            }
        }        
    }
    return $output
}

# Extract spec packages used in the build
function GetHydraSpecPackages([string] $pathToOutputFile, [string]$publishedPackage) 
{
    [bool] $enteredCopySpecTarget = $false
    [bool] $enteredGenerateSpecTarget = $false
    [string] $output = ''
    [string] $packageName = ''
    foreach ($line in (Get-Content $pathToOutputFile))
    {
        if ($line.StartsWith("Copy") -and $line.EndsWith("Specification:"))
        {
            $enteredCopySpecTarget = $true
            $enteredGenerateSpecTarget = $false
        }
        if ($line -eq 'GenerateCodeFromSpecs:')
        {
            $enteredGenerateSpecTarget = $true
            $enteredCopySpecTarget = $false
        }
        if ($enteredCopySpecTarget)
        {
            [string] $lineTrimmed = $line.Trim()
            if ($lineTrimmed.StartsWith("Copying file from "))
            {
                [int]$indexOfPackages = $lineTrimmed.IndexOf("\packages\")
                [int]$indexOfTools = $lineTrimmed.IndexOf("\tools\")
                [int]$start = $indexOfPackages + "\packages\".Length;
                if ($indexOfPackages -gt 0 -and $indexOfTools -gt 0)
                {
                    [string]$currentPackage = $lineTrimmed.Substring($start, $indexOfTools - $start)
                    $packageName = $currentPackage.Substring(0, $currentPackage.IndexOf(".Specification."))
                    [string]$specVersion = $currentPackage.Substring($currentPackage.IndexOf(".Specification.") + ".Specification.".Length)
                    if ($publishedPackage.Contains($packageName) -eq $true) {
                        $output += "* $packageName`r`n"
                        $output += "   * Spec: $specVersion`r`n"
                    }
                }
            }
        } 
        if ($enteredGenerateSpecTarget)
        {
            if ($line.Contains(("Hydra.Generator")))
            {
                [int]$indexOfGenerator = $line.IndexOf("Hydra.Generator.") + "Hydra.Generator.".Length
                [int]$indexOfBuild = $line.IndexOf("\build\")
                if ($indexOfPackages -gt 0 -and $indexOfTools -gt 0 -and $publishedPackage.Contains($packageName) -eq $true)
                {
                    [string]$hydraVersion = $line.Substring($indexOfGenerator, $indexOfBuild - $indexOfGenerator)
                    $output += "   * Hydra: $hydraVersion`r`n"
                }
            }
        }    
    }
    return $output
}

# Create a new tag and a release
function CreateRelease([string] $credentials, [string] $repo, [string] $sha1, [string] $body) {
    $releaseName = (Get-Date -Format "yyyy-MM-dd @ HH:mm")
    $tag = (Get-Date -Format yyyy-MM-ddTHH-mm)

    $json = ConvertTo-Json @{"tag_name" = $tag;"target_commitish" = $sha1; "name" = $releaseName; "body" = $body; "draft" = $false; "prerelease" = $true }
    Write-Debug $json
    $result = Invoke-WebRequest -Uri "https://api.github.com/repos/$repo/releases" -Headers @{"Authorization" = "Token $credentials"} -Method Post -Body $json
    $result
}

$body = "# Released Packages`r`n"
[string]$publishedPackage = GetPublishedPackages $BuildOutputPath "PublishPackagesOnly"
if ($publishedPackage.Trim() -eq '') {
    $body += "None"
} else {
    $body += $publishedPackage
	$body += "`r`n"
	$body += "## Hydra Packages`r`n"
	$body += GetHydraSpecPackages $BuildOutputPath $publishedPackage
}

if ($Sha1 -eq $null -or $Sha1 -eq '') {
    $Sha1 = & "git" rev-parse HEAD
}

Write-Debug "Sha1: $Sha1"

if ($WhatIf -eq $true -or $publishedPackage.Trim() -eq '') {
    $body
} else {    
    CreateRelease $Credential $Repo $Sha1 $body
}