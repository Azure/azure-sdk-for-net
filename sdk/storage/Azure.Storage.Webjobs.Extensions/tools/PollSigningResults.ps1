$isPr = Test-Path env:APPVEYOR_PULL_REQUEST_NUMBER
$directoryPath = Split-Path $MyInvocation.MyCommand.Path -Parent

if (-not $isPr -and $env:SkipAssemblySigning -ne "true") {
  $timeout = new-timespan -Minutes 15
  $sw = [diagnostics.stopwatch]::StartNew();
  $polling = $true;
  $ctx = New-AzureStorageContext $env:FILES_ACCOUNT_NAME $env:FILES_ACCOUNT_KEY
  $blob = $null;
  while ($sw.elapsed -lt $timeout -and $polling) {
    $blob = Get-AzureStorageBlob "$env:APPVEYOR_BUILD_VERSION.zip" "webjobs-signed" -Context $ctx -ErrorAction Ignore
    if (-not $blob) {
      "${sw.elapsed} elapsed, polling..."
    }
    else {
      "Jenkins artifacts found"
      $polling = $false;
    }
    Start-Sleep -Seconds 5
  }

  if ($polling) {
    "No jenkins artifacts found, investigate job at https://funkins-master.redmond.corp.microsoft.com/job/Build_signing/"
    exit(1);
  }

  Remove-Item "$directoryPath/../buildoutput" -Recurse -Force

  Mkdir "$directoryPath/../buildoutput"

  Get-AzureStorageBlobContent "$env:APPVEYOR_BUILD_VERSION.zip" "webjobs-signed" -Destination "$directoryPath/../buildoutput/signed.zip" -Context $ctx

  Expand-Archive "$directoryPath/../buildoutput/signed.zip" "$directoryPath/../buildoutput/signed"

  Get-ChildItem "$directoryPath/../buildoutput/signed" | % {
    Push-AppveyorArtifact $_.FullName
  }
  if (-not $?) { exit 1 }
}