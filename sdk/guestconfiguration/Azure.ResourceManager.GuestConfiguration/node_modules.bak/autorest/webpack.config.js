// @ts-check

const path = require("path");
const CopyPlugin = require("copy-webpack-plugin");
const baseWebpackConfig = require("../../../common/config/webpack.base.config");
/**
 * @type {import("webpack").Configuration}
 */
module.exports = {
  ...baseWebpackConfig,
  entry: {
    app: "./src/app.ts",
    exports: "./src/exports.ts",
  },
  output: {
    ...baseWebpackConfig.output,
    path: path.resolve(__dirname, "dist"),
    libraryTarget: "commonjs2",
  },
  plugins: [
    // We need to copy the yarn cli.js so @azure-tools/extensions can call the file as it is.(Not bundled in the webpack bundle.)
    new CopyPlugin({
      patterns: [{ from: "node_modules/@azure-tools/extension/dist/yarn/cli.js", to: "yarn/cli.js" }],
    }),

    // We need to copy the default configuration resources files.
    new CopyPlugin({
      patterns: [{ from: "node_modules/@autorest/configuration/resources", to: "resources" }],
    }),

    // We need to copy mappings.wasm so it can be loaded by SourceMapConsumer https://github.com/mozilla/source-map
    new CopyPlugin({
      patterns: [{ from: "node_modules/source-map/lib/mappings.wasm", to: "mappings.wasm" }],
    }),
  ],
  optimization: {
    ...baseWebpackConfig.optimization,
    // Makes sure the different endpoints don't duplicate share common code.
    splitChunks: {
      chunks: "all",
    },
  },
};
