using CommunityToolkit.Mvvm.ComponentModel;

namespace Model;

public partial class Pregnant : ObservableObject
{
    [ObservableProperty]
    private uint _age = 0;

    [ObservableProperty]
    private uint _systolicBP;

    [ObservableProperty]
    private uint _diastolicBP;

    [ObservableProperty]
    private double _bloodSugar = 0;

    [ObservableProperty]
    private double _bodyTemperature = 0;

    [ObservableProperty]
    private uint _heartRate = 0;

    public int BloodSugarDelta
    {
        get => (int)SystolicBP - (int)DiastolicBP;
    }
}
