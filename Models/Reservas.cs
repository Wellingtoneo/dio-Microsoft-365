namespace C_.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes {get; set;}
        List<Suite> Suites { get; set; }

        public Reserva() 
        { 
            CadastrarSuites();
            Hospedes = new List<Pessoa>();
        }

        public int DisponibilidadeDeSuite(int numeroDaSuite)
        {
             bool resultado = true;
            do 
            {
               if(Suites[numeroDaSuite].Reservada){
                 try
                 {
                    Console.Clear();
                    Console.WriteLine("Suíte indisponivel no momento.\nEscolha uma opção disponível por favor!");
                    Console.WriteLine(SuitesDisponiveis());
                    numeroDaSuite = Convert.ToInt32(Console.ReadLine())-1;
                 }
                 catch (System.Exception)
                 {
                    throw new ArgumentException("Sistema encerrado! Entrada Inválida!");
                 }
               } else {
                resultado = false;
               }
            }while(resultado);
            return numeroDaSuite;
        }
        public bool VerificarCapacidade(int numeroDaSuite, int numeroAcompanhantes)
        {
            bool validacao = false;
            if(numeroAcompanhantes > Suites[numeroDaSuite].Capacidade)
            {
               string msg = "Total de Pessoas excede a capacidade da suíte!" +
               $"\n Digite uma quantidade menor ou igual {Suites[numeroDaSuite].Capacidade}";
               Console.WriteLine(msg);
               validacao = true;
            }
            return validacao;
        }
        
        public string CadastrarHospedes(string hospedes, int numeroDaSuite, int numeroAcompanhantes, int dias)
        {
            Hospedes.Add(new Pessoa(hospedes, numeroAcompanhantes, numeroDaSuite));
            Suites[numeroDaSuite].Reservada = true;
            Suites[numeroDaSuite].Dias = dias;
            string sucesso = "Reserva concluida com sucesso!"+
            $"\n{Suites[numeroDaSuite].Reservada} reservada por {dias} dia(s)."+
            $"\n{CalcularValorDiaria(numeroDaSuite)}\n" +
            "\nDigite uma das opções:" +
            "\n9 - Voltar ao menu principal.";
            return sucesso;
        }

        void CadastrarSuites()
        {
           Suites = new List<Suite>();
           Suite grandeMuralhaDaChina = new Suite(tipoSuite: "Grande Muralha da China (China)", capacidade: 3, valordiaria: 300, Id: 0);
           Suite petra =  new Suite(tipoSuite: "Petra (Jordânia)", capacidade: 4, valordiaria: 450, Id: 1);
           Suite cristoRedentor = new Suite(tipoSuite: "Cristo Redentor (Brasil)", capacidade: 6, valordiaria: 850, Id: 2);
           Suite machuPicchu = new Suite(tipoSuite: "Machu Picchu (Peru)", capacidade: 3, valordiaria: 550, Id: 3);
           Suite chichenItza = new Suite(tipoSuite: "Chichén Itzá (México)", capacidade: 4, valordiaria: 350, Id: 4);
           Suite coliseuDeRoma = new Suite(tipoSuite: "Coliseu de Roma (Itália)", capacidade: 5, valordiaria: 450, Id: 5);
           Suite tajMahal = new Suite(tipoSuite: "Taj Mahal (Índia)", capacidade: 4, valordiaria: 650, Id: 6);
           Suites.Add(grandeMuralhaDaChina);
           Suites.Add(petra);
           Suites.Add(cristoRedentor);
           Suites.Add(machuPicchu);
           Suites.Add(chichenItza);
           Suites.Add(coliseuDeRoma);
           Suites.Add(tajMahal);
        }

        public int ObterIndexPessoa(string nome)
        {
            int index = Hospedes.FindIndex(r => r.Nome.Equals(nome));
            return index;
        }
        public string CancelarReserva(int numeroDoHospede)
        {
            int opcao;
            string retorno = "";
            
            do
            {   
                Console.WriteLine("Digite 9 para confirmar.\nDigite 0 para retornar!");
                opcao = Convert.ToInt32(Console.ReadLine());    
                if ( opcao == 9 )
                {
                    Suites[Hospedes[numeroDoHospede].NumeroDaSuite].Reservada = false;
                    Suites[Hospedes[numeroDoHospede].NumeroDaSuite].Dias = 0;
                    Hospedes.RemoveAt(numeroDoHospede);
                    retorno = "Reserva cancelada com Sucesso!";
                }
                else 
                {
                    retorno = "Reserva continua ativa!\nObrigado Pela preferência!";
                }

            } while(opcao != 0 && opcao != 9);

            return retorno;
        }
        public bool VerificarIndexHospede(int numberHospede)
        {
            try
            {
                return Hospedes[numberHospede].Nome != "";
            }
            catch (System.Exception)
            {
                
                return false;
            }
        }   
        public void ObterStatusSuites() 
        {
            string statusSuite = ""; int number;
            if(Hospedes.Count == 0){
                statusSuite = "Não Existe suítes com reservas no momento.";
                Console.WriteLine($"{statusSuite}\nDigite qualquer número para continuar!");
                Convert.ToInt32(Console.ReadLine());
            } else {
                foreach(Pessoa pessoa in Hospedes)
                {
                    statusSuite += $"{ObterIndexPessoa(pessoa.Nome)} - {pessoa.Nome}, durante {Suites[pessoa.NumeroDaSuite].Dias} dia(s) " +
                    $"hospedado na suite {Suites[pessoa.NumeroDaSuite].TipoSuite}\nValores:\n" +
                    $"{CalcularValorDiaria(pessoa.NumeroDaSuite)}\n\n";
                }
                Console.WriteLine(statusSuite + "Digite o número da reserva para cancelar.\n9 - Para retorna.");
                number = Convert.ToInt32(Console.ReadLine());
                
                if (number != 9)
                {
                    if(VerificarIndexHospede(number) )
                    {
                        Console.WriteLine(CancelarReserva(number));
                    }
                }

            }
        }
        public string SuitesDisponiveis(){
            string suitesDisponiveis = "";
            foreach(Suite suite in Suites)
            {
                if(!suite.Reservada){
                    if (suitesDisponiveis == ""){
                        suitesDisponiveis += "Para reservar uma suite basta digitar o numero correspondente a mesma!\n";
                    }
                    string nomeSuite = suite.TipoSuite.ToString();
                    suitesDisponiveis += $"\n{suite.ID + 1} - {suite.TipoSuite} valor da diaria R$ {suite.ValorDiaria} capacidade de {suite.Capacidade} pessoas.";
                } 
            }
            if (suitesDisponiveis == "")
            {
                suitesDisponiveis = "No momento não temos suites disponiveis!\nHotel As 7 Maravilhas do Mundo agradece a preferência!";
            }
            return suitesDisponiveis += "\n\n9 - Voltar ao menu principal.";
        }
        public string CalcularValorDiaria(int opcao)
        {
            decimal valor =  Suites[opcao].Dias * Suites[opcao].ValorDiaria;
            string msg = "Valor a ser pago:\n";
            if ( Suites[opcao].Dias >= 10)
            {
                msg += "Obá!! você ganhou um desconto 10% - R$ " + valor * 0.90M;
            }
            else 
            {
                msg += "R$ " + valor;
            }

            return msg;
        }
    }
}