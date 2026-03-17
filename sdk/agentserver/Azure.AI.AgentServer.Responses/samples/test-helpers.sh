#!/usr/bin/env bash
# Shared helpers for sample test scripts.
# Source this file at the top of each test.sh:
#   SAMPLE_NAME="GettingStarted"
#   SAMPLE_PORT=5100
#   source "$(dirname "$0")/../test-helpers.sh"
#
# Provides:
#   http METHOD PATH [BODY]       — JSON request/response with wireline logging
#   http_stream METHOD PATH BODY  — SSE request with wireline logging
#   start_sample_server           — builds & starts the server, waits for /ready
#
# After sourcing and calling start_sample_server, the server runs in the
# background and is automatically killed on script exit.
# HTTP_BODY is set after each http() call for downstream extraction (jq, etc.).

set -euo pipefail

: "${SAMPLE_NAME:?Set SAMPLE_NAME before sourcing test-helpers.sh}"
: "${SAMPLE_PORT:?Set SAMPLE_PORT before sourcing test-helpers.sh}"

PORT=${PORT:-$SAMPLE_PORT}
BASE="http://localhost:$PORT"

# ── HTTP wireline helpers ──────────────────────────────────────────────

# Sends a JSON request and prints request/response in HTTP/1.1 wireline format.
# Sets HTTP_BODY to the response body for downstream use.
http() {
  local method="$1" path="$2" body="${3:-}"
  local url="${BASE}${path}"

  echo "-----------------------------------------------"
  echo "> ${method} ${path} HTTP/1.1"
  echo "> Host: localhost:${PORT}"
  echo "> Content-Type: application/json"
  [[ -n "$body" ]] && echo "> Content-Length: ${#body}"
  echo ">"
  [[ -n "$body" ]] && { echo "$body" | jq . 2>/dev/null || echo "$body"; }
  echo ""

  local hdr; hdr=$(mktemp)
  local curl_args=(-s -D "$hdr" -X "$method" -H "Content-Type: application/json")
  [[ -n "$body" ]] && curl_args+=(-d "$body")
  HTTP_BODY=$(curl "${curl_args[@]}" "$url")

  while IFS= read -r line; do echo "< ${line%$'\r'}"; done < "$hdr"
  rm -f "$hdr"
  echo ""
  echo "$HTTP_BODY" | jq . 2>/dev/null || echo "$HTTP_BODY"
  echo ""
}

# Like http() but writes the raw body (SSE stream) instead of jq-formatting.
http_stream() {
  local method="$1" path="$2" body="${3:-}"
  local url="${BASE}${path}"

  echo "-----------------------------------------------"
  echo "> ${method} ${path} HTTP/1.1"
  echo "> Host: localhost:${PORT}"
  echo "> Content-Type: application/json"
  [[ -n "$body" ]] && echo "> Content-Length: ${#body}"
  echo ">"
  [[ -n "$body" ]] && { echo "$body" | jq . 2>/dev/null || echo "$body"; }
  echo ""

  local hdr; hdr=$(mktemp)
  local out; out=$(mktemp)
  curl -s -D "$hdr" -X "$method" -H "Content-Type: application/json" \
       -d "$body" "$url" -o "$out"

  while IFS= read -r line; do echo "< ${line%$'\r'}"; done < "$hdr"
  echo ""
  cat "$out"
  echo ""
  rm -f "$hdr" "$out"
}

# ── Server lifecycle ───────────────────────────────────────────────────

# Starts the sample server in the background and waits for /ready.
# The caller's SAMPLE_DIR must point to the project directory.
start_sample_server() {
  local project_dir="${1:-$(dirname "${BASH_SOURCE[1]}")}"

  echo "=== ${SAMPLE_NAME} Sample ==="
  echo ""

  ASPNETCORE_ENVIRONMENT=Production dotnet run --project "$project_dir" --urls "$BASE" \
    --Logging:LogLevel:Default=Warning --Logging:LogLevel:Microsoft=Warning 2>&1 >/dev/null &
  SERVER_PID=$!
  trap "kill $SERVER_PID 2>/dev/null; wait $SERVER_PID 2>/dev/null" EXIT

  for i in $(seq 1 30); do
      if curl -sf "$BASE/ready" -o /dev/null 2>/dev/null; then
          break
      fi
      sleep 0.5
  done
}

# Prints the success banner. Call at the end of each test script.
pass() {
  echo "=== ${SAMPLE_NAME}: All tests passed ==="
}
