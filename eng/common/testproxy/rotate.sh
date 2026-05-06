#!/usr/bin/env bash

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Generates a self-signed CA and a TLS certificate for localhost signed by that CA,
# then packages them into a PKCS#12 (PFX) file for use with the test proxy.
#
# Usage: ./rotate.sh [--days <n>] [--password <pass>]
#   --days      Validity period in days (default: 365)
#   --password  Password for the PFX file (default: password, matching apply-dev-cert.sh)

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

DAYS=365
PFX_PASSWORD="password"

while [[ $# -gt 0 ]]; do
    case "$1" in
        --days)
            DAYS="$2"
            shift 2
            ;;
        --password)
            PFX_PASSWORD="$2"
            shift 2
            ;;
        *)
            echo "Unknown argument: $1" >&2
            exit 1
            ;;
    esac
done

CA_KEY="$SCRIPT_DIR/ca.key"
# dotnet-devcert.crt is the CA public cert installed into trust stores by apply-dev-cert.sh.
CA_CERT="$SCRIPT_DIR/dotnet-devcert.crt"
CA_CONF="$SCRIPT_DIR/ca.conf"

TLS_KEY="$SCRIPT_DIR/dotnet-devcert.key"
TLS_CSR="$SCRIPT_DIR/dotnet-devcert.csr"
TLS_CERT="$SCRIPT_DIR/localhost.crt"
TLS_PFX="$SCRIPT_DIR/dotnet-devcert.pfx"
TLS_CONF="$SCRIPT_DIR/localhost.conf"

echo "Generating CA private key..."
openssl genrsa -out "$CA_KEY" 2048

echo "Generating self-signed CA certificate (${DAYS} days)..."
openssl req -new -x509 \
    -key "$CA_KEY" \
    -out "$CA_CERT" \
    -days "$DAYS" \
    -config "$CA_CONF"

echo "Generating TLS private key..."
openssl genrsa -out "$TLS_KEY" 2048

echo "Generating TLS certificate signing request..."
openssl req -new \
    -key "$TLS_KEY" \
    -out "$TLS_CSR" \
    -config "$TLS_CONF"

echo "Signing TLS certificate with CA (${DAYS} days)..."
openssl x509 -req \
    -in "$TLS_CSR" \
    -CA "$CA_CERT" \
    -CAkey "$CA_KEY" \
    -CAcreateserial \
    -out "$TLS_CERT" \
    -days "$DAYS" \
    -extfile "$TLS_CONF" \
    -extensions x509_ext

echo "Creating PFX bundle (TLS cert + CA chain + private key)..."
openssl pkcs12 -export \
    -out "$TLS_PFX" \
    -inkey "$TLS_KEY" \
    -in "$TLS_CERT" \
    -certfile "$CA_CERT" \
    -password "pass:${PFX_PASSWORD}"

# Remove OpenSSL serial number tracking file; it is regenerated on each run.
rm -f "$SCRIPT_DIR/dotnet-devcert.srl"

echo ""
echo "Created files:"
echo "  $CA_CERT  (CA public cert — install this into trust stores)"
echo "  $TLS_CERT"
echo "  $TLS_CSR"
echo "  $TLS_PFX  (CA public cert + TLS public cert + TLS private key)"
echo ""
echo "Private keys (gitignored — do not commit):"
echo "  $CA_KEY"
echo "  $TLS_KEY"
echo ""
echo "Run apply-dev-cert.sh to install the certificates into your trust stores."
