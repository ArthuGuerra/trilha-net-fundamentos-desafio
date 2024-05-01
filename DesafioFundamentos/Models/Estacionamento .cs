using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorioEstacionamentoOF.Models
{
    public abstract class Estacionamento  
    {
        public List<string> Plate { get; set; } = new List<string>();
        public virtual string Placa { get; set; }
        public virtual double PriceSeg { get; set; } = 0.001388889;
        public virtual double PriceFixed { get; set; } = 10;
        public virtual double PriceTotal { get; set; }
        //public int Hour { get; set; }
        public virtual DateTime Time { get; set; } 


        public Estacionamento(){}

        public virtual void AddVehicle()
        {
            Console.WriteLine("Informe a placa do veículo nesse formato: xxxx-0000");
            Console.WriteLine("\n");
            Placa = Console.ReadLine();
            bool placaVeiculo = Plate.Any(x => x.ToUpper() == Placa.ToUpper());  // verifica se ja existe a placa estacionada

            if(placaVeiculo)
            {
                Console.WriteLine($"Veiculo com placa: {Placa.ToUpper()} já está estacionado. Verifique se digitou corretamente!");
                Console.WriteLine("Aperte qualquer botão");
                Console.ReadLine();
                Console.Clear();
               
            }
            else
            {
                Plate.Add(Placa);
                Console.WriteLine("Veiculo adicionado com sucesso");
                Console.WriteLine("Aperte qualquer botão");
                Console.ReadLine();
                Console.Clear();
               
            }
            
        }

         public virtual void ListVehicle()
         {
            foreach (string plate in Plate)
            {
                Console.WriteLine($" Placa - {plate.ToUpper()}");
            }
            Console.WriteLine("Aperte qualquer botão");
            Console.ReadLine();
            Console.Clear();
         }


         public abstract void RemoveVehicle(DateTime moment);

        
    }
}