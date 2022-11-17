##
# This illustrates how to run stryker from the test project context
# https://stryker-mutator.io/docs/stryker-net/operating-modes/#test-project-context
##

cd "./src/ShoppingCart.Tests";
dotnet-stryker --config-file "stryker-config.json" --open-report;
cd "../../";
