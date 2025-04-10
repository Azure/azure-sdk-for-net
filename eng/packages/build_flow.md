Build
  Initialize the repo
    Setting package versions
    Update to typespec latest
    Make package.json and package-lock.json available to test legs
  Build the packages
    Just run npm pack
    if we know we're possing to the dev feed, we need to provide overrides.json for tsp-client use
Test
  Initialize the repo
    Use package.json and package-lock.json from build leg
  Test the packages
    npm test

Publish
  publish to npmjs or dev feed
  Update emitter-package.jsons
      tsp-client
          which emitter
          whick emitter-package.json
          overrides?

Uptake and Regenerate