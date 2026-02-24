#!/usr/bin/env python3
"""
Compare the current generated SDK resource classes against the baseline commit
to identify which resource classes have been deleted.

Usage:
    python migdiff.py
"""

import os
import subprocess
import sys

MIGRATION_DIR = os.path.dirname(os.path.abspath(__file__))
PROJECT_DIR = os.path.dirname(MIGRATION_DIR)
SDK_ROOT = os.path.abspath(os.path.join(PROJECT_DIR, "..", "..", ".."))
INFO_TXT = os.path.join(MIGRATION_DIR, "info.txt")

# Relative path from the repo root to the Generated folder
GENERATED_REL = os.path.relpath(
    os.path.join(PROJECT_DIR, "src", "Generated"), SDK_ROOT
)


def read_info():
    """Read the baseline commit id and sdk path from info.txt."""
    baseline_commit = None
    sdk_path = None
    with open(INFO_TXT) as f:
        for line in f:
            line = line.strip()
            if line.startswith("baseline commit id:"):
                baseline_commit = line.split(":", 1)[1].strip()
            elif line.startswith("sdk  path:") or line.startswith("sdk path:"):
                sdk_path = line.split(":", 1)[1].strip()
    if not baseline_commit:
        print("ERROR: Could not find 'baseline commit id:' in info.txt")
        sys.exit(1)
    return baseline_commit, sdk_path


def git_ls_tree_resources(commit, rel_path):
    """List *Resource.cs files in the Generated folder at a given commit."""
    cmd = [
        "git", "ls-tree", "-r", "--name-only", commit,
        rel_path + "/"
    ]
    result = subprocess.run(
        cmd, capture_output=True, text=True, cwd=SDK_ROOT
    )
    if result.returncode != 0:
        print(f"ERROR: git ls-tree failed:\n{result.stderr}")
        sys.exit(1)

    resources = set()
    for line in result.stdout.strip().splitlines():
        filename = os.path.basename(line)
        if filename.endswith("Resource.cs") and not filename.endswith(".Serialization.cs"):
            resources.add(filename)
    return resources


def current_resources():
    """List *Resource.cs files in the current working tree's Generated folder."""
    generated_dir = os.path.join(PROJECT_DIR, "src", "Generated")
    if not os.path.isdir(generated_dir):
        print(f"ERROR: Generated directory not found: {generated_dir}")
        sys.exit(1)

    resources = set()
    for filename in os.listdir(generated_dir):
        if filename.endswith("Resource.cs") and not filename.endswith(".Serialization.cs"):
            resources.add(filename)
    return resources


def resource_name(filename):
    """Extract the resource class name from a filename (strip .cs)."""
    return filename[:-3]


def main():
    baseline_commit, _ = read_info()
    print(f"Baseline commit: {baseline_commit}")
    print(f"Generated path:  {GENERATED_REL}")
    print()

    baseline = git_ls_tree_resources(baseline_commit, GENERATED_REL)
    current = current_resources()

    deleted = sorted(baseline - current, key=str.lower)
    added = sorted(current - baseline, key=str.lower)
    kept = sorted(baseline & current, key=str.lower)

    # --- Deleted resources ---
    if deleted:
        print(f"DELETED resource classes ({len(deleted)}):")
        for f in deleted:
            print(f"  - {resource_name(f)}")
    else:
        print("No resource classes were deleted.")
    print()

    # --- Added resources (informational) ---
    if added:
        print(f"NEW resource classes ({len(added)}):")
        for f in added:
            print(f"  + {resource_name(f)}")
    else:
        print("No new resource classes were added.")
    print()

    # --- Summary ---
    print(f"Summary: baseline={len(baseline)}, current={len(current)}, "
          f"kept={len(kept)}, deleted={len(deleted)}, added={len(added)}")


if __name__ == "__main__":
    main()
