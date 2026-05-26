

using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using Model.Enums;
using Model.Services;
using Model.Services.API;

namespace ViewModel;

/// <summary>
/// Класс представления Пользовательского интерфейса.
/// </summary>
public partial class MainVM : ObservableObject
{
    [ObservableProperty]
    private Pregnant _editablePregnant;

    [ObservableProperty]
    private HealthRisk _predictedHealthRisk = HealthRisk.Unknown;

    public MainVM()
    {
        LoadStatusCommand.Execute(null);
    }

    [RelayCommand]
    public async Task GetPrediction(object? parameter)
    {
        APIOperator.Connect();
        Debug.WriteLine("Getting prediction...");
        PredictedHealthRisk = await APIOperator.GetPrediction(EditablePregnant);
    }

    [RelayCommand]
    public void SaveStatus(object? parameter)
    {
        AppContentSaver.SaveData(EditablePregnant);
    }

    [RelayCommand]
    public void LoadStatus(object? parameter)
    {
        EditablePregnant = AppContentSaver.LoadData();
    }
}
