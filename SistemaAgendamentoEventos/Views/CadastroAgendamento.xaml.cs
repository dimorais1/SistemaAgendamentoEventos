using SistemaAgendamentoEventos.Models;

namespace SistemaAgendamentoEventos.Views;

public partial class CadastroAgendamento : ContentPage
{
    public Evento EventoAtual { get; set; } // Uma propriedade para segurar o evento

    public CadastroAgendamento()
    {
        InitializeComponent();
        EventoAtual = new Evento(); // Cria uma nova inst�ncia do evento
        this.BindingContext = EventoAtual; // Define o BindingContext da p�gina

	}

    private async void Button_Clicked_Avancar(object sender, EventArgs e)
    {
        try 
        {

            if (string.IsNullOrWhiteSpace(EventoAtual.NomeEvento))
            {
                await DisplayAlert("Erro", "Por favor, insira o nome do evento.", "OK");
                return;
            }
            if (EventoAtual.NParticipantes <= 0)
            {
                await DisplayAlert("Erro", "O n�mero de participantes deve ser maior que zero.", "OK");
                return;
            }
            if (EventoAtual.ValorParticipante <= 0)
            {
                await DisplayAlert("Erro", "O Valor do custo dos participantes deve ser maior que zero.", "OK");
                return;
            }

            if (EventoAtual.DataTermino < EventoAtual.DataInicio)
            {
                await DisplayAlert("Erro", "A Data de T�rmino n�o pode ser anterior � Data de In�cio.", "OK");
                return;
            }

            await Navigation.PushAsync(new EventoAgendado()
            {
                BindingContext = EventoAtual
            });


        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", "Ocorreu um erro ao cadastrar o evento: " + ex.Message, "OK");
        }
    }
}