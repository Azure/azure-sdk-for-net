#!/usr/bin/env python3
"""
Match resource classes with resourceSchema.json resourceIdPatterns.

This script:
1. Reads resourceSchema.json to get all resource definitions
2. Scans all *Resource.cs files in src/Generated to extract resourceId patterns from CreateResourceIdentifier
3. Matches the patterns between schema and generated classes
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
    
    Looks for patterns like:
        var resourceId = $"/subscriptions/{subscriptionId}/providers/...";
    """
    content = file_path.read_text(encoding='utf-8')
    
    # Extract class name
    class_match = re.search(r'public partial class (\w+Resource)\s*:', content)
    if not class_match:
        return None
    class_name = class_match.group(1)
    
    # Extract resourceId pattern from CreateResourceIdentifier method
    # Pattern: var resourceId = $"...";
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
    # Replace {paramName} with {*} for comparison
    return re.sub(r'\{[^}]+\}', '{*}', pattern)


def match_resources(
    resource_classes: list[ResourceClass],
    schema_resources: list[SchemaResource]
) -> dict:
    """
    Match resource classes with schema resources based on resourceIdPattern.
    
    Returns a dict with:
    - matches: list of (class, schema_resource) tuples
    - unmatched_classes: classes without a schema match
    - unmatched_schema: schema resources without a class match
    """
    matches = []
    unmatched_classes = []
    matched_schema_indices = set()
    
    for resource_class in resource_classes:
        normalized_class_pattern = normalize_pattern(resource_class.resource_id_pattern)
        found_match = False
        
        for idx, schema_resource in enumerate(schema_resources):
            normalized_schema_pattern = normalize_pattern(schema_resource.resource_id_pattern)
            
            if normalized_class_pattern == normalized_schema_pattern:
                matches.append((resource_class, schema_resource))
                matched_schema_indices.add(idx)
                found_match = True
                break
        
        if not found_match:
            unmatched_classes.append(resource_class)
    
    unmatched_schema = [
        schema_resources[i] 
        for i in range(len(schema_resources)) 
        if i not in matched_schema_indices
    ]
    
    return {
        'matches': matches,
        'unmatched_classes': unmatched_classes,
        'unmatched_schema': unmatched_schema
    }


def main():
    # Determine paths
    script_dir = Path(__file__).parent
    schema_path = script_dir / 'resourceSchema.json'
    generated_dir = script_dir / 'src' / 'Generated'
    output_path = script_dir / 'matchresult.txt'
    
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
    
    print(f"Found {len(resource_classes)} resource classes with CreateResourceIdentifier")
    
    # Match resources
    print("\nMatching resources...")
    results = match_resources(resource_classes, schema_resources)
    
    # Build output
    lines = []
    
    lines.append("=" * 80)
    lines.append("MATCHES")
    lines.append("=" * 80)
    for resource_class, schema_resource in results['matches']:
        lines.append(f"\n{resource_class.class_name}")
        lines.append(f"  Class Pattern:  {resource_class.resource_id_pattern}")
        lines.append(f"  Schema Pattern: {schema_resource.resource_id_pattern}")
        lines.append(f"  Schema Model:   {schema_resource.resource_model_id}")
        lines.append(f"  Resource Name:  {schema_resource.resource_name}")
    
    lines.append(f"\n\nTotal matches: {len(results['matches'])}")
    
    if results['unmatched_classes']:
        lines.append("\n" + "=" * 80)
        lines.append("UNMATCHED CLASSES (no schema match)")
        lines.append("=" * 80)
        for resource_class in results['unmatched_classes']:
            lines.append(f"\n{resource_class.class_name}")
            lines.append(f"  Pattern: {resource_class.resource_id_pattern}")
            lines.append(f"  File: {Path(resource_class.file_path).name}")
    
    if results['unmatched_schema']:
        lines.append("\n" + "=" * 80)
        lines.append("UNMATCHED SCHEMA RESOURCES (no class match)")
        lines.append("=" * 80)
        for schema_resource in results['unmatched_schema']:
            lines.append(f"\n{schema_resource.resource_name}")
            lines.append(f"  Pattern: {schema_resource.resource_id_pattern}")
            lines.append(f"  Model: {schema_resource.resource_model_id}")
    
    # Summary
    lines.append("\n" + "=" * 80)
    lines.append("SUMMARY")
    lines.append("=" * 80)
    lines.append(f"Total schema resources:    {len(schema_resources)}")
    lines.append(f"Total resource classes:    {len(resource_classes)}")
    lines.append(f"Matched:                   {len(results['matches'])}")
    lines.append(f"Unmatched classes:         {len(results['unmatched_classes'])}")
    lines.append(f"Unmatched schema entries:  {len(results['unmatched_schema'])}")
    
    # Write to file
    output_content = '\n'.join(lines)
    with open(output_path, 'w', encoding='utf-8') as f:
        f.write(output_content)
    
    # Also print to console
    print(output_content)
    print(f"\n\nOutput written to {output_path}")
    
    # Return results as JSON for programmatic use
    return results


if __name__ == "__main__":
    main()
