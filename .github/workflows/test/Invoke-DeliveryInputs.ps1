# Test adapter: exercise the production PowerShell selector on compact JSON input.
$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [Text.UTF8Encoding]::new($false, $true)
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewSerialization.psm1') -Force
$options = [System.Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth = 10000
$document = [System.Text.Json.JsonDocument]::Parse([Console]::In.ReadToEnd(), $options)
try {
    $results = [Collections.Generic.List[object]]::new()
    foreach ($item in $document.RootElement.EnumerateArray()) {
        try { $results.Add(@{ value = (Get-JsRequiredInputs $item 48000) }) }
        catch { $results.Add(@{ error = $_.Exception.Message }) }
    }
    [Console]::Out.Write((ConvertTo-Json -InputObject $results.ToArray() -Depth 100 -Compress -EscapeHandling EscapeNonAscii))
} finally { $document.Dispose() }
