namespace test_skoropechatanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тест на скорость печати ");
            Console.WriteLine("Enter - попробовать еще");
            Console.WriteLine("ESC-выход");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
                
        }
        static public void Write()
        {
            Thread thread = new Thread(new ThreadStart(Program.Timer));
            thread.Start();
            string path = "C:\\Users\\user\\Desktop\\text.txt";
            Random random = new Random();
            int num = random.Next(Convert.ToInt32(Directory.GetFiles(path).Length) - 1);
            string text = File.ReadAllText($"{path}{num}.txt");
            List<char> chars = new();
            foreach (char l in text)
            {
                chars.Add(l);
                Console.Write(l);
            }

            int i = 0;
            int miss = 0;
            while (i < chars.Count)
            {
                Console.SetCursorPosition(0, 1);
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                Console.CursorVisible = false;
                if (key.KeyChar.Equals(chars[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(chars[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    i++;

                }
                else
                {
                    i += 0; //по приколу :)
                    miss++;
                }

            }

        }
        static public void Timer()
        {
            for (int stop = 60; stop >= 0; stop--)
            {
                Thread.Sleep(1000);
                Console.SetCursorPosition(0, 0);
                if (stop >= 10)
                {
                    Console.Write($"00:{stop}");
                }
                else
                {
                    Console.Write($"00:0{stop}");
                }
               
            }
        }
    }
}