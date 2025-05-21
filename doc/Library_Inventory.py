#!/usr/bin/env python3

"""
Azure SDK for .NET Libraries Inventory Generator

This script is now moved to GeneratorMigration/Library_Inventory.py.
This is just a wrapper that calls the script at the new location.
"""

import os
import sys
import subprocess

if __name__ == "__main__":
    # Get the path to the new script
    script_path = os.path.join(os.path.dirname(os.path.abspath(__file__)), 
                              "GeneratorMigration", "Library_Inventory.py")
    
    # Execute the script at the new location
    print("Redirecting to script at new location: " + script_path)
    result = subprocess.run([sys.executable, script_path] + sys.argv[1:])
    sys.exit(result.returncode)