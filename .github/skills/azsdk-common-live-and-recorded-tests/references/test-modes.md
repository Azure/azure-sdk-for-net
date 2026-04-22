# Test Modes

## Overview

| Mode | Description | Requires Azure Resources | Records Traffic |
|------|-------------|--------------------------|-----------------|
| **Playback** | Runs against previously recorded HTTP interactions | No | No |
| **Record** | Runs against real Azure resources and records HTTP interactions | Yes | Yes |
| **Live** | Runs against real Azure resources without recording | Yes | No |

## Default Behavior

When no test mode is specified, **Playback** is the default. Playback mode does not require test resource deployment or environment variables.

## Record Mode

- Requires deployed test resources and environment variables passed via a `.env` file.
- When all tests pass in record mode, the tool automatically pushes recorded test assets to the assets repo.
- This is the standard workflow for creating or updating test recordings.

## Live Mode

- Requires deployed test resources and environment variables passed via a `.env` file.
- Tests run against real Azure resources without recording HTTP traffic.
- Useful for validating that tests work against real services without updating recordings.

## Playback Mode

- Does not require deployed Azure resources.
- Tests replay previously recorded HTTP interactions via the test proxy.
- This is the default mode and the fastest way to run tests locally.
