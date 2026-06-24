# Language-Specific Fixer Notes

Use these to locate the package and understand what `azsdk_package_run_check`
covers per language. The MCP package tools wrap the real CI build/check/test
steps, so the table is for orientation — always verify through the tools, never
by running these raw commands yourself.

| Language   | Package path pattern             | Build step    | Check covers                 |
| ---------- | -------------------------------- | ------------- | ---------------------------- |
| Python     | `sdk/{service}/{package-name}`   | pip/setuptools| mypy, pyright, pylint, black |
| .NET       | `sdk/{service}/{Package.Name}`   | dotnet build  | dotnet format, API compat    |
| Java       | `sdk/{service}/{package-name}`   | mvn compile   | checkstyle, spotbugs         |
| JavaScript | `sdk/{service}/{package-name}`   | rush build    | eslint, tsc                  |
| Go         | `sdk/{service}/{package-name}`   | go build      | go vet, gofmt                |

## What this skill cannot fix

- **Recording / playback failures** — need Azure credentials and live service
  access to re-record; report that re-recording is required.
- **Infrastructure / transient failures** — network, throttling, agent crashes;
  recommend retrying the pipeline.
- **Breaking API changes** — require a design decision; escalate to a human.

## Common fixes

| Failure              | Fix                                                  |
| -------------------- | ---------------------------------------------------- |
| Type error           | Correct the type annotation or cast at the cited line|
| Missing import       | Add the import statement                             |
| Assertion failure    | Fix the underlying logic bug, not the assertion      |
| Lint / format        | Apply the formatter the check tool reports           |
