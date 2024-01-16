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

    $this.Path = Resolve-Path $File
    $this.Content = Get-Content -Raw $File

    Write-Host $this.Content
    $this.ParseContent($this.Content)
  }

  [string] Left(){
    if ($this.IsConflicted) {
      $tempContent = git show $this.LeftSource:$this.Path
      return $tempContent
    }
    else {
      return $this.Content
    }
  }

  [string] Right(){
    if ($this.IsConflicted) {
      $tempContent = git show $this.RightSource:$this.Path
      return $tempContent
    }
    else {
      return $this.Content
    }
  }

  [void] ParseContent([string]$IncomingContent) {
    $lines = $IncomingContent -split "`r?`n"
    $l = @()
    $r = @()
    $direction = "both"
    
    foreach($line in $lines) {
      Write-Host $line

      $leftMatch = $line -match "^<<<<<<<\s*(.+)"
      $rightMatch = $line -match "^>>>>>>>\s*(.+)"
      # state machine for choosing what we're looking at
      if ($leftMatch) {
        $this.IsConflicted = $true

        Write-Host $leftMatch

        $this.LeftSource = $leftMatch[1]
        continue
      }
      elseif ($rightMatch) {
        $this.IsConflicted = $true

        Write-Host $rightMatch

        $this.RightSource = $rightMatch[1]
        continue
      }
    }
  }
}
