// Management-review verdict contract. Execution success alone is not a clean review.
const markerPattern = /<!--\s*mgmt-review-result:\s*([\s\S]*?)\s*-->/g;

function parseReviewResult(body, headSha, event, inlineCount = 0) {
  const matches = [...String(body || '').matchAll(markerPattern)];
  if (matches.length !== 1) throw new Error('Expected exactly one management review result marker.');
  const result = JSON.parse(matches[0][1]);
  if (result?.version !== 1) throw new Error('Unsupported review result version.');
  if (!/^[a-f0-9]{40}$/.test(headSha) || result.head_sha !== headSha) throw new Error('Review result does not match the captured head.');
  if (!Number.isSafeInteger(result.run_id) || result.run_id <= 0 || !Number.isSafeInteger(result.run_attempt) || result.run_attempt <= 0) throw new Error('Invalid review run identity.');
  if (!['clean', 'findings'].includes(result.verdict)) throw new Error('Invalid review verdict.');
  if (!Number.isSafeInteger(result.findings) || result.findings < 0) throw new Error('Invalid findings count.');
  if ((result.verdict === 'clean') !== (result.findings === 0)) throw new Error('Verdict and findings count disagree.');
  if (!Number.isSafeInteger(result.naming_findings) || result.naming_findings < 0 || result.naming_findings > result.findings) throw new Error('Invalid naming findings count.');
  if (result.naming_findings > 0 && event !== 'REQUEST_CHANGES') throw new Error('Naming findings must request changes in this PR, not be deferred until GA.');
  if (result.findings < inlineCount) throw new Error('Verdict omits inline findings.');
  if (!['COMMENT', 'REQUEST_CHANGES'].includes(event)) throw new Error('Invalid review event.');
  if (event === 'REQUEST_CHANGES' && result.verdict === 'clean') throw new Error('A change request cannot report clean.');
  const lines = body.split(/\r?\n/);
  if (!lines.includes(`Automated review result: ${result.verdict.toUpperCase()}`) || !lines.includes(`Reviewed commit: ${headSha}`)) {
    throw new Error('The visible review result must agree with the machine-readable marker.');
  }
  return { version: 1, head_sha: headSha, run_id: result.run_id, run_attempt: result.run_attempt, verdict: result.verdict, findings: result.findings, naming_findings: result.naming_findings };
}

function validatePublishedReview({ data, reviews, headSha, runUrl, runAttempt }) {
  if (!data || !Array.isArray(data.items) || !Array.isArray(data.errors) || data.errors.length) {
    throw new Error('Invalid safe-output data or safe-output errors.');
  }
  const requests = data.items.filter(item => item.type === 'submit_pull_request_review');
  if (requests.length !== 1) throw new Error('Expected exactly one requested PR review.');
  const request = requests[0];
  const inlineCount = data.items.filter(item => item.type === 'create_pull_request_review_comment').length;
  const expected = parseReviewResult(request.body, headSha, request.event, inlineCount);
  const inlineNaming = data.items.filter(item => item.type === 'create_pull_request_review_comment' && /^\s*\*\*\[NAMING\]\*\*/.test(item.body || '')).length;
  if (expected.naming_findings < inlineNaming) throw new Error('Verdict omits inline naming findings.');
  if (expected.run_id !== Number(runUrl.split('/').at(-1)) || expected.run_attempt !== runAttempt) throw new Error('Review result belongs to a different workflow run or attempt.');
  const footer = `> Analyzed by Azure .NET Management SDK PR Review: ${runUrl}`;
  const candidates = reviews.filter(review => review.user?.login === 'github-actions[bot]' &&
    review.commit_id === headSha && String(review.body || '').split(/\r?\n/).includes(footer));
  if (candidates.length !== 1) throw new Error('Expected exactly one published workflow review for this head and run.');
  const review = candidates[0];
  const state = request.event === 'REQUEST_CHANGES' ? 'CHANGES_REQUESTED' : 'COMMENTED';
  if (review.state !== state) throw new Error('Published review event does not match the requested event.');
  const actual = parseReviewResult(review.body, headSha, request.event, inlineCount);
  if (JSON.stringify(actual) !== JSON.stringify(expected)) throw new Error('Published review result differs from the requested result.');
  return { ...actual, review_id: review.id };
}

module.exports = { parseReviewResult, validatePublishedReview };
