#Requires -Version 7.5
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    $script:baseline = Join-Path $PSScriptRoot '../pr-re-review/ReviewBaselines.ps1'
    function Invoke-BaselineCli([string] $InputJson) {
        $info = [Diagnostics.ProcessStartInfo]::new()
        $info.FileName = (Get-Process -Id $PID).Path
        foreach ($arg in @('-NoLogo', '-NoProfile', '-NonInteractive', '-File', $script:baseline)) { [void]$info.ArgumentList.Add($arg) }
        $info.RedirectStandardInput = $true; $info.RedirectStandardOutput = $true; $info.RedirectStandardError = $true
        $process = [Diagnostics.Process]::Start($info)
        $stdoutTask = $process.StandardOutput.ReadToEndAsync(); $stderrTask = $process.StandardError.ReadToEndAsync()
        $process.StandardInput.Write($InputJson); $process.StandardInput.Close()
        $process.WaitForExit()
        return @{ ExitCode = $process.ExitCode; Stdout = $stdoutTask.GetAwaiter().GetResult(); Stderr = $stderrTask.GetAwaiter().GetResult() }
    }
}

Describe 'Baseline comparator CLI serialization' {
    It 'serializes empty, singleton and multiple results as JSON arrays' {
        foreach ($case in @(
            @{ xml='<Suppressions/>'; count=0 },
            @{ xml='<Suppressions><Suppression><DiagnosticId>CP1</DiagnosticId><Target>T:One</Target></Suppression></Suppressions>'; count=1 },
            @{ xml='<Suppressions><Suppression><DiagnosticId>CP1</DiagnosticId><Target>T:One</Target></Suppression><Suppression><DiagnosticId>CP2</DiagnosticId><Target>T:Two</Target></Suppression></Suppressions>'; count=2 }
        )) {
            $inputJson = ConvertTo-Json -InputObject @(@{path='x.xml';base=$null;head=$case.xml}) -Depth 10 -Compress
            $result = Invoke-BaselineCli $inputJson
            $result.ExitCode | Should -Be 0
            $decoded = ConvertFrom-Json -InputObject $result.Stdout -AsHashtable -NoEnumerate
            ($decoded -is [array]) | Should -BeTrue
            $decoded.Count | Should -Be $case.count
        }
    }
    It 'preserves Unicode and case-distinct field names through Node JSON.parse' {
        $xml='<Suppressions><Suppression><DiagnosticId>CP1</DiagnosticId><Target>T:𝄞界</Target><target>different</target></Suppression></Suppressions>'
        $result=Invoke-BaselineCli (ConvertTo-Json -InputObject @(@{path='x.xml';base=$null;head=$xml}) -Depth 10 -Compress)
        $result.ExitCode | Should -Be 0
        $script = 'let t="";process.stdin.setEncoding("utf8");process.stdin.on("data",x=>t+=x);process.stdin.on("end",()=>{const v=JSON.parse(t);if(!Array.isArray(v)||v.length!==1||v[0].fields.Target!=="T:𝄞界"||v[0].fields.target!=="different"||v[0].fields.DiagnosticId!=="CP1")process.exitCode=1;});'
        $result.Stdout | & node -e $script
        $LASTEXITCODE | Should -Be 0
    }
    It 'fails closed for malformed JSON input' {
        $result=Invoke-BaselineCli '{'
        $result.ExitCode | Should -Not -Be 0
        $result.Stderr | Should -Match 'Invalid baseline input'
    }
}
