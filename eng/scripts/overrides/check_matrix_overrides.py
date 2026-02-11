#!/usr/bin/env python3

from __future__ import annotations

import argparse
import json
import re
from dataclasses import dataclass
from pathlib import Path
from typing import Iterable, Optional, Tuple


@dataclass(frozen=True)
class MatrixOverride:
    file: str
    key: str  # e.g. MatrixConfigs, AdditionalMatrixConfigs, TestDependsOnDependency
    name: Optional[str]  # MatrixConfigs Name if available


NAME_RE = re.compile(r"^\s*-\s*Name:\s*(.+?)\s*$")


def _norm_slash(path: str) -> str:
    return path.replace("\\", "/")


def _relpath(repo_root: Path, full_path: Path) -> str:
    try:
        rel = full_path.resolve().relative_to(repo_root.resolve())
        return _norm_slash(str(rel))
    except Exception:
        return _norm_slash(str(full_path))


def _iter_yaml_files(repo_root: Path, search_paths: list[str]) -> Iterable[Path]:
    for sp in search_paths:
        root = (repo_root / sp).resolve()
        if not root.exists():
            continue
        for path in root.rglob("*.yml"):
            yield path
        for path in root.rglob("*.yaml"):
            yield path


def _indent(s: str) -> int:
    return len(s) - len(s.lstrip(" "))


def find_matrix_overrides(repo_root: Path, search_paths: list[str]) -> list[MatrixOverride]:
    keys = ["MatrixConfigs", "AdditionalMatrixConfigs", "TestDependsOnDependency"]
    results: list[MatrixOverride] = []
    seen: set[Tuple[str, str, str]] = set()

    for yml in _iter_yaml_files(repo_root, search_paths):
        text = yml.read_text(encoding="utf-8", errors="ignore").splitlines()
        rel = _relpath(repo_root, yml)

        i = 0
        while i < len(text):
            line = text[i]
            stripped = line.strip()

            matched_key = None
            for k in keys:
                if stripped.startswith(f"{k}:"):
                    matched_key = k
                    break
            if matched_key is None:
                i += 1
                continue

            start_indent = _indent(line)
            # Record the key itself (even if we can't parse names)
            key_rec = (rel, matched_key, "")
            if key_rec not in seen:
                seen.add(key_rec)
                results.append(MatrixOverride(rel, matched_key, None))

            # Parse - Name: entries under MatrixConfigs/AdditionalMatrixConfigs
            if matched_key in ("MatrixConfigs", "AdditionalMatrixConfigs"):
                j = i + 1
                while j < len(text):
                    ln = text[j]
                    if not ln.strip():
                        j += 1
                        continue
                    if _indent(ln) <= start_indent:
                        break

                    m = NAME_RE.match(ln)
                    if m:
                        name = m.group(1).strip().strip("'\"")
                        rec = (rel, matched_key, name)
                        if rec not in seen:
                            seen.add(rec)
                            results.append(MatrixOverride(rel, matched_key, name))
                    j += 1

            i += 1

    results.sort(key=lambda o: (o.file, o.key, o.name or ""))
    return results


def load_allowlist(path: Path) -> set[MatrixOverride]:
    data = json.loads(path.read_text(encoding="utf-8"))
    if not isinstance(data, list):
        raise ValueError("Allowlist JSON must be an array.")

    allow: set[MatrixOverride] = set()
    for i, entry in enumerate(data):
        if not isinstance(entry, dict):
            raise ValueError(f"Allowlist entry {i} must be an object.")
        file = entry.get("file")
        key = entry.get("key")
        name = entry.get("name")

        if not all(isinstance(x, str) and x.strip() for x in [file, key]):
            raise ValueError(f"Allowlist entry {i} is missing required fields (file, key).")
        if name is not None and not isinstance(name, str):
            raise ValueError(f"Allowlist entry {i} field 'name' must be string or null.")

        allow.add(MatrixOverride(file.strip(), key.strip(), name.strip() if isinstance(name, str) and name.strip() else None))

    return allow


def main() -> int:
    ap = argparse.ArgumentParser(description="Check pipeline matrix overrides in sdk YAML files against an allowlist.")
    ap.add_argument("--repoRoot", default=".", help="Repo root (default: current directory)")
    ap.add_argument(
        "--searchPath",
        action="append",
        default=["sdk"],
        help="Relative path to search (repeatable). Default: sdk",
    )
    ap.add_argument(
        "--allowlist",
        default="eng/overrides/matrix-overrides.allowlist.json",
        help="Allowlist JSON path (relative to repoRoot unless absolute)",
    )
    ap.add_argument(
        "--printInventory",
        action="store_true",
        help="Print current inventory as JSON and exit 0 (no allowlist check).",
    )
    args = ap.parse_args()

    repo_root = Path(args.repoRoot).resolve()
    overrides = find_matrix_overrides(repo_root, args.searchPath)

    if args.printInventory:
        payload = [
            {
                "file": o.file,
                "key": o.key,
                "name": o.name,
                "tracking": "https://github.com/Azure/azure-sdk-for-net/issues/55310",
                "justification": "Existing matrix override when guardrail was introduced.",
            }
            for o in overrides
        ]
        print(json.dumps(payload, indent=2))
        return 0

    allowlist_path = Path(args.allowlist)
    if not allowlist_path.is_absolute():
        allowlist_path = (repo_root / allowlist_path).resolve()

    allowed = load_allowlist(allowlist_path)
    unapproved = [o for o in overrides if o not in allowed]

    if unapproved:
        print(
            f"ERROR: Found {len(unapproved)} matrix override entr"
            f"{'y' if len(unapproved)==1 else 'ies'} not present in allowlist:"
        )
        for o in unapproved:
            print(f"  - file={o.file} key={o.key} name={o.name!r}")
        print()
        print(f"Allowlist: {_norm_slash(str(allowlist_path))}")
        print("To approve, add an entry with tracking + justification to the allowlist.")
        return 1

    print(f"OK: {len(overrides)} matrix override entr{'y' if len(overrides)==1 else 'ies'} found; all are allowlisted.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

