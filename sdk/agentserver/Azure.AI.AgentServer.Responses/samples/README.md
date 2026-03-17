# Samples

Runnable ASP.NET Core servers demonstrating the Azure.AI.AgentServer.Responses.

Each sample is a minimal server with a single `IResponseHandler` implementation.
Every sample includes a `test.sh` script that starts the server, exercises it with `curl`,
and logs full HTTP wireline (request line, headers, and body for both request and response).

## Prerequisites

- .NET 8 SDK

## Samples

### GettingStarted

A minimal echo handler that returns a text message. The test script exercises three modes:

- **Default** — synchronous JSON response
- **Streaming** — SSE event stream
- **Background** — returns immediately, then retrieves via GET

```bash
bash samples/GettingStarted/test.sh
```

### FunctionCalling

A two-turn conversation demonstrating function call flow:

1. **Turn 1** — Client sends a prompt. Server returns a `get_weather` function call output item.
2. **Turn 2** — Client submits a `function_call_output` with weather data. Server returns a text message with the result.

Turns are tied together using a `conversation` ID. The conversation ID uses a valid
`{prefix}_{partitionKey}{entropy}` format so that the server's generated response and
output item IDs share the same partition key for storage colocation.

```bash
bash samples/FunctionCalling/test.sh
```

### MultiOutput

A handler that produces multiple output items in a single response:

1. A **reasoning** item with a summary part
2. A **text message** with the final answer

Demonstrates automatic `outputIndex` management across mixed output types.

```bash
bash samples/MultiOutput/test.sh
```

### ConversationHistory

A multi-turn conversational handler demonstrating `previous_response_id` chaining
and `context.GetHistoryAsync()`:

1. **Turn 1** — Initial message with no history.
2. **Turn 2** — Chains via `previous_response_id` — handler sees Turn 1 output in history.
3. **Turn 3** — Chains again — handler sees Turn 1 + Turn 2 output in history.

Also demonstrates configuring `DefaultFetchHistoryCount` to control history depth.

```bash
bash samples/ConversationHistory/test.sh
```

## Run All

Build all samples and run every test script sequentially:

```bash
bash samples/test-all.sh
```

Each script starts its server on a unique port (5100–5103), runs the tests,
and tears down the server on exit via a `trap`.

## Test Script Features

All test scripts source shared helpers from `test-helpers.sh`, which provides:

- **`http METHOD PATH [BODY]`** — JSON request/response with full HTTP wireline logging
- **`http_stream METHOD PATH BODY`** — SSE request with wireline logging
- **`start_sample_server`** — Starts the server, waits for `/ready`, sets up cleanup trap
- **`pass`** — Prints the success banner

Each sample's `test.sh` only contains the sample-specific test logic — set
`SAMPLE_NAME` and `SAMPLE_PORT`, source the helpers, and call the functions.

Additional features:
- **Full HTTP wireline logging** — Every request/response is printed in HTTP/1.1 format:
  request method, path, headers, pretty-printed JSON body, then response status, headers, and body.
- **Readiness probing** — Scripts poll `GET /ready` before sending test requests.
- **Automatic cleanup** — Server process is killed on script exit (normal, error, or signal).
- **Unique ports** — Each sample uses its own port to avoid conflicts.
