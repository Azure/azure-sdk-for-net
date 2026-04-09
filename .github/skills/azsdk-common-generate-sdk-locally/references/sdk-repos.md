# SDK Repository Details

## Language Repository Mapping

| Language   | Repository             |
| ---------- | ---------------------- |
| .NET       | `azure-sdk-for-net`    |
| Java       | `azure-sdk-for-java`   |
| JavaScript | `azure-sdk-for-js`     |
| Python     | `azure-sdk-for-python` |
| Go         | `azure-sdk-for-go`     |

## Configuration File Paths

- **From azure-rest-api-specs repo:** Use path to `tspconfig.yaml`
- **From SDK language repo:** Use path to `tsp-location.yaml`

## Build Failure Resolution

If build fails:

- Run `azure-sdk-mcp:azsdk_customized_code_update` — it handles classification, TypeSpec fixes, regeneration, and build internally
- See [customization workflow](customization-workflow.md) for full details
