// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
//
// Sends an email notification to the spec pull request author after a release plan is auto-created.
//
// This script runs as a pipeline step after the release plan creation step. It resolves the GitHub
// login of the spec pull request author, maps that login to a Microsoft email address using the
// opensource portal people links API (repos.opensource.microsoft.com), and sends an informational
// email using the Azure SDK emailer service.
//
// Pipeline-only: the email is only sent when the emailer service URL is provided (i.e. when running
// from the automation pipeline). Local executions without the URL are skipped so no email is sent.
//
// This script never fails the pipeline: any lookup or send failure is logged and the process exits 0
// so release plan creation is not blocked by notification problems.
//
// Inputs can be provided as `--kebab-case value` arguments or via environment variables:
//   --emailer-uri           / AZURE_SDK_EMAIL_URI    The Uri of the app used to send email notifications.
//   --pr-number             / PR_NUMBER              The spec pull request number.
//   --repository            / BUILD_REPOSITORY_NAME  The GitHub repository (owner/name) containing the PR.
//   --github-user           / NOTIFY_GITHUB_USER     The PR author's GitHub login (skips the PR lookup).
//   --release-plan-link     / RELEASE_PLAN_LINK      Link to the created release plan.
//   --spec-pull-request-url / SPEC_PULL_REQUEST_URL  Link to the spec pull request.
//   --email-cc              / EMAIL_CC               The CC address for the notification email.
//
// Requires Node 18+ (uses the global fetch API) and an authenticated Azure CLI session (provided by
// the pipeline's AzureCLI@2 task using the opensource-api-connection service connection).

"use strict";

const { execFileSync } = require("child_process");

// The aad resource (application id) for the opensource portal REST API.
const OPENSOURCE_API_RESOURCE = "api://2efaf292-00a0-426c-ba7d-f5d2b214b8fc";
const PEOPLE_LINKS_URL = "https://repos.opensource.microsoft.com/api/people/links";
const DEFAULT_EMAIL_CC = "azsdkapex@microsoft.com";

function getArg(name) {
  const flag = `--${name}`;
  const idx = process.argv.indexOf(flag);
  if (idx !== -1 && idx + 1 < process.argv.length) {
    return process.argv[idx + 1];
  }
  return undefined;
}

function resolveInput(argName, envName, fallback = "") {
  const fromArg = getArg(argName);
  if (fromArg !== undefined && fromArg !== "") {
    return fromArg;
  }
  const fromEnv = process.env[envName];
  if (fromEnv !== undefined && fromEnv !== "") {
    return fromEnv;
  }
  return fallback;
}

function warn(message) {
  console.warn(`##[warning]${message}`);
}

async function getPullRequestAuthor(repository, prNumber, ghToken) {
  const [owner, repo] = repository.split("/");
  if (!owner || !repo) {
    throw new Error(`Repository '${repository}' is not in 'owner/name' format.`);
  }
  const url = `https://api.github.com/repos/${owner}/${repo}/pulls/${prNumber}`;
  const headers = {
    Accept: "application/vnd.github+json",
    "User-Agent": "azsdk-notify-release-plan-owner",
    "X-GitHub-Api-Version": "2022-11-28",
  };
  if (ghToken) {
    headers.Authorization = `Bearer ${ghToken}`;
  }
  const resp = await fetch(url, { headers });
  if (!resp.ok) {
    throw new Error(`GitHub API returned ${resp.status} ${resp.statusText}`);
  }
  const pr = await resp.json();
  return pr && pr.user && pr.user.login ? pr.user.login : "";
}

function getOpensourceApiToken() {
  // Reuse the az CLI session authenticated by the pipeline's AzureCLI@2 task.
  const output = execFileSync(
    "az",
    [
      "account",
      "get-access-token",
      "--resource",
      OPENSOURCE_API_RESOURCE,
      "--query",
      "accessToken",
      "--output",
      "tsv",
    ],
    { encoding: "utf8" }
  );
  return output.trim();
}

async function resolveMicrosoftEmail(githubUser, token) {
  const resp = await fetch(PEOPLE_LINKS_URL, {
    headers: {
      "Content-Type": "application/json",
      "api-version": "2019-10-01",
      Authorization: `Bearer ${token}`,
    },
  });
  if (!resp.ok) {
    throw new Error(`Opensource portal API returned ${resp.status} ${resp.statusText}`);
  }
  const links = await resp.json();
  if (!Array.isArray(links)) {
    throw new Error("Unexpected response shape from opensource portal API.");
  }
  const match = links.find(
    (link) =>
      link && link.github && link.github.login && link.github.login.toLowerCase() === githubUser.toLowerCase()
  );
  if (!match || !match.aad) {
    return { email: "", displayName: "" };
  }
  return {
    email: match.aad.userPrincipalName || match.aad.emailAddress || "",
    displayName: match.aad.preferredName || "",
  };
}

function buildEmailBody(displayName, releasePlanLink, specPullRequestUrl) {
  const greetingName = displayName || "there";
  const planLinkHtml = releasePlanLink
    ? `<a href="${releasePlanLink}">${releasePlanLink}</a>`
    : "the Release Planner tool";
  const prLine = specPullRequestUrl
    ? `<li><strong>Spec pull request:</strong> <a href="${specPullRequestUrl}">${specPullRequestUrl}</a></li>`
    : "";
  return `<html>
<body>
    <p>Hello ${greetingName},</p>
    <p>Our automation has created a release plan for your recently merged API specification pull request.
    A release plan tracks the work required to generate and publish the Azure SDKs for your service.</p>
    <ul>
        <li><strong>Release plan:</strong> ${planLinkHtml}</li>
        ${prLine}
    </ul>
    <p><strong>Next steps:</strong></p>
    <ol>
        <li>Open the release plan and review the auto-populated details (service, product, target release date).</li>
        <li>Confirm the SDK languages and target release month are correct, and update them if needed.</li>
        <li>Follow the release plan to generate, review, and publish the SDKs for each language.</li>
    </ol>
    <p>For guidance on completing a release plan, see the
    <a href="https://eng.ms/docs/products/azure-developer-experience/plan/release-plan">Azure SDK release plan documentation</a>.</p>
    <p>Best regards,</p>
    <p>Azure SDK PM Team</p>
</body>
</html>`;
}

async function sendEmail(emailerUri, to, cc, subject, body) {
  const resp = await fetch(emailerUri, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ EmailTo: to, CC: cc, Subject: subject, Body: body }),
  });
  if (!resp.ok) {
    throw new Error(`Emailer service returned ${resp.status} ${resp.statusText}`);
  }
}

async function main() {
  const emailerUri = resolveInput("emailer-uri", "AZURE_SDK_EMAIL_URI");
  if (!emailerUri) {
    console.log("Emailer URI was not provided. Skipping release plan owner notification.");
    return;
  }

  const repository = resolveInput("repository", "BUILD_REPOSITORY_NAME");
  const prNumber = resolveInput("pr-number", "PR_NUMBER");
  const emailCc = resolveInput("email-cc", "EMAIL_CC", DEFAULT_EMAIL_CC);
  const releasePlanLink = resolveInput("release-plan-link", "RELEASE_PLAN_LINK");
  const specPullRequestUrl = resolveInput("spec-pull-request-url", "SPEC_PULL_REQUEST_URL");
  let githubUser = resolveInput("github-user", "NOTIFY_GITHUB_USER");

  if (!githubUser) {
    if (!prNumber || Number(prNumber) <= 0 || !repository) {
      warn(
        "GitHub user was not provided and pr-number/repository are missing. Cannot resolve the pull request author. Skipping notification."
      );
      return;
    }
    try {
      githubUser = await getPullRequestAuthor(repository, prNumber, process.env.GH_TOKEN);
    } catch (err) {
      warn(`Failed to resolve the pull request author. ${err.message}. Skipping notification.`);
      return;
    }
  }

  if (!githubUser) {
    warn("Could not determine the pull request author's GitHub login. Skipping notification.");
    return;
  }

  let token;
  try {
    token = getOpensourceApiToken();
  } catch (err) {
    warn(
      `Failed to acquire an access token for the opensource portal API. ${err.message}. Skipping notification.`
    );
    return;
  }
  if (!token) {
    warn("Access token for the opensource portal API was empty. Skipping notification.");
    return;
  }

  let email = "";
  let displayName = "";
  try {
    ({ email, displayName } = await resolveMicrosoftEmail(githubUser, token));
  } catch (err) {
    warn(
      `Failed to resolve Microsoft email for GitHub user '${githubUser}'. ${err.message}. Skipping notification.`
    );
    return;
  }

  if (!email) {
    warn(`No Microsoft identity/email found for GitHub user '${githubUser}'. Skipping notification.`);
    return;
  }

  const subject = "Action Required: Review the release plan for your Azure API specification";
  const body = buildEmailBody(displayName, releasePlanLink, specPullRequestUrl);

  try {
    console.log(`Sending email - To: ${email}, CC: ${emailCc}, Subject: ${subject}`);
    await sendEmail(emailerUri, email, emailCc, subject, body);
    console.log(`Successfully sent release plan notification to ${email}`);
  } catch (err) {
    warn(`Failed to send email to ${email}. ${err.message}`);
  }
}

main()
  .catch((err) => {
    warn(`Unexpected error while sending release plan owner notification: ${(err && err.message) || err}`);
  })
  .finally(() => {
    // Never fail the pipeline because of notification issues.
    process.exit(0);
  });
