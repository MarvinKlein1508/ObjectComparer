using ObjectComparer.Tests.Models;

namespace ObjectComparer.Tests.Tests
{
    [TestFixture]
    public class TestShort
    {
        private const string TYPE_NAME = "short";
        [Test]
        public void Test_Default()
        {
            // Arrange
            TestModel model = new TestModel();
            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Check non nullable string
            copy.TestShort = 1;
            TestContext.Out.WriteLine("copy {0}: {1}", TYPE_NAME, copy.TestShort);
            TestContext.Out.WriteLine("model {0}: {1}", TYPE_NAME, model.TestShort);
            TestContext.Out.WriteLine("copy HasBeenModified: {0}", model.HasBeenModified(copy));
            Assert.IsTrue(model.HasBeenModified(copy), "Change {0} has not been registered", TYPE_NAME);

            

            // Assert
            Assert.Pass("Testing {0} has been successful", TYPE_NAME);
        }

        [Test]
        public void Test_NullableStartsWithNull()
        {
            // Check nullable string
            // Arrange
            TestModel model = new TestModel();
            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Act
            copy.TestShortNullable = 1;

            // Assert
            TestContext.Out.WriteLine("copy {0}?: {1}", TYPE_NAME, copy.TestShortNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("model {0}?: {1}", TYPE_NAME, model.TestShortNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("copy HasBeenModified: {0}", model.HasBeenModified(copy));
            Assert.IsTrue(model.HasBeenModified(copy), "Change {0}? has not been registered", TYPE_NAME);

            Assert.Pass("Testing {0}? has been successful", TYPE_NAME);
        }
        [Test]
        public void Test_NullableStartsNotWithNull()
        {
            // Check nullable string
            // Arrange
            TestModel model = new TestModel
            {
                TestShortNullable = 1
            };

            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Act
            copy.TestShortNullable = 2;

            // Assert
            TestContext.Out.WriteLine("copy {0}?: {1}", TYPE_NAME, copy.TestShortNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("model {0}?: {1}", TYPE_NAME, model.TestShortNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("copy HasBeenModified: {0}", model.HasBeenModified(copy));
            Assert.IsTrue(model.HasBeenModified(copy), "Change {0}? has not been registered", TYPE_NAME);

            Assert.Pass("Testing {0}? has been successful", TYPE_NAME);
        }
    }
}