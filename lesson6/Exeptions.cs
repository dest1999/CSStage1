using System;
using System.Collections.Generic;
using System.Text;

namespace lesson6
{
    [Serializable]
    public class PersonCreateExeption : Exception
    {
        public PersonCreateExeption()
        {
        }

        public PersonCreateExeption(string message) : base(message)
        {
        }

    }
}
