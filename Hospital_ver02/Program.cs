using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ver02
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    {
        private List<Patient> _patients;
        private Creator _creator;

        public Hospital()
        {
            _patients = new List<Patient>();
            _creator = new Creator();
        }

        public void Work()
        {
            int _patientsNumber = 20;
            bool isOpen = true;
            string department = " Инфекционное отделение ";
            string line = DrawLine(department.Length);
            string userInput = "4";
            string action = "сортировки";

            CreateNewPatient(_patientsNumber);

            while (isOpen)
            {
                Console.WriteLine($"{line}");
                Console.WriteLine($"{department}");
                Console.WriteLine($"{line}");
                IEnumerable<Patient> filtered = _patients;

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine($"Сортировка по фамилии\n");
                        filtered = _patients.OrderBy(patient => patient.Name);
                        break;
                    case "2":
                        Console.WriteLine($"Сортировка по возрасту");
                        filtered = _patients.OrderBy(patient => patient.Age);
                        break;
                    case "3":
                        Console.WriteLine($"Cортировка по диагнозу");
                        Console.Write($"Введите заболевание: ");
                        string diagnosis = Console.ReadLine();
                        filtered = _patients.Where(patient => patient.Diagnosis == diagnosis);
                        break;
                    case "4":
                        Console.WriteLine($"Сортировка по очередности поступления");
                        filtered = _patients;
                        break;
                    case "9":
                        isOpen = false;
                        action = "выхода";
                        break;
                }

                foreach (var patient in filtered)
                {
                    patient.ShowInfo();
                }

                Console.WriteLine($"\n1 - сортировать по фамилии\n2 - сортировать по возрасту\n3 - выбрать по диагнозу\n4 - сортировать по очередности поступления\n9 - выход");
                userInput = Console.ReadLine();

                Console.WriteLine($"нажмите ENTER для начала {action}");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewPatient(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _patients.Add(_creator.CreateNewPatient());
            }
        }

        private string DrawLine(int length)
        {
            string line = "-";
            string bigLine = "";
            for (int i = 0; i < length; i++)
            {
                bigLine += line;
            }
            return bigLine;
        }
    }

    class Creator
    {
        private static Random _rand;

        static Creator()
        {
            _rand = new Random();
        }

        public Creator()
        {

        }

        public Patient CreateNewPatient()
        {
            return new Patient(CreateNewSurname(), CreateNewAge(), CreateNewDiagnosis());
        }

        private string CreateNewSurname()
        {
            string firstPart = "Ли Си";
            string lastPart = "Цин";
            int caseCount = 9;

            switch (_rand.Next(caseCount))
            {
                case 0:
                    firstPart = "Петр";
                    break;
                case 1:
                    firstPart = "Иван";
                    break;
                case 2:
                    firstPart = "Вас";
                    break;
                case 3:
                    firstPart = "Том";
                    break;
                case 4:
                    firstPart = "Бот";
                    break;
                case 5:
                    firstPart = "Кот";
                    break;
                case 6:
                    firstPart = "Крот";
                    break;
                case 7:
                    firstPart = "Толст";
                    break;
                case 8:
                    firstPart = "Ковал";
                    break;
            }

            switch (_rand.Next(caseCount))
            {
                case 0:
                    lastPart = "ов";
                    break;
                case 1:
                    lastPart = "ин";
                    break;
                case 2:
                    lastPart = "енко";
                    break;
                case 3:
                    lastPart = "иков";
                    break;
                case 4:
                    lastPart = "ченко";
                    break;
                case 5:
                    lastPart = "ищев";
                    break;
                case 6:
                    lastPart = "овец";
                    break;
                case 7:
                    lastPart = "ич";
                    break;
                case 8:
                    lastPart = "уков";
                    break;
            }

            return firstPart + lastPart;
        }

        private int CreateNewAge()
        {
            int minAge = 18;
            int maxAge = 100;

            int age = _rand.Next(minAge, maxAge);
            return age;
        }

        private string CreateNewDiagnosis()
        {
            int caseCount = 5;
            string diagnosis = "без диагноза";

            switch (_rand.Next(caseCount))
            {
                case 0:
                    diagnosis = "чума";
                    break;
                case 1:
                    diagnosis = "холера";
                    break;
                case 2:
                    diagnosis = "сибирская язва";
                    break;
                case 3:
                    diagnosis = "пневмония";
                    break;
                case 4:
                    diagnosis = "менингит";
                    break;
            }

            return diagnosis;
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Diagnosis { get; private set; }

        public Patient(string name, int age, string diagnosis)
        {
            Name = name;
            Age = age;
            Diagnosis = diagnosis;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, {Age} лет, {Diagnosis}");
        }
    }
}
