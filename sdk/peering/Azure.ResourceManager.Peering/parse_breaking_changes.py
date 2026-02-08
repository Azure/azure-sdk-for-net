#!/usr/bin/env python3
"""
Parse and summarize .NET ApiCompat breaking changes from breaking.txt.
Produces a human-readable, grouped summary with actionable fix suggestions.
"""

import re
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
        if not m:
            continue
        error_type, signature, tfm = m.group(1), m.group(2), m.group(3)
        key = (error_type, signature)
        if key in seen:
            continue
        seen.add(key)
        errors.append({
            "error_type": error_type,
            "signature": signature,
            "tfm": tfm,
        })
    return errors


def categorize(errors):
    """Group errors by type, then by affected class."""
    by_type = defaultdict(lambda: defaultdict(list))
    for e in errors:
        if e["error_type"] in ("CannotSealType", "TypesMustExist"):
            # These reference a full type name, not a member signature
            short = shorten_type(e["signature"])
            by_type[e["error_type"]][short].append(short)
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

    print()
    print(f"  Total actions: {action_id}")
    print("=" * 80)


def main():
    path = sys.argv[1] if len(sys.argv) > 1 else "breaking.txt"
    if not Path(path).exists():
        print(f"Error: file '{path}' not found.", file=sys.stderr)
        sys.exit(1)

    errors = parse_file(path)
    if not errors:
        print("No ApiCompat errors found in the file.")
        sys.exit(0)

    by_type = categorize(errors)
    print_report(by_type)


if __name__ == "__main__":
    main()
