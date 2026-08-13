# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

[CmdletBinding()]
param(
    [uri]$Uri = 'ws://localhost:8088/invocations_ws'
)

$ErrorActionPreference = 'Stop'
$socket = [System.Net.WebSockets.ClientWebSocket]::new()
$noCancellation = [System.Threading.CancellationToken]::None

function Send-Json([object]$Value) {
    $json = $Value | ConvertTo-Json -Depth 10 -Compress
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $segment = [System.ArraySegment[byte]]::new($bytes)
    $null = $socket.SendAsync(
        $segment,
        [System.Net.WebSockets.WebSocketMessageType]::Text,
        $true,
        $noCancellation).GetAwaiter().GetResult()
}

function Receive-Json {
    $stream = [System.IO.MemoryStream]::new()
    try {
        do {
            $buffer = [byte[]]::new(4096)
            $segment = [System.ArraySegment[byte]]::new($buffer)
            $result = $socket.ReceiveAsync($segment, $noCancellation).GetAwaiter().GetResult()
            if ($result.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close) {
                throw "Server closed the socket: $($socket.CloseStatus) $($socket.CloseStatusDescription)"
            }
            $stream.Write($buffer, 0, $result.Count)
        } while (-not $result.EndOfMessage)

        $json = [System.Text.Encoding]::UTF8.GetString($stream.ToArray())
        return $json | ConvertFrom-Json
    }
    finally {
        $stream.Dispose()
    }
}

$script:messageNumber = 1

function Send-UserMessage([string]$Text) {
    $script:messageNumber++
    Send-Json @{
        type = 'user.message'
        id = "m_smoke_$script:messageNumber"
        ts = [DateTimeOffset]::UtcNow.ToString('O')
        item_id = "in_smoke_$script:messageNumber"
        content = @(@{ type = 'input_text'; text = $Text })
    }
}

function Send-Inbound([string]$Type, [hashtable]$Fields) {
    $script:messageNumber++
    $message = @{
        type = $Type
        id = "m_smoke_$script:messageNumber"
        ts = [DateTimeOffset]::UtcNow.ToString('O')
    }
    foreach ($entry in $Fields.GetEnumerator()) {
        $message[$entry.Key] = $entry.Value
    }
    Send-Json $message
}

function Expect-Frame([string]$Type) {
    $frame = Receive-Json
    Write-Host "Received $($frame.type)"
    if ($frame.type -ne $Type) {
        throw "Expected $Type, received $($frame.type)"
    }
    return $frame
}

try {
    Write-Host "Connecting to $Uri"
    $null = $socket.ConnectAsync($Uri, $noCancellation).GetAwaiter().GetResult()

    Send-Json @{
        type = 'session.start'
        id = 'm_smoke_start'
        ts = [DateTimeOffset]::UtcNow.ToString('O')
        protocol_version = '1.0'
        reconnect = $false
        response_timeouts = @{
            first_output_ms = 5000
            idle_ms = 8000
            max_duration_ms = 60000
        }
    }

    $ready = Receive-Json
    if ($ready.type -ne 'session.ready') {
        throw "Expected session.ready, received $($ready.type)"
    }
    Write-Host 'Received session.ready'

    Send-Json @{
        type = 'user.message'
        id = 'm_smoke_user'
        ts = [DateTimeOffset]::UtcNow.ToString('O')
        item_id = 'in_smoke_1'
        content = @(@{ type = 'input_text'; text = 'hello' })
    }

    $types = [System.Collections.Generic.List[string]]::new()
    $completedText = $null
    do {
        $frame = Receive-Json
        $null = $types.Add([string]$frame.type)
        Write-Host "Received $($frame.type)"
        if ($frame.type -eq 'response.output_text.done') {
            $completedText = [string]$frame.text
        }
    } while ($frame.type -ne 'response.done')

    foreach ($requiredType in @(
        'response.created',
        'response.output_text.delta',
        'response.output_text.done',
        'response.done')) {
        if (-not $types.Contains($requiredType)) {
            throw "Missing $requiredType. Received: $($types -join ', ')"
        }
    }
    if ($completedText -ne 'Echo: hello') {
        throw "Expected 'Echo: hello', received '$completedText'"
    }

    Send-Inbound 'user.speech_started' @{}

    Send-UserMessage '/done world'
    $created = Expect-Frame 'response.created'
    $done = Expect-Frame 'response.output_text.done'
    $null = Expect-Frame 'response.done'
    if ($done.text -ne 'Echo: world') {
        throw "Non-streaming echo returned '$($done.text)'"
    }

    Send-UserMessage '/voice faster'
    $null = Expect-Frame 'response.created'
    $done = Expect-Frame 'response.output_text.done'
    $null = Expect-Frame 'response.done'
    if ($done.voice.rate -ne '+10%') {
        throw 'Voice patch was not preserved.'
    }

    Send-UserMessage '/none'
    $null = Expect-Frame 'response.none'

    Send-UserMessage '/proactive accepted'
    $null = Expect-Frame 'response.none'
    $proactive = Expect-Frame 'response.created'
    Send-Inbound 'response.accepted' @{ response_id = $proactive.response_id }
    $proactiveDone = Expect-Frame 'response.output_text.done'
    $null = Expect-Frame 'response.done'
    if ($proactiveDone.text -ne 'Proactive echo: accepted') {
        throw "Proactive echo returned '$($proactiveDone.text)'"
    }

    Send-UserMessage '/proactive dropped'
    $null = Expect-Frame 'response.none'
    $proactive = Expect-Frame 'response.created'
    Send-Inbound 'response.dropped' @{
        response_id = $proactive.response_id
        reason = 'superseded'
    }

    Send-UserMessage '/cancel correction'
    $created = Expect-Frame 'response.created'
    $null = Expect-Frame 'response.output_text.delta'
    $cancel = Expect-Frame 'response.cancel'
    if ($cancel.response_id -ne $created.response_id) {
        throw 'response.cancel used a different response ID.'
    }
    Send-Inbound 'response.cancelled' @{
        response_id = $cancel.response_id
        heard_text = 'correction'
    }

    Send-Inbound 'user.no_input' @{
        item_id = 'in_smoke_no_input'
        count = 1
    }
    $null = Expect-Frame 'response.created'
    $null = Expect-Frame 'response.output_text.done'
    $null = Expect-Frame 'response.done'

    Send-UserMessage '/error'
    $created = Expect-Frame 'response.created'
    $errorFrame = Expect-Frame 'error'
    if ($errorFrame.response_id -ne $created.response_id) {
        throw 'Response-scoped error used a different response ID.'
    }

    Send-UserMessage '/end'
    $endCall = Expect-Frame 'end_call'
    if ($endCall.mode -ne 'drain') {
        throw "Expected drain end_call, received '$($endCall.mode)'"
    }

    Send-Inbound 'session.end' @{ reason = 'caller_hangup' }

    Write-Host 'Voice Bridge echo smoke test passed.' -ForegroundColor Green
}
finally {
    if ($socket.State -eq [System.Net.WebSockets.WebSocketState]::Open) {
        $null = $socket.CloseOutputAsync(
            [System.Net.WebSockets.WebSocketCloseStatus]::NormalClosure,
            'smoke test complete',
            $noCancellation).GetAwaiter().GetResult()
    }
    $socket.Dispose()
}
