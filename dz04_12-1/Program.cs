namespace dz04_12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

           
               
                File.Create("primes.txt").Dispose();
                File.Create("fibonacci.txt").Dispose();


                CreateNumbers("numbers.txt");

                if (File.Exists("numbers.txt"))
                {
                    Numbers("numbers.txt");
                    Console.WriteLine("збережено у файли primes.txt та fibonacci.txt.");
                }
                else
                {
                    Console.WriteLine("Файл numbers.txt не знайдено.");
                    return;
                }
            }

            static void CreateNumbers(string file)
            {
            Random random = new Random();
            var numbers = Enumerable.Range(0, 1000).Select(_ => random.Next(1, 10000).ToString()).ToArray();
            File.WriteAllLines(file, numbers);
            Console.WriteLine($"Файл {file} створено.");
        }
            static void Numbers(string file)
            {
                var numbers = File.ReadAllLines(file).Select(int.Parse).ToList();
                var primes = numbers.Where(Prime).Select(n => n.ToString()).ToList();
                File.WriteAllLines("primes.txt", primes);
                var fibonacciNumbers = numbers.Where(Fibonacci).Select(n => n.ToString()).ToList();
                File.WriteAllLines("fibonacci.txt", fibonacciNumbers);
            }

            static bool Prime(int number)
            {
                if (number <= 1) return false;
                if (number == 2) return true;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0) return false;
                }
                return true;
            }

            static bool Fibonacci(int number)
            {
                if (number < 0) return false;
                int a = 0, b = 1;
                while (a <= number)
                {
                    if (a == number) return true;
                    int next = a + b;
                    a = b;
                    b = next;
                }
                return false;
            }
        }
    }

