#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# Resilient Research Agent — Demo Client
#
# Showcases three platform capabilities of the resilient-task primitive
# (all empirically validated against a hosted Foundry deployment):
#   1. LONG-RUNNING TASKS — the framework's PATCH .../tasks/<id> lease
#      renewals (every ~30s) keep the platform's sandbox idle-reclaim
#      timer fresh, so a single run stays warm well past the 15-min
#      eviction window without any client-side keepalive ingress.
#   2. CRASH RECOVERY — when the container dies, the platform's nanny
#      worker restarts it within ~1 min on its own (no new ingress
#      needed); the resilient task auto-resumes from its last checkpoint.
#   3. STEERING — sending a new turn while a turn is still running
#      causes the agent to wind down at the next checkpoint and start
#      fresh on the new topic.
#
# Commands:
#   ./demo-client.sh start "<topic>"   Dispatch and stream a fresh research run
#   ./demo-client.sh stream            Reconnect to the active run (no fresh POST)
#   ./demo-client.sh steer "<topic>"   Queue a steering input — agent winds down
#                                      current turn at next checkpoint and switches
#   ./demo-client.sh crash             Kill the process (DEMO_MODE=1 on server)
#   ./demo-client.sh cancel            Operator cancel of the active run
#   ./demo-client.sh status            Show local session info
#   ./demo-client.sh logs              Stream container stdout/stderr via azd
#   ./demo-client.sh reset             Clear local session state
# ─────────────────────────────────────────────────────────────────────────────

set -uo pipefail

# ── Config ────────────────────────────────────────────────────────────────────

# Point at your own hosted deployment. After `azd deploy`, this script
# AUTO-RESOLVES the endpoint from your azd env
# (AGENT_RESILIENT_RESEARCH_AGENT_DOTNET_INVOCATIONS_ENDPOINT) when run from the demo
# directory — no manual setup needed. To override (e.g. a different project or
# a local server), export the ENDPOINT env var instead of editing this default.
ENDPOINT="${ENDPOINT:-https://<account>.services.ai.azure.com/api/projects/<project>/agents/resilient-research-agent-dotnet/endpoint/protocols}"
API_VERSION="v1"
SESSION_FILE=".demo-session"

# ── Colors ────────────────────────────────────────────────────────────────────

BOLD='\033[1m'
DIM='\033[2m'
GREEN='\033[32m'
YELLOW='\033[33m'
RED='\033[31m'
CYAN='\033[36m'
MAGENTA='\033[35m'
BLUE='\033[34m'
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
        echo "SESSION_ID=\"${SESSION_ID:-}\""
        echo "INV_ID=\"${INV_ID:-}\""
        echo "LAST_EVENT_ID=\"${LAST_EVENT_ID:-0}\""
    } > "$SESSION_FILE"
}

ensure_token() {
    ensure_endpoint
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

# Resolve ENDPOINT. If the caller did not override it via the ENDPOINT env
# var (so it is still the <account>/<project> placeholder), auto-resolve it
# from the azd environment that `azd deploy` populates. The azd value
# AGENT_RESILIENT_RESEARCH_AGENT_DOTNET_INVOCATIONS_ENDPOINT looks like
#   .../agents/<name>/endpoint/protocols/invocations?api-version=...
# and this script appends `/invocations?api-version=$API_VERSION` itself, so
# we strip the `/invocations?...` tail to recover the protocols base.
ensure_endpoint() {
    if [[ "$ENDPOINT" == *"<account>"* || "$ENDPOINT" == *"<project>"* ]]; then
        local azd_inv
        azd_inv="$(azd env get-value AGENT_RESILIENT_RESEARCH_AGENT_DOTNET_INVOCATIONS_ENDPOINT 2>/dev/null || true)"
        if [[ "$azd_inv" == http* ]]; then
            ENDPOINT="${azd_inv%%/invocations*}"
        fi
    fi
    if [[ "$ENDPOINT" == *"<account>"* || "$ENDPOINT" == *"<project>"* ]]; then
        echo -e "${RED}ENDPOINT is not configured.${RESET}" >&2
        echo -e "${DIM}Run this from the demo dir after 'azd deploy' (auto-resolves from the azd env)," >&2
        echo -e "or set it explicitly, e.g.:${RESET}" >&2
        echo -e "  export ENDPOINT=\"https://<account>.services.ai.azure.com/api/projects/<project>/agents/resilient-research-agent-dotnet/endpoint/protocols\"" >&2
        exit 1
    fi
}

# Read a top-level JSON field. Returns empty string on missing/null. Used
# only by the one-shot POST helpers below (start / steer) to extract
# invocation_id / session_id from the dispatch response. The SSE stream
# path does its own parsing in the python renderer.

# Generate a lowercase UUID. Prefer uuidgen; fall back to the kernel RNG or
# python so the demo works on minimal images where uuidgen isn't installed.
_uuid() {
    if command -v uuidgen >/dev/null 2>&1; then
        uuidgen | tr '[:upper:]' '[:lower:]'
    elif [[ -r /proc/sys/kernel/random/uuid ]]; then
        cat /proc/sys/kernel/random/uuid
    else
        python3 -c "import uuid; print(uuid.uuid4())"
    fi
}

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
#  - At LLM emit rate (50-100 tok/s) the original bash 'while read |
#    printf' loop made the real interactive terminal the bottleneck:
#    one printf-per-token caused syscall thrash and built up a backlog
#    that hid the EOF (real crash signal) behind minutes of TTY draining.
#  - python with select() + a small in-memory token buffer (flushed
#    every FLUSH_MS) writes the terminal in batches — ~20x fewer
#    syscalls in steady state, no backlog, EOF is observed promptly.
#  - The renderer trusts EOF on stdin as the authoritative crash signal.
#    No time-based "is the stream stale?" heuristic — those mis-fire
#    during the demo's legitimate 30s cooldowns between subcalls/phases.
#    When curl closes (server crash, network drop, ctrl-c) the renderer
#    sees EOF and exits. When the server emits 'done' or 'run_complete'
#    the renderer exits cleanly. There is no third path.
#  - Renderer formatting and color codes match the previous bash version
#    exactly so prior demo expectations still hold.
#
# Contract with bash:
#   stdin   = raw SSE frames from curl (id: N / data: ...)
#   env     = $INITIAL_EVENT_ID (resume cursor), $STATE_FILE (path to write
#             back LAST_EVENT_ID + STREAM_RESULT on exit), $FLUSH_MS
#   stdout  = rendered output
#   exit    = 0 normally; non-zero only on hard errors

_PY_RENDERER='
import json, os, sys, select, time
from datetime import datetime, timezone

# Bring the env-provided knobs in once.
INITIAL_EVENT_ID = int(os.environ.get("INITIAL_EVENT_ID", "0") or "0")
STATE_FILE       = os.environ.get("STATE_FILE", "")
FLUSH_MS         = float(os.environ.get("FLUSH_MS", "50"))

# CRITICAL: This entire block lives inside a bash heredoc delimited by
# the apostrophe character (the bash assignment `_PY_RENDERER=` then an
# opening apostrophe, opaque content, closing apostrophe at column 1
# of an otherwise empty line). Any literal apostrophe in Python code
# below will silently end the heredoc and truncate the script — debug
# symptom is a NameError several lines later. Use double quotes for
# every Python string literal. Keys we pull from event dicts are
# aliased to module-level CONSTANTS up here so the per-event code
# stays readable without inline string literals becoming a foot-gun.
_DSEC = "duration_sec"

# ANSI palette — mirrors demo-client.sh.
BOLD, DIM = "\033[1m", "\033[2m"
GREEN, YELLOW, RED = "\033[32m", "\033[33m", "\033[31m"
CYAN, MAGENTA, BLUE = "\033[36m", "\033[35m", "\033[34m"
RESET = "\033[0m"

out = sys.stdout
def write(s): out.write(s)
def flush(): out.flush()

def now_utc():
    return datetime.now(timezone.utc).strftime("%H:%M:%SZ")

last_event_id = INITIAL_EVENT_ID
result        = "disconnected"
token_buf     = []                  # collected token content
last_flush    = time.monotonic()

def flush_tokens():
    global token_buf, last_flush
    if token_buf:
        write("".join(token_buf))
        flush()
        token_buf = []
    last_flush = time.monotonic()

def render_block(evt):
    """Render any non-token event with the same shape as the old bash render."""
    t = evt.get("type", "")
    n = now_utc()
    if t == "run_start":
        topic   = evt.get("topic", "")
        em      = evt.get("entry_mode", "")
        total   = evt.get("total_phases", "")
        uptime  = evt.get("server_uptime_sec", "")
        srv     = evt.get("server_time_utc", "")
        prior   = evt.get("prior_topic")
        write("\n")
        write(f"{BOLD}{CYAN}{chr(0x2550)*62}{RESET}\n")
        write(f"{DIM}[{n}]{RESET} {BOLD}{CYAN}\u25b6 Run start{RESET}    topic={BOLD}{topic}{RESET}  ({total} phases)\n")
        if prior:
            write(f"  {YELLOW}(steered from prior topic: {prior}){RESET}\n")
        write(f"  entry_mode={em}   server_time={srv}   uptime={uptime}s\n")
        write(f"{BOLD}{CYAN}{chr(0x2550)*62}{RESET}\n")
    elif t == "recovered":
        c, total = evt.get("completed_phases", ""), evt.get("total_phases", "")
        srv, uptime = evt.get("server_time_utc", ""), evt.get("server_uptime_sec", "")
        write("\n")
        write(f"{DIM}[{n}]{RESET} {BOLD}{GREEN}\U0001f501 Recovered from crash{RESET}   resuming from phase {c}/{total}\n")
        write(f"  server_time={srv}   uptime={uptime}s  {DIM}(uptime ~0s = fresh container){RESET}\n")
    elif t == "phase_start":
        ph, total = evt.get("phase", ""), evt.get("total", "")
        title = evt.get("title", "")
        srv, uptime = evt.get("server_time_utc", ""), evt.get("server_uptime_sec", "")
        write("\n")
        write(f"{BOLD}{BLUE}{chr(0x2500)*62}{RESET}\n")
        write(f"{DIM}[{n}]{RESET} {BOLD}{BLUE}\u25b6 Phase {ph}/{total}{RESET} \u2014 {title}\n")
        write(f"  \u23f0 server_time={srv}   uptime={uptime}s\n")
        write(f"{BOLD}{BLUE}{chr(0x2500)*62}{RESET}\n")
    elif t == "subcall_start":
        role = evt.get("role", "")
        idx, of = evt.get("index", ""), evt.get("of", "")
        write(f"\n{DIM}  [{n}]  [{role} {idx}/{of}] \u2500\u2500\u2500{RESET}\n")
    elif t == "subcall_end":
        write("\n")
    elif t == "phase_end":
        ph, total = evt.get("phase", ""), evt.get("total", "")
        title = evt.get("title", "")
        srv, uptime, dur = evt.get("server_time_utc", ""), evt.get("server_uptime_sec", ""), evt.get("duration_sec", "")
        write(f"\n{DIM}[{n}]{RESET} {GREEN}\u2705 Phase {ph}/{total} done{RESET} \u2014 {title}\n")
        write(f"  \u23f0 server_time={srv}   uptime={uptime}s   \u23f1  duration={dur}s\n")
    elif t == "winding_down":
        cause = evt.get("cause", ""); c = evt.get("completed_phases", "")
        total = evt.get("total_phases", ""); pend = evt.get("pending_steering_inputs", "")
        srv, uptime = evt.get("server_time_utc", ""), evt.get("server_uptime_sec", "")
        write(f"\n{DIM}[{n}]{RESET} {BOLD}{MAGENTA}\u2193 Winding down{RESET}   cause={cause}   completed={c}/{total}   pending_steers={pend}\n")
        write(f"  \u23f0 server_time={srv}   uptime={uptime}s\n")
    elif t == "cooldown":
        # Server is intentionally sleeping (between subcalls or phases).
        # Render a single low-key line so the terminal is not silent.
        # NOTE: keep Python string literals in this heredoc strictly
        # double-quoted. A literal apostrophe ends the surrounding
        # bash heredoc and causes a confusing NameError several lines
        # later when the truncated script is parsed.
        try:
            dur_str = f"{float(evt.get(_DSEC, 0)):.0f}"
        except (TypeError, ValueError):
            dur_str = str(evt.get(_DSEC, "?"))
        stage = evt.get("stage", "")
        ph    = evt.get("phase", "")
        total = evt.get("total", "")
        sub   = evt.get("subcall")
        of    = evt.get("of")
        label = "between phases" if stage == "inter_phase" else "between subcalls"
        if stage == "inter_phase":
            detail = f"next: phase {ph}/{total}"
        elif sub is not None and of is not None:
            detail = f"next: subcall {sub}/{of} in phase {ph}/{total}"
        else:
            detail = f"phase {ph}/{total}"
        write(f"{DIM}[{n}]   ...cooling down {dur_str}s ({label}) \u2014 {detail}{RESET}\n")
    elif t == "run_complete":
        total = evt.get("phases_completed", "")
        srv, uptime = evt.get("server_time_utc", ""), evt.get("server_uptime_sec", "")
        write(f"\n{BOLD}{GREEN}{chr(0x2550)*62}{RESET}\n")
        write(f"{DIM}[{n}]{RESET} {BOLD}{GREEN}\u2705 Run complete{RESET}   {total} phases   \u23f0 {srv}   uptime={uptime}s\n")
        write(f"{BOLD}{GREEN}{chr(0x2550)*62}{RESET}\n")
    elif t == "done":
        reason = evt.get("reason")
        msg = f" ({reason})" if reason else ""
        col = YELLOW if reason else GREEN
        write(f"\n{DIM}[{n}]{RESET} {col}\u2550\u2550 Stream done{msg} \u2550\u2550{RESET}\n")
    else:
        write(f"{DIM}[{n}] [unknown event] {json.dumps(evt)}{RESET}\n")
    flush()

stdin_fd = sys.stdin.fileno()

try:
    pending = b""
    while True:
        deadline = last_flush + FLUSH_MS / 1000.0
        timeout = max(0.0, deadline - time.monotonic())
        r, _, _ = select.select([stdin_fd], [], [], timeout)
        if r:
            try:
                chunk = os.read(stdin_fd, 65536)
            except OSError:
                chunk = b""
            if not chunk:
                # EOF — server (or proxy) closed the SSE stream. This is
                # the authoritative crash/disconnect signal.
                flush_tokens()
                break
            pending += chunk
            # Process complete lines only.
            while b"\n" in pending:
                line_b, pending = pending.split(b"\n", 1)
                line = line_b.decode("utf-8", errors="replace").rstrip("\r")
                if not line or line.startswith(":"):
                    continue
                if line.startswith("id:"):
                    try:
                        last_event_id = int(line[3:].strip())
                    except ValueError:
                        pass
                    continue
                if not line.startswith("data:"):
                    continue
                payload = line[5:].lstrip()
                try:
                    evt = json.loads(payload)
                except json.JSONDecodeError:
                    continue
                t = evt.get("type", "")
                if t == "token":
                    # Hot path: buffer content. Periodic flush + flush on
                    # non-token gives smooth visual output without
                    # per-token TTY syscall thrash.
                    c = evt.get("content")
                    if isinstance(c, str):
                        token_buf.append(c)
                else:
                    # Flush any pending tokens BEFORE emitting block event
                    # so they appear in the right place visually.
                    flush_tokens()
                    render_block(evt)
                    if t in ("done", "run_complete"):
                        result = "complete"
                        # Drain any remaining buffered tokens (none if we
                        # just flushed) and exit.
                        flush_tokens()
                        raise StopIteration
        else:
            # Periodic flush deadline reached with no data.
            flush_tokens()
            # No watchdog: EOF on stdin (above) is the authoritative
            # crash/disconnect signal. The select() timeout just drives
            # the periodic token-buffer flush.
except StopIteration:
    pass
except KeyboardInterrupt:
    flush_tokens()
finally:
    if STATE_FILE:
        try:
            with open(STATE_FILE, "w") as fh:
                fh.write(f"LAST_EVENT_ID={last_event_id}\n")
                fh.write(f"STREAM_RESULT={result}\n")
        except OSError:
            pass
'

# ── SSE reader ───────────────────────────────────────────────────────────────

STREAM_RESULT=""  # "complete" | "disconnected" | "error"

stream_sse() {
    local url="$1"
    STREAM_RESULT="disconnected"

    local state_file
    state_file=$(mktemp)

    # Pipe curl directly into the python renderer. EOF on the pipe is
    # the authoritative disconnect signal — when curl sees the server
    # close the TCP socket it closes its stdout, the renderer sees EOF
    # on stdin, and we exit cleanly. No watchdog, no PID juggling.
    INITIAL_EVENT_ID="${LAST_EVENT_ID:-0}" \
    STATE_FILE="$state_file" \
    FLUSH_MS="${FLUSH_MS:-50}" \
        bash -c 'curl -sN -X GET \
            -H "Authorization: Bearer '"$TOKEN"'" \
            -H "Accept: text/event-stream" \
            -H "Foundry-Features: HostedAgents=V1Preview" \
            "'"$url"'" | python3 -u -c "$1"' _ "$_PY_RENDERER"

    if [[ -f "$state_file" ]]; then
        # shellcheck disable=SC1090
        source "$state_file"
        rm -f "$state_file"
    fi
    save_session
}

# ── Commands ──────────────────────────────────────────────────────────────────

cmd_start() {
    local topic="${1:-Research the future of quantum computing}"
    SESSION_ID="demo-$(_uuid)"
    INV_ID=""
    LAST_EVENT_ID="0"
    save_session
    ensure_token

    echo -e "${GREEN}New session: ${SESSION_ID}${RESET}"
    echo -e "${DIM}Topic: ${topic}${RESET}"

    local response
    response=$(curl -s -X POST \
        -H "Authorization: Bearer $TOKEN" \
        -H "Content-Type: application/json" \
        -H "Foundry-Features: HostedAgents=V1Preview" \
        -d "{\"message\": \"${topic}\"}" \
        "${ENDPOINT}/invocations?api-version=${API_VERSION}&agent_session_id=${SESSION_ID}")
    INV_ID=$(_jq "$response" invocation_id)
    SESSION_ID=$(_jq "$response" session_id)
    save_session
    echo -e "${DIM}Dispatched: invocation_id=${INV_ID}${RESET}"

    echo ""
    echo -e "${BOLD}Streaming. ${DIM}Use Ctrl-C to detach; reconnect later with './demo-client.sh stream'.${RESET}"
    stream_sse "${ENDPOINT}/invocations/${INV_ID}?api-version=${API_VERSION}"
    _report_stream_result
}

cmd_stream() {
    load_session
    if [[ -z "${INV_ID:-}" ]]; then
        echo -e "${RED}No active session. Run './demo-client.sh start \"<topic>\"' first.${RESET}" >&2
        exit 1
    fi
    ensure_token

    echo -e "${DIM}Reconnecting to invocation ${INV_ID}${RESET}"
    local url="${ENDPOINT}/invocations/${INV_ID}?api-version=${API_VERSION}"
    if [[ "${LAST_EVENT_ID:-0}" != "0" ]]; then
        url="${url}&last_event_id=${LAST_EVENT_ID}"
        echo -e "${DIM}Resuming from event ${LAST_EVENT_ID}${RESET}"
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
    if [[ -z "${SESSION_ID:-}" ]]; then
        echo -e "${RED}No active session. Run './demo-client.sh start \"<topic>\"' first.${RESET}" >&2
        exit 1
    fi
    ensure_token

    echo -e "${BOLD}${MAGENTA}Steering session ${SESSION_ID} to: ${topic}${RESET}"

    # Send a fresh POST. Because the task is steerable and an in-progress
    # run exists, the framework queues this as a steering input.
    local response
    response=$(curl -s -X POST \
        -H "Authorization: Bearer $TOKEN" \
        -H "Content-Type: application/json" \
        -H "Foundry-Features: HostedAgents=V1Preview" \
        -d "{\"message\": \"${topic}\"}" \
        "${ENDPOINT}/invocations?api-version=${API_VERSION}&agent_session_id=${SESSION_ID}")
    echo -e "${DIM}Response: ${response}${RESET}"
    local new_inv
    new_inv=$(_jq "$response" invocation_id)
    if [[ -n "$new_inv" ]]; then
        INV_ID="$new_inv"
        LAST_EVENT_ID="0"
        save_session
        echo -e "${DIM}New invocation: ${INV_ID}. Use './demo-client.sh stream' to attach.${RESET}"
    fi
}

cmd_crash() {
    load_session
    if [[ -z "${SESSION_ID:-}" ]]; then
        echo -e "${RED}No active session. Run './demo-client.sh start \"<topic>\"' first.${RESET}" >&2
        exit 1
    fi
    ensure_token

    echo -e "${RED}${BOLD}💥 Crashing the agent container...${RESET}"
    echo -e "${DIM}Session: ${SESSION_ID}${RESET}"

    # The platform only proxies /invocations* — we use the special
    # "crash" sentinel message, which the agent (when DEMO_MODE=1)
    # interprets as "exit the process".
    local response
    response=$(curl -s -X POST \
        -H "Authorization: Bearer $TOKEN" \
        -H "Content-Type: application/json" \
        -H "Foundry-Features: HostedAgents=V1Preview" \
        -d '{"message": "crash"}' \
        "${ENDPOINT}/invocations?api-version=${API_VERSION}&agent_session_id=${SESSION_ID}")
    echo -e "${DIM}Response: ${response}${RESET}"
    echo ""
    echo -e "${YELLOW}The container will exit. The platform's nanny worker brings it back${RESET}"
    echo -e "${YELLOW}within ~1 min on its own (no client ingress needed) and the resilient${RESET}"
    echo -e "${YELLOW}task auto-recovers from its last checkpoint.${RESET}"
    echo ""
    echo -e "${DIM}Run './demo-client.sh stream' whenever you're ready to reconnect.${RESET}"
    echo -e "${DIM}Look for a 'Recovered from crash' marker (uptime resets to ~0).${RESET}"
}

cmd_cancel() {
    load_session
    if [[ -z "${INV_ID:-}" ]]; then
        echo -e "${RED}No active session. Run './demo-client.sh start \"<topic>\"' first.${RESET}" >&2
        exit 1
    fi
    ensure_token

    echo -e "${YELLOW}🛑 Cancelling invocation ${INV_ID}${RESET}"
    local response
    response=$(curl -s -X POST \
        -H "Authorization: Bearer $TOKEN" \
        -H "Content-Type: application/json" \
        -H "Foundry-Features: HostedAgents=V1Preview" \
        -d '{}' \
        "${ENDPOINT}/invocations/${INV_ID}/cancel?api-version=${API_VERSION}")
    echo -e "${GREEN}${response}${RESET}"
}

cmd_status() {
    load_session
    if [[ -f "$SESSION_FILE" ]]; then
        echo -e "${CYAN}Session ID:${RESET}    ${SESSION_ID:-<none>}"
        echo -e "${CYAN}Invocation ID:${RESET} ${INV_ID:-<none>}"
        echo -e "${CYAN}Last event ID:${RESET} ${LAST_EVENT_ID:-0}"
    else
        echo -e "${DIM}No local session.${RESET}"
    fi
}

cmd_logs() {
    load_session
    if [[ -z "${SESSION_ID:-}" ]]; then
        echo -e "${RED}No active session. Run './demo-client.sh start \"<topic>\"' first.${RESET}" >&2
        exit 1
    fi
    echo -e "${DIM}Streaming container stdout/stderr for session ${SESSION_ID}${RESET}"
    azd ai agent monitor --session-id "${SESSION_ID}" --follow
}

cmd_reset() {
    rm -f "$SESSION_FILE"
    echo -e "${GREEN}Session cleared.${RESET}"
}

_report_stream_result() {
    case "$STREAM_RESULT" in
        complete)
            ;;
        disconnected)
            echo ""
            echo -e "${YELLOW}── Stream disconnected ──${RESET}"
            echo -e "${DIM}The agent may still be running on the server.${RESET}"
            echo -e "${DIM}Reconnect with: ./demo-client.sh stream${RESET}"
            ;;
        error)
            echo -e "${RED}── Stream error ──${RESET}" ;;
    esac
}

# ── Main ──────────────────────────────────────────────────────────────────────

usage() {
    cat <<EOF
${BOLD}Resilient Research Agent — Demo Client${RESET}

Commands:
  ${BOLD}start "<topic>"${RESET}    Dispatch a fresh research run and stream it
  ${BOLD}stream${RESET}             Reconnect to the active run (resumes from last_event_id)
  ${BOLD}steer "<topic>"${RESET}    Queue a steering input — agent winds down at next
                     checkpoint and starts fresh on the new topic
  ${BOLD}crash${RESET}              Kill the container (POST /invocations with message="crash";
                     requires DEMO_MODE=1 on the server image)
  ${BOLD}cancel${RESET}             Cooperative cancel of the active run
  ${BOLD}status${RESET}             Show local session info
  ${BOLD}logs${RESET}               Stream container stdout/stderr (azd ai agent monitor)
  ${BOLD}reset${RESET}              Clear local session state

Three-terminal workflow:
  Terminal 1: ./demo-client.sh start "quantum computing"     # streams ~33 min of phases
  Terminal 2: ./demo-client.sh logs                          # peek at server logs
  Terminal 3: ./demo-client.sh crash                         # any time → nanny restores ~1 min later
              ./demo-client.sh steer "fusion energy"         # mid-run pivot
EOF
}

case "${1:-}" in
    start)   shift; cmd_start "${1:-}" ;;
    stream)  cmd_stream ;;
    steer)   shift; cmd_steer "${1:-}" ;;
    crash)   cmd_crash ;;
    cancel)  cmd_cancel ;;
    status)  cmd_status ;;
    logs)    cmd_logs ;;
    reset)   cmd_reset ;;
    *)       usage ;;
esac
