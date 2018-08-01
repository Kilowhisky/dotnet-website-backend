#!/bin/sh

# create a temp directory so we have a build location
CURR_DIR=`pwd`
WORK_DIR=`mktemp -d`
cd $WORK_DIR

# checkout and clone our repo for building
git clone -b release https://github.com/Kilowhisky/ember-website.git .

# install everything we need
yarn install

# build everything
ember build --prod

# copy out to the build directory
shopt -u dotglob        # disable globbing for dot files
rm -r $CURR_DIR/../Api/wwwroot/*
cp -r ./dist/* $CURR_DIR/../Api/wwwroot

#cleanup after ourselves
rm -rf $WORK_DIR

# Done!
echo "Done 🙌"
