#!/usr/bin/env python3

from __future__ import annotations

import argparse
import json
from dataclasses import dataclass
from pathlib import Path
from typing import Iterable, Optional, Tuple
from xml.etree import ElementTree as ET


@dataclass(frozen=True, order=True)
class Finding:
    project: str
    package_id: str
    version_override: str
    reference_kind: str
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
    # Handles tags like "{namespace}PackageReference"
    if "}" in tag:
        return tag.split("}", 1)[1]
    return tag


def _first_child_text(elem: ET.Element, child_local_name: str) -> Optional[str]:
    for c in list(elem):
        if _local_name(c.tag) == child_local_name and (c.text is not None):
            return c.text.strip()
    return None


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


def find_version_overrides(repo_root: Path, search_paths: list[str]) -> list[Finding]:
    seen: set[Tuple[str, str, str, str, str]] = set()
    results: list[Finding] = []

    for csproj in _iter_csproj_files(repo_root, search_paths):
        try:
            tree = ET.parse(csproj)
        except ET.ParseError as e:
            raise RuntimeError(f"Failed to parse XML for '{csproj}': {e}") from e

        root = tree.getroot()
        project_rel = _relpath(repo_root, csproj)

        # Traverse with parent condition context (ItemGroup Condition commonly used).
        for parent in root.iter():
            parent_local = _local_name(parent.tag)
            parent_condition = parent.attrib.get("Condition")
            parent_condition = parent_condition.strip() if parent_condition and parent_condition.strip() else None

            if parent_local != "ItemGroup":
                continue

            for pr in list(parent):
                if _local_name(pr.tag) != "PackageReference":
                    continue

                vo = pr.attrib.get("VersionOverride")
                if not vo or not vo.strip():
                    vo = _first_child_text(pr, "VersionOverride")
                if not vo or not vo.strip():
                    continue
                vo = vo.strip()

                include = pr.attrib.get("Include")
                update = pr.attrib.get("Update")
                if include and include.strip():
                    package_id = include.strip()
                    ref_kind = "Include"
                elif update and update.strip():
                    package_id = update.strip()
                    ref_kind = "Update"
                else:
                    package_id = "<unknown>"
                    ref_kind = "<unknown>"

                cond = pr.attrib.get("Condition")
                cond = cond.strip() if cond and cond.strip() else None
                if cond is None:
                    cond = parent_condition

                key = (project_rel, package_id, vo, ref_kind, cond or "")
                if key in seen:
                    continue
                seen.add(key)
                results.append(Finding(project_rel, package_id, vo, ref_kind, cond))

    results.sort()
    return results


def load_allowlist(path: Path) -> set[Finding]:
    data = json.loads(path.read_text(encoding="utf-8"))
    if not isinstance(data, list):
        raise ValueError("Allowlist JSON must be an array.")

    allow: set[Finding] = set()
    for i, entry in enumerate(data):
        if not isinstance(entry, dict):
            raise ValueError(f"Allowlist entry {i} must be an object.")

        project = entry.get("project")
        package_id = entry.get("packageId")
        version_override = entry.get("versionOverride")
        reference_kind = entry.get("referenceKind")
        condition = entry.get("condition")

        if not all(isinstance(x, str) and x.strip() for x in [project, package_id, version_override, reference_kind]):
            raise ValueError(f"Allowlist entry {i} is missing required fields (project, packageId, versionOverride, referenceKind).")

        if condition is not None and not isinstance(condition, str):
            raise ValueError(f"Allowlist entry {i} field 'condition' must be string or null.")

        allow.add(
            Finding(
                project=str(project).strip(),
                package_id=str(package_id).strip(),
                version_override=str(version_override).strip(),
                reference_kind=str(reference_kind).strip(),
                condition=str(condition).strip() if isinstance(condition, str) and condition.strip() else None,
            )
        )

    return allow


def main() -> int:
    ap = argparse.ArgumentParser(description="Check csproj PackageReference VersionOverride usage against an allowlist.")
    ap.add_argument("--repoRoot", default=".", help="Repo root (default: current directory)")
    ap.add_argument("--searchPath", action="append", default=["sdk"], help="Relative path to search (repeatable). Default: sdk")
    ap.add_argument("--allowlist", default="eng/overrides/versionoverride.allowlist.json", help="Allowlist JSON path (relative to repoRoot unless absolute)")
    args = ap.parse_args()

    repo_root = Path(args.repoRoot).resolve()
    allowlist_path = Path(args.allowlist)
    if not allowlist_path.is_absolute():
        allowlist_path = (repo_root / allowlist_path).resolve()

    findings = find_version_overrides(repo_root, args.searchPath)
    allowed = load_allowlist(allowlist_path)

    unapproved = [f for f in findings if f not in allowed]
    stale_allow = sorted([a for a in allowed if a not in set(findings)])

    if unapproved:
        print(f"ERROR: Found {len(unapproved)} VersionOverride entr{'y' if len(unapproved)==1 else 'ies'} not present in allowlist:")
        for f in unapproved:
            print(f"  - project={f.project} packageId={f.package_id} versionOverride={f.version_override} referenceKind={f.reference_kind} condition={f.condition!r}")
        print()
        print(f"Allowlist: { _norm_slash(str(allowlist_path)) }")
        print("To approve, add an entry with tracking + justification to the allowlist.")
        return 1

    if stale_allow:
        # Not a failure for now; just a nudge to keep the allowlist tidy.
        print(f"Note: {len(stale_allow)} allowlist entr{'y' if len(stale_allow)==1 else 'ies'} did not match current findings (may be stale):")
        for a in stale_allow:
            print(f"  - project={a.project} packageId={a.package_id} versionOverride={a.version_override} referenceKind={a.reference_kind} condition={a.condition!r}")
        print()

    print(f"OK: {len(findings)} VersionOverride entr{'y' if len(findings)==1 else 'ies'} found; all are allowlisted.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

