#!/usr/bin/env bash

##
# This illustrates how to run stryker from the solution file
# https://stryker-mutator.io/docs/stryker-net/operating-modes/#solution-file-context
#
# Currently there's an issue with relative solution paths. However, the Stryker team is aware of this.
##

SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )

dotnet stryker --solution "${SCRIPT_DIR}/Stryker example.sln" --open-report;
