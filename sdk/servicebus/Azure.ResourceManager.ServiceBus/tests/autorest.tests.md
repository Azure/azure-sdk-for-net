# Generate test code configuration

Run `dotnet build /t:GenerateTest` to generate test code.

``` yaml
require:
  - ../src/autorest.md
output-folder: $(this-folder)/Generated
```
