using System;

namespace TamagochiGame___Delegates
{
    class NullException : Exception
    {
        public NullException() : base("Name could not be null or space") { }
    }
}
