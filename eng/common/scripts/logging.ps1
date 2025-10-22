function Test-SupportsDevOpsLogging() {
  return ($null -ne $env:SYSTEM_TEAMPROJECTID)
}

function Test-SupportsGitHubLogging() {
  return ($null -ne $env:GITHUB_ACTIONS)
}

function LogInfo {
  Write-Host "$args"
}

function LogNotice {
  if (Test-SupportsGitHubLogging) {
    Write-Host ("::notice::$args" -replace "`n", "%0D%0A")
  }
  else {
    # No equivalent for DevOps
    Write-Host "[Notice] $args"
  }
}

function LogNoticeForFile($file, $noticeString) {
  if (Test-SupportsGitHubLogging) {
    Write-Host ("::notice file=$file,line=1,col=1::$noticeString" -replace "`n", "%0D%0A")
  }
  else {
    # No equivalent for DevOps
    Write-Host "[Notice in file $file] $noticeString"
  }
}

function LogWarning {
  if (Test-SupportsDevOpsLogging) {
    Write-Host ("##vso[task.LogIssue type=warning;]$args" -replace "`n", "%0D%0A")
  }
  elseif (Test-SupportsGitHubLogging) {
    Write-Host ("::warning::$args" -replace "`n", "%0D%0A")
  }
  else {
    Write-Warning "$args"
  }
}

function LogSuccess {
  $esc = [char]27
  $green = "${esc}[32m"
  $reset = "${esc}[0m"

  Write-Host "${green}$args${reset}"
}

function LogErrorForFile($file, $errorString)
{
  if (Test-SupportsDevOpsLogging) {
    Write-Host ("##vso[task.logissue type=error;sourcepath=$file;linenumber=1;columnnumber=1;]$errorString" -replace "`n", "%0D%0A")
  }
  elseif (Test-SupportsGitHubLogging) {
    Write-Host ("::error file=$file,line=1,col=1::$errorString" -replace "`n", "%0D%0A")
  }
  else {
    Write-Error "[Error in file $file]$errorString"
  }
}

function LogError {
  if (Test-SupportsDevOpsLogging) {
    Write-Host ("##vso[task.LogIssue type=error;]$args" -replace "`n", "%0D%0A")
  }
  elseif (Test-SupportsGitHubLogging) {
    Write-Host ("::error::$args" -replace "`n", "%0D%0A")
  }
  else {
    Write-Error "$args"
  }
}

function LogDebug {
  if (Test-SupportsDevOpsLogging) {
    Write-Host "[debug]$args"
  }
  elseif (Test-SupportsGitHubLogging) {
    Write-Host "::debug::$args"
  }
  else {
    Write-Debug "$args"
  }
}

function LogGroupStart() {
  if (Test-SupportsDevOpsLogging) {
    Write-Host "##[group]$args"
  }
  elseif (Test-SupportsGitHubLogging) {
    Write-Host "::group::$args"
  }
}

function LogGroupEnd() {
  if (Test-SupportsDevOpsLogging) {
    Write-Host "##[endgroup]"
  }
  elseif (Test-SupportsGitHubLogging) {
    Write-Host "::endgroup::"
  }
}

function LogJobFailure() {
  if (Test-SupportsDevOpsLogging) {
    Write-Host "##vso[task.complete result=Failed;]"
  }
  # No equivalent for GitHub Actions.  Failure is only determined by nonzero exit code.
}

function ProcessMsBuildLogLine($line) {
  if (Test-SupportsDevOpsLogging) {
    if ($line -like "*: error*") {
      return ("##vso[task.LogIssue type=error;]$line" -replace "`n", "%0D%0A")
    }
    elseif ($line -like "*: warning*") {
      return ("##vso[task.LogIssue type=warning;]$line" -replace "`n", "%0D%0A")
    }
  }
  return $line
}
