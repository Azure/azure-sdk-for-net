#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# Resilient Responses Research Agent — Demo Client
#
# Showcases four platform capabilities of the responses package
# (all empirically validated against a Foundry hosted deployment):
#   1. LONG-RUNNING RESPONSES — the underlying @multi_turn_task lease
#      renewals (every ~30s) keep the platform's sandbox idle-reclaim
#      timer fresh, so a single response stays warm well past the
#      eviction window without any client-side keepalive ingress.
#   2. CRASH RECOVERY — when the container dies, the platform's nanny
#      worker restarts it within ~1 min on its own (no new ingress
#      needed); the resilient response auto-resumes with
#      `context.is_recovery is True` from its last completed phase.
#   3. STEERING — sending a follow-up turn while one is still running
#      (POST with `previous_response_id`) queues the input; the agent
#      winds down at the next phase boundary and re-enters with the
#      new input as a fresh steered turn (`context.is_steered_turn`).
#   4. OPERATOR CANCEL — POST /responses/{id}/cancel forces the
#      response to `status=cancelled` regardless of what the handler
#      emits (B11 contract).
#
# Commands:
#   ./demo-client.sh start "<topic>"   Dispatch + stream a fresh response (bg+stream)
#   ./demo-client.sh stream            Reconnect to the active response (no fresh POST)
#   ./demo-client.sh steer "<topic>"   Queue a follow-up turn — agent winds down
#                                      current turn at next checkpoint and switches
#   ./demo-client.sh cancel            Operator cancel of the active response
#   ./demo-client.sh crash             Trigger demo-mode container crash
#   ./demo-client.sh delete            DELETE /responses/{id}
#   ./demo-client.sh status            Show local session info
#   ./demo-client.sh logs              Stream container stdout/stderr via azd
#   ./demo-client.sh reset             Clear local session state
# ─────────────────────────────────────────────────────────────────────────────

set -uo pipefail

# ── Config ────────────────────────────────────────────────────────────────────

# Point at your own hosted deployment. After `azd ai agent run`, the
# endpoint is printed in the deploy output (…/agents/<name>/endpoint/protocols),
# or read it from your azd env (AGENT_*_RESPONSES_ENDPOINT). Override via
# the ENDPOINT env var instead of editing this default.
ENDPOINT="${ENDPOINT:-https://<account>.services.ai.azure.com/api/projects/<project>/agents/resilient-responses-agent-demo-dotnet/endpoint/protocols}"
API_VERSION="${API_VERSION:-v1}"
MODEL="${MODEL:-gpt-5.4-nano}"
SESSION_FILE=".demo-session"

# ── Colors ────────────────────────────────────────────────────────────────────

BOLD='\033[1m'
DIM='\033[2m'
GREEN='\033[32m'
YELLOW='\033[33m'
RED='\033[31m'
CYAN='\033[36m'
RESET='\033[0m'

# ── Session state ─────────────────────────────────────────────────────────────

load_session() {
    if [[ -f "$SESSION_FILE" ]]; then
        # shellcheck disable=SC1090
        source "$SESSION_FILE"
    fi
}

save_session() {
    {
        echo "RESPONSE_ID=\"${RESPONSE_ID:-}\""
        echo "PREV_RESPONSE_ID=\"${PREV_RESPONSE_ID:-}\""
        echo "LAST_SEQUENCE_NUMBER=\"${LAST_SEQUENCE_NUMBER:-0}\""
    } > "$SESSION_FILE"
}

ensure_token() {
    if [[ "${LOCAL_NOAUTH:-0}" == "1" ]]; then
        TOKEN="local-noauth"
        return
    fi
    if [[ -z "${TOKEN:-}" ]]; then
        TOKEN=$(az account get-access-token --resource https://ai.azure.com --query accessToken -o tsv 2>/dev/null)
        if [[ -z "$TOKEN" ]]; then
            echo -e "${RED}Failed to get Azure token. Run 'az login' first.${RESET}" >&2
            exit 1
        fi
    fi
}

# Extract a top-level JSON field. Returns empty string on missing/null.
_jq() {
    local json="$1"
    local key="$2"
    echo "$json" | python3 -c "
import sys, json
try:
    d = json.loads(sys.stdin.read())
    v = d.get('$key')
    print('' if v is None else v)
except Exception:
    print('')
" 2>/dev/null
}

# ── SSE stream renderer (Python — see comment) ───────────────────────────────

# Why a python renderer instead of bash:
#  - At LLM emit rate (50-100 tok/s) a bash 'while read | printf' loop
#    makes the real interactive terminal the bottleneck — one printf-per-
#    token causes syscall thrash. The python renderer batches writes per
#    SSE event, keeping the terminal responsive even on slow links.
#  - We also need a single place to persist LAST_SEQUENCE_NUMBER for
#    later reconnects.

stream_sse() {
    local url="$1"
    local extra_header="${2:-}"
    local method="${3:-GET}"
    local post_body="${4:-}"
    ensure_token

    local hdrs=(-H "Authorization: Bearer $TOKEN"
                -H "Accept: text/event-stream"
                -H "Foundry-Features: HostedAgents=V1Preview")
    if [[ -n "$extra_header" ]]; then
        hdrs+=(-H "$extra_header")
    fi

    # Use a pipe + python to render; on exit (Ctrl-C or stream end) the
    # renderer prints the last sequence number AND the discovered response
    # id (if the stream came from POST /responses) to sidecar files we read
    # back into LAST_SEQUENCE_NUMBER / RESPONSE_ID.
    local seq_file=".demo-session.lastseq"
    local id_file=".demo-session.rid"
    rm -f "$seq_file" "$id_file"

    STREAM_RESULT="ok"
    local curl_args=("${hdrs[@]}")
    if [[ "$method" == "POST" ]]; then
        curl_args+=(-X POST -H "Content-Type: application/json" --data "$post_body")
    fi
    curl -sS -N "${curl_args[@]}" "$url" 2>/dev/null | python3 -u -c "
import json, sys, os, signal

SEQ_FILE = '$seq_file'
ID_FILE = '$id_file'

def _save_seq(n):
    try:
        with open(SEQ_FILE, 'w') as f:
            f.write(str(n))
    except Exception:
        pass

def _save_id(rid):
    try:
        with open(ID_FILE, 'w') as f:
            f.write(str(rid))
    except Exception:
        pass

_last = 0
_id_saved = False

def _handle_sigint(*_):
    _save_seq(_last)
    sys.exit(0)

signal.signal(signal.SIGINT, _handle_sigint)

current_event = None
current_data = []

for raw in sys.stdin:
    line = raw.rstrip('\n')
    if not line:
        if current_event and current_data:
            data = '\n'.join(current_data)
            try:
                payload = json.loads(data)
            except Exception:
                payload = {'_raw': data}
            seq = payload.get('sequence_number')
            if isinstance(seq, int):
                _last = seq
            # Extract response id from the first lifecycle event we see.
            if not _id_saved:
                resp = payload.get('response') or {}
                rid = resp.get('id')
                if rid:
                    _save_id(rid)
                    _id_saved = True
            t = payload.get('type', current_event)
            if t == 'response.output_text.delta':
                sys.stdout.write(payload.get('delta', ''))
                sys.stdout.flush()
            elif t in ('response.created', 'response.in_progress', 'response.completed',
                       'response.failed', 'response.cancelled', 'response.incomplete'):
                resp = payload.get('response') or {}
                status = resp.get('status') or t.split('.')[-1]
                sys.stdout.write('\n\033[2m[' + t + ' status=' + str(status) + ']\033[0m\n')
                sys.stdout.flush()
        current_event = None
        current_data = []
        continue
    if line.startswith('event:'):
        current_event = line.split(':', 1)[1].strip()
    elif line.startswith('data:'):
        current_data.append(line.split(':', 1)[1].lstrip())

_save_seq(_last)
print()
"
    local rc=$?
    if [[ -f "$id_file" ]]; then
        local new_id
        new_id=$(cat "$id_file" 2>/dev/null || echo "")
        if [[ -n "$new_id" ]]; then
            RESPONSE_ID="$new_id"
        fi
        rm -f "$id_file"
    fi
    if [[ -f "$seq_file" ]]; then
        LAST_SEQUENCE_NUMBER=$(cat "$seq_file" 2>/dev/null || echo "0")
        rm -f "$seq_file"
    fi
    save_session
    if [[ "$rc" -ne 0 && "$rc" -ne 130 ]]; then
        STREAM_RESULT="error"
    fi
}

# ── Commands ──────────────────────────────────────────────────────────────────

cmd_start() {
    local topic="${1:-Research the future of quantum computing}"
    RESPONSE_ID=""
    PREV_RESPONSE_ID=""
    LAST_SEQUENCE_NUMBER="0"
    save_session
    ensure_token

    echo -e "${GREEN}Starting a fresh research response${RESET}"
    echo -e "${DIM}Topic: ${topic}${RESET}"

    local body
    body=$(python3 -c "
import json, sys
print(json.dumps({
    'model': '$MODEL',
    'input': sys.argv[1],
    'stream': True,
    'store': True,
    'background': True,
}))
" "$topic")

    local response
    # POST with stream=true returns SSE; pipe through stream_sse which
    # extracts response_id from the first response.created event,
    # renders the rest, and persists LAST_SEQUENCE_NUMBER on exit.
    echo ""
    echo -e "${BOLD}Streaming. ${DIM}Use Ctrl-C to detach; reconnect later with './demo-client.sh stream'.${RESET}"
    stream_sse "${ENDPOINT}/responses?api-version=${API_VERSION}" "" POST "$body"
    if [[ -z "${RESPONSE_ID:-}" ]]; then
        echo -e "${RED}Failed to dispatch (no response.id captured from SSE).${RESET}"
        exit 1
    fi
    echo -e "${DIM}Dispatched: response_id=${RESPONSE_ID}${RESET}"
    _report_stream_result
}

cmd_stream() {
    load_session
    if [[ -z "${RESPONSE_ID:-}" ]]; then
        echo -e "${RED}No active response. Run './demo-client.sh start \"<topic>\"' first.${RESET}" >&2
        exit 1
    fi
    ensure_token

    echo -e "${DIM}Reconnecting to response ${RESPONSE_ID}${RESET}"
    local url="${ENDPOINT}/responses/${RESPONSE_ID}?stream=true&api-version=${API_VERSION}"
    if [[ "${LAST_SEQUENCE_NUMBER:-0}" != "0" ]]; then
        url="${url}&starting_after=${LAST_SEQUENCE_NUMBER}"
        echo -e "${DIM}Resuming from sequence_number ${LAST_SEQUENCE_NUMBER}${RESET}"
    fi
    stream_sse "$url"
    _report_stream_result
}

cmd_steer() {
    local topic="${1:-}"
    if [[ -z "$topic" ]]; then
        echo -e "${RED}Usage: ./demo-client.sh steer \"<new topic>\"${RESET}" >&2
        exit 1
    fi
    load_session
    if [[ -z "${RESPONSE_ID:-}" ]]; then
        echo -e "${RED}No active response to steer. Run './demo-client.sh start' first.${RESET}" >&2
        exit 1
    fi
    ensure_token

    echo -e "${YELLOW}Steering: queuing follow-up turn on response ${RESPONSE_ID}${RESET}"
    echo -e "${DIM}New topic: ${topic}${RESET}"

    local body
    body=$(python3 -c "
import json, sys
print(json.dumps({
    'model': '$MODEL',
    'input': sys.argv[1],
    'previous_response_id': sys.argv[2],
    'stream': True,
    'store': True,
    'background': True,
}))
" "$topic" "$RESPONSE_ID")

    PREV_RESPONSE_ID="$RESPONSE_ID"
    RESPONSE_ID=""
    LAST_SEQUENCE_NUMBER="0"
    save_session

    echo ""
    echo -e "${BOLD}Streaming the steered turn.${RESET}"
    # POST returns SSE (stream=true) — stream_sse captures the new
    # response_id from the first response.created event.
    stream_sse "${ENDPOINT}/responses?api-version=${API_VERSION}" "" POST "$body"
    if [[ -z "${RESPONSE_ID:-}" ]]; then
        echo -e "${RED}Failed to steer (no response.id captured from SSE).${RESET}"
        RESPONSE_ID="$PREV_RESPONSE_ID"
        save_session
        exit 1
    fi
    echo -e "${DIM}New response_id=${RESPONSE_ID} (steered after ${PREV_RESPONSE_ID})${RESET}"
    _report_stream_result
}

cmd_cancel() {
    load_session
    if [[ -z "${RESPONSE_ID:-}" ]]; then
        echo -e "${RED}No active response.${RESET}" >&2
        exit 1
    fi
    ensure_token

    echo -e "${YELLOW}Cancelling response ${RESPONSE_ID}${RESET}"
    curl -sS -X POST \
        -H "Authorization: Bearer $TOKEN" \
        -H "Foundry-Features: HostedAgents=V1Preview" \
        "${ENDPOINT}/responses/${RESPONSE_ID}/cancel?api-version=${API_VERSION}" | python3 -m json.tool
}

cmd_crash() {
    load_session
    ensure_token

    echo -e "${RED}Triggering container crash via input=\"crash\"${RESET}"
    echo -e "${DIM}(requires DEMO_MODE=1 on the server)${RESET}"

    local body='{"model": "'"$MODEL"'", "input": "crash", "stream": true, "store": true, "background": true}'
    # The crash POST returns SSE briefly (response.created + response.failed
    # if our handler emits before exit) — pipe through stream_sse so we see
    # whatever comes out before the container dies. The renderer's
    # accumulated curl will then error out when the connection drops.
    stream_sse "${ENDPOINT}/responses?api-version=${API_VERSION}" "" POST "$body"

    echo ""
    echo -e "${DIM}Container will exit shortly. Platform nanny restarts within ~1 min.${RESET}"
    echo -e "${DIM}If you had an active response, './demo-client.sh stream' after restart will${RESET}"
    echo -e "${DIM}reconnect and resume from the last completed phase.${RESET}"
}

cmd_delete() {
    load_session
    if [[ -z "${RESPONSE_ID:-}" ]]; then
        echo -e "${RED}No active response.${RESET}" >&2
        exit 1
    fi
    ensure_token

    echo -e "${YELLOW}Deleting response ${RESPONSE_ID}${RESET}"
    curl -sS -X DELETE \
        -H "Authorization: Bearer $TOKEN" \
        -H "Foundry-Features: HostedAgents=V1Preview" \
        "${ENDPOINT}/responses/${RESPONSE_ID}?api-version=${API_VERSION}" | python3 -m json.tool
}

cmd_status() {
    load_session
    echo -e "${BOLD}Local session state${RESET} ${DIM}(${SESSION_FILE})${RESET}"
    echo "  RESPONSE_ID:          ${RESPONSE_ID:-<none>}"
    echo "  PREV_RESPONSE_ID:     ${PREV_RESPONSE_ID:-<none>}"
    echo "  LAST_SEQUENCE_NUMBER: ${LAST_SEQUENCE_NUMBER:-0}"
    echo ""
    if [[ -n "${RESPONSE_ID:-}" ]]; then
        ensure_token
        echo -e "${BOLD}Server-side snapshot${RESET}"
        curl -sS \
            -H "Authorization: Bearer $TOKEN" \
            -H "Foundry-Features: HostedAgents=V1Preview" \
            "${ENDPOINT}/responses/${RESPONSE_ID}?api-version=${API_VERSION}" | python3 -m json.tool
    fi
}

cmd_logs() {
    azd ai agent monitor resilient-responses-agent-demo-dotnet --follow "$@"
}

cmd_reset() {
    rm -f "$SESSION_FILE"
    echo -e "${DIM}Cleared ${SESSION_FILE}.${RESET}"
}

_report_stream_result() {
    case "$STREAM_RESULT" in
        ok)    : ;;
        error) echo -e "${RED}Stream errored; try './demo-client.sh stream' to reconnect.${RESET}" >&2 ;;
    esac
}

usage() {
    cat <<'USAGE'
Resilient Responses Research Agent — Demo Client

Usage:
  ./demo-client.sh start "<topic>"   Dispatch + stream a fresh research response
  ./demo-client.sh stream            Reconnect to the active response (no fresh POST)
  ./demo-client.sh steer "<topic>"   Queue a follow-up turn — agent winds down
                                     current turn at next checkpoint and switches
  ./demo-client.sh cancel            Operator cancel of the active response
  ./demo-client.sh crash             Trigger demo-mode container crash
  ./demo-client.sh delete            DELETE /responses/{id}
  ./demo-client.sh status            Show local session info + server snapshot
  ./demo-client.sh logs              Stream container stdout/stderr via azd
  ./demo-client.sh reset             Clear local session state

Environment overrides:
  ENDPOINT     Foundry agent protocols endpoint (set to your deployment).
  API_VERSION  Default: v1.
  MODEL        Default: gpt-4.1-mini.
USAGE
}

# ── Dispatch ──────────────────────────────────────────────────────────────────

case "${1:-}" in
    start)   shift; cmd_start "${1:-}" ;;
    stream)  cmd_stream ;;
    steer)   shift; cmd_steer "${1:-}" ;;
    cancel)  cmd_cancel ;;
    crash)   cmd_crash ;;
    delete)  cmd_delete ;;
    status)  cmd_status ;;
    logs)    shift; cmd_logs "$@" ;;
    reset)   cmd_reset ;;
    -h|--help|help|"") usage ;;
    *)
        echo -e "\033[31mUnknown command: $1\033[0m" >&2
        usage
        exit 1
        ;;
esac
