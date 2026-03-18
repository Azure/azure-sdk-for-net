.PHONY: all restore build test lint format clean pack generate-responses-contracts samples npm-install dev

REPO_ROOT := $(shell git rev-parse --show-toplevel 2>/dev/null || echo "../..")

all: restore build test lint

## Open the monorepo in VS Code.  When prompted, select "Reopen in Container"
## and choose the "AgentServer" configuration.  If the devcontainer CLI is
## installed (`npm i -g @devcontainers/cli`), the container starts directly.
dev:
	@if command -v devcontainer >/dev/null 2>&1; then \
		echo "🐳 Starting AgentServer dev container..."; \
		devcontainer open \
			--workspace-folder "$(REPO_ROOT)" \
			--config "$(REPO_ROOT)/.devcontainer/agentserver/devcontainer.json"; \
	elif command -v code >/dev/null 2>&1; then \
		echo "📂 Opening monorepo in VS Code..."; \
		echo "   → Select 'Reopen in Container' then choose 'AgentServer'."; \
		code "$(REPO_ROOT)"; \
	else \
		echo "❌ Neither 'devcontainer' CLI nor 'code' CLI found on PATH."; \
		echo "   Install one of:"; \
		echo "     npm i -g @devcontainers/cli"; \
		echo "     https://code.visualstudio.com/docs/editor/command-line"; \
		exit 1; \
	fi

restore:
	dotnet restore

build: restore
	dotnet build --no-restore

test: build
	dotnet test --no-build --verbosity normal

lint:
	dotnet format --verify-no-changes Azure.AI.AgentServer.Responses/src/Azure.AI.AgentServer.Responses.csproj
	dotnet format --verify-no-changes Azure.AI.AgentServer.Responses/tests/Azure.AI.AgentServer.Responses.Tests.csproj
	dotnet format --verify-no-changes Azure.AI.AgentServer.Responses.Contracts/src/Azure.AI.AgentServer.Responses.Contracts.csproj

format:
	dotnet format Azure.AI.AgentServer.Responses/src/Azure.AI.AgentServer.Responses.csproj
	dotnet format Azure.AI.AgentServer.Responses/tests/Azure.AI.AgentServer.Responses.Tests.csproj
	dotnet format Azure.AI.AgentServer.Responses.Contracts/src/Azure.AI.AgentServer.Responses.Contracts.csproj

samples:
	dotnet build Azure.AI.AgentServer.Responses/samples/Samples.slnx

clean:
	dotnet clean
	find . -type d \( -name bin -o -name obj \) -exec rm -rf {} + 2>/dev/null || true

pack: build
	dotnet pack --no-build --configuration Debug -o ./nupkg

TSP_DIR := Azure.AI.AgentServer.Responses.Contracts/src/TypeSpec
TSP_OUT := $(TSP_DIR)/tsp-output

node_modules: package.json
	npm install
	@touch node_modules

npm-install: node_modules

OPENAPI_YAML := $(TSP_OUT)/openapi.virtual-public-preview.yaml
VALIDATORS_DIR := Azure.AI.AgentServer.Responses.Contracts/src/Generated/Validators
OVERLAY_YAML := Azure.AI.AgentServer.Responses.Contracts/src/Validation/validation-overlay.yaml
VALIDATORS_NAMESPACE := Azure.AI.AgentServer.Responses

generate-responses-contracts: node_modules
	@echo "🔄 Syncing upstream TypeSpec sources..."
	npx tsp-client sync --output-dir Azure.AI.AgentServer.Responses.Contracts/src/TypeSpec
	@echo "✅ TypeSpec sources synced"
	@echo "🔨 Compiling TypeSpec → C# models + OpenAPI spec..."
	cd $(TSP_DIR) && npx tsp compile .
	@echo "📦 Copying generated models into Contracts..."
	rm -rf Azure.AI.AgentServer.Responses.Contracts/src/Generated/Models Azure.AI.AgentServer.Responses.Contracts/src/Generated/Internal
	mkdir -p Azure.AI.AgentServer.Responses.Contracts/src/Generated/Models Azure.AI.AgentServer.Responses.Contracts/src/Generated/Internal
	cp -r $(TSP_OUT)/src/Generated/Models/* Azure.AI.AgentServer.Responses.Contracts/src/Generated/Models/ 2>/dev/null || true
	cp $(TSP_OUT)/src/Generated/AzureAIAgentServerResponsesModelFactory.cs Azure.AI.AgentServer.Responses.Contracts/src/Generated/Models/ 2>/dev/null || true
	cp $(TSP_OUT)/src/Generated/Internal/*.cs Azure.AI.AgentServer.Responses.Contracts/src/Generated/Internal/ 2>/dev/null || true
	@echo "✅ Models generated"
	@echo "🔨 Generating C# validators from OpenAPI spec..."
	python3 scripts/generate-validators.py \
		--input $(OPENAPI_YAML) \
		--output $(VALIDATORS_DIR) \
		--overlay $(OVERLAY_YAML) \
		--namespace $(VALIDATORS_NAMESPACE) \
		--root-schemas OpenAI.Response
	@echo "✅ Validators generated"
	@echo "🧹 Cleaning up tsp-output intermediates..."
	@# Preserve only the hand-written Custom stubs; remove everything else.
	find $(TSP_OUT) -mindepth 1 -maxdepth 1 ! -name src -exec rm -rf {} +
	find $(TSP_OUT)/src -mindepth 1 -maxdepth 1 ! -name Custom -exec rm -rf {} +
	@echo "✅ All Responses contracts generated and cleaned up."
