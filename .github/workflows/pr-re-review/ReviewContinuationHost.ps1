#Requires -Version 7.3
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# One private host per queue (or independent publication guard). Only the
# trusted Node adapter writes stdin; model results remain nested data.
$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [Text.UTF8Encoding]::new($false,$true)
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot 'ReviewContinuation.psm1') -Force
Import-Module (Join-Path $PSScriptRoot 'ReviewSerialization.psm1') -Force
$options=[Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth=10000
$state=$null; $purpose=$null; $finished=$false
$operations=[Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
foreach ($name in @('initialize','next','worker-prompt','complete','finish','assert-publication')) { [void]$operations.Add($name) }
function Write-CoreResponse([long] $Id, $Result) {
    [Console]::Out.WriteLine((ConvertTo-ContinuationJson ([ordered]@{id=$Id;result=$Result})))
}
function Require-Queue {
    if ($null -eq $script:state -or $script:finished) { throw 'No active continuation queue.' }
}
while ($null -ne ($line=[Console]::In.ReadLine())) {
    $document=$null; $id=[long]0
    try {
        $document=[Text.Json.JsonDocument]::Parse($line,$options)
        $root=$document.RootElement; $idElement=Get-JsonProperty $root 'id'
        if ($null -eq $idElement -or $idElement.ValueKind -ne [Text.Json.JsonValueKind]::Number -or -not $idElement.TryGetInt64([ref]$id) -or $id -le 0 -or $id -gt 9007199254740991) { throw 'Invalid core request identity.' }
        $operation=Get-JsString (Get-JsonProperty $root 'operation'); $payload=Get-JsonProperty $root 'payload'
        if (-not $operations.Contains($operation)) { throw 'Unsupported continuation operation.' }
        if ($null -eq $payload -or $payload.ValueKind -ne [Text.Json.JsonValueKind]::Object) { throw 'Invalid core request payload.' }
        switch -CaseSensitive ($operation) {
            'initialize' {
                if ($null -ne $purpose) { throw 'Continuation host already initialized.' }
                $snapshot=Get-JsonProperty $payload 'snapshot'
                if ($null -eq $snapshot) { throw 'Missing captured snapshot.' }
                $state=New-ContinuationState $snapshot.Clone() (Get-JsString (Get-JsonProperty $payload 'snapshotHash'))
                $purpose='queue'
                $result=[ordered]@{work_count=$state.Work.Count;checkpoint=(Get-ContinuationCheckpoint $state)}
                break
            }
            'next' {
                Require-Queue
                $result=Get-ContinuationAssignment $state (Get-JsString (Get-JsonProperty $payload 'nonce'))
                break
            }
            'worker-prompt' {
                Require-Queue
                $result=Get-ContinuationWorkerPrompt $state $payload
                break
            }
            'complete' {
                Require-Queue
                $result=Complete-ContinuationAssignment $state (Get-JsonProperty $payload 'attempt_id') (Get-JsString (Get-JsonProperty $payload 'nonce')) (Get-JsonProperty $payload 'deliveryVerified') (Get-JsonProperty $payload 'response')
                break
            }
            'finish' {
                Require-Queue
                $result=Complete-ContinuationReview $state
                $finished=$true
                break
            }
            'assert-publication' {
                if ($null -ne $purpose -and -not [StringComparer]::Ordinal.Equals($purpose,'guard')) { throw 'Invalid guard operation in a running queue.' }
                $purpose='guard'
                Assert-ContinuationPublication (Get-JsonProperty $payload 'snapshot') (Get-JsonProperty $payload 'progress') (Get-JsonProperty $payload 'output') (Get-JsonProperty $payload 'agentResult') (Get-JsString (Get-JsonProperty $payload 'snapshotHash')) (Get-JsonProperty $payload 'actualRouting') (Get-JsonProperty $payload 'routingError')
                $result=[ordered]@{verified=$true}
                break
            }
            default { throw 'Unsupported continuation operation.' }
        }
        Write-CoreResponse $id $result
    } catch {
        [Console]::Out.WriteLine((ConvertTo-ContinuationJson ([ordered]@{id=$id;error=$_.Exception.Message})))
        exit 1
    } finally { if ($null -ne $document) { $document.Dispose() } }
}
if ([StringComparer]::Ordinal.Equals($purpose,'queue') -and -not $finished) {
    [Console]::Error.WriteLine('Continuation queue closed before verified finalization.')
    exit 1
}
