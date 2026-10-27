using System;

namespace MusicLabel.Domain;

/// <summary>
/// Wird ausgelöst, wenn ein angeforderter Interpret in der Datenquelle nicht gefunden wurde.
/// </summary>
[System.Serializable]
public class InterpretNichtGefundenExceptionException : System.Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InterpretNichtGefundenExceptionException"/> class.
    /// </summary>
    public InterpretNichtGefundenExceptionException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InterpretNichtGefundenExceptionException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">Die Fehlermeldung.</param>
    public InterpretNichtGefundenExceptionException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InterpretNichtGefundenExceptionException"/> class with a specified error message and inner exception.
    /// </summary>
    /// <param name="message">Die Fehlermeldung.</param>
    /// <param name="inner">Die innere Exception.</param>
    public InterpretNichtGefundenExceptionException(string message, System.Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InterpretNichtGefundenExceptionException"/> class with serialized data.
    /// </summary>
    /// <param name="info">Die Serialisierungsinformationen.</param>
    /// <param name="context">Der Serialisierungskontext.</param>
    protected InterpretNichtGefundenExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
} 
