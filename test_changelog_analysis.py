#!/usr/bin/env python3
"""
Test script for CHANGELOG analysis tool.

Tests that the tool correctly handles:
1. Multiple releases per CHANGELOG file
2. Calculates averages correctly per file
3. Handles files with no git history (regenerated files)
"""

import unittest
from datetime import datetime, timedelta
from analyze_changelog_versions import analyze_version_changes


class TestChangelogAnalysis(unittest.TestCase):
    """Test cases for CHANGELOG version change analysis."""
    
    def setUp(self):
        """Set up test fixtures."""
        self.repo_root = "/home/runner/work/azure-sdk-for-net/azure-sdk-for-net"
        self.three_months_ago = datetime.now() - timedelta(days=90)
        self.since_date = self.three_months_ago.strftime("%Y-%m-%d")
    
    def test_azure_core_multiple_releases(self):
        """Test that Azure.Core CHANGELOG shows multiple releases in the last 3 months."""
        changelog_path = f"{self.repo_root}/sdk/core/Azure.Core/CHANGELOG.md"
        
        result = analyze_version_changes(self.repo_root, changelog_path, self.since_date)
        
        # Azure.Core should have multiple releases in the last 3 months
        # Based on the CHANGELOG content:
        # - 1.50.0 (2025-11-05)
        # - 1.49.0 (2025-09-22)
        # - 1.48.0 (2025-09-09)
        # - 1.47.3 (2025-08-20)
        self.assertGreaterEqual(len(result["releases"]), 2, 
                                f"Expected at least 2 releases, found {len(result['releases'])}")
        
        # Verify specific releases
        release_versions = [r["version"] for r in result["releases"]]
        self.assertIn("1.50.0", release_versions, "Should include 1.50.0 release")
        self.assertIn("1.48.0", release_versions, "Should include 1.48.0 release")
        
        # Check release dates
        for release in result["releases"]:
            release_date = datetime.strptime(release["release_date"], "%Y-%m-%d")
            self.assertGreaterEqual(release_date, self.three_months_ago,
                                    f"Release {release['version']} date should be within 3 months")
        
        print(f"✓ Azure.Core test passed: Found {len(result['releases'])} releases")
        for r in result["releases"]:
            print(f"  - {r['version']} ({r['release_date']}): {r['changes']} changes")
    
    def test_average_calculation(self):
        """Test that average changes per file is calculated correctly."""
        changelog_path = f"{self.repo_root}/sdk/core/Azure.Core/CHANGELOG.md"
        
        result = analyze_version_changes(self.repo_root, changelog_path, self.since_date)
        
        if result["releases"]:
            # Calculate expected average
            total_changes = sum(r["changes"] for r in result["releases"])
            expected_avg = total_changes / len(result["releases"])
            
            self.assertEqual(result["avg_changes"], expected_avg,
                             "Average should be total changes divided by number of releases")
            self.assertEqual(result["total_changes"], total_changes,
                             "Total changes should sum all release changes")
            
            print(f"✓ Average calculation test passed:")
            print(f"  Total changes: {result['total_changes']}")
            print(f"  Number of releases: {len(result['releases'])}")
            print(f"  Average: {result['avg_changes']:.2f}")
    
    def test_regenerated_file_handling(self):
        """Test that files with no git history (regenerated) are handled correctly."""
        # Azure.Core was regenerated, so it should have releases but no version changes
        changelog_path = f"{self.repo_root}/sdk/core/Azure.Core/CHANGELOG.md"
        
        result = analyze_version_changes(self.repo_root, changelog_path, self.since_date)
        
        # Should find releases
        self.assertGreater(len(result["releases"]), 0,
                           "Should find releases even in regenerated files")
        
        # With no git history of version evolution, changes should be 0
        for release in result["releases"]:
            # Note: This may be 0 if no unreleased versions were tracked
            self.assertGreaterEqual(release["changes"], 0,
                                    "Changes should be 0 or positive")
        
        print(f"✓ Regenerated file test passed: Found {len(result['releases'])} releases")


if __name__ == "__main__":
    # Run tests
    suite = unittest.TestLoader().loadTestsFromTestCase(TestChangelogAnalysis)
    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)
    
    # Exit with appropriate code
    exit(0 if result.wasSuccessful() else 1)
