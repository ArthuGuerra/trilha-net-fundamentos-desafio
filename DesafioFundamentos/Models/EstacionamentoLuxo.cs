using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using DesafioFundamentos.Exceptions;

namespace RepositorioEstacionamentoOF.Models
{
    public class EstacionamentoLuxo : Estacionamento
    {
       
        public int ValetParking { get; set; } = 20;
        public List<EstacionamentoLuxo> ListLuxo { get; set; } = new List<EstacionamentoLuxo>();
        public override double PriceSeg { get; set; } = 0.005555556;
        public override double PriceFixed { get; set;  } = 50;
        public override double PriceTotal { get; set;  } = 0;
        public override DateTime Time { get; set; } 

        public EstacionamentoLuxo(){}
        public EstacionamentoLuxo(DateTime time)
        {
            Time = time;
        }
       
        public EstacionamentoLuxo(string placa, int valetParking) 
        {
            Placa = placa;
            ValetParking = valetParking;   
        }


        public sealed override void AddVehicle()
        {
            try
            {
            Console.WriteLine($"O senhor(a) deseja um manobrista ( s / n )? Possui uma taxa de R${ValetParking.ToString("F2",CultureInfo.InvariantCulture)} ");

            string valet = Console.ReadLine();

            if(valet == "s" || valet == "S")
            {
                Console.WriteLine($"Taxa de R${ValetParking.ToString("F2",CultureInfo.InvariantCulture)} aplicada ao preço final");

                Console.WriteLine("Informe a placa do veículo nesse formato: xxxx-0000");
                Console.WriteLine("\n");
                Placa = Console.ReadLine();
                EstacionamentoLuxo car = ListLuxo.Find(x => x.Placa == Placa);

                if(car == null)
                {              
                EstacionamentoLuxo carro1 = new EstacionamentoLuxo(Placa,ValetParking);
                Console.WriteLine("Veiculo adicionado com sucesso");
                ListLuxo.Add(carro1);
                Console.WriteLine("Aperte qualquer botão");
                Console.ReadLine();
                Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Veiculo com placa: {Placa.ToUpper()} já está estacionado. Verifique se digitou corretamente!");
                    Console.WriteLine("Aperte qualquer botão");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Informe a placa do veículo nesse formato: xxxx-0000");
                Console.WriteLine("\n");
                Placa = Console.ReadLine();
                EstacionamentoLuxo car = ListLuxo.Find(x => x.Placa == Placa);

                if(car == null)
                {                
                    Console.WriteLine("Veiculo adicionado com sucesso");
                    Console.WriteLine("Sem manobrista. Prossiga e escolha uma vaga. ");
                    EstacionamentoLuxo carro2 = new EstacionamentoLuxo(Placa,0);
                    ListLuxo.Add(carro2);
                    Console.WriteLine("Aperte qualquer botão");
                    Console.ReadLine();
                    Console.Clear();;              
                }
                else
                {
                    Console.WriteLine($"Veiculo com placa: {Placa.ToUpper()} já está estacionado. Verifique se digitou corretamente!");
                    Console.WriteLine("Aperte qualquer botão");
                    Console.ReadLine();
                    Console.Clear();
                }
            }    
            } catch(FormatException f)
            {
                Console.WriteLine(f.Message);
            }  catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }


        public sealed override void RemoveVehicle(DateTime moment) // DAteTime.Now
        {
            try
            {
            Console.WriteLine("Informe a placa do veículo nesse formato: xxxx-0000");
            Console.WriteLine("\n");
            string plate = Console.ReadLine();
            
            EstacionamentoLuxo carro = ListLuxo.Find(x => x.Placa == plate); // verifica se ja existe a placa estacionada


            if(carro != null)
            { 
                TimeSpan seg = moment.Subtract(Time);
                int valet = carro.ValetParking;
                PriceTotal = (seg.Seconds * PriceSeg ) + PriceFixed + valet;
                Console.WriteLine($"Preço por segundo: R${PriceSeg.ToString("F9",CultureInfo.InvariantCulture)}/1s \n Segundos: {seg.Seconds}\n Preço Fixo: R${PriceFixed.ToString("F2",CultureInfo.InvariantCulture)}\n ValetParking: R${carro.ValetParking}\n Total: R${PriceTotal.ToString("F3",CultureInfo.InvariantCulture)} ");
                ListLuxo.Remove(carro);
                PriceTotal = 0;
                Console.WriteLine("Aperte qualquer botão");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"Veiculo com placa: {plate.ToUpper()} não está estacionado. Verifique se digitou corretamente!");
                Console.WriteLine("Aperte qualquer botão");
                Console.ReadLine();
                Console.Clear();
            }
            } catch (FormatException f)
            {
                Console.WriteLine(f.Message);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public override void ListVehicle()
        {
            foreach( EstacionamentoLuxo carroLuxo in ListLuxo)
            {
                Console.WriteLine($"Placa - {carroLuxo.Placa.ToUpper()}");
            }
            Console.WriteLine("Aperte qualquer botão");
            Console.ReadLine();
            Console.Clear();
        }
    }
}