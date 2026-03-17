.PHONY: all restore build test lint format clean pack generate-models generate-openapi generate-validators generate-contracts samples npm-install

all: restore build test lint

restore:
	dotnet restore

build: restore
	dotnet build --no-restore

test: build
	dotnet test --no-build --verbosity normal

lint:
	dotnet format --verify-no-changes

format:
	dotnet format

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

generate-models: node_modules
	@echo "🔄 Syncing upstream TypeSpec sources..."
	npx tsp-client sync --output-dir Azure.AI.AgentServer.Responses.Contracts/src/TypeSpec
	@echo "✅ TypeSpec sources synced"
	@echo "🔨 Compiling TypeSpec view → C# models..."
	cd $(TSP_DIR) && npx tsp compile .
	@echo "📦 Copying generated models into Contracts..."
	rm -rf Azure.AI.AgentServer.Responses.Contracts/src/Generated/Models Azure.AI.AgentServer.Responses.Contracts/src/Generated/Internal
	mkdir -p Azure.AI.AgentServer.Responses.Contracts/src/Generated/Models Azure.AI.AgentServer.Responses.Contracts/src/Generated/Internal
	cp -r $(TSP_OUT)/src/Generated/Models/* Azure.AI.AgentServer.Responses.Contracts/src/Generated/Models/ 2>/dev/null || true
	cp $(TSP_OUT)/src/Generated/AzureAIResponsesServerSdkContext.cs Azure.AI.AgentServer.Responses.Contracts/src/Generated/Models/ 2>/dev/null || true
	cp $(TSP_OUT)/src/Generated/AzureAIResponsesServerSdkModelFactory.cs Azure.AI.AgentServer.Responses.Contracts/src/Generated/Models/ 2>/dev/null || true
	cp $(TSP_OUT)/src/Generated/Internal/*.cs Azure.AI.AgentServer.Responses.Contracts/src/Generated/Internal/ 2>/dev/null || true
	@echo "🧹 Cleaning up regenerated artifacts..."
	rm -f $(TSP_OUT)/Azure.AI.AgentServer.Responses.sln
	rm -f $(TSP_OUT)/Configuration.json $(TSP_OUT)/tspCodeModel.json
	rm -f $(TSP_OUT)/src/Azure.AI.AgentServer.Responses.csproj
	rm -rf $(TSP_OUT)/src/Generated
	@echo "✅ Models generated to Azure.AI.AgentServer.Responses.Contracts/src/Generated/Models/"
	@echo "   NOTE: DeleteResponseResult.cs and AzureAIResponsesServerSdkModelFactory.cs are"
	@echo "   excluded from compilation via Contracts.csproj due to codegen bugs."
	@echo "   Custom replacements are in Azure.AI.AgentServer.Responses.Contracts/src/Custom/."

OPENAPI_YAML := $(TSP_OUT)/openapi.virtual-public-preview.yaml
VALIDATORS_DIR := Azure.AI.AgentServer.Responses.Contracts/src/Generated/Validators
OVERLAY_YAML := Azure.AI.AgentServer.Responses.Contracts/src/Validation/validation-overlay.yaml
VALIDATORS_NAMESPACE := Azure.AI.AgentServer.Responses

generate-openapi: node_modules
	@echo "🔨 Compiling TypeSpec → OpenAPI 3.0 YAML..."
	cd $(TSP_DIR) && npx tsp compile .
	@echo "✅ OpenAPI spec generated at $(OPENAPI_YAML)"

generate-validators: generate-openapi
	@echo "🔨 Generating C# validators from OpenAPI spec..."
	python3 scripts/generate-validators.py \
		--input $(OPENAPI_YAML) \
		--output $(VALIDATORS_DIR) \
		--overlay $(OVERLAY_YAML) \
		--namespace $(VALIDATORS_NAMESPACE) \
		--root-schemas OpenAI.Response
	@echo "✅ Validators generated to $(VALIDATORS_DIR)/"

generate-contracts: generate-models generate-validators
	@echo "✅ All generated artifacts are up to date."
