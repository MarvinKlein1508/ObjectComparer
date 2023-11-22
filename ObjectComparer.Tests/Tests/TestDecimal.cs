using ObjectComparer.Tests.Models;

namespace ObjectComparer.Tests.Tests
{
    [TestFixture]
    public class TestDecimal
    {
        private const string TYPE_NAME = "decimal";
        [Test]
        public void Test_Default()
        {
            // Arrange
            TestModel model = new TestModel();
            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Check non nullable string
            copy.TestDecimal = 1m;
            TestContext.Out.WriteLine("copy {0}: {1}", TYPE_NAME, copy.TestDecimal);
            TestContext.Out.WriteLine("model {0}: {1}", TYPE_NAME, model.TestDecimal);
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
            copy.TestDecimalNullable = 1;

            // Assert
            TestContext.Out.WriteLine("copy {0}?: {1}", TYPE_NAME, copy.TestDecimalNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("model {0}?: {1}", TYPE_NAME, model.TestDecimalNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("copy HasBeenModified: {0}", model.HasBeenModified(copy));
            Assert.IsTrue(model.HasBeenModified(copy), "Change {0}? has not been registered", TYPE_NAME);
        }
        [Test]
        public void Test_NullableStartsNotWithNull()
        {
            // Check nullable string
            // Arrange
            TestModel model = new TestModel
            {
                TestDecimalNullable = 1
            };

            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Act
            copy.TestDecimalNullable = 2;

            // Assert
            TestContext.Out.WriteLine("copy {0}?: {1}", TYPE_NAME, copy.TestDecimalNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("model {0}?: {1}", TYPE_NAME, model.TestDecimalNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("copy HasBeenModified: {0}", model.HasBeenModified(copy));
            Assert.IsTrue(model.HasBeenModified(copy), "Change {0}? has not been registered", TYPE_NAME);

            Assert.Pass("Testing {0}? has been successful", TYPE_NAME);
        }
    }
}