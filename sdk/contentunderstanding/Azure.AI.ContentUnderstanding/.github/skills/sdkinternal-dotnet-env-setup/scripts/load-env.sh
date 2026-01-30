#!/bin/bash
# Load environment variables from .env file
# Usage: source load-env.sh [path/to/.env]

ENV_FILE="${1:-.env}"

# Find .env file
if [[ ! -f "$ENV_FILE" ]]; then
    dir=$(pwd)
    while [[ "$dir" != "/" ]]; do
        if [[ -f "$dir/.env" ]]; then
            ENV_FILE="$dir/.env"
            break
        fi
        dir=$(dirname "$dir")
    done
fi

if [[ ! -f "$ENV_FILE" ]]; then
    echo -e "\033[31mError: .env file not found\033[0m"
    echo "Create a .env file with your Azure credentials"
    return 1 2>/dev/null || exit 1
fi

echo -e "\033[33mLoading environment from: $ENV_FILE\033[0m"

# Load variables
while IFS= read -r line || [[ -n "$line" ]]; do
    # Trim whitespace
    line=$(echo "$line" | xargs)
    
    # Skip comments and empty lines
    [[ "$line" =~ ^# ]] && continue
    [[ -z "$line" ]] && continue
    
    # Parse key=value
    if [[ "$line" =~ ^([^=]+)=(.*)$ ]]; then
        key="${BASH_REMATCH[1]}"
        value="${BASH_REMATCH[2]}"
        
        # Trim whitespace
        key=$(echo "$key" | xargs)
        value=$(echo "$value" | xargs)
        
        # Remove surrounding quotes
        value="${value#[\"\']}"
        value="${value%[\"\']}"
        
        # Export environment variable
        export "$key=$value"
        echo -e "\033[32m  Loaded: $key\033[0m"
    fi
done < "$ENV_FILE"

echo -e "\033[32mEnvironment loaded successfully!\033[0m"
