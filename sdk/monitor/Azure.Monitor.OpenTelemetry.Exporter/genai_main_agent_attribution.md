# GenAI Main Agent Attribution

## Owner

<!-- TODO: Add owner -->

## Approvers

* Rajkumar Rangaraj
* Jackson Weber
* Radhika Gupta

## Status

Experimental

## Purpose

Specifies how Azure Monitor Distros (Python, .NET, Java, Node.js) detect the top-level ("main") agent in a GenAI multi-agent system and propagate main-agent context so that all emitted telemetry (traces, metrics, logs) is attributed to the user-facing agent rather than to internal implementation agents.

## Specification

### Span Attribution

The distro MUST register a SpanProcessor in the TracerProvider pipeline before any export processor (e.g., BatchSpanProcessor).

In [OnStart(span, parentContext)][1], the processor MUST:

1. Extract the Span from `parentContext` to obtain the parent span. If there is no parent span, return.

2. For each row in the table below, read the **primary source** attribute from the parent span. If it exists, copy it onto `span` as the target attribute. Otherwise, read the **fallback source** attribute from the parent span and, if it exists, copy it onto `span` as the target attribute.

   | Target attribute (on `span`) | Primary source (on parent span) | Fallback source (on parent span) |
   | :--- | :--- | :--- |
   | `microsoft.gen_ai.main_agent.name` | `microsoft.gen_ai.main_agent.name` | `gen_ai.agent.name` |
   | `microsoft.gen_ai.main_agent.id` | `microsoft.gen_ai.main_agent.id` | `gen_ai.agent.id` |
   | `microsoft.gen_ai.main_agent.version` | `microsoft.gen_ai.main_agent.version` | `gen_ai.agent.version` |
   | `microsoft.gen_ai.main_agent.conversation_id` | `microsoft.gen_ai.main_agent.conversation_id` | `gen_ai.conversation.id` |

In [OnEnd(span)][7], the processor MUST:

1. If `span` does not have `gen_ai.operation.name` = `invoke_agent`, return.

2. If `span` already has any `microsoft.gen_ai.main_agent.*` attribute, return.

3. For each row in the table below, read the source attribute from `span` and, if it exists, copy it onto `span` as the target attribute.

   | Target attribute | Source attribute |
   | :--- | :--- |
   | `microsoft.gen_ai.main_agent.name` | `gen_ai.agent.name` |
   | `microsoft.gen_ai.main_agent.id` | `gen_ai.agent.id` |
   | `microsoft.gen_ai.main_agent.version` | `gen_ai.agent.version` |
   | `microsoft.gen_ai.main_agent.conversation_id` | `gen_ai.conversation.id` |

### Log Attribution

The distro MUST register a LogRecordProcessor in the LoggerProvider pipeline before any export processor (e.g., BatchLogRecordProcessor).

In [OnEmit(logRecord, context)][2], the processor MUST:

1. Extract the Span from `context` to obtain the current span. If there is no current span, return.

2. If the current span has any `microsoft.gen_ai.main_agent.*` attributes, copy all of them onto the `logRecord`.

### Metric Attribution

The OTel Metrics SDK does not define a per-measurement processor hook ([issue][3], [PR][4]).

**Java**: The Java SDK includes an internal [`View.AttributesProcessor`][5] that accepts `(Attributes, Context)` and can modify measurement attributes. The distro could use this to extract the active span from `Context` and copy `microsoft.gen_ai.main_agent.*` attributes onto measurements.

**Python, .NET, Node.js**: I don't believe an equivalent internal hook exists.

[1]: https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/sdk.md#onstart "SpanProcessor OnStart"
[2]: https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/logs/sdk.md#onemit "LogRecordProcessor OnEmit"
[3]: https://github.com/open-telemetry/opentelemetry-specification/issues/4298 "Support measurement processors in Metrics SDK"
[4]: https://github.com/open-telemetry/opentelemetry-specification/pull/4318 "Add MeasurementProcessor to Metrics SDK (closed)"
[5]: https://github.com/open-telemetry/opentelemetry-java/blob/main/sdk/metrics/src/main/java/io/opentelemetry/sdk/metrics/internal/view/AttributesProcessor.java "Java AttributesProcessor (internal API)"
[7]: https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/sdk.md#onend "SpanProcessor OnEnd"
