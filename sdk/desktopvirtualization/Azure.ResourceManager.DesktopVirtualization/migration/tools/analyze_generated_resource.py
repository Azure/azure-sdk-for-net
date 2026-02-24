#!/usr/bin/env python3
"""
Analyze generated resource classes.

This script:
1. Checks if the resource id of each generated resource class matches any resource in resourceSchema.json
2. Sorts the resource ids from shortest to longest
"""

import json
import re
import sys
from pathlib import Path
from dataclasses import dataclass
from typing import Optional


@dataclass
class ResourceClass:
    """Represents a generated resource class."""
    file_path: str
    class_name: str
    resource_id_pattern: str
    matched: bool = False
    matched_schema_name: str = ""
    matched_schema_model: str = ""


@dataclass
class SchemaResource:
    """Represents a resource from resourceSchema.json."""
    resource_model_id: str
    resource_id_pattern: str
    resource_type: str
    resource_name: str


def extract_resource_id_from_class(file_path: Path) -> Optional[ResourceClass]:
    """
    Extract the resourceId pattern from a generated *Resource.cs file.
    """
    content = file_path.read_text(encoding='utf-8')
    
    # Extract class name
    class_match = re.search(r'public partial class (\w+Resource)\s*:', content)
    if not class_match:
        return None
    class_name = class_match.group(1)
    
    # Extract resourceId pattern from CreateResourceIdentifier method
    resource_id_match = re.search(
        r'public static ResourceIdentifier CreateResourceIdentifier\([^)]*\)\s*\{[^}]*var resourceId = \$"([^"]+)"',
        content,
        re.DOTALL
    )
    
    if not resource_id_match:
        return None
    
    resource_id_pattern = resource_id_match.group(1)
    
    return ResourceClass(
        file_path=str(file_path),
        class_name=class_name,
        resource_id_pattern=resource_id_pattern
    )


def load_schema_resources(schema_path: Path) -> list[SchemaResource]:
    """Load resources from resourceSchema.json."""
    with open(schema_path, 'r', encoding='utf-8') as f:
        schema = json.load(f)
    
    resources = []
    for resource in schema.get('arguments', {}).get('resources', []):
        resources.append(SchemaResource(
            resource_model_id=resource.get('resourceModelId', ''),
            resource_id_pattern=resource.get('resourceIdPattern', ''),
            resource_type=resource.get('resourceType', ''),
            resource_name=resource.get('resourceName', '')
        ))
    
    return resources


def normalize_pattern(pattern: str) -> str:
    """
    Normalize a resource ID pattern for comparison.
    Replace parameter placeholders with a generic marker.
    """
    return re.sub(r'\{[^}]+\}', '{*}', pattern)


def analyze_resources(
    resource_classes: list[ResourceClass],
    schema_resources: list[SchemaResource]
) -> list[ResourceClass]:
    """
    Analyze resource classes against schema resources.
    Returns the list with matched status updated.
    """
    for resource_class in resource_classes:
        normalized_class_pattern = normalize_pattern(resource_class.resource_id_pattern)
        
        for schema_resource in schema_resources:
            normalized_schema_pattern = normalize_pattern(schema_resource.resource_id_pattern)
            
            if normalized_class_pattern == normalized_schema_pattern:
                resource_class.matched = True
                resource_class.matched_schema_name = schema_resource.resource_name
                resource_class.matched_schema_model = schema_resource.resource_model_id
                break
    
    return resource_classes


def main():
    # Determine paths
    script_dir = Path(__file__).parent
    schema_path = script_dir / 'resourceSchema.json'
    generated_dir = script_dir / 'src' / 'Generated'
    output_path = script_dir / 'analyze_result.txt'
    
    if not schema_path.exists():
        print(f"Error: {schema_path} not found")
        sys.exit(1)
    
    if not generated_dir.exists():
        print(f"Error: {generated_dir} not found")
        sys.exit(1)
    
    # Load schema resources
    print("Loading resourceSchema.json...")
    schema_resources = load_schema_resources(schema_path)
    print(f"Found {len(schema_resources)} resources in schema")
    
    # Find and parse resource classes
    print("\nScanning generated resource classes...")
    resource_classes = []
    for cs_file in generated_dir.glob('*Resource.cs'):
        # Skip collection files
        if 'Collection' in cs_file.name:
            continue
        # Skip serialization files
        if '.Serialization.' in cs_file.name:
            continue
            
        resource_class = extract_resource_id_from_class(cs_file)
        if resource_class:
            resource_classes.append(resource_class)
    
    print(f"Found {len(resource_classes)} resource classes")
    
    # Analyze resources
    print("\nAnalyzing resources...")
    resource_classes = analyze_resources(resource_classes, schema_resources)
    
    # Sort by resource id length (shortest to longest)
    resource_classes.sort(key=lambda x: len(x.resource_id_pattern))
    
    # Build output
    lines = []
    
    lines.append("=" * 100)
    lines.append("GENERATED RESOURCES ANALYSIS")
    lines.append("Sorted by resource ID length (shortest to longest)")
    lines.append("=" * 100)
    
    matched_count = 0
    unmatched_count = 0
    
    for i, resource_class in enumerate(resource_classes, 1):
        lines.append("")
        lines.append(f"{i}. {resource_class.class_name}")
        lines.append(f"   Resource ID: {resource_class.resource_id_pattern}")
        lines.append(f"   Length: {len(resource_class.resource_id_pattern)} characters")
        lines.append(f"   File: {Path(resource_class.file_path).name}")
        
        if resource_class.matched:
            lines.append(f"   Status: MATCHED")
            lines.append(f"   Schema Resource Name: {resource_class.matched_schema_name}")
            lines.append(f"   Schema Model ID: {resource_class.matched_schema_model}")
            matched_count += 1
        else:
            lines.append(f"   Status: NOT MATCHED")
            unmatched_count += 1
    
    # Summary
    lines.append("")
    lines.append("=" * 100)
    lines.append("SUMMARY")
    lines.append("=" * 100)
    lines.append(f"Total generated resource classes: {len(resource_classes)}")
    lines.append(f"Matched with schema:              {matched_count}")
    lines.append(f"Not matched:                      {unmatched_count}")
    
    # Part 2: Sorted resource IDs list
    lines.append("")
    lines.append("=" * 100)
    lines.append("RESOURCE IDs (sorted by length, shortest to longest)")
    lines.append("=" * 100)
    for i, resource_class in enumerate(resource_classes, 1):
        status = "✓" if resource_class.matched else "✗"
        lines.append(f"{i:2d}. [{status}] {resource_class.class_name}")
        lines.append(f"    {resource_class.resource_id_pattern}")
    
    # Write to file
    output_content = '\n'.join(lines)
    with open(output_path, 'w', encoding='utf-8') as f:
        f.write(output_content)
    
    # Also print to console
    print(output_content)
    print(f"\n\nOutput written to {output_path}")


if __name__ == "__main__":
    main()
