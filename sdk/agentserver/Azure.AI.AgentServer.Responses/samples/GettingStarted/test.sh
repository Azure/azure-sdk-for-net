#!/usr/bin/env bash
# Test script for the GettingStarted sample.
# Exercises three modes: default JSON, streaming SSE, and background (POST+GET).
SAMPLE_NAME="GettingStarted"
SAMPLE_PORT=5100
source "$(dirname "$0")/../test-helpers.sh"

start_sample_server

echo "--- Default mode (JSON) ---"
http POST /responses '{"model":"test"}'

echo "--- Streaming mode (SSE) ---"
http_stream POST /responses '{"model":"test","stream":true}'

echo "--- Background mode (POST then GET) ---"
http POST /responses '{"model":"test","background":true}'
ID=$(echo "$HTTP_BODY" | jq -r '.id')
sleep 0.5
http GET "/responses/${ID}"

pass
