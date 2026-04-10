---
description: 'SDK release readiness and publishing'
related_skill: "azsdk-common-sdk-release"
---

# SDK release

> **Related Skill:** See `.github/skills/azsdk-common-sdk-release/SKILL.md` for the complete release workflow with step-by-step guidance and troubleshooting.

There are two tools to help with SDK releases:
- Check SDK release readiness
- Release SDK

## Check SDK Release Readiness
Run `CheckPackageReleaseReadiness` to verify if the package is ready for release. This tool checks:
- API review status
- Change log status
- Package name approval(If package is new and releasing a preview version)
- Release date is set in release tracker

## Release SDK
Run `ReleasePackage` to release the package. This tool requires package name and language as inputs. It will:
- Check if the package is ready for release
- Identify the release pipeline
- Trigger the release pipeline.
User needs to approve the release stage in the pipeline after it is triggered.