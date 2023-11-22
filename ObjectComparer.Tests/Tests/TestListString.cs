using ObjectComparer.Tests.Models;

namespace ObjectComparer.Tests.Tests
{
    [TestFixture]
    public class TestListString
    {
        private const string TYPE_NAME = "List<string>";
        [Test]
        public void Test_Default()
        {
            // Arrange
            TestModel model = new TestModel();
            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Act
            copy.TestListString.Add("Hello World");


            // Assert
            TestContext.Out.WriteLine("copy {0}:", TYPE_NAME);
            foreach (var item in copy.TestListString)
            {
                TestContext.Out.WriteLine("{0}", item);
            }
            TestContext.Out.WriteLine("model {0}:", TYPE_NAME);
            foreach (var item in model.TestListString)
            {
                TestContext.Out.WriteLine("{0}", item);
            }
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
            copy.TestListStringNullable.Add(null);
            copy.TestListStringNullable.Add("Hello World");
            // Assert
            TestContext.Out.WriteLine("copy {0}:", TYPE_NAME);
            foreach (var item in copy.TestListStringNullable)
            {
                TestContext.Out.WriteLine("{0}", item ?? "<NULL>");
            }
            TestContext.Out.WriteLine("model {0}:", TYPE_NAME);
            foreach (var item in model.TestListStringNullable)
            {
                TestContext.Out.WriteLine("{0}", item ?? "<NULL>");
            }
            TestContext.Out.WriteLine("copy HasBeenModified: {0}", model.HasBeenModified(copy));
            Assert.IsTrue(model.HasBeenModified(copy), "Change {0}? has not been registered", TYPE_NAME);
        }
    }
}