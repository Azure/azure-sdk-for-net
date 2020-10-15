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
  # flag to allow checking against azure sdk link guidance. Check link guidance here: https://aka.ms/azsdk/guideline/links
  [bool] $checkLinkGuidance = $false
)

$ProgressPreference = "SilentlyContinue"; # Disable invoke-webrequest progress dialog
# Regex of the locale keywords.
$locale = "/en-us/"
$emptyLinkMessage = "There is at least one empty link in the page. Please replace with absolute link. Check here for more infomation: https://aka.ms/azsdk/guideline/links"
function NormalizeUrl([string]$url){
  if (Test-Path $url) {
    $url = "file://" + (Resolve-Path $url).ToString();
  }

  $uri = [System.Uri]$url;

  if ($script:baseUrl -eq "") {
    # for base url default to containing directory
    $script:baseUrl = (new-object System.Uri($uri, ".")).ToString();
  }

  if ($script:rootUrl -eq "") {
    if ($uri.IsFile) { 
      # for files default to the containing directory
      $script:rootUrl = $script:baseUrl;
    }
    else {
      # for http links default to the root path
      $script:rootUrl = new-object System.Uri($uri, "/");
    }
  }
  return $uri
}

function LogWarning
{
  if ($devOpsLogging)
  {
    Write-Host "##vso[task.LogIssue type=warning;]$args"
  }
  else
  {
    Write-Warning "$args"
  }
}

function LogError
{
  if ($devOpsLogging)
  {
    Write-Host "##vso[task.logissue type=error]$args"
  }
  else
  {
    Write-Error "$args"
  }
}

function ResolveUri ([System.Uri]$referralUri, [string]$link)
{
  # If the link is mailto, skip it.
  if ($link.StartsWith("mailto:")) {
    Write-Verbose "Skipping $link because it is a mailto link."
    return $null
  }

  $linkUri = [System.Uri]$link;
  # Our link guidelines do not allow relative links so only resolve them when we are not
  # validating links against our link guidelines (i.e. !$checkLinkGuideance)
  if ($checkLinkGuidance -and !$linkUri.IsAbsoluteUri) {
    return $linkUri
  }

  if (!$linkUri.IsAbsoluteUri) {
    # For rooted paths resolve from the baseUrl
    if ($link.StartsWith("/")) {
      Write-Verbose "rooturl = $rootUrl"
      $linkUri = new-object System.Uri([System.Uri]$rootUrl, ".$link");
    }
    else {
      $linkUri = new-object System.Uri($referralUri, $link);
    }
  }

  $linkUri = [System.Uri]$linkUri.GetComponents([System.UriComponents]::HttpRequestUrl, [System.UriFormat]::SafeUnescaped)
  Write-Verbose "ResolvedUri $link to $linkUri"

  # If the link is not a web request, like mailto, skip it.
  if (!$linkUri.Scheme.StartsWith("http") -and !$linkUri.IsFile) {
    Write-Verbose "Skipping $linkUri because it is not http or file based."
    return $null
  }

  if ($null -ne $ignoreLinks -and ($ignoreLinks.Contains($link) -or $ignoreLinks.Contains($linkUri.ToString()))) {
    Write-Verbose "Ignoring invalid link $linkUri because it is in the ignore file."
    return $null
  }

  return $linkUri;
}

function ParseLinks([string]$baseUri, [string]$htmlContent)
{
  $hrefRegex = "<a[^>]+href\s*=\s*[""']?(?<href>[^""']*)[""']?"
  $regexOptions = [System.Text.RegularExpressions.RegexOptions]"Singleline, IgnoreCase";

  $hrefs = [RegEx]::Matches($htmlContent, $hrefRegex, $regexOptions);

  #$hrefs | Foreach-Object { Write-Host $_ }

  Write-Verbose "Found $($hrefs.Count) raw href's in page $baseUri";
  $links = $hrefs | ForEach-Object { ResolveUri $baseUri $_.Groups["href"].Value } | Sort-Object -Unique

  #$links | Foreach-Object { Write-Host $_ }

  return $links
}

function CheckLink ([System.Uri]$linkUri)
{
  if(!$linkUri.ToString().Trim()) {
    LogWarning "Found Empty link. Please use absolute link instead. Check here for more infomation: https://aka.ms/azsdk/guideline/links"
    return $false
  }
  if ($checkedLinks.ContainsKey($linkUri)) { 
    if (!$checkedLinks[$linkUri]) {
      LogWarning "broken link $linkUri"
    }
    return $checkedLinks[$linkUri] 
  }

  $linkValid = $true
  Write-Verbose "Checking link $linkUri..."  

  if ($linkUri.IsFile) {
    if (!(Test-Path $linkUri.LocalPath)) {
      LogWarning "Link to file does not exist $($linkUri.LocalPath)"
      $linkValid = $false
    }
  }
  else {
    try {
      $headRequestSucceeded = $true
      try {
        # Attempt HEAD request first
        $response = Invoke-WebRequest -Uri $linkUri -Method HEAD
      }
      catch {
        $headRequestSucceeded = $false
      }
      if (!$headRequestSucceeded) {
        # Attempt a GET request if the HEAD request failed.
        $response = Invoke-WebRequest -Uri $linkUri -Method GET
      }
      $statusCode = $response.StatusCode
      if ($statusCode -ne 200) {
        Write-Host "[$statusCode] while requesting $linkUri"
      }
    }
    catch {
      $statusCode = $_.Exception.Response.StatusCode.value__

      if(!$statusCode) {
        # Try to pull the error code from any inner SocketException we might hit
        $statusCode = $_.Exception.InnerException.ErrorCode
      }

      if ($statusCode -in $errorStatusCodes) {
        LogWarning "[$statusCode] broken link $linkUri"
        $linkValid = $false
      }
      else {
        if ($null -ne $statusCode) {
          Write-Host "[$statusCode] while requesting $linkUri"
        }
        elseif (!$linkUri.ToString().StartsWith("#")) {
          Write-Host "Exception while requesting $linkUri"
          Write-Host $_.Exception.ToString()
        }
      }
    }
  }
  
  if ($checkLinkGuidance) {
    $link = $linkUri.ToString()
    # Check if the url is relative links, suppress the archor link validation.
    if (!$linkUri.IsAbsoluteUri -and !$link.StartsWith("#")) {
      LogWarning "DO NOT use relative link $linkUri. Please use absolute link instead. Check here for more infomation: https://aka.ms/azsdk/guideline/links"
      $linkValid = $false
    }
    # Check if the url is anchor link has any uppercase.
    if ($link -cmatch '#[^?]*[A-Z]') {
      LogWarning "Please lower case your anchor tags (i.e. anything after '#' in your link '$linkUri'. Check here for more information: https://aka.ms/azsdk/guideline/links"
      $linkValid = $false
    }
     # Check if link uri includes locale info.
    if ($linkUri -match $locale) {
      LogWarning "DO NOT include locale $locale information in links: $linkUri. Check here for more information: https://aka.ms/azsdk/guideline/links"
      $linkValid = $false
    }
  }

  $checkedLinks[$linkUri] = $linkValid
  return $linkValid
}

function ReplaceGithubLink([string]$originLink) {
  if (!$branchReplacementName) {
    return $originLink
  }
  $ReplacementPattern = "`${1}$branchReplacementName`$2"
  return $originLink -replace $branchReplaceRegex, $ReplacementPattern 
}

function GetLinks([System.Uri]$pageUri)
{
  if ($pageUri.Scheme.StartsWith("http")) {
    try {
      $response = Invoke-WebRequest -Uri $pageUri
      $content = $response.Content
    }
    catch {
      $statusCode = $_.Exception.Response.StatusCode.value__
      Write-Error "Invalid page [$statusCode] $pageUri"
    }
  }
  elseif ($pageUri.IsFile -and (Test-Path $pageUri.LocalPath)) {
    $file = $pageUri.LocalPath
    if ($file.EndsWith(".md")) {
      $content = (ConvertFrom-MarkDown $file).html
    }
    elseif ($file.EndsWith(".html")) {
      $content = Get-Content $file
    }
    else {
      if (Test-Path ($file + "index.html")) {
        $content = Get-Content ($file + "index.html")
      }
      else {
        # Fallback to just reading the content directly
        $content = Get-Content $file
      }
    }
  }
  else {
    Write-Error "Don't know how to process uri $pageUri"
  }

  $links = ParseLinks $pageUri $content

  return $links;
}

if ($urls) {
  if ($urls.Count -eq 0) {
    Write-Host "Usage $($MyInvocation.MyCommand.Name) <urls>";
    exit 1;
  }  
}

if ($PSVersionTable.PSVersion.Major -lt 6)
{
  LogWarning "Some web requests will not work in versions of PS earlier then 6. You are running version $($PSVersionTable.PSVersion)."
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
  $uri = NormalizeUrl $url  
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
    $replacedLink = ReplaceGithubLink $linkUri
    $isLinkValid = CheckLink $replacedLink
    if (!$isLinkValid -and !$badLinksPerPage.Contains($linkUri)) {
      if (!$linkUri.ToString().Trim()) {
        $linkUri = $emptyLinkMessage
      }
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
  LogError "Found $($checkedLinks.Count) links with $($badLinks.Count) page(s) broken."
} 
else {
  Write-Host "Found $($checkedLinks.Count) links. No broken links found."
}
exit $badLinks.Count
