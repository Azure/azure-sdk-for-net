const assert = require('node:assert/strict');
const { test } = require('node:test');
const fs = require('node:fs');
const path = require('node:path');
const { parseReviewResult, validatePublishedReview } = require('./mgmt-review-result.cjs');

const sha = 'a'.repeat(40);
const runUrl = 'https://github.com/Azure/azure-sdk-for-net/actions/runs/456';
const result = (extra = {}) => ({ version: 1, head_sha: sha, run_id: 456, run_attempt: 1, verdict: 'clean', findings: 0, naming_findings: 0, ...extra });
const body = (value = result()) => `### Management SDK Review Summary\nAutomated review result: ${value.verdict.toUpperCase()}\nReviewed commit: ${value.head_sha}\n<!-- mgmt-review-result: ${JSON.stringify(value)} -->`;
const published = (text = body(), extra = {}) => ({
  id: 789, user: { login: 'github-actions[bot]' }, commit_id: sha, state: 'COMMENTED',
  body: `${text}\n> Analyzed by Azure .NET Management SDK PR Review: ${runUrl}`, ...extra,
});
const output = (text = body(), event = 'COMMENT') => ({ items: [{ type: 'submit_pull_request_review', event, body: text }], errors: [] });
const validate = (data = output(), reviews = [published()]) => validatePublishedReview({ data, reviews, headSha: sha, runUrl, runAttempt: 1 });

test('accepts a clean current-head published review', () => {
  assert.deepEqual(validate(), { ...result(), review_id: 789 });
});
test('accepts findings without reporting clean, including reused findings without new inline comments', () => {
  const value = result({ verdict: 'findings', findings: 2 });
  assert.equal(validate(output(body(value), 'REQUEST_CHANGES'), [published(body(value), { state: 'CHANGES_REQUESTED' })]).verdict, 'findings');
  const withGuidance = `## ⚠️ Action required: resolve TypeSpec review findings\n\n${body(value)}`;
  assert.equal(validate(output(withGuidance, 'REQUEST_CHANGES'), [published(withGuidance, { state: 'CHANGES_REQUESTED' })]).verdict, 'findings');
});
test('rejects the original missing-verdict regression', () => {
  assert.throws(() => parseReviewResult('### Management SDK Review Summary\nNo new issues.', sha, 'COMMENT'), /exactly one/);
});
test('rejects duplicate markers, malformed JSON and unsupported schema', () => {
  assert.throws(() => parseReviewResult(body() + body(), sha, 'COMMENT'), /exactly one/);
  assert.throws(() => parseReviewResult('<!-- mgmt-review-result: nope -->', sha, 'COMMENT'), /JSON/);
  assert.throws(() => parseReviewResult(body(result({ version: 2 })), sha, 'COMMENT'), /version/);
});
test('rejects stale SHA and unknown verdict', () => {
  assert.throws(() => parseReviewResult(body(result({ head_sha: 'b'.repeat(40) })), sha, 'COMMENT'), /head/);
  assert.throws(() => parseReviewResult(body(result({ verdict: 'ci_analysis' })), sha, 'COMMENT'), /verdict/);
});
test('requires findings count to agree with verdict and inline output', () => {
  for (const value of [result({ findings: 1 }), result({ verdict: 'findings' }), result({ findings: -1 }), result({ findings: 0.5 })]) {
    assert.throws(() => parseReviewResult(body(value), sha, 'COMMENT'));
  }
  assert.throws(() => parseReviewResult(body(), sha, 'COMMENT', 1), /inline/);
});
test('change requests cannot claim clean and visible result must agree', () => {
  assert.throws(() => parseReviewResult(body(), sha, 'REQUEST_CHANGES'), /clean/);
  assert.throws(() => parseReviewResult(body().replace('result: CLEAN', 'result: FINDINGS'), sha, 'COMMENT'), /visible/);
});
test('requires exactly one requested review, with no safe-output errors', () => {
  assert.throws(() => validate({ items: [], errors: [] }), /exactly one/);
  assert.throws(() => validate({ items: [...output().items, ...output().items], errors: [] }), /exactly one/);
  assert.throws(() => validate({ ...output(), errors: ['blocked'] }), /errors/);
});
test('rejects human, other-workflow, stale-head, and dismissed reviews', () => {
  for (const extra of [{ user: { login: 'some-user' } }, { body: body() }, { commit_id: 'b'.repeat(40) }, { state: 'DISMISSED' }]) {
    assert.throws(() => validate(output(), [published(body(), extra)]));
  }
});
test('rejects replay from another run or rerun attempt', () => {
  for (const extra of [{ run_id: 999 }, { run_attempt: 2 }]) {
    const text = body(result(extra));
    assert.throws(() => validate(output(text), [published(text)]), /run or attempt/);
  }
});

test('published result must match requested result and event', () => {
  const findings = result({ verdict: 'findings', findings: 1 });
  assert.throws(() => validate(output(), [published(body(findings))]));
  assert.throws(() => validate(output(), [published(body(), { state: 'CHANGES_REQUESTED' })]));
});
test('actionable naming cannot remain a non-blocking before-GA comment', () => {
  const value = result({ verdict: 'findings', findings: 1, naming_findings: 1 });
  assert.throws(() => validate(output(body(value), 'COMMENT'), [published(body(value))]), /Naming findings must request changes/);
  assert.equal(validate(output(body(value), 'REQUEST_CHANGES'), [published(body(value), { state: 'CHANGES_REQUESTED' })]).verdict, 'findings');
});

test('naming inline comments cannot be hidden behind a clean or non-naming result', () => {
  const data = output(body(result({ verdict: 'findings', findings: 1 })), 'REQUEST_CHANGES');
  data.items.push({ type: 'create_pull_request_review_comment', body: '**[NAMING]** **[CONTEXTUALNAMING]** Fix this type name in this PR.' });
  assert.throws(() => validate(data, [published(data.items[0].body, { state: 'CHANGES_REQUESTED' })]), /omits inline naming/);
});

test('non-naming advisory findings remain non-clean even with COMMENT', () => {
  const value = result({ verdict: 'findings', findings: 1 });
  assert.equal(validate(output(body(value)), [published(body(value))]).verdict, 'findings');
});

test('checks actual inline findings against the verdict', () => {
  const data = output();
  data.items.push({ type: 'create_pull_request_review_comment', body: '[P2] issue' });
  assert.throws(() => validate(data), /inline/);
});

test('the skill centrally defines compatible workflow and manual signal templates', () => {
  const skill = fs.readFileSync(path.join(__dirname, '../../skills/azure-sdk-mgmt-pr-review/SKILL.md'), 'utf8');
  const blocks = [...skill.matchAll(/```markdown\n([\s\S]*?)```/g)].map(match => match[1]);
  const workflow = blocks.filter(block => block.includes('<!-- mgmt-review-result:'));
  const manual = blocks.filter(block => block.includes('<!-- mgmt-manual-review-result:'));
  assert.equal(workflow.length, 1, 'The skill must own exactly one workflow template');
  assert.equal(manual.length, 1, 'The skill must own exactly one manual template');
  const render = value => value.replaceAll('<full-reviewed-head-sha>', sha)
    .replaceAll('<workflow-run-id>', '456').replaceAll('<workflow-run-attempt>', '1');
  assert.deepEqual(parseReviewResult(render(workflow[0]), sha, 'COMMENT'), result());
  const manualResult = JSON.parse(render(manual[0]).match(/<!-- mgmt-manual-review-result:\s*([\s\S]*?)\s*-->/)[1]);
  assert.deepEqual(manualResult, { version: 1, head_sha: sha, verdict: 'clean', findings: 0, naming_findings: 0 });
});

test('the workflow supplies trusted context and references the skill without duplicating signal templates', () => {
  const workflow = fs.readFileSync(path.join(__dirname, '../mgmt-review.md'), 'utf8');
  assert.ok(workflow.includes('Final Review Signal'));
  assert.ok(workflow.includes('${{ needs.capture_review_head.outputs.head_sha }}'));
  assert.ok(workflow.includes('${{ github.run_id }}'));
  assert.ok(workflow.includes('${{ env.MGMT_REVIEW_RUN_ATTEMPT }}'));
  assert.ok(!workflow.includes('<!-- mgmt-review-result:'));
  assert.ok(!workflow.includes('<!-- mgmt-manual-review-result:'));
});
