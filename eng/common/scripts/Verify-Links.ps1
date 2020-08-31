param (
  # url list to verify links. Can either be a http address or a local file request. Local file paths support md and html files.
  [string[]] $urls,
  # file that contains a set of links to ignore when verifying
  [string] $ignoreLinksFile = "$PSScriptRoot/ignore-links.txt",
  # switch that will enable devops specific logging for warnings
  [switch] $devOpsLogging = $false,
  # check the links recurisvely based on recursivePattern
  [switch] $recursive = $true,
  # recusiving check links for all links verified that begin with this baseUrl, defaults to the folder the url is contained in
  [string] $baseUrl = "",
  # path to the root of the site for resolving rooted relative links, defaults to host root for http and file directory for local files
  [string] $rootUrl = "",
  # list of http status codes count as broken links. Defaults to 400, 401, 404, SocketError.HostNotFound = 11001, SocketError.NoData = 11004
  [array] $errorStatusCodes = @(400, 401, 404, 11001, 11004),
  # regex to check if the link needs to be replaced
  [string] $branchReplaceRegex = "^(https://github.com/.*/(?:blob|tree)/)master(/.*)$",
  # the substitute branch name or SHA commit
  [string] $branchReplacementName = "",
  # flag to allow checking against azure sdk link guidance.
  [bool] $checkLinkGuidance = $false
)

. (Join-Path $PSScriptRoot link-replacement.ps1)

$ProgressPreference = "SilentlyContinue"; # Disable invoke-webrequest progress dialog
function ReplaceGithubLink([string]$originLink) {
  if (!$branchReplacementName) {
    return $originLink
  }
  $ReplacementPattern = "`${1}$branchReplacementName`$2"
  return $originLink -replace $branchReplaceRegex, $ReplacementPattern 
}

if ($urls) {
  if ($urls.Count -eq 0) {
    Write-Host "Usage $($MyInvocation.MyCommand.Name) <urls>";
    exit 1;
  }  
}

if ($PSVersionTable.PSVersion.Major -lt 6)
{
  LogWarning $devOpsLogging "Some web requests will not work in versions of PS earlier then 6. You are running version $($PSVersionTable.PSVersion)."
}
$ignoreLinks = @();
if (Test-Path $ignoreLinksFile)
{
  $ignoreLinks = [Array](Get-Content $ignoreLinksFile | ForEach-Object { ($_ -replace "#.*", "").Trim() } | Where-Object { $_ -ne "" })
}

$checkedPages = @{};
$checkedLinks = @{};
$badLinks = @{};
$pageUrisToCheck = new-object System.Collections.Queue

foreach ($url in $urls) {
  $uri = NormalizeUrl $url $script:baseUrl $script:rootUrl
  $pageUrisToCheck.Enqueue($uri);
}

while ($pageUrisToCheck.Count -ne 0)
{
  $pageUri = $pageUrisToCheck.Dequeue();
  if ($checkedPages.ContainsKey($pageUri)) { continue }
  $checkedPages[$pageUri] = $true;

  $linkUris = GetLinks $pageUri
  Write-Host "Found $($linkUris.Count) links on page $pageUri";
  $badLinksPerPage = @();
  foreach ($linkUri in $linkUris) {
    $linkUri = ReplaceGithubLink $linkUri
    $isLinkValid = CheckLink -devOpsLogging $devOpsLogging -sourceDir $linkUri 
      -checkLinkGuidance $checkLinkGuidance -checkedLinks $checkedLinks -errorStatusCodes $errorStatusCodes
    if (!$isLinkValid -and !$badLinksPerPage.Contains($linkUri)) {
      $badLinksPerPage += $linkUri
    }
    if ($recursive -and $isLinkValid) {
      if ($linkUri.ToString().StartsWith($baseUrl) -and !$checkedPages.ContainsKey($linkUri)) {
        $pageUrisToCheck.Enqueue($linkUri);
      }
    }
  }
  if ($badLinksPerPage.Count -gt 0) {
    $badLinks[$pageUri] = $badLinksPerPage
  }
}

if ($badLinks.Count -gt 0) {
  Write-Host "Summary of broken links:"
}
foreach ($pageLink in $badLinks.Keys) {
  Write-Host "'$pageLink' has $($badLinks[$pageLink].Count) broken link(s):"
  foreach ($brokenLink in $badLinks[$pageLink]) {
    Write-Host "  $brokenLink"
  }
}

if ($badLinks.Count -gt 0) {
  LogError $devOpsLogging "Found $($checkedLinks.Count) links with $($badLinks.Count) page(s) broken."
} 
else {
  Write-Host "Found $($checkedLinks.Count) links. No broken links found."
}
exit $badLinks.Count
