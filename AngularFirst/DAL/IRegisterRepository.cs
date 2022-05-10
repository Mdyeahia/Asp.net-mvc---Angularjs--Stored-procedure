using AngularFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularFirst.DAL
{
    public interface IRegisterRepository
    {
        IEnumerable<Register> GetRegisters();
        Register GetRegisterByID(int id);
        void InsertRegister(Register register);
        void DeleteRegister(int id);
        void UpdateRegister(Register register);
        void Save();
    }
}
