using ByteBankIO;
using System.Text;

partial class Program
{
    static void UsandoStreamReader()
    { 
        var enderecoDoArquivo = "contas.txt";

        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            //var linha = leitor.ReadLine();

            //var texto = leitor.ReadToEnd();

            //var numero = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);

                var mensagem = $"Conta número: {contaCorrente.Numero}," +
                    $" Agência: {contaCorrente.Agencia}," +
                    $" Saldo: {contaCorrente.Saldo}," +
                    $" Titular: {contaCorrente.Titular.Nome}";

                Console.WriteLine(mensagem);
            }
        }
        Console.ReadLine();
    }
    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        // 375 4644 2483.13 Jonatan
        var campos = linha.Split(',');
        var agencia = int.Parse(campos[0]);
        var numero = int.Parse(campos[1]);
        var saldo = double.Parse(campos[2].Replace(".", ","));
        var nomeTitular = campos[3];

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agencia, numero);
        resultado.Depositar(saldo);
        resultado.Titular = titular;

        return resultado;
    }
}
