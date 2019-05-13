# Queue Storage
> see https://aka.ms/autorest

## Configuration
``` yaml

# Prevent swagger validation because it complains about vendor extensions
# instead of ignoring them per the spec
pipeline:
  swagger-document/individual/schema-validator:
     scope: unused

# Generate queue storage
input-file: ./queue.json
output-folder: ../../Azure.Storage.Queues/src
clear-output-folder: false

# Use the Azure C# Track 2 generator
# use: C:\src\Storage\Swagger\Generator
# We can't use relative paths here, so use a relative path in generate.ps1
azure-track2-csharp: true

```
