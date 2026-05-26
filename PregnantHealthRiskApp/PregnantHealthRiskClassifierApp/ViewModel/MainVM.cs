using CommunityToolkit.Mvvm.ComponentModel;

namespace Model;

public partial class MainVM : ObservableObject
{
    [ObservableProperty]
    private Pregnant _editingPregnant;
}
