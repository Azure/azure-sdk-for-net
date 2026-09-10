# Sample 15: Annotations — file references and citations

This sample shows how to attach annotations to a message output item. Annotations let the handler return metadata alongside the text — file references, citations, or links — that clients can render as download buttons, footnotes, or hyperlinks.

The protocol supports several annotation types, and they can be mixed freely on the same message:

- **`file_path`** — references a file by ID. The `file_id` is an opaque string that your client and server agree on — a file path, a blob storage key, a database record ID, or any format your file store uses. Use this when the handler produces files (reports, images, data exports) and the client needs to retrieve them.
- **`file_citation`** — cites a file stored in a file store of your choice. Carries a `file_id`, `filename`, and positional `index`.
- **`url_citation`** — cites a web URL referenced in the text. Carries `url`, `title`, and character range (`start_index` / `end_index`) so the client can highlight the cited span.
- For use cases that involve creating or modifying files on a file system, consider using the **`apply_patch_call`** tool output item instead.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

Use the `OutputItemMessage(text, annotations)` convenience method to emit a message with annotations in one call. Each `FilePath` annotation takes a `fileId` (a file path or any identifier your file store uses) and an `index`:

```C# Snippet:Responses_Sample15_FileAnnotationsHandler
public class FileAnnotationsHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Mix different annotation types on the same message.
        // file_path — references a file by ID in your own store.
        // file_citation — cites a file stored in your own file store.
        // url_citation — cites a web URL referenced in the text.
        var annotations = new Annotation[]
        {
            new FilePath(fileId: "/reports/monthly-summary.pdf", index: 0),
            new FilePath(fileId: "/exports/data.csv", index: 1),
            new FilePath(fileId: "/images/chart.png", index: 2),
            new FileCitationBody(fileId: "/sources/research-paper.pdf", index: 3, filename: "research-paper.pdf"),
            new UrlCitationBody(url: new Uri("https://example.com/docs/guide"), startIndex: 0, endIndex: 29, title: "Developer Guide"),
        };

        // Emit a message with the annotations attached to the text content.
        foreach (var evt in stream.OutputItemMessage(
            "Here are your files and sources.",
            annotations))
        {
            yield return evt;
        }

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }
}
```

## Run the server

```C# Snippet:Responses_Sample15_StartServer
ResponsesServer.Run<FileAnnotationsHandler>();
```

## Test the endpoint

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "test", "input": "Generate the monthly reports"}' \
  --no-buffer
```

The response body contains a message output item with annotations in the `content[0].annotations` array. When streaming (`"stream": true`), each annotation is also delivered as a separate `response.output_text.annotation.added` SSE event:

```json
{
  "type": "message",
  "content": [
    {
      "type": "output_text",
      "text": "Here are your files and sources.",
      "annotations": [
        { "type": "file_path", "file_id": "/reports/monthly-summary.pdf", "index": 0 },
        { "type": "file_path", "file_id": "/exports/data.csv", "index": 1 },
        { "type": "file_path", "file_id": "/images/chart.png", "index": 2 },
        { "type": "file_citation", "file_id": "/sources/research-paper.pdf", "index": 3, "filename": "research-paper.pdf" },
        { "type": "url_citation", "url": "https://example.com/docs/guide", "start_index": 0, "end_index": 29, "title": "Developer Guide" }
      ]
    }
  ]
}
```
