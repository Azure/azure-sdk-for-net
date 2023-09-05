function Invoke-LoggedCommand($command, $executePath)
{
    $pipelineBuild = !!$env:TF_BUILD
    $startTime = Get-Date

    if($pipelineBuild) {
        Write-Host "##[group]$command"
    } else {
        Write-Host "> $command"
    }

    if($executePath) {
      Push-Location $executePath
    }

    try {
      if ($IsLinux -or $IsMacOs)
      {
          sh -c "$command 2>&1"
      }
      else
      {
          cmd /c "$command 2>&1"
      }

      $duration = (Get-Date) - $startTime

      if($pipelineBuild) {
        Write-Host "##[endgroup]"
      }

      if($LastExitCode -ne 0)
      {
          if($pipelineBuild) {
              Write-Error "##[error]Command failed to execute ($duration): $command`n"
          } else {
              Write-Error "Command failed to execute ($duration): $command`n"
          }
      }
      else {
          Write-Host "Command succeeded ($duration)`n"
      }
    }
    finally {
      if($executePath) {
        Pop-Location
      }
    }
}

Set-Alias -Name invoke -Value Invoke-LoggedCommand