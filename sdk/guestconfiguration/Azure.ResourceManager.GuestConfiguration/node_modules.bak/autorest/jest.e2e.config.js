// @ts-check

const defaultConfig = require("./jest.config");

const config = {
  ...defaultConfig,
  setupFilesAfterEnv: ["<rootDir>/test/setup-jest-e2e.ts"],
  testMatch: ["<rootDir>/test/**/*.e2e.ts"],
};

module.exports = config;
