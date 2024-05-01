using RepositorioEstacionamentoOF.Models;
using System.Globalization;


/// colocar as exceções


Console.WriteLine($"Olá, bem vindo ao estacionamento Guerra ");
Console.WriteLine($"Temos 2 opções de estacionamento, comum e o de luxo. ");
Console.WriteLine("");
Console.WriteLine($"O de luxo é de R$20.00 reais por hora e R$50.00 fixo.  ");
Console.WriteLine("");
Console.WriteLine($"O comum é de R$5.00 reais por hora e R$10.00 fixo.  ");
Console.WriteLine("");
Console.WriteLine($"Escolha em qual quer deixar seu carro. \n  1 - Luxo \n  2 - Comum");
int est = int.Parse(Console.ReadLine());

// colocar uma exceção aqui
int n = 0;
switch(est)
{

    case 1:
    Console.WriteLine($"Bem vindo ao estacionamento de luxo.");
    EstacionamentoLuxo luxo = new EstacionamentoLuxo(DateTime.Now);
        
    while( n != 4)
    {
        Console.WriteLine("Escolha uma das opções:");
        Console.WriteLine("1 - Add veiculo");
        Console.WriteLine("2 - Listar veiculos");
        Console.WriteLine("3 - Remover veiculo");
        Console.WriteLine("4 - Sair");
        n = int.Parse(Console.ReadLine());


        switch(n)
        {
            case 1:
            
            luxo.AddVehicle();
            break;

            case 2:
            luxo.ListVehicle();
            break;
            
            case 3:
            luxo.RemoveVehicle(DateTime.Now);
            break;

        }
       
    }
    
    break;
    
   case 2:
    Console.WriteLine($"Bem vindo ao estacionamento comum");
    Estacionamento comum = new EstacionamentoComum();

    int i = 0;
    
    while(i != 4)
    {
        Console.WriteLine($"Escolha alguma das oções: ");
        Console.WriteLine($"1 - Add veículo");
        Console.WriteLine($"2 - Listar veículos");
        Console.WriteLine($"3 - Remover veículo");
        Console.WriteLine($"4 - sair");
        i = int.Parse(Console.ReadLine());


        switch(i)
        {
            case 1:
            comum.AddVehicle();
            break;

            case 2: 
            comum.ListVehicle();
            break;

            case 3:
            comum.RemoveVehicle(DateTime.Now);
            break;
            
        }
    }
    break;
}


