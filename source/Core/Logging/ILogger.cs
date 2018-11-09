using System;

namespace Solution.Core.Logging
{
    public interface ILogger
    {
        void Error(Exception exception);
    }
}
