using MagicBaseData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBaseData.Interfaces
{
    public interface IController
    {
        void Create(Magician character);
        void Read(string path);
        void Write(string path);
        void Update(Magician character);
        void Delete(int id);
        IEnumerable<Magician> Search(string character);
        IEnumerable<Magician> GetAll();
    }
}
