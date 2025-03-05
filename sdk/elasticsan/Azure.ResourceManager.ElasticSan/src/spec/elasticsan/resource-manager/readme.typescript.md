## TypeScript

These settings apply only when `--typescript` is specified on the command line.
Please also specify `--typescript-sdks-folder=<path to root folder of your azure-sdk-for-js clone>`.

``` yaml
modelerfour:
  flatten-models: false
```

```yaml $(typescript)
typescript:
  azure-arm: true
  package-name: "@azure/arm-elasticsan"
  output-folder: "$(typescript-sdks-folder)/sdk/elasticsans/arm-elasticsan"
  payload-flattening-threshold: 1
  generate-metadata: true
```
