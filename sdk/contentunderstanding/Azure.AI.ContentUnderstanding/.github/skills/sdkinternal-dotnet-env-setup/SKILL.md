---
name: sdkinternal-dotnet-env-setup
description: Load environment variables from .env file for Azure SDK development. This skill helps you find .env files, load environment variables into your shell session, and validate required variables for testing.
---

# SDK Environment Setup

This skill loads environment variables from `.env` files for Azure SDK development and testing.

## 🎯 What This Skill Does

1. Locates `.env` files in your workspace
2. Loads environment variables into the current shell session
3. Validates required variables for SDK testing

## 📋 Pre-requisites

- [ ] `.env` file exists in the SDK module directory
- [ ] Required Azure credentials are configured

## 🔧 Usage

### PowerShell (Windows)

```powershell
# Navigate to SDK module directory
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Load environment variables  
. .github\skills\sdk-setup-env\scripts\load-env.ps1
```

### Bash (Linux/macOS)

```bash
# Navigate to SDK module directory
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Load environment variables
source .github/skills/sdk-setup-env/scripts/load-env.sh
```

## 📦 Required Environment Variables

### Content Understanding Service

| Variable | Description |
|----------|-------------|
| `CONTENTUNDERSTANDING_ENDPOINT` | Service endpoint URL |
| `AZURE_TEST_MODE` | Test mode: `Playback`, `Record`, or `Live` |

### Optional Variables

| Variable | Description |
|----------|-------------|
| `GPT_4_1_DEPLOYMENT` | GPT-4.1 model deployment name |
| `GPT_4_1_MINI_DEPLOYMENT` | GPT-4.1-mini model deployment name |
| `TEXT_EMBEDDING_3_LARGE_DEPLOYMENT` | Text embedding model deployment name |
| `AZURE_TEST_USE_CLI_AUTH` | Use Azure CLI authentication |

## ⚠️ Security Notes

- Never commit `.env` files to version control
- Ensure `.gitignore` includes `.env`
- Use Azure Key Vault for production secrets

## 🌐 Cross-Language Support

| Language | Script | Notes |
|----------|--------|-------|
| .NET | `load-env.ps1` / `load-env.sh` | Primary scripts |
| Java | `load-env.sh` | Export vars before Maven |
| Python | `load-env.sh` | python-dotenv also works |
| JavaScript | `load-env.sh` | dotenv package alternative |
