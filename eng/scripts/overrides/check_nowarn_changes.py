#!/usr/bin/env python3

from __future__ import annotations

import argparse
import json
import subprocess
from dataclasses import dataclass
from pathlib import Path
from typing import Iterable, Optional, Tuple


@dataclass(frozen=True, order=True)
class NoWarnChange:
    file: str


def _run(cmd: list[str], cwd: Path) -> subprocess.CompletedProcess[str]:
    return subprocess.run(cmd, cwd=str(cwd), text=True, capture_output=True)


def _ensure_base_ref(repo_root: Path, base_ref: str) -> None:
    # If base_ref exists locally, do nothing. Otherwise attempt a small fetch.
    chk = _run(["git", "rev-parse", "--verify", "--quiet", base_ref], cwd=repo_root)
    if chk.returncode == 0:
        return

    # Best-effort fetch. This is safe in CI and helps when checkouts are shallow.
    fetch = _run(["git", "fetch", "--no-tags", "origin", "main"], cwd=repo_root)
    if fetch.returncode != 0:
        raise RuntimeError(
            f"Unable to resolve base ref '{base_ref}'.\n"
            f"git fetch failed:\n{fetch.stderr.strip()}"
        )

    chk2 = _run(["git", "rev-parse", "--verify", "--quiet", base_ref], cwd=repo_root)
    if chk2.returncode != 0:
        raise RuntimeError(f"Unable to resolve base ref '{base_ref}' even after fetch.")


def _changed_files(repo_root: Path, base_ref: str, pathspec: str) -> list[str]:
    p = _run(
        ["git", "diff", "--name-only", f"{base_ref}...HEAD", "--", pathspec],
        cwd=repo_root,
    )
    if p.returncode != 0:
        raise RuntimeError(p.stderr.strip())
    return [line.strip().replace("\\", "/") for line in p.stdout.splitlines() if line.strip()]


def _file_has_nowarn_diff(repo_root: Path, base_ref: str, file_path: str) -> bool:
    p = _run(
        ["git", "diff", "-U0", "--no-color", f"{base_ref}...HEAD", "--", file_path],
        cwd=repo_root,
    )
    if p.returncode != 0:
        # diff returns 1 when there are changes; that's fine. Only treat stderr output failures as errors.
        if p.stderr.strip():
            raise RuntimeError(p.stderr.strip())

    for line in p.stdout.splitlines():
        if not line or line[0] not in "+-":
            continue
        # ignore diff headers
        if line.startswith("+++ ") or line.startswith("--- "):
            continue
        if "<NoWarn" in line or "</NoWarn" in line:
            return True
    return False


def find_nowarn_changes(repo_root: Path, base_ref: str) -> list[NoWarnChange]:
    candidates = _changed_files(repo_root, base_ref, "sdk")
    # Focus on MSBuild files where NoWarn is meaningful.
    msbuild_exts = (".csproj", ".props", ".targets")
    candidates = [f for f in candidates if f.endswith(msbuild_exts)]

    results: list[NoWarnChange] = []
    for f in sorted(set(candidates)):
        if _file_has_nowarn_diff(repo_root, base_ref, f):
            results.append(NoWarnChange(f))

    return results


def load_allowlist(path: Path) -> set[NoWarnChange]:
    data = json.loads(path.read_text(encoding="utf-8"))

    if isinstance(data, dict):
        entries = data.get("entries")
        if not isinstance(entries, list):
            raise ValueError("Allowlist JSON object must contain an 'entries' array.")
        allow = set()
        for i, entry in enumerate(entries):
            if not isinstance(entry, dict):
                raise ValueError(f"Allowlist entry {i} must be an object.")
            file = entry.get("file")
            if not isinstance(file, str) or not file.strip():
                raise ValueError(f"Allowlist entry {i} is missing required field 'file'.")
            allow.add(NoWarnChange(file.strip()))
        return allow

    if not isinstance(data, list):
        raise ValueError("Allowlist JSON must be an object with 'entries' or an array.")

    allow = set()
    for i, entry in enumerate(data):
        if not isinstance(entry, dict):
            raise ValueError(f"Allowlist entry {i} must be an object.")
        file = entry.get("file")
        if not isinstance(file, str) or not file.strip():
            raise ValueError(f"Allowlist entry {i} is missing required field 'file'.")
        allow.add(NoWarnChange(file.strip()))
    return allow


def main() -> int:
    ap = argparse.ArgumentParser(description="Fail PRs that change NoWarn without allowlisting.")
    ap.add_argument("--repoRoot", default=".", help="Repo root (default: current directory)")
    ap.add_argument("--baseRef", default="origin/main", help="Base ref for diff (default: origin/main)")
    ap.add_argument(
        "--allowlist",
        default="eng/overrides/nowarn-changes.allowlist.json",
        help="Allowlist JSON path (relative to repoRoot unless absolute)",
    )
    ap.add_argument(
        "--printInventory",
        action="store_true",
        help="Print current NoWarn-changing files as JSON and exit 0 (no allowlist check).",
    )
    args = ap.parse_args()

    repo_root = Path(args.repoRoot).resolve()
    base_ref = args.baseRef
    _ensure_base_ref(repo_root, base_ref)

    changes = find_nowarn_changes(repo_root, base_ref)

    if args.printInventory:
        payload = {
            "baseRef": base_ref,
            "entries": [
                {
                    "file": c.file,
                    "tracking": "https://github.com/Azure/azure-sdk-for-net/issues/55312",
                    "justification": "Allow NoWarn change with SDK team awareness.",
                }
                for c in changes
            ],
        }
        print(json.dumps(payload, indent=2))
        return 0

    allowlist_path = Path(args.allowlist)
    if not allowlist_path.is_absolute():
        allowlist_path = (repo_root / allowlist_path).resolve()

    allowed = load_allowlist(allowlist_path) if allowlist_path.exists() else set()
    unapproved = [c for c in changes if c not in allowed]

    if unapproved:
        print(
            f"ERROR: Found {len(unapproved)} file(s) under sdk/ with NoWarn changes not present in allowlist:"
        )
        for c in unapproved:
            print(f"  - file={c.file}")
        print()
        print(f"Base ref: {base_ref}")
        print(f"Allowlist: {allowlist_path.as_posix()}")
        print("To approve, add an entry with tracking + justification to the allowlist.")
        return 1

    print("OK: No unallowlisted NoWarn changes detected.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

