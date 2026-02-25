#!/usr/bin/env python3
"""
Diff extension classes between baseline commit and newly generated versions.

This script:
1. Reads the baseline commit from migration/info.txt
2. Gets extension class files from baseline commit (src/Generated/Extensions/)
3. Compares with current generated extension classes
4. Reports added/removed extension classes
5. For shared classes, compares public methods/members to find diffs
"""

import re
import subprocess
import sys
from dataclasses import dataclass, field
from pathlib import Path
from typing import Optional


@dataclass
class PublicMember:
    """Represents a public member in an extension class."""
    kind: str  # "method", "property", "field"
    name: str
    signature: str
    is_static: bool = False
    is_extension: bool = False


@dataclass
class ExtensionClass:
    """Represents an extension class with its public members."""
    class_name: str
    file_path: str
    is_static: bool = False
    base_class: str = ""
    public_members: list[PublicMember] = field(default_factory=list)


def run_git_command(args: list[str], cwd: Path) -> tuple[int, str, str]:
    """Run a git command and return (returncode, stdout, stderr)."""
    result = subprocess.run(
        ["git"] + args,
        cwd=cwd,
        capture_output=True,
        text=True,
    )
    return result.returncode, result.stdout, result.stderr


def get_git_root(start: Path) -> Path:
    """Resolve the repository root from a starting directory."""
    code, stdout, _ = run_git_command(["rev-parse", "--show-toplevel"], start)
    if code != 0:
        return start
    return Path(stdout.strip())


def get_project_root(start: Path) -> Path:
    """Find nearest ancestor that contains src/Generated/Extensions."""
    for candidate in [start, *start.parents]:
        if (candidate / "src" / "Generated" / "Extensions").exists():
            return candidate
    return start


def get_baseline_commit(project_root: Path) -> Optional[str]:
    """Read baseline commit id from migration/info.txt."""
    info_path = project_root / "migration" / "info.txt"
    if not info_path.exists():
        return None
    for line in info_path.read_text(encoding="utf-8").splitlines():
        stripped = line.strip()
        if stripped.lower().startswith("baseline commit id:"):
            commit = stripped.split(":", 1)[1].strip()
            if commit:
                return commit
    return None


def get_file_from_revision(relative_path: Path, workspace: Path, revision: str) -> Optional[str]:
    """Get file content from a git revision using a workspace-relative path."""
    code, stdout, _ = run_git_command(
        ["show", f"{revision}:{relative_path.as_posix()}"], workspace
    )
    if code == 0:
        return stdout
    return None


def list_revision_extension_files(
    extensions_relative_dir: Path, workspace: Path, revision: str
) -> set[Path]:
    """List extension .cs files from a git revision under src/Generated/Extensions."""
    code, stdout, _ = run_git_command(
        ["ls-tree", "-r", "--name-only", revision, extensions_relative_dir.as_posix()],
        workspace,
    )
    if code != 0:
        return set()

    files: set[Path] = set()
    for line in stdout.splitlines():
        line = line.strip()
        if not line.endswith(".cs"):
            continue
        if line.endswith(".Serialization.cs"):
            continue
        files.add(Path(line))
    return files


def list_current_extension_files(extensions_dir: Path, git_root: Path) -> set[Path]:
    """List current extension .cs files as git-root-relative paths."""
    files: set[Path] = set()
    for file_path in extensions_dir.rglob("*.cs"):
        if file_path.name.endswith(".Serialization.cs"):
            continue
        files.add(file_path.relative_to(git_root))
    return files


def extract_class_info(content: str) -> tuple[Optional[str], bool, str]:
    """Extract class name, whether it's static, and its base class from file content.

    Returns (class_name, is_static, base_class).
    """
    # Try static class first
    match = re.search(
        r"public\s+static\s+partial\s+class\s+(\w+)",
        content,
    )
    if match:
        return match.group(1), True, ""

    # Try non-static class
    match = re.search(
        r"public\s+partial\s+class\s+(\w+)\s*(?::\s*(\w+))?",
        content,
    )
    if match:
        base = match.group(2) or ""
        return match.group(1), False, base

    return None, False, ""


def extract_public_members(content: str, class_name: str, is_static_class: bool) -> list[PublicMember]:
    """Extract public methods and properties from an extension class."""
    members: list[PublicMember] = []
    seen_signatures: set[str] = set()

    # Pattern for public methods (including static, virtual, override, async, extension 'this')
    method_pattern = re.compile(
        r"^\s*public\s+"
        r"(static\s+)?"
        r"(virtual\s+|override\s+)?"
        r"(async\s+)?"
        r"([\w<>,\.\[\]\s\?]+?)\s+"  # return type
        r"(\w+)\s*"                   # method name
        r"\(([^)]*)\)",               # parameters
        re.MULTILINE,
    )

    # Pattern for public properties
    property_pattern = re.compile(
        r"^\s*public\s+"
        r"(static\s+)?"
        r"(virtual\s+|override\s+)?"
        r"([\w<>,\.\[\]\s\?]+?)\s+"
        r"(\w+)\s*\{\s*(?:get|set|init)",
        re.MULTILINE,
    )

    for match in method_pattern.finditer(content):
        is_static = match.group(1) is not None
        is_async = match.group(3) is not None
        return_type = " ".join(match.group(4).split())
        method_name = match.group(5).strip()
        parameters = " ".join(match.group(6).split())

        # Skip constructors
        if method_name == class_name:
            continue

        # Skip property-like matches
        end_pos = match.end()
        following = content[end_pos : end_pos + 50].strip()
        if following.startswith("{") and (
            "get" in following[:20] or "set" in following[:20]
        ):
            continue

        is_extension = "this " in parameters.split(",")[0] if parameters else False

        static_prefix = "static " if is_static else ""
        async_prefix = "async " if is_async else ""
        signature = f"public {static_prefix}{async_prefix}{return_type} {method_name}({parameters})"

        if signature not in seen_signatures:
            seen_signatures.add(signature)
            members.append(
                PublicMember(
                    kind="method",
                    name=method_name,
                    signature=signature,
                    is_static=is_static,
                    is_extension=is_extension,
                )
            )

    for match in property_pattern.finditer(content):
        prop_type = " ".join(match.group(3).split())
        name = match.group(4).strip()
        signature = f"public {prop_type} {name} {{ ... }}"
        if signature not in seen_signatures:
            seen_signatures.add(signature)
            members.append(
                PublicMember(kind="property", name=name, signature=signature)
            )

    return members


def parse_extension_class(content: str, file_path: str) -> Optional[ExtensionClass]:
    """Parse an extension class file into an ExtensionClass object."""
    class_name, is_static, base_class = extract_class_info(content)
    if not class_name:
        return None

    members = extract_public_members(content, class_name, is_static)

    return ExtensionClass(
        class_name=class_name,
        file_path=file_path,
        is_static=is_static,
        base_class=base_class,
        public_members=members,
    )


def build_extension_map(
    file_paths: set[Path], workspace: Path, from_revision: Optional[str]
) -> dict[str, ExtensionClass]:
    """Build a map of class_name -> parsed ExtensionClass from a set of files."""
    extensions: dict[str, ExtensionClass] = {}

    for relative_path in sorted(file_paths):
        if from_revision:
            content = get_file_from_revision(relative_path, workspace, from_revision)
            if content is None:
                continue
        else:
            absolute_path = workspace / relative_path
            content = absolute_path.read_text(encoding="utf-8")

        ext_class = parse_extension_class(content, str(relative_path))
        if ext_class:
            extensions[ext_class.class_name] = ext_class

    return extensions


def normalize_signature(signature: str) -> str:
    """Normalize a signature for comparison purposes.

    Treats ``= null`` and ``= default`` as equivalent so that trivial
    default-value changes are not reported as diffs.
    """
    return re.sub(r'=\s*(null|default)\b', '= default', signature)


def compare_members(
    old_members: list[PublicMember], new_members: list[PublicMember]
) -> dict[str, list]:
    """Compare public members between two extension classes."""
    old_by_key: dict[tuple[str, str], set[str]] = {}
    new_by_key: dict[tuple[str, str], set[str]] = {}

    for member in old_members:
        key = (member.kind, member.name)
        old_by_key.setdefault(key, set()).add(member.signature)

    for member in new_members:
        key = (member.kind, member.name)
        new_by_key.setdefault(key, set()).add(member.signature)

    old_keys = set(old_by_key.keys())
    new_keys = set(new_by_key.keys())

    removed: list[str] = []
    added: list[str] = []
    changed: list[dict[str, list[str] | str]] = []

    for key in sorted(old_keys - new_keys):
        removed.extend(sorted(old_by_key[key]))

    for key in sorted(new_keys - old_keys):
        added.extend(sorted(new_by_key[key]))

    for key in sorted(old_keys & new_keys):
        old_sigs = old_by_key[key]
        new_sigs = new_by_key[key]
        # Compare using normalized signatures so that trivial default-value
        # changes (e.g. ``= null`` → ``= default``) are not reported.
        old_normalized = {normalize_signature(s) for s in old_sigs}
        new_normalized = {normalize_signature(s) for s in new_sigs}
        if old_normalized != new_normalized:
            changed.append(
                {
                    "kind": key[0],
                    "name": key[1],
                    "old": sorted(old_sigs),
                    "new": sorted(new_sigs),
                }
            )

    return {"added": added, "removed": removed, "changed": changed}


def main() -> None:
    script_dir = Path(__file__).resolve().parent
    project_root = get_project_root(script_dir)
    git_root = get_git_root(project_root)

    project_relative = project_root.relative_to(git_root)
    extensions_relative_dir = project_relative / "src" / "Generated" / "Extensions"
    extensions_dir = git_root / extensions_relative_dir
    output_path = script_dir / "extension_diff_result.txt"

    if not extensions_dir.exists():
        print(f"Error: {extensions_dir} not found")
        sys.exit(1)

    baseline_commit = get_baseline_commit(project_root)
    if not baseline_commit:
        print(
            f"Error: baseline commit id not found in "
            f"{project_root / 'migration' / 'info.txt'}"
        )
        sys.exit(1)

    code, _, stderr = run_git_command(
        ["rev-parse", "--verify", baseline_commit], git_root
    )
    if code != 0:
        print(
            f"Error: baseline commit '{baseline_commit}' is not valid: "
            f"{stderr.strip()}"
        )
        sys.exit(1)

    print(f"Using baseline commit: {baseline_commit}")

    print("Getting extension files from baseline commit...")
    baseline_files = list_revision_extension_files(
        extensions_relative_dir, git_root, baseline_commit
    )
    print(f"Found {len(baseline_files)} extension files in baseline")

    print("\nGetting current extension files (post-generated)...")
    current_files = list_current_extension_files(extensions_dir, git_root)
    print(f"Found {len(current_files)} extension files in current")

    print("\nParsing baseline extensions...")
    baseline_extensions = build_extension_map(
        baseline_files, git_root, from_revision=baseline_commit
    )
    print(f"Parsed {len(baseline_extensions)} extension classes from baseline")

    print("\nParsing current extensions...")
    current_extensions = build_extension_map(
        current_files, git_root, from_revision=None
    )
    print(f"Parsed {len(current_extensions)} extension classes from current")

    # ── Build output ──────────────────────────────────────────────────
    lines: list[str] = []
    lines.append("=" * 100)
    lines.append("EXTENSION DIFF ANALYSIS")
    lines.append(
        f"Comparing baseline ({baseline_commit}) vs Current (post-generated)"
    )
    lines.append("=" * 100)

    baseline_names = set(baseline_extensions.keys())
    current_names = set(current_extensions.keys())

    removed_classes = sorted(baseline_names - current_names)
    added_classes = sorted(current_names - baseline_names)
    common_classes = sorted(baseline_names & current_names)

    # ── Removed extension classes ─────────────────────────────────────
    if removed_classes:
        lines.append("")
        lines.append("-" * 80)
        lines.append("REMOVED EXTENSION CLASSES (in baseline but not in current)")
        lines.append("-" * 80)
        for name in removed_classes:
            ext = baseline_extensions[name]
            kind = "static class" if ext.is_static else "class"
            lines.append(f"\n  {name} ({kind})")
            lines.append(f"    File: {Path(ext.file_path).name}")
            lines.append(f"    Had {len(ext.public_members)} public members")

    # ── Added extension classes ───────────────────────────────────────
    if added_classes:
        lines.append("")
        lines.append("-" * 80)
        lines.append("ADDED EXTENSION CLASSES (in current but not in baseline)")
        lines.append("-" * 80)
        for name in added_classes:
            ext = current_extensions[name]
            kind = "static class" if ext.is_static else "class"
            lines.append(f"\n  {name} ({kind})")
            lines.append(f"    File: {Path(ext.file_path).name}")
            lines.append(f"    Has {len(ext.public_members)} public members")

    # ── Modified extension classes ────────────────────────────────────
    modified_classes: list[str] = []

    for name in common_classes:
        old_ext = baseline_extensions[name]
        new_ext = current_extensions[name]

        member_diff = compare_members(old_ext.public_members, new_ext.public_members)
        if (
            not member_diff["added"]
            and not member_diff["removed"]
            and not member_diff["changed"]
        ):
            continue

        modified_classes.append(name)
        lines.append("")
        lines.append("-" * 80)
        lines.append("MODIFIED EXTENSION CLASSES (public member changes)")
        lines.append("-" * 80)
        kind = "static class" if new_ext.is_static else "class"
        lines.append(f"\n{name} ({kind})")
        lines.append(f"  File: {Path(new_ext.file_path).name}")

        if member_diff["added"]:
            lines.append(
                f"\n  + Added members ({len(member_diff['added'])}):"
            )
            for sig in member_diff["added"]:
                lines.append(f"      + {sig}")

        if member_diff["removed"]:
            lines.append(
                f"\n  - Removed members ({len(member_diff['removed'])}):"
            )
            for sig in member_diff["removed"]:
                lines.append(f"      - {sig}")

        if member_diff["changed"]:
            lines.append(
                f"\n  ~ Changed members ({len(member_diff['changed'])}):"
            )
            for change in member_diff["changed"]:
                lines.append(f"      ~ {change['kind']} {change['name']}")
                lines.append("        OLD:")
                for old_sig in change["old"]:
                    lines.append(f"          - {old_sig}")
                lines.append("        NEW:")
                for new_sig in change["new"]:
                    lines.append(f"          + {new_sig}")

    unchanged_count = len(common_classes) - len(modified_classes)

    # ── Summary ───────────────────────────────────────────────────────
    lines.append("")
    lines.append("=" * 100)
    lines.append("SUMMARY")
    lines.append("=" * 100)
    lines.append(f"Extension classes in baseline:  {len(baseline_extensions)}")
    lines.append(f"Extension classes in current:   {len(current_extensions)}")
    lines.append("")
    lines.append(f"Removed classes ({len(removed_classes)}):")
    for name in removed_classes:
        lines.append(f"  - {name}")
    lines.append(f"Added classes ({len(added_classes)}):")
    for name in added_classes:
        lines.append(f"  + {name}")
    lines.append(f"Modified classes ({len(modified_classes)}):")
    for name in modified_classes:
        lines.append(f"  ~ {name}")
    unchanged_classes = sorted(
        set(common_classes) - set(modified_classes)
    )
    lines.append(f"Unchanged classes ({unchanged_count}):")
    for name in unchanged_classes:
        lines.append(f"    {name}")

    if not removed_classes and not added_classes and not modified_classes:
        lines.append("")
        lines.append(
            "No differences found between baseline and current generated extensions."
        )

    output_content = "\n".join(lines)
    output_path.write_text(output_content, encoding="utf-8")

    print(output_content)
    print(f"\n\nOutput written to {output_path}")


if __name__ == "__main__":
    main()
