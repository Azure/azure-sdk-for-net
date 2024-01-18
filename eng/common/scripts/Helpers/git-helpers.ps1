# cSpell:ignore Committish
# cSpell:ignore PULLREQUEST
# cSpell:ignore TARGETBRANCH
# cSpell:ignore SOURCECOMMITID
function Get-ChangedFiles {
  param (
    [string]$SourceCommittish= "${env:SYSTEM_PULLREQUEST_SOURCECOMMITID}",
    [string]$TargetCommittish = ("origin/${env:SYSTEM_PULLREQUEST_TARGETBRANCH}" -replace "refs/heads/"),
    [string]$DiffPath,
    [string]$DiffFilterType = "d"
  )
  # If ${env:SYSTEM_PULLREQUEST_TARGETBRANCH} is empty, then return empty.
  if (!$TargetCommittish -or ($TargetCommittish -eq "origin/")) {
    Write-Host "There is no target branch passed in. "
    return ""
  }

  # Add config to disable the quote and encoding on file name. 
  # Ref: https://github.com/msysgit/msysgit/wiki/Git-for-Windows-Unicode-Support#disable-quoted-file-names
  # Ref: https://github.com/msysgit/msysgit/wiki/Git-for-Windows-Unicode-Support#disable-commit-message-transcoding
  # Git PR diff: https://docs.github.com/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-comparing-branches-in-pull-requests#three-dot-and-two-dot-git-diff-comparisons
  $command = "git -c core.quotepath=off -c i18n.logoutputencoding=utf-8 diff `"$TargetCommittish...$SourceCommittish`" --name-only --diff-filter=$DiffFilterType"
  if ($DiffPath) {
  $command = $command + " -- `'$DiffPath`'"
  }
  Write-Host $command
  $changedFiles = Invoke-Expression -Command $command
  if(!$changedFiles) {
    Write-Host "No changed files in git diff between $TargetCommittish and $SourceCommittish"
  }
  else {
  Write-Host "Here are the diff files:"
  foreach ($file in $changedFiles) {
      Write-Host "    $file"
  }
  }
  return $changedFiles
}

class ConflictedFile {
  [string]$LeftSource = ""
  [string]$RightSource = ""
  [string]$Content = ""
  [string]$Path = ""
  [boolean]$IsConflicted = $false

  ConflictedFile([string]$File = "") {
    if (!(Test-Path $File)) {
      throw "File $File does not exist, pass a valid file path to the constructor."
    }

    # Normally we would use Resolve-Path $file, but git only can handle relative paths using git show <commitsh>:<path>
    # Therefore, just maintain whatever the path is given to us. Left() and Right() should therefore be called from the same
    # directory as where we defined the relative path to the target file.
    $this.Path = $File
    $this.Content = Get-Content -Raw $File

    $this.ParseContent($this.Content)
  }

  [array] Left(){
    if ($this.IsConflicted) {
      # we are forced to get this line by line and reassemble via join because of how powershell is interacting with
      # git show --textconv commitsh:path
      # powershell ignores the newlines with and without --textconv, which results in a json file without original spacing.
      # by forcefully reading into the array line by line, the whitespace is preserved. we're relying on gits autoconverstion of clrf to lf
      # to ensure that the line endings are consistent.
      Write-Host "git show $($this.LeftSource):$($this.Path)"
      $tempContent = git show ("$($this.LeftSource):$($this.Path)")
      return $tempContent -split "`r?`n"
    }
    else {
      return $this.Content
    }
  }

  [array] Right(){
    if ($this.IsConflicted) {
      Write-Host "git show $($this.RightSource):$($this.Path)"
      $tempContent =  git show ("$($this.RightSource):$($this.Path)")
      return $tempContent -split "`r?`n"
    }
    else {
      return $this.Content
    }
  }

  [void] ParseContent([string]$IncomingContent) {
    $lines = $IncomingContent -split "`r?`n"
    $l = @()
    $r = @()
    
    foreach($line in $lines) {
      if ($line -match "^<<<<<<<\s*(.+)") {
        $this.IsConflicted = $true
        $this.LeftSource = $matches[1]
        continue
      }
      elseif ($line -match "^>>>>>>>\s*(.+)") {
        $this.IsConflicted = $true
        $this.RightSource = $matches[1]
        continue
      }

      if ($this.LeftSource -and $this.RightSource) {
        break
      }
    }
  }
}
