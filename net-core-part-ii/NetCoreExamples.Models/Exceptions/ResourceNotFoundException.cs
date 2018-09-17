using System;

namespace NetCoreExamples.Models.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base("The resource was not found.") {}
        public ResourceNotFoundException(string message) : base(message) {}
        public ResourceNotFoundException(string message, Exception inner) : base(message, inner) {}
    }
}