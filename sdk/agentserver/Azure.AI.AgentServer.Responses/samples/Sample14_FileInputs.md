# Sample 14: File inputs

This sample shows how to build handlers that receive files as input. The Responses protocol supports three ways to send files:

1. **Base64 inline** — file content encoded in the `file_data` field as a `data:<mime>;base64,<data>` string
2. **URL** — a publicly accessible URL in the `file_url` field
3. **File ID** — a reference to a previously uploaded file in the `file_id` field

The server library deserializes all three into `MessageContentInputFileContent`. Your handler can inspect which fields are populated and act accordingly.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Handle base64 file input

Clients can send file content inline using a base64 data URL in the `file_data` field. The handler extracts the raw bytes from the data URL:

```C# Snippet:Responses_Sample14_FileBase64Handler
public class FileBase64Handler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var items = await context.GetInputItemsAsync(cancellationToken: cancellationToken);

        // Find file content parts from user messages.
        var files = items
            .OfType<ItemMessage>()
            .SelectMany(msg => msg.GetContentExpanded())
            .OfType<MessageContentInputFileContent>()
            .ToList();

        string reply;
        if (files.Count > 0 && DataUrl.TryDecodeBytes(files[0].FileData, out byte[] fileBytes))
        {
            string filename = files[0].Filename ?? "unknown";
            reply = $"Received file '{filename}' ({fileBytes.Length} bytes inline).";
        }
        else
        {
            reply = "No inline file data found in the input.";
        }

        foreach (var evt in stream.OutputItemMessage(reply))
            yield return evt;

        yield return stream.EmitCompleted();
    }
}
```

## Handle file URL input

Clients can also send a URL pointing to the file. The handler can fetch the file content from the URL or simply record the reference:

```C# Snippet:Responses_Sample14_FileUrlHandler
public class FileUrlHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var items = await context.GetInputItemsAsync(cancellationToken: cancellationToken);

        var files = items
            .OfType<ItemMessage>()
            .SelectMany(msg => msg.GetContentExpanded())
            .OfType<MessageContentInputFileContent>()
            .ToList();

        string reply;
        if (files.Count > 0 && files[0].FileUrl != null)
        {
            string filename = files[0].Filename ?? "unknown";
            reply = $"Received file '{filename}' via URL: {files[0].FileUrl}";
        }
        else
        {
            reply = "No file URL found in the input.";
        }

        foreach (var evt in stream.OutputItemMessage(reply))
            yield return evt;

        yield return stream.EmitCompleted();
    }
}
```

## Handle file ID input

Clients can reference a file already stored in a file store by passing a `file_id`. The ID is an opaque string — a file path, blob key, database record, or any identifier your store uses:

```C# Snippet:Responses_Sample14_FileIdHandler
public class FileIdHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var items = await context.GetInputItemsAsync(cancellationToken: cancellationToken);

        var files = items
            .OfType<ItemMessage>()
            .SelectMany(msg => msg.GetContentExpanded())
            .OfType<MessageContentInputFileContent>()
            .ToList();

        string reply;
        if (files.Count > 0 && files[0].FileId != null)
        {
            string filename = files[0].Filename ?? "unknown";
            reply = $"Received file '{filename}' with ID: {files[0].FileId}";
        }
        else
        {
            reply = "No file ID found in the input.";
        }

        foreach (var evt in stream.OutputItemMessage(reply))
            yield return evt;

        yield return stream.EmitCompleted();
    }
}
```

## Start the server

```C# Snippet:Responses_Sample14_StartFileHandler
ResponsesServer.Run<FileBase64Handler>();
```

## Test the endpoint

### Send a file inline (base64)

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{
    "model": "file-processor",
    "input": [
      {
        "type": "message",
        "role": "user",
        "content": [
          {"type": "input_text", "text": "Summarize this document"},
          {
            "type": "input_file",
            "filename": "notes.txt",
            "file_data": "data:text/plain;base64,SGVsbG8gV29ybGQ="
          }
        ]
      }
    ]
  }' \
  --no-buffer
```

### Send a file by URL

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{
    "model": "file-processor",
    "input": [
      {
        "type": "message",
        "role": "user",
        "content": [
          {"type": "input_text", "text": "Analyze this CSV"},
          {
            "type": "input_file",
            "filename": "data.csv",
            "file_url": "https://example.com/data.csv"
          }
        ]
      }
    ]
  }' \
  --no-buffer
```

### Send a file by ID

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{
    "model": "file-processor",
    "input": [
      {
        "type": "message",
        "role": "user",
        "content": [
          {"type": "input_text", "text": "Review this report"},
          {
            "type": "input_file",
            "filename": "report.pdf",
            "file_id": "/uploads/report.pdf"
          }
        ]
      }
    ]
  }' \
  --no-buffer
```

> **Tip**: The `filename` field is optional but recommended — it helps the handler determine the file type. For inline data, use the standard data URL format: `data:<mime-type>;base64,<base64-encoded-content>`.
