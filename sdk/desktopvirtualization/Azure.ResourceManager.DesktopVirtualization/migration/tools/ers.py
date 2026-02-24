#!/usr/bin/env python3
"""
Extract the Azure.ClientGenerator.Core.@armProviderSchema decorator from tspCodeModel.json
and save it to resourceSchema.json
"""

import json
import sys
from pathlib import Path

def extract_arm_provider_schema(input_file: str = "tspCodeModel.json", output_file: str = "resourceSchema.json"):
    """
    Extract the @armProviderSchema decorator from the tspCodeModel.json file.
    
    Args:
        input_file: Path to the tspCodeModel.json file
        output_file: Path to the output resourceSchema.json file
    """
    input_path = Path(input_file)
    
    if not input_path.exists():
        print(f"Error: {input_file} not found")
        sys.exit(1)
    
    with open(input_path, 'r', encoding='utf-8') as f:
        data = json.load(f)
    
    # Navigate to clients -> decorators and find the @armProviderSchema decorator
    arm_provider_schema = None
    
    clients = data.get("clients", [])
    for client in clients:
        decorators = client.get("decorators", [])
        for decorator in decorators:
            if decorator.get("name") == "Azure.ClientGenerator.Core.@armProviderSchema":
                arm_provider_schema = decorator
                break
        if arm_provider_schema:
            break
    
    if arm_provider_schema is None:
        print("Error: Azure.ClientGenerator.Core.@armProviderSchema decorator not found")
        sys.exit(1)
    
    # Write the extracted schema to the output file
    output_path = Path(output_file)
    with open(output_path, 'w', encoding='utf-8') as f:
        json.dump(arm_provider_schema, f, indent=2)
    
    print(f"Successfully extracted @armProviderSchema to {output_file}")

if __name__ == "__main__":
    input_file = sys.argv[1] if len(sys.argv) > 1 else "tspCodeModel.json"
    output_file = sys.argv[2] if len(sys.argv) > 2 else "resourceSchema.json"
    extract_arm_provider_schema(input_file, output_file)
