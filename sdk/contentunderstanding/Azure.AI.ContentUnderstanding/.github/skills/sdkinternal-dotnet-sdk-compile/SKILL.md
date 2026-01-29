---
name: sdkinternal-dotnet-sdk-compile
description: Compile Azure SDK source code. This skill helps you build SDK modules locally, verify compilation before testing, and resolve dependency issues. Supports dotnet (C#), Maven (Java), pip (Python), npm (JavaScript).
---

# SDK Compile

This skill compiles Azure SDK source code for local development and testing.

## 🎯 What This Skill Does

1. Detects the SDK language and build system
2. Compiles source code with appropriate flags
3. Reports compilation errors with context

## 📋 Pre-requisites

- [ ] SDK source code checked out
- [ ] .NET SDK installed (6.0+)
- [ ] Dependencies restored

## 🔧 Usage

### PowerShell (Windows)

```powershell
# Navigate to SDK module
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Build
.github\skills\sdk-compile\scripts\compile.ps1
```

### Bash (Linux/macOS)

```bash
# Navigate to SDK module
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Build
.github/skills/sdk-compile/scripts/compile.sh
```

## 📦 .NET-Specific Notes

### Build Single Project

```powershell
# Build main library
dotnet build src\Azure.AI.ContentUnderstanding.csproj

# Build test project
dotnet build tests\Azure.AI.ContentUnderstanding.Tests.csproj
```

### Build with Specific Configuration

```powershell
# Debug build (default)
dotnet build -c Debug

# Release build
dotnet build -c Release
```

### Common Build Issues

1. **Missing dependencies**: Run `dotnet restore` first
2. **Framework mismatch**: Check `TargetFrameworks` in `.csproj`
3. **Analyzer warnings**: Fix code issues or adjust severity in `.editorconfig`

## 🌐 Cross-Language Commands

| Language | Compile Command | Notes |
|----------|----------------|-------|
| .NET | `dotnet build` | Requires .NET SDK |
| Java | `mvn compile` | Requires JDK 8+ |
| Python | `pip install -e .` | Creates editable install |
| JavaScript | `npm run build` | Check package.json for script |
