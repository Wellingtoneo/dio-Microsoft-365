using System.Text;
using C_.Models;

Console.OutputEncoding = Encoding.UTF8;
int opcao = 9;
Reserva reserva = new Reserva();
bool fluxo = true;
do
{

    Console.Clear();
    Console.WriteLine("Hotel as 7 Maravilhas do Mundo.\nDigite o número correspondente a opção para acessa-la.\n");
    Console.WriteLine("0 - Encerrar atendimento.");
    Console.WriteLine("1 - Suites disponíveis.");
    Console.WriteLine("2 - Cancelar Reserva.");
    opcao = Convert.ToInt32(Console.ReadLine());

    switch(opcao)
    {
        case 1:
            Console.Clear();
            Console.WriteLine(reserva.SuitesDisponiveis());
            opcao = Convert.ToInt32(Console.ReadLine())-1;

            if(opcao >= 0 && opcao < 8) {
                opcao = reserva.DisponibilidadeDeSuite(opcao);
                Console.WriteLine("Digite seu nome:");
                string nome = Console.ReadLine();
                bool validacao;
                int numeroAcompanhantes;
                int dias;
                do{
                    Console.WriteLine("Digite a quantidade de acompanhates.");
                    numeroAcompanhantes = Convert.ToInt32(Console.ReadLine())+1;
                    validacao = reserva.VerificarCapacidade(opcao, numeroAcompanhantes);
                } while(validacao);
                    
                    Console.WriteLine("Digite a quantidate de dias que pretende ficar no hotel.");
                    dias = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(reserva.CadastrarHospedes(nome, opcao, numeroAcompanhantes, dias));
                    opcao = Convert.ToInt32(Console.ReadLine());

            }
            
            break;

        case 2:
            Console.Clear();
            reserva.ObterStatusSuites();
            break;

        case 0:
            fluxo = false;
            break;
        
        default:
            Console.WriteLine("Opção não é válida!");
            break;

    }

}while(fluxo);
