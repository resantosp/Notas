using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNotasDaTurma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PROXIMO PASSO: deixar o usuário escolher de antemão a quantidade de vezes que vai colocar nome e nota do aluno
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string userChoice = getUserChoice();

            while (userChoice != "4")
            {
                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"\tALUNO: {a.Nome}\tNOTA: {a.Nota}");
                            }
                        }

                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nAlunos;
                        EConceito conceitoGeral;

                        if (mediaGeral < 3)
                        {
                            conceitoGeral = EConceito.E;
                        }
                        else if (mediaGeral < 5)
                        {
                            conceitoGeral = EConceito.D;
                        }
                        else if (mediaGeral < 7)
                        {
                            conceitoGeral = EConceito.C;
                        }
                        else if (mediaGeral < 9)
                        {
                            conceitoGeral = EConceito.B;
                        }
                        else
                        {
                            conceitoGeral = EConceito.A;
                        }

                        Console.WriteLine("\t===================");
                        Console.WriteLine($"\tMÉDIA GERAL:\t{mediaGeral}");
                        Console.WriteLine($"\tCONCEITO GERAL:\t{conceitoGeral}");
                        Console.WriteLine("\t===================");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userChoice = getUserChoice();

            }

            Console.ReadLine();

        }

        private static string getUserChoice()
        {
            Console.WriteLine("\nInforme a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("4 - Sair\n");

            Console.Write("SUA OPÇÃO: ");
            string userChoice = Console.ReadLine();
            Console.WriteLine();
            return userChoice;
        }
    }
}
