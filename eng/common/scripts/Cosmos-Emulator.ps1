<#
.SYNOPSIS
Script for installing and launching cosmos emulator

.DESCRIPTION
This script downloads, installs and launches cosmosdb-emulator.

.PARAMETER EmulatorMsiUrl
Uri for downloading the cosmosdb-emulator

.PARAMETER StartParameters
Parameter with which to launch the cosmosdb-emulator

.PARAMETER Stage
Determines what part of the script to run. Has to be either Install or Launch
#>
[CmdletBinding()]
Param (
  [string] $EmulatorMsiUrl = "https://aka.ms/cosmosdb-emulator",
  [string] $StartParameters,
  [Parameter(Mandatory=$True)]
  [ValidateSet('Install', 'Launch')]
  [string] $Stage
)

$targetDir = Join-Path $Env:Temp AzureCosmosEmulator
$logFile = Join-Path $Env:Temp log.txt
$productName = "Azure Cosmos DB Emulator"
$emulator = (Join-Path $targetDir (Join-Path $productName "Microsoft.Azure.Cosmos.Emulator.exe"))

if ($Stage -eq "Install")
{
  $downloadTryCount = 0
  New-Item $targetDir -Type Directory
  New-Item $logFile -Type File
  do
  {
    # Download and Extract Public Cosmos DB Emulator
    Write-Host "Downloading and extracting Cosmos DB Emulator - $EmulatorMsiUrl"
    Write-Host "Target Directory $targetDir"
    Write-Host "Log File $logFile"

    $downloadTryCount++
    Write-Host "Download Try Count: $downloadTryCount"
    Remove-Item -Path (Join-Path $targetDir '*') -Recurse
    Clear-Content -Path $logFile

    $installProcess  = Start-Process msiexec -Wait -PassThru -ArgumentList "/a $EmulatorMsiUrl TARGETDIR=$targetDir /qn /liew $logFile"
    Get-Content $logFile
    Write-Host "Exit Code: $($installProcess.ExitCode)"
  }
  while(($installProcess.ExitCode -ne 0) -and ($downloadTryCount -lt 3))

  if(Test-Path (Join-Path $Env:LOCALAPPDATA CosmosDbEmulator))
  {
    Write-Host "Deleting Cosmos DB Emulator data"
    Remove-Item -Recurse -Force $Env:LOCALAPPDATA\CosmosDbEmulator
  }

  Write-Host "Getting Cosmos DB Emulator Version"
  $fileVersion = Get-ChildItem $emulator
  Write-Host $emulator $fileVersion.VersionInfo
}

if ($Stage -eq "Launch")
{
  Write-Host "Launching Cosmos DB Emulator"
  if (!(Test-Path $emulator)) {
    Write-Error "The emulator is not installed where expected at '$emulator'"
    return
  }

  $process = Start-Process $emulator -ArgumentList "/getstatus" -PassThru -Wait
  switch ($process.ExitCode) {
    1 {
      Write-Host "The emulator is already starting"
      return
    }
    2 {
      Write-Host "The emulator is already running"
      return
    }
    3 {
      Write-Host "The emulator is stopped"
    }
    default {
      Write-Host "Unrecognized exit code $($process.ExitCode)"
      return
    }
  }

  $argumentList = ""
  if (-not [string]::IsNullOrEmpty($StartParameters)) {
      $argumentList += , $StartParameters
  } else {
    # Use the default params if none provided
    $argumentList = "/noexplorer /noui /enablepreview /disableratelimiting /enableaadauthentication"
  }

  Write-Host "Starting emulator process: $emulator $argumentList"
  $process = Start-Process $emulator -ArgumentList $argumentList -ErrorAction Stop -PassThru
  Write-Host "Emulator process started: $($process.Name), $($process.FileVersion)"

  $Timeout = 600
  $result="NotYetStarted"
  $complete = if ($Timeout -gt 0) {
    $start = [DateTimeOffset]::Now
    $stop = $start.AddSeconds($Timeout)
    {
      $result -eq "Running" -or [DateTimeOffset]::Now -ge $stop
    }
  }
  else {
    {
      $result -eq "Running"
    }
  }

  do {
    $process = Start-Process $emulator -ArgumentList "/getstatus" -PassThru -Wait
    switch ($process.ExitCode) {
      1 {
        Write-Host "The emulator is starting"
      }
      2 {
        Write-Host "The emulator is running"
        $result="Running"
        return
      }
      3 {
        Write-Host "The emulator is stopped"
      }
      default {
        Write-Host "Unrecognized exit code $($process.ExitCode)"
      }
    }
    Start-Sleep -Seconds 5
  }
  until ($complete.Invoke())
  Write-Error "The emulator failed to reach Running status within ${Timeout} seconds"
}