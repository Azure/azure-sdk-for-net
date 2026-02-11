#!/usr/bin/env python3

from __future__ import annotations

import argparse
import json
import re
from dataclasses import dataclass
from pathlib import Path
from typing import Iterable, Optional, Tuple
from xml.etree import ElementTree as ET


AZC_PATTERN = re.compile(r"\bAZC\d{4}\b")


@dataclass(frozen=True, order=True)
class NoWarnOverride:
    file: str
    rule_id: str
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


def _iter_directory_build_props(repo_root: Path, search_paths: list[str]) -> Iterable[Path]:
    for sp in search_paths:
        root = (repo_root / sp).resolve()
        if not root.exists():
            continue
        for path in root.rglob("Directory.Build.props"):
            yield path


def find_nowarn_azc_overrides(repo_root: Path, search_paths: list[str]) -> list[NoWarnOverride]:
    seen: set[Tuple[str, str, str]] = set()
    results: list[NoWarnOverride] = []

    for f in _iter_directory_build_props(repo_root, search_paths):
        try:
            tree = ET.parse(f)
        except ET.ParseError:
            continue

        root = tree.getroot()
        file_rel = _relpath(repo_root, f)

        for pg in root.iter():
            if _local_name(pg.tag) != "PropertyGroup":
                continue
            pg_cond = pg.attrib.get("Condition")
            pg_cond = pg_cond.strip() if pg_cond and pg_cond.strip() else None

            for child in list(pg):
                if _local_name(child.tag) != "NoWarn":
                    continue
                text = (child.text or "").strip()
                if not text:
                    continue

                cond = child.attrib.get("Condition")
                cond = cond.strip() if cond and cond.strip() else None
                if cond is None:
                    cond = pg_cond

                for rule in sorted(set(AZC_PATTERN.findall(text))):
                    key = (file_rel, rule, cond or "")
                    if key in seen:
                        continue
                    seen.add(key)
                    results.append(NoWarnOverride(file_rel, rule, cond))

    results.sort()
    return results


def load_allowlist(path: Path) -> set[NoWarnOverride]:
    data = json.loads(path.read_text(encoding="utf-8"))
    if not isinstance(data, list):
        raise ValueError("Allowlist JSON must be an array.")

    allow: set[NoWarnOverride] = set()
    for i, entry in enumerate(data):
        if not isinstance(entry, dict):
            raise ValueError(f"Allowlist entry {i} must be an object.")
        file = entry.get("file")
        rule_id = entry.get("ruleId")
        condition = entry.get("condition")

        if not all(isinstance(x, str) and x.strip() for x in [file, rule_id]):
            raise ValueError(f"Allowlist entry {i} is missing required fields (file, ruleId).")
        if condition is not None and not isinstance(condition, str):
            raise ValueError(f"Allowlist entry {i} field 'condition' must be string or null.")

        allow.add(
            NoWarnOverride(
                file=str(file).strip(),
                rule_id=str(rule_id).strip(),
                condition=str(condition).strip() if isinstance(condition, str) and condition.strip() else None,
            )
        )
    return allow


def main() -> int:
    ap = argparse.ArgumentParser(description="Check AZC NoWarn overrides in Directory.Build.props against an allowlist.")
    ap.add_argument("--repoRoot", default=".", help="Repo root (default: current directory)")
    ap.add_argument(
        "--searchPath",
        action="append",
        default=["sdk"],
        help="Relative path to search (repeatable). Default: sdk",
    )
    ap.add_argument(
        "--allowlist",
        default="eng/overrides/nowarn-directory-overrides.allowlist.json",
        help="Allowlist JSON path (relative to repoRoot unless absolute)",
    )
    ap.add_argument(
        "--printInventory",
        action="store_true",
        help="Print current inventory as JSON and exit 0 (no allowlist check).",
    )
    args = ap.parse_args()

    repo_root = Path(args.repoRoot).resolve()
    overrides = find_nowarn_azc_overrides(repo_root, args.searchPath)

    if args.printInventory:
        payload = [
            {
                "file": o.file,
                "ruleId": o.rule_id,
                "condition": o.condition,
                "tracking": "https://github.com/Azure/azure-sdk-for-net/issues/55310",
                "justification": "Existing NoWarn override when guardrail was introduced.",
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
    stale_allow = sorted([a for a in allowed if a not in set(overrides)])

    if unapproved:
        print(
            f"ERROR: Found {len(unapproved)} NoWarn(AZC) entr"
            f"{'y' if len(unapproved)==1 else 'ies'} not present in allowlist:"
        )
        for o in unapproved:
            print(f"  - file={o.file} ruleId={o.rule_id} condition={o.condition!r}")
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
            print(f"  - file={a.file} ruleId={a.rule_id} condition={a.condition!r}")
        print()

    print(
        f"OK: {len(overrides)} NoWarn(AZC) entr{'y' if len(overrides)==1 else 'ies'} found; all are allowlisted."
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

