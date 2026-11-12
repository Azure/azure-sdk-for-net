$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [Text.UTF8Encoding]::new($false,$true)
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewContinuation.psm1') -Force
Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewSerialization.psm1') -Force
$options = [Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth = 10000
$document = [Text.Json.JsonDocument]::Parse([Console]::In.ReadToEnd(),$options)
try {
    $output = [Collections.Generic.List[string]]::new()
    foreach ($case in $document.RootElement.EnumerateArray()) {
        try {
            $snapshot = Get-JsonProperty $case 'snapshot'
            $mode = Get-JsonProperty $case 'mode'
            if ($null -ne $mode -and (Get-JsString $mode) -ceq 'worker-prompt') {
                $output.Add((ConvertTo-ContinuationJson (New-ContinuationWorkerPrompt (Get-JsonProperty $case 'payload'))))
                continue
            }
            if ($null -ne $mode -and (Get-JsString $mode) -ceq 'batch') {
                $count = Select-JsReviewBatch (Get-JsonProperty $case 'work') (Get-JsonProperty $case 'maxItems').GetInt64() (Get-JsonProperty $case 'maxBytes').GetInt64()
                $output.Add(('{"count":' + $count + '}'))
                continue
            }
            if ($null -ne $mode -and (Get-JsString $mode) -ceq 'publication') {
                Assert-ContinuationPublication $snapshot (Get-JsonProperty $case 'progress') (Get-JsonProperty $case 'output') (Get-JsonProperty $case 'agentResult') (Get-JsString (Get-JsonProperty $case 'snapshotHash')) (Get-JsonProperty $case 'actualRouting') (Get-JsonProperty $case 'routingError')
                $output.Add('{"verified":true}')
                continue
            }
            if ($null -ne $mode -and (Get-JsString $mode) -ceq 'state') {
                $state = New-ContinuationState $snapshot (Get-JsString (Get-JsonProperty $case 'snapshotHash'))
                $assignment = Get-ContinuationAssignment $state ('1'*32)
                $value = @{checkpoint=(Get-ContinuationCheckpoint $state);assignment=$assignment}
                $output.Add((ConvertTo-JsJsonText (ConvertTo-Json -InputObject $value -Depth 100 -Compress)))
                continue
            }
            if ($null -ne $mode -and (Get-JsString $mode) -ceq 'outputs') {
                $outputs = New-ContinuationOutputs $snapshot (Get-JsonProperty $case 'ledger')
                $output.Add(('{"outputs":' + (ConvertTo-ContinuationJson $outputs) + '}'))
                continue
            }
            $work = New-ContinuationWorklist $snapshot
            $response = Get-JsonProperty $case 'response'
            if ($null -eq $response) { $output.Add(('{"work":[' + (($work | ForEach-Object {$_.Json}) -join ',') + ']}')) }
            else {
                $accepted = ConvertTo-ContinuationResults $work $response
                $json = ConvertTo-Json -InputObject $accepted -Depth 100 -Compress
                $output.Add(('{"accepted":' + (ConvertTo-JsJsonText $json) + '}'))
            }
        } catch { $output.Add((ConvertTo-Json -InputObject @{error=$_.Exception.Message} -Compress -EscapeHandling EscapeNonAscii)) }
    }
    [Console]::Out.Write('[' + ($output -join ',') + ']')
} finally { $document.Dispose() }
