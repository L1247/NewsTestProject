using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace NewsTestProject
{
    public class NewsTests
    {
    #region Private Variables

        private News   _news;
        private string _shortContent = "abcdefghij";
        private string longContent   = "abcdefghijklm";

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public void Setup()
        {
            _news = new News();
        }

    #endregion

    #region Test Methods

        [Test]
        public void Should_Return_Short_Content()
        {
            ShouldResponseShortContent(_shortContent , longContent , 10);
        }

        [Test]
        public void Should_Return_Short_Content_When_Length_Is_Big()
        {
            ShouldResponseShortContent(_shortContent , _shortContent , 100);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Should_Return_Null_Exception_When_Content_Is_Null_Or_EmptyString(string content)
        {
            var nullException = Assert.Throws<NullReferenceException>(() => { GetShortContent(content , 10); });
            ShouldResponseExceptionMessage(nullException , "內容為空或者Null");
        }

        [Test]
        public void Should_Return_Argument_Exception_When_Length_Is_Negative_Number()
        {
            var argumentException = Assert.Throws<ArgumentException>(() => GetShortContent(_shortContent , -1));
            ShouldResponseExceptionMessage(argumentException , "長度為負數");
        }

        [Test]
        public void Should_Return_Argument_Exception_When_Length_Is_Zero()
        {
            var argumentException = Assert.Throws<ArgumentException>(() => GetShortContent(_shortContent , 0) , "長度為1");
            ShouldResponseExceptionMessage(argumentException , "長度為0");
        }

    #endregion

    #region Private Methods

        private string GetShortContent(string content , int length)
        {
            if (string.IsNullOrEmpty(content))
                throw new NullReferenceException("內容為空或者Null");
            else if (length < 0)
                throw new ArgumentException("長度為負數");
            else if (length == 0)
                throw new ArgumentException("長度為0");
            var shortContent = _news.GetShortContent(content , length);
            return shortContent;
        }

        private static void ShouldResponseExceptionMessage(Exception exception , string expectedMessage)
        {
            Assert.AreEqual(expectedMessage , exception.Message);
        }

        private void ShouldResponseShortContent(string shortContent , string content , int length)
        {
            Assert.AreEqual(shortContent , GetShortContent(content , length));
        }

    #endregion
    }
}