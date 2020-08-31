$branchReplaceRegex = "(https://github.com/.*/(?:blob|tree)/)master(/.*)"

$regexOptions = [System.Text.RegularExpressions.RegexOptions]"Singleline, IgnoreCase";
function ReplaceLink ($scanFolder, $fileSuffix, $replacement, $customRegex) {
  $regex = new-object System.Text.RegularExpressions.Regex ($branchReplaceRegex, $regexOptions)
  if ($customRegex) {
    $regex = new-object System.Text.RegularExpressions.Regex ($customRegex, $regexOptions)
  }
  if (!$fileSuffix) {
    Write-Host "No file extension provided, so use markdown by default."
    $fileSuffix = ".md"
  } 
  $replacementPattern = "`${1}$replacement`$2"
  if (!$replacement) {
    Write-Error "Please provide the replacement string to replace with."
  }
  if ($scanFolder) {
    $fileSuffixArray = $fileSuffix -split "," 
    $needTochange = @{}
    foreach ($fileExtension in $fileSuffixArray) {
      $fileRegex = "*" + $fileSuffix.Trim()
      foreach ($url in Get-ChildItem -Path "$scanFolder/*" -Recurse -Include $fileRegex) {
        while ((Get-Content -Path $url) -match $regex) {
          Write-Verbose "We have master link matches in page $url"
          $needTochange[$url] = $true
          (Get-Content -Path $url) -replace $regex, $replacementPattern | Set-Content -Path $url 
        }
      }
    }

    foreach ($page in $needTochange.Keys) {
      Write-Host "There are replacements in page $page"
    }
  }
}
