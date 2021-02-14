using System;

namespace NewsTestProject
{
    public class News
    {
    #region Public Methods

        public string GetShortContent(string content , int length)
        {
            var subLength = Math.Min(content.Length , length);
            return content.Substring(0 , subLength);
        }

    #endregion
    }
}