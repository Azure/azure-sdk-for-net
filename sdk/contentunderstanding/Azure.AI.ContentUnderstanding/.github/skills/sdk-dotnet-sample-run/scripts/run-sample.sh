#!/bin/bash
# Run a specific .NET SDK sample for Azure AI Content Understanding
# This script extracts code from sample markdown files, builds a console project, and runs it.
#
# Usage: ./run-sample.sh <SampleName> [options]
# Example: ./run-sample.sh Sample02_AnalyzeUrl
#          ./run-sample.sh Sample01_AnalyzeBinary --file /path/to/document.pdf
#          ./run-sample.sh --list

set -e

# Determine script directory and package root
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PACKAGE_ROOT="$(cd "$SCRIPT_DIR/../../../.." && pwd)"
SAMPLES_DIR="$PACKAGE_ROOT/samples"
RUNNER_BASE="$PACKAGE_ROOT/.sample_runner"
APPSETTINGS="$PACKAGE_ROOT/appsettings.json"
LOCAL_SRC_DIR="$PACKAGE_ROOT/src"

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
CYAN='\033[0;36m'
NC='\033[0m' # No Color

print_info()    { echo -e "${BLUE}$1${NC}"; }
print_success() { echo -e "${GREEN}$1${NC}"; }
print_warning() { echo -e "${YELLOW}$1${NC}"; }
print_error()   { echo -e "${RED}$1${NC}"; }
print_cyan()    { echo -e "${CYAN}$1${NC}"; }

# ─── Ensure .NET SDK is available ─────────────────────────────────────────────
ensure_dotnet_sdk() {
    # Determine required .NET channels
    local required_channels=("10.0")

    # Check if repo's global.json requires a different version
    local repo_global="$PACKAGE_ROOT/../../../global.json"
    if [ -f "$repo_global" ] && command -v python3 &>/dev/null; then
        local major
        major=$(python3 -c "import json; d=json.load(open('$repo_global')); print(d.get('sdk',{}).get('version','').split('.')[0])" 2>/dev/null || echo "")
        if [ -n "$major" ] && [ "$major" -gt 10 ] 2>/dev/null; then
            required_channels+=("${major}.0")
        fi
    fi

    # Find dotnet
    if ! command -v dotnet &>/dev/null; then
        if [ -x "$HOME/.dotnet/dotnet" ]; then
            export PATH="$HOME/.dotnet:$PATH"
            export DOTNET_ROOT="$HOME/.dotnet"
        fi
    fi

    if command -v dotnet &>/dev/null; then
        print_info "dotnet found: $(command -v dotnet)"
        local installed_majors
        installed_majors=$(dotnet --list-sdks 2>/dev/null | awk -F'.' '{print $1}' | sort -u)
        local missing=()
        for ch in "${required_channels[@]}"; do
            local ch_major="${ch%%.*}"
            if ! echo "$installed_majors" | grep -qw "$ch_major"; then
                missing+=("$ch")
            fi
        done
        if [ ${#missing[@]} -eq 0 ]; then
            print_info "All required .NET SDKs are installed."
            return 0
        fi
    else
        local missing=("${required_channels[@]}")
    fi

    # Install missing SDKs
    local install_script="/tmp/dotnet-install.sh"
    if [ ! -f "$install_script" ]; then
        print_info "Downloading .NET install script..."
        curl -sSL https://dot.net/v1/dotnet-install.sh -o "$install_script"
        chmod +x "$install_script"
    fi

    for ch in "${missing[@]}"; do
        print_warning "Installing .NET $ch SDK..."
        bash "$install_script" --channel "$ch" || print_warning "Warning: Failed to install .NET $ch SDK"
    done

    export PATH="$HOME/.dotnet:$PATH"
    export DOTNET_ROOT="$HOME/.dotnet"
    print_success ".NET SDK setup complete."
}

ensure_dotnet_sdk

# ─── List available samples ───────────────────────────────────────────────────
list_samples() {
    echo ""
    print_info "=== Available Samples ==="
    for f in "$SAMPLES_DIR"/Sample*.md; do
        [ -f "$f" ] || continue
        name="$(basename "$f" .md)"
        # Extract first heading after the YAML front matter as description
        desc=$(head -5 "$f" | grep '^# ' | head -1 | sed 's/^# //')
        printf "  ${CYAN}%-30s${NC} %s\n" "$name" "$desc"
    done
    echo ""
}

# ─── Parse arguments ──────────────────────────────────────────────────────────
SAMPLE_NAME=""
LOCAL_FILE=""
RUN_AFTER_BUILD=false

while [[ $# -gt 0 ]]; do
    case $1 in
        --list|-l)
            list_samples
            exit 0
            ;;
        --run|-r)
            RUN_AFTER_BUILD=true
            shift
            ;;
        --file|-f)
            LOCAL_FILE="$2"
            shift 2
            ;;
        --help|-h)
            echo "Usage: $0 <SampleName> [options]"
            echo ""
            echo "Options:"
            echo "  --list, -l          List available samples"
            echo "  --run, -r           Run the sample after building (default: build only)"
            echo "  --file, -f <path>   Local file path (for samples that need a file)"
            echo "  --help, -h          Show this help"
            echo ""
            echo "Examples:"
            echo "  $0 Sample02_AnalyzeUrl"
            echo "  $0 Sample02_AnalyzeUrl --run"
            echo "  $0 Sample01_AnalyzeBinary --file /path/to/doc.pdf"
            echo "  $0 --list"
            exit 0
            ;;
        -*)
            print_error "Unknown option: $1"
            exit 1
            ;;
        *)
            SAMPLE_NAME="$1"
            shift
            ;;
    esac
done

if [ -z "$SAMPLE_NAME" ]; then
    print_error "Error: No sample name provided"
    echo ""
    echo "Usage: $0 <SampleName>"
    echo "Run '$0 --list' to see available samples"
    exit 1
fi

# Normalize: remove .md extension if present
SAMPLE_NAME="${SAMPLE_NAME%.md}"

# Locate the markdown file
SAMPLE_FILE="$SAMPLES_DIR/${SAMPLE_NAME}.md"
if [ ! -f "$SAMPLE_FILE" ]; then
    print_error "Error: Sample not found: $SAMPLE_FILE"
    echo ""
    echo "Did you mean one of these?"
    ls "$SAMPLES_DIR"/Sample*.md 2>/dev/null | xargs -n1 basename | sed 's/\.md$//' \
        | grep -i "${SAMPLE_NAME#Sample}" | head -5 || true
    echo ""
    echo "Run '$0 --list' to see all available samples"
    exit 1
fi

# ─── Read configuration ──────────────────────────────────────────────────────
ENDPOINT="${CONTENTUNDERSTANDING_ENDPOINT:-}"
API_KEY="${AZURE_CONTENT_UNDERSTANDING_KEY:-}"
TARGET_ENDPOINT="${CONTENTUNDERSTANDING_TARGET_ENDPOINT:-}"
TARGET_RESOURCE_ID="${AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID:-}"
SOURCE_ENDPOINT="${CONTENTUNDERSTANDING_SOURCE_ENDPOINT:-}"
SOURCE_RESOURCE_ID="${AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID:-}"
SOURCE_REGION="${AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION:-}"
TARGET_REGION="${AZURE_CONTENT_UNDERSTANDING_TARGET_REGION:-}"
GPT41_DEPLOYMENT="${GPT_4_1_DEPLOYMENT:-gpt-4.1}"
GPT41_MINI_DEPLOYMENT="${GPT_4_1_MINI_DEPLOYMENT:-gpt-4.1-mini}"
EMBEDDING_DEPLOYMENT="${TEXT_EMBEDDING_3_LARGE_DEPLOYMENT:-text-embedding-3-large}"

# Try loading from appsettings.json
if [ -f "$APPSETTINGS" ]; then
    print_info "Loading settings from appsettings.json..."
    if command -v python3 &>/dev/null; then
        ENDPOINT="${ENDPOINT:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('CONTENTUNDERSTANDING_ENDPOINT',''))" 2>/dev/null)}"
        API_KEY="${API_KEY:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('AZURE_CONTENT_UNDERSTANDING_KEY',''))" 2>/dev/null)}"
        TARGET_ENDPOINT="${TARGET_ENDPOINT:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('CONTENTUNDERSTANDING_TARGET_ENDPOINT',''))" 2>/dev/null)}"
        TARGET_RESOURCE_ID="${TARGET_RESOURCE_ID:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID',''))" 2>/dev/null)}"
        SOURCE_ENDPOINT="${SOURCE_ENDPOINT:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('CONTENTUNDERSTANDING_SOURCE_ENDPOINT',''))" 2>/dev/null)}"
        SOURCE_RESOURCE_ID="${SOURCE_RESOURCE_ID:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID',''))" 2>/dev/null)}"
        SOURCE_REGION="${SOURCE_REGION:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION',''))" 2>/dev/null)}"
        TARGET_REGION="${TARGET_REGION:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('AZURE_CONTENT_UNDERSTANDING_TARGET_REGION',''))" 2>/dev/null)}"
        GPT41_DEPLOYMENT="${GPT41_DEPLOYMENT:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('GPT_4_1_DEPLOYMENT','gpt-4.1'))" 2>/dev/null)}"
        GPT41_MINI_DEPLOYMENT="${GPT41_MINI_DEPLOYMENT:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('GPT_4_1_MINI_DEPLOYMENT','gpt-4.1-mini'))" 2>/dev/null)}"
        EMBEDDING_DEPLOYMENT="${EMBEDDING_DEPLOYMENT:-$(python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('TEXT_EMBEDDING_3_LARGE_DEPLOYMENT','text-embedding-3-large'))" 2>/dev/null)}"
    elif command -v jq &>/dev/null; then
        ENDPOINT="${ENDPOINT:-$(jq -r '.CONTENTUNDERSTANDING_ENDPOINT // empty' "$APPSETTINGS" 2>/dev/null)}"
        API_KEY="${API_KEY:-$(jq -r '.AZURE_CONTENT_UNDERSTANDING_KEY // empty' "$APPSETTINGS" 2>/dev/null)}"
        TARGET_ENDPOINT="${TARGET_ENDPOINT:-$(jq -r '.CONTENTUNDERSTANDING_TARGET_ENDPOINT // empty' "$APPSETTINGS" 2>/dev/null)}"
        TARGET_RESOURCE_ID="${TARGET_RESOURCE_ID:-$(jq -r '.AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID // empty' "$APPSETTINGS" 2>/dev/null)}"
        SOURCE_ENDPOINT="${SOURCE_ENDPOINT:-$(jq -r '.CONTENTUNDERSTANDING_SOURCE_ENDPOINT // empty' "$APPSETTINGS" 2>/dev/null)}"
        SOURCE_RESOURCE_ID="${SOURCE_RESOURCE_ID:-$(jq -r '.AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID // empty' "$APPSETTINGS" 2>/dev/null)}"
        SOURCE_REGION="${SOURCE_REGION:-$(jq -r '.AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION // empty' "$APPSETTINGS" 2>/dev/null)}"
        TARGET_REGION="${TARGET_REGION:-$(jq -r '.AZURE_CONTENT_UNDERSTANDING_TARGET_REGION // empty' "$APPSETTINGS" 2>/dev/null)}"
        GPT41_DEPLOYMENT="${GPT41_DEPLOYMENT:-$(jq -r '.GPT_4_1_DEPLOYMENT // "gpt-4.1"' "$APPSETTINGS" 2>/dev/null)}"
        GPT41_MINI_DEPLOYMENT="${GPT41_MINI_DEPLOYMENT:-$(jq -r '.GPT_4_1_MINI_DEPLOYMENT // "gpt-4.1-mini"' "$APPSETTINGS" 2>/dev/null)}"
        EMBEDDING_DEPLOYMENT="${EMBEDDING_DEPLOYMENT:-$(jq -r '.TEXT_EMBEDDING_3_LARGE_DEPLOYMENT // "text-embedding-3-large"' "$APPSETTINGS" 2>/dev/null)}"
    else
        print_warning "⚠ Neither python3 nor jq found. Cannot parse appsettings.json."
        print_warning "  Set environment variables instead: CONTENTUNDERSTANDING_ENDPOINT, AZURE_CONTENT_UNDERSTANDING_KEY"
    fi
elif [ -z "$ENDPOINT" ]; then
    echo ""
    print_cyan "=== First-time Setup ==="
    print_warning "No appsettings.json found and CONTENTUNDERSTANDING_ENDPOINT not set."
    print_warning "Let's create appsettings.json in: $PACKAGE_ROOT"
    echo ""

    read -rp "Enter your Content Understanding endpoint URL (e.g. https://your-foundry.services.ai.azure.com/): " INPUT_ENDPOINT
    if [ -z "$INPUT_ENDPOINT" ]; then
        print_error "Error: Endpoint is required."
        exit 1
    fi
    ENDPOINT="$INPUT_ENDPOINT"

    read -rp "Enter API key (leave blank to use DefaultAzureCredential - recommended): " INPUT_API_KEY
    API_KEY="$INPUT_API_KEY"

    # Write appsettings.json
    if [ -n "$API_KEY" ]; then
        cat > "$APPSETTINGS" << APPSETTINGSJSON
{
  "CONTENTUNDERSTANDING_ENDPOINT": "$ENDPOINT",
  "AZURE_CONTENT_UNDERSTANDING_KEY": "$API_KEY"
}
APPSETTINGSJSON
    else
        cat > "$APPSETTINGS" << APPSETTINGSJSON
{
  "CONTENTUNDERSTANDING_ENDPOINT": "$ENDPOINT"
}
APPSETTINGSJSON
    fi

    print_success "Created appsettings.json at: $APPSETTINGS"
fi

if [ -z "$ENDPOINT" ]; then
    print_error "Error: CONTENTUNDERSTANDING_ENDPOINT is not configured."
    print_error "Set it in appsettings.json or as an environment variable."
    exit 1
fi

print_info "Endpoint: $ENDPOINT"
if [ -n "$API_KEY" ]; then
    print_info "Auth: API Key"
else
    print_info "Auth: DefaultAzureCredential"
fi

# ─── Extract code snippets from markdown ──────────────────────────────────────
print_info "=== Extracting code from: $SAMPLE_NAME ==="

# Extract C# code blocks from the markdown.
# We look for ```C# Snippet:* or ```csharp blocks
CODE_BLOCKS=$(python3 -c "
import re, sys

with open('$SAMPLE_FILE', 'r') as f:
    content = f.read()

# Find all C# code blocks (both 'C# Snippet:*' and 'csharp' fenced blocks)
pattern = r'\`\`\`(?:C#\s+Snippet:\w+|csharp)\s*\n(.*?)\`\`\`'
blocks = re.findall(pattern, content, re.DOTALL)

# Deduplicate: the client creation snippets appear in every sample.
# We keep only the first occurrence of CreateContentUnderstandingClient
# and CreateContentUnderstandingClientApiKey
seen_client_default = False
seen_client_apikey = False
filtered = []
for block in blocks:
    is_default = '<endpoint>' in block and 'DefaultAzureCredential' in block and 'AzureKeyCredential' not in block
    is_apikey = '<apiKey>' in block and 'AzureKeyCredential' in block
    if is_default:
        if seen_client_default:
            continue
        seen_client_default = True
    if is_apikey:
        if seen_client_apikey:
            continue
        seen_client_apikey = True
        # Skip the API key variant — we handle auth in the wrapper
        continue
    filtered.append(block)

# Detect if scoping is needed by checking for duplicate variable declarations across snippets.
# When duplicates are found, use variable hoisting: pre-declare duplicated variables at the top
# and convert all their declarations to assignments. This matches the ps1 logic.
def get_declared_vars(block):
    import re as _re
    # Exclude C# 'using' statements from variable detection
    lines = [l for l in block.split('\n') if not l.strip().startswith('using ')]
    text = '\n'.join(lines)
    pat = r'\b(?:var|string|int|bool|byte\[\]|BinaryData|Uri|Operation<[^>]+>|AnalyzeResult|MediaContent|DocumentContent|AudioVisualContent|ContentUnderstandingClient|[A-Z]\w*)\s+(\w+)\s*='
    return _re.findall(pat, text)

def get_var_type(block, var_name):
    import re as _re
    lines = [l for l in block.split('\n') if not l.strip().startswith('using ')]
    text = '\n'.join(lines)
    pat = r'\b(var|string|int|bool|byte\[\]|BinaryData|Uri|Operation<[^>]+>|AnalyzeResult|MediaContent|DocumentContent|AudioVisualContent|ContentUnderstandingClient|[A-Z]\w*)\s+' + re.escape(var_name) + r'\s*='
    m = _re.search(pat, text)
    if m:
        t = m.group(1)
        return 'dynamic' if t == 'var' else t
    return 'dynamic'

# Count var declarations across blocks
from collections import Counter
var_counter = Counter()
var_type_map = {}
for b in filtered:
    block_vars = set()
    for v in get_declared_vars(b):
        if v not in block_vars:
            block_vars.add(v)
            var_counter[v] += 1
            if v not in var_type_map:
                var_type_map[v] = get_var_type(b, v)

# Variables that need hoisting (appear in 2+ blocks)
hoisted = {v for v, c in var_counter.items() if c >= 2}

# Emit hoisted declarations
if hoisted:
    for v in sorted(hoisted):
        print(f'{var_type_map[v]} {v} = default;')
    print()

# Emit code blocks with duplicate declarations converted to assignments
strip_pat = r'^\s*(?:var|string|int|bool|byte\[\]|BinaryData|Uri|Operation<[^>]+>|AnalyzeResult|MediaContent|DocumentContent|AudioVisualContent|ContentUnderstandingClient|[A-Z]\w*)\s+'
for i, b in enumerate(filtered):
    for line in b.split('\n'):
        # For hoisted variables, strip the type prefix (but not for C# using statements)
        if hoisted and not line.strip().startswith('using '):
            m = re.search(r'\b(?:var|string|int|bool|byte\[\]|BinaryData|Uri|Operation<[^>]+>|AnalyzeResult|MediaContent|DocumentContent|AudioVisualContent|ContentUnderstandingClient|[A-Z]\w*)\s+(\w+)\s*=', line)
            if m and m.group(1) in hoisted:
                line = re.sub(strip_pat, '', line)
        print(line)
    if i < len(filtered) - 1:
        print()
" 2>/dev/null)

if [ -z "$CODE_BLOCKS" ]; then
    print_error "Error: No C# code blocks found in $SAMPLE_FILE"
    exit 1
fi

# ─── Initialize .sample_runner/ scaffolding ───────────────────────────────────
# All files are created at runtime — .sample_runner/ is assumed to start clean
print_info "=== Building sample project ==="

mkdir -p "$RUNNER_BASE"

# global.json: use net10.0 with latestMajor rollForward
if [ ! -f "$RUNNER_BASE/global.json" ]; then
    cat > "$RUNNER_BASE/global.json" << 'GLOBALJSON'
{
  "sdk": {
    "version": "10.0.0",
    "rollForward": "latestMajor"
  }
}
GLOBALJSON
fi

# Isolate from repo's MSBuild central package management and NuGet feeds
if [ ! -f "$RUNNER_BASE/Directory.Build.props" ]; then
    echo '<Project />' > "$RUNNER_BASE/Directory.Build.props"
    echo '<Project />' > "$RUNNER_BASE/Directory.Build.targets"
    echo '<Project />' > "$RUNNER_BASE/Directory.Packages.props"
    cat > "$RUNNER_BASE/NuGet.Config" << 'NUGETCONFIG'
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
NUGETCONFIG
fi

# ─── Resolve SDK reference: try NuGet first, fall back to local build ─────────
LOCAL_SRC_CSPROJ="$LOCAL_SRC_DIR/Azure.AI.ContentUnderstanding.csproj"
USE_LOCAL_SRC=false
DLL_PATH=""

# Try NuGet package first by doing a restore check
print_info "Checking if Azure.AI.ContentUnderstanding NuGet package is available..."
NUGET_AVAILABLE=false
NUGET_CHECK_DIR=$(mktemp -d)
cat > "$NUGET_CHECK_DIR/check.csproj" << 'CHECKCSPROJ'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Azure.AI.ContentUnderstanding" Version="1.0.0-*" />
  </ItemGroup>
</Project>
CHECKCSPROJ
# Copy isolation files so the check project uses nuget.org only
cp "$RUNNER_BASE/global.json" "$NUGET_CHECK_DIR/" 2>/dev/null || true
echo '<Project />' > "$NUGET_CHECK_DIR/Directory.Build.props"
echo '<Project />' > "$NUGET_CHECK_DIR/Directory.Build.targets"
echo '<Project />' > "$NUGET_CHECK_DIR/Directory.Packages.props"
cp "$RUNNER_BASE/NuGet.Config" "$NUGET_CHECK_DIR/" 2>/dev/null || true

pushd "$NUGET_CHECK_DIR" > /dev/null
if dotnet restore check.csproj > /dev/null 2>&1; then
    NUGET_AVAILABLE=true
    print_success "NuGet package Azure.AI.ContentUnderstanding found. Using public NuGet."
fi
popd > /dev/null
rm -rf "$NUGET_CHECK_DIR"

if [ "$NUGET_AVAILABLE" = false ]; then
    print_warning "NuGet package not available. Attempting local SDK build..."
    if [ -f "$LOCAL_SRC_CSPROJ" ]; then
        print_info "Building local SDK from: $LOCAL_SRC_DIR"
        # Build from .sample_runner/ CWD so dotnet uses our local global.json
        pushd "$RUNNER_BASE" > /dev/null
        if dotnet build "$LOCAL_SRC_CSPROJ" -c Release > /tmp/sdk_build_output.txt 2>&1; then
            print_success "Local SDK build succeeded."
            popd > /dev/null
            # Find the built DLL in the repo artifacts directory
            REPO_ROOT="$(cd "$PACKAGE_ROOT/../../.." && pwd)"
            ARTIFACTS_DIR="$REPO_ROOT/artifacts/bin/Azure.AI.ContentUnderstanding"
            DLL_PATH=$(find "$ARTIFACTS_DIR" -name "Azure.AI.ContentUnderstanding.dll" -path "*/Release/net10.0/*" ! -path "*/ref/*" 2>/dev/null | head -1)
            # Fall back to src directory
            if [ -z "$DLL_PATH" ]; then
                DLL_PATH=$(find "$LOCAL_SRC_DIR" -name "Azure.AI.ContentUnderstanding.dll" -path "*/bin/Release/*" ! -path "*/ref/*" 2>/dev/null | head -1)
            fi
            if [ -n "$DLL_PATH" ]; then
                USE_LOCAL_SRC=true
                print_success "Using local SDK DLL: $DLL_PATH"
            else
                print_error "Error: Could not find built DLL and NuGet package is not available."
                exit 1
            fi
        else
            popd > /dev/null
            print_error "Error: Failed to build local SDK and NuGet package is not available."
            tail -20 /tmp/sdk_build_output.txt
            exit 1
        fi
    else
        print_error "Error: NuGet package not available and local SDK source not found at: $LOCAL_SRC_CSPROJ"
        exit 1
    fi
fi

# ─── Create temporary project ────────────────────────────────────────────────
RUNNER_DIR="$RUNNER_BASE/$SAMPLE_NAME"
rm -rf "$RUNNER_DIR"
mkdir -p "$RUNNER_DIR"

# Create .csproj
if [ "$USE_LOCAL_SRC" = true ]; then
    cat > "$RUNNER_DIR/${SAMPLE_NAME}.csproj" << CSPROJ
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <NoWarn>CS8600;CS8602;CS8604;CS0168;CS0219</NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Azure.AI.ContentUnderstanding">
      <HintPath>$DLL_PATH</HintPath>
    </Reference>
    <PackageReference Include="Azure.Core" Version="1.*" />
    <PackageReference Include="Azure.Identity" Version="1.*" />
    <PackageReference Include="System.Text.Json" Version="*" />
    <PackageReference Include="System.Memory.Data" Version="*" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="10.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="10.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="10.*" />
  </ItemGroup>
</Project>
CSPROJ
else
    cat > "$RUNNER_DIR/${SAMPLE_NAME}.csproj" << 'CSPROJ'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <NoWarn>CS8600;CS8602;CS8604;CS0168;CS0219</NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Azure.AI.ContentUnderstanding" Version="1.0.0-*" />
    <PackageReference Include="Azure.Identity" Version="1.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="10.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="10.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="10.*" />
  </ItemGroup>
</Project>
CSPROJ
fi

# Generate Program.cs
cat > "$RUNNER_DIR/Program.cs" << 'PROGRAM_HEADER'
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using System.ClientModel.Primitives;
using System.Drawing;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

// Load configuration
var _appConfig = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables()
    .Build();

string _endpoint = _appConfig["CONTENTUNDERSTANDING_ENDPOINT"] ?? Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_ENDPOINT") ?? "";
string _apiKey = _appConfig["AZURE_CONTENT_UNDERSTANDING_KEY"] ?? Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_KEY") ?? "";
string _targetEndpoint = _appConfig["CONTENTUNDERSTANDING_TARGET_ENDPOINT"] ?? Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TARGET_ENDPOINT") ?? "";
string _targetResourceId = _appConfig["AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID"] ?? Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID") ?? "";
string _sourceEndpoint = _appConfig["CONTENTUNDERSTANDING_SOURCE_ENDPOINT"] ?? Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_SOURCE_ENDPOINT") ?? "";
string _sourceResourceId = _appConfig["AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID"] ?? Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID") ?? "";
string _sourceRegion = _appConfig["AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION"] ?? Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION") ?? "";
string _targetRegion = _appConfig["AZURE_CONTENT_UNDERSTANDING_TARGET_REGION"] ?? Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_REGION") ?? "";
string _gpt41Deployment = _appConfig["GPT_4_1_DEPLOYMENT"] ?? Environment.GetEnvironmentVariable("GPT_4_1_DEPLOYMENT") ?? "gpt-4.1";
string _gpt41MiniDeployment = _appConfig["GPT_4_1_MINI_DEPLOYMENT"] ?? Environment.GetEnvironmentVariable("GPT_4_1_MINI_DEPLOYMENT") ?? "gpt-4.1-mini";
string _embeddingDeployment = _appConfig["TEXT_EMBEDDING_3_LARGE_DEPLOYMENT"] ?? Environment.GetEnvironmentVariable("TEXT_EMBEDDING_3_LARGE_DEPLOYMENT") ?? "text-embedding-3-large";

if (string.IsNullOrEmpty(_endpoint))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Error: CONTENTUNDERSTANDING_ENDPOINT is not configured.");
    Console.WriteLine("Set it in appsettings.json or as an environment variable.");
    Console.ResetColor();
    return;
}

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"Endpoint: {_endpoint}");
Console.ResetColor();

PROGRAM_HEADER

# Now append auth + extracted code
{
    # Auth line
    echo ""
    echo "// --- Authentication ---"
    echo "ContentUnderstandingClient client;"
    echo "if (!string.IsNullOrEmpty(_apiKey))"
    echo "{"
    echo "    client = new ContentUnderstandingClient(new Uri(_endpoint), new AzureKeyCredential(_apiKey));"
    echo "    Console.WriteLine(\"Auth: API Key\");"
    echo "}"
    echo "else"
    echo "{"
    echo "    client = new ContentUnderstandingClient(new Uri(_endpoint), new DefaultAzureCredential());"
    echo "    Console.WriteLine(\"Auth: DefaultAzureCredential\");"
    echo "}"
    echo ""
    echo "Console.WriteLine();"
    echo ""

    # Output extracted code (Python already handles { } scoping when needed for duplicate variables)
    echo "$CODE_BLOCKS" | while IFS= read -r line; do
        # Skip the client creation lines (already handled above)
        if echo "$line" | grep -qE '^\s*(string endpoint|string apiKey|var credential|var client)\s*='; then
            continue
        fi
        if echo "$line" | grep -qE '^\s*//.*Example:.*your-foundry'; then
            continue
        fi

        echo "$line"
    done

} >> "$RUNNER_DIR/Program.cs"

# ─── Post-process: fix unmatched braces and inject fallback variables ─────────

# Fix unmatched braces: some snippets include 'try {' without the closing '} catch/finally'.
# Instead of counting all braces (which is unreliable due to string interpolation and
# initializers), directly check for unclosed try blocks.
TRY_COUNT=$(grep -cE '\btry\s*$|\btry\s*\{' "$RUNNER_DIR/Program.cs" || true)
CATCH_FINALLY_COUNT=$(grep -cE '\b(catch|finally)\s*(\([^)]*\))?\s*\{|\b(catch|finally)\s*$' "$RUNNER_DIR/Program.cs" || true)
UNCLOSED_TRY=$((TRY_COUNT - CATCH_FINALLY_COUNT))
if [ "$UNCLOSED_TRY" -gt 0 ]; then
    for ((i=0; i<UNCLOSED_TRY; i++)); do
        echo '} catch (Exception ex) { Console.WriteLine($"Cleanup error: {ex.Message}"); }' >> "$RUNNER_DIR/Program.cs"
    done
fi

# Inject fallback variable declarations for variables only defined in test setup code
# outside the #region snippet boundaries.
inject_fallback_var() {
    local var_name="$1"
    local var_decl="$2"
    if grep -q "\b${var_name}\b" "$RUNNER_DIR/Program.cs" && \
       ! grep -qE "(string|var)\s+${var_name}\s*=" "$RUNNER_DIR/Program.cs"; then
        # Prepend after the PROGRAM_HEADER (after the auth block)
        sed -i "/^Console\.WriteLine();$/a\\${var_decl}" "$RUNNER_DIR/Program.cs"
    fi
}

inject_fallback_var "analyzerId" 'string analyzerId = $"my_sample_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";'
inject_fallback_var "sourceAnalyzerId" 'string sourceAnalyzerId = $"copy_source_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";'
inject_fallback_var "targetAnalyzerId" 'string targetAnalyzerId = $"copy_target_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";'

# Post-process Program.cs to replace placeholders
if [ -n "$LOCAL_FILE" ]; then
    ESCAPED_FILE=$(echo "$LOCAL_FILE" | sed 's/\\/\\\\/g')
    sed -i "s|<localDocumentFilePath>|$ESCAPED_FILE|g" "$RUNNER_DIR/Program.cs"
    sed -i "s|<filePath>|$ESCAPED_FILE|g" "$RUNNER_DIR/Program.cs"
    sed -i "s|<file_path>|$ESCAPED_FILE|g" "$RUNNER_DIR/Program.cs"
fi

# Replace any remaining <endpoint>, <apiKey> references that might be in the snippets
# These are already handled by the config loading, but some snippets have them inline
sed -i 's|"<endpoint>"|_endpoint|g' "$RUNNER_DIR/Program.cs"
sed -i 's|"<apiKey>"|_apiKey|g' "$RUNNER_DIR/Program.cs"
sed -i 's|"<document_url>"|"https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf"|g' "$RUNNER_DIR/Program.cs"

# Sample00: Replace model deployment name placeholders
sed -i "s|<your-gpt-4.1-deployment-name>|$GPT41_DEPLOYMENT|g" "$RUNNER_DIR/Program.cs"
sed -i "s|<your-gpt-4.1-mini-deployment-name>|$GPT41_MINI_DEPLOYMENT|g" "$RUNNER_DIR/Program.cs"
sed -i "s|<your-text-embedding-3-large-deployment-name>|$EMBEDDING_DEPLOYMENT|g" "$RUNNER_DIR/Program.cs"

# Sample05: Replace <file_path> placeholder (also handled above for LOCAL_FILE)
if [ -n "$LOCAL_FILE" ]; then
    ESCAPED_FILE=$(echo "$LOCAL_FILE" | sed 's/\\/\\\\/g')
    sed -i "s|<file_path>|$ESCAPED_FILE|g" "$RUNNER_DIR/Program.cs"
fi

# Sample15: Replace cross-resource placeholders with config values
if [ -n "$SOURCE_ENDPOINT" ]; then
    sed -i "s|https://source-resource.services.ai.azure.com/|$SOURCE_ENDPOINT|g" "$RUNNER_DIR/Program.cs"
fi
if [ -n "$TARGET_ENDPOINT" ]; then
    sed -i "s|https://target-resource.services.ai.azure.com/|$TARGET_ENDPOINT|g" "$RUNNER_DIR/Program.cs"
fi
if [ -n "$SOURCE_RESOURCE_ID" ]; then
    # Replace only the sourceResourceId line (not targetResourceId which uses the same placeholder)
    sed -i "/string sourceResourceId/s|/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{name}|$SOURCE_RESOURCE_ID|g" "$RUNNER_DIR/Program.cs"
fi
if [ -n "$TARGET_RESOURCE_ID" ]; then
    sed -i "/string targetResourceId/s|/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{name}|$TARGET_RESOURCE_ID|g" "$RUNNER_DIR/Program.cs"
fi
if [ -n "$SOURCE_REGION" ]; then
    # Only replace the source region assignment line, not all occurrences of region strings
    sed -i "s|string sourceRegion = \"eastus\";|string sourceRegion = \"$SOURCE_REGION\";|g" "$RUNNER_DIR/Program.cs"
fi
if [ -n "$TARGET_REGION" ]; then
    sed -i "s|string targetRegion = \"westus\";|string targetRegion = \"$TARGET_REGION\";|g" "$RUNNER_DIR/Program.cs"
fi

# For samples that need a local file but none provided, download a test file
if grep -q '<localDocumentFilePath>\|<filePath>\|<file_path>' "$RUNNER_DIR/Program.cs" 2>/dev/null; then
    if [ -z "$LOCAL_FILE" ]; then
        print_warning "⚠ Sample requires a local file. Downloading a test PDF..."
        TEST_FILE="$RUNNER_DIR/test_document.pdf"
        curl -sL "https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf" -o "$TEST_FILE"
        ESCAPED_TEST=$(echo "$TEST_FILE" | sed 's/\\/\\\\/g')
        sed -i "s|<localDocumentFilePath>|$ESCAPED_TEST|g" "$RUNNER_DIR/Program.cs"
        sed -i "s|<filePath>|$ESCAPED_TEST|g" "$RUNNER_DIR/Program.cs"
        sed -i "s|<file_path>|$ESCAPED_TEST|g" "$RUNNER_DIR/Program.cs"
    fi
fi

# Copy appsettings.json to runner directory if it exists
if [ -f "$APPSETTINGS" ]; then
    cp "$APPSETTINGS" "$RUNNER_DIR/appsettings.json"
    print_info "Copied appsettings.json to sample project folder"
fi

# ─── Build the project ────────────────────────────────────────────────────────
echo ""
print_info "=== Building: $SAMPLE_NAME ==="
echo ""

cd "$RUNNER_DIR"

set +e
dotnet build "$RUNNER_DIR/${SAMPLE_NAME}.csproj"
BUILD_EXIT_CODE=$?
set -e

if [ $BUILD_EXIT_CODE -ne 0 ]; then
    print_error "✗ Build failed with exit code: $BUILD_EXIT_CODE"
    echo ""
    print_warning "Troubleshooting:"
    print_warning "  - Review the generated code: $RUNNER_DIR/Program.cs"
    print_warning "  - Delete .sample_runner/ and re-run to regenerate"
    exit $BUILD_EXIT_CODE
fi

print_success "✓ Build succeeded: $SAMPLE_NAME"

# ─── Run (if --run flag) or print instructions ───────────────────────────────
if [ "$RUN_AFTER_BUILD" = true ]; then
    echo ""
    print_info "=== Running: $SAMPLE_NAME ==="
    echo ""

    set +e
    dotnet run --project "$RUNNER_DIR/${SAMPLE_NAME}.csproj" --no-build
    EXIT_CODE=$?
    set -e

    echo ""
    if [ $EXIT_CODE -eq 0 ]; then
        print_success "✓ Sample completed: $SAMPLE_NAME"
    else
        print_error "✗ Sample failed with exit code: $EXIT_CODE"
        echo ""
        print_warning "Troubleshooting:"
        print_warning "  - Check that your endpoint and credentials are correct"
        print_warning "  - Ensure model deployments are configured (run Sample00_UpdateDefaults)"
        print_warning "  - Verify the Cognitive Services User role is assigned"
        print_warning "  - Review the generated code: $RUNNER_DIR/Program.cs"
    fi
    exit $EXIT_CODE
else
    echo ""
    print_success "Sample project is ready! To run it:"
    echo ""
    print_cyan "  cd $RUNNER_DIR"
    print_cyan "  dotnet run --project ${SAMPLE_NAME}.csproj"
    echo ""
    print_info "Project location: $RUNNER_DIR"
    print_info "Generated code:   $RUNNER_DIR/Program.cs"
    exit 0
fi
