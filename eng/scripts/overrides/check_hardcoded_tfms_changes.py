#!/usr/bin/env python3

from __future__ import annotations

import argparse
import json
import re
import subprocess
from dataclasses import dataclass
from pathlib import Path


@dataclass(frozen=True, order=True)
class HardcodedTfmChange:
    file: str
    property: str  # TargetFramework or TargetFrameworks
    value: str


_SAME_LINE_RE = re.compile(r"<(?P<prop>TargetFrameworks?)>\s*(?P<val>[^<]*)\s*</\1>")
_OPEN_TAG_RE = re.compile(r"<(?P<prop>TargetFrameworks?)>\s*$")
_CLOSE_TAG_RE = re.compile(r"</(?P<prop>TargetFrameworks?)>\s*$")


def _run(cmd: list[str], cwd: Path) -> subprocess.CompletedProcess[str]:
    return subprocess.run(cmd, cwd=str(cwd), text=True, capture_output=True)


def _ensure_base_ref(repo_root: Path, base_ref: str) -> None:
    chk = _run(["git", "rev-parse", "--verify", "--quiet", base_ref], cwd=repo_root)
    if chk.returncode == 0:
        return
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


def _diff_text(repo_root: Path, base_ref: str, file_path: str) -> str:
    p = _run(
        ["git", "diff", "-U0", "--no-color", f"{base_ref}...HEAD", "--", file_path],
        cwd=repo_root,
    )
    if p.returncode not in (0, 1) and p.stderr.strip():
        raise RuntimeError(p.stderr.strip())
    return p.stdout


def _is_hardcoded_tfm_value(val: str) -> bool:
    v = val.strip()
    if not v:
        return False
    if "$(" in v:
        return False
    # Heuristic: TFMs in this repo are overwhelmingly net* identifiers.
    return "net" in v


def _extract_added_property_values(diff_text: str) -> list[tuple[str, str]]:
    """
    Returns list of (property, value) for added lines in the diff.
    Handles:
      - <TargetFramework>net10.0</TargetFramework>
      - <TargetFrameworks>
           net8.0;netstandard2.0
        </TargetFrameworks>
    """
    results: list[tuple[str, str]] = []

    open_prop: str | None = None
    open_val_parts: list[str] = []

    for raw in diff_text.splitlines():
        if not raw or raw[0] != "+":
            continue
        if raw.startswith("+++ "):
            continue

        line = raw[1:].rstrip()

        m = _SAME_LINE_RE.search(line)
        if m:
            results.append((m.group("prop"), m.group("val").strip()))
            continue

        if open_prop is None:
            m2 = _OPEN_TAG_RE.search(line.strip())
            if m2:
                open_prop = m2.group("prop")
                open_val_parts = []
            continue

        # We are inside an open tag.
        if _CLOSE_TAG_RE.search(line.strip()):
            results.append((open_prop, " ".join(p.strip() for p in open_val_parts if p.strip()).strip()))
            open_prop = None
            open_val_parts = []
        else:
            open_val_parts.append(line.strip())

    return results


def find_hardcoded_tfm_changes(repo_root: Path, base_ref: str) -> list[HardcodedTfmChange]:
    candidates = _changed_files(repo_root, base_ref, "sdk")
    msbuild_exts = (".csproj", ".props", ".targets")
    candidates = [f for f in candidates if f.endswith(msbuild_exts)]

    findings: set[HardcodedTfmChange] = set()
    for f in sorted(set(candidates)):
        diff = _diff_text(repo_root, base_ref, f)
        for prop, val in _extract_added_property_values(diff):
            if _is_hardcoded_tfm_value(val):
                findings.add(HardcodedTfmChange(file=f, property=prop, value=val))

    return sorted(findings)


def load_allowlist(path: Path) -> set[HardcodedTfmChange]:
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
            prop = entry.get("property")
            val = entry.get("value")
            if not isinstance(file, str) or not file.strip():
                raise ValueError(f"Allowlist entry {i} is missing required field 'file'.")
            if prop not in ("TargetFramework", "TargetFrameworks"):
                raise ValueError(f"Allowlist entry {i} has invalid 'property': {prop!r}")
            if not isinstance(val, str) or not val.strip():
                raise ValueError(f"Allowlist entry {i} is missing required field 'value'.")
            allow.add(HardcodedTfmChange(file.strip(), prop, val.strip()))
        return allow

    if not isinstance(data, list):
        raise ValueError("Allowlist JSON must be an object with 'entries' or an array.")

    allow = set()
    for i, entry in enumerate(data):
        if not isinstance(entry, dict):
            raise ValueError(f"Allowlist entry {i} must be an object.")
        file = entry.get("file")
        prop = entry.get("property")
        val = entry.get("value")
        if not isinstance(file, str) or not file.strip():
            raise ValueError(f"Allowlist entry {i} is missing required field 'file'.")
        if prop not in ("TargetFramework", "TargetFrameworks"):
            raise ValueError(f"Allowlist entry {i} has invalid 'property': {prop!r}")
        if not isinstance(val, str) or not val.strip():
            raise ValueError(f"Allowlist entry {i} is missing required field 'value'.")
        allow.add(HardcodedTfmChange(file.strip(), prop, val.strip()))
    return allow


def main() -> int:
    ap = argparse.ArgumentParser(description="Fail PRs that introduce hardcoded TFMs under sdk/.")
    ap.add_argument("--repoRoot", default=".", help="Repo root (default: current directory)")
    ap.add_argument("--baseRef", default="origin/main", help="Base ref for diff (default: origin/main)")
    ap.add_argument(
        "--allowlist",
        default="eng/overrides/hardcoded-tfms.allowlist.json",
        help="Allowlist JSON path (relative to repoRoot unless absolute)",
    )
    ap.add_argument(
        "--printInventory",
        action="store_true",
        help="Print current hardcoded TFM changes as JSON and exit 0 (no allowlist check).",
    )
    args = ap.parse_args()

    repo_root = Path(args.repoRoot).resolve()
    base_ref = args.baseRef
    _ensure_base_ref(repo_root, base_ref)

    changes = find_hardcoded_tfm_changes(repo_root, base_ref)

    if args.printInventory:
        payload = {
            "baseRef": base_ref,
            "entries": [
                {
                    "file": c.file,
                    "property": c.property,
                    "value": c.value,
                    "tracking": "https://github.com/Azure/azure-sdk-for-net/issues/55313",
                    "justification": "Hardcoded TFM requires SDK team approval; prefer central RequiredTargetFrameworks.",
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
            f"ERROR: Found {len(unapproved)} hardcoded TargetFramework/TargetFrameworks change(s) under sdk/ not present in allowlist:"
        )
        for c in unapproved:
            print(f"  - file={c.file} property={c.property} value={c.value!r}")
        print()
        print(f"Base ref: {base_ref}")
        print(f"Allowlist: {allowlist_path.as_posix()}")
        print("To approve, add an entry with tracking + justification to the allowlist.")
        return 1

    print("OK: No unallowlisted hardcoded TFM changes detected.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

