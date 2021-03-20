using System;
using DIO.Animes;

namespace DIO.Animes
{
    class Program
    {
        static AnimeRepositorio repositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                   case "1":
                        ListarAnimes();
                        break;
                   case "2":
                        InserirAnime();
                        break;
                    case "3":
                        AtualizarAnime();
                        break;
                    case "4":
                        ExcluirAnime();
                        break;
                    case "5":
                        VisualizarAnime();
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

        private static void ExcluirAnime()
        {
            Console.WriteLine("Digite o id do anime: ");
            int indiceAnime  = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceAnime);
        }
        
        private static void VisualizarAnime()
        {
            Console.Write("Digite o id da série: ");
            int indiceAnime  = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceAnime);

            Console.WriteLine(serie);
        }
        

        private static void  AtualizarAnime()
        {
            
            Console.Write("Digite o id do anime: ");
            int indiceAnime  = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero  = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da anime: ");
            string entradaDescricao = Console.ReadLine();

            Anime atualizaAnime = new Anime(id: indiceAnime,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceAnime, atualizaAnime);
        }

        private static void InserirAnime()
        {
            Console.WriteLine("Inserir novo anime");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero  = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do anime: ");
            string entradaDescricao = Console.ReadLine();

            Anime novoAnime = new Anime(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novoAnime);
        }

        private static void ListarAnimes()
        {
            Console.WriteLine("Listar animes");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum anime cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluído": ""));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Animes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar animes");
            Console.WriteLine("2- Inserir novo anime");
            Console.WriteLine("3- Atualizar anime");
            Console.WriteLine("4- Excluir anime");
            Console.WriteLine("5- Visualizar anime");
            Console.WriteLine("C- Limpar anime");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}

