#!/usr/bin/env python3
"""Quick script to prepare for TypeSpec migration."""

import os
import re
import shutil

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
SRC_DIR = os.path.join(BASE_DIR, "src")

# 1) Move src/autorest.md to autorest.md.back
autorest_src = os.path.join(SRC_DIR, "autorest.md")
autorest_bak = os.path.join(SRC_DIR, "autorest.md.back")
if os.path.exists(autorest_src):
    shutil.move(autorest_src, autorest_bak)
    print(f"Moved {autorest_src} -> {autorest_bak}")
else:
    print(f"WARNING: {autorest_src} not found, skipping.")

# 2) Remove <IncludeAutorestDependency>...</IncludeAutorestDependency> from the csproj
csproj = os.path.join(SRC_DIR, "Azure.ResourceManager.DesktopVirtualization.csproj")
if os.path.exists(csproj):
    with open(csproj, "r") as f:
        content = f.read()
    # Remove the line containing IncludeAutorestDependency (and its trailing newline)
    new_content = re.sub(r"\s*<IncludeAutorestDependency>.*?</IncludeAutorestDependency>\n?", "", content)
    with open(csproj, "w") as f:
        f.write(new_content)
    print(f"Removed IncludeAutorestDependency from {csproj}")
else:
    print(f"WARNING: {csproj} not found, skipping.")

# 3) Copy tsp-location.yaml from $HOME to the project root
tsp_src = os.path.join(os.path.expanduser("~"), "tsp-location.yaml")
tsp_dst = os.path.join(BASE_DIR, "tsp-location.yaml")
if os.path.exists(tsp_src):
    shutil.copy2(tsp_src, tsp_dst)
    print(f"Copied {tsp_src} -> {tsp_dst}")
else:
    print(f"WARNING: {tsp_src} not found, skipping.")

print("Done.")
