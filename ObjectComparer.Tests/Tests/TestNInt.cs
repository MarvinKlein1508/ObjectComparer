using ObjectComparer.Tests.Models;
using System.Reflection;

namespace ObjectComparer.Tests.Tests
{
    [TestFixture]
    public class TestNInt
    {
        private const string TYPE_NAME = "nint";
        [Test]
        public void Test_Default()
        {
            // Arrange
            TestModel model = new TestModel();
            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Check non nullable string
            copy.TestNInt = 1;
            Assert.IsTrue(model.HasBeenModified(copy), "Change {0} has not been registered", TYPE_NAME);
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
            copy.TestNIntNullable = 1;

            // Assert
            TestContext.Out.WriteLine("copy {0}?: {1}", TYPE_NAME, copy.TestNIntNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("model {0}?: {1}", TYPE_NAME, model.TestNIntNullable?.ToString() ?? "<NULL>");
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
                TestNIntNullable = 1
            };

            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Act
            copy.TestNIntNullable = 2;

            // Assert
            TestContext.Out.WriteLine("copy {0}?: {1}", TYPE_NAME, copy.TestNIntNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("model {0}?: {1}", TYPE_NAME, model.TestNIntNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("copy HasBeenModified: {0}", model.HasBeenModified(copy));
            Assert.IsTrue(model.HasBeenModified(copy), "Change {0}? has not been registered", TYPE_NAME);
        }
    }
}