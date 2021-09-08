using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;    //declarando que vai ser o primeiro no array
            string opcaousuario = ObterOpcaoUsuario();

            while (opcaousuario.ToUpper() != "X")
            {
                 switch (opcaousuario)
                 {
                    case "1":
                        Console.WriteLine("Informa o nome do aluno:");
                        Aluno aluno = new Aluno();  //cria o objeto aluno e ja seta o nome que apareçe no console
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Infome a nota do aluno:");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++; // para incrementar que o proximo aluno, vai para a proxima pos do array

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                            Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota}");        
                            }
                        }
                        break;
                    case "3":
                       decimal notaTotal = 0;
                       var nrAlunos = 0;

                       for (int i=0; i < alunos.Length; i++) 
                       {
                          if (!string.IsNullOrEmpty(alunos[i].Nome))
                          {
                              notaTotal = notaTotal + alunos[i].Nota;
                              nrAlunos++;
                          }
                       }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4 )
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6 )
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8 )
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else 
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new  ArgumentOutOfRangeException();       
                 }

                opcaousuario = Console.ReadLine();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opçao desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar aluno");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine();
            Console.WriteLine();
            return opcaousuario;
        }
    }
}
