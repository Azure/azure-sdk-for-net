<#
.SYNOPSIS
Powershell script to run credential scanner tool

.DESCRIPTION
Powershell script to run credential scanner tool

.PARAMETER CredScanFolder
Credential Scanner directory path

.PARAMETER SourceCodeLocation
Source code directory path to run credential scanner tool on

.PARAMETER LogFileName
Full Name of the log file to write credential scanner output to

.EXAMPLE
RunCredScan.ps1 -CredScanFolder C:\Test\CredScan -SourceCodeLocation C:\Test\azure-sdk-for-net -LogFileName C:\Test\scanlog
#>

[CmdletBinding()]
Param(
[Parameter(Mandatory=$True)]
[String]$CredScanFolder,
[Parameter(Mandatory=$True)]
[String]$SourceCodeLocation,
[Parameter(Mandatory=$True)]
[String]$LogFileName
)

$credentialScannerLocation = $CredScanFolder +"\CredentialScanner.exe"
$searcherFile = $CredScanFolder + "\Searchers\buildsearchers.xml"
$sourceLocation = $SourceCodeLocation
$logMatchFile = $LogFileName + "-matches.tsv"

#Check if CredentialScanner exists on machine
if (-not (Test-Path $credentialScannerLocation)) {
    throw "Credential scanner does not exist on the machine. Please install it before running."
}

#Check if source location mentioned in the arguments exists
if (-not (Test-Path $sourceLocation)) {
    throw "Source Location " + $sourceLocation + " does not exist on the machine. Please make sure the repository exists before running Credential Scanner."
}

#Copy GlobalFilters.xml from repository to Credential scanner folder
Copy-Item $sourceLocation"\tools\GlobalFilters.xml" $args[0] -Force

#if match file exists, delete it before running credential scanner
If (Test-Path $logMatchFile){
	Remove-Item $logMatchFile
}

Write-Host "Running credential scanner from location: " $credentialScannerLocation
Write-Host "Source location for credential scanner: " $sourceLocation
Write-Host "Searcher file location for credential scanner: " $searcherFile

$proc = Start-Process -FilePath $credentialScannerLocation -ArgumentList $sourceLocation, $searcherFile, $LogFileName -NoNewWindow -Wait -PassThru

#Check process exit code after running credential scanner
if ($proc.ExitCode -ne 0) {
   Write-Host $proc.StandardError
   throw "While running credential scanner, process exited with status code $($proc.ExitCode)"
}

$matchesLog = [string[]](Get-Content -Path $logMatchFile)

# logMatchFile contains headings always even if there are no matches. Hence check if line count is greater than 1. If a match is found, throw an exception
if ($matchesLog.Count -gt 1)
{
    throw "Credential scanner match found exception!"
}
else
{
    Write-Host "Finished running credential scanner tool. No matches found!"
}

