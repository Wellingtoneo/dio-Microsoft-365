namespace C_.Models
{
    
    public class Suite
    {
        public Suite(string tipoSuite, int capacidade, decimal valordiaria, int Id)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valordiaria;
            Reservada = false;
            ID = Id;
            Dias = 0;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; } 
        public decimal ValorDiaria { get; set; }
        public bool Reservada {get; set;}
        public int ID {get; set;}
        public int Dias {get; set;}

    }
}