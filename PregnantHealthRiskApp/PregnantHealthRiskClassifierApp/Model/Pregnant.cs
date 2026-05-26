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
    private double _bS= 0.0;

    [ObservableProperty]
    private double _bodyTemp = 0.0;

    [ObservableProperty]
    private uint _heartRate = 0;
}
