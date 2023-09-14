function Invoke-LoggedCommand($Command, $ExecutePath, [switch]$GroupOutput)
{
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

      if($LastExitCode -ne 0)
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
