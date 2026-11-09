// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
"use strict";
const assert = require("node:assert/strict");
const fs = require("node:fs");
const path = require("node:path");
const { test } = require("node:test");
const vm = require("node:vm");

const workflows = path.resolve(__dirname, "../../../workflows");
const guard = fs.readFileSync(path.join(workflows, "shared/sdk-build-repair-checkout-guard.md"), "utf8");
const script = guard.match(/node <<'NODE'\r?\n([\s\S]*?)^          NODE\r?$/m)[1]
  .replace(/^          /gm, "").replace(/\r\n/g, "\n");
const original = '(context.payload.action === "opened" || context.payload.action === "synchronize") &&';

function patch(source) {
  let written;
  vm.runInNewContext(script, {
    process: { env: { RUNNER_TEMP: "/test" } },
    require(name) {
      if (name === "node:fs") {
        return {
          readFileSync: () => source,
          writeFileSync: (_, content) => { written = content; },
        };
      }
      assert.equal(name, "node:path");
      return path;
    },
  });
  return written;
}

// Keep the surrounding pinned upstream trust checks to exercise the patched condition.
const helper = `
  function trusted(context, pullRequest, allowedBots) {
    const actor = context.actor;
    const senderType = context.payload.sender?.type;
    const parseAllowedBots = () => allowedBots;
    const isAllowedBot = (login, bots) => bots.includes(login);
    if (
      (context.eventName === "pull_request" || context.eventName === "pull_request_target") &&
      ${original}
      senderType === "Bot" &&
      context.payload.sender?.login === actor &&
      context.payload.repository !== undefined &&
      context.payload.repository !== null &&
      Number.isSafeInteger(context.payload.repository.id) &&
      context.payload.repository.id > 0 &&
      pullRequest?.head?.repo?.id === context.payload.repository.id &&
      pullRequest?.base?.repo?.id === context.payload.repository.id
    ) {
      return true;
    }
    return false;
  }
  trusted;
`;
const trusted = vm.runInNewContext(patch(helper));

function fixture() {
  return {
    context: {
      eventName: "pull_request",
      actor: "azure-sdk-automation[bot]",
      payload: {
        action: "labeled",
        label: { name: "auto-sdk-build-fix" },
        sender: { type: "Bot", login: "azure-sdk-automation[bot]" },
        repository: { id: 2928944 },
      },
    },
    pr: { head: { repo: { id: 2928944 } }, base: { repo: { id: 2928944 } } },
    bots: ["azure-sdk", "azure-sdk-automation[bot]"],
  };
}

test("original helper rejects the release bot label event; patched helper accepts it", () => {
  const { context, pr, bots } = fixture();
  assert.equal(vm.runInNewContext(helper)(context, pr, bots), false);
  assert.equal(trusted(context, pr, bots), true);
});

for (const [name, change] of [
  ["unlisted bot", f => { f.bots = []; }],
  ["human sender", f => { f.context.payload.sender.type = "User"; }],
  ["different sender", f => { f.context.payload.sender.login = "another[bot]"; }],
  ["fork head", f => { f.pr.head.repo.id = 42; }],
  ["different base repository", f => { f.pr.base.repo.id = 42; }],
  ["missing head repository", f => { f.pr.head.repo = null; }],
  ["missing runtime repository", f => { delete f.context.payload.repository; }],
  ["invalid repository ID", f => { f.context.payload.repository.id = 0; }],
  ["wrong label", f => { f.context.payload.label.name = "unrelated"; }],
  ["missing label", f => { delete f.context.payload.label; }],
  ["unlabeled action", f => { f.context.payload.action = "unlabeled"; }],
  ["pull_request_target label event", f => { f.context.eventName = "pull_request_target"; }],
  ["manual comment", f => { f.context.eventName = "issue_comment"; }],
  ["manual dispatch", f => { f.context.eventName = "workflow_dispatch"; }],
]) {
  test(`repair-label exception rejects ${name}`, () => {
    const f = fixture();
    change(f);
    assert.equal(trusted(f.context, f.pr, f.bots), false);
  });
}

for (const action of ["opened", "synchronize"]) {
  test(`existing ${action} behavior is unchanged`, () => {
    const { context, pr } = fixture();
    context.payload.action = action;
    assert.equal(trusted(context, pr, []), true);
    pr.head.repo.id = 42;
    assert.equal(trusted(context, pr, []), false);
  });
}

test("workaround fails closed when upstream condition changes or appears more than once", () => {
  for (const source of ["unexpected helper", helper + helper, patch(helper)]) {
    assert.throws(() => patch(source), /Unexpected gh-aw checkout helper/);
  }
});

test("pinned upstream helper reproduces the failure and preserves permission checks", {
  skip: !process.env.GH_AW_CHECKOUT_HELPER,
}, async () => {
  const upstream = fs.readFileSync(process.env.GH_AW_CHECKOUT_HELPER, "utf8");
  function load(source, f, permission = "none") {
    return vm.runInNewContext(source + "\nassertTrustedCheckoutRuntime;", {
      module: { exports: {} },
      context: { ...f.context, repo: { owner: "Azure", repo: "azure-sdk-for-net" } },
      process: { env: {} },
      core: { info() {} },
      github: { rest: { repos: {
        getCollaboratorPermissionLevel: async () => ({ data: { permission } }),
      } } },
      require: () => ({
        parseAllowedBots: () => f.bots,
        isAllowedBot: (login, bots) => bots.includes(login),
        canonicalizeBotIdentifier: login => login,
        ERR_PERMISSION: "ERR_PERMISSION",
      }),
    });
  }
  const f = fixture();
  await assert.rejects(load(upstream, f)(undefined, f.pr), /ERR_PERMISSION:.*'none' permission/);
  const patched = patch(upstream);
  await load(patched, f)(undefined, f.pr);
  f.pr.head.repo.id = 42;
  await assert.rejects(load(patched, f)(undefined, f.pr), /ERR_PERMISSION/);
  f.pr.head.repo.id = 2928944;
  f.bots = [];
  await assert.rejects(load(patched, f)(undefined, f.pr), /ERR_PERMISSION/);
  f.context.eventName = "issue_comment";
  f.context.actor = "maintainer";
  f.context.payload.sender = { type: "User", login: "maintainer" };
  await load(patched, f, "write")(undefined, f.pr);
  await assert.rejects(load(patched, f, "read")(undefined, f.pr), /ERR_PERMISSION/);
});

test("source imports the guard and compiled agent runs the same script before checkout", () => {
  const source = fs.readFileSync(path.join(workflows, "sdk-build-repair.md"), "utf8");
  assert.match(source, /^  - shared\/sdk-build-repair-checkout-guard.md\r?$/m);
  const lock = fs.readFileSync(path.join(workflows, "sdk-build-repair.lock.yml"), "utf8");
  const agent = lock.match(/^  agent:\r?\n([\s\S]*?)(?=^  [\w-]+:\r?$)/m)[1];
  const step = agent.indexOf("- name: Support allowlisted repair label bots in PR checkout");
  assert.ok(step >= 0);
  assert.ok(step < agent.indexOf("- name: Checkout PR branch"));
  const compiledScript = agent.slice(step).match(/node <<'NODE'\r?\n([\s\S]*?)^          NODE\r?$/m)[1]
    .replace(/^          /gm, "").replace(/\r\n/g, "\n");
  assert.equal(compiledScript, script);
  assert.match(agent, /GH_AW_ALLOWED_BOTS: "azure-sdk,azure-sdk-automation\[bot\]"/);
});
