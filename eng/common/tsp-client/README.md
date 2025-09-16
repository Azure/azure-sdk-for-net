# TypeSpec Client Generator CLI

This directory contains npm package definitions for `@azure-tools/typespec-client-generator-cli` (tsp-client) with pinned versions to ensure reproducible builds across environments and enhance security by preventing supply chain attacks.

## Files

- **`package.json`** - npm package definition with pinned tsp-client version
- **`package-lock.json`** - Lock file ensuring exact dependency versions

## Prerequisites

- **Node.js** (with npm) - Required to install and run tsp-client

## Installation

### Install dependencies

```bash
# Navigate to this directory
cd eng/common/tsp-client

# Install dependencies (recommended for CI/security)
npm i --ignore-scripts --no-audit
```

The `--ignore-scripts --no-audit` flags provide:

- **Security**: Prevents potentially malicious install scripts from running
- **Performance**: Skips vulnerability audit for faster installs
- **Reliability**: Reduces potential points of failure during installation

## Usage

After installation, you can run tsp-client using one of these approaches:

### Option 1: Change directory approach (recommended)

```bash
cd eng/common/tsp-client

# Get help
npm exec --no -- tsp-client --help

# Check version
npm exec --no -- tsp-client version

# Generate client code
npm exec --no -- tsp-client generate --output-dir ./generated

# Initialize a new project
npm exec --no -- tsp-client init --config ./tspconfig.yaml
```

### Option 2: Using environment variable

```bash
# Set repository root (adjust path as needed)
export REPO_ROOT=$(git rev-parse --show-toplevel)

# Get help
npm exec --prefix "${REPO_ROOT}/eng/common/tsp-client" --no -- tsp-client --help

# Check version
npm exec --prefix "${REPO_ROOT}/eng/common/tsp-client" --no -- tsp-client version

# Generate client code
npm exec --prefix "${REPO_ROOT}/eng/common/tsp-client" --no -- tsp-client generate --output-dir ./generated

# Initialize a new project
npm exec --prefix "${REPO_ROOT}/eng/common/tsp-client" --no -- tsp-client init --config ./tspconfig.yaml
```

## CI/CD Best Practices

```bash
cd eng/common/tsp-client
npm i --ignore-scripts --no-audit
npm exec --no -- tsp-client generate --output-dir ./output
```

## Package Management

### Updating tsp-client Version

1. Edit `package.json` to update the version:

   ```json
   {
     "dependencies": {
       "@azure-tools/typespec-client-generator-cli": "0.8.0"
     }
   }
   ```

2. Update the lock file:

   ```bash
   npm install
   ```

3. Commit both `package.json` and `package-lock.json`
