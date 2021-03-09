<#
.SYNOPSIS
Updates the Management pipeline definition

.DESCRIPTION
Adds exclusion paths for all client packages in the management pipeline to prevent it from runing during client builds.
Script assumes that the yml is currently valid and has trigger and pr sections

.PARAMETER PackagesPath
Path to the directory containing all the services

.PARAMETER MgmtYmlPath
Path to the management yml definition

.EXAMPLE
Run script with default parameters.

Update-Mgmt-Yml.ps1

#>
Param (
    [string] $PackagesPath  = "${PSScriptRoot}/../../sdk",
    [string] $MgmtYmlPath = "${PSScriptRoot}/../pipelines/mgmt.yml"
)

Install-Module -Name powershell-yaml -RequiredVersion 0.4.1 -Force -Scope CurrentUser

$MgmtYml = Get-Content $MgmtYmlPath -Raw
$MgmtYmlObj = ConvertFrom-Yaml $MgmtYml -Ordered

$Pr = [ordered]@{ }
$CiBranches = [ordered]@{ }
$CiPaths = [ordered]@{ }
$PrBranches = [ordered]@{ }
$PrPaths = [ordered]@{ }
$Includes = New-Object "System.Collections.Generic.List[String]"
$PrIncludes = New-Object "System.Collections.Generic.List[String]"

$MgmtDirs = Get-ChildItem -Path "$PackagesPath" -Directory -Recurse -Depth 1 | Where-Object { $_.FullName -match "(.Microsoft\.Azure(Stack)?\.Management.)|(.\\mgmt)" }

$Includes.Add('eng/pipelines/mgmt.yml')
# Add Each client path to the exclude list
foreach ($Item in $MgmtDirs) {
    $IncludePath = $Item.FullName.Substring($Item.FullName.IndexOf("sdk\"))
    if ($IncludePath.Split('\').Length -eq 3) {
        $IncludePath = $IncludePath -replace "\\", "/"
        $Includes.Add($IncludePath)
    }
}

# Ci and Pr section
$PrIncludes.Add('master')
$PrIncludes.Add('*-preview')
$PrBranches.Add("include", $PrIncludes)
$PrPaths.Add("include", $Includes)
$Pr.Add("branches", $PrBranches)
$Pr.Add("paths", $PrPaths)

$MgmtYmlObj.pr = $Pr

$NewMgmtYml = ConvertTo-Yaml $MgmtYmlObj -OutFile $MgmtYmlPath -Force
