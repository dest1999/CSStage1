using System;
using System.Collections.Generic;
using System.Text;

namespace lesson6
{
    [Serializable]
    public class MyArrayDataException : Exception
    {
        public string Message;
        public MyArrayDataException(int i, int j)
        {
            Message = $"\n{base.Message}\nВ массиве неверные данные по координатам: {i}, {j}";
        }
        public MyArrayDataException(string message) : base(message) { }
        public MyArrayDataException(string message, Exception inner) : base(message, inner) { }
        protected MyArrayDataException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class MyArraySizeException : Exception
    {
        public string Message;
        public MyArraySizeException()
        {
            Message = base.Message + "\nНеверно указан размер входного массива";
        }
        public MyArraySizeException(string message) : base(message) { }
        public MyArraySizeException(string message, Exception inner) : base(message, inner) { }
        protected MyArraySizeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


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
