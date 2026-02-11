#!/usr/bin/env python3

from __future__ import annotations

import argparse
import json
from dataclasses import dataclass
from pathlib import Path
from typing import Optional, Tuple


@dataclass(frozen=True, order=True)
class Baseline:
    file: str


def _norm_slash(path: str) -> str:
    return path.replace("\\", "/")


def _relpath(repo_root: Path, full_path: Path) -> str:
    try:
        rel = full_path.resolve().relative_to(repo_root.resolve())
        return _norm_slash(str(rel))
    except Exception:
        return _norm_slash(str(full_path))


def find_baselines(repo_root: Path, search_paths: list[str]) -> list[Baseline]:
    results: list[Baseline] = []
    seen: set[str] = set()
    for sp in search_paths:
        root = (repo_root / sp).resolve()
        if not root.exists():
            continue
        for path in root.rglob("ApiCompatBaseline.txt"):
            rel = _relpath(repo_root, path)
            if rel in seen:
                continue
            seen.add(rel)
            results.append(Baseline(rel))

    results.sort()
    return results


def load_allowlist(path: Path) -> set[Baseline]:
    data = json.loads(path.read_text(encoding="utf-8"))
    if not isinstance(data, list):
        raise ValueError("Allowlist JSON must be an array.")

    allow: set[Baseline] = set()
    for i, entry in enumerate(data):
        if not isinstance(entry, dict):
            raise ValueError(f"Allowlist entry {i} must be an object.")
        file = entry.get("file")
        if not isinstance(file, str) or not file.strip():
            raise ValueError(f"Allowlist entry {i} is missing required field 'file'.")
        allow.add(Baseline(file.strip()))
    return allow


def main() -> int:
    ap = argparse.ArgumentParser(description="Check ApiCompatBaseline.txt usage against an allowlist.")
    ap.add_argument("--repoRoot", default=".", help="Repo root (default: current directory)")
    ap.add_argument(
        "--searchPath",
        action="append",
        default=["sdk"],
        help="Relative path to search (repeatable). Default: sdk",
    )
    ap.add_argument(
        "--allowlist",
        default="eng/overrides/apicompat-baselines.allowlist.json",
        help="Allowlist JSON path (relative to repoRoot unless absolute)",
    )
    args = ap.parse_args()

    repo_root = Path(args.repoRoot).resolve()
    allowlist_path = Path(args.allowlist)
    if not allowlist_path.is_absolute():
        allowlist_path = (repo_root / allowlist_path).resolve()

    baselines = find_baselines(repo_root, args.searchPath)
    allowed = load_allowlist(allowlist_path)

    unapproved = [b for b in baselines if b not in allowed]
    stale_allow = sorted([a for a in allowed if a not in set(baselines)])

    if unapproved:
        print(
            f"ERROR: Found {len(unapproved)} ApiCompatBaseline.txt entr"
            f"{'y' if len(unapproved)==1 else 'ies'} not present in allowlist:"
        )
        for b in unapproved:
            print(f"  - file={b.file}")
        print()
        print(f"Allowlist: {_norm_slash(str(allowlist_path))}")
        print("To approve, add an entry with tracking + justification to the allowlist.")
        return 1

    if stale_allow:
        print(
            f"Note: {len(stale_allow)} allowlist entr{'y' if len(stale_allow)==1 else 'ies'} "
            f"did not match current findings (may be stale):"
        )
        for a in stale_allow:
            print(f"  - file={a.file}")
        print()

    print(
        f"OK: {len(baselines)} ApiCompatBaseline.txt entr{'y' if len(baselines)==1 else 'ies'} found; all are allowlisted."
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

