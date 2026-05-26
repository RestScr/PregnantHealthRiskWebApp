namespace Model.Services.API;

public class PostGetContentResponse
{
    /// <summary>
    /// Поле статуса успешности запроса.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Поле сообщения ответа запроса.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Поле контента запроса.
    /// </summary>
    public object Content { get; set; }
}
