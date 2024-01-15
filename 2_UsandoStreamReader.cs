using ByteBankIO;
using System.Text;

partial class Program
{
    static void UsandoStramReader(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";

        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            //var linha = leitor.ReadLine();

            //var texto =  leitor.ReadToEnd();

            //int numero = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var ContaCorrente = ConverterStringParaContaCorrente(linha);

                var msg = $"{ContaCorrente.Titular.Nome} : Conta numero: {ContaCorrente.Numero},  ag: {ContaCorrente.Agencia},  saldo: R$ {ContaCorrente.Saldo}";
                Console.WriteLine(msg);
            }


        }
        Console.ReadLine();
    }
    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        // 375,4644,2483.13,Jonatan

        var campos = linha.Split(',');

        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ',');
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia);
        var numerocomInt = int.Parse(numero);
        var saldoComDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaComInt, numerocomInt);
        resultado.Depositar(saldoComDouble);
        resultado.Titular = titular;

        return resultado;
    }
}