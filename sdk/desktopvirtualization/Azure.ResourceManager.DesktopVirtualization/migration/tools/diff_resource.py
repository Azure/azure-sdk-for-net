#!/usr/bin/env python3
"""
Diff resource classes between baseline commit and newly generated versions.

This script:
1. Reads the baseline commit from info.txt
2. Gets the list of resource classes from baseline commit (pre-generated)
3. Compares with current generated resource classes
4. For missing resources, shows diagnostic info
5. For existing resources, compares public methods to find diffs
"""

import re
import subprocess
import sys
from pathlib import Path
from dataclasses import dataclass, field
from typing import Optional


@dataclass
class PublicMethod:
    """Represents a public method in a resource class."""
    signature: str
    name: str
    return_type: str
    parameters: str
    is_async: bool = False
    is_static: bool = False


@dataclass
class ResourceClass:
    """Represents a resource class with its public methods."""
    class_name: str
    file_path: str
    resource_id_pattern: str = ""
    public_methods: list[PublicMethod] = field(default_factory=list)


def run_git_command(args: list[str], cwd: Path) -> tuple[int, str, str]:
    """Run a git command and return (returncode, stdout, stderr)."""
    result = subprocess.run(
        ["git"] + args,
        cwd=cwd,
        capture_output=True,
        text=True
    )
    return result.returncode, result.stdout, result.stderr


def read_baseline_commit(info_path: Path) -> str:
    """Read baseline commit ID from info.txt."""
    if not info_path.exists():
        print(f"Error: {info_path} not found")
        sys.exit(1)
    content = info_path.read_text(encoding='utf-8')
    for line in content.splitlines():
        if line.startswith('baseline commit id:'):
            return line.split(':', 1)[1].strip()
    print(f"Error: 'baseline commit id' not found in {info_path}")
    sys.exit(1)


def get_file_from_commit(file_path: Path, workspace: Path, commit: str) -> Optional[str]:
    """Get file content from a specific git commit."""
    relative_path = file_path.relative_to(workspace)
    returncode, stdout, stderr = run_git_command(
        ["show", f"{commit}:{relative_path}"],
        workspace
    )
    if returncode == 0:
        return stdout
    return None


def extract_public_methods(content: str) -> list[PublicMethod]:
    """Extract all public methods from C# class content."""
    methods = []
    
    # Pattern for public methods (including async, virtual, static, override)
    # Matches: public [static] [virtual|override] [async] ReturnType MethodName(params)
    method_pattern = re.compile(
        r'^\s*public\s+'
        r'(static\s+)?'
        r'(virtual\s+|override\s+)?'
        r'(async\s+)?'
        r'([\w<>,\[\]\s\?]+?)\s+'  # return type
        r'(\w+)\s*'  # method name
        r'\(([^)]*)\)',  # parameters
        re.MULTILINE
    )
    
    for match in method_pattern.finditer(content):
        is_static = match.group(1) is not None
        is_async = match.group(3) is not None
        return_type = match.group(4).strip()
        method_name = match.group(5).strip()
        parameters = match.group(6).strip()
        
        # Skip properties (they have get/set after)
        # Check if this is followed by { get or { set
        end_pos = match.end()
        following = content[end_pos:end_pos+50].strip()
        if following.startswith('{') and ('get' in following[:20] or 'set' in following[:20]):
            continue
        
        # Skip constructors
        if return_type == method_name or method_name.endswith('Resource'):
            continue
            
        signature = f"public {'static ' if is_static else ''}{'async ' if is_async else ''}{return_type} {method_name}({parameters})"
        
        methods.append(PublicMethod(
            signature=signature,
            name=method_name,
            return_type=return_type,
            parameters=parameters,
            is_async=is_async,
            is_static=is_static
        ))
    
    return methods


def extract_resource_id_pattern(content: str) -> str:
    """Extract resource ID pattern from CreateResourceIdentifier method."""
    match = re.search(
        r'var resourceId = \$"([^"]+)"',
        content
    )
    return match.group(1) if match else ""


def parse_resource_class(content: str, file_path: str) -> Optional[ResourceClass]:
    """Parse a resource class from its content."""
    # Extract class name
    class_match = re.search(r'public partial class (\w+Resource)\s*:', content)
    if not class_match:
        return None
    
    class_name = class_match.group(1)
    resource_id = extract_resource_id_pattern(content)
    methods = extract_public_methods(content)
    
    return ResourceClass(
        class_name=class_name,
        file_path=file_path,
        resource_id_pattern=resource_id,
        public_methods=methods
    )


def parse_collection_class(content: str, file_path: str) -> Optional[ResourceClass]:
    """Parse a collection class from its content."""
    class_match = re.search(r'public partial class (\w+Collection)\s*:', content)
    if not class_match:
        return None
    
    class_name = class_match.group(1)
    methods = extract_public_methods(content)
    
    return ResourceClass(
        class_name=class_name,
        file_path=file_path,
        public_methods=methods
    )


def get_current_resources(generated_dir: Path) -> dict[str, ResourceClass]:
    """Get currently generated resource classes."""
    resources = {}
    
    for cs_file in generated_dir.glob('*Resource.cs'):
        if 'Collection' in cs_file.name or '.Serialization.' in cs_file.name:
            continue
        
        content = cs_file.read_text(encoding='utf-8')
        resource = parse_resource_class(content, str(cs_file))
        if resource:
            resources[resource.class_name] = resource
    
    return resources


def get_current_collections(generated_dir: Path) -> dict[str, ResourceClass]:
    """Get currently generated collection classes."""
    collections = {}
    
    for cs_file in generated_dir.glob('*Collection.cs'):
        if '.Serialization.' in cs_file.name:
            continue
        
        content = cs_file.read_text(encoding='utf-8')
        collection = parse_collection_class(content, str(cs_file))
        if collection:
            collections[collection.class_name] = collection
    
    return collections


def get_baseline_resources(generated_dir: Path, workspace: Path, commit: str) -> dict[str, ResourceClass]:
    """Get resource classes from baseline commit, including files that may have been deleted."""
    resources = {}

    # Use git ls-tree to list files at the baseline commit, so we also find deleted files
    relative_dir = generated_dir.relative_to(workspace)
    returncode, stdout, _ = run_git_command(
        ["ls-tree", "--name-only", commit, str(relative_dir) + "/"],
        workspace
    )
    if returncode != 0:
        return resources

    for line in stdout.strip().splitlines():
        file_path = workspace / line
        if not file_path.name.endswith('Resource.cs'):
            continue
        if 'Collection' in file_path.name or '.Serialization.' in file_path.name:
            continue

        content = get_file_from_commit(file_path, workspace, commit)
        if content:
            resource = parse_resource_class(content, str(file_path))
            if resource:
                resources[resource.class_name] = resource

    return resources


def get_baseline_collections(generated_dir: Path, workspace: Path, commit: str) -> dict[str, ResourceClass]:
    """Get collection classes from baseline commit, including files that may have been deleted."""
    collections = {}

    relative_dir = generated_dir.relative_to(workspace)
    returncode, stdout, _ = run_git_command(
        ["ls-tree", "--name-only", commit, str(relative_dir) + "/"],
        workspace
    )
    if returncode != 0:
        return collections

    for line in stdout.strip().splitlines():
        file_path = workspace / line
        if not file_path.name.endswith('Collection.cs'):
            continue
        if '.Serialization.' in file_path.name:
            continue

        content = get_file_from_commit(file_path, workspace, commit)
        if content:
            collection = parse_collection_class(content, str(file_path))
            if collection:
                collections[collection.class_name] = collection

    return collections


def normalize_signature(signature: str) -> str:
    """Normalize a signature for comparison purposes.

    Treats ``= null`` and ``= default`` as equivalent so that trivial
    default-value changes are not reported as diffs.
    """
    return re.sub(r'=\s*(null|default)\b', '= default', signature)


def compare_methods(
    old_methods: list[PublicMethod],
    new_methods: list[PublicMethod]
) -> dict:
    """Compare two lists of methods and return differences."""
    old_by_name = {m.name: m for m in old_methods}
    new_by_name = {m.name: m for m in new_methods}
    
    old_names = set(old_by_name.keys())
    new_names = set(new_by_name.keys())
    
    added = new_names - old_names
    removed = old_names - new_names
    common = old_names & new_names
    
    changed = []
    for name in common:
        old_m = old_by_name[name]
        new_m = new_by_name[name]
        if normalize_signature(old_m.signature) != normalize_signature(new_m.signature):
            changed.append({
                'name': name,
                'old': old_m.signature,
                'new': new_m.signature
            })
    
    return {
        'added': [new_by_name[n] for n in sorted(added)],
        'removed': [old_by_name[n] for n in sorted(removed)],
        'changed': changed
    }


def main():
    # Determine paths
    script_dir = Path(__file__).parent
    workspace = script_dir
    
    # Find git root
    returncode, stdout, _ = run_git_command(["rev-parse", "--show-toplevel"], script_dir)
    if returncode == 0:
        workspace = Path(stdout.strip())
    
    project_root = script_dir.parent.parent
    generated_dir = project_root / 'src' / 'Generated'
    info_path = script_dir.parent / 'info.txt'
    output_path = script_dir / 'resource_diff_result.txt'
    
    if not generated_dir.exists():
        print(f"Error: {generated_dir} not found")
        sys.exit(1)
    
    baseline_commit = read_baseline_commit(info_path)
    print(f"Using baseline commit: {baseline_commit}")
    
    print("\nGetting resources from baseline (pre-generated)...")
    baseline_resources = get_baseline_resources(generated_dir, workspace, baseline_commit)
    print(f"Found {len(baseline_resources)} resources in baseline")
    
    print("\nGetting current resources (post-generated)...")
    current_resources = get_current_resources(generated_dir)
    print(f"Found {len(current_resources)} resources in current")
    
    print("\nGetting collections from baseline (pre-generated)...")
    baseline_collections = get_baseline_collections(generated_dir, workspace, baseline_commit)
    print(f"Found {len(baseline_collections)} collections in baseline")
    
    print("\nGetting current collections (post-generated)...")
    current_collections = get_current_collections(generated_dir)
    print(f"Found {len(current_collections)} collections in current")
    
    # Build output
    lines = []
    
    lines.append("=" * 100)
    lines.append("RESOURCE & COLLECTION DIFF ANALYSIS")
    lines.append(f"Comparing baseline ({baseline_commit[:12]}) vs Current (post-generated)")
    lines.append("=" * 100)
    
    baseline_names = set(baseline_resources.keys())
    current_names = set(current_resources.keys())
    
    # Resources removed (in baseline but not in current)
    removed_resources = baseline_names - current_names
    if removed_resources:
        lines.append("")
        lines.append("-" * 80)
        lines.append("REMOVED RESOURCES (in baseline but not in current)")
        lines.append("-" * 80)
        for name in sorted(removed_resources):
            resource = baseline_resources[name]
            lines.append(f"\n  {name}")
            lines.append(f"    Resource ID: {resource.resource_id_pattern}")
            lines.append(f"    File: {Path(resource.file_path).name}")
            lines.append(f"    Had {len(resource.public_methods)} public methods")
    
    # Resources added (in current but not in baseline)
    added_resources = current_names - baseline_names
    if added_resources:
        lines.append("")
        lines.append("-" * 80)
        lines.append("ADDED RESOURCES (in current but not in baseline)")
        lines.append("-" * 80)
        for name in sorted(added_resources):
            resource = current_resources[name]
            lines.append(f"\n  {name}")
            lines.append(f"    Resource ID: {resource.resource_id_pattern}")
            lines.append(f"    File: {Path(resource.file_path).name}")
            lines.append(f"    Has {len(resource.public_methods)} public methods")
    
    # Compare common resources
    common_resources = baseline_names & current_names
    resources_with_changes = []
    
    for name in sorted(common_resources):
        base_res = baseline_resources[name]
        curr_res = current_resources[name]
        
        diff = compare_methods(base_res.public_methods, curr_res.public_methods)
        
        if diff['added'] or diff['removed'] or diff['changed']:
            resources_with_changes.append((name, base_res, curr_res, diff))
    
    if resources_with_changes:
        lines.append("")
        lines.append("-" * 80)
        lines.append("MODIFIED RESOURCES (method changes)")
        lines.append("-" * 80)
        
        for name, base_res, curr_res, diff in resources_with_changes:
            lines.append(f"\n{name}")
            lines.append(f"  File: {Path(curr_res.file_path).name}")
            
            if diff['added']:
                lines.append(f"\n  + Added methods ({len(diff['added'])}):")
                for method in diff['added']:
                    lines.append(f"      + {method.signature}")
            
            if diff['removed']:
                lines.append(f"\n  - Removed methods ({len(diff['removed'])}):")
                for method in diff['removed']:
                    lines.append(f"      - {method.signature}")
            
            if diff['changed']:
                lines.append(f"\n  ~ Changed methods ({len(diff['changed'])}):")
                for change in diff['changed']:
                    lines.append(f"      ~ {change['name']}")
                    lines.append(f"        OLD: {change['old']}")
                    lines.append(f"        NEW: {change['new']}")
    
    # Unchanged resources
    unchanged_count = len(common_resources) - len(resources_with_changes)
    
    # ==================== COLLECTION DIFF ====================
    baseline_col_names = set(baseline_collections.keys())
    current_col_names = set(current_collections.keys())
    
    # Collections removed
    removed_collections = baseline_col_names - current_col_names
    if removed_collections:
        lines.append("")
        lines.append("-" * 80)
        lines.append("REMOVED COLLECTIONS (in baseline but not in current)")
        lines.append("-" * 80)
        for name in sorted(removed_collections):
            col = baseline_collections[name]
            lines.append(f"\n  {name}")
            lines.append(f"    File: {Path(col.file_path).name}")
            lines.append(f"    Had {len(col.public_methods)} public methods")
    
    # Collections added
    added_collections = current_col_names - baseline_col_names
    if added_collections:
        lines.append("")
        lines.append("-" * 80)
        lines.append("ADDED COLLECTIONS (in current but not in baseline)")
        lines.append("-" * 80)
        for name in sorted(added_collections):
            col = current_collections[name]
            lines.append(f"\n  {name}")
            lines.append(f"    File: {Path(col.file_path).name}")
            lines.append(f"    Has {len(col.public_methods)} public methods")
    
    # Compare common collections
    common_collections = baseline_col_names & current_col_names
    collections_with_changes = []
    
    for name in sorted(common_collections):
        base_col = baseline_collections[name]
        curr_col = current_collections[name]
        
        diff = compare_methods(base_col.public_methods, curr_col.public_methods)
        
        if diff['added'] or diff['removed'] or diff['changed']:
            collections_with_changes.append((name, base_col, curr_col, diff))
    
    if collections_with_changes:
        lines.append("")
        lines.append("-" * 80)
        lines.append("MODIFIED COLLECTIONS (method changes)")
        lines.append("-" * 80)
        
        for name, base_col, curr_col, diff in collections_with_changes:
            lines.append(f"\n{name}")
            lines.append(f"  File: {Path(curr_col.file_path).name}")
            
            if diff['added']:
                lines.append(f"\n  + Added methods ({len(diff['added'])}):") 
                for method in diff['added']:
                    lines.append(f"      + {method.signature}")
            
            if diff['removed']:
                lines.append(f"\n  - Removed methods ({len(diff['removed'])}):") 
                for method in diff['removed']:
                    lines.append(f"      - {method.signature}")
            
            if diff['changed']:
                lines.append(f"\n  ~ Changed methods ({len(diff['changed'])}):") 
                for change in diff['changed']:
                    lines.append(f"      ~ {change['name']}")
                    lines.append(f"        OLD: {change['old']}")
                    lines.append(f"        NEW: {change['new']}")
    
    unchanged_col_count = len(common_collections) - len(collections_with_changes)
    
    # Summary
    lines.append("")
    lines.append("=" * 100)
    lines.append("SUMMARY")
    lines.append("=" * 100)
    lines.append("--- Resources ---")
    lines.append(f"Resources in baseline:  {len(baseline_resources)}")
    lines.append(f"Resources in current:   {len(current_resources)}")
    lines.append(f"")
    lines.append(f"Removed resources ({len(removed_resources)}):")
    for name in sorted(removed_resources):
        lines.append(f"  - {name}")
    lines.append(f"Added resources ({len(added_resources)}):")
    for name in sorted(added_resources):
        lines.append(f"  + {name}")
    lines.append(f"Modified resources ({len(resources_with_changes)}):")
    for name, _, _, _ in resources_with_changes:
        lines.append(f"  ~ {name}")
    unchanged_resources = common_resources - {name for name, _, _, _ in resources_with_changes}
    lines.append(f"Unchanged resources ({unchanged_count}):")
    for name in sorted(unchanged_resources):
        lines.append(f"    {name}")
    
    lines.append("")
    lines.append("--- Collections ---")
    lines.append(f"Collections in baseline:  {len(baseline_collections)}")
    lines.append(f"Collections in current:   {len(current_collections)}")
    lines.append(f"")
    lines.append(f"Removed collections ({len(removed_collections)}):")
    for name in sorted(removed_collections):
        lines.append(f"  - {name}")
    lines.append(f"Added collections ({len(added_collections)}):")
    for name in sorted(added_collections):
        lines.append(f"  + {name}")
    lines.append(f"Modified collections ({len(collections_with_changes)}):")
    for name, _, _, _ in collections_with_changes:
        lines.append(f"  ~ {name}")
    unchanged_collections = common_collections - {name for name, _, _, _ in collections_with_changes}
    lines.append(f"Unchanged collections ({unchanged_col_count}):")
    for name in sorted(unchanged_collections):
        lines.append(f"    {name}")
    
    has_resource_diff = removed_resources or added_resources or resources_with_changes
    has_collection_diff = removed_collections or added_collections or collections_with_changes
    if not has_resource_diff and not has_collection_diff:
        lines.append("")
        lines.append("No differences found between baseline and current generated code.")
    
    # Write to file
    output_content = '\n'.join(lines)
    with open(output_path, 'w', encoding='utf-8') as f:
        f.write(output_content)
    
    # Print to console
    print(output_content)
    print(f"\n\nOutput written to {output_path}")


if __name__ == "__main__":
    main()
