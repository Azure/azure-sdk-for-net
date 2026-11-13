#!/bin/bash
# =============================================================================
# rotate.sh — Regenerate dotnet-devcert.crt and dotnet-devcert.pfx
#
# Dependencies:
#   - openssl (apt install openssl / already present on most WSL distros)
#
# Usage (from WSL, standing in the repo root):
#   cd eng/common/testproxy
#   bash rotate.sh
#
# The script overwrites dotnet-devcert.crt and dotnet-devcert.pfx in-place
# using the localhost.conf that lives alongside it.
#
# After running:
#   1. Verify the new cert:  openssl x509 -in dotnet-devcert.crt -noout -dates -subject
#   2. Commit both files and open a PR against azure-sdk-tools.
# =============================================================================
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

KEYFILE=$(mktemp)
trap 'rm -f "$KEYFILE"' EXIT

CONF_PATH="$SCRIPT_DIR/localhost.conf"
CRTFILE="$SCRIPT_DIR/dotnet-devcert.crt"
PFXFILE="$SCRIPT_DIR/dotnet-devcert.pfx"

# Generate a new 2048-bit self-signed cert valid for 365 days
openssl req -x509 -nodes -days 365 \
  -newkey rsa:2048 \
  -keyout "$KEYFILE" \
  -out "$CRTFILE" \
  -config "$CONF_PATH"

# Bundle into a PKCS#12 archive (password: "password")
openssl pkcs12 -export \
  -out "$PFXFILE" \
  -inkey "$KEYFILE" \
  -in "$CRTFILE" \
  -passout pass:password

echo ""
echo "✓ Regenerated:"
echo "    $CRTFILE"
echo "    $PFXFILE"
echo ""
openssl x509 -in "$CRTFILE" -noout -dates -subject
