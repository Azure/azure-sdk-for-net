# SDK Repository Details

## Language Repository Mapping

| Language   | Repository             |
| ---------- | ---------------------- |
| .NET       | `azure-sdk-for-net`    |
| Java       | `azure-sdk-for-java`   |
| JavaScript | `azure-sdk-for-js`     |
| Python     | `azure-sdk-for-python` |
| Go         | `azure-sdk-for-go`     |
| Rust       | `azure-sdk-for-rust`   |

## Configuration File Paths

- **From azure-rest-api-specs repo:** Use path to `tspconfig.yaml`
- **From SDK language repo:** Use path to `tsp-location.yaml`

## MCP Tools

| Tool | Purpose |
|------|---------|
| `azure-sdk-mcp:azsdk_verify_setup` | Verify local environment for selected language |
| `azure-sdk-mcp:azsdk_package_generate_code` | Generate SDK from TypeSpec |
| `azure-sdk-mcp:azsdk_package_build_code` | Build package |
| `azure-sdk-mcp:azsdk_package_run_check` | Validate package |
| `azure-sdk-mcp:azsdk_package_run_tests` | Run tests |
| `azure-sdk-mcp:azsdk_customized_code_update` | Apply TypeSpec and code customizations to resolve build errors, breaking changes, or SDK modification requests (includes regeneration and build internally) |
| `azure-sdk-mcp:azsdk_package_update_changelog_content` | Update changelog |
| `azure-sdk-mcp:azsdk_package_update_metadata` | Update package metadata including ci.yml |
| `azure-sdk-mcp:azsdk_package_update_version` | Update package version |

## Build Failure Resolution

If build fails:

- Run `azure-sdk-mcp:azsdk_customized_code_update` — it handles classification, TypeSpec fixes, regeneration, and build internally
- See [customization workflow](customization-workflow.md) for full details
