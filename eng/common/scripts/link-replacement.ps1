param (
  # url list to verify links. Can either be a http address or a local file request. Local file paths support md and html files.
  [string] $sourceDir,
  # file that contains a set of links to ignore when verifying
  [string] $ignoreLinksFile = "$PSScriptRoot/ignore-links.txt",
  # switch that will enable devops specific logging for warnings
  [switch] $devOpsLogging = $false,
  [string] $branchReplaceRegex = "(https://github.com/.*/(?:blob|tree)/)master(/.*)",
  # the substitute branch name or SHA commit
  [string] $releaseTag = ""
)

$regexOptions = [System.Text.RegularExpressions.RegexOptions]"Singleline, IgnoreCase";

function ReplaceLink ($scanFolder, $fileSuffix, $replacement, $customRegex) {
  $regex = new-object System.Text.RegularExpressions.Regex ($branchReplaceRegex, $regexOptions)
  if ($customRegex) {
    $regex = new-object System.Text.RegularExpressions.Regex ($customRegex, $regexOptions)
  }
  if (!$fileSuffix) {
    Write-Error "Please provide at least one file extension to scan against."
  }
  $replacementPattern = "`${2}$replacement`$3"
  if (!$replacement) {
    Write-Error "Please provide the replacement string to replace with."
  }
  if ($scanFolder) {
    $fileSuffixArray = $fileSuffix -split "," 
    $url = @()

    foreach ($fileExtension in $fileSuffixArray) {
      $fileRegex = "*" + $fileSuffix.Trim()
      $urls += Get-ChildItem -Path "$scanFolder/*" -Recurse -Include $fileRegex
    }
    
    if ($urls.Count -eq 0) {
      Write-Host "Usage $($MyInvocation.MyCommand.Name) <urls>";
      return;
    }  
    $needTochange = @{}
    foreach ($url in $urls) {
      while ((Get-Content -Path $url) -match $regex) {
        Write-Verbose "We have master link matches in page $url"
        $needTochange[$url] = $true
        (Get-Content -Path $url) -replace $regex, $replacementPattern | Set-Content -Path $url 
      }
    }
    foreach ($page in $needTochange.Keys) {
      Write-Host "There are replacements in page $page"
    }
  }
}

#ReplaceLink -scanFolder $sourceDir -replacement $releaseTag -fileSuffix ".html"