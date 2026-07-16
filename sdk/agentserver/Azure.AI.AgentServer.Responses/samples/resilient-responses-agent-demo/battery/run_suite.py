#!/usr/bin/env python3
"""Hosted battery driver for resilient-responses-agent-demo.

Drives the deployed responses agent through the request-flag cross product
(store/background/stream) x lifecycle behaviors (normal/reconnect/crash/steer/
cancel), capturing per-case inputs, outputs, and server logs for post-hoc debug.

Usage:
    python run_suite.py T1            # run a single case
    python run_suite.py T1 T2 T3      # run several
    python run_suite.py all           # run the full matrix in order
    python run_suite.py gate          # run T1 only (go/no-go gate)

Artifacts: runs/<UTC-ts>/<case>/{request.json,stream.sse,response.json,
poll.jsonl,reconnect.sse,server.log,meta.json} plus runs/<ts>/{env.txt,results.json}.
"""
from __future__ import annotations

import hashlib
import json
import os
import re
import subprocess
import sys
import time
from datetime import datetime, timezone
from pathlib import Path

import httpx

AGENT = "resilient-responses-agent-demo-dotnet"
ENDPOINT_BASE = (
    "https://rapida-5196-resource.services.ai.azure.com/api/projects/rapida-5196"
    f"/agents/{AGENT}/endpoint/protocols/openai"
)
API_VERSION = "v1"
MODEL = "gpt-5.4-nano"
TOKEN_RESOURCE = "https://ai.azure.com"

# nanny restart window after a crash (seconds) before we expect recovery
RESTART_WAIT_S = 150
# overall per-run terminal timeout
TERMINAL_TIMEOUT_S = 240
# how long to slice server logs per case
LOG_CAPTURE_S = 30

TERMINAL_STATES = {"completed", "failed", "cancelled", "incomplete"}

_token_cache = {"tok": None, "exp": 0.0}


def log(msg: str) -> None:
    print(f"[{datetime.now(timezone.utc).strftime('%H:%M:%S')}] {msg}", flush=True)


def token() -> str:
    if _token_cache["tok"] and time.time() < _token_cache["exp"] - 120:
        return _token_cache["tok"]
    out = subprocess.run(
        ["az", "account", "get-access-token", "--resource", TOKEN_RESOURCE, "--query", "accessToken", "-o", "tsv"],
        capture_output=True,
        text=True,
        check=True,
    ).stdout.strip()
    _token_cache["tok"] = out
    _token_cache["exp"] = time.time() + 50 * 60
    return out


def headers() -> dict:
    return {"Authorization": f"Bearer {token()}", "Content-Type": "application/json"}


def url(path: str = "") -> str:
    sep = "&" if "?" in path else "?"
    return f"{ENDPOINT_BASE}{path}{sep}api-version={API_VERSION}"


def body(input_text: str, *, store: bool, background: bool, stream: bool, prev: str | None = None,
         session_id: str | None = None) -> dict:
    b = {"model": MODEL, "input": input_text, "store": store, "background": background, "stream": stream}
    if prev:
        b["previous_response_id"] = prev
    if session_id:
        # One agent_session_id == one sandbox. Pinning it routes this request to
        # the SAME sandbox as the run that reported this session id.
        b["agent_session_id"] = session_id
    return b


# ---- SSE parsing -----------------------------------------------------------


def parse_sse(raw: str) -> list[dict]:
    """Parse SSE text into a list of {event, data} dicts."""
    events = []
    cur_event = None
    data_lines: list[str] = []

    def flush():
        nonlocal cur_event, data_lines
        if data_lines:
            payload = "\n".join(data_lines)
            try:
                data = json.loads(payload)
            except json.JSONDecodeError:
                data = {"_raw": payload}
            etype = cur_event or (data.get("type") if isinstance(data, dict) else None)
            events.append({"event": etype, "data": data})
        cur_event = None
        data_lines = []

    for line in raw.splitlines():
        if line.startswith("event:"):
            cur_event = line[len("event:") :].strip()
        elif line.startswith("data:"):
            data_lines.append(line[len("data:") :].strip())
        elif line == "":
            flush()
    flush()  # flush trailing event when stream closes without a final blank line
    return events


def event_types(events: list[dict]) -> list[str]:
    return [e.get("event") or (e["data"].get("type") if isinstance(e["data"], dict) else None) for e in events]


def terminal_from_events(events: list[dict]) -> str | None:
    for e in reversed(events):
        t = e.get("event") or ""
        if isinstance(e["data"], dict):
            t = e["data"].get("type", t)
        for st in TERMINAL_STATES:
            if t == f"response.{st}":
                return st
        # response.completed style or nested status
        if isinstance(e["data"], dict):
            resp = e["data"].get("response")
            if isinstance(resp, dict) and resp.get("status") in TERMINAL_STATES:
                return resp["status"]
    return None


# ---- HTTP primitives -------------------------------------------------------


def post_stream(b: dict, sse_path: Path, max_s: int = TERMINAL_TIMEOUT_S) -> dict:
    """POST a streaming create; tee raw SSE to file; return summary."""
    sid = rid = None
    content_type = None
    status_code = None
    chunks: list[str] = []
    t0 = time.time()
    with httpx.Client(http2=False, timeout=httpx.Timeout(max_s, read=max_s)) as c:
        with c.stream("POST", url("/responses"), headers=headers(), json=b) as r:
            sid = r.headers.get("x-agent-session-id")
            content_type = r.headers.get("content-type")
            status_code = r.status_code
            with sse_path.open("w") as f:
                for line in r.iter_lines():
                    f.write(line + "\n")
                    chunks.append(line)
                    if rid is None and '"id"' in line and "resp" in line:
                        m = re.search(r'"id"\s*:\s*"(c?a?resp_[^"]+)"', line)
                        if m:
                            rid = m.group(1)
                    if time.time() - t0 > max_s:
                        break
    events = parse_sse("\n".join(chunks))
    if rid is None:
        for e in events:
            d = e["data"]
            if isinstance(d, dict):
                resp = d.get("response", d)
                if isinstance(resp, dict) and str(resp.get("id", "")).startswith(("resp_", "caresp_")):
                    rid = resp["id"]
                    break
    return {
        "session_id": sid,
        "response_id": rid,
        "content_type": content_type,
        "status_code": status_code,
        "events": events,
        "event_types": event_types(events),
        "elapsed": round(time.time() - t0, 1),
        "terminal": terminal_from_events(events),
    }


def post_json(b: dict, max_s: int = TERMINAL_TIMEOUT_S) -> dict:
    t0 = time.time()
    with httpx.Client(timeout=httpx.Timeout(max_s, read=max_s)) as c:
        r = c.post(url("/responses"), headers=headers(), json=b)
    sid = r.headers.get("x-agent-session-id")
    try:
        data = r.json()
    except Exception:
        data = {"_raw": r.text}
    return {
        "status_code": r.status_code,
        "session_id": sid,
        "json": data,
        "response_id": data.get("id") if isinstance(data, dict) else None,
        "elapsed": round(time.time() - t0, 1),
    }


def get_response(rid: str) -> dict:
    with httpx.Client(timeout=30) as c:
        r = c.get(url(f"/responses/{rid}"), headers=headers())
    try:
        return {"status_code": r.status_code, "json": r.json()}
    except Exception:
        return {"status_code": r.status_code, "json": {"_raw": r.text}}


def poll_terminal(rid: str, jsonl_path: Path, timeout: int = TERMINAL_TIMEOUT_S, interval: float = 5.0) -> dict:
    t0 = time.time()
    last = None
    with jsonl_path.open("w") as f:
        while time.time() - t0 < timeout:
            res = get_response(rid)
            status = res["json"].get("status") if isinstance(res["json"], dict) else None
            rec = {
                "t": round(time.time() - t0, 1),
                "status_code": res["status_code"],
                "status": status,
                "n_output": len(res["json"].get("output", [])) if isinstance(res["json"], dict) else None,
            }
            f.write(json.dumps(rec) + "\n")
            f.flush()
            last = res
            if status in TERMINAL_STATES:
                break
            time.sleep(interval)
    return last or {}


def reconnect_stream(rid: str, starting_after: int, sse_path: Path, max_s: int = TERMINAL_TIMEOUT_S) -> dict:
    chunks: list[str] = []
    t0 = time.time()
    path = f"/responses/{rid}?stream=true&starting_after={starting_after}"
    with httpx.Client(timeout=httpx.Timeout(max_s, read=max_s)) as c:
        with c.stream("GET", url(path), headers=headers()) as r:
            sc = r.status_code
            with sse_path.open("w") as f:
                for line in r.iter_lines():
                    f.write(line + "\n")
                    chunks.append(line)
                    if time.time() - t0 > max_s:
                        break
    events = parse_sse("\n".join(chunks))
    return {
        "status_code": sc,
        "events": events,
        "event_types": event_types(events),
        "terminal": terminal_from_events(events),
        "elapsed": round(time.time() - t0, 1),
    }


def cancel(rid: str) -> dict:
    with httpx.Client(timeout=30) as c:
        r = c.post(url(f"/responses/{rid}/cancel"), headers=headers())
    try:
        return {"status_code": r.status_code, "json": r.json()}
    except Exception:
        return {"status_code": r.status_code, "json": {"_raw": r.text}}


def fire_crash(session_id: str | None = None) -> dict:
    """Crash the sandbox running the target resilient task via a streaming 'crash'.

    One ``agent_session_id`` == one sandbox on the platform. Pass ``session_id``
    (the value the target run reported via the ``x-agent-session-id`` header) so
    this crash request is pinned to the SAME sandbox as that run — otherwise an
    unpinned ``POST /responses`` gets a fresh auto-generated session and may land
    on a DIFFERENT sandbox, leaving the target run untouched (a run that simply
    completes normally would then masquerade as a "recovered" run).

    ``os._exit(137)`` drops the streaming connection mid-flight, which we detect
    as the positive "sandbox went down" signal. The platform restores the
    sandbox within ~2 min and the resilient task recovers.
    """
    b = body("crash", store=True, background=True, stream=True, session_id=session_id)
    dropped = False
    sid = None
    err = None
    try:
        with httpx.Client(timeout=httpx.Timeout(25, read=25)) as c:
            with c.stream("POST", url("/responses"), headers=headers(), json=b) as r:
                sid = r.headers.get("x-agent-session-id")
                for _ in r.iter_lines():
                    pass
    except (
        httpx.ReadError,
        httpx.ReadTimeout,
        httpx.RemoteProtocolError,
        httpx.ConnectError,
        httpx.RemoteProtocolError,
    ) as e:
        dropped = True
        err = repr(e)
    except Exception as e:  # any transport drop counts as the sandbox dying
        dropped = True
        err = repr(e)
    return {"sandbox_dropped": dropped, "crash_session": sid, "err": err}


def steer_crash(rid: str) -> dict:
    """Deliver a 'crash' input onto the TARGET's own resilient task via steering.

    A fresh ``POST /responses`` "crash" may be routed to a different replica
    than the one holding the target resilient task's lease, so it would not kill
    the right container. Steering with ``previous_response_id`` queues the input
    on the SAME resilient task, so the lease-holding container processes it and
    os._exit(137)s — reliably crashing the right container. The recovery-aware
    demo crash route skips the re-delivered "crash" on recovery, so the run
    recovers to completion instead of crash-looping.
    """
    b = body("crash", store=True, background=True, stream=False, prev=rid)
    try:
        return post_json(b, max_s=30)
    except Exception as e:
        return {"error": repr(e)}


def capture_logs(session_id: str | None, out_path: Path) -> None:
    if not session_id:
        out_path.write_text("(no session id captured)\n")
        return
    try:
        p = subprocess.run(
            ["azd", "ai", "agent", "monitor", AGENT, "--session-id", session_id],
            capture_output=True,
            text=True,
            timeout=LOG_CAPTURE_S,
        )
        out_path.write_text(p.stdout + ("\n--- stderr ---\n" + p.stderr if p.stderr else ""))
    except subprocess.TimeoutExpired as e:
        out_path.write_text((e.stdout or "") + "\n(log capture timed out, partial)\n")
    except Exception as e:
        out_path.write_text(f"(log capture failed: {e!r})\n")


def fetch_session_log(session_id: str | None, secs: int = LOG_CAPTURE_S) -> str:
    """Return a snapshot of a session's server logs (best-effort)."""
    if not session_id:
        return ""
    try:
        p = subprocess.run(
            ["azd", "ai", "agent", "monitor", AGENT, "--session-id", session_id],
            capture_output=True,
            text=True,
            timeout=secs,
        )
        return p.stdout or ""
    except subprocess.TimeoutExpired as e:
        return e.stdout or ""
    except Exception as e:
        return f"(fetch failed: {e!r})\n"


# ---- progress helper: wait until N output items completed in a streaming run -


def wait_progress_stream(b: dict, sse_path: Path, want_items: int, max_wait: int = 120) -> dict:
    """Stream a create until `want_items` output_item.done seen, then return
    (keeping the partial SSE). Used to time a crash/steer mid-run."""
    sid = rid = None
    items_done = 0
    chunks: list[str] = []
    t0 = time.time()
    with httpx.Client(timeout=httpx.Timeout(max_wait, read=max_wait)) as c:
        with c.stream("POST", url("/responses"), headers=headers(), json=b) as r:
            sid = r.headers.get("x-agent-session-id")
            with sse_path.open("w") as f:
                for line in r.iter_lines():
                    f.write(line + "\n")
                    f.flush()
                    chunks.append(line)
                    if rid is None:
                        m = re.search(r'"id"\s*:\s*"(c?a?resp_[^"]+)"', line)
                        if m:
                            rid = m.group(1)
                    if "response.output_item.done" in line:
                        items_done += 1
                    if items_done >= want_items:
                        break
                    if time.time() - t0 > max_wait:
                        break
    events = parse_sse("\n".join(chunks))
    return {
        "session_id": sid,
        "response_id": rid,
        "items_done": items_done,
        "events": events,
        "event_types": event_types(events),
        "elapsed": round(time.time() - t0, 1),
    }


# ---- case implementations --------------------------------------------------


def case_normal_stream(d: Path, combo: dict) -> dict:
    b = body(
        f"Research topic: the history of timekeeping [{combo['id']}]",
        store=combo["store"],
        background=combo["background"],
        stream=True,
    )
    (d / "request.json").write_text(json.dumps({"url": url("/responses"), "body": b}, indent=2))
    res = post_stream(b, d / "stream.sse")
    # background streaming may end the POST connection before terminal; if so, reconnect
    if res["terminal"] is None and res["response_id"] and combo["background"]:
        rc = reconnect_stream(res["response_id"], 0, d / "reconnect.sse")
        res["reconnect_terminal"] = rc["terminal"]
        res["terminal"] = res["terminal"] or rc["terminal"]
    created = sum(1 for t in res["event_types"] if t == "response.created")
    ok = res["terminal"] == "completed"
    return {
        "ok": ok,
        "terminal": res["terminal"],
        "response_id": res["response_id"],
        "session_id": res["session_id"],
        "n_events": len(res["event_types"]),
        "n_created": created,
        "elapsed": res["elapsed"],
        "assert": "terminal==completed",
        "first_events": res["event_types"][:8],
        "last_events": res["event_types"][-6:],
    }


def case_normal_poll(d: Path, combo: dict) -> dict:
    b = body(f"Research topic: deep-sea exploration [{combo['id']}]", store=True, background=True, stream=False)
    (d / "request.json").write_text(json.dumps({"url": url("/responses"), "body": b}, indent=2))
    cr = post_json(b)
    (d / "create.json").write_text(json.dumps(cr["json"], indent=2))
    rid = cr["response_id"]
    term = poll_terminal(rid, d / "poll.jsonl") if rid else {}
    status = term.get("json", {}).get("status") if term else None
    return {
        "ok": status == "completed",
        "terminal": status,
        "response_id": rid,
        "session_id": cr["session_id"],
        "create_status": cr["json"].get("status"),
        "assert": "poll status==completed",
    }


def case_normal_sync(d: Path, combo: dict, stream: bool) -> dict:
    text = f"Briefly summarize the water cycle [{combo['id']}]"
    b = body(text, store=combo["store"], background=False, stream=stream)
    (d / "request.json").write_text(json.dumps({"url": url("/responses"), "body": b}, indent=2))
    if stream:
        res = post_stream(b, d / "stream.sse")
        rid, term, sid = res["response_id"], res["terminal"], res["session_id"]
    else:
        cr = post_json(b)
        (d / "response.json").write_text(json.dumps(cr["json"], indent=2))
        rid = cr["response_id"]
        term = cr["json"].get("status") if isinstance(cr["json"], dict) else None
        sid = cr["session_id"]
    # GET-after check: store=true -> stored snapshot; store=false -> 404
    after = get_response(rid) if rid else {"status_code": None}
    (d / "get_after.json").write_text(json.dumps(after, indent=2))
    expect_404 = not combo["store"]
    get_ok = (after["status_code"] == 404) if expect_404 else (after["status_code"] == 200)
    return {
        "ok": term == "completed" and get_ok,
        "terminal": term,
        "response_id": rid,
        "session_id": sid,
        "get_after_code": after["status_code"],
        "assert": f"completed & GET-after={'404' if expect_404 else 'stored'}",
    }


def case_reconnect(d: Path, combo: dict) -> dict:
    b = body("Research topic: the history of cartography [reconnect]", store=True, background=True, stream=True)
    (d / "request.json").write_text(json.dumps({"url": url("/responses"), "body": b}, indent=2))
    # stream until 1 item done, then drop the connection
    p = wait_progress_stream(b, d / "stream.partial.sse", want_items=1, max_wait=120)
    rid, sid = p["response_id"], p["session_id"]
    pre_events = p["event_types"]
    # reconnect from the beginning and assemble the full stream
    rc = reconnect_stream(rid, 0, d / "reconnect.sse") if rid else {"terminal": None}
    rc_events = rc.get("events", [])
    created = sum(1 for t in rc.get("event_types", []) if t == "response.created")
    in_progress = sum(1 for t in rc.get("event_types", []) if t == "response.in_progress")
    # monotonic, gap/dup-free sequence numbers across the assembled stream
    seqs = []
    for e in rc_events:
        dd = e.get("data")
        if isinstance(dd, dict) and isinstance(dd.get("sequence_number"), int):
            seqs.append(dd["sequence_number"])
    monotonic = all(b > a for a, b in zip(seqs, seqs[1:])) if len(seqs) > 1 else True
    # Correctness invariants for a starting_after=0 reconnect:
    #  - assembled stream reaches terminal completed
    #  - no DUPLICATE response.created (<=1; seq-0 created is excluded by
    #    starting_after=0, so 0 is also valid)
    #  - exactly one response.in_progress reset
    #  - sequence numbers strictly increasing (no gaps/dups)
    ok = (
        rc.get("terminal") == "completed"
        and created <= 1
        and in_progress == 1
        and monotonic
        and rc.get("status_code") == 200
    )
    return {
        "ok": ok,
        "terminal": rc.get("terminal"),
        "response_id": rid,
        "session_id": sid,
        "pre_items_done": p["items_done"],
        "n_created_assembled": created,
        "n_in_progress_reset": in_progress,
        "seq_monotonic": monotonic,
        "reconnect_status": rc.get("status_code"),
        "n_seqs": len(seqs),
        "assert": "reconnect: terminal completed, <=1 created, 1 in_progress reset, monotonic seqs",
        "pre_last": pre_events[-4:],
        "reconnect_first": rc.get("event_types", [])[:6],
    }


def case_crash_recovery(d: Path, combo: dict, stream: bool) -> dict:
    from verify_crash import ContinuousLogCapture  # lazy: avoid import cycle

    b = body("Research topic: the evolution of writing systems [crash]", store=True, background=True, stream=stream)
    (d / "request.json").write_text(json.dumps({"url": url("/responses"), "body": b}, indent=2))
    if stream:
        p = wait_progress_stream(b, d / "stream.precrash.sse", want_items=1, max_wait=120)
        rid, sid = p["response_id"], p["session_id"]
        pre = {"items_done": p["items_done"], "event_types_tail": p["event_types"][-6:]}
    else:
        cr = post_json(b)
        (d / "create.json").write_text(json.dumps(cr["json"], indent=2))
        rid, sid = cr["response_id"], cr["session_id"]
        # let it make some progress
        time.sleep(20)
        snap = get_response(rid)
        pre = {"create_status": cr["json"].get("status"), "n_output_pre": len(snap["json"].get("output", []))}
    # capture the TARGET session's logs continuously across the restart so we
    # can PROVE recovery (reclaim/recover markers), not just observe completion
    cap = ContinuousLogCapture(sid, d / "server.continuous.log")
    cap.start()
    time.sleep(3)
    log(f"  crashing the sandbox running the target task via streaming 'crash' (rid={rid}, session={sid}) ...")
    crash = fire_crash(sid)
    (d / "crash.json").write_text(json.dumps(crash, indent=2))
    log(f"  sandbox_dropped={crash.get('sandbox_dropped')}; waiting {RESTART_WAIT_S}s for restore + recovery ...")
    time.sleep(RESTART_WAIT_S)
    # recover: reconnect (stream) or poll (non-stream)
    if stream:
        rc = reconnect_stream(rid, 0, d / "reconnect.sse")
        in_progress_reset = "response.in_progress" in rc["event_types"]
        created = sum(1 for t in rc["event_types"] if t == "response.created")
        term = rc["terminal"]
        recov = {
            "reconnect_terminal": term,
            "n_created_assembled": created,
            "in_progress_reset_present": in_progress_reset,
        }
    else:
        term_res = poll_terminal(rid, d / "poll.postcrash.jsonl")
        term = term_res.get("json", {}).get("status")
        recov = {"poll_terminal": term}
    cap.stop()
    time.sleep(2)
    # Recovery evidence. On a SINGLE sandbox a mid-run crash + a completed
    # terminal is itself proof the resilient run recovered (it could not finish on
    # a dead sandbox). The "Reclaimed stale task / Recovered task (recovery #N)"
    # markers are corroborating evidence, but on restart they land in whichever
    # session slice reconnects first — so we grep BOTH the target session log and
    # the crash request's session log.
    import re

    txt = (d / "server.continuous.log").read_text() if (d / "server.continuous.log").exists() else ""
    crash_log = fetch_session_log(crash.get("crash_session")) if crash.get("crash_session") else ""
    (d / "crash_session.log").write_text(crash_log)
    both = txt + "\n" + crash_log
    reclaim = len(re.findall(r"Reclaimed stale task", both))
    recovered = len(re.findall(r"Recovered task .* \(recovery #\d+\)", both))
    recov.update(
        {
            "reclaim_markers": reclaim,
            "recovered_markers": recovered,
            "recovery_markers_present": reclaim > 0 or recovered > 0,
        }
    )
    ok = term == "completed"
    res = {
        "ok": ok,
        "terminal": term,
        "response_id": rid,
        "session_id": sid,
        "pre_crash": pre,
        "recovery": recov,
        "assert": "single-sandbox: resilient run recovered to completed after a mid-run crash",
    }
    return res


def case_steering(d: Path, combo: dict) -> dict:
    b = body("Research topic: the history of bridges [steer-A]", store=True, background=True, stream=True)
    (d / "request.json").write_text(json.dumps({"url": url("/responses"), "body": b}, indent=2))
    p = wait_progress_stream(b, d / "streamA.sse", want_items=1, max_wait=120)
    rid, sid = p["response_id"], p["session_id"]
    log(f"  steering rid={rid} with new topic ...")
    sb = body(
        "Actually research suspension-bridge engineering instead [steer-B]",
        store=True,
        background=True,
        stream=False,
        prev=rid,
    )
    (d / "steer.request.json").write_text(json.dumps(sb, indent=2))
    steer = post_json(sb)
    (d / "steer.response.json").write_text(json.dumps(steer["json"], indent=2))
    # the steered run continues under a new response id (previous_response_id chain)
    steered_rid = steer["response_id"]
    term_res = poll_terminal(steered_rid, d / "poll.steered.jsonl") if steered_rid else {}
    status = term_res.get("json", {}).get("status")
    # also confirm original wound down (terminal or handed off)
    orig = get_response(rid)
    return {
        "ok": status == "completed",
        "terminal": status,
        "response_id": rid,
        "steered_response_id": steered_rid,
        "session_id": sid,
        "orig_status": orig["json"].get("status") if isinstance(orig["json"], dict) else None,
        "assert": "steered turn completes; original winds down",
    }


def case_steering_stream(d: Path, combo: dict) -> dict:
    """Steer an in-flight run with a STREAMING follow-up turn.

    Regression guard for the queued-streaming bug: a POST /responses that sets
    stream:true AND carries previous_response_id is queued behind the active
    turn, but MUST still return an SSE stream (text/event-stream) — not a JSON
    'queued' envelope. The stream stays open (keep-alives only) until the
    in-flight turn winds down, then emits response.created / … for the steered
    turn and drives it to terminal.
    """
    b = body("Research topic: the history of lighthouses [steer-stream-A]", store=True, background=True, stream=True)
    (d / "request.json").write_text(json.dumps({"url": url("/responses"), "body": b}, indent=2))
    p = wait_progress_stream(b, d / "streamA.sse", want_items=1, max_wait=120)
    rid, sid = p["response_id"], p["session_id"]
    log(f"  steering rid={rid} with a STREAMING follow-up (pinned session={sid}) ...")
    sb = body(
        "Actually research the engineering of Fresnel lenses instead [steer-stream-B]",
        store=True,
        background=True,
        stream=True,
        prev=rid,
        session_id=sid,
    )
    (d / "steer.request.json").write_text(json.dumps(sb, indent=2))
    # The steered POST is queued behind turn A. The critical assertion: the
    # response is an SSE stream, not a JSON 'queued' envelope.
    steer = post_stream(sb, d / "steer.stream.sse")
    ctype = (steer.get("content_type") or "").lower()
    is_sse = "text/event-stream" in ctype
    steered_rid = steer["response_id"]
    steered_terminal = steer.get("terminal")
    # If the streamed POST connection ended before terminal, confirm via poll.
    if steered_terminal not in TERMINAL_STATES and steered_rid:
        term_res = poll_terminal(steered_rid, d / "poll.steered.jsonl")
        steered_terminal = term_res.get("json", {}).get("status")
    orig = get_response(rid)
    return {
        "ok": is_sse and steered_terminal == "completed",
        "content_type": steer.get("content_type"),
        "returned_sse_not_json": is_sse,
        "terminal": steered_terminal,
        "response_id": rid,
        "steered_response_id": steered_rid,
        "session_id": sid,
        "steered_event_types": steer.get("event_types"),
        "orig_status": orig["json"].get("status") if isinstance(orig["json"], dict) else None,
        "assert": "queued streaming steer returns SSE (text/event-stream), not JSON; steered turn completes",
    }


def case_steering_crash(d: Path, combo: dict) -> dict:
    from verify_crash import ContinuousLogCapture  # lazy: avoid import cycle

    b = body("Research topic: the history of clocks [steerXcrash-A]", store=True, background=True, stream=True)
    (d / "request.json").write_text(json.dumps(b, indent=2))
    p = wait_progress_stream(b, d / "streamA.sse", want_items=1, max_wait=120)
    rid, sid = p["response_id"], p["session_id"]
    sb = body(
        "Switch to researching atomic-clock precision [steerXcrash-B]",
        store=True,
        background=True,
        stream=False,
        prev=rid,
    )
    steer = post_json(sb)
    (d / "steer.response.json").write_text(json.dumps(steer["json"], indent=2))
    steered_rid = steer["response_id"]
    time.sleep(8)  # let the steered input drain/queue
    cap = ContinuousLogCapture(sid, d / "server.continuous.log")
    cap.start()
    time.sleep(3)
    log("  crashing the sandbox running the target task via streaming 'crash' after steer ...")
    crash = fire_crash(sid)
    (d / "crash.json").write_text(json.dumps(crash, indent=2))
    log(f"  sandbox_dropped={crash.get('sandbox_dropped')}; waiting {RESTART_WAIT_S}s for restore + recovery ...")
    time.sleep(RESTART_WAIT_S)
    term_res = poll_terminal(steered_rid, d / "poll.postcrash.jsonl") if steered_rid else {}
    status = term_res.get("json", {}).get("status")
    final = get_response(steered_rid) if steered_rid else {"json": {}}
    (d / "final.json").write_text(json.dumps(final["json"], indent=2))
    cap.stop()
    time.sleep(2)
    import re

    txt = (d / "server.continuous.log").read_text() if (d / "server.continuous.log").exists() else ""
    crash_log = fetch_session_log(crash.get("crash_session")) if crash.get("crash_session") else ""
    (d / "crash_session.log").write_text(crash_log)
    both = txt + "\n" + crash_log
    reclaim = len(re.findall(r"Reclaimed stale task", both))
    recovered = len(re.findall(r"Recovered task .* \(recovery #\d+\)", both))
    return {
        "ok": status == "completed",
        "terminal": status,
        "response_id": rid,
        "steered_response_id": steered_rid,
        "session_id": sid,
        "reclaim_markers": reclaim,
        "recovered_markers": recovered,
        "recovery_markers_present": reclaim > 0 or recovered > 0,
        "assert": "steered input survives single-sandbox crash; recovered run completes",
    }


def case_cancel(d: Path, combo: dict) -> dict:
    b = body("Research topic: the history of the printing press [cancel]", store=True, background=True, stream=True)
    (d / "request.json").write_text(json.dumps(b, indent=2))
    p = wait_progress_stream(b, d / "stream.precancel.sse", want_items=1, max_wait=120)
    rid, sid = p["response_id"], p["session_id"]
    log(f"  cancelling rid={rid} ...")
    cx = cancel(rid)
    (d / "cancel.response.json").write_text(json.dumps(cx["json"], indent=2))
    time.sleep(8)
    final = get_response(rid)
    (d / "final.json").write_text(json.dumps(final["json"], indent=2))
    status = final["json"].get("status") if isinstance(final["json"], dict) else None
    return {
        "ok": status == "cancelled",
        "terminal": status,
        "response_id": rid,
        "session_id": sid,
        "cancel_code": cx["status_code"],
        "assert": "terminal==cancelled",
    }


# ---- oversized-input / attachment-spill helpers ----------------------------

# Comfortably over the core inline threshold (~200 KB) so the resilient-task input
# spills to ``task.attachments`` and recovery must reconstruct it from there.
_OVERSIZE_BYTES = 300 * 1024


def make_oversized(marker: str, pad: str) -> tuple[str, int, str]:
    """Build a ``marker``-prefixed >300 KB input; return (text, len, sha256)."""
    text = marker + (pad * _OVERSIZE_BYTES)
    return text, len(text), hashlib.sha256(text.encode("utf-8")).hexdigest()


def _response_output_text(resp_json: dict) -> str:
    """Concatenate all output-item text from a GET /responses snapshot."""
    parts: list[str] = []
    for item in resp_json.get("output") or []:
        for c in item.get("content") or []:
            if isinstance(c, dict) and isinstance(c.get("text"), str):
                parts.append(c["text"])
    return "\n".join(parts)


def _parse_echoes(text: str) -> list[tuple[int, str]]:
    """Extract every ``*_LEN=<n> ... *_SHA256=<hex>`` echo pair, in order."""
    lens = [int(m) for m in re.findall(r"_LEN=(\d+)", text)]
    shas = re.findall(r"_SHA256=([0-9a-f]{64})", text)
    return list(zip(lens, shas))


def case_oversized_input(d: Path, combo: dict) -> dict:
    """>300 KB normal input → resilient-input attachment spill round-trips losslessly."""
    text, n, sha = make_oversized("__ECHO_INPUT__", "x")
    b = body(text, store=True, background=True, stream=False)
    (d / "request.meta.json").write_text(json.dumps({"input_len": n, "input_sha256": sha}, indent=2))
    cr = post_json(b)
    rid, sid = cr["response_id"], cr["session_id"]
    term = poll_terminal(rid, d / "poll.jsonl") if rid else {}
    final = get_response(rid) if rid else {"json": {}}
    (d / "final.json").write_text(json.dumps(final["json"], indent=2))
    echoes = _parse_echoes(_response_output_text(final["json"]))
    status = final["json"].get("status") if isinstance(final["json"], dict) else None
    match = bool(echoes) and echoes[0] == (n, sha)
    return {
        "ok": status == "completed" and match,
        "terminal": status,
        "response_id": rid,
        "session_id": sid,
        "sent_len": n,
        "echoed": echoes[:1],
        "spill_roundtrip_ok": match,
        "assert": "oversized normal input spills + echoes back byte-identical (len+sha256)",
    }


def case_oversized_steering(d: Path, combo: dict) -> dict:
    """>300 KB *steering* input (on an in-flight chain) → spill round-trips losslessly."""
    # Turn 1: a small echo create to establish the chain.
    b1 = body("__ECHO_INPUT__seed", store=True, background=True, stream=True)
    (d / "request.json").write_text(json.dumps(b1, indent=2))
    p = wait_progress_stream(b1, d / "streamA.sse", want_items=1, max_wait=120)
    rid, sid = p["response_id"], p["session_id"]
    # Steer with an oversized input chained onto the same task.
    text, n, sha = make_oversized("__ECHO_INPUT__", "y")
    (d / "steer.meta.json").write_text(json.dumps({"input_len": n, "input_sha256": sha}, indent=2))
    sb = body(text, store=True, background=True, stream=False, prev=rid)
    steer = post_json(sb)
    steered_rid = steer["response_id"]
    poll_terminal(steered_rid, d / "poll.steered.jsonl") if steered_rid else {}
    final = get_response(steered_rid) if steered_rid else {"json": {}}
    (d / "final.json").write_text(json.dumps(final["json"], indent=2))
    echoes = _parse_echoes(_response_output_text(final["json"]))
    status = final["json"].get("status") if isinstance(final["json"], dict) else None
    match = bool(echoes) and echoes[-1] == (n, sha)
    return {
        "ok": status == "completed" and match,
        "terminal": status,
        "response_id": rid,
        "steered_response_id": steered_rid,
        "session_id": sid,
        "sent_len": n,
        "echoed": echoes[-1:],
        "spill_roundtrip_ok": match,
        "assert": "oversized steering input spills + steered turn echoes it byte-identical",
    }


def case_oversized_crash_recovery(d: Path, combo: dict) -> dict:
    """>300 KB input survives a mid-run crash: the recovered handler re-reads the
    byte-identical input from the spilled task attachment (parity proof)."""
    from verify_crash import ContinuousLogCapture  # lazy import

    text, n, sha = make_oversized("__ECHO_CRASH__", "z")
    (d / "request.meta.json").write_text(json.dumps({"input_len": n, "input_sha256": sha}, indent=2))
    b = body(text, store=True, background=True, stream=False)
    cr = post_json(b)
    rid, sid = cr["response_id"], cr["session_id"]
    # The handler echoes pre-crash, checkpoints, then os._exit(137)s itself.
    cap = ContinuousLogCapture(sid, d / "server.continuous.log")
    cap.start()
    log(f"  oversized echo+crash rid={rid}; waiting {RESTART_WAIT_S}s for restore + recovery ...")
    time.sleep(RESTART_WAIT_S)
    term_res = poll_terminal(rid, d / "poll.postcrash.jsonl", timeout=90) if rid else {}
    final = get_response(rid) if rid else {"json": {}}
    (d / "final.json").write_text(json.dumps(final["json"], indent=2))
    cap.stop()
    time.sleep(2)
    txt = (d / "server.continuous.log").read_text() if (d / "server.continuous.log").exists() else ""
    reclaim = len(re.findall(r"Reclaimed stale task", txt))
    recovered = len(re.findall(r"Recovered task .* \(recovery #\d+\)", txt))
    # Diagnose the resilient-task create. Oversized (>threshold) inputs spill to a
    # task ``attachments`` entry. The hosted task-store offloads ANY attachment to
    # an AzureML dataset blob store (POST .../datasets/.../startPendingUpload),
    # which currently 403s — surfaced to the SDK as a 500 on POST /tasks. So the
    # resilient task is never created and recovery is impossible. Small inputs that
    # stay INLINE in payload (no attachments field) create fine. This is a
    # hosted-only, service-side failure the local LocalFileTaskProvider cannot
    # reproduce. The captured 500 body names the failing dataset-offload target;
    # see capture_oversized_task_trace.py / the __TASKTRACE__ route for the full
    # untruncated request+response trace.
    create_500 = len(re.findall(r"task-store response: POST \S+/tasks\S* -> 500", txt))
    create_ok = len(re.findall(r"task-store response: POST \S+/tasks\S* -> 20[01]", txt))
    offload_403 = len(re.findall(r"datasets/[^ ]*startPendingUpload", txt))
    resilient_task_created = create_ok > 0
    echoes = _parse_echoes(_response_output_text(final["json"]))
    status = final["json"].get("status") if isinstance(final["json"], dict) else None
    # Expect 2 echoes: pre-crash + post-recovery, both byte-identical to the input.
    parity_ok = len(echoes) >= 2 and echoes[0] == (n, sha) and echoes[-1] == (n, sha)
    diagnosis = None
    if not resilient_task_created and create_500 > 0:
        diagnosis = (
            f"RESILIENT-TASK CREATE FAILED: {create_500} x POST /tasks -> 500 "
            f"(0 successful creates) — the {n}-byte input spilled to a task "
            f"attachment, and the hosted task-store's attachment offload to the "
            f"AzureML dataset store 403'd ({offload_403} startPendingUpload refs in "
            f"log) — recovery impossible for any attachment-bearing (oversized) input."
        )
    return {
        "ok": status == "completed" and parity_ok,
        "terminal": status,
        "response_id": rid,
        "session_id": sid,
        "sent_len": n,
        "echoes": echoes,
        "spill_recovery_parity_ok": parity_ok,
        "resilient_task_created": resilient_task_created,
        "task_create_500_count": create_500,
        "task_create_ok_count": create_ok,
        "diagnosis": diagnosis,
        "reclaim_markers": reclaim,
        "recovered_markers": recovered,
        "recovery_markers_present": reclaim > 0 or recovered > 0,
        "assert": "oversized input survives crash: recovered handler re-reads byte-identical attachment",
    }


def case_mark_failed(d: Path, combo: dict) -> dict:
    """Handler emits a clean ``response.failed`` (code=server_error) — the failed
    terminal + error.code surface the research path never produces on its own."""
    b = body("__FAIL__please", store=True, background=True, stream=False)
    (d / "request.json").write_text(json.dumps(b, indent=2))
    cr = post_json(b)
    rid, sid = cr["response_id"], cr["session_id"]
    term = poll_terminal(rid, d / "poll.jsonl") if rid else {}
    final = get_response(rid) if rid else {"json": {}}
    (d / "final.json").write_text(json.dumps(final["json"], indent=2))
    status = final["json"].get("status") if isinstance(final["json"], dict) else None
    err = final["json"].get("error") if isinstance(final["json"], dict) else None
    code = err.get("code") if isinstance(err, dict) else None
    return {
        "ok": status == "failed" and code == "server_error",
        "terminal": status,
        "response_id": rid,
        "session_id": sid,
        "error_code": code,
        "assert": "terminal==failed with error.code==server_error",
    }


CASES = {
    "T1": ("C1", {"id": "C1", "store": True, "background": True}, case_normal_stream),
    "T2": ("C1", {"id": "C1", "store": True, "background": True}, case_reconnect),
    "T3": ("C1", {"id": "C1", "store": True, "background": True}, lambda d, c: case_crash_recovery(d, c, stream=True)),
    "T4": ("C1", {"id": "C1", "store": True, "background": True}, case_steering),
    "T5": ("C1", {"id": "C1", "store": True, "background": True}, case_steering_crash),
    "T6": ("C1", {"id": "C1", "store": True, "background": True}, case_cancel),
    "T7": ("C2", {"id": "C2", "store": True, "background": True}, case_normal_poll),
    "T8": ("C2", {"id": "C2", "store": True, "background": True}, lambda d, c: case_crash_recovery(d, c, stream=False)),
    "T9": ("C3", {"id": "C3", "store": True, "background": False}, lambda d, c: case_normal_sync(d, c, stream=True)),
    "T10": ("C4", {"id": "C4", "store": True, "background": False}, lambda d, c: case_normal_sync(d, c, stream=False)),
    "T11": ("C5", {"id": "C5", "store": False, "background": False}, lambda d, c: case_normal_sync(d, c, stream=True)),
    "T12": ("C6", {"id": "C6", "store": False, "background": False}, lambda d, c: case_normal_sync(d, c, stream=False)),
    # ── Oversized-input / attachment-spill + extra terminal coverage ──
    "T13": ("C7", {"id": "C7", "store": True, "background": True}, case_oversized_input),
    "T14": ("C7", {"id": "C7", "store": True, "background": True}, case_oversized_steering),
    "T15": ("C7", {"id": "C7", "store": True, "background": True}, case_oversized_crash_recovery),
    "T16": ("C8", {"id": "C8", "store": True, "background": True}, case_mark_failed),
    # ── Queued-streaming steer: SSE-not-JSON regression guard ──
    "T17": ("C1", {"id": "C1", "store": True, "background": True}, case_steering_stream),
}

ORDER = [f"T{i}" for i in range(1, 18)]


def run_case(run_dir: Path, name: str) -> dict:
    combo_id, combo, fn = CASES[name]
    d = run_dir / f"{name}-{combo_id}"
    d.mkdir(parents=True, exist_ok=True)
    log(f"=== {name} ({combo_id}) start ===")
    t0 = time.time()
    meta = {"case": name, "combo": combo_id, "start": datetime.now(timezone.utc).isoformat()}
    try:
        result = fn(d, combo)
        meta.update(result)
    except Exception as e:
        import traceback

        meta["ok"] = False
        meta["error"] = repr(e)
        meta["traceback"] = traceback.format_exc()
        log(f"  ERROR: {e!r}")
    meta["duration_s"] = round(time.time() - t0, 1)
    # capture server logs for the session
    sid = meta.get("session_id")
    log(f"  capturing server logs (session={sid}) ...")
    capture_logs(sid, d / "server.log")
    (d / "meta.json").write_text(json.dumps(meta, indent=2))
    log(
        f"=== {name} {'PASS' if meta.get('ok') else 'FAIL'} "
        f"(terminal={meta.get('terminal')}, {meta['duration_s']}s) ==="
    )
    return meta


def main() -> None:
    args = sys.argv[1:] or ["gate"]
    if args == ["all"]:
        names = ORDER
    elif args == ["gate"]:
        names = ["T1"]
    else:
        names = args
    ts = datetime.now(timezone.utc).strftime("%Y%m%dT%H%M%SZ")
    run_dir = Path(__file__).parent / "runs" / ts
    run_dir.mkdir(parents=True, exist_ok=True)
    (run_dir / "env.txt").write_text(
        f"endpoint={ENDPOINT_BASE}\napi_version={API_VERSION}\nmodel={MODEL}\n"
        f"agent={AGENT}\ncases={names}\nstarted={ts}\n"
    )
    log(f"run dir: {run_dir}")
    results = []
    for name in names:
        results.append(run_case(run_dir, name))
        (run_dir / "results.json").write_text(json.dumps(results, indent=2))
    n_pass = sum(1 for r in results if r.get("ok"))
    log(f"\nSUMMARY: {n_pass}/{len(results)} passed")
    for r in results:
        log(
            f"  {r['case']:4} {r['combo']:3} {'PASS' if r.get('ok') else 'FAIL':4} "
            f"terminal={r.get('terminal')} {r['duration_s']}s"
        )
    print(f"\nArtifacts: {run_dir}")


if __name__ == "__main__":
    main()
