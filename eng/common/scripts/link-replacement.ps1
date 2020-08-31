# The folder to scan against.
$sourceDir = "."
# file that contains a set of links to ignore when verifying
$ignoreLinksFile = "$PSScriptRoot/ignore-links.txt"
# switch that will enable devops specific logging for warnings
$devOpsLogging = $false,                              
# regex to check if the link needs to be replaced
$linkReplaceRegex = "(https://github.com/.*/(?:blob|tree)/)master(/.*)"
# the substitute branch name, SHA commit or releaseTag
$replacePattern = ""
# flag to allow checking against azure sdk link guidance.
$checkLinkGuidance = $false
# The file suffix to check. Allow multiple suffix separated by comma, e.g ".md, .html"
$suffix = ".md"
$regexOptions = [System.Text.RegularExpressions.RegexOptions]"Singleline, IgnoreCase"
# Regex of the locale keywords.
$locale = "/en-us/"
# recusiving check links for all links verified that begin with this baseUrl, defaults to the folder the url is contained in
$baseUrl = ""
# path to the root of the site for resolving rooted relative links, defaults to host root for http and file directory for local files
$rootUrl = ""
function CheckLink 
{
  Param (
    [System.Uri]$linkUri, 
    [bool]$checkLinkGuidance, 
    [Hashtable]$checkedLinks, 
    [bool]$devOpsLogging,
    [array]$errorStatusCodes
  )  

  if ($checkedLinks.ContainsKey($linkUri)) { 
    if (!$checkedLinks[$linkUri]) {
      LogWarning $devOpsLogging "broken link $linkUri"
    }
    return $checkedLinks[$linkUri] 
  }

  $linkValid = $true
  Write-Verbose "Checking link $linkUri..."  

  if ($linkUri.IsFile) {
    if (!(Test-Path $linkUri.LocalPath)) {
      LogWarning $devOpsLogging "Link to file does not exist $($linkUri.LocalPath)"
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
        LogWarning $devOpsLogging "[$statusCode] broken link $linkUri"
        $linkValid = $false
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
  
  # Check if link uri includes locale info.
  if ($checkLinkGuidance -and ($linkUri -match $locale)) {
    LogWarning $devOpsLogging "DO NOT include locale $locale information in links: $linkUri."
    $linkValid = $false
  }
  $checkedLinks[$linkUri] = $linkValid
  return $linkValid
}

function LogWarning([bool]$devOpsLogging, [string]$logMessage)
{
  if ($devOpsLogging)
  {
    Write-Host "##vso[task.LogIssue type=warning;]$logMessage"
  }
  else
  {
    Write-Warning "$logMessage"
  }
}

function LogError([bool]$devOpsLogging, [string]$logMessage)
{
  if ($devOpsLogging)
  {
    Write-Host "##vso[task.logissue type=error]$logMessage"
  }
  else
  {
    Write-Error "$logMessage"
  }
}

function ReplaceLink ($scanFolder, $fileSuffix, $replacement, $customRegex) {
  # Check all parameters
  $regex = new-object System.Text.RegularExpressions.Regex ($linkReplaceRegex, $regexOptions)
  if ($customRegex) {
    $regex = new-object System.Text.RegularExpressions.Regex ($customRegex, $regexOptions)
  }
 
  if (!$fileSuffix) {
    LogWarning "Will scan markdown files by default."
    $fileSuffix = $suffix
  }
  if (!$replacement) {
    LogError "Please provide the replacement string to replace with."
    return
  }
  $replacementPattern = "`${1}$replacement`$2"


  # Retrieved qualified files.
  if (!$scanFolder) {
    LogWarning "No folder to scan against. Exiting."
    return
  }
  $fileSuffixArray = $fileSuffix -split "," 
  $visitedLinks = @{}
  foreach ($fileExtension in $fileSuffixArray) {
    $fileRegex = "*" + $fileSuffix.Trim()
    foreach ($url in Get-ChildItem -Path "$scanFolder/*" -Recurse -Include $fileRegex) {
      $content = Get-Content -Path $url
      # Skip, if no match
      if (!($content -match $regex)) {
        continue
      }
      $uri = NormalizeUrl $url
      $replaceMapping = @{}
      foreach ($link in (GetLinks $uri $regex)) {
        if (CheckLink -linkUri ($link.ToString() -replace $regex, $replacementPattern) -checkedLinks $visitedLinks) {
          $replaceMapping[$($link.ToString())] = $link.ToString() -replace $regex, $replacementPattern
        }
      }
      Write-Host "Replaced $($replaceMapping.count) link(s) in page $url."
      foreach($originLink in $replaceMapping.Keys) {
        Write-Host "Replace $originLink to $($replaceMapping[$originLink])."
        (Get-Content -Path $url) -replace $originLink, $replaceMapping[$originLink] | Set-Content -Path $url
      }
    }
  }
}

function ResolveUri ([System.Uri]$referralUri, [string]$link, [string]$rootUrl)
{
  # If the link is mailto, skip it.
  if ($link.StartsWith("mailto:")) {
    Write-Verbose "Skipping $link because it is a mailto link."
    return $null
  }

  $linkUri = [System.Uri]$link;
  # Our link guidelines do not allow relative links so only resolve them when we are not
  # validating links against our link guidelines (i.e. !$checkLinkGuideance)
  if(!$checkLinkGuidance) {
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

function ParseLinks([string]$baseUri, [string]$htmlContent, [string]$pattern)
{
  $hrefRegex = "<a[^>]+href\s*=\s*[""']?(?<href>[^""']*)[""']?"
 
  $hrefs = [RegEx]::Matches($htmlContent, $hrefRegex, $regexOptions);

  #$hrefs | Foreach-Object { Write-Host $_ }

  Write-Verbose "Found $($hrefs.Count) raw href's in page $baseUri";
  $links = $hrefs | ForEach-Object { ResolveUri $baseUri $_.Groups["href"].Value "d"} 
    | Where-Object {$_ -match $pattern} | Sort-Object -Unique

  #$links | Foreach-Object { Write-Host $_ }

  return $links
}

function GetLinks([System.Uri]$pageUri, [string]$pattern)
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

  $links = ParseLinks $pageUri $content $pattern

  foreach ($link in $links) {
    Write-Host "Here is the link you want: $link."
  }
  return $links;
}

function NormalizeUrl([string]$url, [string]$baseUrl, [string]$rootUrl){
  if (Test-Path $url) {
    $url = "file://" + (Resolve-Path $url).ToString();
  }

  $uri = [System.Uri]$url;

  if ($baseUrl -eq "") {
    # for base url default to containing directory
    $baseUrl = (new-object System.Uri($uri, ".")).ToString();
  }

  if ($rootUrl -eq "") {
    if ($uri.IsFile) { 
      # for files default to the containing directory
      $rootUrl = $baseUrl;
    }
    else {
      # for http links default to the root path
      $rootUrl = new-object System.Uri($uri, "/");
    }
  }
  return $uri
}

#ReplaceLink -scanFolder $sourceDir -replacement $replacePattern -fileSuffix $suffix -customRegex $branchReplaceRegex