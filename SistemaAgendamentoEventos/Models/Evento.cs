using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SistemaAgendamentoEventos.Models
{
    public class Evento : INotifyPropertyChanged // A classe Evento agora implementa INotifyPropertyChanged
    {
        // Evento necessário para a interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // Método auxiliar para notificar a UI sobre a mudança de uma propriedade
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string nomeEvento;
        public string NomeEvento
        {
            get => nomeEvento;
            set
            {
                if (nomeEvento != value)
                {
                    nomeEvento = value;
                    OnPropertyChanged(); // Notifica a UI
                }
            }
        }

        private DateTime minDataInicio;
        public DateTime MinDataInicio
        {
            get => minDataInicio;
            set
            {
                if (minDataInicio != value)
                {
                    minDataInicio = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime maxDataInicio;
        public DateTime MaxDataInicio
        {
            get => maxDataInicio;
            set
            {
                if (maxDataInicio != value)
                {
                    maxDataInicio = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime minDataTermino;
        public DateTime MinDataTermino
        {
            get => minDataTermino;
            set
            {
                if (minDataTermino != value)
                {
                    minDataTermino = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime maxDataTermino;
        public DateTime MaxDataTermino
        {
            get => maxDataTermino;
            set
            {
                if (maxDataTermino != value)
                {
                    maxDataTermino = value;
                    OnPropertyChanged();
                }
            }
        }

        // Construtor ou método para inicializar as datas mínimas/máximas
        public Evento()
        {
            
            MinDataInicio = DateTime.Now;
            MaxDataInicio = DateTime.Now.AddMonths(1); 

            MinDataTermino = MinDataInicio.AddDays(1);
            MaxDataTermino = MinDataInicio.AddMonths(6); 
        }

        
        private DateTime dataInicio;
        public DateTime DataInicio
        {
            get => dataInicio;
            set
            {
                if (dataInicio != value)
                {
                    dataInicio = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DuracaoEmDias));

                    
                    MinDataTermino = dataInicio.AddDays(1);
                    MaxDataTermino = dataInicio.AddMonths(6); 
                }
            }
        }

        private DateTime dataTermino;
        public DateTime DataTermino
        {
            get => dataTermino;
            set
            {
                if (dataTermino != value)
                {
                    dataTermino = value;
                    OnPropertyChanged(); // Notifica a UI
                    OnPropertyChanged(nameof(DuracaoEmDias)); // Notifica que DuracaoEmDias pode ter mudado
                }
            }
        }

        private int nParticipantes;
        public int NParticipantes
        {
            get => nParticipantes;
            set
            {
                if (nParticipantes != value)
                {
                    nParticipantes = value;
                    OnPropertyChanged(); // Notifica a UI
                    OnPropertyChanged(nameof(CustoTotal)); // Notifica que CustoTotal pode ter mudado
                }
            }
        }

        private string localEvento;
        public string LocalEvento
        {
            get => localEvento;
            set
            {
                if (localEvento != value)
                {
                    localEvento = value;
                    OnPropertyChanged(); // Notifica a UI
                }
            }
        }

        private double valorParticipante;
        public double ValorParticipante
        {
            get => valorParticipante;
            set
            {
                if (valorParticipante != value)
                {
                    valorParticipante = value;
                    OnPropertyChanged(); // Notifica a UI
                    OnPropertyChanged(nameof(CustoTotal)); // Notifica que CustoTotal pode ter mudado
                }
            }
        }

        // Propriedade para calcular a duração do evento em dias
        public int DuracaoEmDias
        {
            get
            {
                if (DataTermino < DataInicio)
                {
                    return 0;
                }
                TimeSpan duracao = DataTermino - DataInicio;
                return duracao.Days;
            }
        }

        // Propriedade para calcular o custo total do evento
        public double CustoTotal
        {
            get
            {
                return NParticipantes * ValorParticipante;
            }
        }
    }
}