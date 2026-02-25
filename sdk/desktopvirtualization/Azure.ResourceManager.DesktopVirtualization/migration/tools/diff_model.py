#!/usr/bin/env python3
"""
Diff model types between baseline commit and newly generated versions.

This script:
1. Reads the baseline commit from migration/info.txt
2. Gets model files from baseline commit (src/Generated/Models/)
3. Compares with current generated model files
4. Reports added/removed model types
5. For shared models, compares public members to find API diffs
"""

import re
import subprocess
import sys
from dataclasses import dataclass, field
from pathlib import Path
from typing import Optional


# ---------------------------------------------------------------------------
# Data classes
# ---------------------------------------------------------------------------

@dataclass
class PublicMember:
    """Represents a public member in a model type."""
    kind: str  # "constructor", "method", "property", "field"
    name: str
    signature: str


@dataclass
class ModelType:
    """Represents a model type and its public API surface."""
    type_name: str
    type_kind: str  # "class", "struct", "enum"
    file_path: str
    public_members: list[PublicMember] = field(default_factory=list)
    enum_members: list[str] = field(default_factory=list)


# ---------------------------------------------------------------------------
# Git helpers
# ---------------------------------------------------------------------------

def run_git_command(args: list[str], cwd: Path) -> tuple[int, str, str]:
    """Run a git command and return (returncode, stdout, stderr)."""
    result = subprocess.run(
        ["git"] + args, cwd=cwd, capture_output=True, text=True
    )
    return result.returncode, result.stdout, result.stderr


def get_git_root(start: Path) -> Path:
    code, stdout, _ = run_git_command(["rev-parse", "--show-toplevel"], start)
    if code != 0:
        return start
    return Path(stdout.strip())


def get_project_root(start: Path) -> Path:
    """Find nearest ancestor that contains src/Generated/Models."""
    for candidate in [start, *start.parents]:
        if (candidate / "src" / "Generated" / "Models").exists():
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


def get_file_from_revision(
    relative_path: Path, workspace: Path, revision: str
) -> Optional[str]:
    code, stdout, _ = run_git_command(
        ["show", f"{revision}:{relative_path.as_posix()}"], workspace
    )
    return stdout if code == 0 else None


def list_revision_model_files(
    models_relative_dir: Path, workspace: Path, revision: str
) -> set[Path]:
    code, stdout, _ = run_git_command(
        ["ls-tree", "-r", "--name-only", revision,
         models_relative_dir.as_posix()],
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


def list_revision_data_files(
    generated_relative_dir: Path, workspace: Path, revision: str
) -> set[Path]:
    """List *Data.cs files directly under src/Generated/ (resource data types)."""
    code, stdout, _ = run_git_command(
        ["ls-tree", "--name-only", revision,
         generated_relative_dir.as_posix() + "/"],
        workspace,
    )
    if code != 0:
        return set()
    files: set[Path] = set()
    for line in stdout.splitlines():
        line = line.strip()
        if not line.endswith("Data.cs"):
            continue
        if line.endswith(".Serialization.cs"):
            continue
        files.add(Path(line))
    return files


def list_current_model_files(models_dir: Path, git_root: Path) -> set[Path]:
    files: set[Path] = set()
    for fp in models_dir.rglob("*.cs"):
        if fp.name.endswith(".Serialization.cs"):
            continue
        files.add(fp.relative_to(git_root))
    return files


def list_current_data_files(generated_dir: Path, git_root: Path) -> set[Path]:
    """List *Data.cs files directly under src/Generated/ (resource data types)."""
    files: set[Path] = set()
    for fp in generated_dir.glob("*Data.cs"):
        if fp.name.endswith(".Serialization.cs"):
            continue
        files.add(fp.relative_to(git_root))
    return files


# ---------------------------------------------------------------------------
# C# parsing
# ---------------------------------------------------------------------------

def find_matching_brace(text: str, open_index: int) -> int:
    depth = 0
    for i in range(open_index, len(text)):
        if text[i] == "{":
            depth += 1
        elif text[i] == "}":
            depth -= 1
            if depth == 0:
                return i
    return -1


def extract_type_block(content: str) -> tuple[Optional[str], Optional[str], str]:
    """Return (type_kind, type_name, body) for the first public type."""
    m = re.search(
        r"^\s*public\s+(?:readonly\s+|sealed\s+|abstract\s+|partial\s+)*"
        r"(class|struct|enum)\s+(\w+)\b",
        content,
        re.MULTILINE,
    )
    if not m:
        return None, None, ""
    type_kind, type_name = m.group(1), m.group(2)
    open_idx = content.find("{", m.end())
    if open_idx < 0:
        return type_kind, type_name, ""
    close_idx = find_matching_brace(content, open_idx)
    if close_idx < 0:
        return type_kind, type_name, ""
    return type_kind, type_name, content[open_idx + 1 : close_idx]


def extract_enum_members(body: str) -> list[str]:
    items: list[str] = []
    for line in body.splitlines():
        s = line.strip()
        if not s or s.startswith("//") or s.startswith("///"):
            continue
        s = s.split("//", 1)[0].strip().rstrip(",")
        if not s:
            continue
        if "=" in s:
            s = s.split("=", 1)[0].strip()
        if re.match(r"^[A-Za-z_]\w*$", s):
            items.append(s)
    return items


def extract_public_members(type_name: str, body: str) -> list[PublicMember]:
    members: list[PublicMember] = []
    seen: set[str] = set()

    ctor_pat = re.compile(
        rf"^\s*public\s+{re.escape(type_name)}\s*\(([^)]*)\)",
        re.MULTILINE,
    )
    method_pat = re.compile(
        r"^\s*public\s+"
        r"(?:static\s+)?"
        r"(?:virtual\s+|override\s+)?"
        r"(?:async\s+)?"
        r"([\w<>,\.\[\]\s\?]+?)\s+"
        r"(\w+)\s*"
        r"\(([^)]*)\)",
        re.MULTILINE,
    )
    prop_pat = re.compile(
        r"^\s*public\s+"
        r"(?:static\s+)?"
        r"(?:virtual\s+|override\s+)?"
        r"([\w<>,\.\[\]\s\?]+?)\s+"
        r"(\w+)\s*\{",
        re.MULTILINE,
    )
    field_pat = re.compile(
        r"^\s*public\s+"
        r"(?:const\s+|static\s+readonly\s+|readonly\s+|static\s+)?"
        r"([\w<>,\.\[\]\s\?]+?)\s+"
        r"(\w+)\s*(?:=|;)",
        re.MULTILINE,
    )

    for m in ctor_pat.finditer(body):
        params = " ".join(m.group(1).split())
        sig = f"public {type_name}({params})"
        if sig not in seen:
            seen.add(sig)
            members.append(PublicMember("constructor", type_name, sig))

    for m in method_pat.finditer(body):
        ret = " ".join(m.group(1).split())
        name = m.group(2).strip()
        params = " ".join(m.group(3).split())
        if name == type_name:
            continue
        end = m.end()
        following = body[end : end + 40].strip()
        if following.startswith("{") and (
            "get" in following[:20] or "set" in following[:20]
        ):
            continue
        sig = f"public {ret} {name}({params})"
        if sig not in seen:
            seen.add(sig)
            members.append(PublicMember("method", name, sig))

    for m in prop_pat.finditer(body):
        ptype = " ".join(m.group(1).split())
        name = m.group(2).strip()
        # Determine accessor kind (get/set/init) from the block
        brace_start = m.end() - 1  # position of '{'
        brace_end = find_matching_brace(body, brace_start)
        if brace_end < 0:
            continue
        accessor_block = body[brace_start:brace_end + 1]
        has_get = bool(re.search(r'\bget\b', accessor_block))
        has_set = bool(re.search(r'\bset\b', accessor_block))
        has_init = bool(re.search(r'\binit\b', accessor_block))
        if not has_get and not has_set and not has_init:
            continue  # Not a property accessor block
        accessors = []
        if has_get:
            accessors.append('get')
        if has_set:
            accessors.append('set')
        if has_init:
            accessors.append('init')
        accessor_str = '; '.join(accessors) + ';'
        sig = f"public {ptype} {name} {{ {accessor_str} }}"
        if sig not in seen:
            seen.add(sig)
            members.append(PublicMember("property", name, sig))

    for m in field_pat.finditer(body):
        ftype = " ".join(m.group(1).split())
        name = m.group(2).strip()
        if name in {mb.name for mb in members if mb.kind in {"property", "method"}}:
            continue
        sig = f"public {ftype} {name}"
        if sig not in seen:
            seen.add(sig)
            members.append(PublicMember("field", name, sig))

    return members


# ---------------------------------------------------------------------------
# Model parsing & map building
# ---------------------------------------------------------------------------

def parse_model(content: str, file_path: str) -> Optional[ModelType]:
    type_kind, type_name, body = extract_type_block(content)
    if not type_kind or not type_name:
        return None
    model = ModelType(
        type_name=type_name, type_kind=type_kind, file_path=file_path
    )
    if type_kind == "enum":
        model.enum_members = extract_enum_members(body)
    else:
        model.public_members = extract_public_members(type_name, body)
    return model


def build_model_map(
    file_paths: set[Path],
    workspace: Path,
    from_revision: Optional[str],
) -> dict[str, ModelType]:
    models: dict[str, ModelType] = {}
    for rp in sorted(file_paths):
        if from_revision:
            content = get_file_from_revision(rp, workspace, from_revision)
            if content is None:
                continue
        else:
            content = (workspace / rp).read_text(encoding="utf-8")
        model = parse_model(content, str(rp))
        if model:
            models[model.type_name] = model
    return models


# ---------------------------------------------------------------------------
# Comparison helpers
# ---------------------------------------------------------------------------

def normalize_signature(signature: str) -> str:
    """Treat ``= null`` and ``= default`` as equivalent."""
    return re.sub(r"=\s*(null|default)\b", "= default", signature)


def compare_members(old: ModelType, new: ModelType) -> dict[str, list]:
    old_by_key: dict[tuple[str, str], set[str]] = {}
    new_by_key: dict[tuple[str, str], set[str]] = {}

    for mb in old.public_members:
        old_by_key.setdefault((mb.kind, mb.name), set()).add(mb.signature)
    for mb in new.public_members:
        new_by_key.setdefault((mb.kind, mb.name), set()).add(mb.signature)

    old_keys = set(old_by_key)
    new_keys = set(new_by_key)

    removed: list[str] = []
    added: list[str] = []
    changed: list[dict] = []

    for k in sorted(old_keys - new_keys):
        removed.extend(sorted(old_by_key[k]))
    for k in sorted(new_keys - old_keys):
        added.extend(sorted(new_by_key[k]))
    for k in sorted(old_keys & new_keys):
        old_norm = {normalize_signature(s) for s in old_by_key[k]}
        new_norm = {normalize_signature(s) for s in new_by_key[k]}
        if old_norm != new_norm:
            changed.append({
                "kind": k[0], "name": k[1],
                "old": sorted(old_by_key[k]),
                "new": sorted(new_by_key[k]),
            })

    return {"added": added, "removed": removed, "changed": changed}


def compare_enums(old: ModelType, new: ModelType) -> dict[str, list[str]]:
    old_vals = set(old.enum_members)
    new_vals = set(new.enum_members)
    return {
        "added": sorted(new_vals - old_vals),
        "removed": sorted(old_vals - new_vals),
    }


# ---------------------------------------------------------------------------
# Main
# ---------------------------------------------------------------------------

def main() -> None:
    script_dir = Path(__file__).resolve().parent
    project_root = get_project_root(script_dir)
    git_root = get_git_root(project_root)

    project_rel = project_root.relative_to(git_root)
    generated_rel = project_rel / "src" / "Generated"
    models_rel = generated_rel / "Models"
    models_dir = git_root / models_rel
    generated_dir = git_root / generated_rel
    output_path = script_dir / "model_diff_result.txt"

    if not models_dir.exists():
        print(f"Error: {models_dir} not found")
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
        print(f"Error: baseline commit '{baseline_commit}' is not valid: {stderr.strip()}")
        sys.exit(1)

    print(f"Using baseline commit: {baseline_commit}")

    print("Getting model files from baseline commit...")
    baseline_files = list_revision_model_files(models_rel, git_root, baseline_commit)
    baseline_data_files = list_revision_data_files(generated_rel, git_root, baseline_commit)
    baseline_files |= baseline_data_files
    print(f"Found {len(baseline_files)} model files in baseline (including {len(baseline_data_files)} *Data.cs)")

    print("\nGetting current model files (post-generated)...")
    current_files = list_current_model_files(models_dir, git_root)
    current_data_files = list_current_data_files(generated_dir, git_root)
    current_files |= current_data_files
    print(f"Found {len(current_files)} model files in current (including {len(current_data_files)} *Data.cs)")

    print("\nParsing baseline models...")
    baseline_models = build_model_map(baseline_files, git_root, baseline_commit)
    print(f"Parsed {len(baseline_models)} model types from baseline")

    print("\nParsing current models...")
    current_models = build_model_map(current_files, git_root, None)
    print(f"Parsed {len(current_models)} model types from current")

    # ── Build output ──────────────────────────────────────────────────
    lines: list[str] = []
    lines.append("=" * 100)
    lines.append("MODEL DIFF ANALYSIS")
    lines.append(f"Comparing baseline ({baseline_commit}) vs Current (post-generated)")
    lines.append("=" * 100)

    baseline_names = set(baseline_models)
    current_names = set(current_models)

    removed_models = sorted(baseline_names - current_names)
    added_models = sorted(current_names - baseline_names)
    common_models = sorted(baseline_names & current_names)

    # ── Removed ───────────────────────────────────────────────────────
    if removed_models:
        lines.append("")
        lines.append("-" * 80)
        lines.append("REMOVED MODELS (in baseline but not in current)")
        lines.append("-" * 80)
        for name in removed_models:
            m = baseline_models[name]
            lines.append(f"\n  {name} ({m.type_kind})")
            lines.append(f"    File: {Path(m.file_path).name}")

    # ── Added ─────────────────────────────────────────────────────────
    if added_models:
        lines.append("")
        lines.append("-" * 80)
        lines.append("ADDED MODELS (in current but not in baseline)")
        lines.append("-" * 80)
        for name in added_models:
            m = current_models[name]
            lines.append(f"\n  {name} ({m.type_kind})")
            lines.append(f"    File: {Path(m.file_path).name}")

    # ── Modified ──────────────────────────────────────────────────────
    modified_models: list[str] = []

    for name in common_models:
        old_m = baseline_models[name]
        new_m = current_models[name]

        # Type kind changed
        if old_m.type_kind != new_m.type_kind:
            modified_models.append(name)
            lines.append("")
            lines.append("-" * 80)
            lines.append("MODEL TYPE KIND CHANGES")
            lines.append("-" * 80)
            lines.append(f"\n{name}")
            lines.append(f"  OLD kind: {old_m.type_kind}")
            lines.append(f"  NEW kind: {new_m.type_kind}")
            continue

        # Enum diff
        if old_m.type_kind == "enum":
            ediff = compare_enums(old_m, new_m)
            if ediff["added"] or ediff["removed"]:
                modified_models.append(name)
                lines.append("")
                lines.append("-" * 80)
                lines.append("MODIFIED ENUMS")
                lines.append("-" * 80)
                lines.append(f"\n{name}")
                if ediff["added"]:
                    lines.append(f"  + Added values ({len(ediff['added'])}):")
                    for v in ediff["added"]:
                        lines.append(f"      + {v}")
                if ediff["removed"]:
                    lines.append(f"  - Removed values ({len(ediff['removed'])}):")
                    for v in ediff["removed"]:
                        lines.append(f"      - {v}")
            continue

        # Class / struct member diff
        mdiff = compare_members(old_m, new_m)
        if not mdiff["added"] and not mdiff["removed"] and not mdiff["changed"]:
            continue

        modified_models.append(name)
        lines.append("")
        lines.append("-" * 80)
        lines.append("MODIFIED MODELS (public member changes)")
        lines.append("-" * 80)
        lines.append(f"\n{name}")
        lines.append(f"  File: {Path(new_m.file_path).name}")

        if mdiff["added"]:
            lines.append(f"\n  + Added members ({len(mdiff['added'])}):")
            for sig in mdiff["added"]:
                lines.append(f"      + {sig}")
        if mdiff["removed"]:
            lines.append(f"\n  - Removed members ({len(mdiff['removed'])}):")
            for sig in mdiff["removed"]:
                lines.append(f"      - {sig}")
        if mdiff["changed"]:
            lines.append(f"\n  ~ Changed members ({len(mdiff['changed'])}):")
            for c in mdiff["changed"]:
                lines.append(f"      ~ {c['kind']} {c['name']}")
                lines.append("        OLD:")
                for s in c["old"]:
                    lines.append(f"          - {s}")
                lines.append("        NEW:")
                for s in c["new"]:
                    lines.append(f"          + {s}")

    unchanged_count = len(common_models) - len(modified_models)

    # ── Detect "Missing setter" models ────────────────────────────────
    # A property is "missing setter" when:
    #   - The baseline had { get; set; } but the current only has { get; }
    #   - This happens when a model is output-only in TypeSpec (usage: Output)
    #     but the baseline (autorest) treated it as input+output
    missing_setter_models: list[tuple[str, list[str]]] = []  # (model_name, [prop_names])
    for name in modified_models:
        old_m = baseline_models[name]
        new_m = current_models[name]
        if old_m.type_kind == "enum" or new_m.type_kind == "enum":
            continue
        old_props = {mb.name: mb.signature for mb in old_m.public_members if mb.kind == "property"}
        new_props = {mb.name: mb.signature for mb in new_m.public_members if mb.kind == "property"}
        lost_setters: list[str] = []
        for prop_name in sorted(old_props.keys() & new_props.keys()):
            old_sig = old_props[prop_name]
            new_sig = new_props[prop_name]
            old_has_set = bool(re.search(r'\bset\b', old_sig))
            new_has_set = bool(re.search(r'\bset\b', new_sig))
            if old_has_set and not new_has_set:
                lost_setters.append(prop_name)
        if lost_setters:
            missing_setter_models.append((name, lost_setters))

    # ── Detect "Properties flattened" models ──────────────────────────
    # A model is "flattened in baseline" when:
    #   - The current version added a single "Properties" property
    #   - The baseline had multiple individual properties that are now removed
    flattened_models: list[tuple[str, str]] = []  # (model_name, properties_type)
    for name in modified_models:
        old_m = baseline_models[name]
        new_m = current_models[name]
        if old_m.type_kind == "enum" or new_m.type_kind == "enum":
            continue
        mdiff = compare_members(old_m, new_m)
        # Look for an added property named "Properties"
        props_sig = ""
        for sig in mdiff["added"]:
            if re.search(r"\bProperties\b\s*\{", sig):
                props_sig = sig
                break
        if props_sig and mdiff["removed"]:
            # Extract the type of the Properties property
            tm = re.search(r"public\s+([\w<>,\.\[\]\s\?]+?)\s+Properties\s*\{", props_sig)
            props_type = tm.group(1).strip() if tm else "?"
            flattened_models.append((name, props_type))

    # ── Summary ───────────────────────────────────────────────────────
    lines.append("")
    lines.append("=" * 100)
    lines.append("SUMMARY")
    lines.append("=" * 100)
    lines.append(f"Models in baseline:     {len(baseline_models)}")
    lines.append(f"Models in current:      {len(current_models)}")
    lines.append("")
    lines.append(f"Removed models ({len(removed_models)}):")
    for name in removed_models:
        lines.append(f"  - {name}")
    lines.append(f"Added models ({len(added_models)}):")
    for name in added_models:
        lines.append(f"  + {name}")
    lines.append(f"Modified models ({len(modified_models)}):")
    for name in modified_models:
        lines.append(f"  ~ {name}")
    lines.append(f"Unchanged models ({unchanged_count}):")

    if flattened_models:
        lines.append("")
        lines.append("-" * 80)
        lines.append(
            "FLATTENED → PROPERTIES (baseline had flattened properties, "
            "current wraps them in a Properties property)"
        )
        lines.append("-" * 80)
        for name, props_type in flattened_models:
            lines.append(f"  {name}  →  {props_type}")

    if missing_setter_models:
        lines.append("")
        lines.append("-" * 80)
        lines.append(
            "MISSING SETTERS (baseline had { get; set; } but current only has { get; })"
        )
        lines.append(
            "Fix: Add @@usage(ModelName, Usage.input, \"csharp\"); to client.tsp"
        )
        lines.append("-" * 80)
        for name, props in missing_setter_models:
            lines.append(f"  {name}")
            for p in props:
                lines.append(f"    - {p}")

    if not removed_models and not added_models and not modified_models:
        lines.append("")
        lines.append("No differences found between baseline and current generated models.")

    output_content = "\n".join(lines)
    output_path.write_text(output_content, encoding="utf-8")

    print(output_content)
    print(f"\n\nOutput written to {output_path}")


if __name__ == "__main__":
    main()
