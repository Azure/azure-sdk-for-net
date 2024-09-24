#Requires -Version 7.0
Set-StrictMode -Version 3.0

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

function Invoke-LoggedCommand {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $Command,

        [ValidateScript({ Test-Path $_ -PathType Container })]
        [string] $ExecutePath,

        [switch] $GroupOutput,

        [switch] $IgnoreExitCode
    )

    $pipelineBuild = !!$env:TF_BUILD
    $startTime = Get-Date

    if($pipelineBuild -and $GroupOutput) {
        Write-Host "##[group]$Command"
    } else {
        Write-Host "> $Command"
    }

    if($ExecutePath) {
      Push-Location $ExecutePath
    }

    try {
      Invoke-Expression $Command

      $duration = (Get-Date) - $startTime

      if($pipelineBuild -and $GroupOutput) {
        Write-Host "##[endgroup]"
      }

      if($IgnoreExitCode) {
        Write-Host "Command completed ($duration)`n"
      }
      elseif($LastExitCode -ne 0)
      {
          if($pipelineBuild) {
              Write-Error "##[error]Command completed with exit code $LastExitCode ($duration): $Command`n"
          } else {
              Write-Error "Command completed with exit code $LastExitCode ($duration): $Command`n"
          }
      }
      else {
          Write-Host "Command completed ($duration)`n"
      }
    }
    finally {
      if($ExecutePath) {
        Pop-Location
      }
    }
}
