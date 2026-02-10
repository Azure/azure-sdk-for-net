## Autorest openapi-to-typespec Plugin Configuration

Autorest extension to scaffold a new TypeSpec definition from an existing OpenApi document.

To run it

```bash
autorest --openapi-to-typespec --input-file=<path-to-swagger> --namespace=<namespace> --title="<ProjectName>" --use=@autorest/openapi-to-typespec@next --output-folder=.
```

or with a README config file

```bash
autorest --openapi-to-typespec --require=<path-to-readme-config>.md --use=@autorest/openapi-to-typespec@next --output-folder=.
```

This plugin will generate the following files

main.tsp - Entry point of the TypeSpec project, it contains service information
models.tsp - Contains all the model definitions
routes.tsp - Contains all the resource endpoints
tsproject.yaml - Contains configuration for the TypeSpec compiler
package.json - Configuration of the TypeSpec project

```yaml
version: 3.10.1
use-extension:
  "@autorest/modelerfour": "^4.27.0"

include-x-ms-examples-original-file: true

modelerfour:
  # this runs a pre-namer step to clean up names
  prenamer: false

openapi-to-typespec-scope/emitter:
  input-artifact: openapi-to-typespec-files

output-artifact: openapi-to-typespec-files

pipeline:
  source-swagger-detector:
    input: openapi-document/multi-api/identity
  openapi-to-typespec: # <- name of plugin
    input:
      - modelerfour/identity
      - source-swagger-detector
    output-artifact: openapi-to-typespec-files

  openapi-to-typespec/emitter:
    input: openapi-to-typespec
    scope: openapi-to-typespec-scope/emitter
```
