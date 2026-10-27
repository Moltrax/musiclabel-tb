using System;

namespace MusicLabel.Domain;

[System.Serializable]
public class InterpretNichtGefundenExceptionException : System.Exception
{
    public InterpretNichtGefundenExceptionException() { }
    public InterpretNichtGefundenExceptionException(string message) : base(message) { }
    public InterpretNichtGefundenExceptionException(string message, System.Exception inner) : base(message, inner) { }
    protected InterpretNichtGefundenExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
} 
