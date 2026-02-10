// @ts-check

const defaultConfig = require("./jest.config");

const config = {
  ...defaultConfig,
  testMatch: ["<rootDir>/test/**/*.e2e.ts"],
};

module.exports = config;
