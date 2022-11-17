##
# This illustrates how to run stryker from the source project context
# https://stryker-mutator.io/docs/stryker-net/operating-modes/#source-project-context
##

cd "./src/ShoppingCart.Example";
dotnet-stryker --config-file "stryker-config.json" --open-report;
cd "../../";
