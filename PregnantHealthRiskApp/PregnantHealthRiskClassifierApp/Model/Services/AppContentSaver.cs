
using Newtonsoft.Json;

namespace Model.Services;

/// <summary>
/// Класс сохранения состояния приложения.
/// </summary>
public static class AppContentSaver
{
    /// <summary>
    /// Путь к файлу сохранения.
    /// </summary>
    private static string Filename { get; set; } = System.Environment.GetFolderPath(
        Environment.SpecialFolder.MyDocuments
        ) + "/HealthRiskApp/state.json";

    /// <summary>
    /// Сохранить состояние.
    /// </summary>
    /// <param name="pregnant"></param>
    public static void SaveData(Pregnant pregnant)
    {
        string json = JsonConvert.SerializeObject(pregnant);

        File.WriteAllText(Filename, json);
    }

    /// <summary>
    /// Загрузить состояние.
    /// </summary>
    /// <returns></returns>
    public static Pregnant LoadData()
    {
        FileInfo fileInfo = new FileInfo(Filename);
        if (!fileInfo.Directory.Exists)
            fileInfo.Directory.Create();

        if (!File.Exists(Filename))
            File.Create(Filename).Close();
        string json = File.ReadAllText(Filename);

        Pregnant? pregnant = JsonConvert.DeserializeObject<Pregnant>(json);

        if (pregnant == null)
        {
            return new Pregnant();
        }

        return pregnant;
    }
}
