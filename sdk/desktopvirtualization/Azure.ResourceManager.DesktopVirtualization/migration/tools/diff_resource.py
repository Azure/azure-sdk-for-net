#!/usr/bin/env python3
"""
Diff resource classes between pre-generated (HEAD) and newly generated versions.

This script:
1. Gets the list of resource classes from git HEAD (pre-generated)
2. Compares with current generated resource classes
3. For missing resources, shows diagnostic info
4. For existing resources, compares public methods to find diffs
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


def get_file_from_head(file_path: Path, workspace: Path) -> Optional[str]:
    """Get file content from git HEAD."""
    relative_path = file_path.relative_to(workspace)
    returncode, stdout, stderr = run_git_command(
        ["show", f"HEAD:{relative_path}"],
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


def get_head_resources(generated_dir: Path, workspace: Path) -> dict[str, ResourceClass]:
    """Get resource classes from git HEAD."""
    resources = {}
    
    for cs_file in generated_dir.glob('*Resource.cs'):
        if 'Collection' in cs_file.name or '.Serialization.' in cs_file.name:
            continue
        
        content = get_file_from_head(cs_file, workspace)
        if content:
            resource = parse_resource_class(content, str(cs_file))
            if resource:
                resources[resource.class_name] = resource
    
    return resources


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
        if old_m.signature != new_m.signature:
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
    
    generated_dir = script_dir / 'src' / 'Generated'
    output_path = script_dir / 'diff_result.txt'
    
    if not generated_dir.exists():
        print(f"Error: {generated_dir} not found")
        sys.exit(1)
    
    print("Getting resources from HEAD (pre-generated)...")
    head_resources = get_head_resources(generated_dir, workspace)
    print(f"Found {len(head_resources)} resources in HEAD")
    
    print("\nGetting current resources (post-generated)...")
    current_resources = get_current_resources(generated_dir)
    print(f"Found {len(current_resources)} resources in current")
    
    # Build output
    lines = []
    
    lines.append("=" * 100)
    lines.append("RESOURCE DIFF ANALYSIS")
    lines.append("Comparing HEAD (pre-generated) vs Current (post-generated)")
    lines.append("=" * 100)
    
    head_names = set(head_resources.keys())
    current_names = set(current_resources.keys())
    
    # Resources removed (in HEAD but not in current)
    removed_resources = head_names - current_names
    if removed_resources:
        lines.append("")
        lines.append("-" * 80)
        lines.append("REMOVED RESOURCES (in HEAD but not in current)")
        lines.append("-" * 80)
        for name in sorted(removed_resources):
            resource = head_resources[name]
            lines.append(f"\n  {name}")
            lines.append(f"    Resource ID: {resource.resource_id_pattern}")
            lines.append(f"    File: {Path(resource.file_path).name}")
            lines.append(f"    Had {len(resource.public_methods)} public methods")
    
    # Resources added (in current but not in HEAD)
    added_resources = current_names - head_names
    if added_resources:
        lines.append("")
        lines.append("-" * 80)
        lines.append("ADDED RESOURCES (in current but not in HEAD)")
        lines.append("-" * 80)
        for name in sorted(added_resources):
            resource = current_resources[name]
            lines.append(f"\n  {name}")
            lines.append(f"    Resource ID: {resource.resource_id_pattern}")
            lines.append(f"    File: {Path(resource.file_path).name}")
            lines.append(f"    Has {len(resource.public_methods)} public methods")
    
    # Compare common resources
    common_resources = head_names & current_names
    resources_with_changes = []
    
    for name in sorted(common_resources):
        head_res = head_resources[name]
        curr_res = current_resources[name]
        
        diff = compare_methods(head_res.public_methods, curr_res.public_methods)
        
        if diff['added'] or diff['removed'] or diff['changed']:
            resources_with_changes.append((name, head_res, curr_res, diff))
    
    if resources_with_changes:
        lines.append("")
        lines.append("-" * 80)
        lines.append("MODIFIED RESOURCES (method changes)")
        lines.append("-" * 80)
        
        for name, head_res, curr_res, diff in resources_with_changes:
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
    
    # Summary
    lines.append("")
    lines.append("=" * 100)
    lines.append("SUMMARY")
    lines.append("=" * 100)
    lines.append(f"Resources in HEAD:      {len(head_resources)}")
    lines.append(f"Resources in current:   {len(current_resources)}")
    lines.append(f"")
    lines.append(f"Removed resources:      {len(removed_resources)}")
    lines.append(f"Added resources:        {len(added_resources)}")
    lines.append(f"Modified resources:     {len(resources_with_changes)}")
    lines.append(f"Unchanged resources:    {unchanged_count}")
    
    if not removed_resources and not added_resources and not resources_with_changes:
        lines.append("")
        lines.append("No differences found between HEAD and current generated resources.")
    
    # Write to file
    output_content = '\n'.join(lines)
    with open(output_path, 'w', encoding='utf-8') as f:
        f.write(output_content)
    
    # Print to console
    print(output_content)
    print(f"\n\nOutput written to {output_path}")


if __name__ == "__main__":
    main()
