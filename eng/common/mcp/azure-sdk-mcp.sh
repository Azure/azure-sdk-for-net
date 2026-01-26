#!/bin/bash
# Azure SDK MCP Server Wrapper for Linux/macOS
# This script checks for PowerShell 7 (pwsh) and provides installation instructions if not found.

# Check if pwsh is available
if ! command -v pwsh &> /dev/null; then
    echo "" >&2
    echo "================================================================================" >&2
    echo " ERROR: PowerShell 7 (pwsh) is required but not installed." >&2
    echo "================================================================================" >&2
    echo "" >&2
    echo " The Azure SDK MCP Server requires PowerShell 7 or later." >&2
    echo "" >&2
    echo " To install PowerShell 7:" >&2
    echo "" >&2
    echo "   On Windows:" >&2
    echo "     winget install --id Microsoft.PowerShell --source winget" >&2
    echo "" >&2
    echo "   On Ubuntu/Debian:" >&2
    echo "     sudo apt-get update && sudo apt-get install -y powershell" >&2
    echo "" >&2
    echo "   On macOS (using Homebrew):" >&2
    echo "     brew install powershell/tap/powershell" >&2
    echo "" >&2
    echo "   Other platforms:" >&2
    echo "     https://learn.microsoft.com/powershell/scripting/install/install-powershell" >&2
    echo "" >&2
    echo " After installing, restart VS Code and try again." >&2
    echo "================================================================================" >&2
    echo "" >&2
    exit 1
fi

# PowerShell 7 is available, run the MCP server script
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
exec pwsh -NoLogo -NoProfile -File "$SCRIPT_DIR/azure-sdk-mcp.ps1" "$@"
