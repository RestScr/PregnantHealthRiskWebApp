
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using Model.Enums;
using Newtonsoft.Json;

namespace Model.Services.API;

/// <summary>
/// Класс оператора с API.
/// </summary>
public static class APIOperator
{
    /// <summary>
    /// Ссылка на API.
    /// </summary>
    private static string Url { get; set; } = "http://127.0.0.1:8000/";

    private static string PostDataUrl = "predict";
    private static string GetPredictionUrl = "predict/{{taskId}}?task_id={0}";

    /// <summary>
    /// Ссылка на объект для работы с API.
    /// </summary>
    private static HttpClient Client { get; set; } = new HttpClient();

    /// <summary>
    /// Задать ссылку на API.
    /// </summary>
    public static void Connect()
    {
        if (Client.BaseAddress == null)
            Client.BaseAddress = new Uri(Url);
    }

    /// <summary>
    /// Получить предсказание модели.
    /// </summary>
    /// <param name="pregnant"> Объект беременной женщины. </param>
    /// <returns></returns>
    public static async Task<HealthRisk> GetPrediction(Pregnant pregnant)
    {
        if (Client.BaseAddress == null)
            return HealthRisk.Unknown;

        Dataset dataset = new Dataset(pregnant);

        // POST-Запрос
        HttpResponseMessage postResponse = await Client.PostAsJsonAsync(
            PostDataUrl, 
            dataset
        );

        Debug.WriteLine(JsonConvert.SerializeObject(dataset));

        // GET-Запрос, ожидаем получить результат.
        if (!postResponse.IsSuccessStatusCode)
        {
            Debug.WriteLine("An error when posting request has occured.");
            Debug.WriteLine(postResponse.Content.ToString()); 
            return HealthRisk.Unknown;
        }

        Debug.WriteLine("Successful post.");

        PostGetContentResponse? postResponseData = await postResponse.Content.ReadFromJsonAsync<PostGetContentResponse>();

        if (postResponseData == null)
        {
            Debug.WriteLine("Null response");
            return HealthRisk.Unknown;
        }
        string taskId = postResponseData.Content.ToString();

        HttpResponseMessage getResponse = await Client.GetAsync(String.Format(GetPredictionUrl, taskId));

        while (!getResponse.IsSuccessStatusCode)
        {
            await Task.Delay(1000);
            Debug.WriteLine("Getting Prediction...");
            getResponse = await Client.GetAsync(String.Format(GetPredictionUrl, taskId));
        }

        PostGetContentResponse? getResponseData = await getResponse.Content.ReadFromJsonAsync<PostGetContentResponse>();

        if (getResponseData == null)
        {
            Debug.WriteLine("Null Get response");
            return HealthRisk.Unknown;
        }

        JsonElement element = (JsonElement)getResponseData.Content;
        Debug.WriteLine(element);
        List<double> predictions = new List<double>();

        foreach (JsonElement item in element.EnumerateArray())
        {
            predictions.Add(item.GetDouble());
        }

        return (HealthRisk)((int)predictions.First());
    }
}
