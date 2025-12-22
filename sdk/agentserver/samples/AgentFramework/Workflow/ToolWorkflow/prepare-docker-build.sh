#!/bin/bash
# Script to prepare NuGet package cache for Docker build
# This script copies ALL packages from local cache to avoid authentication issues

set -e

REPO_ROOT="/Users/lixiaoli/Projects/azure-sdk-for-net"
CACHE_DIR="$REPO_ROOT/.nuget-cache"
LOCAL_NUGET="$HOME/.nuget/packages"

echo "Preparing NuGet package cache for Docker build..."
echo "This will copy ALL NuGet packages from your local cache..."

# Remove old cache if exists
if [ -d "$CACHE_DIR" ]; then
    echo "Removing old cache directory..."
    rm -rf "$CACHE_DIR"
fi

# Create cache directory
mkdir -p "$CACHE_DIR"

# Copy entire NuGet packages directory
# This ensures all dependencies are available, including transitive dependencies
echo "Copying all NuGet packages from local cache..."
echo "Source: $LOCAL_NUGET"
echo "Destination: $CACHE_DIR"

cp -r "$LOCAL_NUGET/"* "$CACHE_DIR/" 2>/dev/null || true

echo ""
echo "✓ NuGet cache prepared successfully at: $CACHE_DIR"
echo "  Total packages copied: $(find "$CACHE_DIR" -mindepth 1 -maxdepth 1 -type d | wc -l)"
echo ""
echo "You can now build the Docker image with:"
echo "  cd $REPO_ROOT"
echo "  docker build -f sdk/agentserver/samples/AgentFramework/Workflow/BasicWorkflow/Dockerfile -t basicworkflow:latest ."
