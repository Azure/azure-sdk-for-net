# Read analysis diagnostics

> **Supported service API version:** `2026-06-01-preview`

Content Understanding analysis results can include diagnostic information in
`AnalysisResult.Infos`. Diagnostics are represented as `ResponseError` values
with a code and a human-readable message.

Diagnostic messages are intended for troubleshooting and can change as the
service evolves. Applications should not parse the message as structured
telemetry.

## Analyze an invoice and read diagnostics

The following example analyzes an invoice with the `prebuilt-invoice` analyzer,
then inspects the `Infos` collection on the completed result:

```C# Snippet:ContentUnderstandingReadAnalysisDiagnostics
Uri invoiceUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-dotnet/main/ContentUnderstanding.Common/data/invoice.pdf");

Operation<AnalysisResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-invoice",
    inputs: new[] { new AnalysisInput { Uri = invoiceUrl } });

AnalysisResult result = operation.Value;

// After a completed analysis, diagnostic information is available on the result.
// Treat diagnostic messages as human-readable text. Use OpenTelemetry when you
// need structured telemetry for monitoring or automation.
foreach (ResponseError info in result.Infos)
{
    Console.WriteLine($"{info.Code}: {info.Message}");
}
```

Example output from the preview service:

```text
LLMStats: completion calls: 2; embedding calls: 1; avg completion latency: 5.75s; total completion latency: 11.50s; avg embedding latency: 0.94s; total embedding latency: 0.94s
```

The service currently uses the `LLMStats` code for information about completion
and embedding calls. Consumers should handle unknown codes because additional
diagnostic codes may be introduced later.
