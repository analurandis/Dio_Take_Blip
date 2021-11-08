using System;
using dio.series.Entity;
using dio.series.Model;

namespace dio.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            Console.WriteLine("Series DIO");
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();


        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar Serie");

            Console.Write("Digite o id da Série ");
            if (int.TryParse(Console.ReadLine(), out int indice))
            {
                Console.WriteLine(repositorio.RetornarId(indice).ToString());

            }
            else
            {
                Console.Write("Id inválido");
            }
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir Serie");

            Console.Write("Digite o id da Série ");
            if (int.TryParse(Console.ReadLine(), out int indice))
            {
                repositorio.Excluir(indice);

            }
            else
            {
                Console.Write("Id inválido");
            }

        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar Serie");

            Console.Write("Digite o id da Série ");
            int indice = int.Parse(Console.ReadLine());
            var serie = pedirDados(indice);
            repositorio.Atualizar(indice, serie);
        }

        private static Serie pedirDados(int? id)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();
            Serie novaSerie;
            if (id != null)
            {
                novaSerie = new Serie(id: (int)id,
                                                       genero: (Genero)entradaGenero,
                                                       titulo: entradaTitulo,
                                                       ano: entradaAno,
                                                       descricao: entradaDescricao);

            }
            else
            {
                novaSerie = new Serie(id: repositorio.ProximoId(),
                                                       genero: (Genero)entradaGenero,
                                                       titulo: entradaTitulo,
                                                       ano: entradaAno,
                                                       descricao: entradaDescricao);

            }


            return novaSerie;
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            var serie = pedirDados(null);
            repositorio.Inserir(serie);

        }

        private static void ListarSeries()
        {
            var lista = repositorio.Listar();
            if (lista.Count == 0)
            {
                Console.WriteLine("Sem series cadastradas");
            }
            else
            {
                foreach (var serie in lista)
                {
                    Console.WriteLine($"Serie {serie.retornarId()} - {serie.retornarTitulo()}  {(serie.retornarExcluido() ? " - Excluido" : "")}");


                }

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
