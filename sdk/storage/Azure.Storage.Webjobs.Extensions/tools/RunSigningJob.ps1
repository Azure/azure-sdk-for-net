$isPr = Test-Path env:APPVEYOR_PULL_REQUEST_NUMBER
$directoryPath = Split-Path $MyInvocation.MyCommand.Path -Parent

if (-not $isPr) {
  Compress-Archive $directoryPath\..\buildoutput\* $directoryPath\..\buildoutput\tosign.zip

  if ($env:SkipAssemblySigning -eq "true") {
    "Assembly signing disabled. Skipping signing process."
    exit 0;
  }

  $ctx = New-AzureStorageContext $env:FILES_ACCOUNT_NAME $env:FILES_ACCOUNT_KEY
  Set-AzureStorageBlobContent "$directoryPath/../buildoutput/tosign.zip" "webjobs" -Blob "$env:APPVEYOR_BUILD_VERSION.zip" -Context $ctx

  $queue = Get-AzureStorageQueue "signing-jobs" -Context $ctx

  $messageBody = "SignNupkgs;webjobs;$env:APPVEYOR_BUILD_VERSION.zip"
  # $message = New-Object -TypeName Microsoft.WindowsAzure.Storage.Queue.CloudQueueMessage -ArgumentList $messageBody
  $queue.CloudQueue.AddMessage($messageBody)
}