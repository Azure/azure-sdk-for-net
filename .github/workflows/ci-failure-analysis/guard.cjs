// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

const checkName = 'Azure .NET CI Failure Analysis';

function positiveInteger(value, name) {
  if (!Number.isSafeInteger(value) || value <= 0) {
    throw new Error(`Invalid ${name}.`);
  }
  return value;
}

function failureEvent(context) {
  const check = context.payload.check_run;
  return context.eventName === 'check_run' &&
    context.payload.action === 'completed' &&
    check?.name === 'net - pullrequest' &&
    check.status === 'completed' &&
    check.conclusion === 'failure';
}

function validateEvent(context) {
  const check = context.payload.check_run;
  positiveInteger(check.id, 'CI check run ID');
  positiveInteger(context.payload.repository.id, 'repository ID');
  if (!/^[0-9a-f]{40}$/.test(check.head_sha)) {
    throw new Error('Invalid CI head SHA.');
  }
  if (!/^\d{4}-\d\d-\d\dT\d\d:\d\d:\d\d(?:\.\d+)?Z$/.test(check.completed_at) ||
      !Number.isFinite(Date.parse(check.completed_at))) {
    throw new Error('Invalid CI completion timestamp.');
  }
}

function keyFor(context, prNumber) {
  const check = context.payload.check_run;
  // Check-run events have no run_attempt; completed_at distinguishes repeated completions of the same ID.
  return `ci-failure-analysis:${context.payload.repository.id}:${prNumber}:${check.head_sha}:${check.id}:${check.completed_at}`;
}

function workflowAttempt(context) {
  return positiveInteger(context.runAttempt ?? Number(process.env.GITHUB_RUN_ATTEMPT || 1), 'workflow run attempt');
}

function runUrl(context) {
  const id = positiveInteger(context.runId, 'workflow run ID');
  return `${context.serverUrl}/${context.repo.owner}/${context.repo.repo}/actions/runs/${id}/attempts/${workflowAttempt(context)}`;
}

function currentCheck(context, check) {
  const event = context.payload.check_run;
  return check.id === event.id &&
    check.name === event.name &&
    check.status === 'completed' &&
    check.conclusion === 'failure' &&
    check.head_sha === event.head_sha &&
    check.completed_at === event.completed_at;
}

function currentPr(context, pr) {
  return pr.state === 'open' &&
    pr.draft === false &&
    pr.base?.repo?.id === context.payload.repository.id &&
    pr.head?.sha === context.payload.check_run.head_sha;
}

async function reportExists({ github, context }, prNumber) {
  const marker = `<!-- ${keyFor(context, prNumber)} -->`;
  const comments = await github.paginate(github.rest.issues.listComments, {
    ...context.repo, issue_number: prNumber, per_page: 100
  });
  return comments.some(comment =>
    comment.user?.login === 'github-actions[bot]' &&
    comment.user.type === 'Bot' &&
    comment.body?.startsWith(`## 🔍 CI Failure Analysis for PR #${prNumber}\n`) &&
    comment.body.includes(marker));
}

async function prepare({ github, context, core }) {
  core.setOutput('eligible', 'false');
  if (!failureEvent(context)) {
    core.info('Skipping event: only completed, failed net - pullrequest checks are eligible.');
    return { eligible: false };
  }
  validateEvent(context);
  const { data: check } = await github.rest.checks.get({
    ...context.repo, check_run_id: context.payload.check_run.id
  });
  if (!currentCheck(context, check)) {
    core.info('Skipping a superseded CI completion.');
    return { eligible: false };
  }

  let candidates = context.payload.check_run.pull_requests || [];
  if (candidates.length === 0) {
    candidates = (await github.paginate(github.rest.pulls.list, {
      ...context.repo, state: 'open', per_page: 100
    }))
      .filter(pr => currentPr(context, pr))
      .sort((a, b) => b.updated_at.localeCompare(a.updated_at));
  }

  for (const candidate of candidates) {
    const prNumber = positiveInteger(candidate.number, 'pull request number');
    const { data: pr } = await github.rest.pulls.get({ ...context.repo, pull_number: prNumber });
    if (!currentPr(context, pr)) {
      core.info(`Skipping PR #${prNumber}: closed, draft, foreign repository, or superseded head.`);
      continue;
    }

    const key = keyFor(context, prNumber);
    const claims = await github.paginate(github.rest.checks.listForRef, {
      ...context.repo, ref: check.head_sha, check_name: checkName, filter: 'all', per_page: 100
    });
    if (claims.some(claim => claim.name === checkName && claim.external_id === key) ||
        await reportExists({ github, context }, prNumber)) {
      core.info(`Skipping PR #${prNumber}: this CI completion has already been claimed or reported.`);
      return { eligible: false };
    }

    const { data: claim } = await github.rest.checks.create({
      ...context.repo,
      name: checkName,
      head_sha: check.head_sha,
      external_id: key,
      status: 'in_progress',
      details_url: runUrl(context),
      output: {
        title: checkName,
        summary: `Analyzing failed net - pullrequest check ${check.id} completed at ${check.completed_at} for PR #${prNumber}.`
      }
    });
    const prepared = {
      eligible: true,
      prNumber,
      claimId: positiveInteger(claim.id, 'analysis check ID'),
      headSha: check.head_sha,
      completedAt: check.completed_at,
      workflowRunId: context.runId,
      workflowRunAttempt: workflowAttempt(context)
    };
    core.setOutput('analysis_context', JSON.stringify(prepared));
    core.setOutput('pr_number', prNumber);
    core.setOutput('head_sha', check.head_sha);
    core.setOutput('completed_at', check.completed_at);
    core.setOutput('eligible', 'true');
    core.info(`Claimed ${key} in check ${claim.id}.`);
    return prepared;
  }

  core.info('No open, non-draft pull request matches the failed CI head.');
  return { eligible: false };
}

async function ownedClaim({ github, context, prepared }) {
  if (!failureEvent(context)) throw new Error('Invalid CI failure event.');
  validateEvent(context);
  positiveInteger(prepared?.prNumber, 'pull request number');
  positiveInteger(prepared?.claimId, 'analysis check ID');
  if (prepared.headSha !== context.payload.check_run.head_sha ||
      prepared.completedAt !== context.payload.check_run.completed_at) {
    throw new Error('Analysis context does not identify the triggering CI head and completion.');
  }
  if (prepared.workflowRunId !== context.runId || prepared.workflowRunAttempt !== workflowAttempt(context)) {
    throw new Error('Analysis claim belongs to a different workflow run or attempt.');
  }
  const { data: claim } = await github.rest.checks.get({
    ...context.repo, check_run_id: prepared.claimId
  });
  if (claim.name !== checkName ||
      claim.head_sha !== context.payload.check_run.head_sha ||
      claim.external_id !== keyFor(context, prepared.prNumber) ||
      claim.details_url !== runUrl(context)) {
    throw new Error('Analysis claim does not belong to this workflow run and CI completion.');
  }
  return claim;
}

async function stillCurrent({ github, context, prepared }) {
  const { data: check } = await github.rest.checks.get({
    ...context.repo, check_run_id: context.payload.check_run.id
  });
  if (!currentCheck(context, check)) return false;
  const { data: pr } = await github.rest.pulls.get({
    ...context.repo, pull_number: prepared.prNumber
  });
  return currentPr(context, pr);
}

async function beginAnalysis({ github, context, core, prepared }) {
  core.setOutput('eligible', 'false');
  if (!failureEvent(context)) return false;
  const args = { github, context, prepared };
  const claim = await ownedClaim(args);
  if (claim.status !== 'in_progress' ||
      !await stillCurrent(args) ||
      await reportExists(args, prepared.prNumber)) {
    core.info('Skipping agent startup: the analysis is completed, superseded, or already reported.');
    return false;
  }
  core.setOutput('eligible', 'true');
  return true;
}

async function guardOutput({ github, context, core, prepared, agentOutput }) {
  const args = { github, context, prepared };
  const claim = await ownedClaim(args);
  if (claim.status !== 'in_progress') throw new Error('Analysis claim is no longer active.');
  if (!agentOutput || !Array.isArray(agentOutput.items) || agentOutput.items.length === 0) {
    throw new Error('Missing or malformed CI analysis output.');
  }
  const allowed = new Set(['add_comment', 'noop', 'report_incomplete', 'missing_data', 'missing_tool']);
  if (agentOutput.items.some(item => !item || !allowed.has(item.type))) {
    throw new Error('Unexpected CI analysis output item.');
  }
  if (agentOutput.items.some(item => item.type === 'report_incomplete')) {
    return { disposition: 'incomplete', agentOutput };
  }
  if (!await stillCurrent(args)) {
    core.info('Suppressing stale CI analysis output.');
    return {
      disposition: 'skip',
      agentOutput: { ...agentOutput, items: [{ type: 'noop', message: 'The PR or CI completion is no longer current.' }] }
    };
  }
  if (await reportExists(args, prepared.prNumber)) {
    core.info('Suppressing duplicate CI analysis output.');
    return {
      disposition: 'duplicate',
      agentOutput: { ...agentOutput, items: [{ type: 'noop', message: 'This CI completion already has a report.' }] }
    };
  }

  const comments = agentOutput.items.filter(item => item.type === 'add_comment');
  if (comments.length !== 1 || typeof comments[0].body !== 'string' ||
      !comments[0].body.startsWith(`## 🔍 CI Failure Analysis for PR #${prepared.prNumber}\n`)) {
    throw new Error('Expected exactly one CI failure analysis comment for the target PR.');
  }
  const marker = `<!-- ${keyFor(context, prepared.prNumber)} -->`;
  return {
    disposition: 'publish',
    agentOutput: {
      ...agentOutput,
      items: agentOutput.items.map(item => item.type === 'add_comment'
        ? { ...item, body: `${item.body}\n\n${marker}` }
        : item)
    }
  };
}

async function finalize({ github, context, core, prepared, jobResults }) {
  const args = { github, context, prepared };
  const claim = await ownedClaim(args);
  if (claim.status === 'completed') return;

  const failedJobs = Object.entries(jobResults)
    .filter(([, result]) => result === 'failure' || result === 'cancelled')
    .map(([name]) => name);
  let conclusion;
  let summary;
  if (failedJobs.length > 0) {
    conclusion = 'failure';
    summary = `CI failure analysis failed in: ${failedJobs.join(', ')}.`;
  } else if (!await stillCurrent(args)) {
    conclusion = 'skipped';
    summary = 'CI failure analysis skipped because the PR or CI completion is no longer current.';
  } else if (await reportExists(args, prepared.prNumber)) {
    conclusion = 'success';
    summary = 'CI failure analysis comment published and verified.';
  } else {
    conclusion = 'failure';
    summary = 'CI failure analysis did not publish the expected report.';
  }

  await github.rest.checks.update({
    ...context.repo,
    check_run_id: prepared.claimId,
    status: 'completed',
    conclusion,
    output: { title: checkName, summary: `${summary} See ${runUrl(context)}` }
  });
  core.info(summary);
  if (conclusion === 'failure') throw new Error(summary);
}

module.exports = { prepare, beginAnalysis, guardOutput, finalize };
