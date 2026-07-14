// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.Core;
using Azure.Identity;

/// <summary>
/// DEMO_MODE-only diagnostic: capture a full, untruncated HTTP trace of the
/// resilient-task create (<c>POST {endpoint}/tasks</c>) with an oversized attachment,
/// from INSIDE the hosted container (where the hosted-agent managed-identity credential
/// is valid).
///
/// External callers get HTTP 403 <c>hosted_agent_required</c> for task writes, so the
/// real <c>500</c> the service returns for an oversized attachment can only be observed
/// in-container. This issues a raw <c>POST /tasks</c> whose body is constructed to match
/// the <c>Azure.AI.AgentServer.Core</c> hosted task-store wire contract (the Core store
/// types are <c>internal</c>, so we reproduce the documented wire shape rather than route
/// through the internal client), dumping the request line/headers/full body and the full
/// response status/headers/body. Only the bearer token VALUE is redacted.
/// </summary>
internal static class TaskTrace
{
    // The scope the hosted-agent credential uses for task-store writes (same resource the
    // battery requests via `az account get-access-token --resource https://ai.azure.com`).
    private const string TokenScope = "https://ai.azure.com/.default";
    private const string FoundryFeaturesHeader = "Foundry-Features";
    private const string FoundryFeaturesValue = "Routines=V1Preview";

    public static async Task<string> CaptureOversizedTaskTraceAsync(
        string projectEndpoint,
        string agentName,
        CancellationToken cancellationToken,
        int attachBytes = 300 * 1024)
    {
        const int controlBytes = 1024; // 1 KB inline control
        var sections = new List<string>();

        var (controlRec, controlErr) =
            await CaptureOneAsync(projectEndpoint, agentName, controlBytes, useAttachment: false, cancellationToken);
        sections.Add("##### CONTROL — SMALL INLINE INPUT, NO ATTACHMENT (expected to SUCCEED) #####");
        sections.Add(controlRec is not null
            ? Format(controlRec, controlBytes, "(inline, no attachment)")
            : $"NO HTTP RECORD CAPTURED. SDK error: {controlErr}");
        if (controlErr is not null)
            sections.Add($"SDK raised (control): {controlErr}");

        var (overRec, overErr) =
            await CaptureOneAsync(projectEndpoint, agentName, attachBytes, useAttachment: true, cancellationToken);
        sections.Add("");
        sections.Add("##### OVERSIZED INPUT SPILLED TO ATTACHMENT (the FAILING case) #####");
        sections.Add(overRec is not null
            ? Format(overRec, attachBytes, "_input")
            : $"NO HTTP RECORD CAPTURED. SDK error: {overErr}");
        if (overErr is not null)
            sections.Add($"SDK raised (oversized): {overErr}");

        var cs = controlRec?.Status.ToString() ?? "?";
        var os = overRec?.Status.ToString() ?? "?";
        var summary =
            "\n##### SUMMARY #####\n" +
            $"CONTROL  (inline payload, NO attachment, {controlBytes} bytes) -> POST /tasks {cs}\n" +
            $"OVERSIZED ({attachBytes}-byte input spilled to _input attachment)  -> POST /tasks {os}\n" +
            "The two requests are identical except the oversized one carries an `attachments` " +
            "field. The task-attachments SOT permits up to 2 MB per attachment. An oversized " +
            "500 wraps an upstream 403 from the task-store's attachment offload to the AzureML " +
            "dataset store (POST .../datasets/.../startPendingUpload -> 403 Forbidden) — a " +
            "service-side permission/config issue on attachment handling, not an SDK bug.\n";

        return string.Join("\n", sections) + "\n" + summary;
    }

    private sealed record TraceRecord(
        string Method,
        string Url,
        IDictionary<string, string> RequestHeaders,
        byte[] RequestBody,
        int Status,
        string Reason,
        IDictionary<string, string> ResponseHeaders,
        byte[] ResponseBody);

    private static async Task<(TraceRecord? Record, string? Error)> CaptureOneAsync(
        string projectEndpoint,
        string agentName,
        int attachBytes,
        bool useAttachment,
        CancellationToken cancellationToken)
    {
        try
        {
            var url = $"{projectEndpoint.TrimEnd('/')}/tasks";
            var body = BuildTaskCreateBody(agentName, attachBytes, useAttachment);
            var bodyBytes = Encoding.UTF8.GetBytes(body);

            var credential = new DefaultAzureCredential();
            var token = await credential.GetTokenAsync(
                new TokenRequestContext(new[] { TokenScope }), cancellationToken);

            using var http = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new ByteArrayContent(bodyBytes),
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            request.Headers.TryAddWithoutValidation(FoundryFeaturesHeader, FoundryFeaturesValue);

            var reqHeaders = CollectHeaders(request.Headers, request.Content?.Headers);

            using var response = await http.SendAsync(request, cancellationToken);
            var respBody = await response.Content.ReadAsByteArrayAsync(cancellationToken);
            var respHeaders = CollectHeaders(response.Headers, response.Content?.Headers);

            var record = new TraceRecord(
                Method: "POST",
                Url: url,
                RequestHeaders: reqHeaders,
                RequestBody: bodyBytes,
                Status: (int)response.StatusCode,
                Reason: response.ReasonPhrase ?? "",
                ResponseHeaders: respHeaders,
                ResponseBody: respBody);
            return (record, null);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString());
        }
    }

    private static string BuildTaskCreateBody(string agentName, int attachBytes, bool useAttachment)
    {
        const string pad = "A long research input. ";
        var sb = new StringBuilder(attachBytes + pad.Length);
        while (sb.Length < attachBytes)
            sb.Append(pad);
        var blob = sb.ToString(0, attachBytes);

        var sessionId = $"task-trace-{Guid.NewGuid():N}";
        var nowIso = DateTimeOffset.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        var expiresIso = DateTimeOffset.UtcNow.AddSeconds(60).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

        var payload = new JsonObject
        {
            ["metadata"] = new JsonObject(),
            ["turn_started_at"] = nowIso,
            ["schema_version"] = "1",
        };

        JsonObject? attachments = null;
        if (useAttachment)
        {
            var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(blob))).ToLowerInvariant();
            payload["input"] = new JsonObject
            {
                ["__attachment_ref__"] = new JsonObject { ["key"] = "_input", ["hash"] = hash },
            };
            attachments = new JsonObject { ["_input"] = blob };
        }
        else
        {
            payload["input"] = blob;
        }

        var root = new JsonObject
        {
            ["object"] = "task",
            ["id"] = $"resilient-resp-{Guid.NewGuid():N}",
            ["agent_name"] = agentName,
            ["session_id"] = sessionId,
            ["status"] = "in_progress",
            ["title"] = "resilient-response oversized task-trace diagnostic",
            ["payload"] = payload,
            ["source"] = new JsonObject
            {
                ["type"] = "agentserver.task",
                ["name"] = "handler",
                ["server_version"] = "Azure.AI.AgentServer.Core/1.0.0-beta.27",
            },
            ["tags"] = new JsonObject { ["_task_name"] = "handler" },
            ["lease"] = new JsonObject
            {
                ["owner"] = $"{agentName}|session:{sessionId}",
                ["instance_id"] = $"trace-{Guid.NewGuid():N}"[..18],
                ["expires_at"] = expiresIso,
            },
        };
        if (attachments is not null)
            root["attachments"] = attachments;

        return root.ToJsonString(new JsonSerializerOptions { WriteIndented = false });
    }

    private static Dictionary<string, string> CollectHeaders(
        HttpHeaders headers, HttpHeaders? contentHeaders)
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var (name, value) in Enumerate(headers))
            result[name] = Redact(name, value);
        if (contentHeaders is not null)
            foreach (var (name, value) in Enumerate(contentHeaders))
                result[name] = Redact(name, value);
        return result;
    }

    private static IEnumerable<(string Name, string Value)> Enumerate(HttpHeaders headers)
    {
        foreach (var kvp in headers)
            yield return (kvp.Key, string.Join(", ", kvp.Value));
    }

    private static string Redact(string name, string value)
    {
        if (string.Equals(name, "Authorization", StringComparison.OrdinalIgnoreCase))
        {
            var scheme = value.Contains(' ') ? value.Split(' ', 2)[0] : "Bearer";
            return $"{scheme} <REDACTED — live hosted-agent bearer token>";
        }
        return value;
    }

    private static string Format(TraceRecord rec, int attachBytes, string attachKey)
    {
        var rb = rec.RequestBody;
        var sb = rec.ResponseBody;
        var lines = new List<string>
        {
            new string('=', 100),
            "RAW HTTP TRACE — resilient-task create (POST /tasks) with oversized attachment",
            $"captured IN-CONTAINER (hosted-agent credential) at {DateTimeOffset.UtcNow:O}",
            $"attachment: key='{attachKey}' value_size={attachBytes} bytes " +
                "(task-attachments SOT limit: 2 MB/attachment — this is well under it)",
            new string('=', 100),
            "",
            "################  REQUEST  ################",
            $"{rec.Method} {rec.Url}",
            "",
            "--- request headers ---",
        };
        lines.AddRange(rec.RequestHeaders.Select(kv => $"{kv.Key}: {kv.Value}"));
        lines.Add("");
        lines.Add($"--- request body ({rb.Length} bytes, UNTRUNCATED) ---");
        lines.Add(Encoding.UTF8.GetString(rb));
        lines.Add("");
        lines.Add("################  RESPONSE  ################");
        lines.Add($"HTTP {rec.Status} {rec.Reason}".TrimEnd());
        lines.Add("");
        lines.Add("--- response headers ---");
        lines.AddRange(rec.ResponseHeaders.Select(kv => $"{kv.Key}: {kv.Value}"));
        lines.Add("");
        lines.Add($"--- response body ({sb.Length} bytes, UNTRUNCATED) ---");
        lines.Add(sb.Length > 0 ? Encoding.UTF8.GetString(sb) : "<empty response body>");
        lines.Add(new string('=', 100));
        return string.Join("\n", lines);
    }
}
