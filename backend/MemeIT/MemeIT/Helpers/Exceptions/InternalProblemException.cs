﻿namespace MemeIT.Helpers.Exceptions
{
    public class InternalProblemException : Exception
    {
        public InternalProblemException()
        {
        }

        public InternalProblemException(string? message) : base(message)
        {
        }

        public InternalProblemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
