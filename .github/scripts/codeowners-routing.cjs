const fs = require('fs');

const serviceLabelPattern = /^#[ \t]*ServiceLabel:[ \t]*(.*)$/gm;
const azureSdkOwnersPattern = /^#[ \t]*AzureSdkOwners:[ \t]*(.*)$/gm;
const serviceOwnersPattern = /^#[ \t]*ServiceOwners:[ \t]*(.*)$/gm;

function readMatches(block, pattern) {
  pattern.lastIndex = 0;
  return [...block.matchAll(pattern)];
}

function readOwners(matches) {
  return matches
    .flatMap(match => match[1].trim().split(/\s+/))
    .filter(Boolean)
    .map(value => value.replace(/^@/, '').toLowerCase());
}

function parseCodeownersRouting(content) {
  if (typeof content !== 'string') {
    throw new TypeError('CODEOWNERS content must be a string');
  }

  const entries = [];
  const blocks = content.split(/\r?\n\s*\r?\n/);
  let startLine = 1;

  for (const block of blocks) {
    const serviceLabels = readMatches(block, serviceLabelPattern);
    const azureSdkOwners = readMatches(block, azureSdkOwnersPattern);
    const serviceOwners = readMatches(block, serviceOwnersPattern);

    if (serviceLabels.length === 0) {
      if ((azureSdkOwners.length > 0) || (serviceOwners.length > 0)) {
        throw new Error(`CODEOWNERS block at line ${startLine} contains owner metadata without a ServiceLabel`);
      }
    } else {
      if (serviceLabels.length !== 1) {
        throw new Error(`CODEOWNERS block at line ${startLine} contains multiple ServiceLabel entries`);
      }
      if (azureSdkOwners.length > 1) {
        throw new Error(`CODEOWNERS block at line ${startLine} contains multiple AzureSdkOwners entries`);
      }
      if (serviceOwners.length > 1) {
        throw new Error(`CODEOWNERS block at line ${startLine} contains multiple ServiceOwners entries`);
      }

      const labels = serviceLabels[0][1].split('%').slice(1).map(label => label.trim());
      if ((labels.length === 0) || (labels.some(label => !label))) {
        throw new Error(`CODEOWNERS ServiceLabel entry at line ${startLine} has invalid labels`);
      }

      entries.push({
        line: startLine,
        labels,
        azureSdkOwners: readOwners(azureSdkOwners),
        serviceOwners: readOwners(serviceOwners)
      });
    }

    startLine += block.split(/\r?\n/).length + 1;
  }

  return entries;
}

function findCodeownersRouting(content, finalLabels) {
  if (!(finalLabels instanceof Set)) {
    throw new TypeError('Final labels must be a Set');
  }

  const entries = parseCodeownersRouting(content);
  for (let index = entries.length - 1; index >= 0; index--) {
    const entry = entries[index];
    if (entry.labels.every(label => finalLabels.has(label))) {
      return {
        azureSdk: entry.azureSdkOwners,
        service: entry.serviceOwners
      };
    }
  }

  return null;
}

module.exports = {
  findCodeownersRouting,
  parseCodeownersRouting
};

if (require.main === module) {
  const [command, filePath] = process.argv.slice(2);
  if ((command !== '--validate') || !filePath) {
    console.error('Usage: node codeowners-routing.cjs --validate <CODEOWNERS path>');
    process.exitCode = 2;
  } else {
    try {
      const entries = parseCodeownersRouting(fs.readFileSync(filePath, 'utf8'));
      console.log(`Validated ${entries.length} CODEOWNERS routing blocks`);
    } catch (error) {
      console.error(error.message);
      process.exitCode = 1;
    }
  }
}
