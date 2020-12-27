using GeaKit.Engine;
using Xunit;

namespace GeaKit.Test {
    public class PrioritySortedActionsTest {
        [Fact]
        public void UpdatesAreExecuted() {
            var engineUpdate = new PrioritySortedActions();
            var executionCount = 0;
            engineUpdate.AddUpdate(
                (dt) => { executionCount++; }
            );

            engineUpdate.ExecuteAll(0);
            engineUpdate.ExecuteAll(0);
            Assert.Equal(2, executionCount);
        }

        [Fact]
        public void UpdatesAreExecutedInOrder() {
            var engineUpdate = new PrioritySortedActions();
            var executionOrder = "";
            engineUpdate.AddUpdate(
                (dt) => { executionOrder += "1"; },
                1
            );
            engineUpdate.AddUpdate(
                (dt) => { executionOrder += "3"; },
                3
            );
            engineUpdate.AddUpdate(
                (dt) => { executionOrder += "2"; },
                2
            );

            engineUpdate.ExecuteAll(0);
            Assert.Equal("123", executionOrder);
        }
    }
}