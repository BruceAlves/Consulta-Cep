using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consulta_Cep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite seu cep");
            string cep = Console.ReadLine();

            // buscando resposta no site do via cep
            HttpClient cliente = new HttpClient();
            var respostaJson = cliente.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;

            //convertendo resposta em string de json
            string jsonString = respostaJson.Content.ReadAsStringAsync().Result;

            //convertendo o string de json em objeto
            RespostaVIaCep resposta = JsonConvert.DeserializeObject<RespostaVIaCep>(jsonString);

            Console.WriteLine(resposta.Estado);
            Console.WriteLine(resposta.Cidade);
            Console.WriteLine(resposta.Bairro);
            Console.WriteLine(resposta.Rua);

            Console.ReadKey();
        }
    }
}
