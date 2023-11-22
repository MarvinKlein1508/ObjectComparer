using ObjectComparer.Tests.Models;

namespace ObjectComparer.Tests.Tests
{
    [TestFixture]
    public class TestList
    {
        private const string TYPE_NAME = "List<object>";
        [Test]
        public void Test_Default()
        {
            // Arrange
            TestModel model = new TestModel();
            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Act
            copy.TestList.Add("Hello World");


            // Assert
            TestContext.Out.WriteLine("copy {0}:", TYPE_NAME);
            foreach (var item in copy.TestList)
            {
                TestContext.Out.WriteLine("{0}", item);
            }
            TestContext.Out.WriteLine("model {0}:", TYPE_NAME);
            foreach (var item in model.TestList)
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
            copy.TestListNullable = new List<object>
            {
                "Hello World"
            };
            
            // Assert
            TestContext.Out.WriteLine("copy {0}:", TYPE_NAME);
            foreach (var item in copy.TestListNullable)
            {
                TestContext.Out.WriteLine("{0}", item ?? "<NULL>");
            }
            TestContext.Out.WriteLine("model {0}:", TYPE_NAME);
            if (model.TestListNullable is null)
            {
                TestContext.Out.WriteLine("List is <NULL>");
            }
            else
            {
                foreach (var item in model.TestListNullable)
                {
                    TestContext.Out.WriteLine("{0}", item ?? "<NULL>");
                }
            }
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
                TestListNullable = new List<object>()
            };

            var copy = model.DeepCopyByExpressionTree();

            Assert.IsFalse(model.HasBeenModified(copy), "Invalid copy of object");

            // Act
            copy.TestListNullable = new List<object>
            {
                "Hello World"
            };

            // Assert
            TestContext.Out.WriteLine("copy {0}:", TYPE_NAME);
            if (copy.TestListNullable is null)
            {
                TestContext.Out.WriteLine("COPY List is <NULL>");
            }
            else
            {
                foreach (var item in copy.TestListNullable)
                {
                    TestContext.Out.WriteLine("{0}", item ?? "<NULL>");
                }
            }
            TestContext.Out.WriteLine("model {0}:", TYPE_NAME);
            if (model.TestListNullable is null)
            {
                TestContext.Out.WriteLine("MODEL List is <NULL>");
            }
            else
            {
                foreach (var item in model.TestListNullable)
                {
                    TestContext.Out.WriteLine("{0}", item ?? "<NULL>");
                }
            }
            TestContext.Out.WriteLine("copy HasBeenModified: {0}", model.HasBeenModified(copy));
            Assert.IsTrue(model.HasBeenModified(copy), "Change {0}? has not been registered", TYPE_NAME);
        }
    }
}