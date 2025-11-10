#!/usr/bin/env python3
"""
Analyze CHANGELOG.md files to track version changes before release.

This script:
1. Finds CHANGELOG.md files in the repository
2. Tracks version changes through git history
3. Counts how many times a version changed while unreleased
4. Calculates statistics per file and overall
5. Outputs results to CSV

Example:
  1.0.0-beta.1 (Unreleased) -> 1.0.0-beta.2 (Unreleased) -> 1.0.0 (2025-11-10)
  This counts as 2 version changes before release.
"""

import re
import subprocess
import csv
from datetime import datetime, timedelta
from pathlib import Path
from collections import defaultdict
from typing import List, Dict, Tuple, Optional


def run_git_command(cmd: List[str], cwd: str) -> str:
    """Run a git command and return output."""
    result = subprocess.run(
        cmd,
        cwd=cwd,
        capture_output=True,
        text=True,
        check=True
    )
    return result.stdout


def find_changelog_files(repo_root: str, limit: Optional[int] = None) -> List[Path]:
    """Find all CHANGELOG.md files in the repository."""
    changelogs = []
    sdk_dir = Path(repo_root) / "sdk"
    
    if sdk_dir.exists():
        for changelog in sdk_dir.rglob("CHANGELOG.md"):
            changelogs.append(changelog)
            if limit and len(changelogs) >= limit:
                break
    
    return sorted(changelogs)


def parse_version_line(line: str) -> Optional[Tuple[str, Optional[str]]]:
    """
    Parse a version line from CHANGELOG.md.
    
    Returns: (version, date) or None
    Examples:
      "## 1.0.0 (2025-11-10)" -> ("1.0.0", "2025-11-10")
      "## 1.0.0-beta.1 (Unreleased)" -> ("1.0.0-beta.1", None)
    """
    # Match version headers like ## 1.0.0 (2025-11-10) or ## 1.0.0-beta.1 (Unreleased)
    pattern = r'^##\s+([\d.]+(?:-[a-zA-Z0-9.]+)?)\s+\(([^)]+)\)'
    match = re.match(pattern, line.strip())
    
    if match:
        version = match.group(1)
        date_str = match.group(2).strip()
        
        # Check if it's unreleased
        if date_str.lower() == "unreleased":
            return (version, None)
        
        # Try to parse as date
        try:
            datetime.strptime(date_str, "%Y-%m-%d")
            return (version, date_str)
        except ValueError:
            return (version, None)
    
    return None


def get_git_history_for_file(repo_root: str, filepath: str, since_date: str) -> List[Tuple[str, str, str]]:
    """
    Get git history for a specific file.
    
    Returns: List of (commit_hash, date, content) tuples
    """
    rel_path = Path(filepath).relative_to(repo_root)
    
    try:
        # Get commits that modified this file since the given date
        log_cmd = [
            "git", "--no-pager", "log",
            "--follow",
            "--since", since_date,
            "--format=%H|%ci",
            "--", str(rel_path)
        ]
        log_output = run_git_command(log_cmd, repo_root)
        
        if not log_output.strip():
            return []
        
        commits = []
        for line in log_output.strip().split('\n'):
            if '|' in line:
                commit_hash, commit_date = line.split('|', 1)
                # Get file content at this commit
                try:
                    show_cmd = ["git", "--no-pager", "show", f"{commit_hash}:{rel_path}"]
                    content = run_git_command(show_cmd, repo_root)
                    commits.append((commit_hash, commit_date, content))
                except subprocess.CalledProcessError:
                    # File might not exist at this commit
                    continue
        
        return commits
    except subprocess.CalledProcessError:
        return []


def extract_versions_from_changelog(content: str) -> List[Tuple[str, Optional[str]]]:
    """
    Extract all version entries from changelog content.
    
    Returns: List of (version, release_date) tuples in order they appear
    """
    versions = []
    for line in content.split('\n'):
        parsed = parse_version_line(line)
        if parsed:
            versions.append(parsed)
    
    return versions


def analyze_version_changes(repo_root: str, changelog_path: str, since_date: str) -> Dict:
    """
    Analyze version changes for a single CHANGELOG.md file.
    
    Algorithm:
    1. Read the current CHANGELOG content and extract ALL releases
    2. Filter releases by date range
    3. For each release in range, check git history to count version changes while unreleased
    4. If no git history exists (file was regenerated), assume 0 changes
    
    Example:
    - Commit 1: ## 1.0.0-beta.1 (Unreleased)  <- Start tracking
    - Commit 2: ## 1.0.0-beta.2 (Unreleased)  <- Version changed (1 change)
    - Commit 3: ## 1.0.0 (2025-11-10)         <- Released (1 total change before release)
    
    Returns: Dictionary with analysis results
    """
    # First, read the current CHANGELOG to get all releases
    try:
        with open(changelog_path, 'r') as f:
            current_content = f.read()
    except FileNotFoundError:
        return {
            "path": changelog_path,
            "releases": [],
            "total_changes": 0,
            "avg_changes": 0.0
        }
    
    # Extract all versions from current changelog
    all_versions = extract_versions_from_changelog(current_content)
    
    # Filter to only released versions within date range
    cutoff_dt = datetime.strptime(since_date, "%Y-%m-%d")
    releases_in_range = []
    
    for version, release_date in all_versions:
        if release_date:  # Only released versions
            try:
                release_dt = datetime.strptime(release_date, "%Y-%m-%d")
                if release_dt >= cutoff_dt:
                    releases_in_range.append((version, release_date))
            except ValueError:
                pass
    
    if not releases_in_range:
        return {
            "path": changelog_path,
            "releases": [],
            "total_changes": 0,
            "avg_changes": 0.0
        }
    
    # Now get git history to track version changes
    history = get_git_history_for_file(repo_root, changelog_path, since_date)
    
    # Build sequence of top versions commit by commit
    commit_sequence = []
    if history:
        # Process commits in chronological order (oldest first)
        for commit_hash, commit_date, content in reversed(history):
            versions = extract_versions_from_changelog(content)
            
            if versions:
                top_version, top_release_date = versions[0]
                commit_sequence.append({
                    "commit": commit_hash[:7],
                    "date": commit_date.split()[0],
                    "version": top_version,
                    "released": top_release_date is not None,
                    "release_date": top_release_date
                })
    
    # For each release in range, count version changes
    releases = []
    
    for version, release_date in releases_in_range:
        # Try to find this release in commit history
        num_changes = 0
        
        if commit_sequence:
            # Find the release event in commit sequence
            release_idx = None
            for i, commit in enumerate(commit_sequence):
                if commit["version"] == version and commit["released"]:
                    release_idx = i
                    break
            
            if release_idx is not None:
                # Count distinct unreleased versions that came before this release
                unreleased_versions = set()
                
                # Go back through commits to find unreleased versions leading to this
                j = release_idx - 1
                while j >= 0:
                    prev_commit = commit_sequence[j]
                    
                    # Stop when we hit another release
                    if prev_commit["released"]:
                        break
                    
                    # Add this unreleased version
                    unreleased_versions.add(prev_commit["version"])
                    j -= 1
                
                # Check if the released version itself appeared as unreleased
                for k in range(max(0, release_idx - 10), release_idx):
                    if (commit_sequence[k]["version"] == version and 
                        not commit_sequence[k]["released"]):
                        unreleased_versions.add(version)
                        break
                
                # Number of changes = distinct versions - 1 (first doesn't count as change)
                num_changes = max(0, len(unreleased_versions) - 1) if unreleased_versions else 0
        
        releases.append({
            "version": version,
            "changes": num_changes,
            "release_date": release_date
        })
    
    total_changes = sum(r["changes"] for r in releases)
    avg_changes = total_changes / len(releases) if releases else 0.0
    
    return {
        "path": changelog_path,
        "releases": releases,
        "total_changes": total_changes,
        "avg_changes": avg_changes
    }


def main():
    """Main analysis function."""
    repo_root = "/home/runner/work/azure-sdk-for-net/azure-sdk-for-net"
    
    # Calculate date 3 months ago
    three_months_ago = datetime.now() - timedelta(days=90)
    since_date = three_months_ago.strftime("%Y-%m-%d")
    
    print(f"Analyzing CHANGELOG.md files...")
    print(f"Looking for releases since: {since_date}")
    print()
    
    # Find all changelog files
    changelog_files = find_changelog_files(repo_root, limit=None)
    print(f"Found {len(changelog_files)} CHANGELOG.md files to analyze")
    print()
    
    # Analyze each file
    results = []
    for i, changelog_path in enumerate(changelog_files, 1):
        rel_path = str(changelog_path.relative_to(repo_root))
        print(f"[{i}/{len(changelog_files)}] Analyzing {rel_path}...")
        
        analysis = analyze_version_changes(repo_root, str(changelog_path), since_date)
        
        if analysis["releases"]:
            results.append(analysis)
            print(f"  Found {len(analysis['releases'])} release(s) with {analysis['total_changes']} total changes (avg: {analysis['avg_changes']:.2f})")
        else:
            print(f"  No releases found in date range")
        print()
    
    # Write results to CSV
    output_file = Path(repo_root) / "changelog_version_analysis.csv"
    
    with open(output_file, 'w', newline='') as csvfile:
        fieldnames = ['changelog_path', 'version', 'changes_before_release', 'release_date', 'avg_changes_per_file']
        writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
        
        writer.writeheader()
        
        for result in results:
            rel_path = str(Path(result["path"]).relative_to(repo_root))
            
            if result["releases"]:
                for release in result["releases"]:
                    writer.writerow({
                        'changelog_path': rel_path,
                        'version': release['version'],
                        'changes_before_release': release['changes'],
                        'release_date': release['release_date'],
                        'avg_changes_per_file': f"{result['avg_changes']:.2f}"
                    })
            else:
                writer.writerow({
                    'changelog_path': rel_path,
                    'version': 'N/A',
                    'changes_before_release': 0,
                    'release_date': 'N/A',
                    'avg_changes_per_file': '0.00'
                })
    
    # Print summary
    print("=" * 80)
    print("SUMMARY")
    print("=" * 80)
    print(f"Files analyzed: {len(changelog_files)}")
    print(f"Files with releases in date range: {len(results)}")
    
    if results:
        total_releases = sum(len(r["releases"]) for r in results)
        total_changes = sum(r["total_changes"] for r in results)
        overall_avg = total_changes / total_releases if total_releases > 0 else 0
        
        print(f"Total releases found: {total_releases}")
        print(f"Total version changes before release: {total_changes}")
        print(f"Overall average changes per release: {overall_avg:.2f}")
        
        # Print per-file averages
        print()
        print("Per-file averages:")
        for result in results:
            rel_path = str(Path(result["path"]).relative_to(repo_root))
            print(f"  {rel_path}: {result['avg_changes']:.2f}")
    
    print()
    print(f"Results written to: {output_file}")


if __name__ == "__main__":
    main()
