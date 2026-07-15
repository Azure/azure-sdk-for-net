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
# SESSION AFFINITY (why crash/steer land on the SAME container):
#   In the hosted platform one `agent_session_id` == one sandbox/container.
#   This client generates a single session id up front and pins it on the
#   BODY of every *new-response* POST (start, steer, crash) via the
#   `agent_session_id` property — so they all route to the SAME sandbox.
#   That is what makes `crash` kill the container running your response
#   (and `steer` queue onto it). Operations on an EXISTING response
#   (GET/stream, cancel, delete) need no session id — the platform routes
#   them by `response_id`. The session id is persisted in .demo-session so
#   it is shared across terminals, and is cleared ONLY by `reset`.
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
# Deployed agent name (used by `logs` and the post-crash recovery watch).
AGENT_NAME="${AGENT_NAME:-resilient-responses-agent-demo-dotnet}"

# ── Colors ────────────────────────────────────────────────────────────────────

BOLD='\033[1m'
DIM='\033[2m'
GREEN='\033[32m'
YELLOW='\033[33m'
RED='\033[31m'
CYAN='\033[36m'
RESET='\033[0m'

# ── Command timing ──────────────────────────────────────────────────────────
# Every command prints when it was triggered and when it ended (with elapsed
# wall-clock), so a stream/crash/recover run has clear start/stop markers even
# across terminals. Timestamps are UTC ISO-8601 (matches the server log clock).

_now_iso() { date -u +%Y-%m-%dT%H:%M:%SZ; }

# Emitted at process exit (registered by the dispatch trap) so the end banner
# prints even when a command exits early (e.g. missing session, usage error).
_CMD_LABEL=""
_CMD_START_EPOCH=""
_print_end_banner() {
    local rc=$?
    [[ -z "$_CMD_LABEL" ]] && return 0
    local end_epoch elapsed
    end_epoch=$(date -u +%s)
    elapsed=$(( end_epoch - ${_CMD_START_EPOCH:-end_epoch} ))
    echo -e "${DIM}──────────────────────────────────────────────────────────────${RESET}" >&2
    echo -e "${DIM}⏹ ${_CMD_LABEL} ended  @ $(_now_iso)  (elapsed ${elapsed}s, exit ${rc})${RESET}" >&2
    _CMD_LABEL=""  # guard against double-print
}

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
        echo "SESSION_ID=\"${SESSION_ID:-}\""
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

# Generate a client-side session id if we don't already have one. One
# session id == one sandbox/container on the platform, so we create it
# ONCE and pin it on every new-response POST (start/steer/crash) to keep
# them on the same sandbox. Cleared only by `reset`.
ensure_session_id() {
    load_session
    if [[ -z "${SESSION_ID:-}" ]]; then
        if command -v uuidgen >/dev/null 2>&1; then
            SESSION_ID="demo-$(uuidgen | tr '[:upper:]' '[:lower:]')"
        else
            SESSION_ID="demo-$(python3 -c 'import uuid; print(uuid.uuid4())')"
        fi
        save_session
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
    local hdr_file=".demo-session.hdr"
    rm -f "$seq_file" "$id_file" "$hdr_file"

    STREAM_RESULT="ok"
    local curl_args=("${hdrs[@]}")
    if [[ "$method" == "POST" ]]; then
        curl_args+=(-X POST -H "Content-Type: application/json" --data "$post_body")
    fi
    # -D dumps the response headers (incl. x-agent-session-id, which the
    # platform returns on every /responses call) while the SSE body streams
    # to the renderer pipe. We use it to confirm sandbox affinity afterwards.
    curl -sS -N -D "$hdr_file" "${curl_args[@]}" "$url" 2>/dev/null | python3 -u -c "
import json, sys, os, signal
from datetime import datetime, timezone

SEQ_FILE = '$seq_file'
ID_FILE = '$id_file'

def _ts():
    # UTC ISO-8601 (matches the server log clock) for correlating client-side
    # render time with server-side task telemetry.
    return datetime.now(timezone.utc).strftime('%Y-%m-%dT%H:%M:%SZ')

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

# Read the SSE stream line-by-line with NO read-ahead buffering so deltas render
# in the console the instant they arrive (and a mid-stream crash/drop is visible
# immediately, not after a buffer drains). 'for line in sys.stdin' can use CPython's
# internal read-ahead chunking; iter(readline, '') forces one prompt readline() per
# line. Paired with curl -N (no curl output buffering) and python3 -u (unbuffered
# stdout) + per-delta flush() below, this keeps end-to-end latency minimal.
for raw in iter(sys.stdin.readline, ''):
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
            # Extract response id from the first lifecycle event we see, and
            # surface it immediately (rather than only after the stream ends).
            if not _id_saved:
                resp = payload.get('response') or {}
                rid = resp.get('id')
                if rid:
                    _save_id(rid)
                    _id_saved = True
                    sys.stdout.write('\033[36m\u25b6 response_id=' + str(rid) + '\033[0m\n')
                    sys.stdout.flush()
            t = payload.get('type', current_event)
            if t == 'response.output_text.delta':
                sys.stdout.write(payload.get('delta', ''))
                sys.stdout.flush()
            elif t == 'response.output_item.added':
                # Timestamp each output item as it begins rendering so the
                # per-item cadence (and any post-crash gap) is visible.
                idx = payload.get('output_index')
                item = payload.get('item') or {}
                itype = item.get('type') or 'item'
                label = ('#' + str(idx)) if isinstance(idx, int) else ''
                sys.stdout.write('\n\033[2m[' + _ts() + '] \u25b8 output item ' + label +
                                 ' (' + str(itype) + ')\033[0m\n')
                sys.stdout.flush()
            elif t == 'response.output_item.done':
                idx = payload.get('output_index')
                label = ('#' + str(idx)) if isinstance(idx, int) else ''
                sys.stdout.write('\n\033[2m[' + _ts() + '] \u2713 output item ' + label +
                                 ' done\033[0m\n')
                sys.stdout.flush()
            elif t in ('response.created', 'response.in_progress', 'response.completed',
                       'response.failed', 'response.cancelled', 'response.incomplete'):
                resp = payload.get('response') or {}
                status = resp.get('status') or t.split('.')[-1]
                sys.stdout.write('\n\033[2m[' + _ts() + '] [' + t + ' status=' + str(status) + ']\033[0m\n')
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
    # Confirm the platform routed us to the session we pinned. The server
    # echoes the effective session in the x-agent-session-id header. For a
    # POST we sent agent_session_id in the body, so this should match; for a
    # bare GET/stream reconnect (no body) we adopt whatever the platform
    # reports so `logs` still works.
    if [[ -f "$hdr_file" ]]; then
        local sid
        sid=$(grep -i '^x-agent-session-id:' "$hdr_file" | tail -1 | tr -d '\r' | awk '{print $2}')
        if [[ -n "$sid" ]]; then
            if [[ -z "${SESSION_ID:-}" ]]; then
                SESSION_ID="$sid"
            elif [[ "$sid" != "$SESSION_ID" ]]; then
                echo -e "${YELLOW}⚠ server session ${sid} != pinned ${SESSION_ID}${RESET}" >&2
            fi
        fi
        rm -f "$hdr_file"
    fi
    save_session
    if [[ "$rc" -ne 0 && "$rc" -ne 130 ]]; then
        STREAM_RESULT="error"
    fi
}

# ── Commands ──────────────────────────────────────────────────────────────────

cmd_start() {
    local topic="${1:-Research the future of quantum computing}"
    ensure_session_id          # pin one sandbox for the whole demo (only reset clears it)
    RESPONSE_ID=""
    PREV_RESPONSE_ID=""
    LAST_SEQUENCE_NUMBER="0"
    save_session
    ensure_token

    echo -e "${GREEN}Starting a fresh research response${RESET}"
    echo -e "${CYAN}▶ agent_session_id=${SESSION_ID}${RESET} ${DIM}(sandbox affinity — shared across terminals)${RESET}"
    echo -e "${DIM}Topic: ${topic}${RESET}"

    local body
    body=$(python3 -c "
import json, sys
print(json.dumps({
    'model': '$MODEL',
    'input': sys.argv[1],
    'agent_session_id': sys.argv[2],
    'stream': True,
    'store': True,
    'background': True,
}))
" "$topic" "$SESSION_ID")

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
    if [[ -z "${SESSION_ID:-}" ]]; then
        echo -e "${RED}No pinned session. Run './demo-client.sh start' first.${RESET}" >&2
        exit 1
    fi
    ensure_token

    echo -e "${YELLOW}Steering: queuing follow-up turn on response ${RESPONSE_ID}${RESET}"
    echo -e "${DIM}Session: ${SESSION_ID} · New topic: ${topic}${RESET}"

    local body
    body=$(python3 -c "
import json, sys
print(json.dumps({
    'model': '$MODEL',
    'input': sys.argv[1],
    'previous_response_id': sys.argv[2],
    'agent_session_id': sys.argv[3],
    'stream': True,
    'store': True,
    'background': True,
}))
" "$topic" "$RESPONSE_ID" "$SESSION_ID")

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

# Fetch the server-side status for a response id. Echoes the status string
# (e.g. queued/in_progress/completed/failed) or empty on error.
_response_status() {
    local rid="$1"
    ensure_token
    curl -sS \
        -H "Authorization: Bearer ${TOKEN}" \
        -H "Foundry-Features: HostedAgents=V1Preview" \
        "${ENDPOINT}/responses/${rid}?api-version=${API_VERSION}" 2>/dev/null \
        | python3 -c "
import sys, json
try:
    print((json.load(sys.stdin) or {}).get('status') or '')
except Exception:
    print('')
" 2>/dev/null
}

# Read-only recovery watch (NOT an SSE reconnect loop). After a crash we
# respawn 'azd ai agent monitor' for the pinned session — a SINGLE monitor
# attach does not reliably follow the container across the nanny restart, so
# we re-attach in a loop and accumulate the pre-crash + post-restart logs into
# one file. As each recovery marker first appears we print it, and we poll the
# response status via GET until it reaches a terminal state. This is what
# lets you actually SEE the crash → restart → reclaim → recover → completed
# progression that a plain `logs` attach misses.
_watch_recovery() {
    local sid="$1" rid="$2"
    local deadline=$(( $(date +%s) + 200 ))
    local logf; logf="$(mktemp)"
    local saw_crash=0 saw_reclaim=0 saw_recover=0 status="" pre_inst="" restart_seen=0

    echo ""
    echo -e "${BOLD}Watching recovery${RESET} ${DIM}(read-only: re-attaching monitor + polling status across the restart)${RESET}"
    echo -e "${DIM}session=${sid}${RESET}"
    [[ -n "$rid" ]] && echo -e "${DIM}response=${rid}${RESET}"

    # capture the instance that is live BEFORE the crash so we can detect the
    # distinct post-restart worker generation.
    pre_inst=$(timeout 12 azd ai agent monitor "$AGENT_NAME" --session-id "$sid" 2>/dev/null \
        | grep -oE 'instance=worker-[0-9]+-[a-f0-9]+-[0-9]+' | head -1 | sed 's/instance=//')
    [[ -n "$pre_inst" ]] && echo -e "${DIM}pre-crash worker: ${pre_inst}${RESET}"

    while (( $(date +%s) < deadline )); do
        # one bounded monitor attach → append its buffer to the accumulator
        timeout 12 azd ai agent monitor "$AGENT_NAME" --session-id "$sid" >>"$logf" 2>/dev/null

        if [[ "$saw_crash" -eq 0 ]] && grep -q "CRASH triggered via input=crash" "$logf"; then
            saw_crash=1; echo -e "  ${RED}✖ crash fired${RESET} ${DIM}@ $(_now_iso)${RESET} ${DIM}(CRASH triggered via input=crash — exiting in 300ms)${RESET}"
        fi
        # a distinct 2nd worker instance == the container was restarted by the nanny
        if [[ "$restart_seen" -eq 0 ]]; then
            local insts
            insts=$(grep -oE 'instance=worker-[0-9]+-[a-f0-9]+-[0-9]+' "$logf" | sed 's/instance=//' | sort -u)
            local distinct; distinct=$(echo "$insts" | grep -c .)
            if { [[ -n "$pre_inst" ]] && echo "$insts" | grep -qv "^${pre_inst}$" && [[ "$distinct" -ge 2 ]]; } \
               || { [[ -z "$pre_inst" ]] && [[ "$distinct" -ge 2 ]]; }; then
                restart_seen=1
                local newinst; newinst=$(echo "$insts" | grep -v "^${pre_inst}$" | head -1)
                echo -e "  ${YELLOW}↻ container restarted${RESET} ${DIM}@ $(_now_iso)${RESET} ${DIM}new worker: ${newinst:-<new generation>}${RESET}"
            fi
        fi
        if [[ "$saw_reclaim" -eq 0 ]] && grep -q "Reclaimed stale task" "$logf"; then
            saw_reclaim=1
            local rc; rc=$(grep -oE "Reclaimed stale task [^ ]+" "$logf" | head -1)
            echo -e "  ${CYAN}⟳ ${rc:-reclaimed stale task}${RESET} ${DIM}@ $(_now_iso)${RESET}"
            # A stale-task lease can only be reclaimed by a DIFFERENT process,
            # which necessarily means the crashed container was restarted.
            if [[ "$restart_seen" -eq 0 ]]; then
                restart_seen=1
                echo -e "  ${YELLOW}↻ container restarted${RESET} ${DIM}@ $(_now_iso)${RESET} ${DIM}(inferred: stale lease reclaimed by a new process)${RESET}"
            fi
        fi
        if [[ "$saw_recover" -eq 0 ]] && grep -qE "Recovered task .* \(recovery #[0-9]+\)" "$logf"; then
            saw_recover=1
            local rv; rv=$(grep -oE "Recovered task .* \(recovery #[0-9]+\)" "$logf" | head -1)
            echo -e "  ${GREEN}✔ ${rv:-recovered task}${RESET} ${DIM}@ $(_now_iso)${RESET}"
        fi

        if [[ -n "$rid" ]]; then
            status=$(_response_status "$rid")
            case "$status" in
                completed|failed|cancelled|incomplete)
                    echo -e "  ${GREEN}● terminal status=${status}${RESET} ${DIM}@ $(_now_iso)${RESET}"
                    break
                    ;;
            esac
        fi
        sleep 6
    done

    echo ""
    echo -e "${BOLD}Recovery verdict${RESET}"
    echo -e "  crash fired            : $([[ $saw_crash -eq 1 ]] && echo -e "${GREEN}yes${RESET}" || echo -e "${YELLOW}not seen in logs${RESET}")"
    echo -e "  container restarted    : $([[ $restart_seen -eq 1 ]] && echo -e "${GREEN}yes${RESET}" || echo -e "${YELLOW}not observed${RESET}")"
    echo -e "  task reclaimed         : $([[ $saw_reclaim -eq 1 ]] && echo -e "${GREEN}yes${RESET}" || echo -e "${YELLOW}no${RESET}")"
    echo -e "  task recovered         : $([[ $saw_recover -eq 1 ]] && echo -e "${GREEN}yes${RESET}" || echo -e "${YELLOW}no${RESET}")"
    echo -e "  response terminal      : ${status:-<none / no active response>}"
    echo -e "${DIM}full captured log: ${logf}${RESET}"
    if [[ -n "$rid" && "$status" == "completed" && ( $saw_reclaim -eq 1 || $saw_recover -eq 1 ) ]]; then
        echo -e "${GREEN}✔ RECOVERY PROVEN — the crashed run resumed on a new container and completed.${RESET}"
    elif [[ -z "$rid" ]]; then
        echo -e "${YELLOW}Note: no in-flight response was active, so there was nothing to recover —${RESET}"
        echo -e "${YELLOW}the crash only restarted an idle sandbox. Run 'start' first, then 'crash'.${RESET}"
    fi
}

cmd_crash() {
    local watch=1
    if [[ "${1:-}" == "--no-watch" ]]; then watch=0; fi
    load_session
    if [[ -z "${SESSION_ID:-}" ]]; then
        echo -e "${RED}No pinned session. Run './demo-client.sh start' first so the${RESET}" >&2
        echo -e "${RED}crash lands on the SAME sandbox as your running response.${RESET}" >&2
        exit 1
    fi
    ensure_token

    echo -e "${RED}Triggering container crash via input=\"crash\"${RESET}"
    echo -e "${CYAN}▶ agent_session_id=${SESSION_ID}${RESET} ${DIM}(same sandbox as the running response)${RESET}"
    if [[ -n "${RESPONSE_ID:-}" ]]; then
        echo -e "${DIM}Active response to recover: ${RESPONSE_ID}${RESET}"
    else
        echo -e "${YELLOW}⚠ No active response in this session — the crash will restart an idle${RESET}"
        echo -e "${YELLOW}  sandbox with nothing to recover. Run './demo-client.sh start' first,${RESET}"
        echo -e "${YELLOW}  then './demo-client.sh crash' from another terminal, to see recovery.${RESET}"
    fi
    echo -e "${DIM}(requires DEMO_MODE=1 on the server)${RESET}"

    # Capture the ORIGINAL in-flight response id BEFORE the crash POST — the
    # crash's own POST returns a throwaway response that always ends `failed`
    # (the demo crash branch emits response.failed then exits), and stream_sse
    # would overwrite RESPONSE_ID with it. The run we want to watch recover is
    # the one that was already streaming on this sandbox.
    local target_rid="${RESPONSE_ID:-}"

    local body
    body=$(python3 -c "
import json, sys
print(json.dumps({
    'model': '$MODEL',
    'input': 'crash',
    'agent_session_id': sys.argv[1],
    'stream': True,
    'store': True,
    'background': True,
}))
" "$SESSION_ID")
    # The crash POST is pinned to the same sandbox running the response, so
    # its Environment.Exit(137) kills THAT container. The stream drops when
    # the connection breaks — that is the client↔container disconnect you
    # recover from with './demo-client.sh stream'.
    stream_sse "${ENDPOINT}/responses?api-version=${API_VERSION}" "" POST "$body"

    # Restore the original response id (stream_sse just clobbered it with the
    # crash response's id) so 'stream'/'status' still target the real run.
    if [[ -n "$target_rid" ]]; then
        RESPONSE_ID="$target_rid"
        save_session
    fi

    echo ""
    echo -e "${DIM}Container will exit in ~300ms. Platform nanny restarts within ~1 min.${RESET}"

    if [[ "$watch" -eq 1 ]]; then
        # Actively monitor the logs + status across the restart and show the
        # crash → restart → reclaim → recover → completed progression. Pass
        # --no-watch to skip and just fire the crash.
        _watch_recovery "$SESSION_ID" "$target_rid"
    else
        echo -e "${DIM}Skipping recovery watch (--no-watch). Use './demo-client.sh stream' to${RESET}"
        echo -e "${DIM}reconnect to the recovered response after the restart.${RESET}"
    fi
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
    echo "  SESSION_ID:           ${SESSION_ID:-<none>}"
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
    load_session
    local args=("$AGENT_NAME" --follow)
    if [[ -n "${SESSION_ID:-}" ]]; then
        args+=(--session-id "$SESSION_ID")
        echo -e "${DIM}Streaming logs for agent_session_id=${SESSION_ID}${RESET}"
    fi
    echo -e "${DIM}Note: a single monitor attach does not follow the container across a${RESET}"
    echo -e "${DIM}crash/restart. To watch a full crash→recover cycle use './demo-client.sh crash'${RESET}"
    echo -e "${DIM}(it re-attaches automatically and prints the recovery markers).${RESET}"
    azd ai agent monitor "${args[@]}" "$@"
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
  ./demo-client.sh crash             Trigger demo-mode crash, then watch recovery
                                     (crash→restart→reclaim→recover→completed);
                                     append --no-watch to only fire the crash
  ./demo-client.sh delete            DELETE /responses/{id}
  ./demo-client.sh status            Show local session info + server snapshot
  ./demo-client.sh logs              Stream container stdout/stderr via azd
  ./demo-client.sh reset             Clear local session state

Environment overrides:
  ENDPOINT     Foundry agent protocols endpoint (set to your deployment).
  API_VERSION  Default: v1.
  MODEL        Default: gpt-5.4-nano.
  AGENT_NAME   Deployed agent name (default: resilient-responses-agent-demo-dotnet).
USAGE
}

# ── Dispatch ──────────────────────────────────────────────────────────────────

CMD="${1:-}"
case "$CMD" in
    start|stream|steer|cancel|crash|delete|status|logs|reset)
        # Print a triggered/ended banner (with elapsed) around every real
        # command. The EXIT trap guarantees the end banner even on early exit.
        _CMD_LABEL="command '${CMD}'"
        _CMD_START_EPOCH=$(date -u +%s)
        trap _print_end_banner EXIT
        echo -e "${DIM}▶ ${_CMD_LABEL} triggered @ $(_now_iso)${RESET}" >&2
        ;;
esac

case "$CMD" in
    start)   shift; cmd_start "${1:-}" ;;
    stream)  cmd_stream ;;
    steer)   shift; cmd_steer "${1:-}" ;;
    cancel)  cmd_cancel ;;
    crash)   shift; cmd_crash "${1:-}" ;;
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
