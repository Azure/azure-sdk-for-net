#!/usr/bin/env python3

"""
Azure SDK for .NET Libraries Inventory Generator

This script generates an inventory of libraries in the Azure SDK for .NET repository,
categorizing them as data plane or management plane, and by the type of generator used
(Swagger or TypeSpec).
"""

import os
import re
import json
import glob
from pathlib import Path

def is_mgmt_library(path):
    """Check if a library is a management plane library."""
    if "Azure.ResourceManager" in path or ".Management." in path:
        return True
    return False

def identify_generator(path):
    """
    Identify if a library is generated using swagger or tsp.
    Returns: "Swagger", a specific TypeSpec generator name, "TSP-Old", or "No Generator"
    """
    # Special case for Azure.AI.OpenAI which uses TypeSpec with new generator via special handling
    if os.path.basename(path) == "Azure.AI.OpenAI" and "openai" in path:
        return "http-client-csharp"
        
    # First check for direct TypeSpec indicators
    tsp_config_path = os.path.join(path, "src", "tspconfig.yaml")
    tsp_dir = os.path.join(path, "src", "tsp")
    tsp_files = glob.glob(os.path.join(path, "src", "*.tsp"))
    
    # Check for tsp-location.yaml files
    tsp_location_paths = []
    for root, dirs, files in os.walk(path):
        for file in files:
            if file.lower() == "tsp-location.yaml":
                tsp_location_paths.append(os.path.join(root, file))
    
    # If there's a tsp-location.yaml file and it contains emitterPackageJsonPath, extract the generator name
    for tsp_location_path in tsp_location_paths:
        try:
            with open(tsp_location_path, 'r', encoding='utf-8', errors='ignore') as f:
                content = f.read()
                if "emitterPackageJsonPath" in content:
                    # Extract the emitterPackageJsonPath value
                    import re
                    match = re.search(r'emitterPackageJsonPath:\s*"([^"]+)"', content)
                    if match:
                        emitter_path = match.group(1)
                        # Construct absolute path to the emitter package JSON
                        repo_root = os.path.abspath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", ".."))
                        emitter_json_path = os.path.join(repo_root, emitter_path)
                        
                        # Try to read the generator name from the emitter package JSON
                        if os.path.exists(emitter_json_path):
                            try:
                                with open(emitter_json_path, 'r', encoding='utf-8', errors='ignore') as f:
                                    package_json = json.load(f)
                                    # Look for TypeSpec generator in dependencies
                                    for dep in package_json.get('dependencies', {}):
                                        if dep.startswith('@azure-typespec/'):
                                            # Return just the generator name without the @azure-typespec/ prefix
                                            return dep.replace('@azure-typespec/', '')
                            except Exception as e:
                                pass  # Fall back to generic name if can't extract
                    
                    # If we couldn't extract a specific name, use a generic "TypeSpec New Generator"
                    return "http-client-csharp"  # Default name for new generator
                else:
                    # Found tsp-location.yaml but no emitterPackageJsonPath, it's using the old TypeSpec generator
                    return "TSP-Old"
        except:
            pass
    
    if os.path.exists(tsp_config_path) or os.path.exists(tsp_dir) or tsp_files:
        return "TSP-Old"
    
    # Check autorest.md for TypeSpec indicators
    autorest_md_path = os.path.join(path, "src", "autorest.md")
    if os.path.exists(autorest_md_path):
        with open(autorest_md_path, 'r', encoding='utf-8', errors='ignore') as f:
            content = f.read().lower()
            
            # Check for TypeSpec markers
            tsp_markers = [
                "typespec",
                "emit-yaml-tags: tsp",
                "output-folder: $(typescript-sdks-folder)",
                "azure-typespec"
            ]
            
            for marker in tsp_markers:
                if marker in content:
                    return "TSP-Old"
            
            # If input-file points to a swagger spec, it's Swagger
            if "input-file:" in content and ("json" in content or "swagger" in content):
                return "Swagger"
            
            # If it's using autorest but not specifically TSP, assume Swagger
            return "Swagger"
    
    # No autorest.md but Generated folder exists, assume Swagger
    if os.path.exists(os.path.join(path, "src", "Generated")):
        return "Swagger"
        
    # Check if there's any file in src with "// <auto-generated/>" comment
    # which is typically found in AutoRest generated code
    src_dir = os.path.join(path, "src")
    if os.path.exists(src_dir):
        for root, dirs, files in os.walk(src_dir):
            for file in files:
                if file.endswith(".cs"):
                    file_path = os.path.join(root, file)
                    try:
                        with open(file_path, 'r', encoding='utf-8', errors='ignore') as f:
                            first_lines = "".join([f.readline() for _ in range(10)])
                            if "<auto-generated/>" in first_lines:
                                return "Swagger"  # Default to Swagger if we see auto-generated code
                    except:
                        pass
    
    # If we couldn't identify a generator, it's "No Generator" instead of "Unknown"
    return "No Generator"

def scan_libraries(sdk_root):
    """
    Scan all libraries in the sdk directory.
    
    Args:
        sdk_root (str): Path to the SDK root directory
        
    Returns:
        list: List of dictionaries with library information
    """
    libraries = []
    
    # Scan through all service directories
    for service_dir in os.listdir(sdk_root):
        service_path = os.path.join(sdk_root, service_dir)
        if not os.path.isdir(service_path):
            continue
        
        # Look for library directories
        for library_dir in os.listdir(service_path):
            library_path = os.path.join(service_path, library_dir)
            if not os.path.isdir(library_path):
                continue
                
            # Skip directories that don't look like libraries
            if library_dir in ["tests", "samples", "perf", "assets", "docs"]:
                continue
                
            # Skip libraries that start with "Microsoft."
            if library_dir.startswith("Microsoft."):
                continue
                
            # If it has a /src directory or a csproj file, it's likely a library
            if os.path.exists(os.path.join(library_path, "src")) or glob.glob(os.path.join(library_path, "*.csproj")):
                library_type = "Management" if is_mgmt_library(library_path) else "Data Plane"
                generator = identify_generator(library_path)
                
                libraries.append({
                    "service": service_dir,
                    "library": library_dir,
                    "path": os.path.relpath(library_path, os.path.dirname(sdk_root)),
                    "type": library_type,
                    "generator": generator
                })
    
    return libraries

def generate_markdown_report(libraries):
    """
    Generate a markdown report from the library inventory.
    
    Args:
        libraries (list): List of library dictionaries
        
    Returns:
        str: Markdown report content
    """
    # Group by type and generator
    mgmt_swagger = [lib for lib in libraries if lib["type"] == "Management" and lib["generator"] == "Swagger"]
    data_swagger = [lib for lib in libraries if lib["type"] == "Data Plane" and lib["generator"] == "Swagger"]
    
    # Old TypeSpec libraries
    mgmt_tsp_old = [lib for lib in libraries if lib["type"] == "Management" and lib["generator"] == "TSP-Old"]
    data_tsp_old = [lib for lib in libraries if lib["type"] == "Data Plane" and lib["generator"] == "TSP-Old"]
    
    # Group by specific TypeSpec generator
    # First, identify all unique new generator types
    new_generator_types = set([
        lib["generator"] 
        for lib in libraries 
        if lib["generator"] not in ["Swagger", "TSP-Old", "No Generator"]
    ])
    
    # Create groups for each generator type
    mgmt_tsp_by_generator = {}
    data_tsp_by_generator = {}
    
    for gen_type in new_generator_types:
        mgmt_tsp_by_generator[gen_type] = [
            lib for lib in libraries 
            if lib["type"] == "Management" and lib["generator"] == gen_type
        ]
        data_tsp_by_generator[gen_type] = [
            lib for lib in libraries 
            if lib["type"] == "Data Plane" and lib["generator"] == gen_type
        ]
    
    no_generator = [lib for lib in libraries if lib["generator"] == "No Generator"]
    
    report = []
    report.append("# Azure SDK for .NET Libraries Inventory\n")
    
    report.append("## Summary\n")
    report.append(f"- Total libraries: {len(libraries)}")
    report.append(f"- Management Plane (Swagger): {len(mgmt_swagger)}")
    report.append(f"- Management Plane (TSP-Old): {len(mgmt_tsp_old)}")
    
    # List all new generator types with counts
    for gen_type in sorted(new_generator_types):
        report.append(f"- Management Plane (TypeSpec - {gen_type}): {len(mgmt_tsp_by_generator[gen_type])}")
    
    report.append(f"- Data Plane (Swagger): {len(data_swagger)}")
    report.append(f"- Data Plane (TSP-Old): {len(data_tsp_old)}")
    
    # List all new generator types with counts for data plane
    for gen_type in sorted(new_generator_types):
        report.append(f"- Data Plane (TypeSpec - {gen_type}): {len(data_tsp_by_generator[gen_type])}")
    
    report.append(f"- No generator: {len(no_generator)}")
    report.append("\n")
    
    # Add sections for each TypeSpec generator for Data Plane
    for gen_type in sorted(new_generator_types):
        if len(data_tsp_by_generator[gen_type]) > 0:
            report.append(f"## Data Plane Libraries using TypeSpec ({gen_type})\n")
            report.append(f"TypeSpec with {gen_type} generator is detected by the presence of a tsp-location.yaml file with an emitterPackageJsonPath value referencing {gen_type}, or through special handling for specific libraries.\n")
            report.append("| Service | Library | Path |")
            report.append("| ------- | ------- | ---- |")
            for lib in sorted(data_tsp_by_generator[gen_type], key=lambda x: (x["service"], x["library"])):
                report.append(f"| {lib['service']} | {lib['library']} | {lib['path']} |")
            report.append("\n")
    
    # Old TypeSpec Data Plane Libraries
    if len(data_tsp_old) > 0:
        report.append("## Data Plane Libraries using TypeSpec (Old Generator)\n")
        report.append("TypeSpec with old generator is detected by the presence of a tsp-location.yaml file without an emitterPackageJsonPath value, tspconfig.yaml file, tsp directory, or *.tsp files.\n")
        report.append("| Service | Library | Path |")
        report.append("| ------- | ------- | ---- |")
        for lib in sorted(data_tsp_old, key=lambda x: (x["service"], x["library"])):
            report.append(f"| {lib['service']} | {lib['library']} | {lib['path']} |")
        report.append("\n")
    
    # Data Plane Swagger Libraries
    if len(data_swagger) > 0:
        report.append("## Data Plane Libraries using Swagger\n")
        report.append("| Service | Library | Path |")
        report.append("| ------- | ------- | ---- |")
        for lib in sorted(data_swagger, key=lambda x: (x["service"], x["library"])):
            report.append(f"| {lib['service']} | {lib['library']} | {lib['path']} |")
        report.append("\n")
    
    # Add sections for each TypeSpec generator for Management Plane
    for gen_type in sorted(new_generator_types):
        if len(mgmt_tsp_by_generator[gen_type]) > 0:
            report.append(f"## Management Plane Libraries using TypeSpec ({gen_type})\n")
            report.append(f"TypeSpec with {gen_type} generator is detected by the presence of a tsp-location.yaml file with an emitterPackageJsonPath value referencing {gen_type}, or through special handling for specific libraries.\n")
            report.append("| Service | Library | Path |")
            report.append("| ------- | ------- | ---- |")
            for lib in sorted(mgmt_tsp_by_generator[gen_type], key=lambda x: (x["service"], x["library"])):
                report.append(f"| {lib['service']} | {lib['library']} | {lib['path']} |")
            report.append("\n")
    
    # Old TypeSpec Management Plane Libraries
    if len(mgmt_tsp_old) > 0:
        report.append("## Management Plane Libraries using TypeSpec (Old Generator)\n")
        report.append("TypeSpec with old generator is detected by the presence of a tsp-location.yaml file without an emitterPackageJsonPath value, tspconfig.yaml file, tsp directory, or *.tsp files.\n")
        report.append("| Service | Library | Path |")
        report.append("| ------- | ------- | ---- |")
        for lib in sorted(mgmt_tsp_old, key=lambda x: (x["service"], x["library"])):
            report.append(f"| {lib['service']} | {lib['library']} | {lib['path']} |")
        report.append("\n")
    
    # Management Plane Swagger Libraries
    if len(mgmt_swagger) > 0:
        report.append("## Management Plane Libraries using Swagger\n")
        report.append("| Service | Library | Path |")
        report.append("| ------- | ------- | ---- |")
        for lib in sorted(mgmt_swagger, key=lambda x: (x["service"], x["library"])):
            report.append(f"| {lib['service']} | {lib['library']} | {lib['path']} |")
        report.append("\n")
    
    # No Generator Libraries
    report.append("## Libraries with No Generator\n")
    report.append(f"Libraries with no generator have neither autorest.md nor tsp-location.yaml files. Total: {len(no_generator)}\n")
    report.append("| Service | Library | Path |")
    report.append("| ------- | ------- | ---- |")
    for lib in sorted(no_generator, key=lambda x: (x["service"], x["library"])):
        report.append(f"| {lib['service']} | {lib['library']} | {lib['path']} |")
    
    return "\n".join(report)

if __name__ == "__main__":
    # Define the path to the SDK root directory
    SDK_ROOT = os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", "..", "sdk")
    
    # Scan libraries
    libraries = scan_libraries(SDK_ROOT)
    
    # Print summary counts
    mgmt_swagger = sum(1 for lib in libraries if lib["type"] == "Management" and lib["generator"] == "Swagger")
    mgmt_tsp_old = sum(1 for lib in libraries if lib["type"] == "Management" and lib["generator"] == "TSP-Old")
    data_swagger = sum(1 for lib in libraries if lib["type"] == "Data Plane" and lib["generator"] == "Swagger")
    data_tsp_old = sum(1 for lib in libraries if lib["type"] == "Data Plane" and lib["generator"] == "TSP-Old")
    no_generator = sum(1 for lib in libraries if lib["generator"] == "No Generator")
    
    # Get counts for specific TypeSpec generators
    new_generator_types = set([
        lib["generator"] 
        for lib in libraries 
        if lib["generator"] not in ["Swagger", "TSP-Old", "No Generator"]
    ])
    
    print(f"Total libraries found: {len(libraries)}")
    print(f"Management Plane (Swagger): {mgmt_swagger}")
    print(f"Management Plane (TSP-Old): {mgmt_tsp_old}")
    
    # Print counts for each new generator type in Management Plane
    for gen_type in sorted(new_generator_types):
        mgmt_gen_count = sum(1 for lib in libraries if lib["type"] == "Management" and lib["generator"] == gen_type)
        if mgmt_gen_count > 0:
            print(f"Management Plane (TypeSpec - {gen_type}): {mgmt_gen_count}")
    
    print(f"Data Plane (Swagger): {data_swagger}")
    print(f"Data Plane (TSP-Old): {data_tsp_old}")
    
    # Print counts for each new generator type in Data Plane
    for gen_type in sorted(new_generator_types):
        data_gen_count = sum(1 for lib in libraries if lib["type"] == "Data Plane" and lib["generator"] == gen_type)
        if data_gen_count > 0:
            print(f"Data Plane (TypeSpec - {gen_type}): {data_gen_count}")
    
    print(f"No generator: {no_generator}")
    
    # Generate the inventory markdown file
    markdown_report = generate_markdown_report(libraries)
    inventory_md_path = os.path.join(os.path.dirname(os.path.abspath(__file__)), "Library_Inventory.md")
    with open(inventory_md_path, 'w') as f:
        f.write(markdown_report)
    
    print(f"Library inventory markdown generated at: {inventory_md_path}")
    
    # Export JSON too for programmatic use
    json_path = os.path.join(os.path.dirname(os.path.abspath(__file__)), "Library_Inventory.json")
    with open(json_path, 'w') as f:
        json.dump(libraries, f, indent=2)
    
    print(f"Library inventory JSON generated at: {json_path}")