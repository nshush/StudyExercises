using System;
class MainClass
{
    public static void Main(string[] args)
    {
        (string Name, string LastName, string Login, int LoginLength, bool HasPet, string[] favcolors, double Age) User;

        for (int k = 0; k < 3; k++)
        {

            Console.WriteLine("������� ���");
            User.Name = Console.ReadLine();

            Console.WriteLine("������� �������");

            User.LastName = Console.ReadLine();

            Console.WriteLine("������� �����");

            User.Login = Console.ReadLine();

            User.LoginLength = User.Login.Length;

            Console.WriteLine("���� �� � ��� ��������? �� ��� ���");

            var result = Console.ReadLine();

            if (result == "��")
            {
                User.HasPet = true;
            }
            else
            {
                User.HasPet = false;
            }

            Console.WriteLine("������� ������� ������������");

            User.Age = double.Parse(Console.ReadLine());

            User.favcolors = new string[3];
            Console.WriteLine("������� ��� ������� ����� ������������");

            for (int i = 0; i < User.favcolors.Length; i++)
            {
                User.favcolors[i] = Console.ReadLine();
            }
        }
    }
}