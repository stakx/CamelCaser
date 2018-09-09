using Xunit;

namespace CamelCaser
{
    public class NameTests
    {
        [Fact]
        public void Empty_string_is_returned_unchanged()
        {
            Assert.Equal("", "".ToLowerCamelCase());
        }
    }
}
