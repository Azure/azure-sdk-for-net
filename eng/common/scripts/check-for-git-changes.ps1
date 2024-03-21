echo "git add -A"
git add -A

echo "git diff --name-status --cached --exit-code"
git diff --name-status --cached --exit-code

if ($LastExitCode -ne 0) {
  echo "##vso[task.setvariable variable=HasChanges]$true"
  echo "Changes detected so setting HasChanges=true"
}
else {
  echo "##vso[task.setvariable variable=HasChanges]$false"
  echo "No changes so skipping code push"
}
