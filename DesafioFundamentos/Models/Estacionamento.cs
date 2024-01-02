namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            string placa = "";
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine(); 
            veiculos.Add(placa);
           
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = "";
            placa = Console.ReadLine();


            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {


                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                decimal horas = 0;
                horas = Convert.ToDecimal(Console.ReadLine()); 

                decimal valorTotal = precoInicial + (horas * precoPorHora); 
                veiculos.Remove(placa);


                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {Math.Round(valorTotal,2)} reais");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (string valor in veiculos)
                {
                    Console.WriteLine(valor);
                }
               
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

