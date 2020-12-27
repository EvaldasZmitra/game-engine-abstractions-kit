using Xunit;

namespace GeaKit.Etc {
    public class MinMaxValueTest {
        [Theory]
        [InlineData(0, 0, 1f, 0)]
        [InlineData(-1f, 0, 1f, 0)]
        [InlineData(2f, 0, 1f, 1)]
        public void GetInitializedCorrectly(
            float value,
            float min,
            float max,
            float expectedValue
        ) {
            var minMaxValue = new Resource<float>(value, min, max);
            Assert.Equal(expectedValue, minMaxValue.Value);
        }
    }
}