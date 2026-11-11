#Requires -Version 7.5
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
  Import-Module (Join-Path $PSScriptRoot '../pr-re-review/PrReReviewInput.psm1') -Force
  $script:dir = Join-Path ([IO.Path]::GetTempPath()) ('gh-fixture-' + [guid]::NewGuid().ToString('N'))
  [IO.Directory]::CreateDirectory($script:dir) | Out-Null
  $fake = @'
#!/usr/bin/env node
const fs=require('node:fs');const status=process.env.MOCK_STATUS, exit=Number(process.env.MOCK_EXIT || '0'), body=process.env.MOCK_BODY_FILE ? fs.readFileSync(process.env.MOCK_BODY_FILE,'utf8') : process.env.MOCK_BODY || '{"ok":true}';
if(status !== 'missing') process.stdout.write(status === 'malformed' ? 'NOT HTTP\n' : `HTTP/2.0 ${status} Example\n`);
if(exit) process.stderr.write(`gh: error (HTTP ${status})\n`);
process.stdout.write('Content-Type: application/json\n\n'+body+'\n', () => { process.exitCode = exit; });
'@
  if ($IsWindows) {
    [IO.File]::WriteAllText((Join-Path $script:dir 'gh-test.cjs'), $fake, [Text.UTF8Encoding]::new($false))
    [IO.File]::WriteAllText((Join-Path $script:dir 'gh.cmd'), "@node `"%~dp0gh-test.cjs`" %*`r`n", [Text.Encoding]::ASCII)
  } else {
    [IO.File]::WriteAllText((Join-Path $script:dir 'gh'), $fake, [Text.UTF8Encoding]::new($false))
    & chmod +x (Join-Path $script:dir 'gh')
  }
  $script:oldPath=$env:PATH; $script:oldStatus=$env:MOCK_STATUS; $script:oldExit=$env:MOCK_EXIT; $script:oldBody=$env:MOCK_BODY; $script:oldBodyFile=$env:MOCK_BODY_FILE
  $env:PATH="$script:dir$([IO.Path]::PathSeparator)$env:PATH"; Remove-Item Env:MOCK_BODY_FILE -ErrorAction SilentlyContinue
}
AfterAll { $env:PATH=$script:oldPath; $env:MOCK_STATUS=$script:oldStatus; $env:MOCK_EXIT=$script:oldExit; $env:MOCK_BODY=$script:oldBody; $env:MOCK_BODY_FILE=$script:oldBodyFile; Remove-Item -Recurse -Force $script:dir }
Describe 'gh --include transport' {
  It 'returns exact status <Status> and exit <Exit>' -ForEach @(
    @{Status='200';Exit='0'},@{Status='403';Exit='1'},@{Status='404';Exit='1'},@{Status='401';Exit='1'},@{Status='429';Exit='1'},@{Status='500';Exit='1'}
  ) {
    $env:MOCK_STATUS=$Status;$env:MOCK_EXIT=$Exit;$env:MOCK_BODY='{"ok":true}'
    $result=Invoke-PrReReviewGhApi -Arguments @('repos/Azure/repo/contents/a') -IncludeStatus
    $result.Status | Should -Be ([int]$Status)
    $result.ExitCode | Should -Be ([int]$Exit)
    ($result.Body|ConvertFrom-Json).ok | Should -BeTrue
  }
  It 'reads a 4 MiB blob response without truncation' {
    $env:MOCK_STATUS='200';$env:MOCK_EXIT='0';$env:MOCK_BODY_FILE=Join-Path $script:dir 'body.json'
    $content='A' * (4 * 1024 * 1024 * 4 / 3 + 4)
    [IO.File]::WriteAllText($env:MOCK_BODY_FILE, (ConvertTo-Json -InputObject @{ content = $content } -Compress), [Text.UTF8Encoding]::new($false))
    try {
      $result=Invoke-PrReReviewGhApi -Arguments @('repos/Azure/repo/git/blobs/example') -IncludeStatus
      $result.Status | Should -Be 200
      ($result.Body|ConvertFrom-Json).content.Length | Should -Be $content.Length
    } finally { Remove-Item Env:MOCK_BODY_FILE -ErrorAction SilentlyContinue }
  }
  It 'returns unknown status for missing or malformed response status' -ForEach @('missing','malformed') {
    $env:MOCK_STATUS=$_;$env:MOCK_EXIT='1';$result=Invoke-PrReReviewGhApi -Arguments @('repos/Azure/repo/contents/a') -IncludeStatus
    $result.Status | Should -Be 0
    $result.ExitCode | Should -Be 1
  }
}
