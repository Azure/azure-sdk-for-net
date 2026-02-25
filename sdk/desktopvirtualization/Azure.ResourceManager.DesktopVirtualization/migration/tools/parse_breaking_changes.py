#!/usr/bin/env python3
"""
Parse and summarize .NET ApiCompat breaking changes from breaking.txt.
Produces a human-readable, grouped summary with actionable fix suggestions.
"""

import re
import subprocess
import sys
from collections import defaultdict
from pathlib import Path

# ── regex to extract error type + full member signature ──────────────────────
ERROR_RE = re.compile(
    r"error\s*:\s*(\w+)\s*:\s*(?:Member|Type)\s+'(.+?)'"
    r"\s+(?:does not exist|is [\w\s()]+)\s+in the implementation"
    r".*?\[.*?::TargetFramework=([\w.]+)\]"
)

SEAL_RE = re.compile(
    r"error\s*:\s*(CannotSealType)\s*:\s*Type\s+'(.+?)'"
    r"\s+is effectively.*?\[.*?::TargetFramework=([\w.]+)\]"
)

TYPE_RE = re.compile(
    r"error\s*:\s*(TypesMustExist)\s*:\s*Type\s+'(.+?)'"
    r"\s+does not exist.*?\[.*?::TargetFramework=([\w.]+)\]"
)

NONVIRTUAL_RE = re.compile(
    r"error\s*:\s*(CannotMakeMemberNonVirtual)\s*:\s*Member\s+'(.+?)'"
    r"\s+is non-virtual.*?\[.*?::TargetFramework=([\w.]+)\]"
)

REMOVE_ATTR_RE = re.compile(
    r"error\s*:\s*(CannotRemoveAttribute)\s*:\s*Attribute\s+'(.+?)'"
    r"\s+exists on\s+'(.+?)'"
    r"\s+in the contract but not the implementation"
    r".*?\[.*?::TargetFramework=([\w.]+)\]"
)

REMOVE_BASE_RE = re.compile(
    r"error\s*:\s*(CannotRemoveBaseTypeOrInterface)\s*:\s*Type\s+'(.+?)'"
    r"\s+does not (?:inherit from base type|implement interface)\s+'(.+?)'"
    r"\s+in the implementation but it does in the contract"
    r".*?\[.*?::TargetFramework=([\w.]+)\]"
)


def shorten_type(full_name: str) -> str:
    """Remove common namespace prefixes to shorten display names."""
    replacements = [
        ("Azure.ResourceManager.Peering.Models.", "Models."),
        ("Azure.ResourceManager.Peering.Mocking.", "Mocking."),
        ("Azure.ResourceManager.Peering.", ""),
        ("Azure.ResourceManager.Resources.", "Resources."),
        ("System.Threading.Tasks.", ""),
        ("System.Threading.", ""),
        ("System.Collections.Generic.", ""),
        ("System.Nullable<", "?<"),  # will fixup later
        ("System.", ""),
    ]
    s = full_name
    for old, new in replacements:
        s = s.replace(old, new)
    # Clean up Nullable: ?<Foo> -> Foo?
    s = re.sub(r"\?\<(.+?)\>", r"\1?", s)
    return s


def extract_class_and_member(signature: str):
    """
    Given a full member signature, return (class_name, member_description).
    E.g. "public void Foo.Bar.Baz()" -> ("Foo.Bar", "void Baz()")
    """
    # Remove 'public ' / 'protected ' prefix
    sig = re.sub(r"^(public|protected|private|internal)\s+", "", signature.strip())

    # Property getter/setter: "ReturnType Namespace.Class.Prop.get()" or ".set(Type)"
    prop_match = re.match(r"(.+?)\s+([\w.<>,\?\s]+)\.(get|set)\((.*?)\)$", sig)
    if prop_match:
        ret_type, full_prop, accessor, params = prop_match.groups()
        parts = full_prop.rsplit(".", 1)
        if len(parts) == 2:
            cls, prop = parts
            if accessor == "get":
                return cls, f"{prop} {{ get; }}  (returns {shorten_type(ret_type)})"
            else:
                return cls, f"{prop} {{ set; }}  (param: {shorten_type(params) if params else shorten_type(ret_type)})"
        return full_prop, f"{accessor}()"

    # Constructor: "void Namespace.Class..ctor()"
    ctor_match = re.match(r"void\s+([\w.]+)\.\.\.?ctor\((.*?)\)$", sig)
    if ctor_match:
        cls = ctor_match.group(1)
        params = ctor_match.group(2)
        return cls, f".ctor({shorten_type(params)})"

    # Normal method: "ReturnType Namespace.Class.Method(params)"
    method_match = re.match(r"(.+?)\s+([\w.<>,\?\s]+)\((.*)\)$", sig)
    if method_match:
        ret_type, full_method, params = method_match.groups()
        parts = full_method.rsplit(".", 1)
        if len(parts) == 2:
            cls, method = parts
            short_params = ", ".join(shorten_type(p.strip()) for p in params.split(",")) if params.strip() else ""
            return cls, f"{shorten_type(ret_type)} {method}({short_params})"
        return full_method, f"({shorten_type(params)})"

    return "(unknown)", sig


def parse_file(path: str):
    """Parse breaking.txt and return structured error records."""
    text = Path(path).read_text()
    errors = []
    seen = set()

    for line in text.splitlines():
        m = ERROR_RE.search(line) or SEAL_RE.search(line) or NONVIRTUAL_RE.search(line) or TYPE_RE.search(line)
        m_attr = None
        m_base = None
        if not m:
            m_attr = REMOVE_ATTR_RE.search(line)
        if not m and not m_attr:
            m_base = REMOVE_BASE_RE.search(line)
        if not m and not m_attr and not m_base:
            continue

        if m:
            error_type, signature, tfm = m.group(1), m.group(2), m.group(3)
            error = {"error_type": error_type, "signature": signature, "tfm": tfm}
            key = (error_type, signature)
        elif m_attr:
            error_type = m_attr.group(1)
            attribute = m_attr.group(2)
            member = m_attr.group(3)
            tfm = m_attr.group(4)
            error = {"error_type": error_type, "signature": member, "attribute": attribute, "tfm": tfm}
            key = (error_type, attribute, member)
        else:  # m_base
            error_type = m_base.group(1)
            type_name = m_base.group(2)
            base_type = m_base.group(3)
            tfm = m_base.group(4)
            error = {"error_type": error_type, "signature": type_name, "base_type": base_type, "tfm": tfm}
            key = (error_type, type_name, base_type)

        if key in seen:
            continue
        seen.add(key)
        errors.append(error)
    return errors


def categorize(errors):
    """Group errors by type, then by affected class."""
    by_type = defaultdict(lambda: defaultdict(list))
    for e in errors:
        if e["error_type"] in ("CannotSealType", "TypesMustExist"):
            # These reference a full type name, not a member signature
            short = shorten_type(e["signature"])
            by_type[e["error_type"]][short].append(short)
        elif e["error_type"] == "CannotRemoveAttribute":
            member = e["signature"]
            parts = member.rsplit(".", 1)
            if len(parts) == 2:
                cls, prop = parts
            else:
                cls, prop = "(unknown)", member
            attr_short = shorten_type(e["attribute"]).rsplit(".", 1)[-1]
            by_type[e["error_type"]][cls].append(f"{attr_short} on {shorten_type(prop)}")
        elif e["error_type"] == "CannotRemoveBaseTypeOrInterface":
            type_name = e["signature"]
            base_type = e["base_type"]
            by_type[e["error_type"]][shorten_type(type_name)].append(f"base: {shorten_type(base_type)}")
        else:
            cls, member = extract_class_and_member(e["signature"])
            by_type[e["error_type"]][cls].append(member)
    return by_type


ERROR_DESCRIPTIONS = {
    "MembersMustExist": {
        "title": "Missing Members (MembersMustExist)",
        "desc":  "These members existed in the public API contract but are missing in the new implementation.",
        "fix":   "Add these members back to the implementation, or add entries to the API baseline/compat suppression file.",
    },
    "TypesMustExist": {
        "title": "Missing Types (TypesMustExist)",
        "desc":  "These entire types existed in the contract but are gone from the implementation.",
        "fix":   "Re-introduce the type (possibly as an empty stub or tag class), or suppress in the baseline.",
    },
    "CannotSealType": {
        "title": "Sealed Types (CannotSealType)",
        "desc":  "These types now have only private constructors, effectively sealing them, but were unsealed before.",
        "fix":   "Add back a public/protected parameterless constructor, or suppress in the baseline.",
    },
    "CannotMakeMemberNonVirtual": {
        "title": "Non-Virtual Members (CannotMakeMemberNonVirtual)",
        "desc":  "These members were virtual in the contract but are now non-virtual.",
        "fix":   "Mark the member as virtual/override again, or suppress in the baseline.",
    },
    "CannotRemoveAttribute": {
        "title": "Removed Attributes (CannotRemoveAttribute)",
        "desc":  "These attributes existed on members in the contract but are missing in the implementation.",
        "fix":   "Re-add the attribute to the member, or suppress in the baseline.",
    },
    "CannotRemoveBaseTypeOrInterface": {
        "title": "Removed Base Types/Interfaces (CannotRemoveBaseTypeOrInterface)",
        "desc":  "These types no longer inherit from their original base type or implement an interface.",
        "fix":   "Restore the base type or interface, or suppress in the baseline.",
    },
}


def print_report(by_type):
    """Print a nicely formatted report to stdout."""
    total = sum(len(members) for classes in by_type.values() for members in classes.values())
    unique_classes = set()
    for classes in by_type.values():
        unique_classes.update(classes.keys())

    print("=" * 80)
    print("  BREAKING CHANGES SUMMARY")
    print("=" * 80)
    print(f"  Total unique errors : {total}")
    print(f"  Error categories    : {len(by_type)}")
    print(f"  Affected classes    : {len(unique_classes)}")
    print("=" * 80)

    for error_type, classes in by_type.items():
        info = ERROR_DESCRIPTIONS.get(error_type, {
            "title": error_type,
            "desc": "",
            "fix": "",
        })
        member_count = sum(len(m) for m in classes.values())

        print()
        print(f"┌─ {info['title']}  ({member_count} errors)")
        print(f"│  {info['desc']}")
        print(f"│  FIX: {info['fix']}")
        print("│")

        for cls, members in sorted(classes.items()):
            short_cls = shorten_type(cls)
            print(f"│  ▸ {short_cls}")
            for m in members:
                print(f"│      • {m}")
        print("└" + "─" * 79)

    # ── Actionable checklist ─────────────────────────────────────────────────
    print()
    print("=" * 80)
    print("  SUGGESTED ACTION CHECKLIST")
    print("=" * 80)

    action_id = 0
    if "TypesMustExist" in by_type:
        for cls in sorted(by_type["TypesMustExist"]):
            action_id += 1
            print(f"  [{action_id}] Re-add missing type: {cls}")

    if "MembersMustExist" in by_type:
        # group by class for concise output
        for cls, members in sorted(by_type["MembersMustExist"].items()):
            short_cls = shorten_type(cls)
            # separate methods, ctors, property accessors
            ctors    = [m for m in members if m.startswith(".ctor")]
            props    = [m for m in members if "{ get; }" in m or "{ set; }" in m]
            methods  = [m for m in members if m not in ctors and m not in props]
            if ctors:
                action_id += 1
                print(f"  [{action_id}] Add public constructor to {short_cls}")
            if props:
                for p in props:
                    action_id += 1
                    prop_name = p.split("{")[0].strip()
                    print(f"  [{action_id}] Restore property {short_cls}.{prop_name}")
            if methods:
                action_id += 1
                names = ", ".join(m.split("(")[0].rsplit(" ", 1)[-1] if " " in m else m.split("(")[0] for m in methods)
                print(f"  [{action_id}] Add missing method(s) to {short_cls}: {names}")

    if "CannotSealType" in by_type:
        for cls in sorted(by_type["CannotSealType"]):
            action_id += 1
            print(f"  [{action_id}] Un-seal type (add public/protected ctor): {cls}")

    if "CannotMakeMemberNonVirtual" in by_type:
        for cls, members in sorted(by_type["CannotMakeMemberNonVirtual"].items()):
            for m in members:
                action_id += 1
                print(f"  [{action_id}] Make member virtual again in {shorten_type(cls)}: {m.split('(')[0]}")

    if "CannotRemoveAttribute" in by_type:
        for cls, members in sorted(by_type["CannotRemoveAttribute"].items()):
            action_id += 1
            attr_names = sorted(set(m.split(" on ")[0] for m in members))
            props = sorted(m.split(" on ")[1] if " on " in m else m for m in members)
            print(f"  [{action_id}] Re-add attribute(s) {', '.join(attr_names)} to {shorten_type(cls)}: {', '.join(props)}")

    if "CannotRemoveBaseTypeOrInterface" in by_type:
        for cls, bases in sorted(by_type["CannotRemoveBaseTypeOrInterface"].items()):
            action_id += 1
            base_names = [b.replace("base: ", "") for b in bases]
            print(f"  [{action_id}] Restore base type(s) for {cls}: {', '.join(base_names)}")

    print()
    print(f"  Total actions: {action_id}")
    print("=" * 80)


def _find_sdk_root() -> Path:
    """Walk up from this script's directory to find the SDK package root.

    The SDK root is identified as the directory that contains the ``src/``
    subfolder with a ``.csproj`` file.  Starting from the ``migration/tools``
    directory, that is two levels up.
    """
    current = Path(__file__).resolve().parent
    for _ in range(5):
        if (current / "src").is_dir() and list((current / "src").glob("*.csproj")):
            return current
        current = current.parent
    return None


def generate_breaking_txt(sdk_root: Path, output: Path) -> None:
    """Run ``dotnet build`` under *sdk_root* and write combined stdout+stderr
    to *output*.  The build is expected to fail when there are breaking
    changes, so a non-zero exit code is **not** treated as an error."""
    print(f"Running 'dotnet build' in {sdk_root} ...")
    result = subprocess.run(
        ["dotnet", "build"],
        cwd=str(sdk_root),
        capture_output=True,
        text=True,
    )
    combined = result.stdout + "\n" + result.stderr
    output.write_text(combined, encoding="utf-8")
    print(f"Build output written to {output}  (exit code {result.returncode})")


def main():
    path = Path(sys.argv[1]) if len(sys.argv) > 1 else None

    if path is None:
        # No file supplied – auto-generate breaking.txt via dotnet build.
        sdk_root = _find_sdk_root()
        if sdk_root is None:
            print("Error: could not locate the SDK package root.", file=sys.stderr)
            sys.exit(1)
        path = Path(__file__).resolve().parent / "breaking.txt"
        generate_breaking_txt(sdk_root, path)
    elif not path.exists():
        print(f"Error: file '{path}' not found.", file=sys.stderr)
        sys.exit(1)

    errors = parse_file(str(path))
    if not errors:
        print("No ApiCompat errors found in the file.")
        sys.exit(0)

    by_type = categorize(errors)
    print_report(by_type)


if __name__ == "__main__":
    main()
