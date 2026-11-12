# Test adapter: exercise the shared production selector on compact JSON input.
param([switch] $Stream)
$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [Text.UTF8Encoding]::new($false, $true)
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewSerialization.psm1') -Force
$options = [Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth = 10000
if ($Stream) {
    while ($null -ne ($line = [Console]::In.ReadLine())) {
        $frame = [Text.Json.JsonDocument]::Parse($line, $options)
        try {
            $root = $frame.RootElement
            $count = Select-JsReviewBatch (Get-JsonProperty (Get-JsonProperty $root 'payload') 'work') 8 48000
            [Console]::Out.WriteLine(('{"id":' + (Get-JsonProperty $root 'id').GetRawText() + ',"result":' + $count + '}'))
        } finally { $frame.Dispose() }
    }
    exit 0
}
$document = [Text.Json.JsonDocument]::Parse([Console]::In.ReadToEnd(), $options)
try {
    $counts = [Collections.Generic.List[int]]::new()
    foreach ($case in $document.RootElement.EnumerateArray()) {
        $counts.Add((Select-JsReviewBatch (Get-JsonProperty $case 'work') 8 48000))
    }
    [Console]::Out.Write((ConvertTo-Json -InputObject $counts.ToArray() -Compress))
} finally { $document.Dispose() }
