#!/usr/bin/env python3

from __future__ import annotations

import argparse
import json
from dataclasses import dataclass
from pathlib import Path
from typing import Iterable, Optional, Tuple
from xml.etree import ElementTree as ET


@dataclass(frozen=True, order=True)
class Exclusion:
    project: str
    excluded_package_id: str
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


def _iter_csproj_files(repo_root: Path, search_paths: list[str]) -> Iterable[Path]:
    for sp in search_paths:
        root = (repo_root / sp).resolve()
        if not root.exists():
            continue
        for path in root.rglob("*.csproj"):
            p = _norm_slash(str(path))
            if "/bin/" in p.lower() or "/obj/" in p.lower():
                continue
            yield path


def find_exclusions(repo_root: Path, search_paths: list[str]) -> list[Exclusion]:
    seen: set[Tuple[str, str, str]] = set()
    results: list[Exclusion] = []

    for csproj in _iter_csproj_files(repo_root, search_paths):
        try:
            tree = ET.parse(csproj)
        except ET.ParseError as e:
            raise RuntimeError(f"Failed to parse XML for '{csproj}': {e}") from e

        root = tree.getroot()
        project_rel = _relpath(repo_root, csproj)

        for item_group in root.iter():
            if _local_name(item_group.tag) != "ItemGroup":
                continue

            ig_cond = item_group.attrib.get("Condition")
            ig_cond = ig_cond.strip() if ig_cond and ig_cond.strip() else None

            for item in list(item_group):
                if _local_name(item.tag) != "ExcludeFromProjectReferenceToConversion":
                    continue

                inc = item.attrib.get("Include")
                if not inc or not inc.strip():
                    continue

                cond = item.attrib.get("Condition")
                cond = cond.strip() if cond and cond.strip() else None
                if cond is None:
                    cond = ig_cond

                key = (project_rel, inc.strip(), cond or "")
                if key in seen:
                    continue
                seen.add(key)
                results.append(Exclusion(project_rel, inc.strip(), cond))

    results.sort()
    return results


def load_allowlist(path: Path) -> set[Exclusion]:
    data = json.loads(path.read_text(encoding="utf-8"))
    if not isinstance(data, list):
        raise ValueError("Allowlist JSON must be an array.")

    allow: set[Exclusion] = set()
    for i, entry in enumerate(data):
        if not isinstance(entry, dict):
            raise ValueError(f"Allowlist entry {i} must be an object.")

        project = entry.get("project")
        excluded = entry.get("excludedPackageId")
        condition = entry.get("condition")

        if not all(isinstance(x, str) and x.strip() for x in [project, excluded]):
            raise ValueError(f"Allowlist entry {i} is missing required fields (project, excludedPackageId).")

        if condition is not None and not isinstance(condition, str):
            raise ValueError(f"Allowlist entry {i} field 'condition' must be string or null.")

        allow.add(
            Exclusion(
                project=str(project).strip(),
                excluded_package_id=str(excluded).strip(),
                condition=str(condition).strip() if isinstance(condition, str) and condition.strip() else None,
            )
        )

    return allow


def main() -> int:
    ap = argparse.ArgumentParser(
        description="Check ExcludeFromProjectReferenceToConversion usage against an allowlist."
    )
    ap.add_argument("--repoRoot", default=".", help="Repo root (default: current directory)")
    ap.add_argument(
        "--searchPath",
        action="append",
        default=["sdk"],
        help="Relative path to search (repeatable). Default: sdk",
    )
    ap.add_argument(
        "--allowlist",
        default="eng/overrides/projectrefconversion-exclusions.allowlist.json",
        help="Allowlist JSON path (relative to repoRoot unless absolute)",
    )
    args = ap.parse_args()

    repo_root = Path(args.repoRoot).resolve()
    allowlist_path = Path(args.allowlist)
    if not allowlist_path.is_absolute():
        allowlist_path = (repo_root / allowlist_path).resolve()

    exclusions = find_exclusions(repo_root, args.searchPath)
    allowed = load_allowlist(allowlist_path)

    unapproved = [e for e in exclusions if e not in allowed]
    stale_allow = sorted([a for a in allowed if a not in set(exclusions)])

    if unapproved:
        print(
            f"ERROR: Found {len(unapproved)} ExcludeFromProjectReferenceToConversion entr"
            f"{'y' if len(unapproved)==1 else 'ies'} not present in allowlist:"
        )
        for e in unapproved:
            print(
                f"  - project={e.project} excludedPackageId={e.excluded_package_id} condition={e.condition!r}"
            )
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
            print(
                f"  - project={a.project} excludedPackageId={a.excluded_package_id} condition={a.condition!r}"
            )
        print()

    print(
        f"OK: {len(exclusions)} ExcludeFromProjectReferenceToConversion entr"
        f"{'y' if len(exclusions)==1 else 'ies'} found; all are allowlisted."
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

