# Azure Generator Agent

The Azure Generator Agent is a powerful tool for automated Azure SDK code generation and migration workflows with improved architecture and enhanced capabilities.


## Commands

### Generate
```bash
dotnet run -- generate <sdk-path>
```

### Migrate
```bash
dotnet run -- migrate <sdk-path>
```

## Configuration

Configuration is managed through `appsettings.json` and supports:
- Logging levels and output targets
- Workflow settings (max retries, verbose mode)
- Environment-specific overrides

## Getting Started

1. Restore packages: `dotnet restore`
2. Build: `dotnet build`
3. Run: `dotnet run -- generate <your-sdk-path>`