using ByteBankIO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var enderecoDoArquivo = "contas.txt";
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var numeroDeBytesLidos = -1;

                var buffer = new byte[1024];

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024); // buffer, offset (indica a posição onde irá começar a escrita), índice limte de escrita.
                    Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }

                fluxoDoArquivo.Close();
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void EscreverBuffer(byte[] buffer, int byteslidos)
    {
        var utf8 = new UTF8Encoding();
        var texto = utf8.GetString(buffer,0, byteslidos);

        
        Console.Write(texto);

        /*
        foreach (var meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(" ");
        }
        */
    }
}