#!/usr/bin/env python3
"""
Checks that all rename-mapping entries from autorest.md.back are correctly
represented as @@clientName / @@alternateType decorators in client.tsp.
"""

import re
import sys
import os

MIGRATION_DIR = os.path.dirname(os.path.abspath(__file__))
AUTOREST_BACK = os.path.join(MIGRATION_DIR, "autorest.md.bak")
INFO_TXT = os.path.join(MIGRATION_DIR, "info.txt")

# Read spec path from info.txt
with open(INFO_TXT) as f:
    for line in f:
        if line.startswith("spec path:"):
            SPEC_DIR = line.split(":", 1)[1].strip()
            break
    else:
        print("ERROR: Could not find 'spec path:' in info.txt")
        sys.exit(1)

CLIENT_TSP = os.path.join(SPEC_DIR, "client.tsp")

# Type mappings (autorest type -> TypeSpec type)
TYPE_MAP = {
    "arm-id": "Azure.Core.armResourceIdentifier",
    "uri": "url",
    "any": "unknown",
}

# How each TypeSpec type appears in the decorator text
TYPE_SEARCH = {
    "arm-id": "Azure.Core.armResourceIdentifier",
    "uri": "TypeSpec.url",
    "any": "unknown",
}


def parse_autorest_back(path):
    """Parse rename-mapping and prepend-rp-prefix from autorest.md.back."""
    with open(path) as f:
        content = f.read()

    # Extract rename-mapping entries
    rename_entries = []
    in_rename = False
    for line in content.split("\n"):
        stripped = line.strip()
        if stripped == "rename-mapping:":
            in_rename = True
            continue
        if in_rename:
            m = re.match(r"^\s+(\S+):\s*(.*)", line)
            if m:
                rename_entries.append((m.group(1), m.group(2).strip()))
            elif stripped and not re.match(r"^\s", line):
                in_rename = False

    # Extract prepend-rp-prefix entries
    prepend_entries = []
    in_prepend = False
    for line in content.split("\n"):
        stripped = line.strip()
        if stripped == "prepend-rp-prefix:":
            in_prepend = True
            continue
        if in_prepend:
            m = re.match(r"^\s+-\s+(\S+)", line)
            if m:
                prepend_entries.append(m.group(1))
            elif stripped and not re.match(r"^\s", line):
                in_prepend = False

    return rename_entries, prepend_entries


def resolve_key(key):
    """
    Resolve an autorest rename-mapping key to a TypeSpec target.

    Returns (target_str, target_type) where target_type is one of:
      'model', 'property', 'member_or_property'
    """
    if ".properties." in key:
        parts = key.split(".properties.")
        model = parts[0] + "Properties"
        prop = parts[1]
        return f"{model}.{prop}", "property"
    elif "." in key:
        parts = key.split(".", 1)
        return f"{parts[0]}.{parts[1]}", "member_or_property"
    else:
        return key, "model"


def parse_value(value):
    """
    Parse a rename-mapping value into (new_name, type_part).

    new_name is None if '-' or absent.
    type_part is None if no pipe separator.
    """
    if "|" in value:
        name_part, type_part = value.split("|", 1)
        name_part = name_part.strip()
        type_part = type_part.strip()
    else:
        name_part = value.strip()
        type_part = None

    if name_part == "-":
        name_part = None

    return name_part, type_part


def find_decorator_in_tsp(tsp_content, decorator, target, value_str):
    """
    Check if a decorator like @@clientName(target, "value", "csharp") exists,
    handling multi-line formatting. Uses case-insensitive matching on the
    target to handle differences like MsixPackage vs MSIXPackage.
    """
    lines = tsp_content.split("\n")
    target_lower = target.lower()
    for i, line in enumerate(lines):
        # Case-insensitive check for the decorator + target
        if decorator.lower() in line.lower() and target_lower in line.lower():
            block = "\n".join(lines[i : i + 5])
            if value_str in block:
                return True
    return False


def main():
    rename_entries, prepend_entries = parse_autorest_back(AUTOREST_BACK)

    with open(CLIENT_TSP) as f:
        client_tsp = f.read()

    missing_clientname = []
    missing_alternatetype = []
    skipped_types = []

    for key, value in rename_entries:
        target, target_type = resolve_key(key)
        new_name, type_part = parse_value(value)

        # Check @@clientName
        if new_name:
            if not find_decorator_in_tsp(
                client_tsp, "@@clientName", target, f'"{new_name}"'
            ):
                missing_clientname.append((key, target, new_name))

        # Check @@alternateType
        if type_part:
            if type_part not in TYPE_MAP:
                skipped_types.append((key, target, type_part))
            else:
                search_str = TYPE_SEARCH[type_part]
                if not find_decorator_in_tsp(
                    client_tsp, "@@alternateType", target, search_str
                ):
                    missing_alternatetype.append(
                        (key, target, type_part, search_str)
                    )

    # Check prepend-rp-prefix
    missing_prepend = []
    for name in prepend_entries:
        expected = f"DesktopVirtualization{name}"
        if not find_decorator_in_tsp(
            client_tsp, "@@clientName", name, f'"{expected}"'
        ):
            missing_prepend.append((name, expected))

    # Report
    print("=" * 72)
    print("RENAME-MAPPING VERIFICATION")
    print("=" * 72)

    ok = True

    print(f"\nEntries checked: {len(rename_entries)} rename-mapping"
          f" + {len(prepend_entries)} prepend-rp-prefix")

    if skipped_types:
        print(f"\nSkipped type changes (type not in map): {len(skipped_types)}")
        for key, target, tp in skipped_types:
            print(f"  {key}: type '{tp}' not mapped")

    print("\n--- Missing @@clientName ---")
    if missing_clientname:
        ok = False
        for key, target, name in missing_clientname:
            print(f'  {key} -> @@clientName({target}, "{name}", "csharp");')
    else:
        print("  All present.")

    print("\n--- Missing @@alternateType ---")
    if missing_alternatetype:
        ok = False
        for key, target, orig, ts in missing_alternatetype:
            print(f"  {key} -> @@alternateType({target}, {ts}, \"csharp\");")
    else:
        print("  All present.")

    print("\n--- Missing prepend-rp-prefix ---")
    if missing_prepend:
        ok = False
        for name, expected in missing_prepend:
            print(f'  {name} -> @@clientName({name}, "{expected}", "csharp");')
    else:
        print("  All present.")

    print("\n" + "=" * 72)
    if ok:
        print("RESULT: All rename-mapping entries are covered in client.tsp.")
    else:
        print("RESULT: Some entries are MISSING — see above.")
    print("=" * 72)

    sys.exit(0 if ok else 1)


if __name__ == "__main__":
    main()
