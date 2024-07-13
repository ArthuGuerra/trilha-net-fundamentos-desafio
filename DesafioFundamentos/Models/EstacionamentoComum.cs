using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using DesafioFundamentos.Exceptions;

namespace RepositorioEstacionamentoOF.Models
{
    public class EstacionamentoComum : Estacionamento
    {
        
        public EstacionamentoComum(){}

          public sealed override void RemoveVehicle(DateTime seg)
        {
            try
            {
            Console.WriteLine("Informe a placa do veículo nesse formato: xxxx-0000");
            Console.WriteLine("\n");
            string plate = Console.ReadLine();

            bool placaVeiculo = Plate.Any(x => x.ToUpper() == plate.ToUpper());  // verifica se ja existe a placa estacionada

            if(placaVeiculo)
            {
                // Console.WriteLine("Informe quantas horas o senhor(a) ficou estacionado ");
                // int hour = int.Parse(Console.ReadLine());

                TimeSpan time = seg.Subtract(Time);
                PriceTotal += ( PriceSeg * time.Seconds ) + PriceFixed; 
                Console.WriteLine($"Preço por segundo: R${PriceSeg.ToString("F9",CultureInfo.InvariantCulture)}/s \n Segundos: {time.Seconds}\n Preço fixo: R${PriceFixed.ToString("F2",CultureInfo.InvariantCulture)} \n Total: R${PriceTotal.ToString("F3",CultureInfo.InvariantCulture)}");

                Plate.Remove(plate);
                PriceTotal = 0;
                Console.WriteLine("aperte qualquer botão");
                Console.ReadLine();
                Console.Clear();

               
            }
            else
            {
                Console.WriteLine($"Veiculo com placa: {plate.ToUpper()} não está em nosso EStacionamento. Verifique se digitou corretamente!");
                Console.WriteLine("aperte qualquer botão");
                Console.ReadLine();
                Console.Clear();
            }

            } catch (FormatException e)
            {
                Console.WriteLine("Erro de formato" + e.Message);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}