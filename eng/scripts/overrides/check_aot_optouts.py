#!/usr/bin/env python3

from __future__ import annotations

import argparse
import json
from dataclasses import dataclass
from pathlib import Path
from typing import Iterable, Optional, Tuple
from xml.etree import ElementTree as ET


@dataclass(frozen=True, order=True)
class AotOptOut:
    file: str
    property: str
    value: str
    condition: Optional[str]


def _norm_slash(path: str) -> str:
    return path.replace("\\", "/")


def _relpath(repo_root: Path, full_path: Path) -> str:
    try:
        rel = full_path.resolve().relative_to(repo_root.resolve())
        return _norm_slash(str(rel))
    except Exception:
        return _norm_slash(str(full_path))


def _local_name(tag: str) -> str:
    if "}" in tag:
        return tag.split("}", 1)[1]
    return tag


def _iter_msbuild_files(repo_root: Path, search_paths: list[str]) -> Iterable[Path]:
    exts = {".csproj", ".props", ".targets"}
    for sp in search_paths:
        root = (repo_root / sp).resolve()
        if not root.exists():
            continue
        for path in root.rglob("*"):
            if not path.is_file():
                continue
            if path.suffix.lower() not in exts:
                continue
            p = _norm_slash(str(path))
            if "/bin/" in p.lower() or "/obj/" in p.lower():
                continue
            yield path


def find_aot_optouts(repo_root: Path, search_paths: list[str]) -> list[AotOptOut]:
    keys = ["AotCompatOptOut", "AotAnalyzersOptOut"]
    seen: set[Tuple[str, str, str, str]] = set()
    results: list[AotOptOut] = []

    for f in _iter_msbuild_files(repo_root, search_paths):
        try:
            tree = ET.parse(f)
        except ET.ParseError:
            # Some .targets/.props in the repo are not well-formed XML or contain placeholders.
            # Skip those rather than failing the whole check.
            continue

        root = tree.getroot()
        file_rel = _relpath(repo_root, f)

        for pg in root.iter():
            if _local_name(pg.tag) != "PropertyGroup":
                continue

            pg_cond = pg.attrib.get("Condition")
            pg_cond = pg_cond.strip() if pg_cond and pg_cond.strip() else None

            for child in list(pg):
                name = _local_name(child.tag)
                if name not in keys:
                    continue

                raw_value = (child.text or "").strip()
                if raw_value.lower() != "true":
                    continue

                cond = child.attrib.get("Condition")
                cond = cond.strip() if cond and cond.strip() else None
                if cond is None:
                    cond = pg_cond

                key = (file_rel, name, "true", cond or "")
                if key in seen:
                    continue
                seen.add(key)

                results.append(AotOptOut(file_rel, name, "true", cond))

    results.sort()
    return results


def load_allowlist(path: Path) -> set[AotOptOut]:
    data = json.loads(path.read_text(encoding="utf-8"))

    # Preferred shape (reduces duplication):
    # {
    #   "trackingDefault": "...",
    #   "justificationDefault": "...",
    #   "entries": [{ "file": "...", "property": "...", "condition": null }, ...]
    # }
    if isinstance(data, dict):
        entries = data.get("entries")
        if not isinstance(entries, list):
            raise ValueError("Allowlist JSON object must contain an 'entries' array.")

        allow: set[AotOptOut] = set()
        for i, entry in enumerate(entries):
            if not isinstance(entry, dict):
                raise ValueError(f"Allowlist entry {i} must be an object.")

            file = entry.get("file")
            prop = entry.get("property")
            condition = entry.get("condition")

            if not all(isinstance(x, str) and x.strip() for x in [file, prop]):
                raise ValueError(f"Allowlist entry {i} is missing required fields (file, property).")
            if condition is not None and not isinstance(condition, str):
                raise ValueError(f"Allowlist entry {i} field 'condition' must be string or null.")

            allow.add(
                AotOptOut(
                    file=str(file).strip(),
                    property=str(prop).strip(),
                    value="true",
                    condition=str(condition).strip() if isinstance(condition, str) and condition.strip() else None,
                )
            )

        return allow

    # Back-compat: array of objects containing value/metadata
    if not isinstance(data, list):
        raise ValueError("Allowlist JSON must be an object with 'entries' or an array.")

    allow: set[AotOptOut] = set()
    for i, entry in enumerate(data):
        if not isinstance(entry, dict):
            raise ValueError(f"Allowlist entry {i} must be an object.")

        file = entry.get("file")
        prop = entry.get("property")
        value = entry.get("value")
        condition = entry.get("condition")

        if not all(isinstance(x, str) and x.strip() for x in [file, prop, value]):
            raise ValueError(f"Allowlist entry {i} is missing required fields (file, property, value).")
        if condition is not None and not isinstance(condition, str):
            raise ValueError(f"Allowlist entry {i} field 'condition' must be string or null.")

        allow.add(
            AotOptOut(
                file=str(file).strip(),
                property=str(prop).strip(),
                value=str(value).strip(),
                condition=str(condition).strip() if isinstance(condition, str) and condition.strip() else None,
            )
        )

    return allow


def main() -> int:
    ap = argparse.ArgumentParser(description="Check AOT opt-out properties against an allowlist.")
    ap.add_argument("--repoRoot", default=".", help="Repo root (default: current directory)")
    ap.add_argument(
        "--searchPath",
        action="append",
        default=["sdk"],
        help="Relative path to search (repeatable). Default: sdk",
    )
    ap.add_argument(
        "--allowlist",
        default="eng/overrides/aot-optouts.allowlist.json",
        help="Allowlist JSON path (relative to repoRoot unless absolute)",
    )
    ap.add_argument(
        "--printInventory",
        action="store_true",
        help="Print current inventory as JSON and exit 0 (no allowlist check).",
    )
    ap.add_argument(
        "--printAllowlistTemplate",
        action="store_true",
        help="Print a compact allowlist template JSON (object with entries) and exit 0.",
    )
    args = ap.parse_args()

    repo_root = Path(args.repoRoot).resolve()
    findings = find_aot_optouts(repo_root, args.searchPath)

    if args.printInventory:
        payload = [
            {"file": f.file, "property": f.property, "value": f.value, "condition": f.condition}
            for f in findings
        ]
        print(json.dumps(payload, indent=2))
        return 0

    if args.printAllowlistTemplate:
        payload = {
            "trackingDefault": "https://github.com/Azure/azure-sdk-for-net/issues/55310",
            "justificationDefault": "Existing opt-out when guardrail was introduced.",
            "entries": [
                {"file": f.file, "property": f.property, "condition": f.condition} for f in findings
            ],
        }
        print(json.dumps(payload, separators=(",", ":"), ensure_ascii=False))
        return 0

    allowlist_path = Path(args.allowlist)
    if not allowlist_path.is_absolute():
        allowlist_path = (repo_root / allowlist_path).resolve()

    allowed = load_allowlist(allowlist_path)
    unapproved = [f for f in findings if f not in allowed]

    if unapproved:
        print(
            f"ERROR: Found {len(unapproved)} AOT opt-out entr"
            f"{'y' if len(unapproved)==1 else 'ies'} not present in allowlist:"
        )
        for f in unapproved:
            print(
                f"  - file={f.file} property={f.property} value={f.value} condition={f.condition!r}"
            )
        print()
        print(f"Allowlist: {_norm_slash(str(allowlist_path))}")
        print("To approve, add an entry with tracking + justification to the allowlist.")
        return 1

    print(
        f"OK: {len(findings)} AOT opt-out entr{'y' if len(findings)==1 else 'ies'} found; all are allowlisted."
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

