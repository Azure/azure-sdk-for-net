function Invoke-LoggedCommand
{
    [CmdletBinding()]
    param
    (
        [string] $Command,
        [string] $ExecutePath,
        [switch] $GroupOutput,
        [int[]] $AllowedExitCodes = @(0)
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

      if($LastExitCode -notin $AllowedExitCodes)
      {
          if($pipelineBuild) {
              Write-Error "##[error]Command failed to execute ($duration): $Command`n"
          } else {
              Write-Error "Command failed to execute ($duration): $Command`n"
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
