$ProgressPreference = 'SilentlyContinue'
$tests = @(
  @{
    Name = 'PUBLIC_BASELINE'
    Url = 'https://apiview.dev/api/PullRequests/CreateAPIRevisionIfAPIHasChanges?artifactName=packages_PRBatch&buildId=5977923&filePath=%2FAzure.AI.AgentServer.AgentFramework%2FAzure.AI.AgentServer.AgentFramework.1.0.0-alpha.20260308.1.nupkg&commitSha=8ce7f33aa42f0948037329204d4b5e12cdadc2f2&repoName=Azure%2Fazure-sdk-for-net&pullRequestNumber=56873&packageName=Azure.AI.AgentServer.AgentFramework&language=net&project=public&packageType=client'
  },
  @{
    Name = 'INTERNAL_JAVA_PR'
    Url = 'https://apiview.dev/api/PullRequests/CreateAPIRevisionIfAPIHasChanges?artifactName=packages&buildId=5237815&filePath=%2Fcom.azure.resourcemanager%2Fazure-resourcemanager-impactreporting%2Fazure-resourcemanager-impactreporting-1.0.0-beta.2-sources.jar&commitSha=98fc55c8df1df6dc73585cfa1c858e6b966e1d98&repoName=Azure%2Fazure-sdk-for-java&pullRequestNumber=46447&packageName=com.azure.resourcemanager%3Aazure-resourcemanager-impactreporting&language=java&project=internal&packageType=mgmt'
  }
)

$scratch = Join-Path ([System.IO.Path]::GetTempPath()) ("apiview-poc-" + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $scratch | Out-Null

foreach ($test in $tests) {
  $headersPath = Join-Path $scratch ($test.Name + '.headers.txt')
  $bodyPath = Join-Path $scratch ($test.Name + '.body.txt')
  $corr = [guid]::NewGuid().ToString()

  Write-Host "POC_BEGIN:$($test.Name)"
  Write-Host "POC_CORRELATION:$($test.Name):$corr"

  & curl.exe -sS -D $headersPath -o $bodyPath --max-time 60 -H "x-correlation-id: $corr" $test.Url
  $curlExit = $LASTEXITCODE
  Write-Host "POC_CURL_EXIT:$($test.Name):$curlExit"

  $statusLine = ''
  if (Test-Path $headersPath) {
    $statusLine = Select-String -Path $headersPath -Pattern '^HTTP/\S+\s+\d+' | Select-Object -Last 1 | ForEach-Object { $_.Line }
  }

  if ($statusLine -match '^HTTP/\S+\s+(\d+)') {
    Write-Host "POC_STATUS:$($test.Name):$($matches[1])"
  }

  if (Test-Path $bodyPath) {
    $body = Get-Content $bodyPath -Raw
    if ($body.Length -gt 2500) {
      $body = $body.Substring(0, 2500)
    }
    if ($body) {
      Write-Host "POC_BODY:$($test.Name):$body"
    }
  }

  Write-Host "POC_END:$($test.Name)"
}
