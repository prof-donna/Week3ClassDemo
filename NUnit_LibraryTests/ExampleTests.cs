using Library.BusinessLogic;
using NUnit.Framework;


namespace NUnit_LibraryTests
{
    public class ExampleTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TruncateInputText_SmallerThanLimit_ReturnUnchanged()
        {
            // arrange
            string expectedText = "This is text that won't change.";
            int expectedLength = expectedText.Length;


            // act
            string actualText = ArticleHelper.TruncateInputText(expectedText);

            // assert
            Assert.AreEqual(expectedText, actualText);
            Assert.AreEqual(expectedLength, actualText.Length);
        }


        [TestCase("This is text that won't change.")]
        [TestCase("")]
        [TestCase("One more example")]
        public void TruncateInputText_SmallerThanLimit_ReturnUnchanged(string text)
        {
            // arrange
            string expectedText = text;
            int expectedLength = expectedText.Length;


            // act
            string actualText = ArticleHelper.TruncateInputText(expectedText);

            // assert
            Assert.AreEqual(expectedText, actualText);
            Assert.AreEqual(expectedLength, actualText.Length);
        }


        [Test]
        public void TruncateInputText_LargerThanLimit_ReturnTruncatedWithEllipsis()
        {
            // arrange
            string initialText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vel egestas tellus, sed blandit mauris. Mauris in lacus nec enim convallis suscipit volutpat.";

            string expectedText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vel egestas tellus, sed blandit mauris. Mauris in lacus nec enim convallis suscipit volu...";

            // act
            string actualText = ArticleHelper.TruncateInputText(initialText);

            // assert
            Assert.AreEqual(expectedText, actualText);

        }


        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vel egestas tellus, sed blandit mauris. Mauris in lacus nec enim convallis suscipit volutpat.", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vel egestas tellus, sed blandit mauris. Mauris in lacus nec enim convallis suscipit volu...")]
        [TestCase("Curabitur at elementum dui, finibus gravida est. Sed vel mauris libero. Suspendisse ipsum mauris, egestas finibus ex at, feugiat cursus ex. Sed mi sed.", "Curabitur at elementum dui, finibus gravida est. Sed vel mauris libero. Suspendisse ipsum mauris, egestas finibus ex at, feugiat cursus ex. Sed mi sed...")]
        public void TruncateInputText_LargerThanLimit_ReturnTruncatedWithEllipsis(string initialText, string expectedText)
        {
            // act
            string actualText = ArticleHelper.TruncateInputText(initialText);

            // assert
            Assert.AreEqual(expectedText, actualText);

        }

    }
}