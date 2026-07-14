#!/usr/bin/env python3
"""Capture a full, untruncated HTTP trace of the failing oversized resilient-task
create (POST /tasks with a >threshold attachment) against the hosted Foundry
task-store, for service-side investigation.

Drives the REAL core SDK client (``HostedTaskProvider.create``) so the request is
byte-faithful to what the resilient-responses path sends, wrapping the transport to
dump the request line, query, headers, full body and the full response status,
headers, and body. Only the bearer token VALUE is redacted (it is a live secret).

Usage:  python capture_oversized_task_trace.py [attachment_bytes]
Writes: runs/task-trace-<ts>.txt  (and prints it)
"""
from __future__ import annotations

import asyncio
import json
import subprocess
import sys
import time
import uuid
from datetime import datetime, timezone
from pathlib import Path

from azure.core.credentials import AccessToken
from azure.core.pipeline.transport import AioHttpTransport, AsyncHttpTransport

from azure.ai.agentserver.core.tasks._client import HostedTaskProvider
from azure.ai.agentserver.core.tasks._models import TaskCreateRequest

PROJECT_ENDPOINT = "https://rapida-0687-resource.services.ai.azure.com/api/projects/rapida-0687"
AUTH_RESOURCE = "https://ai.azure.com"
AGENT = "resilient-responses-agent-demo-dotnet"


def _redact_headers(headers) -> dict:
    out = {}
    for k, v in dict(headers).items():
        if k.lower() == "authorization":
            scheme = v.split(" ", 1)[0] if isinstance(v, str) and " " in v else "Bearer"
            out[k] = f"{scheme} <REDACTED — live bearer token>"
        else:
            out[k] = v
    return out


def _body_bytes(obj) -> bytes:
    for attr in ("content", "body", "data"):
        v = getattr(obj, attr, None)
        if v is None:
            continue
        if isinstance(v, bytes):
            return v
        if isinstance(v, str):
            return v.encode("utf-8")
    return b""


class CapturingTransport(AsyncHttpTransport):
    """Wrap a real transport; capture the exact request + response bytes."""

    def __init__(self, inner: AsyncHttpTransport) -> None:
        self.inner = inner
        self.records: list[dict] = []

    async def send(self, request, **kwargs):
        req_body = _body_bytes(request)
        rec = {
            "request": {
                "method": getattr(request, "method", "?"),
                "url": str(getattr(request, "url", "?")),
                "headers": _redact_headers(getattr(request, "headers", {}) or {}),
                "body_bytes": req_body,
            }
        }
        response = await self.inner.send(request, **kwargs)
        body = b""
        try:
            await response.load_body()
            body = response.body() or b""
        except Exception as exc:  # noqa: BLE001
            body = f"<could not buffer response body: {exc!r}>".encode("utf-8")
        rec["response"] = {
            "status_code": getattr(response, "status_code", "?"),
            "reason": getattr(response, "reason", ""),
            "headers": dict(getattr(response, "headers", {}) or {}),
            "body_bytes": body,
        }
        self.records.append(rec)
        return response

    async def open(self) -> None:
        await self.inner.open()

    async def close(self) -> None:
        await self.inner.close()

    async def __aenter__(self) -> "CapturingTransport":
        await self.open()
        return self

    async def __aexit__(self, *a) -> None:
        await self.close()


class AzCliCredential:
    """Async token credential backed by ``az account get-access-token``."""

    async def get_token(self, *scopes, **kwargs) -> AccessToken:  # noqa: ARG002
        tok = subprocess.run(
            ["az", "account", "get-access-token", "--resource", AUTH_RESOURCE, "--query", "accessToken", "-o", "tsv"],
            capture_output=True,
            text=True,
            check=True,
        ).stdout.strip()
        return AccessToken(tok, int(time.time()) + 3000)

    async def close(self) -> None:
        pass

    async def __aenter__(self) -> "AzCliCredential":
        return self

    async def __aexit__(self, *a) -> None:
        pass


def _fmt(rec: dict, attach_bytes: int, attach_key: str) -> str:
    req, resp = rec["request"], rec["response"]
    rb = req["body_bytes"]
    out = []
    out.append("=" * 100)
    out.append("RAW HTTP TRACE — resilient-task create (POST /tasks) with oversized attachment")
    out.append(f"captured: {datetime.now(timezone.utc).isoformat()}")
    out.append(
        f"attachment: key={attach_key!r} value_size={attach_bytes} bytes "
        f"(spec limit: 2 MB/attachment — this is well under it)"
    )
    out.append("=" * 100)
    out.append("")
    out.append("################  REQUEST  ################")
    out.append(f"{req['method']} {req['url']}")
    out.append("")
    out.append("--- request headers ---")
    for k, v in req["headers"].items():
        out.append(f"{k}: {v}")
    out.append("")
    out.append(f"--- request body ({len(rb)} bytes, UNTRUNCATED) ---")
    out.append(rb.decode("utf-8", errors="replace"))
    out.append("")
    out.append("################  RESPONSE  ################")
    out.append(f"HTTP {resp['status_code']} {resp.get('reason', '')}".rstrip())
    out.append("")
    out.append("--- response headers ---")
    for k, v in resp["headers"].items():
        out.append(f"{k}: {v}")
    out.append("")
    body = resp["body_bytes"]
    bt = body.decode("utf-8", errors="replace") if isinstance(body, bytes) else str(body)
    out.append(f"--- response body ({len(body)} bytes, UNTRUNCATED) ---")
    out.append(bt if bt else "<empty response body>")
    out.append("=" * 100)
    return "\n".join(out)


async def main() -> None:
    attach_bytes = int(sys.argv[1]) if len(sys.argv) > 1 else 300 * 1024
    # Realistic spilled-input payload: a JSON blob whose large field reproduces the
    # >threshold size (the responses resilient path spills the serialized input here).
    big = "A long research input. " * ((attach_bytes // 23) + 1)
    big = big[:attach_bytes]
    attach_key = "input"
    session_id = f"task-trace-{uuid.uuid4().hex}"
    task_id = f"resilient-resp-{uuid.uuid4().hex}"
    lease_owner = f"{AGENT}|session:{session_id}"
    lease_instance_id = f"trace-{uuid.uuid4().hex[:12]}"

    req = TaskCreateRequest(
        agent_name=AGENT,
        session_id=session_id,
        status="in_progress",
        id=task_id,
        payload={"kind": "agentserver.response"},
        source={"type": "agentserver.task"},
        lease_owner=lease_owner,
        lease_instance_id=lease_instance_id,
        lease_duration_seconds=60,
        attachments={attach_key: big},
    )

    inner = AioHttpTransport()
    cap = CapturingTransport(inner)
    cred = AzCliCredential()
    provider = HostedTaskProvider(PROJECT_ENDPOINT, cred, transport=cap)

    err = None
    try:
        await provider.create(req)
    except Exception as exc:  # noqa: BLE001
        err = repr(exc)

    ts = datetime.now(timezone.utc).strftime("%Y%m%dT%H%M%SZ")
    out_dir = Path(__file__).parent / "runs"
    out_dir.mkdir(parents=True, exist_ok=True)
    out_path = out_dir / f"task-trace-{ts}.txt"
    if not cap.records:
        out_path.write_text(f"NO HTTP RECORD CAPTURED. SDK error: {err}\n")
        print(out_path.read_text())
        return
    text = _fmt(cap.records[-1], attach_bytes, attach_key)
    if err:
        text += f"\n\nSDK raised: {err}\n"
    out_path.write_text(text)
    print(text)
    print(f"\n[saved] {out_path}")


if __name__ == "__main__":
    asyncio.run(main())
