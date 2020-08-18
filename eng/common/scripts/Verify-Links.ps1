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
  # flag to allow resolving relative paths or not
  [bool] $resolveRelativeLinks = $true
)

$ProgressPreference = "SilentlyContinue"; # Disable invoke-webrequest progress dialog

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

function ResolveUri ([System.Uri]$referralUri, [string]$link)
{
  # If the link is mailto, skip it.
  if ($link.StartsWith("mailto:")) {
    Write-Verbose "Skipping $link because it is a mailto link."
    return $null
  }

  $linkUri = [System.Uri]$link;
  if($resolveRelativeLinks){
    if (!$linkUri.IsAbsoluteUri) {
    # For rooted paths resolve from the baseUrl
      if ($link.StartsWith("/")) {
        echo "rooturl = $rootUrl"
        $linkUri = new-object System.Uri([System.Uri]$rootUrl, ".$link");
      }
      else {
        $linkUri = new-object System.Uri($referralUri, $link);
      }
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
  if ($checkedLinks.ContainsKey($linkUri)) { return }

  Write-Verbose "Checking link $linkUri..."
  if ($linkUri.IsFile) {
    if (!(Test-Path $linkUri.LocalPath)) {
      LogWarning "Link to file does not exist $($linkUri.LocalPath)"
      $script:badLinks += $linkUri
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
        $script:badLinks += $linkUri 
      }
      else {
        if ($null -ne $statusCode) {
          Write-Host "[$statusCode] while requesting $linkUri"
        }
        else {
          Write-Host "Exception while requesting $linkUri"
          Write-Host $_.Exception.ToString()
        }
      }
    }
  }
  $checkedLinks[$linkUri] = $true;
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

$badLinks = @();
$ignoreLinks = @();
if (Test-Path $ignoreLinksFile)
{
  $ignoreLinks = [Array](Get-Content $ignoreLinksFile | ForEach-Object { ($_ -replace "#.*", "").Trim() } | Where-Object { $_ -ne "" })
}

$checkedPages = @{};
$checkedLinks = @{};
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
  
  foreach ($linkUri in $linkUris) {
    CheckLink $linkUri
    if ($recursive) {
      if ($linkUri.ToString().StartsWith($baseUrl) -and !$checkedPages.ContainsKey($linkUri)) {
        $pageUrisToCheck.Enqueue($linkUri);
      }
    }
  }
}

Write-Host "Found $($checkedLinks.Count) links with $($badLinks.Count) broken"
$badLinks | ForEach-Object { Write-Host "  $_" }

exit $badLinks.Count
