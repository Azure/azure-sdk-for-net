# OpenTelemetry Exporter Benchmarks

Use the following example to run Benchmarks from command line:
(change parameters as necessary)

Navigate to `./sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Benchmarks`
directory and run the following command:

```sh
dotnet run --configuration Release --framework net6.0
```

To run specific Benchmarks use filter attribute :

```sh
dotnet run --configuration Release --framework net6.0 --filter *TagObjectsBenchmarks*
```
