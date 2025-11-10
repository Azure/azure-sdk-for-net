#!/usr/bin/env python3
"""Debug script to understand version evolution"""

import re
import subprocess
from datetime import datetime, timedelta
from pathlib import Path

def run_git_command(cmd, cwd):
    result = subprocess.run(cmd, cwd=cwd, capture_output=True, text=True, check=True)
    return result.stdout

def parse_version_line(line):
    pattern = r'^##\s+([\d.]+(?:-[a-zA-Z0-9.]+)?)\s+\(([^)]+)\)'
    match = re.match(pattern, line.strip())
    
    if match:
        version = match.group(1)
        date_str = match.group(2).strip()
        
        if date_str.lower() == "unreleased":
            return (version, None)
        
        try:
            datetime.strptime(date_str, "%Y-%m-%d")
            return (version, date_str)
        except ValueError:
            return (version, None)
    
    return None

def extract_versions_from_changelog(content):
    versions = []
    for line in content.split('\n'):
        parsed = parse_version_line(line)
        if parsed:
            versions.append(parsed)
    
    return versions

repo_root = "/home/runner/work/azure-sdk-for-net/azure-sdk-for-net"
changelog = "sdk/ai/Azure.AI.Agents.Persistent/CHANGELOG.md"
since_date = "2025-08-01"

rel_path = changelog

# Get commits
log_cmd = [
    "git", "--no-pager", "log",
    "--follow",
    "--since", since_date,
    "--format=%H|%ci",
    "--", str(rel_path)
]
log_output = run_git_command(log_cmd, repo_root)

commits = []
for line in log_output.strip().split('\n')[:30]:  # First 30 commits
    if '|' in line:
        commit_hash, commit_date = line.split('|', 1)
        try:
            show_cmd = ["git", "--no-pager", "show", f"{commit_hash}:{rel_path}"]
            content = run_git_command(show_cmd, repo_root)
            commits.append((commit_hash[:7], commit_date.split()[0], content))
        except:
            pass

print(f"Found {len(commits)} commits")
print()

# Process in chronological order
for commit_hash, commit_date, content in reversed(commits):
    versions = extract_versions_from_changelog(content)
    if versions:
        top_version, top_release_date = versions[0]
        print(f"{commit_date} {commit_hash}: ## {top_version} ({'Released: ' + top_release_date if top_release_date else 'Unreleased'})")
