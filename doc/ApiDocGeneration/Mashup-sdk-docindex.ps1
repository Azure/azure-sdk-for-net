[CmdletBinding()]
Param (
    [Parameter(Mandatory = $True)]
    $DocOutHtmlDir,
    [Parameter(Mandatory = $True)]
    $ArtifactStagingDirectory,
    [Parameter(Mandatory = $True)]
    $ArtifactName
)

function ResolveUri ([String]$link, [String]$url)
{
  $linkUri = [System.Uri]$link
  # Check if the relative path inside of original api folder.
  if (!$linkUri.IsAbsoluteUri -and $link.StartsWith("../")) {
    return 
  }
  return $link
}

function ParseLinks([string]$htmlContent, [string]$url)
{
  $hrefRegex = "[""']../(?<href>[^""']*)"
  $regexOptions = [System.Text.RegularExpressions.RegexOptions]"Singleline, IgnoreCase"

  $hrefs = [RegEx]::Matches($htmlContent, $hrefRegex, $regexOptions)
  if (!$hrefs) {
    return $null
  }
  return $hrefs
}

function Update-Relative-links([String[]]$content, [String]$urlToReplace) {
  $mutatedContent = @()
  foreach ($line in $content) {
    $originalLinks = ParseLinks -htmlContent $line -url $urlToReplace
    if (!$originalLinks) {
      $mutatedContent += $line
    }
    foreach ($link in $originalLinks) {
      $originalLink = "../" + $link.Groups["href"].Value
      $mutatedContent += $line.Replace($originalLink, $link.Groups["href"].Value)
    }
  }
  return $mutatedContent
}

# Copy everything inside of /api out.
$urlToFlatten = "${DocOutHtmlDir}/api/"
$destFolder = "${DocOutHtmlDir}/"
Move-Item -Path "${DocOutHtmlDir}/api/*" -Destination $destFolder -Confirm:$false -Force
Remove-Item $urlToFlatten -Confirm:$false 

# Change the relative path inside index.html.
$baseUrl = $destFolder + "index.html"
$content = Get-Content -Path $baseUrl
$mutatedContent = Update-Relative-links -content $content -urlToReplace $urlToFlatten
Set-Content -Path $baseUrl -Value $mutatedContent

Write-Verbose "Compress and copy HTML into the staging Area"
Compress-Archive -Path "${DocOutHtmlDir}/*" -DestinationPath "${ArtifactStagingDirectory}/${ArtifactName}/${ArtifactName}.docs.zip" -CompressionLevel Fastest