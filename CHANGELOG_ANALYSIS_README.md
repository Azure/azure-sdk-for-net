# CHANGELOG Version Change Analysis Tool

## Purpose

This tool analyzes CHANGELOG.md files across the Azure SDK repository to track how many times unreleased package versions changed before being released.

## Background

SDK packages maintain a CHANGELOG.md file with version entries in the format:
- `## 1.0.0-beta.1 (Unreleased)` - Version is being actively developed
- `## 1.0.0-beta.1 (2025-11-10)` - Version was released on the specified date

The tool tracks the evolution of version numbers to understand how frequently version numbers change while in an unreleased state.

## Usage

### Basic Usage

Run the analysis on a sample of 10 CHANGELOG files:

```bash
python3 analyze_changelog_versions.py
```

### Configuration

Edit the script to adjust:
- **Time period**: Modify `three_months_ago` calculation in `main()` function
- **File limit**: Change the `limit` parameter in `find_changelog_files()` call
- **File selection**: Modify the `find_changelog_files()` function to target specific directories

### Output

The tool generates:
1. **Console output**: Summary statistics and per-file analysis
2. **CSV file**: `changelog_version_analysis.csv` with columns:
   - `changelog_path`: Relative path to the CHANGELOG.md file
   - `version`: The released version number
   - `changes_before_release`: Count of version number changes while unreleased
   - `release_date`: Date the version was released
   - `avg_changes_per_file`: Average changes per release for this file

## How It Works

1. **Find CHANGELOGs**: Locates all CHANGELOG.md files under the `sdk/` directory
2. **Retrieve Git History**: Gets full commit history for each file (requires unshallow clone)
3. **Parse Versions**: Extracts version headers and determines if they're released or unreleased
4. **Track Evolution**: Follows the chronological sequence of version numbers
5. **Count Changes**: For each release, counts how many distinct version numbers appeared while unreleased
6. **Calculate Statistics**: Computes per-file and overall averages

## Example Scenarios

### Scenario 1: No version changes before release
```
Commit 1: ## 1.0.0-beta.1 (Unreleased)
Commit 2: ## 1.0.0-beta.1 (Unreleased)  <- Same version, multiple commits
Commit 3: ## 1.0.0-beta.1 (2025-11-10)  <- Released
Result: 0 changes before release
```

### Scenario 2: Version changes before release
```
Commit 1: ## 1.0.0-beta.1 (Unreleased)
Commit 2: ## 1.0.0-beta.2 (Unreleased)  <- Version changed (1 change)
Commit 3: ## 1.0.0-beta.3 (Unreleased)  <- Version changed again (2 changes)
Commit 4: ## 1.0.0 (2025-11-10)         <- Released
Result: 2 changes before release
```

### Scenario 3: Multiple releases per file
```
Release 1: beta.1 → beta.2 → released (1 change)
Release 2: 1.1.0-beta.1 → 1.1.0 (0 changes)
Average: 0.5 changes per release for this file
```

## Requirements

- Python 3.7+
- Git repository with full history (run `git fetch --unshallow` if needed)
- Standard library only (no external dependencies)

## Notes

- The tool looks back 3 months from the current date by default
- Only released versions (with dates) are included in the analysis
- The analysis is based on the "top" version in each commit (first version header in the CHANGELOG)
- Files with no releases in the time period are skipped in the output
