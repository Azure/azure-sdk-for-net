// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const vm = require('node:vm');
const { createRequire } = require('node:module');
const { test } = require('node:test');

const headSha = 'a'.repeat(40);
const completedAt = '2026-09-10T18:00:00Z';
const implementation = () => require('./guard.cjs');

function fixture() {
  const check = {
    id: 123,
    name: 'net - pullrequest',
    status: 'completed',
    conclusion: 'failure',
    head_sha: headSha,
    completed_at: completedAt,
    html_url: 'https://dev.azure.com/azure-sdk/public/_build/results?buildId=456',
    pull_requests: [{ number: 42 }]
  };
  const pr = {
    number: 42,
    state: 'open',
    draft: false,
    head: { sha: headSha },
    base: { repo: { id: 789 } },
    updated_at: completedAt
  };
  const context = {
    eventName: 'check_run',
    payload: { action: 'completed', repository: { id: 789 }, check_run: structuredClone(check) },
    repo: { owner: 'Azure', repo: 'azure-sdk-for-net' },
    serverUrl: 'https://github.com',
    runId: 1000,
    runAttempt: 1
  };
  const state = { check, prs: [pr], claims: [], comments: [], calls: [], outputs: {} };
  const method = (name, handler) => Object.assign(async args => {
    state.calls.push({ name, args });
    return { data: await handler(args) };
  }, { operation: name });
  const github = {
    rest: {
      checks: {
        get: method('checks.get', args => {
          const value = args.check_run_id === state.check.id
            ? state.check
            : state.claims.find(claim => claim.id === args.check_run_id);
          assert.ok(value, `Unexpected check ID ${args.check_run_id}`);
          return structuredClone(value);
        }),
        listForRef: method('checks.listForRef', () => ({ check_runs: structuredClone(state.claims) })),
        create: method('checks.create', args => {
          const claim = { id: 900 + state.claims.length, ...args };
          state.claims.push(claim);
          return structuredClone(claim);
        }),
        update: method('checks.update', args => {
          const claim = state.claims.find(value => value.id === args.check_run_id);
          assert.ok(claim);
          Object.assign(claim, args);
          return structuredClone(claim);
        })
      },
      pulls: {
        get: method('pulls.get', args => {
          const pr = state.prs.find(value => value.number === args.pull_number);
          if (!pr) throw Object.assign(new Error('PR not found'), { status: 404 });
          return structuredClone(pr);
        }),
        list: method('pulls.list', () => structuredClone(state.prs))
      },
      issues: {
        listComments: method('issues.listComments', () => structuredClone(state.comments))
      }
    },
    paginate: async (route, args) => {
      const { data } = await route(args);
      return Array.isArray(data) ? data : data.check_runs;
    }
  };
  const core = {
    info: () => {},
    warning: () => {},
    setOutput: (key, value) => { state.outputs[key] = String(value); }
  };
  return { github, context, core, state };
}

async function prepared() {
  const f = fixture();
  const prepared = await implementation().prepare(f);
  assert.equal(prepared.eligible, true);
  assert.equal(prepared.prNumber, 42);
  assert.equal(f.state.claims.length, 1);
  return { ...f, prepared };
}

function output(prNumber = 42) {
  return { items: [{ type: 'add_comment', body: `## 🔍 CI Failure Analysis for PR #${prNumber}\n\nActual error: error CS1002.` }] };
}

function postedComment(body) {
  return { id: 600, body, user: { login: 'github-actions[bot]', type: 'Bot' } };
}

const successfulJobs = { activation: 'success', agent: 'success', detection: 'success', safe_outputs: 'success' };

function workflowLines(name) {
  return fs.readFileSync(path.join(__dirname, '..', name), 'utf8').replace(/\r\n/g, '\n').split('\n');
}

function indentedValue(lines, index) {
  const indent = lines[index].match(/^\s*/)[0].length;
  const value = lines[index].slice(lines[index].indexOf(':') + 1).trim();
  if (!['|', '>'].includes(value)) return value;
  const result = [];
  for (const line of lines.slice(index + 1)) {
    if (line.trim() && line.match(/^\s*/)[0].length <= indent) break;
    result.push(line.slice(indent + 2));
  }
  return result.join('\n').trimEnd();
}

function jobLines(lines, name) {
  const start = lines.indexOf(`  ${name}:`);
  if (start === -1) return [];
  const rest = lines.slice(start + 1);
  const end = rest.findIndex(line => /^  \S/.test(line));
  return end === -1 ? rest : rest.slice(0, end);
}

function compiledActivation(event) {
  const lines = workflowLines('ci-failure-analysis.lock.yml');
  const pre = jobLines(lines, 'pre_activation');
  const activatedIndex = pre.findIndex(line => line.trimStart().startsWith('activated:'));
  const environment = {
    github: { event_name: 'check_run', event },
    steps: {
      check_membership: { outputs: { is_team_member: 'false' } },
      start: { outcome: 'success', outputs: { eligible: 'true' } }
    },
    needs: { pre_activation: { outputs: { eligible: 'true' } } }
  };
  if (activatedIndex !== -1) {
    const expression = indentedValue(pre, activatedIndex).replace(/^\$\{\{\s*|\s*\}\}$/g, '');
    environment.needs.pre_activation.outputs.activated = String(vm.runInNewContext(expression, environment));
  }
  const activation = jobLines(lines, 'activation');
  const expression = indentedValue(activation, activation.findIndex(line => line.trimStart().startsWith('if:')));
  return vm.runInNewContext(expression, environment);
}

function stepScript(filename, name) {
  const lines = workflowLines(filename);
  const start = lines.findIndex(line => line.trim() === `- name: ${name}`);
  assert.notEqual(start, -1, `Missing step: ${name}`);
  const script = lines.findIndex((line, index) => index > start && line.trim() === 'script: |');
  assert.notEqual(script, -1, `Missing script: ${name}`);
  return indentedValue(lines, script);
}

async function runWorkflowScript(filename, name, f, env = {}, mockFs) {
  const script = stepScript(filename, name);
  const repositoryRequire = createRequire(path.resolve(__dirname, '..', '..', '..', 'package.json'));
  const localRequire = name => name === 'node:fs' && mockFs ? mockFs : repositoryRequire(name);
  const AsyncFunction = Object.getPrototypeOf(async function () {}).constructor;
  await new AsyncFunction('require', 'github', 'context', 'core', 'process', script)(
    localRequire, f.github, f.context, f.core, { env }
  );
}

test('compiled backend admits a failed CI app event without requiring a repository team role', () => {
  assert.equal(compiledActivation(fixture().context.payload), true);
});

for (const [label, runId, runAttempt, expected] of [
  ['original attempt', 1000, 1, true],
  ['partial failed-job rerun', 1000, 2, false],
  ['another workflow run', 1001, 1, false]
]) {
  test(`compiled agent condition handles ${label} even with reused activation outputs`, async () => {
    const f = await prepared();
    const lines = jobLines(workflowLines('ci-failure-analysis.lock.yml'), 'agent');
    const expression = indentedValue(lines, lines.findIndex(line => line.trimStart().startsWith('if:')));
    const github = { run_id: String(runId), run_attempt: String(runAttempt) };
    const needs = { activation: { result: 'success', outputs: { daily_ai_credits_exceeded: 'false' } } };
    const inputs = { analysis_context: JSON.stringify(f.prepared) };
    assert.equal(vm.runInNewContext(expression, { github, needs, inputs, fromJSON: JSON.parse }), expected);
  });
}

for (const [label, change] of [
  ['pending', event => { event.check_run.status = 'in_progress'; }],
  ['rerequested', event => { event.action = 'rerequested'; }]
]) {
  test(`compiled backend rejects ${label} CI even from an alternative caller`, () => {
    const event = fixture().context.payload;
    change(event);
    const lines = jobLines(workflowLines('ci-failure-analysis.lock.yml'), 'activation');
    const expression = indentedValue(lines, lines.findIndex(line => line.trimStart().startsWith('if:')));
    const github = { event_name: 'check_run', event };
    const needs = { pre_activation: { outputs: { activated: 'true', eligible: 'true' } } };
    assert.equal(vm.runInNewContext(expression, { github, needs }), false);
  });
}

test('the actual trigger script claims a qualifying event through the tested helper', async () => {
  const f = fixture();
  await runWorkflowScript('ci-failure-analysis-trigger.yml', 'Claim the completed CI failure', f);
  assert.equal(f.state.outputs.eligible, 'true');
  assert.equal(f.state.claims.length, 1);
});

test('the actual compiled publication script guards and stamps the runtime artifact', async () => {
  const f = await prepared();
  let contents = JSON.stringify(output());
  const mockFs = {
    readFileSync: file => { assert.equal(file, 'memory'); return contents; },
    writeFileSync: (file, value) => { assert.equal(file, 'memory'); contents = value; }
  };
  await runWorkflowScript('ci-failure-analysis.lock.yml', 'Revalidate CI identity before publishing', f, {
    ANALYSIS_CONTEXT: JSON.stringify(f.prepared), AGENT_OUTPUT: 'memory'
  }, mockFs);
  assert.match(JSON.parse(contents).items[0].body, /<!-- ci-failure-analysis:/);
});

test('the actual compiled startup script blocks failed-job reruns before the agent', async () => {
  const f = await prepared();
  f.context.runAttempt++;
  await assert.rejects(() => runWorkflowScript(
    'ci-failure-analysis.lock.yml', 'Validate the claimed analysis before starting the agent', f, {
      ANALYSIS_CONTEXT: JSON.stringify(f.prepared)
    }
  ), /claim|workflow run/i);
  assert.equal(f.state.outputs.eligible, 'false');
});

test('the actual finalization script fails a failed reusable workflow instead of publishing success', async () => {
  const f = await prepared();
  await assert.rejects(() => runWorkflowScript(
    'ci-failure-analysis-trigger.yml', 'Complete the CI analysis check', f, {
      ANALYSIS_CONTEXT: JSON.stringify(f.prepared), ANALYSIS_RESULT: 'failure'
    }
  ), /failed/);
  assert.equal(f.state.claims[0].conclusion, 'failure');
});

test('repository-wide failure analysis does not require management or provisioning paths', async () => {
  const f = await prepared();
  assert.equal(f.state.claims[0].status, 'in_progress');
  assert.equal(f.state.claims[0].head_sha, headSha);
  assert.ok(f.state.claims[0].external_id.includes(String(f.context.payload.check_run.id)));
  assert.equal(f.state.outputs.eligible, 'true');
  assert.equal(f.state.outputs.pr_number, '42');
  assert.equal(f.state.outputs.head_sha, headSha);
  assert.equal(f.state.outputs.completed_at, completedAt);
  assert.equal(JSON.parse(f.state.outputs.analysis_context).headSha, headSha);
  assert.equal(JSON.parse(f.state.outputs.analysis_context).completedAt, completedAt);
  assert.equal(f.prepared.workflowRunId, f.context.runId);
  assert.equal(f.prepared.workflowRunAttempt, f.context.runAttempt);
  assert.ok(!f.state.calls.some(call => call.name.includes('listFiles')));
});

for (const [label, change] of [
  ['success', f => { f.context.payload.check_run.conclusion = 'success'; }],
  ['cancelled', f => { f.context.payload.check_run.conclusion = 'cancelled'; }],
  ['neutral', f => { f.context.payload.check_run.conclusion = 'neutral'; }],
  ['pending', f => { f.context.payload.check_run.status = 'in_progress'; }],
  ['other check', f => { f.context.payload.check_run.name = 'Build'; }],
  ['rerequested event', f => { f.context.payload.action = 'rerequested'; }],
  ['manual event', f => { f.context.eventName = 'workflow_dispatch'; }],
  ['workflow run event', f => { f.context.eventName = 'workflow_run'; }]
]) {
  test(`does not analyze ${label}`, async () => {
    const f = fixture();
    change(f);
    assert.equal((await implementation().prepare(f)).eligible, false);
    assert.equal(f.state.calls.length, 0);
    assert.equal(f.state.outputs.eligible, 'false');
  });
}

for (const [label, change] of [
  ['draft PR', f => { f.state.prs[0].draft = true; }],
  ['closed PR', f => { f.state.prs[0].state = 'closed'; }],
  ['superseded PR head', f => { f.state.prs[0].head.sha = 'b'.repeat(40); }],
  ['different base repository', f => { f.state.prs[0].base.repo.id = 999; }],
  ['CI now successful', f => { f.state.check.conclusion = 'success'; }],
  ['CI rerunning', f => { f.state.check.status = 'in_progress'; }],
  ['newer CI attempt', f => { f.state.check.completed_at = '2026-09-10T19:00:00Z'; }]
]) {
  test(`skips ${label} using current API data`, async () => {
    const f = fixture();
    change(f);
    assert.equal((await implementation().prepare(f)).eligible, false);
    assert.equal(f.state.claims.length, 0);
  });
}

for (const [field, value] of [
  ['id', '123;malicious'],
  ['head_sha', '$(malicious)'],
  ['completed_at', 'not-a-time']
]) {
  test(`fails explicitly for malformed CI ${field}`, async () => {
    const f = fixture();
    f.context.payload.check_run[field] = value;
    await assert.rejects(() => implementation().prepare(f), /invalid|malformed/i);
    assert.equal(f.state.claims.length, 0);
  });
}

test('resolves an unassociated Azure DevOps check to the most recently updated matching open PR', async () => {
  const f = fixture();
  f.context.payload.check_run.pull_requests = [];
  f.state.check.pull_requests = [];
  f.state.prs.push({ ...structuredClone(f.state.prs[0]), number: 43, updated_at: '2026-09-10T19:00:00Z' });
  assert.equal((await implementation().prepare(f)).prNumber, 43);
});

test('skips an unassociated check with no matching PR', async () => {
  const f = fixture();
  f.context.payload.check_run.pull_requests = [];
  f.state.check.pull_requests = [];
  f.state.prs = [];
  assert.equal((await implementation().prepare(f)).eligible, false);
});

test('does not turn a GitHub read failure into a successful no-op', async () => {
  const f = fixture();
  f.github.rest.checks.get = async () => { throw new Error('GitHub unavailable'); };
  await assert.rejects(() => implementation().prepare(f), /GitHub unavailable/);
});

test('does not hide an inaccessible associated PR', async () => {
  const f = fixture();
  f.state.prs = [];
  await assert.rejects(() => implementation().prepare(f), /PR not found/);
});

test('serial duplicate deliveries and workflow reruns cannot claim the same CI attempt', async () => {
  const f = await prepared();
  assert.equal((await implementation().prepare(f)).eligible, false);
  f.context.runId++;
  assert.equal((await implementation().prepare(f)).eligible, false);
  f.context.runAttempt++;
  assert.equal((await implementation().prepare(f)).eligible, false);
  assert.equal(f.state.claims.length, 1);
});

test('backend startup admits only an active, current claim before any agent execution', async () => {
  const f = await prepared();
  assert.equal(await implementation().beginAnalysis(f), true);
  f.state.claims[0].status = 'completed';
  f.state.claims[0].conclusion = 'failure';
  assert.equal(await implementation().beginAnalysis(f), false);
  assert.equal(f.state.outputs.eligible, 'false');
});

test('backend startup skips a head that advanced after the trigger prepared it', async () => {
  const f = await prepared();
  f.state.prs[0].head.sha = 'b'.repeat(40);
  assert.equal(await implementation().beginAnalysis(f), false);
});

test('rerunning failed jobs with reused prepare outputs cannot run the agent again', async () => {
  const f = await prepared();
  f.context.runAttempt++;
  await assert.rejects(() => implementation().beginAnalysis(f), /claim|workflow run/i);
});

test('workflow attempt identity uses GITHUB_RUN_ATTEMPT when the toolkit omits runAttempt', async () => {
  const previous = process.env.GITHUB_RUN_ATTEMPT;
  try {
    process.env.GITHUB_RUN_ATTEMPT = '3';
    const f = fixture();
    delete f.context.runAttempt;
    await implementation().prepare(f);
    assert.ok(f.state.claims[0].details_url.endsWith('/attempts/3'));
  } finally {
    if (previous === undefined) delete process.env.GITHUB_RUN_ATTEMPT;
    else process.env.GITHUB_RUN_ATTEMPT = previous;
  }
});

test('a later completed CI attempt on the same check ID gets its own identity', async () => {
  const f = await prepared();
  f.context.payload.check_run.completed_at = f.state.check.completed_at = '2026-09-10T19:00:00Z';
  f.context.runId++;
  assert.equal((await implementation().prepare(f)).eligible, true);
  assert.equal(f.state.claims.length, 2);
  assert.notEqual(f.state.claims[0].external_id, f.state.claims[1].external_id);
});

test('distinct check run IDs on the same head are not conflated', async () => {
  const f = await prepared();
  f.context.payload.check_run.id = ++f.state.check.id;
  f.context.runId++;
  assert.equal((await implementation().prepare(f)).eligible, true);
  assert.notEqual(f.state.claims[0].external_id, f.state.claims[1].external_id);
});

test('existing bot analysis survives ledger loss without another analysis', async () => {
  const f = await prepared();
  const { agentOutput } = await implementation().guardOutput({ ...f, agentOutput: output() });
  f.state.comments.push(postedComment(agentOutput.items[0].body));
  f.state.claims = [];
  assert.equal((await implementation().prepare(f)).eligible, false);
});

test('a comment from an untrusted author cannot suppress analysis', async () => {
  const f = await prepared();
  const { agentOutput } = await implementation().guardOutput({ ...f, agentOutput: output() });
  f.state.comments.push({ ...postedComment(agentOutput.items[0].body), user: { login: 'contributor', type: 'User' } });
  f.state.claims = [];
  assert.equal((await implementation().prepare(f)).eligible, true);
});

test('safe-output guard stamps a report with immutable PR, head and CI attempt identity', async () => {
  const f = await prepared();
  const result = await implementation().guardOutput({ ...f, agentOutput: output() });
  assert.equal(result.disposition, 'publish');
  assert.match(result.agentOutput.items[0].body, /<!-- ci-failure-analysis:/);
  assert.ok(result.agentOutput.items[0].body.includes(headSha));
  assert.ok(result.agentOutput.items[0].body.includes(completedAt));
  assert.ok(result.agentOutput.items[0].body.startsWith('## 🔍 CI Failure Analysis for PR #42'));
});

for (const [label, change] of [
  ['head advances', f => { f.state.prs[0].head.sha = 'b'.repeat(40); }],
  ['PR closes', f => { f.state.prs[0].state = 'closed'; }],
  ['PR becomes draft', f => { f.state.prs[0].draft = true; }],
  ['CI starts another attempt', f => { f.state.check.status = 'in_progress'; }],
  ['CI completes again', f => { f.state.check.completed_at = '2026-09-10T19:00:00Z'; }]
]) {
  test(`safe-output guard drops stale feedback when ${label}`, async () => {
    const f = await prepared();
    change(f);
    const result = await implementation().guardOutput({ ...f, agentOutput: output() });
    assert.equal(result.disposition, 'skip');
    assert.deepEqual(result.agentOutput.items.map(item => item.type), ['noop']);
  });
}

test('safe-output guard suppresses an already published report for the same completion', async () => {
  const f = await prepared();
  const first = await implementation().guardOutput({ ...f, agentOutput: output() });
  f.state.comments.push(postedComment(first.agentOutput.items[0].body));
  const second = await implementation().guardOutput({ ...f, agentOutput: output() });
  assert.equal(second.disposition, 'duplicate');
  assert.deepEqual(second.agentOutput.items.map(item => item.type), ['noop']);
});

test('safe-output guard rejects a claim belonging to another workflow run', async () => {
  const f = await prepared();
  f.context.runId++;
  await assert.rejects(() => implementation().guardOutput({ ...f, agentOutput: output() }), /claim|owner/i);
});

test('safe-output guard rejects caller context from a different head or CI attempt', async () => {
  const f = await prepared();
  for (const prepared of [
    { ...f.prepared, headSha: 'b'.repeat(40) },
    { ...f.prepared, completedAt: '2026-09-10T19:00:00Z' }
  ]) {
    await assert.rejects(() => implementation().guardOutput({ ...f, prepared, agentOutput: output() }), /context|claim/i);
  }
});

test('safe-output guard rejects malformed, extra, wrong-PR and missing reports', async () => {
  const f = await prepared();
  for (const agentOutput of [
    undefined,
    {},
    { items: [] },
    { items: [output().items[0], output().items[0]] },
    output(43),
    { items: [{ type: 'submit_pull_request_review', body: 'Not a CI analysis' }] }
  ]) {
    await assert.rejects(() => implementation().guardOutput({ ...f, agentOutput }), /output|report|comment|item/i);
  }
});

test('report_incomplete remains a failure signal rather than being replaced by a no-op', async () => {
  const f = await prepared();
  const agentOutput = { items: [{ type: 'report_incomplete', reason: 'GitHub unavailable' }] };
  const result = await implementation().guardOutput({ ...f, agentOutput });
  assert.deepEqual(result.agentOutput, agentOutput);
});

test('finalizer marks success only after verifying a published bot report', async () => {
  const f = await prepared();
  const { agentOutput } = await implementation().guardOutput({ ...f, agentOutput: output() });
  f.state.comments.push(postedComment(agentOutput.items[0].body));
  await implementation().finalize({ ...f, jobResults: successfulJobs });
  assert.equal(f.state.claims[0].status, 'completed');
  assert.equal(f.state.claims[0].conclusion, 'success');
});

test('finalizer fails when a nominally successful agent produces no report', async () => {
  const f = await prepared();
  await assert.rejects(() => implementation().finalize({ ...f, jobResults: successfulJobs }), /report|comment/i);
  assert.equal(f.state.claims[0].conclusion, 'failure');
});

for (const job of ['activation', 'agent', 'detection', 'safe_outputs']) {
  test(`finalizer preserves ${job} failures`, async () => {
    const f = await prepared();
    await assert.rejects(() => implementation().finalize({
      ...f, jobResults: { ...successfulJobs, [job]: 'failure' }
    }), /fail/i);
    assert.equal(f.state.claims[0].conclusion, 'failure');
  });
}

test('finalizer closes stale analysis as skipped without commenting', async () => {
  const f = await prepared();
  f.state.prs[0].head.sha = 'b'.repeat(40);
  await implementation().finalize({ ...f, jobResults: successfulJobs });
  assert.equal(f.state.claims[0].conclusion, 'skipped');
});

test('finalizer propagates check publication errors', async () => {
  const f = await prepared();
  const { agentOutput } = await implementation().guardOutput({ ...f, agentOutput: output() });
  f.state.comments.push(postedComment(agentOutput.items[0].body));
  f.github.rest.checks.update = async () => { throw new Error('Check update failed'); };
  await assert.rejects(() => implementation().finalize({ ...f, jobResults: successfulJobs }), /Check update failed/);
});
