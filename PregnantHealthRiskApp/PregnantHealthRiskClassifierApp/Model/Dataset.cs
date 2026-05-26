

namespace Model;

/// <summary>
/// Специальный класс для отправки множества данных в API.
/// </summary>
public class Dataset
{
    /// <summary>
    /// Записи в датасете.
    /// </summary>
    public List<Pregnant> Records { get; set; } = new List<Pregnant>();

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public Dataset() { }

    /// <summary>
    /// Конструктор датасета с массивом.
    /// </summary>
    /// <param name="pregnants"></param>
    public Dataset(Pregnant[] pregnants)
    {
        Records = new List<Pregnant>(pregnants);
    }

    public Dataset(Pregnant pregnant)
    {
        Records.Add(pregnant);
    }

    /// <summary>
    /// Конструктор с готовым списком.
    /// </summary>
    /// <param name="pregnants"></param>
    public Dataset(List<Pregnant> pregnants)
    {
        Records = pregnants;
    }
}
