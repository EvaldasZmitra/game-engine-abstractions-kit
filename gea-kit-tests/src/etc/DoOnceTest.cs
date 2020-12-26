using Xunit;

namespace GeaKit.Etc {
    public class DoOnceTest {
        [Fact]
        public void DoesOnce() {
            var count = 0;
            var doOnce = new DoOnce();

            doOnce.Do(() => { count++; });
            Assert.Equal(1, count);

            doOnce.Do(() => { count++; });
            Assert.Equal(1, count);

            doOnce.Reset();
            doOnce.Do(() => { count++; });
            Assert.Equal(2, count);
        }
    }
}