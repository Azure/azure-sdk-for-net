if ! command -v live-server &> /dev/null
then
    echo "Start to install live-server:"
    npm install --global live-server
fi
live-server ./content/index.html