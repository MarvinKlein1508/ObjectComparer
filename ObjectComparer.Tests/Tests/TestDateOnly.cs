using ObjectComparer.Tests.Models;

namespace ObjectComparer.Tests.Tests
{
    [TestFixture]
    public class TestDateOnly
    {
        private const string TYPE_NAME = "DateOnly";
        [Test]
        public void Test_Default()
        {
            // Arrange
            TestModel model = new TestModel();
            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Act
            copy.TestDateOnly = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
            
            
            // Assert
            TestContext.Out.WriteLine("copy {0}: {1}", TYPE_NAME, copy.TestDateOnly);
            TestContext.Out.WriteLine("model {0}: {1}", TYPE_NAME, model.TestDateOnly);
            TestContext.Out.WriteLine("copy HasBeenModified: {0}", model.HasBeenModified(copy));
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
            copy.TestDateOnlyNullable = DateOnly.FromDateTime(DateTime.Today);

            // Assert
            TestContext.Out.WriteLine("copy {0}?: {1}", TYPE_NAME, copy.TestDateOnlyNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("model {0}?: {1}", TYPE_NAME, model.TestDateOnlyNullable?.ToString() ?? "<NULL>");
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
                TestDateOnlyNullable = DateOnly.FromDateTime(DateTime.Today)
            };

            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Act
            copy.TestDateOnlyNullable = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

            // Assert
            TestContext.Out.WriteLine("copy {0}?: {1}", TYPE_NAME, copy.TestDateOnlyNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("model {0}?: {1}", TYPE_NAME, model.TestDateOnlyNullable?.ToString() ?? "<NULL>");
            TestContext.Out.WriteLine("copy HasBeenModified: {0}", model.HasBeenModified(copy));
            Assert.IsTrue(model.HasBeenModified(copy), "Change {0}? has not been registered", TYPE_NAME);
        }
    }
}