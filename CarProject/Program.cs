using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarProject
{
    internal class Program
    {

        static string fileName = "carsystem.dat";
        static GenericStore<Car> carStore = new GenericStore<Car>();
        static GenericStore<Model> modelStore = new GenericStore<Model>();
        static GenericStore<Marka> markaStore = new GenericStore<Marka>();


        [Obsolete]
        static void Main(string[] args)
        {
            int markaid;
            int modelid;
            int carid;

            try
            {
                using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    var db = (CarsContext)bf.Deserialize(file);

                    carStore = db.CarsGroup;
                    modelStore = db.ModelsGroup;
                    markaStore = db.MarkasGroup;

                    Car.SetCounter(carStore[carStore.Count - 1].Id);
                    Model.SetCounter(modelStore[modelStore.Count - 1].Id);
                    Marka.SetCounter(markaStore[markaStore.Count - 1].Id);
                }
            }
            catch (Exception)
            {
            }


        l1:

            bool hasCancel = false;



            while (hasCancel != true)
            {

                Console.Clear();
                PrintMenu();

                int selectedMenu = InputTester.ReadInteger("Choose menu: ");

                switch (selectedMenu)
                {
                    case 1:
                        Marka marka = new Marka();


                        marka.Name = InputTester.ReadString("Type Name of marka: ");

                        markaStore.Add(marka);

                        Console.Clear();
                        break;
                  
                    case 2:
                        GetAllMarkas();
                        
                    l3:
                         markaid = InputTester.ReadInteger("Marka Id: ");

                        var foundMarka = markaStore.Find(g => g.Id == markaid);

                        if (foundMarka == null)
                        {
                            Console.WriteLine("Not in the list: ");
                            goto l3;
                        }
                        foundMarka.Name = InputTester.ReadString("Marka name: ");


                        Console.Clear();
                        GetAllMarkas();
                        Console.Write("Please press any key go to menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto l1;

                   

                    case 3:
                        GetAllMarkas();
                    l2:
                        markaid = InputTester.ReadInteger("Marka id: ");

                        if (!markaStore.Exists(x => x.Id == markaid))
                        {
                            Console.WriteLine("Not in the list: ");
                            goto l2;
                        }

                        Marka foundmarka = markaStore.Find(g => g.Id == markaid);

                        markaStore.Remove(foundmarka);
                        GetAllMarkas();
                        Console.ReadKey();
                        break;

                    case 4:

                        Console.Clear();
                        GetAllMarkas(); 
                        Console.Write("Please press any key go to menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto l1;

                      

                    case 5:

                        Console.Clear();
                        Console.WriteLine("Choose from the list: ");
                        GetAllMarkas();
                        markaid = InputTester.ReadInteger("Marka id: ");

                        var chooseMarka= markaStore.Find(g => g.Id == markaid);

                        if (chooseMarka == null)
                        {
                            Console.WriteLine("This Marka does not exists, redirected to marka create");
                            goto case 1;
                        }

                 
                        Model model = new Model();


                        model.Name = InputTester.ReadString("Type Name of model");

                        model.MarkaId = chooseMarka.Id;

                        

                        modelStore.Add(model);

                        Console.Clear();
                        break;

                    case 6:
                        GetAllModels();


                        modelid = InputTester.ReadInteger("Model id: ");

                        var foundModel = modelStore.Find(g => g.Id == modelid);

                        if (foundModel == null)
                        {
                            Console.WriteLine("Such model does exists (Press any key to go back to menu : ");
                            Console.ReadKey();
                            break;
                        }
                        foundModel.Name = InputTester.ReadString("Model name: ");

                        

                      
                        Console.Clear();
                        GetAllModels();
                        Console.Write("Please press any key go to menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto l1;
                     
                    case 7:

                        GetAllModels();
                    l4:
                        modelid = InputTester.ReadInteger("Marka id: ");

                        if (!markaStore.Exists(x => x.Id == modelid))
                        {
                            Console.WriteLine("Not in the list: ");
                            goto l4;
                        }

                        Model foundmodel = modelStore.Find(g => g.Id == modelid);

                        modelStore.Remove(foundmodel);
                        GetAllModels();
                        Console.ReadKey();
                        break;
                        
                    case 8:
                        Console.Clear();
                        GetAllModels();
                        Console.Write("Please press any key go to menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto l1;
                       
                    case 9:


                        Console.Clear();
                        Console.WriteLine("Choose from the list: ");
                        GetAllModels();
                        carid = InputTester.ReadInteger("Car id: ");

                        var chooseCar = modelStore.Find(g => g.Id == carid);

                        if (chooseCar == null)
                        {
                            Console.WriteLine("Such car does exists (Press any key to go back to menu : ");
                            Console.ReadKey();
                            break;
                        }

                        Car car = new Car();


                        car.Name = InputTester.ReadString("Type Name of car: ");
                        car.ModelId = chooseCar.Id;
                            
                        car.Year = InputTester.YearCheck("Type Year of car: ");
                        car.BanNo = InputTester.ReadInteger("Type BanNo of car: ");
                        car.EngineVolume = InputTester.ReadDouble("Type EngineVolume of car: ");
                        car.Gearbox = InputTester.ReadString("Type Gearbox of car: ");
                        car.Color = InputTester.ReadString("Type Color of car: ");
                        car.Price = InputTester.ReadDouble("Type Price of car: ");

                        carStore.Add(car);

                        Console.Clear();

                        break;
                    case 10:
                       GetAllCars();    


                        carid = InputTester.ReadInteger("Model id: ");

                        var foundcar = carStore.Find(g => g.Id == carid);

                        if (foundcar == null)
                        {
                            Console.WriteLine("Such model does exists (Press any key to go back to menu : ");
                            Console.ReadKey();
                            break;
                        }
                        foundcar.Name = InputTester.ReadString("Model name: ");
                        foundcar.Year = InputTester.YearCheck("Type Year of car");
                        foundcar.BanNo = InputTester.ReadInteger("Type BanNo of car");
                        foundcar.EngineVolume = InputTester.ReadDouble("Type EngineVolume of car");
                        foundcar.Gearbox = InputTester.ReadString("Type Gearbox of car");
                        foundcar.Color = InputTester.ReadString("Type Color of car");
                        foundcar.Price = InputTester.ReadDouble("Type Price of car");

                        Console.Clear();
                        GetAllModels();
                        Console.Write("Please press any key go to menu");
                        Console.ReadKey();
                        Console.Clear();
                       
                        break;

                    case 11:

                        GetAllModels();
                    l45:
                        carid = InputTester.ReadInteger("Marka id: ");

                        if (!markaStore.Exists(x => x.Id == carid))
                        {
                            Console.WriteLine("Siyahidan secilmelidir: ");
                            goto l45;
                        }

                        Car foundcar1 = carStore.Find(g => g.Id == carid);

                        carStore.Remove(foundcar1);
                        GetAllModels();
                        Console.ReadKey();
                        break;

                    case 12:
                        GetAllCars();
                        Console.ReadKey();
                        break;

                    case 13:
                        Console.Clear();
                        Console.WriteLine("Saving....");
                        Task.Delay(1500).Wait();

                        Console.WriteLine("Saved!");


                        CarsContext db = new CarsContext();

                        carStore = db.CarsGroup;
                        modelStore = db.ModelsGroup;
                        markaStore = db.MarkasGroup;

                        using (var file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            BinaryFormatter bf = new BinaryFormatter();

                            bf.Serialize(file, db);
                        }

                        goto l1;


                    case 14:

                        break;

                    case 15:
                        hasCancel = true;

                        break;



                }

                static void PrintMenu()
                {
                    Console.WriteLine("1: Add new Marka");
                    Console.WriteLine("2: Edit Marka");
                    Console.WriteLine("3: Remove Marka");
                    Console.WriteLine("4: View list of Markas");
                    Console.WriteLine("5: Add new Model");
                    Console.WriteLine("6: Edit Model");
                    Console.WriteLine("7: Remove Model");
                    Console.WriteLine("8: View list of Model");
                    Console.WriteLine("9: Add new Car");
                    Console.WriteLine("10: Edit Car");
                    Console.WriteLine("11: Remove Car");
                    Console.WriteLine("12: View list of Cars");
                    Console.WriteLine("13: Save");
                    Console.WriteLine("14: Load");
                    Console.WriteLine("15: Exit");




                }





                static void GetAllCars()
                {
                    GetAllModels();

                    int carid = InputTester.ReadInteger("Model id: ");
                    if (carid > 0)
                    {
                        var chooseGroup = modelStore.Find(s => s.Id == carid);

                        var chooseItems = carStore.FindAll(s => s.Id == carid);

                        Console.WriteLine($"## List of Markas => {chooseGroup.Name}##");

                        foreach (var item in chooseItems)
                        {
                            var group = modelStore.Find(g => g.Id == item.Id);

                            Console.WriteLine($"{item}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("## List of Cars ##");
                        foreach (var item in carStore)
                        {
                            var group = carStore.Find(g => g.Id == item.Id);

                            Console.WriteLine($"{item}");
                        }
                    }



                }


                static void  GetAllModels()
                {
                    GetAllMarkas();

                    int markaId = InputTester.ReadInteger("Marka id: ");


                    if (markaId > 0)
                    {
                        var chooseGroup = markaStore.Find(s => s.Id == markaId);

                        var chooseItems = modelStore.FindAll(s => s.Id == markaId);

                        Console.WriteLine($"## List of Models => {chooseGroup.Name}##");

                        foreach (var item in chooseItems)
                        {
                            var group = markaStore.Find(g => g.Id == item.Id);

                            Console.WriteLine($"{item}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("## List of Models ##");
                        foreach (var item in modelStore)
                        {
                            var group = modelStore.Find(g => g.Id == item.Id);

                            Console.WriteLine($"{group.Name}: {item}");
                        }
                    }

                    







                }


                static void GetAllMarkas()
                {

                    Console.WriteLine("## List of Markas ##");
                    foreach (var item in markaStore)
                    {
                        Console.WriteLine(item);
                    }
                }


            }
        }
    }


}
