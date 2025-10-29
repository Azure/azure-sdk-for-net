. $PSScriptRoot/../logging.ps1

function Invoke-LoggedMsbuildCommand
{
    [CmdletBinding()]
    param
    (
        [string] $Command,
        [string] $ExecutePath,
        [switch] $GroupOutput,
        [int[]] $AllowedExitCodes = @(0)
    )
    return Invoke-LoggedCommand $Command -ExecutePath $ExecutePath -GroupOutput:$GroupOutput -AllowedExitCodes $AllowedExitCodes -OutputProcessor { param($line) ProcessMsBuildLogLine $line }

}

function Invoke-LoggedCommand
{
    [CmdletBinding()]
    param
    (
        [string] $Command,
        [string] $ExecutePath,
        [switch] $GroupOutput,
        [int[]] $AllowedExitCodes = @(0),
        [switch] $DoNotExitOnFailedExitCode,
        [scriptblock] $OutputProcessor
    )

    $startTime = Get-Date

    if($GroupOutput) {
        LogGroupStart $Command
    } else {
        Write-Host "> $Command"
    }

    if($ExecutePath) {
      Push-Location $ExecutePath
    }

    if (!$OutputProcessor) {
      $OutputProcessor = { param($line) $line }
    }

    try {
      Invoke-Expression $Command | Foreach-Object { & $OutputProcessor $_ }

      $duration = (Get-Date) - $startTime

      if($GroupOutput) {
        LogGroupEnd
      }

      if($LASTEXITCODE -notin $AllowedExitCodes)
      {
          LogError "Command failed to execute ($duration): $Command`n"
          if (!$DoNotExitOnFailedExitCode) {
              exit $LASTEXITCODE
          }
      }
      else {
          Write-Host "Command succeeded ($duration)`n"
      }
    }
    finally {
      if($ExecutePath) {
        Pop-Location
      }
    }
}

function Set-ConsoleEncoding
{
    [CmdletBinding()]
    param
    (
        [string] $Encoding = 'utf-8'
    )

    $outputEncoding = [System.Text.Encoding]::GetEncoding($Encoding)
    [Console]::OutputEncoding = $outputEncoding
    [Console]::InputEncoding = $outputEncoding
}
