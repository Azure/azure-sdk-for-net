#!/usr/bin/env python3

from __future__ import annotations

import argparse
import json
import subprocess
from dataclasses import dataclass
from pathlib import Path


@dataclass(frozen=True, order=True)
class AddedAsset:
    file: str
    reason: str


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


def _added_files(repo_root: Path, base_ref: str) -> list[str]:
    p = _run(
        ["git", "diff", "--name-status", "--diff-filter=A", f"{base_ref}...HEAD"],
        cwd=repo_root,
    )
    if p.returncode != 0:
        raise RuntimeError(p.stderr.strip())

    files: list[str] = []
    for line in p.stdout.splitlines():
        if not line.strip():
            continue
        parts = line.split("\t", 1)
        if len(parts) != 2:
            continue
        status, path = parts[0].strip(), parts[1].strip()
        if status != "A":
            continue
        files.append(path.replace("\\", "/"))
    return files


def _is_under_sessionrecords(path: str) -> bool:
    # Recordings in this repo are typically stored under SessionRecords and should be moved to azure-sdk-assets.
    return "/SessionRecords/" in f"/{path}/"


_FORBIDDEN_SDK_EXTS = {
    ".png",
    ".jpg",
    ".jpeg",
    ".gif",
    ".bmp",
    ".tiff",
    ".ico",
    ".zip",
    ".7z",
    ".rar",
    ".tar",
    ".gz",
    ".tgz",
    ".nupkg",
    ".snupkg",
    ".exe",
    ".dll",
    ".so",
    ".dylib",
    ".bin",
    ".mp4",
    ".mov",
    ".avi",
    ".wav",
    ".mp3",
}


def find_added_assets(repo_root: Path, base_ref: str) -> list[AddedAsset]:
    added = _added_files(repo_root, base_ref)
    results: list[AddedAsset] = []

    for f in sorted(set(added)):
        if _is_under_sessionrecords(f):
            results.append(AddedAsset(file=f, reason="New recordings/assets under SessionRecords must not be committed."))
            continue

        p = Path(f)
        ext = p.suffix.lower()
        if f.startswith("sdk/") and ext in _FORBIDDEN_SDK_EXTS:
            results.append(AddedAsset(file=f, reason=f"Binary asset extension '{ext}' is not allowed under sdk/."))
            continue

    return results


def load_allowlist(path: Path) -> set[str]:
    data = json.loads(path.read_text(encoding="utf-8"))

    if isinstance(data, dict):
        entries = data.get("entries")
        if not isinstance(entries, list):
            raise ValueError("Allowlist JSON object must contain an 'entries' array.")
        allowed = set()
        for i, entry in enumerate(entries):
            if not isinstance(entry, dict):
                raise ValueError(f"Allowlist entry {i} must be an object.")
            f = entry.get("file")
            if not isinstance(f, str) or not f.strip():
                raise ValueError(f"Allowlist entry {i} is missing required field 'file'.")
            allowed.add(f.strip())
        return allowed

    if not isinstance(data, list):
        raise ValueError("Allowlist JSON must be an object with 'entries' or an array.")

    allowed = set()
    for i, entry in enumerate(data):
        if not isinstance(entry, dict):
            raise ValueError(f"Allowlist entry {i} must be an object.")
        f = entry.get("file")
        if not isinstance(f, str) or not f.strip():
            raise ValueError(f"Allowlist entry {i} is missing required field 'file'.")
        allowed.add(f.strip())
    return allowed


def main() -> int:
    ap = argparse.ArgumentParser(description="Fail PRs that add disallowed assets (recordings/binaries).")
    ap.add_argument("--repoRoot", default=".", help="Repo root (default: current directory)")
    ap.add_argument("--baseRef", default="origin/main", help="Base ref for diff (default: origin/main)")
    ap.add_argument(
        "--allowlist",
        default="eng/overrides/added-assets.allowlist.json",
        help="Allowlist JSON path (relative to repoRoot unless absolute)",
    )
    ap.add_argument(
        "--printInventory",
        action="store_true",
        help="Print current added assets as JSON and exit 0 (no allowlist check).",
    )
    args = ap.parse_args()

    repo_root = Path(args.repoRoot).resolve()
    base_ref = args.baseRef
    _ensure_base_ref(repo_root, base_ref)

    findings = find_added_assets(repo_root, base_ref)

    if args.printInventory:
        payload = {
            "baseRef": base_ref,
            "entries": [
                {
                    "file": a.file,
                    "tracking": "https://github.com/Azure/azure-sdk-for-net/issues/55314",
                    "justification": a.reason,
                }
                for a in findings
            ],
        }
        print(json.dumps(payload, indent=2))
        return 0

    allowlist_path = Path(args.allowlist)
    if not allowlist_path.is_absolute():
        allowlist_path = (repo_root / allowlist_path).resolve()

    allowed_files = load_allowlist(allowlist_path) if allowlist_path.exists() else set()

    unapproved = [a for a in findings if a.file not in allowed_files]
    if unapproved:
        print(f"ERROR: Found {len(unapproved)} disallowed added asset file(s) not present in allowlist:")
        for a in unapproved:
            print(f"  - file={a.file}")
            print(f"    reason={a.reason}")
        print()
        print(f"Base ref: {base_ref}")
        print(f"Allowlist: {allowlist_path.as_posix()}")
        print("To approve, add an entry with tracking + justification to the allowlist.")
        return 1

    print("OK: No unallowlisted added assets detected.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

