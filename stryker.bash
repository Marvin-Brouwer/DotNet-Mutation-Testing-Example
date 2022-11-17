#!/usr/bin/env bash

##
# This illustrates how to run stryker from the command line, giving you a choice of operating-modes
# https://stryker-mutator.io/docs/stryker-net/operating-modes
##

PS3='Please choose an operating-mode: '
options=("Source project context" "Test project context" "Solution context" "Quit")
select opt in "${options[@]}"
do
    case $opt in
        "Source project context")
            echo "./stryker-source-context.bash";
			. "./stryker-source-context.bash";
			break;
            ;;
        "Test project context")
            echo "./stryker-test-context.bash";
			. "./stryker-test-context.bash";
			break;
            ;;
        "Solution context")
            echo "./stryker-solution-context.bash";
			. "./stryker-solution-context.bash";
			break;
            ;;
        "Quit")
            break
            ;;
        *) echo "invalid option $REPLY";;
    esac
done
