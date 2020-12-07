[CmdletBinding()]
Param (
    [Parameter(Mandatory = $True)]
    $DocOutHtmlDir,
    [Parameter(Mandatory = $True)]
    $ArtifactStagingDirectory,
    [Parameter(Mandatory = $True)]
    $ArtifactName
)

# Copy everything inside of /api out.
Write-Verbose "Copy index.html and toc.yml out."
$destFolder = "${DocOutHtmlDir}/"
Copy-Item -Path "${DocOutHtmlDir}/api/index.html" -Destination $destFolder -Confirm:$false -Force

# Change the relative path inside index.html.
Write-Verbose "Make changes on relative path on page index.html."
$baseUrl = $destFolder + "index.html"
$content = Get-Content -Path $baseUrl -Raw
$hrefRegex = "[""']\.\.\/([^""']*)[""']"
$tocRegex = "(./)?toc.html"
$mutatedContent = $content -replace $hrefRegex, '"./$1"'
$mutatedContent = $mutatedContent -replace $tocRegex, './api/toc.html'
Set-Content -Path $baseUrl -Value $mutatedContent -NoNewline

Write-Verbose "Compress and copy HTML into the staging Area"
Compress-Archive -Path "${DocOutHtmlDir}/*" -DestinationPath "${ArtifactStagingDirectory}/${ArtifactName}/${ArtifactName}.docs.zip" -CompressionLevel Fastest  