#!/bin/bash

# Post-create setup script for the AgentServer dev container.
# Installs dev tooling (Copilot CLI, uv, Spec-Kit), restores .NET dependencies,
# and prepares the workspace for development.

set -euo pipefail

run_command() {
    local command_to_run="$*"
    local output
    local exit_code

    output=$(eval "$command_to_run" 2>&1) || exit_code=$?
    exit_code=${exit_code:-0}

    if [ $exit_code -ne 0 ]; then
        echo -e "\033[0;31m[ERROR] Command failed (Exit Code $exit_code): $command_to_run\033[0m" >&2
        echo -e "\033[0;31m$output\033[0m" >&2
        exit $exit_code
    fi
}

# --- GitHub Copilot CLI ---
echo -e "\n🤖 Checking GitHub Copilot CLI..."
if gh copilot --help &>/dev/null; then
    echo "✅ gh copilot is already available (built-in)"
elif gh auth status &>/dev/null; then
    run_command "gh extension install github/gh-copilot --force"
    echo "✅ Done (installed as extension)"
else
    echo "⚠️  Skipped: gh is not authenticated. Run 'gh auth login' then 'gh extension install github/gh-copilot' manually."
fi

# --- UV (Python package manager for spec-kit) ---
echo -e "\n🐍 Installing UV..."
run_command "pip install uv"
echo "✅ Done"

# --- Specify CLI (spec-kit) ---
echo -e "\n📋 Installing Specify CLI (spec-kit)..."
run_command "uv tool install specify-cli --from git+https://github.com/github/spec-kit.git"
echo "✅ Done"

# --- Python dependencies for codegen scripts ---
echo -e "\n🔨 Installing Python codegen dependencies..."
run_command "pip install pyyaml"
echo "✅ Done"

# --- .NET restore ---
echo -e "\n🔧 Restoring .NET dependencies..."
run_command "dotnet restore Azure.AI.AgentServer.sln"
echo "✅ Done"

# --- Fix /workspaces permissions (needed by tsp-client) ---
echo -e "\n🔐 Fixing /workspaces permissions..."
sudo chmod o+w /workspaces/
echo "✅ Done"

# --- npm install (if package.json exists) ---
if [ -f "package.json" ]; then
    echo -e "\n📦 Installing npm dependencies..."
    run_command "npm install"
    echo "✅ Done"
fi

# --- Clean apt cache ---
echo -e "\n🧹 Cleaning cache..."
run_command "sudo apt-get autoclean -y"
run_command "sudo apt-get clean"

# --- Add gh auth check to shell startup ---
cat >> ~/.bashrc << 'GHCHECK'

# Check GitHub CLI auth on new terminal
if command -v gh &>/dev/null && ! gh auth status &>/dev/null 2>&1; then
    echo -e "\n⚠️  GitHub CLI is not authenticated. Run: gh auth login\n"
fi
GHCHECK

echo -e "\n✅ Setup completed. Happy coding! 🚀"
