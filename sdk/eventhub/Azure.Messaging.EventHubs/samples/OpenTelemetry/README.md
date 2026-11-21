# Export Event Hubs telemetry

This sample exports Event Hubs traces, native metrics, and structured AMQP lifecycle logs. It uses the library in this checkout so it includes the instrumentation under development. The sample requires the SDK specified by the repository's `global.json`.

Run from the repository root:

```sh
dotnet run --project sdk/eventhub/Azure.Messaging.EventHubs/samples/OpenTelemetry/Azure.Messaging.EventHubs.Samples.OpenTelemetry.csproj
```

The default mode attempts to send to local port zero, which cannot host a service. It catches the expected connection failure and exports real SDK telemetry to the console without Azure credentials. Expect one failed logical send, no accepted events, and failed connection and sender creation attempts. The sample flushes providers even when an operation fails.

To exercise the same SDK operation without any tracer provider, meter provider, log bridge, or exporter:

```sh
dotnet run --project sdk/eventhub/Azure.Messaging.EventHubs/samples/OpenTelemetry/Azure.Messaging.EventHubs.Samples.OpenTelemetry.csproj -- --no-providers
```

## Export to a collector

Start an OpenTelemetry Collector with the supplied configuration:

```sh
docker run --rm --name eventhubs-dotnet-otel -p 14318:4318 \
  -v "$PWD/sdk/eventhub/Azure.Messaging.EventHubs/samples/OpenTelemetry/collector.yaml:/etc/otelcol/config.yaml:ro" \
  otel/opentelemetry-collector:0.109.0
```

Then export all three signals using OTLP/HTTP:

```sh
OTEL_EXPORTER_OTLP_ENDPOINT=http://localhost:14318 \
  dotnet run --project sdk/eventhub/Azure.Messaging.EventHubs/samples/OpenTelemetry/Azure.Messaging.EventHubs.Samples.OpenTelemetry.csproj -- --otlp
```

For a live send, set `EVENTHUBS_CONNECTION_STRING` to an Event Hubs connection string that includes `EntityPath` and has permission to send. Add `--live` to either command. Keep credentials outside source control.

## Application configuration

- Set `AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true)` before creating clients, and subscribe to `Azure.Messaging.EventHubs.*` on the tracer provider.
- Subscribe to `Azure.Messaging.EventHubs` on the meter provider. Metrics work independently of the tracing switch. The sample configures histogram boundaries suitable for durations measured in seconds.
- Bridge the `AmqpLifecycle` EventSource record into application logging. This record contains structured identifiers and outcomes. Other existing diagnostic records can include broker descriptions; review them before forwarding them externally.
- Keep providers alive for the client lifetime. Flush or dispose them during shutdown, including after failures. Exporters belong to the application, not the Event Hubs client.

Buffered duration metrics include preparation and retries, excluding queue time, batch-fill waits, and callbacks. Buffered spans have real start and end timestamps and can therefore include batch-fill waits. Existing producer spans remain children of buffered worker spans. Counters represent logical operations, not retry attempts. Event counts represent accepted sends and successful receives; they do not guarantee exactly-once delivery.
