namespace SistemaAgendamentoEventos.Views;

public partial class EventoAgendado : ContentPage
{
	public EventoAgendado()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}