#!/usr/bin/env bash
# Test script for the MultiOutput sample.
# Shows reasoning + message output items in both JSON and streaming modes.
SAMPLE_NAME="MultiOutput"
SAMPLE_PORT=5102
source "$(dirname "$0")/../test-helpers.sh"

start_sample_server

echo "--- Default mode (JSON) — reasoning + message ---"
http POST /responses '{"model":"test"}'

echo "--- Streaming mode (SSE) — watch event ordering ---"
http_stream POST /responses '{"model":"test","stream":true}'

pass
