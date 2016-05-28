$credentialScannerLocation = $args[0]+"\CredentialScanner.exe"
$searcherFile = $args[0]+"\Searchers\buildsearchers.xml"
$sourceLocation = $args[1]
$logFile = $args[2]
$logMatchFile = $logFile + "-matches.tsv"

#if match file exists, delete it before running credential scanner
If (Test-Path $logMatchFile){
	Remove-Item $logMatchFile
}

Start-Process -FilePath $credentialScannerLocation -ArgumentList $sourceLocation, $searcherFile, $logFile -NoNewWindow -Wait -PassThru

# Skip the first line in the logMatchFile since it has headings even if there are no matches. If a match is found, throw an exception
if (([string[]](Get-Content $logMatchFile))[1])
{
    throw "Credential scanner found matches"
}