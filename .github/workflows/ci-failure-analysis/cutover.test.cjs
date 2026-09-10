// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const vm = require('node:vm');
const { spawnSync } = require('node:child_process');
const { test } = require('node:test');

const workflows = path.resolve(__dirname, '..');
const read = name => fs.readFileSync(path.join(workflows, name), 'utf8').replace(/\r\n/g, '\n');
const trigger = read('provisioning-review-trigger.yml');
const triggerCondition = trigger.match(/    if: >\n((?:      .*\n)+)/)[1].trim();
const dispatchScript = trigger.slice(trigger.indexOf('        run: |\n') + '        run: |\n'.length)
  .split('\n').map(line => line.replace(/^          /, '')).join('\n');
const reviewCondition = read('provisioning-review.md').match(/\nif: \|\n((?:  .*\n)+)/)[1].trim();

function eventContext(conclusion) {
  return { github: { event_name: 'check_run', event: { check_run: { name: 'net - pullrequest', conclusion } } } };
}

test('provisioning automatic review still accepts successful CI', () => {
  assert.equal(vm.runInNewContext(triggerCondition, eventContext('success')), true);
});

test('provisioning automatic review no longer owns failed CI', () => {
  assert.equal(vm.runInNewContext(triggerCondition, eventContext('failure')), false);
});

for (const conclusion of ['cancelled', 'neutral', null]) {
  test(`provisioning does not expand automatic review to ${conclusion}`, () => {
    assert.equal(vm.runInNewContext(triggerCondition, eventContext(conclusion)), false);
  });
}

function runManualDispatcher(conclusion) {
  const shell = process.platform === 'win32'
    ? path.join(process.env.ProgramFiles, 'Git', 'bin', 'bash.exe')
    : 'bash';
  const mock = `
gh() {
  case "$*" in
    *"workflow run"*) echo "DISPATCHED $*" ;;
    *"isDraft"*) echo false ;;
    *"headRefOid"*) echo "$CHECK_RUN_HEAD_SHA" ;;
    *"pulls/42/files"*) echo 'sdk/compute/Azure.Provisioning.Compute/src/Compute.cs' ;;
    *"pulls/42"*) echo "$CHECK_RUN_HEAD_SHA" ;;
    *"commits/"*)
      if [[ "$*" == *".completed_at"* ]]; then
        printf '2026-09-10T18:00:00Z\\t%s\\t%s\\t%s\\n' "$TEST_CONCLUSION" "$CHECK_RUN_HEAD_SHA" "$CHECK_RUN_URL"
      fi ;;
    *"repos/Azure/azure-sdk-for-net/check-runs"*) ;;
    *) echo "Unexpected gh call: $*" >&2; return 90 ;;
  esac
}
`;
  const result = spawnSync(shell, ['--noprofile', '--norc', '-c', mock + dispatchScript], {
    encoding: 'utf8',
    env: {
      ...process.env,
      GITHUB_EVENT_NAME: 'workflow_dispatch',
      GITHUB_RUN_ID: '1000',
      GITHUB_SERVER_URL: 'https://github.com',
      REPOSITORY: 'Azure/azure-sdk-for-net',
      DEFAULT_BRANCH: 'main',
      MANUAL_PR_NUMBER: '42',
      PR_NUMBER: '',
      CHECK_RUN_HEAD_SHA: 'a'.repeat(40),
      CHECK_RUN_URL: 'https://dev.azure.com/azure-sdk/public/_build/results?buildId=456',
      TEST_CONCLUSION: conclusion
    }
  });
  assert.ifError(result.error);
  assert.equal(result.status, 0, result.stderr);
  return result.stdout;
}

test('provisioning manual backfill still dispatches a successful terminal CI check', () => {
  assert.match(runManualDispatcher('success'), /DISPATCHED workflow run provisioning-review\.lock\.yml/);
});

test('provisioning manual backfill does not dispatch a failed terminal CI check', () => {
  assert.doesNotMatch(runManualDispatcher('failure'), /DISPATCHED/);
});

test('the directly dispatchable provisioning endpoint rejects explicit failed CI', () => {
  const github = { event_name: 'workflow_dispatch', event: { inputs: { check_run_conclusion: 'failure' } } };
  assert.equal(vm.runInNewContext(reviewCondition, { github }), false);
});

test('the provisioning endpoint preserves successful and unspecified manual reviews', () => {
  for (const check_run_conclusion of ['success', '']) {
    const github = { event_name: 'workflow_dispatch', event: { inputs: { check_run_conclusion } } };
    assert.equal(vm.runInNewContext(reviewCondition, { github }), true);
  }
});

test('management dispatcher, source and compiled endpoint are retired together', () => {
  for (const name of ['mgmt-review-trigger.yml', 'mgmt-review.md', 'mgmt-review.lock.yml']) {
    assert.equal(fs.existsSync(path.join(workflows, name)), false, `${name} remains dispatchable`);
  }
});
