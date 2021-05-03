using MagicBaseData.Enums;
using MagicBaseData.Interfaces;
using MagicBaseData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace MagicBaseData.Controllers
{
    public class Controller : IController
    {
        public static Controller peopleController;
        private static Controller instance;
        private List<Magician> data;

        private Controller () {
            data = new List<Magician>();
        }
        public static Controller GetInstance()
        {
            if (instance == null)
            {
                instance = new Controller();
            }
            return instance;
        }

        public void Create(Magician character)
        {
            data.Add(character);
        }
        public void Read(string path)
        {
            data.Clear();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var str = line.Split(',');
                        data.Add(new Magician {
                            Id = int.Parse(str[0]),
                            Name = str[1],
                            power = double.Parse(str[2]),
                            Speed = double.Parse(str[3]),
                            HitPoints = int.Parse(str[4]),
                            KindOfMagic = (KindOfMagic)Enum.Parse(typeof(KindOfMagic), str[5]) }) ;
                      
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Write(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    for (var i = 0; i < data.Count; i++)
                    {
                        sw.WriteLine(data[i].ToString());
                    }
                    sw.Close();
                }
                // File.WriteAllLines(path, );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(Magician item)
        {
            var ind = data.FindIndex(s => s.Id.Equals(item.Id));

            data[ind].Name = item.Name;
            data[ind].power = item.power;
            data[ind].Speed = item.Speed;
            data[ind].HitPoints = item.HitPoints;
            data[ind].KindOfMagic = item.KindOfMagic;
        }
        public void Delete(int id)
        {
            data.Remove(data.Where(d => d.Id==id).FirstOrDefault());
        }
        public IEnumerable<Magician> GetAll()
        {
            return data;
        }
        public IEnumerable<Magician> Search(string character)
        {
            List<Magician> result = new List<Magician>();
            for (var i = 0; i < data.Count; i++)
            {
                if (data[i].ToString().ToLower().Contains(character.ToLower()) && character.Contains(",") == false)
                {
                    result.Add(data[i]);
                }
            }
            return result;
        }
        public void CheekTheSamePerson()
        {
            for (var i = 0; i < data.Count; i++)
            {
                for (var j = 0; j < data.Count; j++)
                {
                    if (data[i]==data[j])
                    {
                        data.RemoveAt(i);
                    }
                }
            }
        }
        public string indexSearch(int id)
        {
            string result = " ";
            for (var i = 0; i < data.Count; i++)
            {
                if (data[i].Id == id)
                {
                    return data[i].ToString();
                }
                else
                {
                    return "Magician not found" ;
                }
            }
            return result;
        }
    }
}
