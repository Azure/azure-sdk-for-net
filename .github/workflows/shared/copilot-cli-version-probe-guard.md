---
jobs:
  agent:
    pre-steps:
      - &guard-copilot-cli-version-probe
        name: Guard Copilot CLI version probe
        shell: bash
        run: |
          set -euo pipefail

          installer="${RUNNER_TEMP}/gh-aw/actions/install_copilot_cli.sh"

          if [ ! -f "$installer" ]; then
            echo "ERROR: Copilot CLI installer not found at $installer" >&2
            exit 1
          fi

          if ! command -v timeout >/dev/null 2>&1; then
            echo "ERROR: The timeout command is required to guard the Copilot CLI version probe" >&2
            exit 1
          fi

          if grep -q '^probe_copilot_cli_version()' "$installer"; then
            echo "Copilot CLI version probe is already guarded"
            exit 0
          fi

          patched="${installer}.guarded"
          rm -f "$patched"

          while IFS= read -r line || [ -n "$line" ]; do
            printf '%s\n' "$line" >> "$patched"

            if [ "$line" = "set -euo pipefail" ]; then
              cat >> "$patched" <<'EOF'

          probe_copilot_cli_version() {
            local cli="$1"
            local output
            local status
            local timeout_seconds="${GH_AW_COPILOT_VERSION_PROBE_TIMEOUT_SECONDS:-30}"

            if ! [[ "$timeout_seconds" =~ ^[1-9][0-9]*$ ]]; then
              echo "ERROR: Invalid Copilot CLI version probe timeout: $timeout_seconds" >&2
              return 1
            fi

            output="$(mktemp "${TEMP_DIR:-${RUNNER_TEMP}}/copilot-version-probe.XXXXXX")"

            set +e
            timeout --signal=TERM --kill-after=5s "${timeout_seconds}s" "$cli" --version >"$output" 2>&1
            status=$?
            set -e

            cat "$output"

            if [ "$status" -eq 0 ]; then
              rm -f "$output"
              return 0
            fi

            if { [ "$status" -eq 124 ] || [ "$status" -eq 137 ]; } &&
              grep -Eq '(^|[^0-9])[0-9]+\.[0-9]+\.[0-9]+([^0-9]|$)' "$output"; then
              echo "::warning::Copilot CLI version probe did not exit after producing output; the process was terminated and setup will continue"
              rm -f "$output"
              return 0
            fi

            echo "ERROR: Copilot CLI version probe failed with exit code $status" >&2
            rm -f "$output"
            return "$status"
          }
          EOF
            fi
          done < "$installer"

          replaced="${patched}.replaced"
          sed \
            -e 's|"$RESOLVED_COPILOT" --version|probe_copilot_cli_version "$RESOLVED_COPILOT"|' \
            -e 's|"${INSTALL_DIR}/copilot" --version|probe_copilot_cli_version "${INSTALL_DIR}/copilot"|' \
            -e 's|copilot --version|probe_copilot_cli_version "$(command -v copilot)"|' \
            "$patched" > "$replaced"
          mv "$replaced" "$patched"

          replacement_count="$(grep -c 'probe_copilot_cli_version ' "$patched")"

          if [ "$replacement_count" -ne 3 ]; then
            echo "ERROR: Expected to guard 3 Copilot CLI version probes, guarded $replacement_count" >&2
            rm -f "$patched"
            exit 1
          fi

          chmod --reference="$installer" "$patched"
          mv "$patched" "$installer"

          echo "Guarded 3 Copilot CLI version probes with a 30-second default timeout"
  detection:
    pre-steps:
      - *guard-copilot-cli-version-probe
---

<!-- Remove this import after gh-aw bounds the Copilot CLI version probes upstream -->
