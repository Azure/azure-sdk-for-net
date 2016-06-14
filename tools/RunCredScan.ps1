$credentialScannerLocation = $args[0]+"\CredentialScanner.exe"
$searcherFile = $args[0]+"\Searchers\buildsearchers.xml"
$sourceLocation = $args[1]
$logFile = $args[2]
$logMatchFile = $logFile + "-matches.tsv"

#Check if CredentialScanner exists on machine
if (-not (Test-Path $credentialScannerLocation)) {
    throw "Credential Scanner does not exist on the machine. Please install it before running."
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

$proc = Start-Process -FilePath $credentialScannerLocation -ArgumentList $sourceLocation, $searcherFile, $logFile -NoNewWindow -Wait -PassThru

#Check process exit code after running credential scanner
if ($proc.ExitCode -ne 0) {
   throw "While running credential scanner, process exited with status code $($proc.ExitCode)"
}

# Skip the first line in the logMatchFile since it has headings even if there are no matches. If a match is found, throw an exception
if (([string[]](Get-Content $logMatchFile))[1])
{
    throw "Credential scanner found matches"
}